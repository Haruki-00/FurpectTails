Public Class scheduleform
    Dim dayPanels(41) As Panel
    Dim dayLabels(41) As Label
    Dim currentYear As Integer = DateTime.Now.Year
    Dim currentMonth As Integer = DateTime.Now.Month

    Private Sub CalendarForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreateCalendarGrid()
        DisplayCalendar(currentYear, currentMonth)
    End Sub

    Private Sub DayPanel_Click(sender As Object, e As EventArgs)
        Dim clickedPanel As Control = DirectCast(sender, Control)
        Dim parentPanel As Panel = If(TypeOf clickedPanel Is Panel, DirectCast(clickedPanel, Panel), clickedPanel.Parent)

        Dim lbl As Label = parentPanel.Controls.OfType(Of Label).FirstOrDefault()
        If lbl IsNot Nothing AndAlso lbl.Text <> "" Then
            MessageBox.Show("You clicked day " & lbl.Text)
        End If
    End Sub

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

    Private Sub DisplayCalendar(year As Integer, month As Integer)
        monthlbl.Text = New DateTime(year, month, 1).ToString("MMMM yyyy")
        For i As Integer = 0 To 41
            dayLabels(i).Text = ""
            dayPanels(i).BackColor = Color.White
        Next

        Dim firstDay As New DateTime(year, month, 1)
        Dim daysInMonth As Integer = DateTime.DaysInMonth(year, month)
        Dim startDayOfWeek As Integer = CInt(firstDay.DayOfWeek)

        Dim dayCounter As Integer = 1
        For i As Integer = startDayOfWeek To startDayOfWeek + daysInMonth - 1
            dayLabels(i).Text = dayCounter.ToString()
            dayPanels(i).BackColor = Color.LightYellow
            dayCounter += 1
        Next
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

End Class