Imports Microsoft.Data.SqlClient

Public Class resetform
    Dim connstring As String = "Server=MARIAKRISTINA\SQLEXPRESs;Database=FurpectTailsDB;Integrated Security=true;TrustServerCertificate=True"
    Dim con As New SqlConnection(connstring)

    Private Sub backbttn_Click(sender As Object, e As EventArgs) Handles backbttn.Click
        Me.Close()
        loginform.Show()
    End Sub

    Private Sub rstbttn_load(sender As Object, e As EventArgs) Handles MyBase.Load
        trgttxt.Enabled = False
        newpsstxt.Enabled = False
        rstbttn.Enabled = False
    End Sub

    Private Sub adminverifybttn_Click(sender As Object, e As EventArgs) Handles adminverifybttn.Click
        Dim adminUser As String = adminusrtxt.Text.Trim()
        Dim adminPass As String = adminpsstxt.Text.Trim()

        If con.State = ConnectionState.Closed Then
            con.Open()
        End If

        Dim query As String = "SELECT COUNT (*) FROM Users WHERE Username=@user AND Password=@pass AND Role='Admin'"

        Dim cmd As New SqlCommand(query, con)
        cmd.Parameters.AddWithValue("@user", adminUser)
        cmd.Parameters.AddWithValue("@pass", adminPass)

        Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
        If count > 0 Then
            MessageBox.Show("Admin verified, You may now reset password", "Verified", MessageBoxButtons.OK, MessageBoxIcon.Information)
            trgttxt.Enabled = True
            newpsstxt.Enabled = True
            rstbttn.Enabled = True
        End If
    End Sub

    Private Sub rstbttn_Click(sender As Object, e As EventArgs) Handles rstbttn.Click
        Dim target As String = trgttxt.Text.Trim()
        Dim newpass As String = newpsstxt.Text.Trim()

        If target = "" Or newpass = "" Then
            MessageBox.Show("Please enter Username and New Password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If con.State = ConnectionState.Closed Then
            con.Open()
        End If

        Dim query As String = "UPDATE Users SET Password=@newPass WHERE Username=@target"
        Dim cmd As New SqlCommand(query, con)
        cmd.Parameters.AddWithValue("@newPass", newpass)
        cmd.Parameters.AddWithValue("@target", target)

        Dim rows As Integer = cmd.ExecuteNonQuery()
        If rows > 0 Then
            MessageBox.Show("Password reset successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Username not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        If con.State = ConnectionState.Open Then
            con.Close()
        End If
    End Sub
End Class