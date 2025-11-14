Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class receipthotelform
    Public Property Receipthoteltext As String

    Private Sub receiptForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        receiptlbl.Text = Receipthoteltext
    End Sub

    Private Sub exportpdrbtn_Click(sender As Object, e As EventArgs) Handles exportpdrbtn.Click
        Dim saveDialog As New SaveFileDialog()
        saveDialog.Filter = "PDF Files|*.pdf"
        saveDialog.FileName = "Receipt.pdf"

        If saveDialog.ShowDialog() = DialogResult.OK Then
            Dim doc As New Document(PageSize.A4, 40, 40, 40, 40)
            PdfWriter.GetInstance(doc, New FileStream(saveDialog.FileName, FileMode.Create))
            doc.Open()
            doc.Add(New Paragraph(receiptlbl.Text, FontFactory.GetFont("Arial", 12)))
            doc.Close()
            MessageBox.Show("Receipt exported as PDF successfully!")
        End If
    End Sub

End Class