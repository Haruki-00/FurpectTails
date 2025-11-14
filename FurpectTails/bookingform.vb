Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports Microsoft.Data.SqlClient

Public Class BookingForm
    Private connectionString As String = "Server=MARIAKRISTINA\SQLEXPRESS;Database=FurpectTailsDB;Integrated Security=True;TrustServerCertificate=True"
    Private bookingID As Integer = 0
    Private UnitID As Integer
    Private UnitNumber As Integer

    Public Sub New(unitId As Integer, unitNumber As Integer)
        InitializeComponent()
        Me.UnitID = unitId
        Me.UnitNumber = unitNumber
    End Sub

    ' ======================== SUPPORT CLASS ========================
    Private Class ComboItem
        Public Property ID As Integer
        Public Property Name As String
        Public Overrides Function ToString() As String
            Return Name
        End Function
    End Class

    ' ======================== FORM LOAD ========================
    Private Sub BookingForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadClients()
        LoadPaymentMethods()
        LoadServiceTypes()
        LoadStatus()
        LoadBookingDetails()
    End Sub

    ' ======================== LOAD FUNCTIONS ========================
    Private Sub LoadClients()
        clientcmb.Items.Clear()
        Using con As New SqlConnection(connectionString)
            con.Open()
            Using cmd As New SqlCommand("SELECT ClientID, FirstName + ' ' + LastName AS FullName FROM ClientTable", con)
                Using rdr As SqlDataReader = cmd.ExecuteReader()
                    While rdr.Read()
                        clientcmb.Items.Add(New ComboItem With {.ID = CInt(rdr("ClientID")), .Name = rdr("FullName").ToString()})
                    End While
                End Using
            End Using
        End Using
        clientcmb.SelectedIndex = -1
    End Sub

    Private Sub LoadPets(Optional clientID As Integer = 0)
        petcmb.Items.Clear()
        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim query As String = If(clientID > 0, "SELECT PetID, PetName FROM PetTable WHERE ClientID=@ClientID", "SELECT PetID, PetName FROM PetTable")
            Using cmd As New SqlCommand(query, con)
                If clientID > 0 Then
                    cmd.Parameters.AddWithValue("@ClientID", clientID)
                End If
                Using rdr As SqlDataReader = cmd.ExecuteReader()
                    While rdr.Read()
                        petcmb.Items.Add(New ComboItem With {.ID = CInt(rdr("PetID")), .Name = rdr("PetName").ToString()})
                    End While
                End Using
            End Using
        End Using
        petcmb.SelectedIndex = -1
    End Sub

    Private Sub LoadPaymentMethods()
        paymentcmb.Items.Clear()
        paymentcmb.Items.AddRange(New String() {"Cash", "Card", "GCash"})
        paymentcmb.SelectedIndex = -1
    End Sub

    Private Sub LoadServiceTypes()
        typecmb.Items.Clear()
        typecmb.Items.AddRange(New String() {"Overnight Stay", "Day Care"})
        typecmb.SelectedIndex = -1
    End Sub

    Private Sub LoadStatus()
        statuscmb.Items.Clear()
        statuscmb.Items.AddRange(New String() {"Booked", "Reserved", "Completed"})
        statuscmb.SelectedIndex = -1
    End Sub

    Private Sub LoadBookingDetails()
        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim query As String = "SELECT TOP 1 * FROM BookingTable WHERE UnitID=@UnitID AND UnitNumber=@UnitNumber AND Status IN ('Booked', 'Reserved') ORDER BY BookingID DESC"
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@UnitID", UnitID)
                cmd.Parameters.AddWithValue("@UnitNumber", UnitNumber)

                Using rdr As SqlDataReader = cmd.ExecuteReader()
                    If rdr.Read() Then
                        bookingID = CInt(rdr("BookingID"))
                        startdtp.Value = If(IsDBNull(rdr("StartTime")), DateTime.Now, CDate(rdr("StartTime")))
                        enddtp.Value = If(IsDBNull(rdr("EndTime")), DateTime.Now, CDate(rdr("EndTime")))
                        statuscmb.Text = If(IsDBNull(rdr("Status")), "", rdr("Status").ToString())
                        paymentcmb.Text = If(IsDBNull(rdr("PaymentMethod")), "", rdr("PaymentMethod").ToString())
                        typecmb.Text = If(IsDBNull(rdr("ServiceType")), "", rdr("ServiceType").ToString())

                        Dim clientIdValue As Integer = If(IsDBNull(rdr("ClientID")), 0, CInt(rdr("ClientID")))
                        For Each item As ComboItem In clientcmb.Items
                            If item.ID = clientIdValue Then
                                clientcmb.SelectedItem = item
                                Exit For
                            End If
                        Next

                        If clientIdValue > 0 Then
                            LoadPets(clientIdValue)
                            Dim petIdValue As Integer = If(IsDBNull(rdr("PetID")), 0, CInt(rdr("PetID")))
                            For Each item As ComboItem In petcmb.Items
                                If item.ID = petIdValue Then
                                    petcmb.SelectedItem = item
                                    Exit For
                                End If
                            Next
                        End If

                        savebtn.Text = "Update Booking"
                    Else
                        savebtn.Text = "Save Booking"
                    End If
                End Using
            End Using
        End Using
    End Sub

    Private Sub clientcmb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles clientcmb.SelectedIndexChanged
        If clientcmb.SelectedItem IsNot Nothing Then
            Dim selectedClientID As Integer = CType(clientcmb.SelectedItem, ComboItem).ID
            LoadPets(selectedClientID)
        Else
            LoadPets()
        End If
    End Sub

    ' ======================== SAVE OR UPDATE BOOKING ========================
    Private Sub savebtn_Click(sender As Object, e As EventArgs) Handles savebtn.Click
        If clientcmb.SelectedItem Is Nothing OrElse petcmb.SelectedItem Is Nothing OrElse String.IsNullOrWhiteSpace(paymentcmb.Text) Then
            MessageBox.Show("Please select Client, Pet, and Payment Method.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim clientID As Integer = CType(clientcmb.SelectedItem, ComboItem).ID
        Dim petID As Integer = CType(petcmb.SelectedItem, ComboItem).ID
        Dim startTime As DateTime = startdtp.Value
        Dim endTime As DateTime = enddtp.Value
        Dim paymentMethod As String = paymentcmb.Text
        Dim status As String = statuscmb.Text.Trim()

        If status = "Completed" Then
            endTime = DateTime.Now
            enddtp.Value = endTime
        End If

        Using conn As New SqlConnection(connectionString)
            conn.Open()

            If bookingID = 0 Then
                Dim insertBooking As String = "INSERT INTO BookingTable (ClientID, PetID, UnitID, UnitNumber, StartTime, EndTime, Status, PaymentMethod, ServiceType, IsActive) OUTPUT INSERTED.BookingID VALUES (@ClientID, @PetID, @UnitID, @UnitNumber, @StartTime, @EndTime, @Status, @PaymentMethod, @ServiceType, 1)"
                Using cmd As New SqlCommand(insertBooking, conn)
                    cmd.Parameters.AddWithValue("@ClientID", clientID)
                    cmd.Parameters.AddWithValue("@PetID", petID)
                    cmd.Parameters.AddWithValue("@UnitID", UnitID)
                    cmd.Parameters.AddWithValue("@UnitNumber", UnitNumber)
                    cmd.Parameters.AddWithValue("@StartTime", startTime)
                    cmd.Parameters.AddWithValue("@EndTime", endTime)
                    cmd.Parameters.AddWithValue("@Status", status)
                    cmd.Parameters.AddWithValue("@ServiceType", typecmb.Text)
                    cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod)
                    bookingID = Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            Else
                Dim updateBooking As String = "
                UPDATE BookingTable 
                SET Status=@Status, 
                    PaymentMethod=@PaymentMethod, 
                    StartTime=@StartTime,
                    EndTime=@EndTime 
                WHERE BookingID=@BookingID"
                Using cmd As New SqlCommand(updateBooking, conn)
                    cmd.Parameters.AddWithValue("@Status", status)
                    cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod)
                    cmd.Parameters.AddWithValue("@StartTime", startTime)
                    cmd.Parameters.AddWithValue("@EndTime", endTime)
                    cmd.Parameters.AddWithValue("@BookingID", bookingID)
                    cmd.ExecuteNonQuery()
                End Using
            End If

            MessageBox.Show("Booking saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Using

        ' ================= RECEIPT GENERATION =================
        If status = "Completed" Then
            Dim clientName As String = clientcmb.Text
            Dim petName As String = petcmb.Text
            Dim unitNumber As String = Me.UnitNumber.ToString()
            Dim checkinDate As DateTime = startTime
            Dim checkoutDate As DateTime = endTime
            Dim totalAmount As Decimal

            Using conn As New SqlConnection(connectionString)
                conn.Open()
                totalAmount = GenerateBilling(conn, checkinDate, checkoutDate, paymentMethod, clientID)
            End Using

            Dim receiptText As String = $"--- Furpect Tails Pet Hotel Receipt ---" & Environment.NewLine &
                $"Date: {DateTime.Now}" & Environment.NewLine &
                $"Booking ID: {bookingID}" & Environment.NewLine &
                $"Client Name: {clientName}" & Environment.NewLine &
                $"Pet Name: {petName}" & Environment.NewLine &
                $"Unit: {unitNumber}" & Environment.NewLine &
                $"Status: {status}" & Environment.NewLine &
                $"Check-in: {checkinDate:MMMM dd, yyyy hh:mm tt}" & Environment.NewLine &
                $"Check-out: {checkoutDate:MMMM dd, yyyy hh:mm tt}" & Environment.NewLine &
                $"Total Amount: ₱{totalAmount:N2}" & Environment.NewLine &
                $"----------------------------------------" & Environment.NewLine &
                $"Thank you for trusting Furpect Tails!"

            Dim receiptForm As New receipthotelform()
            receiptForm.Receipthoteltext = receiptText
            receiptForm.ShowDialog()
        End If

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    ' ======================== GET TOTAL AMOUNT ========================
    Private Function GetTotalAmount(bookingID As Integer) As Decimal
        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Dim cmd As New SqlCommand("SELECT TOP 1 TotalAmount FROM BillingTable WHERE BookingID=@BookingID ORDER BY BillDate DESC", conn)
            cmd.Parameters.AddWithValue("@BookingID", bookingID)
            Dim result = cmd.ExecuteScalar()
            If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                Return Convert.ToDecimal(result)
            End If
        End Using
        Return 0D
    End Function

    ' ======================== BILLING FUNCTION WITH DISCOUNT ========================
    Private Function GenerateBilling(conn As SqlConnection, startTime As DateTime, endTime As DateTime, paymentMethod As String, clientID As Integer) As Decimal
        Dim sizeType As String = String.Empty
        Dim unitName As String = String.Empty
        Using cmd As New SqlCommand("SELECT SizeType, UnitName FROM UnitTable WHERE UnitID=@UnitID", conn)
            cmd.Parameters.AddWithValue("@UnitID", UnitID)
            Using rdr As SqlDataReader = cmd.ExecuteReader()
                If rdr.Read() Then
                    sizeType = If(IsDBNull(rdr("SizeType")), String.Empty, rdr("SizeType").ToString().ToLower())
                    unitName = If(IsDBNull(rdr("UnitName")), String.Empty, rdr("UnitName").ToString())
                End If
            End Using
        End Using

        Dim serviceType As String = typecmb.Text.Trim().ToLower()
        Dim totalHours As Double = (endTime - startTime).TotalHours
        Dim totalAmount As Decimal = 0D

        ' ----- BASE PRICING -----
        If serviceType.Contains("day care") Then
            Dim baseRate As Decimal = If(sizeType.Contains("small"), 200D, 400D)
            If totalHours <= 3 Then
                totalAmount = baseRate
            Else
                Dim extraHours As Double = Math.Ceiling(totalHours - 3)
                totalAmount = baseRate + (extraHours * 50D)
            End If
        ElseIf serviceType.Contains("overnight stay") Then
            Dim baseRate As Decimal = If(sizeType.Contains("small"), 500D, 800D)
            If totalHours <= 24 Then
                totalAmount = baseRate
            Else
                Dim extraHours As Double = Math.Ceiling(totalHours - 24)
                totalAmount = baseRate + (extraHours * 50D)
            End If
        End If

        ' ----- COUNT PREVIOUS COMPLETED BOOKINGS -----
        Dim bookingCount As Integer
        Using cmdCount As New SqlCommand("SELECT COUNT(*) FROM BookingTable WHERE ClientID=@ClientID AND Status='Completed'", conn)
            cmdCount.Parameters.AddWithValue("@ClientID", clientID)
            bookingCount = Convert.ToInt32(cmdCount.ExecuteScalar()) + 1
        End Using

        ' ----- INSERT BILLING -----
        Dim insertBilling As String = "INSERT INTO BillingTable (BookingID, TotalAmount, PaymentMethod, BillDate, Status) VALUES (@BookingID, @TotalAmount, @PaymentMethod, GETDATE(), 'Pending')"
        Using cmd As New SqlCommand(insertBilling, conn)
            cmd.Parameters.AddWithValue("@BookingID", bookingID)
            cmd.Parameters.AddWithValue("@TotalAmount", totalAmount)
            cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod)
            cmd.ExecuteNonQuery()
        End Using

        Return totalAmount
    End Function

    ' ======================== CANCEL BOOKING ========================
    Private Sub cancelbtn_Click(sender As Object, e As EventArgs) Handles cancelbtn.Click
        If bookingID = 0 Then
            MessageBox.Show("No active booking to cancel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim confirm As DialogResult = MessageBox.Show(
            "Are you sure you want to cancel this booking?",
            "Confirm Cancellation",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        )

        If confirm = DialogResult.No Then Exit Sub

        Using con As New SqlConnection(connectionString)
            con.Open()

            ' Cancel booking
            Dim cancelQuery As String = "UPDATE BookingTable SET Status='Canceled', IsActive=0 WHERE BookingID=@BookingID"
            Using cmd As New SqlCommand(cancelQuery, con)
                cmd.Parameters.AddWithValue("@BookingID", bookingID)
                cmd.ExecuteNonQuery()
            End Using

            ' Free unit
            Dim unitQuery As String = "UPDATE UnitTable SET IsBooked=0 WHERE UnitID=@UnitID"
            Using cmd As New SqlCommand(unitQuery, con)
                cmd.Parameters.AddWithValue("@UnitID", UnitID)
                cmd.ExecuteNonQuery()
            End Using
        End Using

        MessageBox.Show("Booking has been canceled and the unit is now available.", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub
End Class
