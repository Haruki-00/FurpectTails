<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class adminmanageroomsform
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
        Label5 = New Label()
        sizecmb = New ComboBox()
        Label7 = New Label()
        catfiltcmb = New ComboBox()
        pricetxt = New TextBox()
        Label4 = New Label()
        desctxt = New TextBox()
        Label3 = New Label()
        unitnametxt = New TextBox()
        Label2 = New Label()
        unitidtxt = New TextBox()
        Label1 = New Label()
        unitgrid = New DataGridView()
        unitavailtxt = New TextBox()
        Label6 = New Label()
        Panel3 = New Panel()
        Panel1 = New Panel()
        dltbttn = New Button()
        Panel2 = New Panel()
        clrtxt = New Button()
        updbttn = New Button()
        newbttn = New Button()
        CType(unitgrid, ComponentModel.ISupportInitialize).BeginInit()
        Panel3.SuspendLayout()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(99, 157)
        Label5.Name = "Label5"
        Label5.Size = New Size(55, 15)
        Label5.TabIndex = 62
        Label5.Text = "Size Type"
        ' 
        ' sizecmb
        ' 
        sizecmb.FormattingEnabled = True
        sizecmb.Location = New Point(99, 176)
        sizecmb.Name = "sizecmb"
        sizecmb.Size = New Size(224, 23)
        sizecmb.TabIndex = 61
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(58, 18)
        Label7.Name = "Label7"
        Label7.Size = New Size(36, 15)
        Label7.TabIndex = 60
        Label7.Text = "Filter:"
        ' 
        ' catfiltcmb
        ' 
        catfiltcmb.FormattingEnabled = True
        catfiltcmb.Location = New Point(99, 13)
        catfiltcmb.Name = "catfiltcmb"
        catfiltcmb.Size = New Size(224, 23)
        catfiltcmb.TabIndex = 59
        ' 
        ' pricetxt
        ' 
        pricetxt.Location = New Point(475, 174)
        pricetxt.Name = "pricetxt"
        pricetxt.Size = New Size(224, 23)
        pricetxt.TabIndex = 58
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(473, 154)
        Label4.Name = "Label4"
        Label4.Size = New Size(33, 15)
        Label4.TabIndex = 57
        Label4.Text = "Price"
        ' 
        ' desctxt
        ' 
        desctxt.Location = New Point(475, 40)
        desctxt.Name = "desctxt"
        desctxt.Size = New Size(224, 23)
        desctxt.TabIndex = 56
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(475, 20)
        Label3.Name = "Label3"
        Label3.Size = New Size(67, 15)
        Label3.TabIndex = 55
        Label3.Text = "Description"
        ' 
        ' unitnametxt
        ' 
        unitnametxt.Location = New Point(99, 106)
        unitnametxt.Name = "unitnametxt"
        unitnametxt.Size = New Size(224, 23)
        unitnametxt.TabIndex = 54
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(99, 89)
        Label2.Name = "Label2"
        Label2.Size = New Size(64, 15)
        Label2.TabIndex = 53
        Label2.Text = "Unit Name"
        ' 
        ' unitidtxt
        ' 
        unitidtxt.Location = New Point(99, 40)
        unitidtxt.Name = "unitidtxt"
        unitidtxt.ReadOnly = True
        unitidtxt.Size = New Size(224, 23)
        unitidtxt.TabIndex = 52
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(99, 20)
        Label1.Name = "Label1"
        Label1.Size = New Size(43, 15)
        Label1.TabIndex = 48
        Label1.Text = "Unit ID"
        ' 
        ' unitgrid
        ' 
        unitgrid.AllowUserToResizeColumns = False
        unitgrid.AllowUserToResizeRows = False
        unitgrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        unitgrid.BackgroundColor = Color.White
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(252), CByte(198), CByte(219))
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        unitgrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        unitgrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        unitgrid.Location = New Point(0, 52)
        unitgrid.Name = "unitgrid"
        unitgrid.ReadOnly = True
        unitgrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        unitgrid.Size = New Size(1160, 386)
        unitgrid.TabIndex = 46
        ' 
        ' unitavailtxt
        ' 
        unitavailtxt.Location = New Point(475, 103)
        unitavailtxt.Name = "unitavailtxt"
        unitavailtxt.Size = New Size(224, 23)
        unitavailtxt.TabIndex = 64
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(475, 85)
        Label6.Name = "Label6"
        Label6.Size = New Size(80, 15)
        Label6.TabIndex = 63
        Label6.Text = "Unit Available"
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.FromArgb(CByte(255), CByte(229), CByte(239))
        Panel3.BorderStyle = BorderStyle.FixedSingle
        Panel3.Controls.Add(unitgrid)
        Panel3.Controls.Add(Label7)
        Panel3.Controls.Add(catfiltcmb)
        Panel3.Location = New Point(13, 247)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(1160, 441)
        Panel3.TabIndex = 65
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(255), CByte(216), CByte(230))
        Panel1.BorderStyle = BorderStyle.FixedSingle
        Panel1.Controls.Add(dltbttn)
        Panel1.Controls.Add(Panel2)
        Panel1.Controls.Add(clrtxt)
        Panel1.Controls.Add(updbttn)
        Panel1.Controls.Add(newbttn)
        Panel1.Controls.Add(sizecmb)
        Panel1.Controls.Add(desctxt)
        Panel1.Controls.Add(unitavailtxt)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(unitidtxt)
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(pricetxt)
        Panel1.Controls.Add(unitnametxt)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(Label3)
        Panel1.ForeColor = SystemColors.ControlText
        Panel1.Location = New Point(13, 18)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1160, 230)
        Panel1.TabIndex = 66
        ' 
        ' dltbttn
        ' 
        dltbttn.BackColor = Color.FromArgb(CByte(72), CByte(203), CByte(213))
        dltbttn.FlatStyle = FlatStyle.Flat
        dltbttn.ForeColor = SystemColors.ControlText
        dltbttn.Location = New Point(946, 57)
        dltbttn.Name = "dltbttn"
        dltbttn.Size = New Size(104, 40)
        dltbttn.TabIndex = 66
        dltbttn.Text = "Delete"
        dltbttn.UseVisualStyleBackColor = False
        ' 
        ' Panel2
        ' 
        Panel2.BackgroundImage = My.Resources.Resources.paw_prints_1f43e
        Panel2.BackgroundImageLayout = ImageLayout.Zoom
        Panel2.Location = New Point(1024, 14)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(85, 59)
        Panel2.TabIndex = 69
        ' 
        ' clrtxt
        ' 
        clrtxt.BackColor = Color.FromArgb(CByte(194), CByte(235), CByte(239))
        clrtxt.FlatStyle = FlatStyle.Flat
        clrtxt.Location = New Point(947, 125)
        clrtxt.Name = "clrtxt"
        clrtxt.Size = New Size(104, 40)
        clrtxt.TabIndex = 68
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
        updbttn.TabIndex = 67
        updbttn.Text = "Update"
        updbttn.UseVisualStyleBackColor = False
        ' 
        ' newbttn
        ' 
        newbttn.BackColor = Color.FromArgb(CByte(229), CByte(87), CByte(135))
        newbttn.FlatStyle = FlatStyle.Flat
        newbttn.Location = New Point(803, 57)
        newbttn.Name = "newbttn"
        newbttn.Size = New Size(104, 40)
        newbttn.TabIndex = 65
        newbttn.Text = "New"
        newbttn.UseVisualStyleBackColor = False
        ' 
        ' adminmanageroomsform
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(255), CByte(229), CByte(239))
        ClientSize = New Size(1200, 712)
        Controls.Add(Panel1)
        Controls.Add(Panel3)
        FormBorderStyle = FormBorderStyle.None
        Name = "adminmanageroomsform"
        Text = "adminmanagerooms"
        CType(unitgrid, ComponentModel.ISupportInitialize).EndInit()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Label5 As Label
    Friend WithEvents sizecmb As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents catfiltcmb As ComboBox
    Friend WithEvents pricetxt As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents desctxt As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents unitnametxt As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents unitidtxt As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents unitgrid As DataGridView
    Friend WithEvents unitavailtxt As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents dltbttn As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents clrtxt As Button
    Friend WithEvents updbttn As Button
    Friend WithEvents newbttn As Button
End Class
