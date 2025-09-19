Imports Microsoft.Data.SqlClient

Public Class productform
    Dim connectionString As String = "Server=MARIAKRISTINA\SQLEXPRESs;Database=FurpectTailsDB;Integrated Security=true;TrustServerCertificate=True"

    Private Sub LoadData()
        Dim dt As New DataTable()
        Using con As New SqlConnection(connectionString)
            Dim query As String = "SELECT * FROM Productstable"
            Using adap As New SqlDataAdapter(query, con)
                adap.Fill(dt)
                prodgrid.DataSource = dt
            End Using
        End Using
    End Sub

    Private Sub productform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub newbttn_Click(sender As Object, e As EventArgs) Handles newbttn.Click
        Using con As New SqlConnection(connectionString)
            Dim query As String = "INSERT INTO Productstable (ItemName, Description, UnitPrice, Stock) VALUES (@ItemName, @Description, @Price, @Stock)"
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@ItemName", itmnametxt.Text)
                cmd.Parameters.AddWithValue("@Description", desctxt.Text)
                cmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(pricetxt.Text))
                cmd.Parameters.AddWithValue("@Stock", Convert.ToInt32(stcktxt.Text))

                con.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using

        MessageBox.Show("Product added successfully!")
        ClearFields()
        LoadData()
    End Sub

    Private Sub updbttn_Click(sender As Object, e As EventArgs) Handles updbttn.Click
        Using con As New SqlConnection(connectionString)
            Dim query As String = "UPDATE Productstable 
                                   SET ItemName=@ItemName, Description=@Description, UnitPrice=@Price, Stock=@Stock 
                                   WHERE ProductID=@ProductID"
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@ItemName", itmnametxt.Text)
                cmd.Parameters.AddWithValue("@Description", desctxt.Text)
                cmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(pricetxt.Text))
                cmd.Parameters.AddWithValue("@Stock", Convert.ToInt32(stcktxt.Text))
                cmd.Parameters.AddWithValue("@ProductID", Convert.ToInt32(prodidtxt.Text))

                con.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using

        MessageBox.Show("Product updated successfully!")
        ClearFields()
        LoadData()
    End Sub

    Private Sub dltbttn_Click(sender As Object, e As EventArgs) Handles dltbttn.Click
        Using con As New SqlConnection(connectionString)
            Dim query As String = "DELETE FROM Productstable WHERE ProductID=@ProductID"
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@ProductID", Convert.ToInt32(prodidtxt.Text))

                con.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using

        MessageBox.Show("Product deleted successfully!")
        ClearFields()
        LoadData()
    End Sub

    Private Sub clrtxt_Click(sender As Object, e As EventArgs) Handles clrtxt.Click
        itmnametxt.Clear()
        desctxt.Clear()
        pricetxt.Clear()
        stcktxt.Clear()
        prodidtxt.Clear()
    End Sub

    Private Sub prodgrid_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles prodgrid.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = prodgrid.Rows(e.RowIndex)
            prodidtxt.Text = row.Cells(0).Value.ToString()
            itmnametxt.Text = row.Cells(1).Value.ToString()
            desctxt.Text = row.Cells(2).Value.ToString()
            pricetxt.Text = row.Cells(3).Value.ToString()
            stcktxt.Text = row.Cells(4).Value.ToString()
        End If


    End Sub

    Public Sub ClearFields()
        itmnametxt.Clear()
        desctxt.Clear()
        pricetxt.Clear()
        stcktxt.Clear()
        prodidtxt.Clear()
    End Sub
End Class
