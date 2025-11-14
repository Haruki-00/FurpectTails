<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class manageservicesadminform
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
        Label7 = New Label()
        catfiltcmb = New ComboBox()
        pricetxt = New TextBox()
        Label4 = New Label()
        desctxt = New TextBox()
        Label3 = New Label()
        servnametxt = New TextBox()
        Label2 = New Label()
        servidtxt = New TextBox()
        clrtxt = New Button()
        updbttn = New Button()
        dltbttn = New Button()
        Label1 = New Label()
        newbttn = New Button()
        servgrid = New DataGridView()
        catcmb = New ComboBox()
        Label5 = New Label()
        CType(servgrid, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(352, 336)
        Label7.Name = "Label7"
        Label7.Size = New Size(36, 15)
        Label7.TabIndex = 43
        Label7.Text = "Filter:"
        ' 
        ' catfiltcmb
        ' 
        catfiltcmb.FormattingEnabled = True
        catfiltcmb.Location = New Point(352, 360)
        catfiltcmb.Name = "catfiltcmb"
        catfiltcmb.Size = New Size(121, 23)
        catfiltcmb.TabIndex = 40
        ' 
        ' pricetxt
        ' 
        pricetxt.Location = New Point(136, 248)
        pricetxt.Name = "pricetxt"
        pricetxt.Size = New Size(176, 23)
        pricetxt.TabIndex = 37
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(56, 256)
        Label4.Name = "Label4"
        Label4.Size = New Size(33, 15)
        Label4.TabIndex = 36
        Label4.Text = "Price"
        ' 
        ' desctxt
        ' 
        desctxt.Location = New Point(136, 208)
        desctxt.Name = "desctxt"
        desctxt.Size = New Size(176, 23)
        desctxt.TabIndex = 35
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(56, 216)
        Label3.Name = "Label3"
        Label3.Size = New Size(67, 15)
        Label3.TabIndex = 34
        Label3.Text = "Description"
        ' 
        ' servnametxt
        ' 
        servnametxt.Location = New Point(136, 128)
        servnametxt.Name = "servnametxt"
        servnametxt.Size = New Size(176, 23)
        servnametxt.TabIndex = 33
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(56, 136)
        Label2.Name = "Label2"
        Label2.Size = New Size(79, 15)
        Label2.TabIndex = 32
        Label2.Text = "Service Name"
        ' 
        ' servidtxt
        ' 
        servidtxt.Location = New Point(136, 88)
        servidtxt.Name = "servidtxt"
        servidtxt.ReadOnly = True
        servidtxt.Size = New Size(176, 23)
        servidtxt.TabIndex = 31
        ' 
        ' clrtxt
        ' 
        clrtxt.Location = New Point(208, 368)
        clrtxt.Name = "clrtxt"
        clrtxt.Size = New Size(104, 40)
        clrtxt.TabIndex = 30
        clrtxt.Text = "Clear"
        clrtxt.UseVisualStyleBackColor = True
        ' 
        ' updbttn
        ' 
        updbttn.Location = New Point(64, 368)
        updbttn.Name = "updbttn"
        updbttn.Size = New Size(104, 40)
        updbttn.TabIndex = 29
        updbttn.Text = "Update"
        updbttn.UseVisualStyleBackColor = True
        ' 
        ' dltbttn
        ' 
        dltbttn.BackColor = Color.Red
        dltbttn.FlatStyle = FlatStyle.Flat
        dltbttn.Location = New Point(208, 296)
        dltbttn.Name = "dltbttn"
        dltbttn.Size = New Size(104, 40)
        dltbttn.TabIndex = 28
        dltbttn.Text = "Delete"
        dltbttn.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(56, 96)
        Label1.Name = "Label1"
        Label1.Size = New Size(58, 15)
        Label1.TabIndex = 27
        Label1.Text = "Service ID"
        ' 
        ' newbttn
        ' 
        newbttn.BackColor = Color.FromArgb(CByte(128), CByte(255), CByte(128))
        newbttn.FlatStyle = FlatStyle.Flat
        newbttn.Location = New Point(64, 296)
        newbttn.Name = "newbttn"
        newbttn.Size = New Size(104, 40)
        newbttn.TabIndex = 26
        newbttn.Text = "New"
        newbttn.UseVisualStyleBackColor = False
        ' 
        ' servgrid
        ' 
        servgrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        servgrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        servgrid.Location = New Point(352, 48)
        servgrid.Name = "servgrid"
        servgrid.ReadOnly = True
        servgrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        servgrid.Size = New Size(752, 280)
        servgrid.TabIndex = 25
        ' 
        ' catcmb
        ' 
        catcmb.FormattingEnabled = True
        catcmb.Location = New Point(136, 168)
        catcmb.Name = "catcmb"
        catcmb.Size = New Size(176, 23)
        catcmb.TabIndex = 44
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(56, 176)
        Label5.Name = "Label5"
        Label5.Size = New Size(55, 15)
        Label5.TabIndex = 45
        Label5.Text = "Category"
        ' 
        ' manageservicesadminform
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1200, 712)
        Controls.Add(Label5)
        Controls.Add(catcmb)
        Controls.Add(Label7)
        Controls.Add(catfiltcmb)
        Controls.Add(pricetxt)
        Controls.Add(Label4)
        Controls.Add(desctxt)
        Controls.Add(Label3)
        Controls.Add(servnametxt)
        Controls.Add(Label2)
        Controls.Add(servidtxt)
        Controls.Add(clrtxt)
        Controls.Add(updbttn)
        Controls.Add(dltbttn)
        Controls.Add(Label1)
        Controls.Add(newbttn)
        Controls.Add(servgrid)
        FormBorderStyle = FormBorderStyle.None
        Name = "manageservicesadminform"
        Text = "manageservicesadminform"
        CType(servgrid, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label7 As Label
    Friend WithEvents catfiltcmb As ComboBox
    Friend WithEvents pricetxt As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents desctxt As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents servnametxt As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents servidtxt As TextBox
    Friend WithEvents clrtxt As Button
    Friend WithEvents updbttn As Button
    Friend WithEvents dltbttn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents newbttn As Button
    Friend WithEvents servgrid As DataGridView
    Friend WithEvents catcmb As ComboBox
    Friend WithEvents Label5 As Label
End Class
