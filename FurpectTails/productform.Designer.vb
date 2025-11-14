<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class productform
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
        catcmb = New ComboBox()
        searchprodtxt = New TextBox()
        proddg = New DataGridView()
        cartdg = New DataGridView()
        totallbl = New Label()
        addcartbtn = New Button()
        removebtn = New Button()
        checkoutbtn = New Button()
        paymentmethodcmb = New ComboBox()
        CType(proddg, ComponentModel.ISupportInitialize).BeginInit()
        CType(cartdg, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' catcmb
        ' 
        catcmb.FormattingEnabled = True
        catcmb.Location = New Point(456, 224)
        catcmb.Name = "catcmb"
        catcmb.Size = New Size(121, 23)
        catcmb.TabIndex = 0
        ' 
        ' searchprodtxt
        ' 
        searchprodtxt.Location = New Point(456, 32)
        searchprodtxt.Name = "searchprodtxt"
        searchprodtxt.Size = New Size(192, 23)
        searchprodtxt.TabIndex = 1
        ' 
        ' proddg
        ' 
        proddg.AllowUserToResizeColumns = False
        proddg.AllowUserToResizeRows = False
        proddg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        proddg.Location = New Point(456, 64)
        proddg.Name = "proddg"
        proddg.Size = New Size(488, 150)
        proddg.TabIndex = 2
        ' 
        ' cartdg
        ' 
        cartdg.AllowUserToResizeColumns = False
        cartdg.AllowUserToResizeRows = False
        cartdg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        cartdg.Location = New Point(456, 328)
        cartdg.Name = "cartdg"
        cartdg.Size = New Size(488, 150)
        cartdg.TabIndex = 3
        ' 
        ' totallbl
        ' 
        totallbl.AutoSize = True
        totallbl.Location = New Point(456, 488)
        totallbl.Name = "totallbl"
        totallbl.Size = New Size(41, 15)
        totallbl.TabIndex = 4
        totallbl.Text = "TOTAL"
        ' 
        ' addcartbtn
        ' 
        addcartbtn.Location = New Point(680, 224)
        addcartbtn.Name = "addcartbtn"
        addcartbtn.Size = New Size(75, 23)
        addcartbtn.TabIndex = 5
        addcartbtn.Text = "ADD"
        addcartbtn.UseVisualStyleBackColor = True
        ' 
        ' removebtn
        ' 
        removebtn.Location = New Point(848, 224)
        removebtn.Name = "removebtn"
        removebtn.Size = New Size(75, 23)
        removebtn.TabIndex = 6
        removebtn.Text = "REMOVE"
        removebtn.UseVisualStyleBackColor = True
        ' 
        ' checkoutbtn
        ' 
        checkoutbtn.Location = New Point(728, 488)
        checkoutbtn.Name = "checkoutbtn"
        checkoutbtn.Size = New Size(104, 23)
        checkoutbtn.TabIndex = 7
        checkoutbtn.Text = "CHECKOUT"
        checkoutbtn.UseVisualStyleBackColor = True
        ' 
        ' paymentmethodcmb
        ' 
        paymentmethodcmb.FormattingEnabled = True
        paymentmethodcmb.Location = New Point(456, 280)
        paymentmethodcmb.Name = "paymentmethodcmb"
        paymentmethodcmb.Size = New Size(121, 23)
        paymentmethodcmb.TabIndex = 8
        ' 
        ' productform
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1200, 712)
        Controls.Add(paymentmethodcmb)
        Controls.Add(checkoutbtn)
        Controls.Add(removebtn)
        Controls.Add(addcartbtn)
        Controls.Add(totallbl)
        Controls.Add(cartdg)
        Controls.Add(proddg)
        Controls.Add(searchprodtxt)
        Controls.Add(catcmb)
        FormBorderStyle = FormBorderStyle.None
        Name = "productform"
        Text = "productform"
        CType(proddg, ComponentModel.ISupportInitialize).EndInit()
        CType(cartdg, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents catcmb As ComboBox
    Friend WithEvents searchprodtxt As TextBox
    Friend WithEvents proddg As DataGridView
    Friend WithEvents cartdg As DataGridView
    Friend WithEvents totallbl As Label
    Friend WithEvents addcartbtn As Button
    Friend WithEvents removebtn As Button
    Friend WithEvents checkoutbtn As Button
    Friend WithEvents paymentmethodcmb As ComboBox
End Class
