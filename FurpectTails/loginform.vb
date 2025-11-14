Imports Microsoft.Data.SqlClient
Public Class loginform
    Dim con As New SqlConnection
    Dim com As New SqlCommand
    Dim read As SqlDataReader
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim username As String = txtUsername.Text
        Dim password As String = txtPassword.Text

        Dim connstring As String = "Server=MARIAKRISTINA\SQLEXPRESs;Database=FurpectTailsDB;Integrated Security=true;TrustServerCertificate=True"
        Try
            con = New SqlConnection(connstring)
            con.Open()
            Dim query As String = "SELECT Role FROM Users WHERE Username=@user AND Password=@pass"
            Dim cmd As New SqlCommand(query, con)

            cmd.Parameters.AddWithValue("@user", txtUsername.Text)
            cmd.Parameters.AddWithValue("@pass", txtPassword.Text)


            read = cmd.ExecuteReader()

            If read.HasRows Then
                read.Read()
                Dim role As String = read("Role").ToString()

                If role = "Admin" Then
                    MessageBox.Show("Welcome Admin!")
                    Dim f As New adminform()
                    f.Show()
                    Me.Hide()
                    txtPassword.Clear()
                    txtUsername.Clear()

                ElseIf role = "Staff" Then
                    MessageBox.Show("Welcome Staff!")
                    Dim f As New staffform()
                    f.Show()
                    Me.Hide()
                    txtPassword.Clear()
                    txtUsername.Clear()

                Else
                    MessageBox.Show("Unknown Role")
                End If

            Else
                MessageBox.Show("Invalid Username or Password.")
                txtPassword.Clear()
                txtUsername.Clear()
            End If

        Catch ex As Exception
            MessageBox.Show("Error")
        Finally
            If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub

    Private Sub rstpassbttn_Click(sender As Object, e As EventArgs) Handles rstpassbttn.Click
        Me.Hide()
        resetform.Show()
    End Sub

    Private Sub backbttn_Click(sender As Object, e As EventArgs) Handles backbttn.Click
        Me.Close()
    End Sub
End Class
