<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class staffform
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
        Panel5 = New Panel()
        Prod = New Button()
        report = New Button()
        pethot = New Button()
        clientprof = New Button()
        clndr = New Button()
        logout = New Button()
        Panel4 = New Panel()
        Label1 = New Label()
        Panel3 = New Panel()
        Panel6 = New Panel()
        Panel2 = New Panel()
        Panel1 = New Panel()
        Panel2.SuspendLayout()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel5
        ' 
        Panel5.BackColor = SystemColors.ButtonFace
        Panel5.Location = New Point(0, 48)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(168, 1)
        Panel5.TabIndex = 3
        ' 
        ' Prod
        ' 
        Prod.BackColor = Color.FromArgb(CByte(255), CByte(165), CByte(200))
        Prod.FlatAppearance.BorderSize = 0
        Prod.FlatStyle = FlatStyle.Flat
        Prod.Font = New Font("Lucida Sans", 12.75F, FontStyle.Bold)
        Prod.ForeColor = Color.Black
        Prod.Location = New Point(0, 192)
        Prod.Name = "Prod"
        Prod.Size = New Size(168, 48)
        Prod.TabIndex = 12
        Prod.Text = "Product"
        Prod.UseVisualStyleBackColor = False
        ' 
        ' report
        ' 
        report.BackColor = Color.FromArgb(CByte(255), CByte(165), CByte(200))
        report.FlatAppearance.BorderSize = 0
        report.FlatStyle = FlatStyle.Flat
        report.Font = New Font("Lucida Sans", 12.75F, FontStyle.Bold)
        report.ForeColor = Color.Black
        report.Location = New Point(0, 240)
        report.Name = "report"
        report.Size = New Size(168, 48)
        report.TabIndex = 8
        report.Text = "Reports"
        report.UseVisualStyleBackColor = False
        ' 
        ' pethot
        ' 
        pethot.BackColor = Color.FromArgb(CByte(255), CByte(165), CByte(200))
        pethot.FlatAppearance.BorderSize = 0
        pethot.FlatStyle = FlatStyle.Flat
        pethot.Font = New Font("Lucida Sans", 12.75F, FontStyle.Bold)
        pethot.ForeColor = Color.Black
        pethot.Location = New Point(0, 144)
        pethot.Name = "pethot"
        pethot.Size = New Size(168, 48)
        pethot.TabIndex = 7
        pethot.Text = "Pet Hotel"
        pethot.UseVisualStyleBackColor = False
        ' 
        ' clientprof
        ' 
        clientprof.BackColor = Color.FromArgb(CByte(255), CByte(165), CByte(200))
        clientprof.FlatAppearance.BorderSize = 0
        clientprof.FlatStyle = FlatStyle.Flat
        clientprof.Font = New Font("Lucida Sans", 12.75F, FontStyle.Bold)
        clientprof.ForeColor = Color.Black
        clientprof.Location = New Point(0, 96)
        clientprof.Name = "clientprof"
        clientprof.Size = New Size(168, 48)
        clientprof.TabIndex = 5
        clientprof.Text = "Client Profile"
        clientprof.UseVisualStyleBackColor = False
        ' 
        ' clndr
        ' 
        clndr.BackColor = Color.FromArgb(CByte(255), CByte(165), CByte(200))
        clndr.FlatAppearance.BorderSize = 0
        clndr.FlatStyle = FlatStyle.Flat
        clndr.Font = New Font("Lucida Sans", 12.75F, FontStyle.Bold)
        clndr.ForeColor = Color.Black
        clndr.Location = New Point(0, 48)
        clndr.Name = "clndr"
        clndr.Size = New Size(168, 48)
        clndr.TabIndex = 4
        clndr.Text = "Calendar"
        clndr.UseVisualStyleBackColor = False
        ' 
        ' logout
        ' 
        logout.BackColor = Color.FromArgb(CByte(255), CByte(165), CByte(200))
        logout.FlatAppearance.BorderSize = 0
        logout.FlatStyle = FlatStyle.Flat
        logout.Font = New Font("Lucida Sans", 12.75F, FontStyle.Bold)
        logout.ForeColor = Color.Black
        logout.Location = New Point(0, 288)
        logout.Name = "logout"
        logout.Size = New Size(168, 48)
        logout.TabIndex = 2
        logout.Text = "Log Out"
        logout.UseVisualStyleBackColor = False
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = SystemColors.ButtonFace
        Panel4.Location = New Point(0, 0)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(168, 1)
        Panel4.TabIndex = 2
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Calibri", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.Black
        Label1.Location = New Point(64, 16)
        Label1.Name = "Label1"
        Label1.Size = New Size(38, 15)
        Label1.TabIndex = 2
        Label1.Text = "STAFF"
        ' 
        ' Panel3
        ' 
        Panel3.BackgroundImage = My.Resources.Resources.image02
        Panel3.BackgroundImageLayout = ImageLayout.Zoom
        Panel3.Location = New Point(0, 0)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(168, 56)
        Panel3.TabIndex = 2
        ' 
        ' Panel6
        ' 
        Panel6.BackColor = SystemColors.ActiveBorder
        Panel6.Location = New Point(167, 56)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(1200, 712)
        Panel6.TabIndex = 5
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.FromArgb(CByte(255), CByte(165), CByte(200))
        Panel2.Controls.Add(Panel5)
        Panel2.Controls.Add(Prod)
        Panel2.Controls.Add(report)
        Panel2.Controls.Add(pethot)
        Panel2.Controls.Add(clientprof)
        Panel2.Controls.Add(clndr)
        Panel2.Controls.Add(logout)
        Panel2.Controls.Add(Panel4)
        Panel2.Controls.Add(Label1)
        Panel2.Location = New Point(-1, 56)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(168, 712)
        Panel2.TabIndex = 4
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(242), CByte(37), CByte(118))
        Panel1.Controls.Add(Panel3)
        Panel1.Location = New Point(-1, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1368, 56)
        Panel1.TabIndex = 3
        ' 
        ' staffform
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1366, 768)
        Controls.Add(Panel6)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "staffform"
        Text = "staffform"
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel5 As Panel
    Friend WithEvents Prod As Button
    Friend WithEvents report As Button
    Friend WithEvents pethot As Button
    Friend WithEvents clientprof As Button
    Friend WithEvents clndr As Button
    Friend WithEvents logout As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
End Class
