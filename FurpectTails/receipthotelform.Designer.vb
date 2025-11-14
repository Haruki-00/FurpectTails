<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class receipthotelform
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
        receiptlbl = New Label()
        Panel1 = New Panel()
        exportpdrbtn = New Button()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' receiptlbl
        ' 
        receiptlbl.BorderStyle = BorderStyle.FixedSingle
        receiptlbl.Dock = DockStyle.Fill
        receiptlbl.Font = New Font("Segoe UI", 11F)
        receiptlbl.Location = New Point(0, 0)
        receiptlbl.Name = "receiptlbl"
        receiptlbl.Size = New Size(366, 382)
        receiptlbl.TabIndex = 0
        receiptlbl.Text = "Receipt"
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = SystemColors.Control
        Panel1.BorderStyle = BorderStyle.FixedSingle
        Panel1.Controls.Add(receiptlbl)
        Panel1.Location = New Point(96, 24)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(368, 384)
        Panel1.TabIndex = 1
        ' 
        ' exportpdrbtn
        ' 
        exportpdrbtn.Location = New Point(240, 416)
        exportpdrbtn.Name = "exportpdrbtn"
        exportpdrbtn.Size = New Size(75, 23)
        exportpdrbtn.TabIndex = 2
        exportpdrbtn.Text = "Button1"
        exportpdrbtn.UseVisualStyleBackColor = True
        ' 
        ' receipthotelform
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(575, 470)
        Controls.Add(exportpdrbtn)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Name = "receipthotelform"
        Text = "receipthotelform"
        Panel1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents receiptlbl As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents exportpdrbtn As Button
End Class
