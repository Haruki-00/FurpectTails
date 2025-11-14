Public Class staffform
    Public Shared PanelContainer As Panel
    Private Sub staffform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        switchPanel(calendarform)
    End Sub
    Sub switchPanel(panel As Form)
        Panel6.Controls.Clear()
        panel.TopLevel = False
        panel.FormBorderStyle = FormBorderStyle.None
        panel.Dock = DockStyle.Fill
        Panel6.Controls.Add(panel)
        panel.Show()
    End Sub

    Private Sub logout_Click(sender As Object, e As EventArgs) Handles logout.Click
        Dim result As DialogResult =
            MessageBox.Show("Are you sure you want to log out?",
                            "Confirm Log Out",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Me.Close()
            loginform.Show()
        End If
    End Sub

    Private Sub pethot_Click(sender As Object, e As EventArgs) Handles pethot.Click
        switchPanel(New pethotel())
    End Sub

    Private Sub Prod_Click(sender As Object, e As EventArgs) Handles Prod.Click
        switchPanel(productform)
    End Sub

    Private Sub report_Click(sender As Object, e As EventArgs) Handles report.Click
        switchPanel(dailyreportform)
    End Sub

    Private Sub clientprof_Click(sender As Object, e As EventArgs) Handles clientprof.Click
        switchPanel(clientformstaff)
    End Sub

    Private Sub clndr_Click(sender As Object, e As EventArgs) Handles clndr.Click
        switchPanel(calendarform)
    End Sub
End Class
