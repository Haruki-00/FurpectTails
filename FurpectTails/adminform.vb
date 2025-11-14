Public Class adminform
    Private Sub adminform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        switchPanel(admincalendarform)
    End Sub
    Private Sub logout_Click(sender As Object, e As EventArgs) Handles logout.Click
        Dim result =
        MessageBox.Show("Are you sure you want to log out?",
            "Confirm Log Out",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Close()
            loginform.Show()
        End If
    End Sub

    Sub switchPanel(panel As Form)
        Panel6.Controls.Clear()
        panel.TopLevel = False
        Panel6.Controls.Add(panel)
        panel.Show()
    End Sub

    Private Sub Prod_Click(sender As Object, e As EventArgs) Handles Prod.Click
        switchPanel(adminproductform)
    End Sub

    Private Sub clndr_Click(sender As Object, e As EventArgs) Handles clndr.Click
        switchPanel(admincalendarform)
    End Sub

    Private Sub Manserv_Click(sender As Object, e As EventArgs) Handles Manserv.Click
        switchPanel(manageservicesadminform)
    End Sub

    Private Sub clientprof_Click(sender As Object, e As EventArgs) Handles clientprof.Click
        switchPanel(adminclientprofform)
    End Sub

    Private Sub manroom_Click(sender As Object, e As EventArgs) Handles manroom.Click
        switchPanel(adminmanageroomsform)
    End Sub

    Private Sub petprof_Click(sender As Object, e As EventArgs) Handles petprof.Click
        switchPanel(adminpetprofile)
    End Sub

End Class