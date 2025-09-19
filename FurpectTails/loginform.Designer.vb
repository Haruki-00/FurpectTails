<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class loginform
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Panel1 = New Panel()
        txtUsername = New TextBox()
        txtPassword = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        Button1 = New Button()
        rstpassbttn = New Button()
        backbttn = New Button()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackgroundImage = My.Resources.Resources._541058696_1287300612839460_7682124276548951984_n_removebg_preview
        Panel1.BackgroundImageLayout = ImageLayout.Zoom
        Panel1.Location = New Point(120, 56)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(104, 96)
        Panel1.TabIndex = 0
        ' 
        ' txtUsername
        ' 
        txtUsername.BorderStyle = BorderStyle.FixedSingle
        txtUsername.Location = New Point(80, 224)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(184, 23)
        txtUsername.TabIndex = 1
        ' 
        ' txtPassword
        ' 
        txtPassword.BorderStyle = BorderStyle.FixedSingle
        txtPassword.Location = New Point(80, 272)
        txtPassword.Name = "txtPassword"
        txtPassword.PasswordChar = "•"c
        txtPassword.Size = New Size(184, 23)
        txtPassword.TabIndex = 2
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(80, 208)
        Label1.Name = "Label1"
        Label1.Size = New Size(60, 15)
        Label1.TabIndex = 3
        Label1.Text = "Username"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(80, 256)
        Label2.Name = "Label2"
        Label2.Size = New Size(57, 15)
        Label2.TabIndex = 4
        Label2.Text = "Password"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(136, 312)
        Button1.Name = "Button1"
        Button1.Size = New Size(75, 23)
        Button1.TabIndex = 5
        Button1.Text = "Log In"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' rstpassbttn
        ' 
        rstpassbttn.FlatAppearance.BorderSize = 0
        rstpassbttn.FlatStyle = FlatStyle.Flat
        rstpassbttn.Location = New Point(120, 344)
        rstpassbttn.Name = "rstpassbttn"
        rstpassbttn.Size = New Size(104, 23)
        rstpassbttn.TabIndex = 6
        rstpassbttn.Text = "Reset Password"
        rstpassbttn.UseVisualStyleBackColor = True
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
        backbttn.TabIndex = 7
        backbttn.Text = "Back"
        backbttn.UseVisualStyleBackColor = False
        ' 
        ' loginform
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(180), CByte(245), CByte(248))
        ClientSize = New Size(360, 460)
        Controls.Add(backbttn)
        Controls.Add(rstpassbttn)
        Controls.Add(Button1)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(txtPassword)
        Controls.Add(txtUsername)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "loginform"
        StartPosition = FormStartPosition.CenterScreen
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents rstpassbttn As Button
    Friend WithEvents backbttn As Button

End Class
