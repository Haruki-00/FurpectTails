<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dailyreportform
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
        drtabs = New TabControl()
        reporttab = New TabPage()
        overalltotallbl = New Label()
        overallchartpanel = New Panel()
        prodtab = New TabPage()
        prodchartpanel = New Panel()
        prodtotallbl = New Label()
        proddg = New DataGridView()
        servtab = New TabPage()
        servchartpanel = New Panel()
        servtotallbl = New Label()
        servdg = New DataGridView()
        hoteltab = New TabPage()
        hotelchartpanel = New Panel()
        hoteltotallbl = New Label()
        hoteldg = New DataGridView()
        refbttn = New Button()
        drtabs.SuspendLayout()
        reporttab.SuspendLayout()
        prodtab.SuspendLayout()
        CType(proddg, ComponentModel.ISupportInitialize).BeginInit()
        servtab.SuspendLayout()
        CType(servdg, ComponentModel.ISupportInitialize).BeginInit()
        hoteltab.SuspendLayout()
        CType(hoteldg, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' drtabs
        ' 
        drtabs.Controls.Add(reporttab)
        drtabs.Controls.Add(prodtab)
        drtabs.Controls.Add(servtab)
        drtabs.Controls.Add(hoteltab)
        drtabs.Location = New Point(2, 4)
        drtabs.Name = "drtabs"
        drtabs.SelectedIndex = 0
        drtabs.Size = New Size(1200, 712)
        drtabs.TabIndex = 0
        ' 
        ' reporttab
        ' 
        reporttab.Controls.Add(refbttn)
        reporttab.Controls.Add(overalltotallbl)
        reporttab.Controls.Add(overallchartpanel)
        reporttab.Location = New Point(4, 24)
        reporttab.Name = "reporttab"
        reporttab.Padding = New Padding(3)
        reporttab.Size = New Size(1192, 684)
        reporttab.TabIndex = 3
        reporttab.Text = "REPORTS"
        reporttab.UseVisualStyleBackColor = True
        ' 
        ' overalltotallbl
        ' 
        overalltotallbl.AutoSize = True
        overalltotallbl.Font = New Font("Stencil", 39.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        overalltotallbl.Location = New Point(58, 548)
        overalltotallbl.Name = "overalltotallbl"
        overalltotallbl.Size = New Size(212, 63)
        overalltotallbl.TabIndex = 1
        overalltotallbl.Text = "Label1"
        ' 
        ' overallchartpanel
        ' 
        overallchartpanel.Location = New Point(18, 15)
        overallchartpanel.Name = "overallchartpanel"
        overallchartpanel.Size = New Size(1151, 483)
        overallchartpanel.TabIndex = 0
        ' 
        ' prodtab
        ' 
        prodtab.Controls.Add(prodchartpanel)
        prodtab.Controls.Add(prodtotallbl)
        prodtab.Controls.Add(proddg)
        prodtab.Location = New Point(4, 24)
        prodtab.Name = "prodtab"
        prodtab.Padding = New Padding(3)
        prodtab.Size = New Size(1192, 684)
        prodtab.TabIndex = 0
        prodtab.Text = "PRODUCT"
        prodtab.UseVisualStyleBackColor = True
        ' 
        ' prodchartpanel
        ' 
        prodchartpanel.Location = New Point(6, 325)
        prodchartpanel.Name = "prodchartpanel"
        prodchartpanel.Size = New Size(1177, 352)
        prodchartpanel.TabIndex = 3
        ' 
        ' prodtotallbl
        ' 
        prodtotallbl.AutoSize = True
        prodtotallbl.Font = New Font("Stencil", 39.75F)
        prodtotallbl.Location = New Point(6, 224)
        prodtotallbl.Name = "prodtotallbl"
        prodtotallbl.Size = New Size(212, 63)
        prodtotallbl.TabIndex = 1
        prodtotallbl.Text = "Label1"
        ' 
        ' proddg
        ' 
        proddg.AllowUserToResizeColumns = False
        proddg.AllowUserToResizeRows = False
        proddg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        proddg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        proddg.Location = New Point(3, 3)
        proddg.Name = "proddg"
        proddg.Size = New Size(1185, 183)
        proddg.TabIndex = 0
        ' 
        ' servtab
        ' 
        servtab.Controls.Add(servchartpanel)
        servtab.Controls.Add(servtotallbl)
        servtab.Controls.Add(servdg)
        servtab.Location = New Point(4, 24)
        servtab.Name = "servtab"
        servtab.Padding = New Padding(3)
        servtab.Size = New Size(1192, 684)
        servtab.TabIndex = 1
        servtab.Text = "GROOMING"
        servtab.UseVisualStyleBackColor = True
        ' 
        ' servchartpanel
        ' 
        servchartpanel.Location = New Point(6, 325)
        servchartpanel.Name = "servchartpanel"
        servchartpanel.Size = New Size(1177, 352)
        servchartpanel.TabIndex = 4
        ' 
        ' servtotallbl
        ' 
        servtotallbl.AutoSize = True
        servtotallbl.Font = New Font("Stencil", 39.75F)
        servtotallbl.Location = New Point(6, 224)
        servtotallbl.Name = "servtotallbl"
        servtotallbl.Size = New Size(212, 63)
        servtotallbl.TabIndex = 2
        servtotallbl.Text = "Label1"
        ' 
        ' servdg
        ' 
        servdg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        servdg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        servdg.Location = New Point(3, 3)
        servdg.Name = "servdg"
        servdg.Size = New Size(1185, 183)
        servdg.TabIndex = 1
        ' 
        ' hoteltab
        ' 
        hoteltab.Controls.Add(hotelchartpanel)
        hoteltab.Controls.Add(hoteltotallbl)
        hoteltab.Controls.Add(hoteldg)
        hoteltab.Location = New Point(4, 24)
        hoteltab.Name = "hoteltab"
        hoteltab.Padding = New Padding(3)
        hoteltab.Size = New Size(1192, 684)
        hoteltab.TabIndex = 2
        hoteltab.Text = "HOTEL"
        hoteltab.UseVisualStyleBackColor = True
        ' 
        ' hotelchartpanel
        ' 
        hotelchartpanel.Location = New Point(6, 325)
        hotelchartpanel.Name = "hotelchartpanel"
        hotelchartpanel.Size = New Size(1177, 352)
        hotelchartpanel.TabIndex = 4
        ' 
        ' hoteltotallbl
        ' 
        hoteltotallbl.AutoSize = True
        hoteltotallbl.Font = New Font("Stencil", 39.75F)
        hoteltotallbl.Location = New Point(6, 224)
        hoteltotallbl.Name = "hoteltotallbl"
        hoteltotallbl.Size = New Size(212, 63)
        hoteltotallbl.TabIndex = 2
        hoteltotallbl.Text = "Label1"
        ' 
        ' hoteldg
        ' 
        hoteldg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        hoteldg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        hoteldg.Location = New Point(3, 3)
        hoteldg.Name = "hoteldg"
        hoteldg.Size = New Size(1185, 183)
        hoteldg.TabIndex = 1
        ' 
        ' refbttn
        ' 
        refbttn.Location = New Point(64, 622)
        refbttn.Name = "refbttn"
        refbttn.Size = New Size(155, 43)
        refbttn.TabIndex = 3
        refbttn.Text = "Refresh"
        refbttn.UseVisualStyleBackColor = True
        ' 
        ' dailyreportform
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1200, 712)
        Controls.Add(drtabs)
        FormBorderStyle = FormBorderStyle.None
        Name = "dailyreportform"
        Text = "dailyreport"
        drtabs.ResumeLayout(False)
        reporttab.ResumeLayout(False)
        reporttab.PerformLayout()
        prodtab.ResumeLayout(False)
        prodtab.PerformLayout()
        CType(proddg, ComponentModel.ISupportInitialize).EndInit()
        servtab.ResumeLayout(False)
        servtab.PerformLayout()
        CType(servdg, ComponentModel.ISupportInitialize).EndInit()
        hoteltab.ResumeLayout(False)
        hoteltab.PerformLayout()
        CType(hoteldg, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents drtabs As TabControl
    Friend WithEvents prodtab As TabPage
    Friend WithEvents proddg As DataGridView
    Friend WithEvents servtab As TabPage
    Friend WithEvents hoteltab As TabPage
    Friend WithEvents prodtotallbl As Label
    Friend WithEvents servtotallbl As Label
    Friend WithEvents servdg As DataGridView
    Friend WithEvents hoteltotallbl As Label
    Friend WithEvents hoteldg As DataGridView
    Friend WithEvents prodchartpanel As Panel
    Friend WithEvents servchartpanel As Panel
    Friend WithEvents hotelchartpanel As Panel
    Friend WithEvents reporttab As TabPage
    Friend WithEvents overalltotallbl As Label
    Friend WithEvents overallchartpanel As Panel
    Friend WithEvents refbttn As Button
End Class
