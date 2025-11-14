<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class adminproductform
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
        prodgrid = New DataGridView()
        newbttn = New Button()
        Label1 = New Label()
        dltbttn = New Button()
        updbttn = New Button()
        clrtxt = New Button()
        prodidtxt = New TextBox()
        itmnametxt = New TextBox()
        Label2 = New Label()
        desctxt = New TextBox()
        Label3 = New Label()
        pricetxt = New TextBox()
        Label4 = New Label()
        stcktxt = New TextBox()
        Label5 = New Label()
        filtercmb = New ComboBox()
        Label6 = New Label()
        catcmb = New ComboBox()
        Label7 = New Label()
        CType(prodgrid, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' prodgrid
        ' 
        prodgrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        prodgrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        prodgrid.Location = New Point(344, 24)
        prodgrid.Name = "prodgrid"
        prodgrid.ReadOnly = True
        prodgrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        prodgrid.Size = New Size(752, 280)
        prodgrid.TabIndex = 2
        ' 
        ' newbttn
        ' 
        newbttn.BackColor = Color.FromArgb(CByte(128), CByte(255), CByte(128))
        newbttn.FlatStyle = FlatStyle.Flat
        newbttn.Location = New Point(56, 264)
        newbttn.Name = "newbttn"
        newbttn.Size = New Size(104, 40)
        newbttn.TabIndex = 3
        newbttn.Text = "New"
        newbttn.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(48, 32)
        Label1.Name = "Label1"
        Label1.Size = New Size(63, 15)
        Label1.TabIndex = 4
        Label1.Text = "Product ID"
        ' 
        ' dltbttn
        ' 
        dltbttn.BackColor = Color.Red
        dltbttn.FlatStyle = FlatStyle.Flat
        dltbttn.Location = New Point(200, 264)
        dltbttn.Name = "dltbttn"
        dltbttn.Size = New Size(104, 40)
        dltbttn.TabIndex = 5
        dltbttn.Text = "Delete"
        dltbttn.UseVisualStyleBackColor = False
        ' 
        ' updbttn
        ' 
        updbttn.Location = New Point(56, 336)
        updbttn.Name = "updbttn"
        updbttn.Size = New Size(104, 40)
        updbttn.TabIndex = 6
        updbttn.Text = "Update"
        updbttn.UseVisualStyleBackColor = True
        ' 
        ' clrtxt
        ' 
        clrtxt.Location = New Point(200, 336)
        clrtxt.Name = "clrtxt"
        clrtxt.Size = New Size(104, 40)
        clrtxt.TabIndex = 7
        clrtxt.Text = "Clear"
        clrtxt.UseVisualStyleBackColor = True
        ' 
        ' prodidtxt
        ' 
        prodidtxt.Location = New Point(128, 24)
        prodidtxt.Name = "prodidtxt"
        prodidtxt.Size = New Size(176, 23)
        prodidtxt.TabIndex = 11
        ' 
        ' itmnametxt
        ' 
        itmnametxt.Location = New Point(128, 64)
        itmnametxt.Name = "itmnametxt"
        itmnametxt.Size = New Size(176, 23)
        itmnametxt.TabIndex = 13
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(48, 72)
        Label2.Name = "Label2"
        Label2.Size = New Size(66, 15)
        Label2.TabIndex = 12
        Label2.Text = "Item Name"
        ' 
        ' desctxt
        ' 
        desctxt.Location = New Point(128, 104)
        desctxt.Name = "desctxt"
        desctxt.Size = New Size(176, 23)
        desctxt.TabIndex = 15
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(48, 112)
        Label3.Name = "Label3"
        Label3.Size = New Size(67, 15)
        Label3.TabIndex = 14
        Label3.Text = "Description"
        ' 
        ' pricetxt
        ' 
        pricetxt.Location = New Point(128, 184)
        pricetxt.Name = "pricetxt"
        pricetxt.Size = New Size(176, 23)
        pricetxt.TabIndex = 17
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(48, 192)
        Label4.Name = "Label4"
        Label4.Size = New Size(33, 15)
        Label4.TabIndex = 16
        Label4.Text = "Price"
        ' 
        ' stcktxt
        ' 
        stcktxt.Location = New Point(128, 224)
        stcktxt.Name = "stcktxt"
        stcktxt.Size = New Size(176, 23)
        stcktxt.TabIndex = 19
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(48, 232)
        Label5.Name = "Label5"
        Label5.Size = New Size(36, 15)
        Label5.TabIndex = 18
        Label5.Text = "Stock"
        ' 
        ' filtercmb
        ' 
        filtercmb.FormattingEnabled = True
        filtercmb.Location = New Point(344, 336)
        filtercmb.Name = "filtercmb"
        filtercmb.Size = New Size(121, 23)
        filtercmb.TabIndex = 20
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(32, 152)
        Label6.Name = "Label6"
        Label6.Size = New Size(90, 15)
        Label6.TabIndex = 21
        Label6.Text = "Category Name"
        ' 
        ' catcmb
        ' 
        catcmb.FormattingEnabled = True
        catcmb.Location = New Point(128, 144)
        catcmb.Name = "catcmb"
        catcmb.Size = New Size(121, 23)
        catcmb.TabIndex = 23
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(344, 312)
        Label7.Name = "Label7"
        Label7.Size = New Size(36, 15)
        Label7.TabIndex = 24
        Label7.Text = "Filter:"
        ' 
        ' adminproductform
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1200, 712)
        Controls.Add(Label7)
        Controls.Add(catcmb)
        Controls.Add(Label6)
        Controls.Add(filtercmb)
        Controls.Add(stcktxt)
        Controls.Add(Label5)
        Controls.Add(pricetxt)
        Controls.Add(Label4)
        Controls.Add(desctxt)
        Controls.Add(Label3)
        Controls.Add(itmnametxt)
        Controls.Add(Label2)
        Controls.Add(prodidtxt)
        Controls.Add(clrtxt)
        Controls.Add(updbttn)
        Controls.Add(dltbttn)
        Controls.Add(Label1)
        Controls.Add(newbttn)
        Controls.Add(prodgrid)
        FormBorderStyle = FormBorderStyle.None
        Name = "adminproductform"
        Text = "productform"
        CType(prodgrid, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents prodgrid As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents newbttn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents dltbttn As Button
    Friend WithEvents updbttn As Button
    Friend WithEvents clrtxt As Button
    Friend WithEvents prodidtxt As TextBox
    Friend WithEvents itmnametxt As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents desctxt As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents pricetxt As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents stcktxt As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents filtercmb As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents catcmb As ComboBox
    Friend WithEvents Label7 As Label
End Class
