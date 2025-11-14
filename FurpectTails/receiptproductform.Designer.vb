<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class receiptproductform
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
        Panel1 = New Panel()
        Receiptlbl = New Label()
        exportpdfbtn = New Button()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(Receiptlbl)
        Panel1.Location = New Point(88, 32)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(408, 584)
        Panel1.TabIndex = 0
        ' 
        ' Receiptlbl
        ' 
        Receiptlbl.BorderStyle = BorderStyle.FixedSingle
        Receiptlbl.Dock = DockStyle.Fill
        Receiptlbl.Location = New Point(0, 0)
        Receiptlbl.Name = "Receiptlbl"
        Receiptlbl.Size = New Size(408, 584)
        Receiptlbl.TabIndex = 0
        Receiptlbl.Text = "Receipt"
        ' 
        ' exportpdfbtn
        ' 
        exportpdfbtn.Location = New Point(248, 624)
        exportpdfbtn.Name = "exportpdfbtn"
        exportpdfbtn.Size = New Size(75, 23)
        exportpdfbtn.TabIndex = 1
        exportpdfbtn.Text = "PDF"
        exportpdfbtn.UseVisualStyleBackColor = True
        ' 
        ' receiptproductform
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(575, 673)
        Controls.Add(exportpdfbtn)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Name = "receiptproductform"
        Text = "Receipt"
        Panel1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Receiptlbl As Label
    Friend WithEvents exportpdfbtn As Button
End Class
