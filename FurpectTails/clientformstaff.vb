Imports Microsoft.Data.SqlClient
Imports Microsoft.Identity

Public Class clientformstaff
    Private ReadOnly connectionString As String = "Server=MARIAKRISTINA\SQLEXPRESS;Database=FurpectTailsDB;Integrated Security=True;TrustServerCertificate=True"
    Private selectedServices As New List(Of Integer)()

    ' ---------------- FORM LOAD ----------------
    Private Sub StaffForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadClients()
        LoadAppointments()
        LoadBilling()
        LoadClientCombo()
        LoadPetCombo()
        LoadServiceCombo()
        LoadAppointmentCombo()
        InitializeSelectedServicesGrid()

        petdg.DataSource = Nothing
        pettotalcounttxt.Clear()
    End Sub

    ' ================= HISTORY SEARCH =================
    Private Sub LoadCustomerHistory(search As String)
        Using con As New SqlConnection(connectionString)
            Dim query As String

            If IsNumeric(search) Then
                query = "SELECT ClientID, LastName, FirstName, MiddleName, Address, PhoneNumber, Gender 
                     FROM ClientTable WHERE ClientID = @search"
            Else
                query = "SELECT ClientID, LastName, FirstName, MiddleName, Address, PhoneNumber, Gender 
                     FROM ClientTable WHERE FirstName LIKE @search OR LastName LIKE @search"
            End If

            Using cmd As New SqlCommand(query, con)
                If IsNumeric(search) Then
                    cmd.Parameters.AddWithValue("@search", Convert.ToInt32(search))
                Else
                    cmd.Parameters.AddWithValue("@search", "%" & search & "%")
                End If

                Dim dt As New DataTable()
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)

                Select Case dt.Rows.Count
                    Case 1
                        Dim row As DataRow = dt.Rows(0)
                        firstnametxt.Text = row("FirstName").ToString()
                        lastnametxt.Text = row("LastName").ToString()
                        midnametxt.Text = row("MiddleName").ToString()
                        addresstxt.Text = row("Address").ToString()
                        numbertxt.Text = row("PhoneNumber").ToString()
                        clientgendercmb.Text = row("Gender").ToString()

                        ' Automatically load the client’s pets
                        Dim clientID As Integer = Convert.ToInt32(row("ClientID"))
                        LoadPetsByClient(clientID)

                    Case > 1
                        clientsdg.DataSource = dt
                        ClearClient()
                    Case Else
                        MessageBox.Show("No customer found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ClearClient()
                End Select
            End Using
        End Using
    End Sub



    ' ---------------- SEARCH PET ----------------
    Private Sub petsearchtxt_TextChanged(sender As Object, e As EventArgs) Handles petsearchtxt.TextChanged
        Dim searchID As String = petsearchtxt.Text.Trim()

        If String.IsNullOrWhiteSpace(searchID) Then
            Return
        End If

        Using con As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("SELECT * FROM PetTable WHERE PetID = @PetID", con)
            cmd.Parameters.AddWithValue("@PetID", searchID)
            Dim dt As New DataTable()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
            petdg.DataSource = dt
        End Using
    End Sub

    ' ---------------- LOAD DATA ----------------
    Private Sub LoadClients()
        Using conn As New SqlConnection(connectionString)
            Dim dt As New DataTable()
            Dim da As New SqlDataAdapter("
    SELECT c.ClientID, c.LastName, c.FirstName, c.MiddleName, c.Address,
           STRING_AGG(p.PhoneNumber, ', ') AS PhoneNumbers,
           c.Gender
    FROM ClientTable c
    LEFT JOIN ClientPhoneTable p ON c.ClientID = p.ClientID
    GROUP BY c.ClientID, c.LastName, c.FirstName, c.MiddleName, c.Address, c.Gender", conn)
            da.Fill(dt)
            clientsdg.DataSource = dt
        End Using
        clientsdg.ReadOnly = True
    End Sub

    Private Sub LoadPets()
        Using conn As New SqlConnection(connectionString)
            Dim dt As New DataTable()
            Dim da As New SqlDataAdapter("SELECT PetID, PetName, PetBreed, PetAge, Species, Gender, ClientID FROM PetTable", conn)
            da.Fill(dt)
            petdg.DataSource = dt
        End Using
        petdg.ReadOnly = True
    End Sub

    Private Sub LoadAppointmentComboByClient(clientID As Integer)
        Using conn As New SqlConnection(connectionString)
            Dim dt As New DataTable()
            Dim query As String = "
            SELECT a.AppointmentID 
            FROM AppointmentTable a
            INNER JOIN PetTable p ON a.PetID = p.PetID
            WHERE p.ClientID = @ClientID"
            Dim da As New SqlDataAdapter(query, conn)
            da.SelectCommand.Parameters.AddWithValue("@ClientID", clientID)
            da.Fill(dt)

            appcmb.DataSource = dt
            appcmb.DisplayMember = "AppointmentID"
            appcmb.ValueMember = "AppointmentID"
            appcmb.SelectedIndex = -1
        End Using
    End Sub

    Private Sub LoadAppointments(Optional clientID As Integer? = Nothing)
        Using conn As New SqlConnection(connectionString)
            Dim dt As New DataTable()
            Dim query As String

            If clientID.HasValue Then
                ' Only load appointments for that client (when clicked in clientsdg)
                query = "
                SELECT a.AppointmentID, a.PetID, a.AppointmentDate, a.Status
                FROM AppointmentTable a
                INNER JOIN PetTable p ON a.PetID = p.PetID
                WHERE p.ClientID = @ClientID
                ORDER BY a.AppointmentDate DESC"
            Else
                ' Default: today's appointments
                query = "
                SELECT AppointmentID, PetID, AppointmentDate, Status
                FROM AppointmentTable
                WHERE CAST(AppointmentDate AS DATE) = CAST(GETDATE() AS DATE)
                ORDER BY AppointmentDate DESC"
            End If

            Using da As New SqlDataAdapter(query, conn)
                If clientID.HasValue Then
                    da.SelectCommand.Parameters.AddWithValue("@ClientID", clientID.Value)
                End If
                da.Fill(dt)
            End Using

            appdg.DataSource = dt
        End Using

        appdg.ReadOnly = True
    End Sub


    Private Sub LoadBilling()
        Using conn As New SqlConnection(connectionString)
            Dim dt As New DataTable()
            Dim query As String = "
                SELECT BillID, AppointmentID, TotalAmount, PaymentMethod, BillDate 
                FROM BillingTable 
                WHERE CAST(BillDate AS DATE) = CAST(GETDATE() AS DATE)"
            Dim da As New SqlDataAdapter(query, conn)
            da.Fill(dt)
            billingdt.DataSource = dt
        End Using
        billingdt.ReadOnly = True
    End Sub

    ' ---------------- LOAD COMBOS ----------------
    Private Sub LoadClientCombo()
        Using conn As New SqlConnection(connectionString)
            Dim dt As New DataTable()
            Dim da As New SqlDataAdapter("SELECT ClientID, FirstName + ' ' + LastName AS FullName FROM ClientTable", conn)
            da.Fill(dt)
            clientownercmb.DataSource = dt
            clientownercmb.DisplayMember = "FullName"
            clientownercmb.ValueMember = "ClientID"
            clientownercmb.SelectedIndex = -1
        End Using
    End Sub

    Private Sub LoadPetCombo()
        If clientownercmb.SelectedValue Is Nothing Then
            petcmb.DataSource = Nothing
            petcmb.Items.Clear()
            petcmb.SelectedIndex = -1
            Return
        End If

        Dim clientID As Integer = Convert.ToInt32(clientownercmb.SelectedValue)

        Using conn As New SqlConnection(connectionString)
            Dim dt As New DataTable()
            Dim da As New SqlDataAdapter("
            SELECT PetID, PetName 
            FROM PetTable 
            WHERE ClientID = @ClientID", conn)
            da.SelectCommand.Parameters.AddWithValue("@ClientID", clientID)
            da.Fill(dt)

            petcmb.DataSource = dt
            petcmb.DisplayMember = "PetName"
            petcmb.ValueMember = "PetID"
            petcmb.SelectedIndex = -1
        End Using
    End Sub


    Private Sub LoadServiceCombo()
        Using conn As New SqlConnection(connectionString)
            Dim dt As New DataTable()
            Dim da As New SqlDataAdapter("SELECT ServiceID, ServiceName FROM ServiceTable", conn)
            da.Fill(dt)
            servicecmb.DataSource = dt
            servicecmb.DisplayMember = "ServiceName"
            servicecmb.ValueMember = "ServiceID"
            servicecmb.SelectedIndex = -1
        End Using
    End Sub
    Private Sub LoadAppointmentCombo()
        Using conn As New SqlConnection(connectionString)
            Dim dt As New DataTable()
            Dim query As String = "
            SELECT AppointmentID 
            FROM AppointmentTable
            ORDER BY AppointmentID DESC"
            Dim da As New SqlDataAdapter(query, conn)
            da.Fill(dt)
            appcmb.DataSource = dt
            appcmb.DisplayMember = "AppointmentID"
            appcmb.ValueMember = "AppointmentID"
            appcmb.SelectedIndex = -1
        End Using
    End Sub

    Private Sub LoadPetsByClient(clientID As Integer)
        Using conn As New SqlConnection(connectionString)
            Dim dt As New DataTable()
            Dim query As String = "SELECT PetID, PetName, PetBreed, PetAge, Species, Gender, ClientID 
                               FROM PetTable WHERE ClientID = @ClientID"
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ClientID", clientID)
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                petdg.DataSource = dt
            End Using
        End Using
        petdg.ReadOnly = True
    End Sub

    ' ---------------- CLIENT ----------------
    Private Sub clientsavebtn_Click(sender As Object, e As EventArgs) Handles clientsavebtn.Click
        If Not ValidateClientInputs(lastnametxt, firstnametxt, midnametxt, addresstxt, numbertxt, clientgendercmb) Then
            Exit Sub
        End If
        Using conn As New SqlConnection(connectionString)
            conn.Open()

            Dim query = "INSERT INTO ClientTable (LastName, FirstName, MiddleName, Address, Gender)
                     OUTPUT INSERTED.ClientID
                     VALUES (@LastName, @FirstName, @MiddleName, @Address, @Gender)"

            Dim clientID As Integer
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@LastName", lastnametxt.Text)
                cmd.Parameters.AddWithValue("@FirstName", firstnametxt.Text)
                cmd.Parameters.AddWithValue("@MiddleName", midnametxt.Text)
                cmd.Parameters.AddWithValue("@Address", addresstxt.Text)
                cmd.Parameters.AddWithValue("@Gender", clientgendercmb.Text)
                clientID = Convert.ToInt32(cmd.ExecuteScalar())
            End Using

            If Not String.IsNullOrWhiteSpace(numbertxt.Text) Then
                Dim phoneNumbers() As String = numbertxt.Text.Split({",", vbCrLf}, StringSplitOptions.RemoveEmptyEntries)
                For Each phone As String In phoneNumbers
                    Dim trimmedPhone As String = phone.Trim()
                    If trimmedPhone <> "" Then
                        Using phoneCmd As New SqlCommand("INSERT INTO ClientPhoneTable (ClientID, PhoneNumber) VALUES (@ClientID, @PhoneNumber)", conn)
                            phoneCmd.Parameters.AddWithValue("@ClientID", clientID)
                            phoneCmd.Parameters.AddWithValue("@PhoneNumber", trimmedPhone)
                            phoneCmd.ExecuteNonQuery()
                        End Using
                    End If
                Next
            End If
        End Using

        LoadClients()
        LoadClientCombo()
        MessageBox.Show("Client and phone numbers saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ClearClient()
    End Sub

    Private Sub custidtxt_Leave(sender As Object, e As EventArgs) Handles custidtxt.Leave
        If Not String.IsNullOrWhiteSpace(custidtxt.Text) Then
            LoadCustomerHistory(custidtxt.Text.Trim())
        End If
    End Sub

    Private Sub sbmtcstmrbtn_Click(sender As Object, e As EventArgs) Handles sbmtcstmrbtn.Click
        LoadCustomerHistory(custidtxt.Text.Trim())
    End Sub

    Private Sub clientsdg_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles clientsdg.CellClick
        If e.RowIndex < 0 Then Exit Sub
        Dim row = clientsdg.Rows(e.RowIndex)
        Dim clientID As Integer = Convert.ToInt32(row.Cells("ClientID").Value)

        lastnametxt.Text = row.Cells("LastName").Value.ToString()
        firstnametxt.Text = row.Cells("FirstName").Value.ToString()
        midnametxt.Text = row.Cells("MiddleName").Value.ToString()
        clientgendercmb.Text = row.Cells("Gender").Value.ToString()
        addresstxt.Text = row.Cells("Address").Value.ToString()

        clientownercmb.SelectedValue = clientID

        Using phoneCon As New SqlConnection(connectionString)
            phoneCon.Open()
            Dim phoneQuery As String = "SELECT PhoneNumber FROM ClientPhoneTable WHERE ClientID = @ClientID"
            Using phoneCmd As New SqlCommand(phoneQuery, phoneCon)
                phoneCmd.Parameters.AddWithValue("@ClientID", clientID)
                Using reader As SqlDataReader = phoneCmd.ExecuteReader()
                    Dim phoneList As New List(Of String)()
                    While reader.Read()
                        phoneList.Add(reader("PhoneNumber").ToString())
                    End While
                    numbertxt.Text = String.Join(Environment.NewLine, phoneList)
                End Using
            End Using
        End Using

        Using conn As New SqlConnection(connectionString)
            conn.Open()

            Dim petQuery As String = "SELECT PetID, PetName, PetBreed, PetAge, Species, Gender, ClientID 
                                  FROM PetTable WHERE ClientID = @ClientID"
            Dim petDa As New SqlDataAdapter(petQuery, conn)
            petDa.SelectCommand.Parameters.AddWithValue("@ClientID", clientID)
            Dim petDt As New DataTable()
            petDa.Fill(petDt)
            petdg.DataSource = petDt
            pettotalcounttxt.Text = petDt.Rows.Count.ToString()

            Dim petCmbQuery As String = "SELECT PetID, PetName FROM PetTable WHERE ClientID = @ClientID"
            Dim petCmbDa As New SqlDataAdapter(petCmbQuery, conn)
            petCmbDa.SelectCommand.Parameters.AddWithValue("@ClientID", clientID)
            Dim petCmbDt As New DataTable()
            petCmbDa.Fill(petCmbDt)
            petcmb.DataSource = petCmbDt
            petcmb.DisplayMember = "PetName"
            petcmb.ValueMember = "PetID"
            petcmb.SelectedIndex = -1

            LoadAppointments(clientID)
        End Using

        LoadAppointmentComboByClient(clientID)
        LoadServiceCombo()
    End Sub

    ' ---------------- PET ----------------
    Private Sub savepetbtn_Click(sender As Object, e As EventArgs) Handles savepetbtn.Click
        If Not ValidatePetInputs(petnametxt, petbreedtxt, petagetxt, speciescmb, petgendercmb, clientownercmb) Then
            Exit Sub
        End If

        If clientownercmb.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a client owner before adding a pet.", "Missing Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim clientID As Integer = Convert.ToInt32(clientownercmb.SelectedValue)

        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim query As String = "INSERT INTO PetTable (PetName, PetBreed, PetAge, Species, Gender, ClientID)
                               VALUES (@PetName, @PetBreed, @PetAge, @Species, @Gender, @ClientID)"
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@PetName", petnametxt.Text.Trim())
                cmd.Parameters.AddWithValue("@PetBreed", petbreedtxt.Text.Trim())
                cmd.Parameters.AddWithValue("@PetAge", petagetxt.Text.Trim())
                cmd.Parameters.AddWithValue("@Species", speciescmb.Text)
                cmd.Parameters.AddWithValue("@Gender", petgendercmb.Text)
                cmd.Parameters.AddWithValue("@ClientID", clientID)
                cmd.ExecuteNonQuery()
            End Using
        End Using

        MessageBox.Show("Pet added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        LoadPetsByClient(clientID)
        ClearPetFields()
    End Sub


    Private Sub petdg_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles petdg.CellClick
        If e.RowIndex < 0 Then Exit Sub

        Dim row = petdg.Rows(e.RowIndex)
        petnametxt.Text = row.Cells("PetName").Value.ToString()
        petagetxt.Text = row.Cells("PetAge").Value.ToString()
        petbreedtxt.Text = row.Cells("PetBreed").Value.ToString()
        speciescmb.Text = row.Cells("Species").Value.ToString()
        petgendercmb.Text = row.Cells("Gender").Value.ToString()

        If row.Cells("ClientID").Value IsNot Nothing Then
            clientownercmb.SelectedValue = Convert.ToInt32(row.Cells("ClientID").Value)
        End If
    End Sub

    Private Sub clrtbtn_Click(sender As Object, e As EventArgs) Handles clrtbtn.Click
        ClearPetFields()
    End Sub
    ' ---------------- SAVE APPOINTMENT ----------------
    Private Sub InitializeSelectedServicesGrid()
        With selsevdg
            .Columns.Clear()
            .Columns.Add("ServiceID", "ID")
            .Columns.Add("ServiceName", "Service")
            .Columns.Add("Price", "Price (₱)")

            .Columns("ServiceID").Visible = False

            Dim removeBtn As New DataGridViewButtonColumn()
            removeBtn.Name = "Remove"
            removeBtn.HeaderText = ""
            removeBtn.Text = "Remove"
            removeBtn.UseColumnTextForButtonValue = True
            .Columns.Add(removeBtn)

            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End With
    End Sub
    Private Sub AddServiceToSelected(serviceID As Integer, serviceName As String, price As Decimal)
        For Each row As DataGridViewRow In selsevdg.Rows
            If row.Cells("ServiceID").Value IsNot Nothing AndAlso
           Convert.ToInt32(row.Cells("ServiceID").Value) = serviceID Then
                MessageBox.Show("Service already added.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        Next

        selsevdg.Rows.Add(serviceID, serviceName, price.ToString("N2"))
        selectedServices.Add(serviceID)
    End Sub
    Private Sub selsevdg_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles selsevdg.CellContentClick
        If e.ColumnIndex = selsevdg.Columns("Remove").Index AndAlso e.RowIndex >= 0 Then
            Dim serviceName As String = selsevdg.Rows(e.RowIndex).Cells("ServiceName").Value.ToString()
            Dim serviceID As Integer = Convert.ToInt32(selsevdg.Rows(e.RowIndex).Cells("ServiceID").Value)

            If MessageBox.Show($"Remove service '{serviceName}'?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                selectedServices.Remove(serviceID)
                selsevdg.Rows.RemoveAt(e.RowIndex)
            End If
        End If
    End Sub
    Private Sub petcmb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles petcmb.SelectedIndexChanged
        If petcmb.SelectedValue Is Nothing OrElse petcmb.SelectedIndex = -1 Then
            appdg.DataSource = Nothing
            Return
        End If

        Dim petID As Integer
        If Not Integer.TryParse(petcmb.SelectedValue.ToString(), petID) Then
            appdg.DataSource = Nothing
            Return
        End If

        Using conn As New SqlConnection(connectionString)
            Dim dt As New DataTable()
            Dim query As String = "
            SELECT a.AppointmentID, a.PetID, a.AppointmentDate, a.Status
            FROM AppointmentTable a
            WHERE a.PetID = @PetID
            ORDER BY a.AppointmentDate DESC"
            Using da As New SqlDataAdapter(query, conn)
                da.SelectCommand.Parameters.AddWithValue("@PetID", petID)
                da.Fill(dt)
                appdg.DataSource = dt
            End Using
        End Using
        appdg.ReadOnly = True
    End Sub
    Private Sub addservicebtn_Click(sender As Object, e As EventArgs) Handles addservicebtn.Click
        If servicecmb.SelectedValue Is Nothing OrElse servicecmb.SelectedValue Is DBNull.Value Then
            MessageBox.Show("Please select a valid service.")
            Return
        End If

        Dim serviceID As Integer
        If Integer.TryParse(servicecmb.SelectedValue.ToString(), serviceID) Then
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim query As String = "SELECT ServiceName, Price FROM ServiceTable WHERE ServiceID = @ServiceID"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@ServiceID", serviceID)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim serviceName As String = reader("ServiceName").ToString()
                            Dim price As Decimal = Convert.ToDecimal(reader("Price"))
                            AddServiceToSelected(serviceID, serviceName, price)
                        End If
                    End Using
                End Using
            End Using
        Else
            MessageBox.Show("Invalid service selected.")
        End If
    End Sub
    Private Sub saveappbtn_Click(sender As Object, e As EventArgs) Handles saveappbtn.Click
        If selectedServices.Count = 0 Then
            MessageBox.Show("Please add at least one service.")
            Return
        End If

        Dim appointmentID As Integer

        Using conn As New SqlConnection(connectionString)
            conn.Open()

            Dim query As String = "INSERT INTO AppointmentTable (PetID, AppointmentDate, Status) 
                               OUTPUT INSERTED.AppointmentID 
                               VALUES (@PetID, @AppointmentDate, @Status)"
            Using cmd As New SqlCommand(query, conn)
                Dim petID As Integer
                If Not Integer.TryParse(petcmb.SelectedValue?.ToString(), petID) Then
                    MessageBox.Show("Please select a valid pet.")
                    Return
                End If

                cmd.Parameters.AddWithValue("@PetID", petID)
                cmd.Parameters.AddWithValue("@AppointmentDate", dateandtimedtp.Value)
                cmd.Parameters.AddWithValue("@Status", statuscmb.Text)
                appointmentID = Convert.ToInt32(cmd.ExecuteScalar())
            End Using

            For Each serviceID As Integer In selectedServices
                Dim queryService As String = "INSERT INTO AppointmentServices (AppointmentID, ServiceID) 
                                          VALUES (@AppointmentID, @ServiceID)"
                Using cmd As New SqlCommand(queryService, conn)
                    cmd.Parameters.AddWithValue("@AppointmentID", appointmentID)
                    cmd.Parameters.AddWithValue("@ServiceID", serviceID)
                    cmd.ExecuteNonQuery()
                End Using
            Next

            Dim total As Decimal = 0
            Dim totalQuery As String = "SELECT SUM(s.Price) 
                                    FROM AppointmentServices aps 
                                    JOIN ServiceTable s ON aps.ServiceID = s.ServiceID 
                                    WHERE aps.AppointmentID = @AppointmentID"
            Using cmd As New SqlCommand(totalQuery, conn)
                cmd.Parameters.AddWithValue("@AppointmentID", appointmentID)
                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing AndAlso result IsNot DBNull.Value Then
                    total = Convert.ToDecimal(result)
                End If
            End Using

            Dim insertBill As String = "INSERT INTO BillingTable (AppointmentID, TotalAmount, PaymentMethod, BillDate)
                                    VALUES (@AppointmentID, @TotalAmount, @PaymentMethod, @BillDate)"
            Using cmd As New SqlCommand(insertBill, conn)
                cmd.Parameters.AddWithValue("@AppointmentID", appointmentID)
                cmd.Parameters.AddWithValue("@TotalAmount", total)
                cmd.Parameters.AddWithValue("@PaymentMethod", "Unpaid")
                cmd.Parameters.AddWithValue("@BillDate", DateTime.Now)
                cmd.ExecuteNonQuery()
            End Using
        End Using

        LoadAppointments()
        LoadAppointmentCombo()
        selectedServices.Clear()
        selsevdg.Rows.Clear()

        appcmb.SelectedValue = appointmentID
        MessageBox.Show("Appointment saved successfully!")
    End Sub

    Private Function GetGroomingDiscount(petId As Integer) As Decimal
        Dim discount As Decimal = 0D
        Dim oneYearAgo As DateTime = DateTime.Now.AddYears(-1)

        Dim query As String = "
        SELECT COUNT(*) 
        FROM GroomingHistory 
        WHERE PetID = @PetID 
          AND GroomDate >= @OneYearAgo
    "

        Using conn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@PetID", petId)
                cmd.Parameters.AddWithValue("@OneYearAgo", oneYearAgo)
                conn.Open()
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                If count >= 10 Then
                    discount = 1D
                ElseIf count >= 5 Then
                    discount = 0.2D
                End If
            End Using
        End Using

        Return discount
    End Function


    ' ---------------- CALCULATE TOTAL WHEN APPOINTMENT SELECTED ----------------
    Private Sub appcmb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles appcmb.SelectedIndexChanged
        If appcmb.SelectedValue Is Nothing Then Exit Sub

        Dim appointmentID As Integer
        If Not Integer.TryParse(appcmb.SelectedValue.ToString(), appointmentID) Then Exit Sub

        Dim total As Decimal = 0

        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Dim query As String = "SELECT SUM(s.Price) FROM AppointmentServices aps 
                                   JOIN ServiceTable s ON aps.ServiceID = s.ServiceID 
                                   WHERE aps.AppointmentID = @AppointmentID"
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@AppointmentID", appointmentID)
                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing AndAlso result IsNot DBNull.Value Then
                    total = Convert.ToDecimal(result)
                End If
            End Using
        End Using

        totaltxt.Text = total.ToString("F2")
    End Sub

    ' ---------------- SAVE BILL ----------------
    Private Sub savebillbtn_Click(sender As Object, e As EventArgs) Handles savebillbtn.Click
        Dim appointmentID As Integer
        If Not Integer.TryParse(appcmb.SelectedValue?.ToString(), appointmentID) Then
            MessageBox.Show("Please select a valid appointment.")
            Return
        End If

        Dim totalAmount As Decimal
        Dim cashGiven As Decimal

        If Not Decimal.TryParse(totaltxt.Text, totalAmount) Then
            MessageBox.Show("Invalid total amount.")
            Return
        End If

        If Not Decimal.TryParse(cashgiventxt.Text, cashGiven) Then
            MessageBox.Show("Please enter a valid cash amount.")
            Return
        End If

        If cashGiven < totalAmount Then
            MessageBox.Show("Insufficient cash. Please enter enough amount to cover the total.")
            Return
        End If

        Dim change As Decimal = cashGiven - totalAmount

        Using conn As New SqlConnection(connectionString)
            conn.Open()

            Dim query As String = "UPDATE BillingTable 
                               SET TotalAmount = @TotalAmount, PaymentMethod = @PaymentMethod, BillDate = @BillDate 
                               WHERE AppointmentID = @AppointmentID"

            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@AppointmentID", appointmentID)
                cmd.Parameters.AddWithValue("@TotalAmount", totalAmount)
                cmd.Parameters.AddWithValue("@PaymentMethod", paymentcmb.Text)
                cmd.Parameters.AddWithValue("@BillDate", billdt.Value)
                cmd.ExecuteNonQuery()
            End Using

            Dim statusQuery As String = "UPDATE AppointmentTable 
                                     SET Status = 'Completed' 
                                     WHERE AppointmentID = @AppointmentID"
            Using cmd As New SqlCommand(statusQuery, conn)
                cmd.Parameters.AddWithValue("@AppointmentID", appointmentID)
                cmd.ExecuteNonQuery()
            End Using
        End Using

        LoadBilling()
        LoadAppointments()

        Dim subtotal As Decimal = 0
        Dim dt As New DataTable()
        dt.Columns.Add("ServiceName")
        dt.Columns.Add("Price", GetType(Decimal))

        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Dim query As String = "
        SELECT s.ServiceName, s.Price 
        FROM AppointmentServices aps 
        JOIN ServiceTable s ON aps.ServiceID = s.ServiceID 
        WHERE aps.AppointmentID = @AppointmentID"
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@AppointmentID", appointmentID)
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim serviceName As String = reader("ServiceName").ToString()
                        Dim price As Decimal = Convert.ToDecimal(reader("Price"))
                        dt.Rows.Add(serviceName, price)
                        subtotal += price
                    End While
                End Using
            End Using
        End Using

        Dim vat As Decimal = subtotal * 0.12D
        totalAmount = subtotal + vat

        MessageBox.Show("Payment successful!" & vbCrLf & "Change: ₱" & change.ToString("F2"),
                "Payment Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Dim receiptForm As New receiptform() With {
    .ReceiptNo = "FT-" & appointmentID.ToString("00000"),
    .Cashier = Environment.UserName,
    .PaymentMethod = paymentcmb.Text,
    .CustomerName = firstnametxt.Text & " " & lastnametxt.Text,
    .PetNames = petcmb.Text,
    .ServiceType = "Pet Grooming",
    .Services = dt,
    .VAT = vat,
    .TotalAmount = totalAmount,
    .Change = change,
    .BillDate = DateTime.Now
}
        receiptForm.ShowDialog()

        ClearBillingFields()
    End Sub

    Private Sub SaveGroomingService(petId As Integer, basePrice As Decimal)
        Dim discountRate As Decimal = GetGroomingDiscount(petId)
        Dim finalPrice As Decimal = basePrice * (1 - discountRate)

        Dim insertQuery As String = "
        INSERT INTO GroomingHistory (PetID, GroomDate, Price)
        VALUES (@PetID, @GroomDate, @Price)
    "

        Using conn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(insertQuery, conn)
                cmd.Parameters.AddWithValue("@PetID", petId)
                cmd.Parameters.AddWithValue("@GroomDate", DateTime.Now)
                cmd.Parameters.AddWithValue("@Price", finalPrice)
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using

        MessageBox.Show($"Grooming saved successfully! Price after discount: ₱{finalPrice:F2}",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub


    ' ---------------- UPDATE STATUS ----------------
    Private Sub updstatusbtn_Click(sender As Object, e As EventArgs) Handles updstatusbtn.Click
        If appdg.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an appointment to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim appointmentID = Convert.ToInt32(appdg.SelectedRows(0).Cells("AppointmentID").Value)
        Dim newStatus = newstatuscmb.Text

        Using con As New SqlConnection(connectionString)
            con.Open
            Dim query = "UPDATE AppointmentTable SET Status = @Status WHERE AppointmentID = @AppointmentID"
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@Status", newStatus)
                cmd.Parameters.AddWithValue("@AppointmentID", appointmentID)
                cmd.ExecuteNonQuery
            End Using
        End Using

        MessageBox.Show("Appointment status updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        If clientownercmb.SelectedValue IsNot Nothing Then
            LoadAppointments(Convert.ToInt32(clientownercmb.SelectedValue))
        Else
            LoadAppointments()
        End If
    End Sub

    Private Sub upddtbtn_Click(sender As Object, e As EventArgs) Handles upddtbtn.Click
        If appdg.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an appointment to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim appointmentID As Integer = Convert.ToInt32(appdg.SelectedRows(0).Cells("AppointmentID").Value)
        Dim newDateTime As DateTime = upddt.Value

        If MessageBox.Show("Are you sure you want to reschedule this appointment to:" & vbCrLf &
                       newDateTime.ToString("MMMM dd, yyyy hh:mm tt") & "?", "Confirm Update",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Return
        End If

        Try
            Using con As New SqlConnection(connectionString)
                con.Open()
                Dim query As String = "UPDATE AppointmentTable SET AppointmentDate = @NewDate WHERE AppointmentID = @AppointmentID"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@NewDate", newDateTime)
                    cmd.Parameters.AddWithValue("@AppointmentID", appointmentID)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Appointment rescheduled successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            If clientownercmb.SelectedValue IsNot Nothing Then
                LoadAppointments(Convert.ToInt32(clientownercmb.SelectedValue))
            Else
                LoadAppointments()
            End If

        Catch ex As Exception
            MessageBox.Show("Error updating appointment date/time: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ---------------- CLEAR FIELDS ----------------

    Public Sub ClearClient()
        lastnametxt.Clear()
        firstnametxt.Clear()
        midnametxt.Clear()
        addresstxt.Clear()
        numbertxt.Clear()
        clientgendercmb.SelectedIndex = -1
        pettotalcounttxt.Clear()
    End Sub

    Private Sub ClearPetFields()
        petnametxt.Clear()
        petbreedtxt.Clear()
        petagetxt.Clear()
        speciescmb.SelectedIndex = -1
        petgendercmb.SelectedIndex = -1
        clientownercmb.SelectedIndex = -1
    End Sub

    Private Sub ClearBillingFields()
        appcmb.SelectedIndex = -1
        paymentcmb.SelectedIndex = -1
        totaltxt.Clear()
        cashgiventxt.Clear()
    End Sub
    Private Sub clrbtn_Click(sender As Object, e As EventArgs) Handles clrbtn.Click
        ClearClient()
    End Sub

End Class
