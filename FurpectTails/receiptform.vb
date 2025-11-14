Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO

Public Class receiptform
    ' ----------- PROPERTIES -----------
    Public Property ReceiptNo As String
    Public Property Cashier As String
    Public Property PaymentMethod As String
    Public Property CustomerName As String
    Public Property PetNames As String
    Public Property ServiceType As String
    Public Property Services As DataTable
    Public Property VAT As Decimal
    Public Property TotalAmount As Decimal
    Public Property Change As Decimal
    Public Property BillDate As DateTime

    Private Sub receiptform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'receiptlbl.Font = New Font("Consolas", 10, FontStyle.Regular)
        'receiptlbl.AutoSize = False
        'receiptlbl.Dock = DockStyle.Fill
        'receiptlbl.TextAlign = ContentAlignment.TopLeft

        Dim sb As New Text.StringBuilder()

        sb.AppendLine("====================================")
        sb.AppendLine("             Furpect Tails")
        sb.AppendLine("        Pet Grooming & Hotel")
        sb.AppendLine("====================================")
        sb.AppendLine("98 Gen. Luna Street, Taguig City, 1632, Metro Manila")
        sb.AppendLine("0927-123-4567 | furfecttails@gmail.com")
        sb.AppendLine()
        sb.AppendLine("              OFFICIAL RECEIPT")
        sb.AppendLine("------------------------------------")
        sb.AppendLine($"Receipt No.: {ReceiptNo}")
        sb.AppendLine($"Date Issued: {BillDate:MMMM dd, yyyy}")
        sb.AppendLine($"Time: {BillDate:hh:mm tt}")
        sb.AppendLine()
        sb.AppendLine($"Cashier: {Cashier}")
        sb.AppendLine($"Payment Method: {PaymentMethod}")
        sb.AppendLine($"Customer Name: {CustomerName}")
        sb.AppendLine($"Pet Name(s): {PetNames}")
        sb.AppendLine($"Service Type: {ServiceType}")
        sb.AppendLine("------------------------------------")
        sb.AppendLine(String.Format("{0,-20}{1,10}", "Description", "Price (₱)"))
        sb.AppendLine("------------------------------------")

        Dim subtotal As Decimal = 0
        For Each row As DataRow In Services.Rows
            sb.AppendLine(String.Format("{0,-20}{1,10:N2}", row("ServiceName"), row("Price")))
            subtotal += Convert.ToDecimal(row("Price"))
        Next

        sb.AppendLine("------------------------------------")
        sb.AppendLine(String.Format("{0,-20}{1,10:N2}", "Subtotal:", subtotal))
        sb.AppendLine(String.Format("{0,-20}{1,10:N2}", "VAT (12%):", VAT))
        sb.AppendLine(String.Format("{0,-20}{1,10:N2}", "Total:", TotalAmount))
        sb.AppendLine(String.Format("{0,-20}{1,10:N2}", "Cash:", TotalAmount + Change))
        sb.AppendLine(String.Format("{0,-20}{1,10:N2}", "Change:", Change))
        sb.AppendLine("====================================")
        sb.AppendLine("   Thank you for trusting Furpect Tails!")
        sb.AppendLine("====================================")

        receiptlbl.Text = sb.ToString()
    End Sub

    ' ----------- EXPORT TO PDF -----------
    Private Sub exportpdfbtn_Click(sender As Object, e As EventArgs) Handles exportpdfbtn.Click
        Try
            Dim saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf"
            saveFileDialog.FileName = $"Receipt_{ReceiptNo}.pdf"

            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                Dim doc As New Document(PageSize.A4, 40, 40, 40, 40)
                PdfWriter.GetInstance(doc, New FileStream(saveFileDialog.FileName, FileMode.Create))
                doc.Open()

                Dim font As Font = FontFactory.GetFont(FontFactory.COURIER, 10)
                doc.Add(New Paragraph(receiptlbl.Text, font))

                doc.Close()
                MessageBox.Show("Receipt exported successfully!", "PDF Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error exporting to PDF: " & ex.Message)
        End Try
    End Sub
End Class
