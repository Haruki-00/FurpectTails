<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class servicesformstaff
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
        servicesgrid = New DataGridView()
        cartgrid = New DataGridView()
        addcartbttn = New Button()
        chckbttn = New Button()
        totallbl = New Label()
        rnvbttn = New Button()
        CType(servicesgrid, ComponentModel.ISupportInitialize).BeginInit()
        CType(cartgrid, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' servicesgrid
        ' 
        servicesgrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        servicesgrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        servicesgrid.Location = New Point(24, 24)
        servicesgrid.Name = "servicesgrid"
        servicesgrid.Size = New Size(840, 224)
        servicesgrid.TabIndex = 0
        ' 
        ' cartgrid
        ' 
        cartgrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        cartgrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        cartgrid.Location = New Point(24, 304)
        cartgrid.Name = "cartgrid"
        cartgrid.Size = New Size(640, 256)
        cartgrid.TabIndex = 1
        ' 
        ' addcartbttn
        ' 
        addcartbttn.Location = New Point(656, 256)
        addcartbttn.Name = "addcartbttn"
        addcartbttn.Size = New Size(99, 40)
        addcartbttn.TabIndex = 2
        addcartbttn.Text = "Add"
        addcartbttn.UseVisualStyleBackColor = True
        ' 
        ' chckbttn
        ' 
        chckbttn.Location = New Point(568, 608)
        chckbttn.Name = "chckbttn"
        chckbttn.Size = New Size(99, 40)
        chckbttn.TabIndex = 4
        chckbttn.Text = "Check"
        chckbttn.UseVisualStyleBackColor = True
        ' 
        ' totallbl
        ' 
        totallbl.AutoSize = True
        totallbl.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        totallbl.Location = New Point(600, 568)
        totallbl.Name = "totallbl"
        totallbl.Size = New Size(57, 30)
        totallbl.TabIndex = 5
        totallbl.Text = "Total"
        ' 
        ' rnvbttn
        ' 
        rnvbttn.Location = New Point(768, 256)
        rnvbttn.Name = "rnvbttn"
        rnvbttn.Size = New Size(99, 40)
        rnvbttn.TabIndex = 6
        rnvbttn.Text = "Remove Item"
        rnvbttn.UseVisualStyleBackColor = True
        ' 
        ' servicesformstaff
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1200, 712)
        Controls.Add(rnvbttn)
        Controls.Add(totallbl)
        Controls.Add(chckbttn)
        Controls.Add(addcartbttn)
        Controls.Add(cartgrid)
        Controls.Add(servicesgrid)
        FormBorderStyle = FormBorderStyle.None
        Name = "servicesformstaff"
        Text = "servicesformstaff"
        CType(servicesgrid, ComponentModel.ISupportInitialize).EndInit()
        CType(cartgrid, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents servicesgrid As DataGridView
    Friend WithEvents cartgrid As DataGridView
    Friend WithEvents addcartbttn As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents chckbttn As Button
    Friend WithEvents totallbl As Label
    Friend WithEvents rnvbttn As Button
End Class
