Imports Microsoft.Data.SqlClient

Public Class productform
    Private connectionString As String = "Server=MARIAKRISTINA\SQLEXPRESS;Database=FurpectTailsDB;Integrated Security=True;TrustServerCertificate=True"

    Private Sub productform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCategories()
        LoadProducts()
        SetupCartGrid()
        SetupPaymentMethod()
    End Sub

    ' ---------------- LOAD CATEGORIES ----------------
    Private Sub LoadCategories()
        Using con As New SqlConnection(connectionString)
            Dim query As String = "SELECT CategoryID, CategoryName FROM ProductCategory"
            Dim adapter As New SqlDataAdapter(query, con)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            Dim allRow As DataRow = dt.NewRow()
            allRow("CategoryID") = DBNull.Value
            allRow("CategoryName") = "All Categories"
            dt.Rows.InsertAt(allRow, 0)

            catcmb.DataSource = dt
            catcmb.DisplayMember = "CategoryName"
            catcmb.ValueMember = "CategoryID"
            catcmb.SelectedIndex = 0
        End Using
    End Sub
    ' ---------------- SETUP PAYMENT METHOD ----------------
    Private Sub SetupPaymentMethod()
        paymentmethodcmb.Items.Clear()
        paymentmethodcmb.Items.Add("Cash")
        paymentmethodcmb.Items.Add("GCash")
        paymentmethodcmb.Items.Add("Card")
        paymentmethodcmb.SelectedIndex = 0 ' Default selection
    End Sub

    ' ---------------- LOAD PRODUCTS ----------------
    Private Sub LoadProducts(Optional ByVal categoryId As Integer? = Nothing, Optional ByVal search As String = "")
        Using con As New SqlConnection(connectionString)
            Dim query As String = "
                SELECT ProductID, ProductName, Price, Stock
                FROM ProductTable
                WHERE (@CategoryID IS NULL OR CategoryID = @CategoryID)
                AND (@Search = '' OR ProductName LIKE '%' + @Search + '%')"
            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.AddWithValue("@CategoryID", If(categoryId, DBNull.Value))
            cmd.Parameters.AddWithValue("@Search", search)

            Dim adapter As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)
            proddg.DataSource = dt
        End Using
    End Sub

    ' ---------------- CATEGORY FILTER ----------------
    Private Sub catcmb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles catcmb.SelectedIndexChanged
        If TypeOf catcmb.SelectedValue IsNot DataRowView AndAlso catcmb.SelectedValue IsNot Nothing Then
            Dim categoryId As Integer? = Nothing
            If catcmb.SelectedValue IsNot DBNull.Value Then
                categoryId = Convert.ToInt32(catcmb.SelectedValue)
            End If

            LoadProducts(categoryId)
        End If
    End Sub

    ' ---------------- SEARCH BOX ----------------
    Private Sub searchprodtxt_TextChanged(sender As Object, e As EventArgs) Handles searchprodtxt.TextChanged
        Dim searchValue As String = searchprodtxt.Text.Trim()

        Dim categoryId As Integer? = Nothing
        If catcmb.SelectedValue IsNot Nothing AndAlso catcmb.SelectedValue IsNot DBNull.Value Then
            categoryId = Convert.ToInt32(catcmb.SelectedValue)
        End If

        LoadProducts(categoryId, searchValue)
    End Sub

    ' ---------------- CART SETUP ----------------
    Private Sub SetupCartGrid()
        cartdg.Columns.Clear()
        cartdg.Rows.Clear()

        cartdg.Columns.Add("ProductID", "ProductID")
        cartdg.Columns.Add("ProductName", "Product Name")
        cartdg.Columns.Add("Qty", "Quantity")
        cartdg.Columns.Add("Price", "Price")
        cartdg.Columns.Add("Total", "Total")

        cartdg.Columns("ProductID").Visible = False
    End Sub

    ' ---------------- ADD TO CART ----------------
    Private Sub addcartbtn_Click(sender As Object, e As EventArgs) Handles addcartbtn.Click
        If proddg.CurrentRow Is Nothing Then
            MessageBox.Show("Please select a product.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' --- Get Product Info Safely ---
        Dim productId As Integer = 0
        If Integer.TryParse(proddg.CurrentRow.Cells("ProductID").Value.ToString(), productId) = False OrElse productId <= 0 Then
            MessageBox.Show("Invalid Product ID. Please refresh product list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim productName As String = proddg.CurrentRow.Cells("ProductName").Value.ToString()
        Dim price As Decimal = Convert.ToDecimal(proddg.CurrentRow.Cells("Price").Value)
        Dim stock As Integer = Convert.ToInt32(proddg.CurrentRow.Cells("Stock").Value)

        Dim qty As Integer = 1
        Dim found As Boolean = False

        ' --- Check if already in cart ---
        For Each row As DataGridViewRow In cartdg.Rows
            If Not row.IsNewRow AndAlso Convert.ToInt32(row.Cells("ProductID").Value) = productId Then
                Dim currentQty As Integer = Convert.ToInt32(row.Cells("Qty").Value)
                If currentQty + 1 > stock Then
                    MessageBox.Show("Not enough stock.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                row.Cells("Qty").Value = currentQty + 1
                row.Cells("Total").Value = (currentQty + 1) * price
                found = True
                Exit For
            End If
        Next

        ' --- Add new item ---
        If Not found Then
            If qty > stock Then
                MessageBox.Show("Not enough stock.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            cartdg.Rows.Add(productId, productName, qty, price, qty * price)
        End If

        ComputeTotal()
    End Sub

    ' ---------------- REMOVE FROM CART ----------------
    Private Sub removebtn_Click(sender As Object, e As EventArgs) Handles removebtn.Click
        If cartdg.CurrentRow Is Nothing Then
            MessageBox.Show("Please select an item to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim selectedRow As DataGridViewRow = cartdg.CurrentRow
        If selectedRow.IsNewRow Then Exit Sub

        Dim currentQty As Integer = Convert.ToInt32(selectedRow.Cells("Qty").Value)
        Dim price As Decimal = Convert.ToDecimal(selectedRow.Cells("Price").Value)

        ' --- If only 1 left, remove entire row ---
        If currentQty > 1 Then
            selectedRow.Cells("Qty").Value = currentQty - 1
            selectedRow.Cells("Total").Value = (currentQty - 1) * price
        Else
            cartdg.Rows.Remove(selectedRow)
        End If

        ' --- Recompute total ---
        ComputeTotal()
    End Sub

    ' ---------------- COMPUTE TOTAL ----------------
    Private Sub ComputeTotal()
        Dim total As Decimal = 0
        For Each row As DataGridViewRow In cartdg.Rows
            If Not row.IsNewRow Then
                total += Convert.ToDecimal(row.Cells("Total").Value)
            End If
        Next
        totallbl.Text = "₱" & total.ToString("N2")
    End Sub

    ' ---------------- CHECKOUT ----------------
    Private Sub checkoutbtn_Click(sender As Object, e As EventArgs) Handles checkoutbtn.Click
        If cartdg.Rows.Count = 0 Then
            MessageBox.Show("No items in cart.", "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' --- Compute Total ---
        Dim totalAmount As Decimal = 0
        For Each row As DataGridViewRow In cartdg.Rows
            If Not row.IsNewRow Then
                totalAmount += Convert.ToDecimal(row.Cells("Total").Value)
            End If
        Next

        ' --- Validate Payment Method ---
        If paymentmethodcmb.SelectedIndex = -1 Then
            MessageBox.Show("Please select a payment method.", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim paymentMethod As String = paymentmethodcmb.SelectedItem.ToString()
        Dim status As String = "Paid"

        ' --- Handle Cash Payment ---
        Dim cashGiven As Decimal = 0
        Dim change As Decimal = 0

        If paymentMethod = "Cash" Then
            Dim cashInput As String = InputBox("Enter amount received from customer:", "Cash Payment", totalAmount.ToString("N2"))
            If String.IsNullOrWhiteSpace(cashInput) Then
                MessageBox.Show("Transaction cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If Not Decimal.TryParse(cashInput, cashGiven) OrElse cashGiven < totalAmount Then
                MessageBox.Show("Insufficient cash amount. Please try again.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            change = cashGiven - totalAmount
        Else
            cashGiven = totalAmount
            change = 0
        End If

        ' --- Proceed with Database Transaction ---
        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim tran As SqlTransaction = con.BeginTransaction()

            Try
                Dim insertBill As String = "
                INSERT INTO BillingTable (AppointmentID, PaymentMethod, BillDate, TotalAmount, BookingID, Status)
                OUTPUT INSERTED.BillID
                VALUES (@AppointmentID, @PaymentMethod, GETDATE(), @TotalAmount, @BookingID, @Status)
            "
                Dim cmdBill As New SqlCommand(insertBill, con, tran)
                cmdBill.Parameters.AddWithValue("@AppointmentID", DBNull.Value)
                cmdBill.Parameters.AddWithValue("@PaymentMethod", paymentMethod)
                cmdBill.Parameters.AddWithValue("@TotalAmount", totalAmount)
                cmdBill.Parameters.AddWithValue("@BookingID", DBNull.Value)
                cmdBill.Parameters.AddWithValue("@Status", status)

                Dim billingId As Integer = Convert.ToInt32(cmdBill.ExecuteScalar())

                ' --- Insert BillingProducts ---
                For Each row As DataGridViewRow In cartdg.Rows
                    If row.IsNewRow Then Continue For

                    Dim pid As Integer = Convert.ToInt32(row.Cells("ProductID").Value)
                    Dim qty As Integer = Convert.ToInt32(row.Cells("Qty").Value)
                    Dim price As Decimal = Convert.ToDecimal(row.Cells("Price").Value)

                    Dim insertDetail As String = "
                    INSERT INTO BillingProducts (BillID, ProductID, Quantity, Price)
                    VALUES (@BillID, @ProductID, @Quantity, @Price)
                "
                    Dim cmdDetail As New SqlCommand(insertDetail, con, tran)
                    cmdDetail.Parameters.AddWithValue("@BillID", billingId)
                    cmdDetail.Parameters.AddWithValue("@ProductID", pid)
                    cmdDetail.Parameters.AddWithValue("@Quantity", qty)
                    cmdDetail.Parameters.AddWithValue("@Price", price)
                    cmdDetail.ExecuteNonQuery()

                    ' --- Update stock ---
                    Dim updateStock As String = "
                    UPDATE ProductTable
                    SET Stock = Stock - @Qty
                    WHERE ProductID = @PID
                "
                    Dim cmdStock As New SqlCommand(updateStock, con, tran)
                    cmdStock.Parameters.AddWithValue("@Qty", qty)
                    cmdStock.Parameters.AddWithValue("@PID", pid)
                    cmdStock.ExecuteNonQuery()
                Next

                tran.Commit()

                ' --- Generate Receipt ---
                Dim receipt As New Text.StringBuilder()
                receipt.AppendLine("FurpectTails Pet Supplies")
                receipt.AppendLine("Official Receipt")
                receipt.AppendLine("----------------------------------")
                receipt.AppendLine("Bill Date: " & DateTime.Now.ToString("yyyy-MM-dd HH:mm"))
                receipt.AppendLine("Payment Method: " & paymentMethod)
                receipt.AppendLine("Status: " & status)
                receipt.AppendLine("")
                receipt.AppendLine("Items Purchased:")

                For Each row As DataGridViewRow In cartdg.Rows
                    If row.IsNewRow Then Continue For
                    Dim pname As String = row.Cells("ProductName").Value.ToString()
                    Dim qty As Integer = Convert.ToInt32(row.Cells("Qty").Value)
                    Dim price As Decimal = Convert.ToDecimal(row.Cells("Price").Value)
                    Dim total As Decimal = Convert.ToDecimal(row.Cells("Total").Value)
                    receipt.AppendLine($"- {pname} x{qty} @ ₱{price.ToString("N2")} = ₱{total.ToString("N2")}")
                Next

                receipt.AppendLine("----------------------------------")
                receipt.AppendLine("TOTAL: ₱" & totalAmount.ToString("N2"))
                receipt.AppendLine("PAYMENT METHOD: " & paymentMethod)
                receipt.AppendLine("CASH GIVEN: ₱" & cashGiven.ToString("N2"))
                receipt.AppendLine("CHANGE: ₱" & change.ToString("N2"))
                receipt.AppendLine("----------------------------------")
                receipt.AppendLine("Thank you for shopping at FurpectTails!")
                receipt.AppendLine("We hope to see you again soon.")
                receipt.AppendLine("")

                ' --- Show Receipt Form ---
                Dim rForm As New receiptproductform()
                rForm.BillID = billingId
                rForm.Cashier = "Staff Name" ' you can make this dynamic later
                rForm.PaymentMethod = paymentMethod
                rForm.Items = cartdg
                rForm.TotalAmount = totalAmount
                rForm.CashGiven = cashGiven
                rForm.Change = change
                rForm.BillDate = DateTime.Now
                rForm.ShowDialog()


                ' --- Reset Cart ---
                cartdg.Rows.Clear()
                ComputeTotal()
                LoadProducts()

            Catch ex As Exception
                tran.Rollback()
                MessageBox.Show("Transaction failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

End Class
