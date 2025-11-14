<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class adminpetprofile
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
        petsearchtxt = New TextBox()
        Label22 = New Label()
        Label9 = New Label()
        Label8 = New Label()
        Label7 = New Label()
        petnametxt = New TextBox()
        clientownercmb = New ComboBox()
        petgendercmb = New ComboBox()
        speciescmb = New ComboBox()
        Label10 = New Label()
        Label11 = New Label()
        petagetxt = New TextBox()
        petbreedtxt = New TextBox()
        Label12 = New Label()
        petdg = New DataGridView()
        clrtxt = New Button()
        updbttn = New Button()
        dltbttn = New Button()
        newbttn = New Button()
        Panel1 = New Panel()
        Panel2 = New Panel()
        Panel3 = New Panel()
        CType(petdg, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        Panel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' petsearchtxt
        ' 
        petsearchtxt.Location = New Point(99, 13)
        petsearchtxt.Name = "petsearchtxt"
        petsearchtxt.Size = New Size(224, 23)
        petsearchtxt.TabIndex = 52
        ' 
        ' Label22
        ' 
        Label22.AutoSize = True
        Label22.Location = New Point(58, 18)
        Label22.Name = "Label22"
        Label22.Size = New Size(38, 15)
        Label22.TabIndex = 51
        Label22.Text = "Pet ID"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(473, 154)
        Label9.Name = "Label9"
        Label9.Size = New Size(42, 15)
        Label9.TabIndex = 50
        Label9.Text = "Owner"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(473, 85)
        Label8.Name = "Label8"
        Label8.Size = New Size(45, 15)
        Label8.TabIndex = 49
        Label8.Text = "Gender"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(473, 20)
        Label7.Name = "Label7"
        Label7.Size = New Size(46, 15)
        Label7.TabIndex = 48
        Label7.Text = "Species"
        ' 
        ' petnametxt
        ' 
        petnametxt.Location = New Point(99, 40)
        petnametxt.Name = "petnametxt"
        petnametxt.Size = New Size(224, 23)
        petnametxt.TabIndex = 47
        ' 
        ' clientownercmb
        ' 
        clientownercmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        clientownercmb.AutoCompleteSource = AutoCompleteSource.ListItems
        clientownercmb.FormattingEnabled = True
        clientownercmb.Location = New Point(475, 174)
        clientownercmb.Name = "clientownercmb"
        clientownercmb.Size = New Size(224, 23)
        clientownercmb.TabIndex = 46
        ' 
        ' petgendercmb
        ' 
        petgendercmb.FormattingEnabled = True
        petgendercmb.Items.AddRange(New Object() {"Male", "Female"})
        petgendercmb.Location = New Point(475, 103)
        petgendercmb.Name = "petgendercmb"
        petgendercmb.Size = New Size(224, 23)
        petgendercmb.TabIndex = 45
        ' 
        ' speciescmb
        ' 
        speciescmb.FormattingEnabled = True
        speciescmb.Items.AddRange(New Object() {"Dog", "Cat"})
        speciescmb.Location = New Point(475, 40)
        speciescmb.Name = "speciescmb"
        speciescmb.Size = New Size(224, 23)
        speciescmb.TabIndex = 44
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(99, 157)
        Label10.Name = "Label10"
        Label10.Size = New Size(48, 15)
        Label10.TabIndex = 42
        Label10.Text = "Pet Age"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Location = New Point(99, 89)
        Label11.Name = "Label11"
        Label11.Size = New Size(57, 15)
        Label11.TabIndex = 41
        Label11.Text = "Pet Breed"
        ' 
        ' petagetxt
        ' 
        petagetxt.Location = New Point(99, 176)
        petagetxt.Name = "petagetxt"
        petagetxt.Size = New Size(224, 23)
        petagetxt.TabIndex = 40
        ' 
        ' petbreedtxt
        ' 
        petbreedtxt.Location = New Point(99, 106)
        petbreedtxt.Name = "petbreedtxt"
        petbreedtxt.Size = New Size(224, 23)
        petbreedtxt.TabIndex = 39
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Location = New Point(99, 20)
        Label12.Name = "Label12"
        Label12.Size = New Size(59, 15)
        Label12.TabIndex = 38
        Label12.Text = "Pet Name"
        ' 
        ' petdg
        ' 
        petdg.AllowUserToResizeColumns = False
        petdg.AllowUserToResizeRows = False
        petdg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        petdg.BackgroundColor = Color.White
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(252), CByte(198), CByte(219))
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 12F)
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        petdg.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        petdg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        petdg.EnableHeadersVisualStyles = False
        petdg.Location = New Point(0, 52)
        petdg.Name = "petdg"
        petdg.ReadOnly = True
        petdg.Size = New Size(1160, 386)
        petdg.TabIndex = 54
        ' 
        ' clrtxt
        ' 
        clrtxt.BackColor = Color.FromArgb(CByte(194), CByte(235), CByte(239))
        clrtxt.FlatStyle = FlatStyle.Flat
        clrtxt.Location = New Point(947, 125)
        clrtxt.Name = "clrtxt"
        clrtxt.Size = New Size(104, 40)
        clrtxt.TabIndex = 58
        clrtxt.Text = "Clear"
        clrtxt.UseVisualStyleBackColor = False
        ' 
        ' updbttn
        ' 
        updbttn.BackColor = Color.FromArgb(CByte(252), CByte(151), CByte(185))
        updbttn.FlatStyle = FlatStyle.Flat
        updbttn.Location = New Point(803, 125)
        updbttn.Name = "updbttn"
        updbttn.Size = New Size(104, 40)
        updbttn.TabIndex = 57
        updbttn.Text = "Update"
        updbttn.UseVisualStyleBackColor = False
        ' 
        ' dltbttn
        ' 
        dltbttn.BackColor = Color.FromArgb(CByte(72), CByte(203), CByte(213))
        dltbttn.FlatStyle = FlatStyle.Flat
        dltbttn.ForeColor = SystemColors.ControlText
        dltbttn.Location = New Point(946, 57)
        dltbttn.Name = "dltbttn"
        dltbttn.Size = New Size(104, 40)
        dltbttn.TabIndex = 56
        dltbttn.Text = "Delete"
        dltbttn.UseVisualStyleBackColor = False
        ' 
        ' newbttn
        ' 
        newbttn.BackColor = Color.FromArgb(CByte(229), CByte(87), CByte(135))
        newbttn.FlatStyle = FlatStyle.Flat
        newbttn.Location = New Point(803, 57)
        newbttn.Name = "newbttn"
        newbttn.Size = New Size(104, 40)
        newbttn.TabIndex = 55
        newbttn.Text = "New"
        newbttn.UseVisualStyleBackColor = False
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(255), CByte(216), CByte(230))
        Panel1.BorderStyle = BorderStyle.FixedSingle
        Panel1.Controls.Add(dltbttn)
        Panel1.Controls.Add(Panel2)
        Panel1.Controls.Add(petnametxt)
        Panel1.Controls.Add(clrtxt)
        Panel1.Controls.Add(Label12)
        Panel1.Controls.Add(updbttn)
        Panel1.Controls.Add(Label9)
        Panel1.Controls.Add(petbreedtxt)
        Panel1.Controls.Add(clientownercmb)
        Panel1.Controls.Add(petagetxt)
        Panel1.Controls.Add(newbttn)
        Panel1.Controls.Add(Label11)
        Panel1.Controls.Add(Label10)
        Panel1.Controls.Add(speciescmb)
        Panel1.Controls.Add(petgendercmb)
        Panel1.Controls.Add(Label7)
        Panel1.Controls.Add(Label8)
        Panel1.ForeColor = SystemColors.ControlText
        Panel1.Location = New Point(13, 18)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1160, 230)
        Panel1.TabIndex = 59
        ' 
        ' Panel2
        ' 
        Panel2.BackgroundImage = My.Resources.Resources.paw_prints_1f43e
        Panel2.BackgroundImageLayout = ImageLayout.Zoom
        Panel2.Location = New Point(1024, 14)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(85, 59)
        Panel2.TabIndex = 59
        ' 
        ' Panel3
        ' 
        Panel3.BorderStyle = BorderStyle.FixedSingle
        Panel3.Controls.Add(petdg)
        Panel3.Controls.Add(petsearchtxt)
        Panel3.Controls.Add(Label22)
        Panel3.Location = New Point(13, 247)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(1160, 441)
        Panel3.TabIndex = 60
        ' 
        ' adminpetprofile
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(255), CByte(229), CByte(239))
        ClientSize = New Size(1200, 712)
        Controls.Add(Panel3)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "adminpetprofile"
        Text = "adminpetprofile"
        CType(petdg, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents petsearchtxt As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents petnametxt As TextBox
    Friend WithEvents clientownercmb As ComboBox
    Friend WithEvents petgendercmb As ComboBox
    Friend WithEvents speciescmb As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents petagetxt As TextBox
    Friend WithEvents petbreedtxt As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents petdg As DataGridView
    Friend WithEvents clrtxt As Button
    Friend WithEvents updbttn As Button
    Friend WithEvents dltbttn As Button
    Friend WithEvents newbttn As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
End Class
