Public Class staffform
    Private Sub Manserv_Click(sender As Object, e As EventArgs) Handles Manserv.Click
        switchPanel(servicesformstaff)
    End Sub

    Sub switchPanel(panel As Form)
        Panel6.Controls.Clear()
        panel.TopLevel = False
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
End Class