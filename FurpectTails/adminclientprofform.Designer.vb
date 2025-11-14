<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class adminclientprofform
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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        sbmtcstmrbtn = New Button()
        custidtxt = New TextBox()
        Label21 = New Label()
        lastnametxt = New TextBox()
        clientsdg = New DataGridView()
        Label6 = New Label()
        clientgendercmb = New ComboBox()
        numbertxt = New TextBox()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        addresstxt = New TextBox()
        midnametxt = New TextBox()
        firstnametxt = New TextBox()
        Label1 = New Label()
        clrtxt = New Button()
        updbttn = New Button()
        dltbttn = New Button()
        newbttn = New Button()
        clientidtxt = New TextBox()
        Label7 = New Label()
        Panel1 = New Panel()
        CType(clientsdg, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' sbmtcstmrbtn
        ' 
        sbmtcstmrbtn.Location = New Point(308, 10)
        sbmtcstmrbtn.Name = "sbmtcstmrbtn"
        sbmtcstmrbtn.Size = New Size(75, 23)
        sbmtcstmrbtn.TabIndex = 35
        sbmtcstmrbtn.Text = "Submit"
        sbmtcstmrbtn.UseVisualStyleBackColor = True
        ' 
        ' custidtxt
        ' 
        custidtxt.Location = New Point(76, 10)
        custidtxt.Name = "custidtxt"
        custidtxt.Size = New Size(224, 23)
        custidtxt.TabIndex = 34
        ' 
        ' Label21
        ' 
        Label21.AutoSize = True
        Label21.Location = New Point(28, 15)
        Label21.Name = "Label21"
        Label21.Size = New Size(42, 15)
        Label21.TabIndex = 33
        Label21.Text = "Search"
        ' 
        ' lastnametxt
        ' 
        lastnametxt.Location = New Point(912, 96)
        lastnametxt.Name = "lastnametxt"
        lastnametxt.Size = New Size(224, 23)
        lastnametxt.TabIndex = 32
        ' 
        ' clientsdg
        ' 
        clientsdg.AllowDrop = True
        clientsdg.AllowUserToResizeColumns = False
        clientsdg.AllowUserToResizeRows = False
        clientsdg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        clientsdg.BackgroundColor = Color.FromArgb(CByte(255), CByte(226), CByte(236))
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(252), CByte(198), CByte(219))
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 12F)
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        clientsdg.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        clientsdg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        clientsdg.EnableHeadersVisualStyles = False
        clientsdg.Location = New Point(0, 43)
        clientsdg.Name = "clientsdg"
        clientsdg.ReadOnly = True
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(252), CByte(198), CByte(219))
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle2.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        clientsdg.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        DataGridViewCellStyle3.BackColor = Color.White
        clientsdg.RowsDefaultCellStyle = DataGridViewCellStyle3
        clientsdg.Size = New Size(808, 669)
        clientsdg.TabIndex = 30
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(856, 344)
        Label6.Name = "Label6"
        Label6.Size = New Size(45, 15)
        Label6.TabIndex = 29
        Label6.Text = "Gender"
        ' 
        ' clientgendercmb
        ' 
        clientgendercmb.FormattingEnabled = True
        clientgendercmb.Items.AddRange(New Object() {"Male", "Female"})
        clientgendercmb.Location = New Point(912, 336)
        clientgendercmb.Name = "clientgendercmb"
        clientgendercmb.Size = New Size(224, 23)
        clientgendercmb.TabIndex = 28
        ' 
        ' numbertxt
        ' 
        numbertxt.Location = New Point(912, 288)
        numbertxt.Name = "numbertxt"
        numbertxt.Size = New Size(224, 23)
        numbertxt.TabIndex = 27
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(816, 296)
        Label5.Name = "Label5"
        Label5.Size = New Size(88, 15)
        Label5.TabIndex = 26
        Label5.Text = "Phone Number"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(856, 248)
        Label4.Name = "Label4"
        Label4.Size = New Size(49, 15)
        Label4.TabIndex = 25
        Label4.Text = "Address"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(824, 200)
        Label3.Name = "Label3"
        Label3.Size = New Size(79, 15)
        Label3.TabIndex = 24
        Label3.Text = "Middle Name"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(840, 152)
        Label2.Name = "Label2"
        Label2.Size = New Size(64, 15)
        Label2.TabIndex = 23
        Label2.Text = "First Name"
        ' 
        ' addresstxt
        ' 
        addresstxt.Location = New Point(912, 240)
        addresstxt.Name = "addresstxt"
        addresstxt.Size = New Size(224, 23)
        addresstxt.TabIndex = 22
        ' 
        ' midnametxt
        ' 
        midnametxt.Location = New Point(912, 192)
        midnametxt.Name = "midnametxt"
        midnametxt.Size = New Size(224, 23)
        midnametxt.TabIndex = 21
        ' 
        ' firstnametxt
        ' 
        firstnametxt.Location = New Point(912, 144)
        firstnametxt.Name = "firstnametxt"
        firstnametxt.Size = New Size(224, 23)
        firstnametxt.TabIndex = 20
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(840, 104)
        Label1.Name = "Label1"
        Label1.Size = New Size(63, 15)
        Label1.TabIndex = 19
        Label1.Text = "Last Name"
        ' 
        ' clrtxt
        ' 
        clrtxt.BackColor = Color.FromArgb(CByte(194), CByte(235), CByte(239))
        clrtxt.FlatStyle = FlatStyle.Flat
        clrtxt.Location = New Point(1048, 440)
        clrtxt.Name = "clrtxt"
        clrtxt.Size = New Size(104, 40)
        clrtxt.TabIndex = 39
        clrtxt.Text = "Clear"
        clrtxt.UseVisualStyleBackColor = False
        ' 
        ' updbttn
        ' 
        updbttn.BackColor = Color.FromArgb(CByte(252), CByte(151), CByte(185))
        updbttn.FlatStyle = FlatStyle.Flat
        updbttn.Location = New Point(896, 440)
        updbttn.Name = "updbttn"
        updbttn.Size = New Size(104, 40)
        updbttn.TabIndex = 38
        updbttn.Text = "Update"
        updbttn.UseVisualStyleBackColor = False
        ' 
        ' dltbttn
        ' 
        dltbttn.BackColor = Color.FromArgb(CByte(72), CByte(203), CByte(213))
        dltbttn.FlatStyle = FlatStyle.Flat
        dltbttn.Location = New Point(1048, 376)
        dltbttn.Name = "dltbttn"
        dltbttn.Size = New Size(104, 40)
        dltbttn.TabIndex = 37
        dltbttn.Text = "Delete"
        dltbttn.UseVisualStyleBackColor = False
        ' 
        ' newbttn
        ' 
        newbttn.BackColor = Color.FromArgb(CByte(229), CByte(87), CByte(135))
        newbttn.FlatStyle = FlatStyle.Flat
        newbttn.Location = New Point(896, 376)
        newbttn.Name = "newbttn"
        newbttn.Size = New Size(104, 40)
        newbttn.TabIndex = 36
        newbttn.Text = "New"
        newbttn.UseVisualStyleBackColor = False
        ' 
        ' clientidtxt
        ' 
        clientidtxt.Location = New Point(912, 48)
        clientidtxt.Name = "clientidtxt"
        clientidtxt.ReadOnly = True
        clientidtxt.Size = New Size(224, 23)
        clientidtxt.TabIndex = 41
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(848, 56)
        Label7.Name = "Label7"
        Label7.Size = New Size(52, 15)
        Label7.TabIndex = 40
        Label7.Text = "Client ID"
        ' 
        ' Panel1
        ' 
        Panel1.BackgroundImage = My.Resources.Resources._111bb3d1317b89e95b046d1cdcce1a39b9eba825
        Panel1.BackgroundImageLayout = ImageLayout.Stretch
        Panel1.Location = New Point(944, 520)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(144, 152)
        Panel1.TabIndex = 42
        ' 
        ' adminclientprofform
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(255), CByte(216), CByte(230))
        ClientSize = New Size(1200, 712)
        Controls.Add(Panel1)
        Controls.Add(clientidtxt)
        Controls.Add(Label7)
        Controls.Add(clrtxt)
        Controls.Add(updbttn)
        Controls.Add(dltbttn)
        Controls.Add(newbttn)
        Controls.Add(sbmtcstmrbtn)
        Controls.Add(custidtxt)
        Controls.Add(Label21)
        Controls.Add(lastnametxt)
        Controls.Add(clientsdg)
        Controls.Add(Label6)
        Controls.Add(clientgendercmb)
        Controls.Add(numbertxt)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(addresstxt)
        Controls.Add(midnametxt)
        Controls.Add(firstnametxt)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.None
        Name = "adminclientprofform"
        Text = "adminclientprofform"
        CType(clientsdg, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents sbmtcstmrbtn As Button
    Friend WithEvents custidtxt As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents lastnametxt As TextBox
    Friend WithEvents clientsdg As DataGridView
    Friend WithEvents Label6 As Label
    Friend WithEvents clientgendercmb As ComboBox
    Friend WithEvents numbertxt As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents addresstxt As TextBox
    Friend WithEvents midnametxt As TextBox
    Friend WithEvents firstnametxt As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents clrtxt As Button
    Friend WithEvents updbttn As Button
    Friend WithEvents dltbttn As Button
    Friend WithEvents newbttn As Button
    Friend WithEvents clientidtxt As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel1 As Panel
End Class
