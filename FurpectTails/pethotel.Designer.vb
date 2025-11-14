<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pethotel
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
        DogPanelContainer = New Panel()
        Label1 = New Label()
        dogflp = New FlowLayoutPanel()
        Panel1 = New Panel()
        CatPanelContainer = New Panel()
        Label2 = New Label()
        catflp = New FlowLayoutPanel()
        Panel3 = New Panel()
        unitflp = New FlowLayoutPanel()
        DogPanelContainer.SuspendLayout()
        CatPanelContainer.SuspendLayout()
        SuspendLayout()
        ' 
        ' DogPanelContainer
        ' 
        DogPanelContainer.Controls.Add(Label1)
        DogPanelContainer.Controls.Add(dogflp)
        DogPanelContainer.Controls.Add(Panel1)
        DogPanelContainer.Dock = DockStyle.Top
        DogPanelContainer.Location = New Point(0, 0)
        DogPanelContainer.Name = "DogPanelContainer"
        DogPanelContainer.Size = New Size(1200, 357)
        DogPanelContainer.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Stencil", 40F)
        Label1.Location = New Point(1, 4)
        Label1.Name = "Label1"
        Label1.Size = New Size(311, 64)
        Label1.TabIndex = 3
        Label1.Text = "DOG HOTEL"
        ' 
        ' dogflp
        ' 
        dogflp.AutoScroll = True
        dogflp.Dock = DockStyle.Bottom
        dogflp.Location = New Point(0, 70)
        dogflp.Name = "dogflp"
        dogflp.Size = New Size(1200, 287)
        dogflp.TabIndex = 2
        ' 
        ' Panel1
        ' 
        Panel1.Location = New Point(3, 356)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1200, 357)
        Panel1.TabIndex = 1
        ' 
        ' CatPanelContainer
        ' 
        CatPanelContainer.Controls.Add(Label2)
        CatPanelContainer.Controls.Add(catflp)
        CatPanelContainer.Controls.Add(Panel3)
        CatPanelContainer.Dock = DockStyle.Bottom
        CatPanelContainer.Location = New Point(0, 355)
        CatPanelContainer.Name = "CatPanelContainer"
        CatPanelContainer.Size = New Size(1200, 357)
        CatPanelContainer.TabIndex = 2
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Stencil", 40F)
        Label2.Location = New Point(0, 3)
        Label2.Name = "Label2"
        Label2.Size = New Size(306, 64)
        Label2.TabIndex = 4
        Label2.Text = "CAT HOTEL"
        ' 
        ' catflp
        ' 
        catflp.AutoScroll = True
        catflp.Dock = DockStyle.Bottom
        catflp.Location = New Point(0, 70)
        catflp.Name = "catflp"
        catflp.Size = New Size(1200, 287)
        catflp.TabIndex = 3
        ' 
        ' Panel3
        ' 
        Panel3.Location = New Point(3, 356)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(1200, 357)
        Panel3.TabIndex = 1
        ' 
        ' unitflp
        ' 
        unitflp.Dock = DockStyle.Fill
        unitflp.Location = New Point(0, 0)
        unitflp.Name = "unitflp"
        unitflp.Size = New Size(1200, 712)
        unitflp.TabIndex = 3
        ' 
        ' pethotel
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1200, 712)
        Controls.Add(CatPanelContainer)
        Controls.Add(DogPanelContainer)
        Controls.Add(unitflp)
        FormBorderStyle = FormBorderStyle.None
        Name = "pethotel"
        Text = "pethotel"
        DogPanelContainer.ResumeLayout(False)
        DogPanelContainer.PerformLayout()
        CatPanelContainer.ResumeLayout(False)
        CatPanelContainer.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents DogPanelContainer As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents dogflp As FlowLayoutPanel
    Friend WithEvents CatPanelContainer As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents catflp As FlowLayoutPanel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents unitflp As FlowLayoutPanel
End Class
