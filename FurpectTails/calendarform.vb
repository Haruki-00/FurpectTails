Imports Microsoft.Data.SqlClient

Public Class calendarform

    ' === Fields and Variables ===
    Private dayPanels(41) As Panel
    Private dayLabels(41) As Label

    Private currentYear As Integer = DateTime.Now.Year
    Private currentMonth As Integer = DateTime.Now.Month
    Private lastSelectedDate As Date = Date.MinValue

    Private ReadOnly connectionString As String =
        "Server=MARIAKRISTINA\SQLEXPRESS;Database=FurpectTailsDB;Integrated Security=True;TrustServerCertificate=True"


    ' === Form Load ===
    Private Sub CalendarForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        CreateCalendarGrid()
        DisplayCalendar(currentYear, currentMonth)
    End Sub


    ' === Event Handlers ===
    Private Sub DayPanel_Click(sender As Object, e As EventArgs)
        Dim parentPanel As Panel = If(TypeOf sender Is Panel,
                                      DirectCast(sender, Panel),
                                      DirectCast(DirectCast(sender, Control).Parent, Panel))

        Dim dateLabel As Label = parentPanel.Controls.OfType(Of Label)().
                                 FirstOrDefault(Function(x) x.Height = 20)
        If dateLabel Is Nothing Then Exit Sub

        Dim dayNumber As Integer
        If Not Integer.TryParse(dateLabel.Text, dayNumber) Then Exit Sub

        Dim selectedDate As New DateTime(currentYear, currentMonth, dayNumber)
        LoadReservationIntoPanel(selectedDate)
    End Sub


    Private Sub nxtbttn_Click(sender As Object, e As EventArgs) Handles nxtbttn.Click
        currentMonth += 1
        If currentMonth > 12 Then
            currentMonth = 1
            currentYear += 1
        End If
        DisplayCalendar(currentYear, currentMonth)
    End Sub


    Private Sub prvbttn_Click(sender As Object, e As EventArgs) Handles prvbttn.Click
        currentMonth -= 1
        If currentMonth < 1 Then
            currentMonth = 12
            currentYear -= 1
        End If
        DisplayCalendar(currentYear, currentMonth)
    End Sub


    Private Sub refbtn_Click(sender As Object, e As EventArgs)
        lastSelectedDate = Date.MinValue
        taskpnl.Controls.Clear()
        DisplayCalendar(currentYear, currentMonth)
    End Sub


    ' === Calendar Grid Creation ===
    Private Sub CreateCalendarGrid()
        pnlcalendar.Controls.Clear()

        Dim panelWidth As Integer = pnlcalendar.Width \ 7
        Dim panelHeight As Integer = pnlcalendar.Height \ 6
        Dim index As Integer = 0

        For row As Integer = 0 To 5
            For col As Integer = 0 To 6
                Dim dayPanel As New Panel With {
                    .Width = panelWidth,
                    .Height = panelHeight,
                    .BackColor = Color.White,
                    .BorderStyle = BorderStyle.FixedSingle,
                    .Left = col * panelWidth,
                    .Top = row * panelHeight
                }

                Dim lbl As New Label With {
                    .Dock = DockStyle.Top,
                    .Height = 20,
                    .TextAlign = ContentAlignment.TopRight,
                    .Font = New Font("Segoe UI", 9, FontStyle.Bold)
                }

                AddHandler dayPanel.Click, AddressOf DayPanel_Click
                AddHandler lbl.Click, AddressOf DayPanel_Click

                dayPanel.Controls.Add(lbl)
                pnlcalendar.Controls.Add(dayPanel)

                dayPanels(index) = dayPanel
                dayLabels(index) = lbl
                index += 1
            Next
        Next
    End Sub


    ' === Display Calendar and Fill Days ===
    Private Sub DisplayCalendar(year As Integer, month As Integer)
        monthlbl.Text = New DateTime(year, month, 1).ToString("MMMM yyyy")

        ' Reset all cells
        For i As Integer = 0 To 41
            dayLabels(i).Text = ""
            dayPanels(i).Controls.Clear()

            Dim lbl As New Label With {
                .Dock = DockStyle.Top,
                .Height = 20,
                .TextAlign = ContentAlignment.TopRight,
                .Font = New Font("Segoe UI", 9, FontStyle.Bold)
            }

            AddHandler lbl.Click, AddressOf DayPanel_Click
            AddHandler dayPanels(i).Click, AddressOf DayPanel_Click

            dayPanels(i).Controls.Add(lbl)
            dayLabels(i) = lbl
            dayPanels(i).BorderStyle = BorderStyle.FixedSingle
            dayPanels(i).BackColor = Color.White
        Next

        ' Fill days of month
        Dim firstDay As New DateTime(year, month, 1)
        Dim daysInMonth As Integer = DateTime.DaysInMonth(year, month)
        Dim startDayOfWeek As Integer = CInt(firstDay.DayOfWeek)

        Dim dayCounter As Integer = 1
        For i As Integer = startDayOfWeek To startDayOfWeek + daysInMonth - 1
            dayLabels(i).Text = dayCounter.ToString()

            LoadReservationsIntoCell(dayPanels(i), year, month, dayCounter)

            ' Highlight today = Blue
            If year = DateTime.Now.Year AndAlso month = DateTime.Now.Month AndAlso dayCounter = DateTime.Now.Day Then
                dayPanels(i).BorderStyle = BorderStyle.Fixed3D
                dayPanels(i).BackColor = Color.LightBlue
            End If

            dayCounter += 1
        Next
    End Sub


    ' === Reservation Panel (Right Side) ===
    Private Sub LoadReservationIntoPanel(dateValue As DateTime)
        taskpnl.Controls.Clear()
        taskpnl.AutoScroll = True

        Dim header As New Label With {
            .Text = $"Reservations for{Environment.NewLine}{dateValue:MMMM dd, yyyy}",
            .Font = New Font("Segoe UI", 13, FontStyle.Bold),
            .AutoSize = False,
            .Dock = DockStyle.Top,
            .Height = 60,
            .Padding = New Padding(10, 5, 10, 5),
            .TextAlign = ContentAlignment.MiddleLeft
        }
        taskpnl.Controls.Add(header)

        Dim reservations As List(Of String) = GetReservations(dateValue)

        If reservations.Count = 0 Then
            Dim noRes As New Label With {
                .Text = "No reservations found",
                .Font = New Font("Segoe UI", 11, FontStyle.Italic),
                .AutoSize = True,
                .Padding = New Padding(10)
            }
            taskpnl.Controls.Add(noRes)
            Exit Sub
        End If

        Dim yOffset As Integer = 65
        For Each item In reservations
            Dim card As New Panel With {
                .Width = taskpnl.Width - 25,
                .Height = 85,
                .Left = 10,
                .Top = yOffset,
                .BackColor = Color.White,
                .BorderStyle = BorderStyle.FixedSingle
            }

            Dim lbl As New Label With {
                .Text = item,
                .Font = New Font("Segoe UI", 10),
                .AutoSize = False,
                .Width = card.Width - 20,
                .Height = card.Height - 10,
                .Left = 10,
                .Top = 5
            }

            AddHandler card.Click, Sub() ShowSelectedReservation(item)
            AddHandler lbl.Click, Sub() ShowSelectedReservation(item)

            card.Controls.Add(lbl)
            taskpnl.Controls.Add(card)
            yOffset += card.Height + 10
        Next
    End Sub


    ' === Fill individual calendar cells with reservation dots/text ===
    Private Sub LoadReservationsIntoCell(cell As Panel, y As Integer, m As Integer, d As Integer)
        Dim dayDate As New DateTime(y, m, d)
        Dim reservationText As String = ""

        Using con As New SqlConnection(connectionString)
            con.Open()

            Dim query As String =
                "SELECT ServiceType, StartTime, EndTime, Status
             FROM BookingTable
             WHERE CAST(StartTime AS DATE) = @d
               AND Status = 'Reserved'
               AND IsActive = 1"

            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@d", dayDate.Date)

                Using rdr As SqlDataReader = cmd.ExecuteReader()
                    While rdr.Read()
                        If Not IsDBNull(rdr("EndTime")) AndAlso CDate(rdr("EndTime")) < DateTime.Now Then Continue While

                        Dim startT As String = Format(rdr("StartTime"), "hh:mm tt")
                        Dim endT As String = If(IsDBNull(rdr("EndTime")), "-", Format(rdr("EndTime"), "hh:mm tt"))
                        reservationText &= $"{startT}-{endT}" & vbCrLf
                    End While
                End Using
            End Using
        End Using

        If reservationText <> "" Then
            Dim lblInfo As New Label With {
                .Text = reservationText.Trim(),
                .Dock = DockStyle.Fill,
                .Font = New Font("Segoe UI", 8),
                .TextAlign = ContentAlignment.TopLeft
            }

            AddHandler lblInfo.Click, AddressOf DayPanel_Click
            cell.Controls.Add(lblInfo)
            lblInfo.BringToFront()
            cell.BorderStyle = BorderStyle.Fixed3D
        End If
    End Sub


    ' === Database Helpers ===
    Private Function GetReservations(dateValue As DateTime) As List(Of String)
        Dim list As New List(Of String)

        Using con As New SqlConnection(connectionString)
            con.Open()

            Dim query As String =
                "SELECT UnitID, UnitNumber, ServiceType, StartTime, EndTime, Status
             FROM BookingTable
             WHERE CAST(StartTime AS DATE) = @d
               AND IsActive = 1"

            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@d", dateValue.Date)

                Using rdr As SqlDataReader = cmd.ExecuteReader()
                    While rdr.Read()
                        Dim sTime As String = Format(rdr("StartTime"), "hh:mm tt")
                        Dim eTime As String = If(IsDBNull(rdr("EndTime")), "-", Format(rdr("EndTime"), "hh:mm tt"))

                        list.Add($"Unit {rdr("UnitID")}-{rdr("UnitNumber")} | {rdr("ServiceType")} ({rdr("Status")})" &
                                 vbCrLf & $"{sTime} - {eTime}")
                    End While
                End Using
            End Using
        End Using

        Return list
    End Function


    ' === Pop-up reservation details ===
    Private Sub ShowSelectedReservation(info As String)
        MessageBox.Show(info, "Reservation Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub


    ' === MonthCalendar Button ===
    'Private Sub clndrbtn_Click(sender As Object, e As EventArgs)
    '    MonthCalendar1.Visible = True
    '    MonthCalendar1.BringToFront
    'End Sub


    '' === MonthCalendar Date Selected ===
    'Private Sub MonthCalendar1_DateSelected(sender As Object, e As DateRangeEventArgs)
    '    Dim selectedDate = e.Start

    '    currentYear = selectedDate.Year
    '    currentMonth = selectedDate.Month

    '    DisplayCalendar(currentYear, currentMonth)

    '    MonthCalendar1.Visible = False
    'End Sub


    '' === Hide MonthCalendar when pointer leaves ===
    'Private Sub MonthCalendar1_MouseLeave(sender As Object, e As EventArgs)
    '    MonthCalendar1.Visible = False
    'End Sub

End Class
