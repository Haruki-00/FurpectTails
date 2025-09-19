<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class resetform
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
        backbttn = New Button()
        adminusrtxt = New TextBox()
        adminpsstxt = New TextBox()
        trgttxt = New TextBox()
        newpsstxt = New TextBox()
        rstbttn = New Button()
        adminverifybttn = New Button()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        SuspendLayout()
        ' 
        ' backbttn
        ' 
        backbttn.BackColor = Color.Red
        backbttn.FlatAppearance.BorderSize = 0
        backbttn.FlatStyle = FlatStyle.Flat
        backbttn.Font = New Font("Lucida Sans", 12.75F, FontStyle.Bold)
        backbttn.ForeColor = SystemColors.ControlText
        backbttn.Location = New Point(0, 0)
        backbttn.Name = "backbttn"
        backbttn.Size = New Size(96, 48)
        backbttn.TabIndex = 0
        backbttn.Text = "Back"
        backbttn.UseVisualStyleBackColor = False
        ' 
        ' adminusrtxt
        ' 
        adminusrtxt.Location = New Point(104, 96)
        adminusrtxt.Name = "adminusrtxt"
        adminusrtxt.Size = New Size(184, 23)
        adminusrtxt.TabIndex = 1
        ' 
        ' adminpsstxt
        ' 
        adminpsstxt.Location = New Point(104, 152)
        adminpsstxt.Name = "adminpsstxt"
        adminpsstxt.Size = New Size(184, 23)
        adminpsstxt.TabIndex = 2
        ' 
        ' trgttxt
        ' 
        trgttxt.Location = New Point(104, 248)
        trgttxt.Name = "trgttxt"
        trgttxt.Size = New Size(184, 23)
        trgttxt.TabIndex = 3
        ' 
        ' newpsstxt
        ' 
        newpsstxt.Location = New Point(104, 304)
        newpsstxt.Name = "newpsstxt"
        newpsstxt.Size = New Size(184, 23)
        newpsstxt.TabIndex = 4
        ' 
        ' rstbttn
        ' 
        rstbttn.Location = New Point(152, 344)
        rstbttn.Name = "rstbttn"
        rstbttn.Size = New Size(80, 32)
        rstbttn.TabIndex = 5
        rstbttn.Text = "Reset"
        rstbttn.UseVisualStyleBackColor = True
        ' 
        ' adminverifybttn
        ' 
        adminverifybttn.Location = New Point(152, 192)
        adminverifybttn.Name = "adminverifybttn"
        adminverifybttn.Size = New Size(80, 32)
        adminverifybttn.TabIndex = 6
        adminverifybttn.Text = "Verify"
        adminverifybttn.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(104, 80)
        Label2.Name = "Label2"
        Label2.Size = New Size(99, 15)
        Label2.TabIndex = 8
        Label2.Text = "Admin Username"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(104, 136)
        Label3.Name = "Label3"
        Label3.Size = New Size(96, 15)
        Label3.TabIndex = 9
        Label3.Text = "Admin Password"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(104, 232)
        Label4.Name = "Label4"
        Label4.Size = New Size(60, 15)
        Label4.TabIndex = 10
        Label4.Text = "Username"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(104, 288)
        Label5.Name = "Label5"
        Label5.Size = New Size(84, 15)
        Label5.TabIndex = 11
        Label5.Text = "New Password"
        ' 
        ' resetform
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(360, 460)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(adminverifybttn)
        Controls.Add(rstbttn)
        Controls.Add(newpsstxt)
        Controls.Add(trgttxt)
        Controls.Add(adminpsstxt)
        Controls.Add(adminusrtxt)
        Controls.Add(backbttn)
        FormBorderStyle = FormBorderStyle.None
        Name = "resetform"
        StartPosition = FormStartPosition.CenterScreen
        Text = "resetform"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents backbttn As Button
    Friend WithEvents adminusrtxt As TextBox
    Friend WithEvents adminpsstxt As TextBox
    Friend WithEvents trgttxt As TextBox
    Friend WithEvents newpsstxt As TextBox
    Friend WithEvents rstbttn As Button
    Friend WithEvents adminverifybttn As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
End Class
