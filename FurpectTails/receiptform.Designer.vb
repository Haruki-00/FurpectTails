<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class receiptform
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        exportpdfbtn = New Button()
        Panel1 = New Panel()
        receiptlbl = New Label()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' exportpdfbtn
        ' 
        exportpdfbtn.Location = New Point(256, 640)
        exportpdfbtn.Name = "exportpdfbtn"
        exportpdfbtn.Size = New Size(75, 23)
        exportpdfbtn.TabIndex = 2
        exportpdfbtn.Text = "PDF"
        exportpdfbtn.UseVisualStyleBackColor = True
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(receiptlbl)
        Panel1.Location = New Point(80, 32)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(408, 584)
        Panel1.TabIndex = 3
        ' 
        ' receiptlbl
        ' 
        receiptlbl.BorderStyle = BorderStyle.FixedSingle
        receiptlbl.Dock = DockStyle.Fill
        receiptlbl.Font = New Font("Segoe UI", 10F)
        receiptlbl.Location = New Point(0, 0)
        receiptlbl.Name = "receiptlbl"
        receiptlbl.Size = New Size(408, 584)
        receiptlbl.TabIndex = 0
        receiptlbl.Text = "Receipt"
        receiptlbl.TextAlign = ContentAlignment.TopCenter
        ' 
        ' receiptform
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(575, 673)
        Controls.Add(Panel1)
        Controls.Add(exportpdfbtn)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Name = "receiptform"
        Text = "Receipt"
        Panel1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents exportpdfbtn As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents receiptlbl As Label
End Class
