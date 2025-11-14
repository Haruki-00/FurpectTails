Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO

Public Class receiptproductform
    ' ----------- PROPERTIES -----------
    Public Property BillID As Integer
    Public Property Cashier As String
    Public Property PaymentMethod As String
    Public Property CustomerName As String
    Public Property Items As DataGridView
    Public Property TotalAmount As Decimal
    Public Property CashGiven As Decimal
    Public Property Change As Decimal
    Public Property BillDate As DateTime

    Private Sub receiptform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sb As New Text.StringBuilder()

        ' ----- HEADER -----
        sb.AppendLine("====================================")
        sb.AppendLine("           Furpect Tails")
        sb.AppendLine("      Pet Supplies and Care")
        sb.AppendLine("====================================")
        sb.AppendLine("98 Gen. Luna Street, Taguig City, 1632")
        sb.AppendLine("0927-123-4567 | furfecttails@gmail.com")
        sb.AppendLine()
        sb.AppendLine("            OFFICIAL RECEIPT")
        sb.AppendLine("------------------------------------")
        sb.AppendLine($"Bill No.: {BillID}")
        sb.AppendLine($"Date: {BillDate:MMMM dd, yyyy}")
        sb.AppendLine($"Time: {BillDate:hh:mm tt}")
        sb.AppendLine()
        sb.AppendLine($"Cashier: {Cashier}")
        sb.AppendLine($"Payment Method: {PaymentMethod}")
        If Not String.IsNullOrWhiteSpace(CustomerName) Then
            sb.AppendLine($"Customer: {CustomerName}")
        End If
        sb.AppendLine("------------------------------------")
        sb.AppendLine(String.Format("{0,-20}{1,10}{2,10}", "Item", "Qty", "Amount"))
        sb.AppendLine("------------------------------------")

        ' ----- ITEMS -----
        Dim subtotal As Decimal = 0
        For Each row As DataGridViewRow In Items.Rows
            If row.IsNewRow Then Continue For
            Dim pname As String = row.Cells("ProductName").Value.ToString()
            Dim qty As Integer = Convert.ToInt32(row.Cells("Qty").Value)
            Dim price As Decimal = Convert.ToDecimal(row.Cells("Price").Value)
            Dim total As Decimal = Convert.ToDecimal(row.Cells("Total").Value)

            sb.AppendLine(String.Format("{0,-20}{1,10}{2,10:N2}", pname, qty, total))
            subtotal += total
        Next

        ' ----- TOTALS -----
        sb.AppendLine("------------------------------------")
        sb.AppendLine(String.Format("{0,-20}{1,10:N2}", "Subtotal:", subtotal))
        sb.AppendLine(String.Format("{0,-20}{1,10:N2}", "Total:", TotalAmount))
        sb.AppendLine(String.Format("{0,-20}{1,10:N2}", "Cash Given:", CashGiven))
        sb.AppendLine(String.Format("{0,-20}{1,10:N2}", "Change:", Change))
        sb.AppendLine("====================================")
        sb.AppendLine(" Thank you for shopping with us!")
        sb.AppendLine(" Have a pawsome day! 🐾")
        sb.AppendLine("====================================")

        Receiptlbl.Text = sb.ToString()
    End Sub

    ' ----------- EXPORT TO PDF -----------
    Private Sub exportpdfbtn_Click(sender As Object, e As EventArgs) Handles exportpdfbtn.Click
        Try
            Dim saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf"
            saveFileDialog.FileName = $"Receipt_{BillID}.pdf"

            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                Dim doc As New Document(PageSize.A4, 40, 40, 40, 40)
                PdfWriter.GetInstance(doc, New FileStream(saveFileDialog.FileName, FileMode.Create))
                doc.Open()

                Dim font As Font = FontFactory.GetFont(FontFactory.COURIER, 10)
                doc.Add(New Paragraph(Receiptlbl.Text, font))

                doc.Close()
                MessageBox.Show("Receipt exported successfully!", "PDF Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error exporting to PDF: " & ex.Message)
        End Try
    End Sub
End Class
