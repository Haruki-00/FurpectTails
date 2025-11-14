Imports Microsoft.Data.SqlClient
Public Class manageservicesadminform
    Private connectionString As String = "Server=MARIAKRISTINA\SQLEXPRESS;Database=FurpectTailsDB;Integrated Security=True;TrustServerCertificate=True"

    Private Sub manageservicesadminform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCategories()
        LoadProducts()
    End Sub

    Private Sub LoadProducts(Optional categoryID As Integer = 0)
        Using con As New SqlConnection(connectionString)
            Dim query As String = "SELECT ServiceID, ServiceName, Description, Category, Price FROM ServiceTable"

            Using cmd As New SqlCommand(query, con)
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)
                servgrid.DataSource = dt
            End Using
        End Using
    End Sub


    Private Sub LoadCategories()
        catfiltcmb.Items.Clear()
        catfiltcmb.Items.Add("All")
        catfiltcmb.Items.Add("Grooming")
        catfiltcmb.Items.Add("Add-on")
        catfiltcmb.Items.Add("Dematting")
        catfiltcmb.SelectedIndex = 0

        catcmb.Items.Clear()
        catcmb.Items.Add("Grooming")
        catcmb.Items.Add("Add-on")
        catcmb.Items.Add("Dematting")
    End Sub

    Private Sub LoadServices(Optional filterCategory As String = "All")
        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Dim query As String = "SELECT  ServiceID, ServiceName, Category, Description, Price FROM ServiceTable"

            If filterCategory <> "All" Then
                query &= " WHERE Category = @Category"
            End If

            Dim cmd As New SqlCommand(query, conn)
            If filterCategory <> "All" Then
                cmd.Parameters.AddWithValue("@Category", filterCategory)
            End If

            Dim adapter As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)
            servgrid.DataSource = dt
        End Using
    End Sub

    Private Sub catcmb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles catfiltcmb.SelectedIndexChanged
        Dim selectedCategory As String = catfiltcmb.SelectedItem.ToString()
        LoadServices(selectedCategory)
    End Sub


    Private Function ValidateFields() As Boolean
        If String.IsNullOrWhiteSpace(servnametxt.Text) Then
            MessageBox.Show("Please enter a service name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            servnametxt.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(desctxt.Text) Then
            MessageBox.Show("Please enter a description.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            desctxt.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(pricetxt.Text) OrElse Not Decimal.TryParse(pricetxt.Text, Nothing) Then
            MessageBox.Show("Please enter a valid price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            pricetxt.Focus()
            Return False
        End If

        Return True
    End Function

    '-------NEW BUTTON-------
    Private Sub newbttn_Click(sender As Object, e As EventArgs) Handles newbttn.Click
        If Not ValidateFields() Then Exit Sub

        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim query As String = "INSERT INTO ServiceTable (ServiceName, Description, Category, Price) 
                               VALUES (@name, @desc, @cat, @price)"
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@name", servnametxt.Text)
                cmd.Parameters.AddWithValue("@desc", desctxt.Text)
                cmd.Parameters.AddWithValue("@price", Decimal.Parse(pricetxt.Text))
                cmd.Parameters.AddWithValue("@cat", catcmb.Text)
                cmd.ExecuteNonQuery()
            End Using
        End Using

        MessageBox.Show("Service added successfully!")
        LoadProducts()
        ClearFields()
    End Sub
    '-------UPDATE BUTTON-------
    Private Sub updbttn_Click(sender As Object, e As EventArgs) Handles updbttn.Click
        If String.IsNullOrWhiteSpace(servidtxt.Text) Then
            MessageBox.Show("Please select a service to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not ValidateFields() Then Exit Sub

        Using con As New SqlConnection(connectionString)
            Dim query As String = "UPDATE ServiceTable 
                               SET ServiceName=@ServiceName, Description=@Description, 
                                   Price=@Price, Category=@Category
                               WHERE ServiceID=@ServiceID"
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@ServiceName", servnametxt.Text)
                cmd.Parameters.AddWithValue("@Description", desctxt.Text)
                cmd.Parameters.AddWithValue("@Category", catcmb.Text)
                cmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(pricetxt.Text))
                cmd.Parameters.AddWithValue("@ServiceID", Convert.ToInt32(servidtxt.Text))

                con.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using

        MessageBox.Show("Service updated successfully!")
        ClearFields()
        LoadProducts()
    End Sub
    '-------DELETE BUTTON-------
    Private Sub dltbttn_Click(sender As Object, e As EventArgs) Handles dltbttn.Click
        If String.IsNullOrWhiteSpace(servidtxt.Text) Then
            MessageBox.Show("Please select a Service to delete.")
            Return
        End If

        Using con As New SqlConnection(connectionString)
            Dim query As String = "DELETE FROM ServiceTable WHERE ServiceID=@ServiceID"
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@ServiceID", Convert.ToInt32(servidtxt.Text))

                con.Open()
                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    MessageBox.Show("Service deleted successfully!")
                    ClearFields()
                    LoadProducts()
                Else
                    MessageBox.Show("No Service was deleted. Please check the Service ID.")
                End If
            End Using
        End Using
    End Sub


    Private Sub servgrid_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles servgrid.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = servgrid.Rows(e.RowIndex)
            servidtxt.Text = row.Cells("ServiceID").Value.ToString()
            servnametxt.Text = row.Cells("ServiceName").Value.ToString()
            catcmb.Text = row.Cells("Category").Value.ToString()
            desctxt.Text = row.Cells("Description").Value.ToString()
            pricetxt.Text = row.Cells("Price").Value.ToString()
        End If
    End Sub


    Public Sub ClearFields()
        servnametxt.Clear()
        desctxt.Clear()
        pricetxt.Clear()
        servidtxt.Clear()
        catcmb.Text = ""
    End Sub
    '-------CLEAR BUTTON-------
    Private Sub clrtxt_Click(sender As Object, e As EventArgs) Handles clrtxt.Click
        ClearFields()
    End Sub

End Class