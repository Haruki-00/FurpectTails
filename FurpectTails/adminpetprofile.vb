Imports Microsoft.Data.SqlClient
Public Class adminpetprofile
    Private connectionString As String = "Server=MARIAKRISTINA\SQLEXPRESS;Database=FurpectTailsDB;Integrated Security=True;TrustServerCertificate=True"
    Private Sub adminpetprofile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Loadpet()
        LoadOwners()
    End Sub

    Public Sub clearfields()
        petnametxt.Clear()
        petbreedtxt.Clear()
        petagetxt.Clear()
        speciescmb.Text = ""
        petgendercmb.Text = ""
        clientownercmb.Text = ""
    End Sub

    Private Sub LoadOwners()
        Using con As New SqlConnection(connectionString)
            Dim query As String = "
            SELECT 
                ClientID,
                (FirstName + ' ' + LastName) AS FullName
            FROM ClientTable
        "

            Using cmd As New SqlCommand(query, con)
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)

                clientownercmb.DataSource = dt
                clientownercmb.DisplayMember = "FullName"
                clientownercmb.ValueMember = "ClientID"
                clientownercmb.SelectedIndex = -1
            End Using
        End Using
    End Sub

    Private Sub SearchPet()
        Using con As New SqlConnection(connectionString)
            Dim query As String = "
            SELECT 
                P.PetID,
                P.PetName,
                P.PetBreed,
                P.PetAge,
                P.Species,
                P.Gender,
                P.ClientID,
                (C.FirstName + ' ' + C.LastName) AS OwnerName
            FROM PetTable P
            INNER JOIN ClientTable C ON P.ClientID = C.ClientID
            WHERE 
                P.PetID LIKE @search OR
                P.PetName LIKE @search OR
                P.PetBreed LIKE @search OR
                P.Species LIKE @search OR
                C.FirstName + ' ' + C.LastName LIKE @search
        "

            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@search", "%" & petsearchtxt.Text & "%")

                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)

                petdg.DataSource = dt
            End Using
        End Using
    End Sub

    Private Sub petsearchtxt_TextChanged(sender As Object, e As EventArgs) Handles petsearchtxt.TextChanged
        SearchPet()
    End Sub

    Private Sub Loadpet()
        Using con As New SqlConnection(connectionString)
            Dim query As String = "
            SELECT 
                P.PetID,
                P.PetName,
                P.PetBreed,
                P.PetAge,
                P.Species,
                P.Gender,
                P.ClientID,
                (C.FirstName + ' ' + C.LastName) AS OwnerName
            FROM PetTable P
            INNER JOIN ClientTable C ON P.ClientID = C.ClientID
        "

            Using cmd As New SqlCommand(query, con)
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)
                petdg.DataSource = dt
            End Using
        End Using
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
            clientownercmb.SelectedValue = CInt(row.Cells("ClientID").Value)
        End If
    End Sub


    Private Function ValidateClientInputs() As Boolean
        If String.IsNullOrWhiteSpace(petnametxt.Text) Then
            MessageBox.Show("Please enter the pet name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            petnametxt.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(petbreedtxt.Text) Then
            MessageBox.Show("Please enter the pet breed.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            petbreedtxt.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(petagetxt.Text) Then
            MessageBox.Show("Please enter the pet age.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            petagetxt.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(speciescmb.Text) Then
            MessageBox.Show("Please enter the pet species.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            speciescmb.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(petgendercmb.Text) Then
            MessageBox.Show("Please enter the client's phone number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            petgendercmb.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(clientownercmb.Text) Then
            MessageBox.Show("Please select the client's gender.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            clientownercmb.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub newbttn_Click(sender As Object, e As EventArgs) Handles newbttn.Click
        If Not ValidateClientInputs() Then Exit Sub

        Using con As New SqlConnection(connectionString)
            Dim query As String = "INSERT INTO PetTable (PetName, PetBreed, PetAge, Species, Gender, ClientID)
                               VALUES (@PetName, @PetBreed, @PetAge, @Species, @Gender, @ClientID)"

            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@PetName", petnametxt.Text)
                cmd.Parameters.AddWithValue("@PetBreed", petbreedtxt.Text)
                cmd.Parameters.AddWithValue("@PetAge", petagetxt.Text)
                cmd.Parameters.AddWithValue("@Species", speciescmb.Text)
                cmd.Parameters.AddWithValue("@Gender", petgendercmb.Text)
                cmd.Parameters.AddWithValue("@ClientID", clientownercmb.SelectedValue)

                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using

        MessageBox.Show("Pet added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Loadpet()
        clearfields()
    End Sub

    Private Sub updbttn_Click(sender As Object, e As EventArgs) Handles updbttn.Click
        If petdg.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a pet to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim petID As Integer = CInt(petdg.SelectedRows(0).Cells("PetID").Value)

        Using con As New SqlConnection(connectionString)
            Dim query As String = "
            UPDATE PetTable SET
                PetName = @PetName,
                PetBreed = @PetBreed,
                PetAge = @PetAge,
                Species = @Species,
                Gender = @Gender,
                ClientID = @ClientID
            WHERE PetID = @PetID
        "

            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@PetID", petID)
                cmd.Parameters.AddWithValue("@PetName", petnametxt.Text)
                cmd.Parameters.AddWithValue("@PetBreed", petbreedtxt.Text)
                cmd.Parameters.AddWithValue("@PetAge", petagetxt.Text)
                cmd.Parameters.AddWithValue("@Species", speciescmb.Text)
                cmd.Parameters.AddWithValue("@Gender", petgendercmb.Text)
                cmd.Parameters.AddWithValue("@ClientID", clientownercmb.SelectedValue)

                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using

        MessageBox.Show("Pet updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Loadpet()
        clearfields()
    End Sub

    Private Sub dltbttn_Click(sender As Object, e As EventArgs) Handles dltbttn.Click
        If petdg.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a pet to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim petID As Integer = CInt(petdg.SelectedRows(0).Cells("PetID").Value)

        If MessageBox.Show("Are you sure you want to delete this pet?",
                       "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        Using con As New SqlConnection(connectionString)
            Dim query As String = "DELETE FROM PetTable WHERE PetID = @PetID"

            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@PetID", petID)
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using

        MessageBox.Show("Pet deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Loadpet()
        clearfields()
    End Sub

    Private Sub clrtxt_Click(sender As Object, e As EventArgs) Handles clrtxt.Click
        clearfields()
    End Sub


End Class