Imports Microsoft.Data.SqlClient

Public Class adminclientprofform

#Region "=== Database Connection ==="

    Private ReadOnly connectionString As String =
        "Server=MARIAKRISTINA\SQLEXPRESS;Database=FurpectTailsDB;Integrated Security=True;TrustServerCertificate=True"

#End Region


#Region "=== Form Load ==="

    Private Sub adminclientprofform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadClients()
    End Sub

#End Region


#Region "=== Utility Methods ==="

    Private Sub ClearFields()
        clientidtxt.Clear()
        lastnametxt.Clear()
        firstnametxt.Clear()
        midnametxt.Clear()
        addresstxt.Clear()
        numbertxt.Clear()
        clientgendercmb.SelectedIndex = -1
    End Sub

#End Region


#Region "=== Data Loading ==="

    Private Sub LoadClients()
        Using con As New SqlConnection(connectionString)
            Dim query As String =
                "SELECT ClientID, LastName, FirstName, MiddleName, Address, PhoneNumber, Gender 
                 FROM ClientTable"

            Using cmd As New SqlCommand(query, con)
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)
                clientsdg.DataSource = dt
            End Using
        End Using
    End Sub


    Private Sub LoadCustomerHistory(search As String)
        Using con As New SqlConnection(connectionString)
            Dim query As String

            ' Numeric → search by ID, otherwise → search by name
            If IsNumeric(search) Then
                query = "SELECT ClientID, LastName, FirstName, MiddleName, Address, PhoneNumber, Gender 
                         FROM ClientTable WHERE ClientID = @search"
            Else
                query = "SELECT ClientID, LastName, FirstName, MiddleName, Address, PhoneNumber, Gender 
                         FROM ClientTable 
                         WHERE FirstName LIKE @search OR LastName LIKE @search"
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
                        ' Single result → display in text fields
                        Dim row As DataRow = dt.Rows(0)
                        clientidtxt.Text = row("ClientID").ToString()
                        lastnametxt.Text = row("LastName").ToString()
                        firstnametxt.Text = row("FirstName").ToString()
                        midnametxt.Text = row("MiddleName").ToString()
                        addresstxt.Text = row("Address").ToString()
                        numbertxt.Text = row("PhoneNumber").ToString()
                        clientgendercmb.Text = row("Gender").ToString()

                    Case > 1
                        ' Multiple results → show in datagrid
                        clientsdg.DataSource = dt
                        ClearFields()

                    Case Else
                        MessageBox.Show("No customer found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ClearFields()
                End Select
            End Using
        End Using
    End Sub

#End Region


#Region "=== DataGrid Events ==="

    Private Sub clientsdg_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles clientsdg.CellClick
        If e.RowIndex < 0 Then Exit Sub

        Dim row As DataGridViewRow = clientsdg.Rows(e.RowIndex)
        clientidtxt.Text = row.Cells("ClientID").Value.ToString()
        lastnametxt.Text = row.Cells("LastName").Value.ToString()
        firstnametxt.Text = row.Cells("FirstName").Value.ToString()
        midnametxt.Text = row.Cells("MiddleName").Value.ToString()
        addresstxt.Text = row.Cells("Address").Value.ToString()
        numbertxt.Text = row.Cells("PhoneNumber").Value.ToString()
        clientgendercmb.Text = row.Cells("Gender").Value.ToString()
    End Sub

#End Region


#Region "=== Button Actions ==="

    ' --- ADD NEW CLIENT ---
    Private Sub newbttn_Click(sender As Object, e As EventArgs) Handles newbttn.Click
        If Not validationmodule.ValidateClientInputs(lastnametxt, firstnametxt, midnametxt, addresstxt, numbertxt, clientgendercmb) Then Exit Sub

        Using con As New SqlConnection(connectionString)
            con.Open()

            Dim query As String =
                "INSERT INTO ClientTable (LastName, FirstName, MiddleName, Address, PhoneNumber, Gender)
                 VALUES (@LastName, @FirstName, @MiddleName, @Address, @PhoneNumber, @Gender)"

            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@LastName", lastnametxt.Text)
                cmd.Parameters.AddWithValue("@FirstName", firstnametxt.Text)
                cmd.Parameters.AddWithValue("@MiddleName", midnametxt.Text)
                cmd.Parameters.AddWithValue("@Address", addresstxt.Text)
                cmd.Parameters.AddWithValue("@PhoneNumber", numbertxt.Text)
                cmd.Parameters.AddWithValue("@Gender", clientgendercmb.Text)
                cmd.ExecuteNonQuery()
            End Using
        End Using

        LoadClients()
        MessageBox.Show("Client saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ClearFields()
    End Sub


    ' --- UPDATE CLIENT ---
    Private Sub updbttn_Click(sender As Object, e As EventArgs) Handles updbttn.Click
        If String.IsNullOrWhiteSpace(clientidtxt.Text) Then
            MessageBox.Show("Please select a client to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not validationmodule.ValidateClientInputs(lastnametxt, firstnametxt, midnametxt, addresstxt, numbertxt, clientgendercmb) Then Exit Sub

        Using con As New SqlConnection(connectionString)
            con.Open()

            Dim query As String =
                "UPDATE ClientTable 
                 SET LastName=@LastName, FirstName=@FirstName, MiddleName=@MiddleName, 
                     Address=@Address, PhoneNumber=@PhoneNumber, Gender=@Gender
                 WHERE ClientID=@ClientID"

            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@ClientID", Convert.ToInt32(clientidtxt.Text))
                cmd.Parameters.AddWithValue("@LastName", lastnametxt.Text)
                cmd.Parameters.AddWithValue("@FirstName", firstnametxt.Text)
                cmd.Parameters.AddWithValue("@MiddleName", midnametxt.Text)
                cmd.Parameters.AddWithValue("@Address", addresstxt.Text)
                cmd.Parameters.AddWithValue("@PhoneNumber", numbertxt.Text)
                cmd.Parameters.AddWithValue("@Gender", clientgendercmb.Text)
                cmd.ExecuteNonQuery()
            End Using
        End Using

        MessageBox.Show("Client updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ClearFields()
        LoadClients()
    End Sub


    ' --- DELETE CLIENT ---
    Private Sub dltbttn_Click(sender As Object, e As EventArgs) Handles dltbttn.Click
        If String.IsNullOrWhiteSpace(clientidtxt.Text) Then
            MessageBox.Show("Please select a client to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim confirm As DialogResult =
            MessageBox.Show("Are you sure you want to delete this client?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirm = DialogResult.No Then Exit Sub

        Using con As New SqlConnection(connectionString)
            con.Open()

            Dim query As String = "DELETE FROM ClientTable WHERE ClientID=@ClientID"

            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@ClientID", Convert.ToInt32(clientidtxt.Text))
                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    MessageBox.Show("Client deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ClearFields()
                    LoadClients()
                Else
                    MessageBox.Show("No client deleted. Please verify the Client ID.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        End Using
    End Sub


    ' --- CLEAR FIELDS ---
    Private Sub clrtxt_Click(sender As Object, e As EventArgs) Handles clrtxt.Click
        ClearFields()
    End Sub


    ' --- SEARCH / SUBMIT ---
    Private Sub sbmtcstmrbtn_Click(sender As Object, e As EventArgs) Handles sbmtcstmrbtn.Click
        Dim searchTerm As String = custidtxt.Text.Trim()
        If searchTerm = "" Then
            MessageBox.Show("Please enter a name or ID to search.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        LoadCustomerHistory(searchTerm)
    End Sub
#End Region
End Class
