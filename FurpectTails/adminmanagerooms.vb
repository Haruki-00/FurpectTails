Imports Microsoft.Data.SqlClient
Public Class adminmanageroomsform
    Private connectionString As String = "Server=MARIAKRISTINA\SQLEXPRESS;Database=FurpectTailsDB;Integrated Security=True;TrustServerCertificate=True"
    Private Sub adminmanageroomsform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Loadunit()
    End Sub
    Private Sub Loadunit(Optional categoryID As Integer = 0)
        Using con As New SqlConnection(connectionString)
            Dim query As String = "SELECT UnitID, UnitName, Description, SizeType, Price, UnitsAvailable FROM UnitTable"

            Using cmd As New SqlCommand(query, con)
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)
                unitgrid.DataSource = dt
            End Using
        End Using
    End Sub

    Private Function ValidateFields() As Boolean
        If String.IsNullOrWhiteSpace(unitnametxt.Text) Then
            MessageBox.Show("Please enter a unit name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            unitnametxt.Focus()
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
    Private Sub newbttn_Click_1(sender As Object, e As EventArgs) Handles newbttn.Click
        If Not ValidateFields() Then Exit Sub

        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim query = "INSERT INTO UnitTable (UnitName, SizeType, Description, Price, UnitsAvailable) 
                               VALUES (@name, @size, @desc, @price, @avail)"
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@name", unitnametxt.Text)
                cmd.Parameters.AddWithValue("@size", sizecmb.Text)
                cmd.Parameters.AddWithValue("@desc", desctxt.Text)
                cmd.Parameters.AddWithValue("@price", Decimal.Parse(pricetxt.Text))
                cmd.Parameters.AddWithValue("@avail", unitavailtxt.Text)
                cmd.ExecuteNonQuery()
            End Using
        End Using

        MessageBox.Show("Unit added successfully!")
        ClearFields()
        Loadunit()
    End Sub

    Private Sub updbttn_Click_1(sender As Object, e As EventArgs) Handles updbttn.Click
        If String.IsNullOrWhiteSpace(unitidtxt.Text) Then
            MessageBox.Show("Please select a unit to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not ValidateFields() Then Exit Sub

        Using con As New SqlConnection(connectionString)
            Dim query = "UPDATE UnitTable 
                               SET UnitName=@UnitName, Description=@Description, 
                                   Price=@Price, SizeType=@SizeType, UnitsAvailable=@avail
                               WHERE UnitID=@UnitID"
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@UnitName", unitnametxt.Text)
                cmd.Parameters.AddWithValue("@Description", desctxt.Text)
                cmd.Parameters.AddWithValue("@SizeType", sizecmb.Text)
                cmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(pricetxt.Text))
                cmd.Parameters.AddWithValue("@UnitID", Convert.ToInt32(unitidtxt.Text))
                cmd.Parameters.AddWithValue("@avail", unitavailtxt.Text)

                con.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using

        MessageBox.Show("Unit updated successfully!")
        ClearFields()
        Loadunit()
    End Sub

    '-------DELETE BUTTON-------
    Private Sub dltbttn_Click_1(sender As Object, e As EventArgs) Handles dltbttn.Click
        If String.IsNullOrWhiteSpace(unitidtxt.Text) Then
            MessageBox.Show("Please select a Unit to delete.")
            Return
        End If

        Using con As New SqlConnection(connectionString)
            Dim query = "DELETE FROM UnitTable WHERE UnitID=@UnitID"
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@UnitID", Convert.ToInt32(unitidtxt.Text))

                con.Open()
                Dim rowsAffected = cmd.ExecuteNonQuery

                If rowsAffected > 0 Then
                    MessageBox.Show("Unit deleted successfully!")
                    ClearFields()
                    Loadunit()
                Else
                    MessageBox.Show("No unit was deleted. Please check the Unit ID.")
                End If
            End Using
        End Using
    End Sub

    Private Sub unitgrid_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles unitgrid.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = unitgrid.Rows(e.RowIndex)
            unitidtxt.Text = row.Cells("UnitID").Value.ToString()
            unitnametxt.Text = row.Cells("UnitName").Value.ToString()
            sizecmb.Text = row.Cells("SizeType").Value.ToString()
            desctxt.Text = row.Cells("Description").Value.ToString()
            pricetxt.Text = row.Cells("Price").Value.ToString()
            unitavailtxt.Text = row.Cells("UnitsAvailable").Value.ToString()
        End If
    End Sub

    Public Sub ClearFields()
        unitnametxt.Clear()
        desctxt.Clear()
        pricetxt.Clear()
        unitidtxt.Clear()
        sizecmb.Text = ""
        unitavailtxt.Clear()
    End Sub
    '-------CLEAR BUTTON-------
    Private Sub clrtxt_Click(sender As Object, e As EventArgs) Handles clrtxt.Click
        ClearFields()
    End Sub

End Class
