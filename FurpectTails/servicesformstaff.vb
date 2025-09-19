Imports Microsoft.Data.SqlClient

Public Class servicesformstaff

    Private connectionString As String = "Server=MARIAKRISTINA\SQLEXPRESS;Database=FurpectTailsDB;Integrated Security=True;TrustServerCertificate=True"
    Private cart As New DataTable()

    Private Sub servicesformstaff_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadServices()
        SetupCartTable()
    End Sub
    Private Sub LoadServices()
        Dim dt As New DataTable()
        Using con As New SqlConnection(connectionString)
            Dim sql As String =
                "SELECT s.ServiceID, s.ServiceName, c.CategoryName, p.PriceID, p.Size, p.Price
                 FROM Services s
                 LEFT JOIN ServiceCategory c ON s.CategoryID = c.CategoryID
                 LEFT JOIN ServicePricing p ON s.ServiceID = p.ServiceID
                 ORDER BY c.CategoryName, s.ServiceName"
            Using da As New SqlDataAdapter(sql, con)
                da.Fill(dt)
            End Using
        End Using

        servicesgrid.DataSource = dt
        servicesgrid.Columns("ServiceID").Visible = False
        servicesgrid.Columns("PriceID").Visible = False
    End Sub

    Private Sub SetupCartTable()
        cart.Columns.Add("ServiceID", GetType(Integer))
        cart.Columns.Add("PriceID", GetType(Integer))
        cart.Columns.Add("Description", GetType(String))
        'cart.Columns.Add("Quantity", GetType(Integer))
        cart.Columns.Add("UnitPrice", GetType(Decimal))
        'cart.Columns.Add("LineTotal", GetType(Decimal), "Quantity * UnitPrice")
        cart.Columns.Add("LineTotal", GetType(Decimal), "UnitPrice")
        cartgrid.DataSource = cart
    End Sub

    Private Sub addcartbttn_Click(sender As Object, e As EventArgs) Handles addcartbttn.Click
        If servicesgrid.CurrentRow Is Nothing Then Return

        Dim sid As Integer = CInt(servicesgrid.CurrentRow.Cells("ServiceID").Value)
        Dim pid As Object = servicesgrid.CurrentRow.Cells("PriceID").Value
        Dim size As Object = servicesgrid.CurrentRow.Cells("Size").Value
        Dim price As Decimal = Convert.ToDecimal(servicesgrid.CurrentRow.Cells("Price").Value)

        Dim desc As String = servicesgrid.CurrentRow.Cells("ServiceName").Value.ToString()
        If size IsNot DBNull.Value Then desc &= " - " & size.ToString()

        Dim found As DataRow() = cart.Select(String.Format("ServiceID = {0} AND (PriceID = {1} OR (PriceID IS NULL AND {1} IS NULL))",
            sid, If(pid Is DBNull.Value, "NULL", pid)))
        Dim r As DataRow = cart.NewRow()
        r("ServiceID") = sid
        r("PriceID") = If(pid Is DBNull.Value, DBNull.Value, pid)
        r("Description") = desc
        r("UnitPrice") = price
        cart.Rows.Add(r)
        UpdateTotals()

    End Sub
    Private Sub UpdateTotals()
        Dim total As Decimal = 0
        For Each r As DataGridViewRow In cartgrid.Rows
            If r.Cells("LineTotal").Value IsNot Nothing Then
                total += Convert.ToDecimal(r.Cells("LineTotal").Value)
            End If
        Next
        totallbl.Text = total.ToString("N2")
    End Sub

    Private Sub chckbttn_Click(sender As Object, e As EventArgs) Handles chckbttn.Click
        If cart.Rows.Count = 0 Then
            MessageBox.Show("Cart is empty.")
            Return
        End If

        Dim total As Decimal = cart.Compute("SUM(LineTotal)", String.Empty)
        Dim paymentMethod As String = "Cash"
        Dim cashier As String = Environment.UserName

        Dim tvp As New DataTable()
        tvp.Columns.Add("ServiceID", GetType(Integer))
        tvp.Columns.Add("PriceID", GetType(Integer))
        tvp.Columns.Add("Description", GetType(String))
        'tvp.Columns.Add("Quantity", GetType(Integer))
        tvp.Columns.Add("UnitPrice", GetType(Decimal))

        For Each r As DataRow In cart.Rows
            Dim nr = tvp.NewRow()
            nr("ServiceID") = Convert.ToInt32(r("ServiceID"))
            If r.IsNull("PriceID") Then nr("PriceID") = DBNull.Value Else nr("PriceID") = Convert.ToInt32(r("PriceID"))
            nr("Description") = r("Description").ToString()
            'nr("Quantity") = Convert.ToInt32(r("Quantity"))
            nr("UnitPrice") = Convert.ToDecimal(r("UnitPrice"))
            tvp.Rows.Add(nr)
        Next

        Using con As New SqlConnection(connectionString)
            con.Open()
            Using cmd As New SqlCommand("sp_ProcessSale", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@CustomerID", DBNull.Value)
                cmd.Parameters.AddWithValue("@TotalAmount", total)
                cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod)
                cmd.Parameters.AddWithValue("@Cashier", cashier)

                Dim param As SqlParameter = cmd.Parameters.AddWithValue("@Items", tvp)
                param.SqlDbType = SqlDbType.Structured
                param.TypeName = "dbo.SaleItemType"

                Try
                    Dim saleIdObj = cmd.ExecuteScalar()
                    Dim saleId As Integer = Convert.ToInt32(saleIdObj)
                    MessageBox.Show("Sale complete. Sale ID: " & saleId.ToString())
                    PrintReceipt(saleId)
                    cart.Clear()
                    UpdateTotals()
                    LoadServices()
                Catch ex As Exception
                    MessageBox.Show("Checkout failed: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private printText As String = String.Empty

    Private Sub PrintReceipt(saleId As Integer)
        Using con As New SqlConnection(connectionString)
            Dim sql As String =
                "SELECT s.SaleID, s.SaleDate, si.Description, si.Quantity, si.UnitPrice, si.LineTotal, s.TotalAmount
                 FROM Sales s
                 INNER JOIN SaleItems si ON s.SaleID = si.SaleID
                 WHERE s.SaleID = @SaleID"
            Using cmd As New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@SaleID", saleId)
                Dim sb As New System.Text.StringBuilder()
                con.Open()
                Using rdr = cmd.ExecuteReader()
                    sb.AppendLine("Furpet Tails")
                    sb.AppendLine("PET GROOMING & HOTEL")
                    sb.AppendLine("Receipt#: " & saleId.ToString())
                    sb.AppendLine("-----------------------------")
                    While rdr.Read()
                        sb.AppendLine(String.Format("{0} x{1} {2}", rdr("Description"), rdr("Quantity"), CType(rdr("LineTotal"), Decimal).ToString("N2")))
                        sb.AppendLine(String.Format("  Unit: {0:N2}", CType(rdr("UnitPrice"), Decimal)))
                    End While
                End Using

                Dim cmd2 As New SqlCommand("SELECT TotalAmount FROM Sales WHERE SaleID=@SaleID", con)
                cmd2.Parameters.AddWithValue("@SaleID", saleId)
                Dim tot = cmd2.ExecuteScalar()
                sb.AppendLine("-----------------------------")
                sb.AppendLine("TOTAL: " & Convert.ToDecimal(tot).ToString("N2"))
                printText = sb.ToString()
            End Using
        End Using

        Dim pd As New Printing.PrintDocument()
        AddHandler pd.PrintPage, AddressOf pd_PrintPage
        Try
            pd.Print()
        Catch ex As Exception
            MessageBox.Show("Print failed: " & ex.Message)
        End Try
    End Sub

    Private Sub pd_PrintPage(sender As Object, e As Printing.PrintPageEventArgs)
        e.Graphics.DrawString(printText, New Font("Courier New", 10), Brushes.Black, 10, 10)
        e.HasMorePages = False
    End Sub

    Private Sub rnvbttn_Click(sender As Object, e As EventArgs) Handles rnvbttn.Click
        If cartgrid.CurrentRow IsNot Nothing Then
            Dim result As DialogResult = MessageBox.Show("Remove this item from cart?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                cartgrid.Rows.Remove(cartgrid.CurrentRow)
                UpdateTotals()
            End If
        Else
            MessageBox.Show("Please select an item to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
End Class