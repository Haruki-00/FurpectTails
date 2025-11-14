Imports Microsoft.Data.SqlClient

Public Class pethotel
    Private connectionString As String = "Server=MARIAKRISTINA\SQLEXPRESS;Database=FurpectTailsDB;Integrated Security=True;TrustServerCertificate=True"
    Private refreshTimer As New Timer()

    Private Sub HotelForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUnits()
        refreshTimer.Interval = 60000
        AddHandler refreshTimer.Tick, AddressOf RefreshColors
        refreshTimer.Start()
    End Sub

    Private Sub LoadUnits()
        dogflp.Controls.Clear()
        catflp.Controls.Clear()

        Using con As New SqlConnection(connectionString)
            con.Open()

            ' --- Retrieve booking information ---
            Dim bookingData As New Dictionary(Of String, (Status As String, ServiceType As String, StartTime As DateTime?, EndTime As DateTime?))()

            Dim bookQuery As String =
                "SELECT UnitID, UnitNumber, Status, ServiceType, StartTime, EndTime
                 FROM BookingTable
                 WHERE IsActive = 1"

            Using cmd As New SqlCommand(bookQuery, con)
                Using rdr As SqlDataReader = cmd.ExecuteReader()
                    While rdr.Read()
                        Dim key As String = $"{rdr("UnitID")}_{rdr("UnitNumber")}"
                        Dim status As String = rdr("Status").ToString()
                        Dim serviceType As String = rdr("ServiceType").ToString()
                        Dim startTime As DateTime? = If(IsDBNull(rdr("StartTime")), Nothing, CDate(rdr("StartTime")))
                        Dim endTime As DateTime? = If(IsDBNull(rdr("EndTime")), Nothing, CDate(rdr("EndTime")))
                        bookingData(key) = (status, serviceType, startTime, endTime)
                    End While
                End Using
            End Using

            ' --- Retrieve all units (Dog Room / Cat Villa) ---
            Dim unitQuery As String = "SELECT UnitID, UnitName, SizeType, Price, UnitsAvailable FROM UnitTable"
            Using cmd2 As New SqlCommand(unitQuery, con)
                Using rdr2 As SqlDataReader = cmd2.ExecuteReader()
                    While rdr2.Read()
                        Dim unitID As Integer = CInt(rdr2("UnitID"))
                        Dim unitName As String = rdr2("UnitName").ToString().Trim()
                        Dim sizeType As String = rdr2("SizeType").ToString()
                        Dim price As Decimal = CDec(rdr2("Price"))
                        Dim unitsAvailable As Integer = CInt(rdr2("UnitsAvailable"))

                        For i As Integer = 1 To unitsAvailable
                            Dim key As String = $"{unitID}_{i}"

                            ' --- Default values ---
                            Dim statusColor As Color = Color.LightGreen
                            Dim serviceDisplay As String = "N/A"
                            Dim startText As String = "-"
                            Dim endText As String = "-"
                            Dim deadlineMsg As String = "Available"

                            ' --- Check if unit has booking ---
                            If bookingData.ContainsKey(key) Then
                                Dim book = bookingData(key)
                                Dim nowTime As DateTime = DateTime.Now

                                ' Update time and service info
                                If book.StartTime.HasValue Then startText = book.StartTime.Value.ToString("MM/dd hh:mm tt")
                                If book.EndTime.HasValue Then endText = book.EndTime.Value.ToString("MM/dd hh:mm tt")
                                serviceDisplay = book.ServiceType

                                Select Case book.Status
                                    Case "Completed"
                                        statusColor = Color.LightGreen
                                        deadlineMsg = "Available"
                                        ' Reset to "-" display like available
                                        startText = "-"
                                        endText = "-"
                                        serviceDisplay = "N/A"

                                    Case "Booked"
                                        If book.EndTime.HasValue AndAlso nowTime > book.EndTime.Value Then
                                            statusColor = Color.OrangeRed
                                            deadlineMsg = "⚠️ Overdue!"
                                        Else
                                            statusColor = Color.LightCoral
                                            deadlineMsg = "🐾 Booked"
                                        End If

                                    Case "Reserved"
                                        statusColor = Color.Khaki
                                        deadlineMsg = "⏳ Reserved"
                                End Select
                            End If

                            ' --- Create panel for each unit ---
                            Dim panel As New Panel With {
                                .Width = 180,
                                .Height = 160,
                                .BorderStyle = BorderStyle.FixedSingle,
                                .Tag = key,
                                .Padding = New Padding(4),
                                .BackColor = statusColor
                            }

                            ' --- Create labels ---
                            Dim lblSched As New Label With {
                                .Text = $"Start: {startText}" & vbCrLf & $"End: {endText}",
                                .Dock = DockStyle.Top,
                                .TextAlign = ContentAlignment.MiddleLeft,
                                .Font = New Font("Segoe UI", 8.5, FontStyle.Regular),
                                .ForeColor = Color.Black,
                                .Height = 40
                            }

                            Dim lblService As New Label With {
                                .Text = $"Service: {serviceDisplay}",
                                .Dock = DockStyle.Top,
                                .TextAlign = ContentAlignment.MiddleLeft,
                                .Font = New Font("Segoe UI", 9, FontStyle.Regular),
                                .Height = 20
                            }

                            Dim lblUnitNum As New Label With {
                                .Text = $"Unit #{i}",
                                .Dock = DockStyle.Top,
                                .TextAlign = ContentAlignment.MiddleCenter,
                                .Font = New Font("Segoe UI", 9, FontStyle.Regular),
                                .Height = 20
                            }

                            ' --- Determine what to show in header ---
                            Dim headerText As String = $"{unitName} ({sizeType})"

                            If bookingData.ContainsKey(key) Then
                                Dim book = bookingData(key)
                                If Not String.IsNullOrEmpty(book.ServiceType) Then
                                    If book.ServiceType.ToLower().Contains("overnight") Then
                                        ' Show fixed price for overnight stay
                                        headerText &= $" - ₱{price:N2}"
                                    ElseIf book.ServiceType.ToLower().Contains("day care") Then
                                        ' Show hours consumed for day care
                                        If book.StartTime.HasValue AndAlso book.EndTime.HasValue Then
                                            Dim totalHours As Double = (book.EndTime.Value - book.StartTime.Value).TotalHours
                                            Dim consumedHours As Integer = Math.Ceiling(totalHours)
                                            headerText &= $" - {consumedHours} hr(s) used"
                                        Else
                                            headerText &= " - (In Progress)"
                                        End If
                                    End If
                                End If
                            Else
                                ' Default (no active booking)
                                headerText &= $" - ₱{price:N2}"
                            End If

                            ' --- Create header label ---
                            Dim lblHeader As New Label With {
                                .Text = headerText,
                                .Dock = DockStyle.Top,
                                .TextAlign = ContentAlignment.MiddleCenter,
                                .Font = New Font("Segoe UI", 9, FontStyle.Bold),
                                .Height = 22
}

                            Dim lblDeadline As New Label With {
                                .Text = deadlineMsg,
                                .Dock = DockStyle.Bottom,
                                .ForeColor = Color.Red,
                                .Font = New Font("Segoe UI", 8.5, FontStyle.Bold),
                                .Height = 20,
                                .TextAlign = ContentAlignment.MiddleCenter
                            }

                            panel.Controls.Add(lblDeadline)
                            panel.Controls.Add(lblHeader)
                            panel.Controls.Add(lblUnitNum)
                            panel.Controls.Add(lblService)
                            panel.Controls.Add(lblSched)

                            ' --- Add click event to open booking form ---
                            AddHandler panel.Click, AddressOf UnitPanel_Click
                            For Each ctrl As Control In panel.Controls
                                AddHandler ctrl.Click, AddressOf UnitPanel_Click
                            Next

                            ' --- Add to correct FlowLayoutPanel ---
                            If unitName.Equals("Dog Room", StringComparison.OrdinalIgnoreCase) Then
                                dogflp.Controls.Add(panel)
                            ElseIf unitName.Equals("Cat Villa", StringComparison.OrdinalIgnoreCase) Then
                                catflp.Controls.Add(panel)
                            End If
                        Next
                    End While
                End Using
            End Using
        End Using
    End Sub

    Private Sub RefreshColors(sender As Object, e As EventArgs)
        LoadUnits()
    End Sub

    Private Sub UnitPanel_Click(sender As Object, e As EventArgs)
        Dim clickedPanel As Panel

        If TypeOf sender Is Label Then
            clickedPanel = CType(DirectCast(sender, Label).Parent, Panel)
        ElseIf TypeOf sender Is Panel Then
            clickedPanel = CType(sender, Panel)
        Else
            Return
        End If

        Dim tagParts = clickedPanel.Tag.ToString().Split("_"c)
        Dim UnitID As Integer = CInt(tagParts(0))
        Dim UnitNumber As Integer = CInt(tagParts(1))

        Dim bookingForm As New BookingForm(UnitID, UnitNumber)
        If bookingForm.ShowDialog() = DialogResult.OK Then
            LoadUnits()
        End If
    End Sub

End Class
