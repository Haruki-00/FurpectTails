Imports Microsoft.Data.SqlClient

Public Class adminproductform
    Private connectionString As String = "Server=MARIAKRISTINA\SQLEXPRESS;Database=FurpectTailsDB;Integrated Security=True;TrustServerCertificate=True"

    Private Sub productform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadFilterCategories()
        LoadCategoryChoices()
        LoadProducts()
    End Sub


    Private Sub LoadFilterCategories()
        Using con As New SqlConnection(connectionString)
            Dim query As String = "SELECT CategoryID, CategoryName FROM ProductCategory"
            Dim da As New SqlDataAdapter(query, con)
            Dim dt As New DataTable()
            da.Fill(dt)

            Dim allRow As DataRow = dt.NewRow()
            allRow("CategoryID") = 0
            allRow("CategoryName") = "All"
            dt.Rows.InsertAt(allRow, 0)

            filtercmb.DataSource = dt
            filtercmb.DisplayMember = "CategoryName"
            filtercmb.ValueMember = "CategoryID"
            filtercmb.SelectedIndex = 0
        End Using
    End Sub



    Private Sub LoadCategoryChoices()
        Using con As New SqlConnection(connectionString)
            Dim query As String = "SELECT CategoryID, CategoryName FROM ProductCategory"
            Dim da As New SqlDataAdapter(query, con)
            Dim dt As New DataTable()
            da.Fill(dt)

            catcmb.DataSource = dt
            catcmb.DisplayMember = "CategoryName"
            catcmb.ValueMember = "CategoryID"
        End Using
    End Sub

    Private Sub LoadProducts(Optional categoryID As Integer = 0)
        Using con As New SqlConnection(connectionString)
            Dim query As String = "SELECT p.ProductID, p.ProductName, p.Description, 
                                          c.CategoryName, p.Price, p.Stock, p.CategoryID
                                   FROM ProductTable p 
                                   INNER JOIN ProductCategory c ON p.CategoryID = c.CategoryID"
            If categoryID > 0 Then
                query &= " WHERE p.CategoryID = @CategoryID"
            End If

            Using cmd As New SqlCommand(query, con)
                If categoryID > 0 Then
                    cmd.Parameters.AddWithValue("@CategoryID", categoryID)
                End If

                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)
                prodgrid.DataSource = dt
            End Using
        End Using
    End Sub


    Private Sub filtercmb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles filtercmb.SelectedIndexChanged
        If filtercmb.SelectedValue IsNot Nothing AndAlso IsNumeric(filtercmb.SelectedValue) Then
            Dim selectedCategoryID As Integer = Convert.ToInt32(filtercmb.SelectedValue)
            LoadProducts(selectedCategoryID)
        End If
    End Sub


    Private Function ValidateFields() As Boolean
        If String.IsNullOrWhiteSpace(itmnametxt.Text) Then
            MessageBox.Show("Please enter a product name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            itmnametxt.Focus()
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

        If String.IsNullOrWhiteSpace(stcktxt.Text) OrElse Not Integer.TryParse(stcktxt.Text, Nothing) Then
            MessageBox.Show("Please enter a valid stock number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            stcktxt.Focus()
            Return False
        End If

        If catcmb.SelectedIndex = -1 Then
            MessageBox.Show("Please select a category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            catcmb.Focus()
            Return False
        End If

        Return True
    End Function


    Private Sub newbttn_Click(sender As Object, e As EventArgs) Handles newbttn.Click
        If Not ValidateFields() Then Exit Sub

        Dim categoryID As Integer = CInt(catcmb.SelectedValue)

        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim query As String = "INSERT INTO Products (ProductName, Description, Price, Stock, CategoryID) 
                               VALUES (@name, @desc, @price, @stock, @cat)"
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@name", itmnametxt.Text)
                cmd.Parameters.AddWithValue("@desc", desctxt.Text)
                cmd.Parameters.AddWithValue("@price", Decimal.Parse(pricetxt.Text))
                cmd.Parameters.AddWithValue("@stock", Integer.Parse(stcktxt.Text))
                cmd.Parameters.AddWithValue("@cat", categoryID)
                cmd.ExecuteNonQuery()
            End Using
        End Using

        MessageBox.Show("Product added successfully!")
        LoadProducts()
        ClearFields()
    End Sub



    Private Sub updbttn_Click(sender As Object, e As EventArgs) Handles updbttn.Click
        If String.IsNullOrWhiteSpace(prodidtxt.Text) Then
            MessageBox.Show("Please select a product to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not ValidateFields() Then Exit Sub

        Using con As New SqlConnection(connectionString)
            Dim query As String = "UPDATE Products 
                               SET ProductName=@ProductName, Description=@Description, 
                                   Price=@Price, Stock=@Stock, CategoryID=@CategoryID 
                               WHERE ProductID=@ProductID"
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@ProductName", itmnametxt.Text)
                cmd.Parameters.AddWithValue("@Description", desctxt.Text)
                cmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(pricetxt.Text))
                cmd.Parameters.AddWithValue("@Stock", Convert.ToInt32(stcktxt.Text))
                cmd.Parameters.AddWithValue("@CategoryID", Convert.ToInt32(catcmb.SelectedValue))
                cmd.Parameters.AddWithValue("@ProductID", Convert.ToInt32(prodidtxt.Text))

                con.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using

        MessageBox.Show("Product updated successfully!")
        ClearFields()
        LoadProducts()
    End Sub


    Private Sub dltbttn_Click(sender As Object, e As EventArgs) Handles dltbttn.Click
        If String.IsNullOrWhiteSpace(prodidtxt.Text) Then
            MessageBox.Show("Please select a product to delete.")
            Return
        End If

        Using con As New SqlConnection(connectionString)
            Dim query As String = "DELETE FROM Products WHERE ProductID=@ProductID"
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@ProductID", Convert.ToInt32(prodidtxt.Text))

                con.Open()
                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    MessageBox.Show("Product deleted successfully!")
                    ClearFields()
                    LoadProducts()
                Else
                    MessageBox.Show("No product was deleted. Please check the Product ID.")
                End If
            End Using
        End Using
    End Sub


    Private Sub prodgrid_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles prodgrid.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = prodgrid.Rows(e.RowIndex)
            prodidtxt.Text = row.Cells("ProductID").Value.ToString()
            itmnametxt.Text = row.Cells("ProductName").Value.ToString()
            desctxt.Text = row.Cells("Description").Value.ToString()
            pricetxt.Text = row.Cells("Price").Value.ToString()
            stcktxt.Text = row.Cells("Stock").Value.ToString()

            catcmb.SelectedValue = row.Cells("CategoryID").Value
        End If
    End Sub


    Public Sub ClearFields()
        itmnametxt.Clear()
        desctxt.Clear()
        pricetxt.Clear()
        stcktxt.Clear()
        prodidtxt.Clear()
        catcmb.Text = ""
    End Sub

    Private Sub clrtxt_Click(sender As Object, e As EventArgs) Handles clrtxt.Click
        ClearFields()
    End Sub

End Class
