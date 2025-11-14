<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class bookingform
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
        clientcmb = New ComboBox()
        petcmb = New ComboBox()
        startdtp = New DateTimePicker()
        enddtp = New DateTimePicker()
        paymentcmb = New ComboBox()
        savebtn = New Button()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        statuscmb = New ComboBox()
        Label6 = New Label()
        typecmb = New ComboBox()
        Label7 = New Label()
        cancelbtn = New Button()
        SuspendLayout()
        ' 
        ' clientcmb
        ' 
        clientcmb.FormattingEnabled = True
        clientcmb.Location = New Point(200, 56)
        clientcmb.Name = "clientcmb"
        clientcmb.Size = New Size(121, 23)
        clientcmb.TabIndex = 0
        ' 
        ' petcmb
        ' 
        petcmb.FormattingEnabled = True
        petcmb.Location = New Point(200, 96)
        petcmb.Name = "petcmb"
        petcmb.Size = New Size(121, 23)
        petcmb.TabIndex = 1
        ' 
        ' startdtp
        ' 
        startdtp.CustomFormat = "yyyy-MM-dd HH:mm"
        startdtp.Format = DateTimePickerFormat.Custom
        startdtp.Location = New Point(200, 144)
        startdtp.Name = "startdtp"
        startdtp.ShowUpDown = True
        startdtp.Size = New Size(160, 23)
        startdtp.TabIndex = 2
        ' 
        ' enddtp
        ' 
        enddtp.CustomFormat = "yyyy-MM-dd HH:mm"
        enddtp.Format = DateTimePickerFormat.Custom
        enddtp.Location = New Point(200, 184)
        enddtp.Name = "enddtp"
        enddtp.ShowUpDown = True
        enddtp.Size = New Size(160, 23)
        enddtp.TabIndex = 3
        ' 
        ' paymentcmb
        ' 
        paymentcmb.FormattingEnabled = True
        paymentcmb.Location = New Point(200, 224)
        paymentcmb.Name = "paymentcmb"
        paymentcmb.Size = New Size(121, 23)
        paymentcmb.TabIndex = 4
        ' 
        ' savebtn
        ' 
        savebtn.Location = New Point(224, 344)
        savebtn.Name = "savebtn"
        savebtn.Size = New Size(75, 23)
        savebtn.TabIndex = 5
        savebtn.Text = "Save"
        savebtn.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(144, 64)
        Label1.Name = "Label1"
        Label1.Size = New Size(38, 15)
        Label1.TabIndex = 6
        Label1.Text = "Client"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(152, 104)
        Label2.Name = "Label2"
        Label2.Size = New Size(24, 15)
        Label2.TabIndex = 7
        Label2.Text = "Pet"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(152, 152)
        Label3.Name = "Label3"
        Label3.Size = New Size(31, 15)
        Label3.TabIndex = 8
        Label3.Text = "Start"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(152, 192)
        Label4.Name = "Label4"
        Label4.Size = New Size(27, 15)
        Label4.TabIndex = 9
        Label4.Text = "End"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(128, 232)
        Label5.Name = "Label5"
        Label5.Size = New Size(54, 15)
        Label5.TabIndex = 10
        Label5.Text = "Payment"
        ' 
        ' statuscmb
        ' 
        statuscmb.FormattingEnabled = True
        statuscmb.Items.AddRange(New Object() {"Booked", "Completed"})
        statuscmb.Location = New Point(200, 264)
        statuscmb.Name = "statuscmb"
        statuscmb.Size = New Size(121, 23)
        statuscmb.TabIndex = 11
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(136, 272)
        Label6.Name = "Label6"
        Label6.Size = New Size(39, 15)
        Label6.TabIndex = 12
        Label6.Text = "Status"
        ' 
        ' typecmb
        ' 
        typecmb.FormattingEnabled = True
        typecmb.Items.AddRange(New Object() {"Booked", "Completed"})
        typecmb.Location = New Point(200, 304)
        typecmb.Name = "typecmb"
        typecmb.Size = New Size(121, 23)
        typecmb.TabIndex = 13
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(144, 312)
        Label7.Name = "Label7"
        Label7.Size = New Size(32, 15)
        Label7.TabIndex = 14
        Label7.Text = "Type"
        ' 
        ' cancelbtn
        ' 
        cancelbtn.BackColor = SystemColors.Control
        cancelbtn.Location = New Point(390, 326)
        cancelbtn.Name = "cancelbtn"
        cancelbtn.Size = New Size(75, 23)
        cancelbtn.TabIndex = 15
        cancelbtn.Text = "CANCEL"
        cancelbtn.UseVisualStyleBackColor = False
        ' 
        ' BookingForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(255), CByte(216), CByte(230))
        ClientSize = New Size(493, 386)
        Controls.Add(cancelbtn)
        Controls.Add(Label7)
        Controls.Add(typecmb)
        Controls.Add(Label6)
        Controls.Add(statuscmb)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(savebtn)
        Controls.Add(paymentcmb)
        Controls.Add(enddtp)
        Controls.Add(startdtp)
        Controls.Add(petcmb)
        Controls.Add(clientcmb)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Name = "BookingForm"
        Text = "bookingform"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents clientcmb As ComboBox
    Friend WithEvents petcmb As ComboBox
    Friend WithEvents startdtp As DateTimePicker
    Friend WithEvents enddtp As DateTimePicker
    Friend WithEvents paymentcmb As ComboBox
    Friend WithEvents savebtn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents statuscmb As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents typecmb As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cancelbtn As Button
End Class
