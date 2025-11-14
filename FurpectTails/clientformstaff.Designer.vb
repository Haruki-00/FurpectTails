<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class clientformstaff
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
        tabmain = New TabControl()
        Clients = New TabPage()
        Label23 = New Label()
        pettotalcounttxt = New TextBox()
        clrbtn = New Button()
        sbmtcstmrbtn = New Button()
        custidtxt = New TextBox()
        Label21 = New Label()
        lastnametxt = New TextBox()
        clientsavebtn = New Button()
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
        Pets = New TabPage()
        clrtbtn = New Button()
        petsearchtxt = New TextBox()
        Label22 = New Label()
        Label9 = New Label()
        Label8 = New Label()
        Label7 = New Label()
        petnametxt = New TextBox()
        clientownercmb = New ComboBox()
        petgendercmb = New ComboBox()
        speciescmb = New ComboBox()
        savepetbtn = New Button()
        petdg = New DataGridView()
        Label10 = New Label()
        Label11 = New Label()
        petagetxt = New TextBox()
        petbreedtxt = New TextBox()
        Label12 = New Label()
        Appointments = New TabPage()
        upddtbtn = New Button()
        upddt = New DateTimePicker()
        selsevdg = New DataGridView()
        newstatuscmb = New ComboBox()
        updstatusbtn = New Button()
        addservicebtn = New Button()
        Label16 = New Label()
        Label15 = New Label()
        Label14 = New Label()
        Label13 = New Label()
        appdg = New DataGridView()
        saveappbtn = New Button()
        statuscmb = New ComboBox()
        dateandtimedtp = New DateTimePicker()
        servicecmb = New ComboBox()
        petcmb = New ComboBox()
        Billing = New TabPage()
        Label24 = New Label()
        cashgiventxt = New TextBox()
        Label20 = New Label()
        Label19 = New Label()
        Label18 = New Label()
        paymentcmb = New ComboBox()
        billingdt = New DataGridView()
        savebillbtn = New Button()
        billdt = New DateTimePicker()
        totaltxt = New TextBox()
        appcmb = New ComboBox()
        Label17 = New Label()
        tabmain.SuspendLayout()
        Clients.SuspendLayout()
        CType(clientsdg, ComponentModel.ISupportInitialize).BeginInit()
        Pets.SuspendLayout()
        CType(petdg, ComponentModel.ISupportInitialize).BeginInit()
        Appointments.SuspendLayout()
        CType(selsevdg, ComponentModel.ISupportInitialize).BeginInit()
        CType(appdg, ComponentModel.ISupportInitialize).BeginInit()
        Billing.SuspendLayout()
        CType(billingdt, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' tabmain
        ' 
        tabmain.Controls.Add(Clients)
        tabmain.Controls.Add(Pets)
        tabmain.Controls.Add(Appointments)
        tabmain.Controls.Add(Billing)
        tabmain.ItemSize = New Size(70, 30)
        tabmain.Location = New Point(0, 0)
        tabmain.Name = "tabmain"
        tabmain.RightToLeft = RightToLeft.No
        tabmain.SelectedIndex = 0
        tabmain.Size = New Size(1200, 712)
        tabmain.TabIndex = 0
        ' 
        ' Clients
        ' 
        Clients.Controls.Add(Label23)
        Clients.Controls.Add(pettotalcounttxt)
        Clients.Controls.Add(clrbtn)
        Clients.Controls.Add(sbmtcstmrbtn)
        Clients.Controls.Add(custidtxt)
        Clients.Controls.Add(Label21)
        Clients.Controls.Add(lastnametxt)
        Clients.Controls.Add(clientsavebtn)
        Clients.Controls.Add(clientsdg)
        Clients.Controls.Add(Label6)
        Clients.Controls.Add(clientgendercmb)
        Clients.Controls.Add(numbertxt)
        Clients.Controls.Add(Label5)
        Clients.Controls.Add(Label4)
        Clients.Controls.Add(Label3)
        Clients.Controls.Add(Label2)
        Clients.Controls.Add(addresstxt)
        Clients.Controls.Add(midnametxt)
        Clients.Controls.Add(firstnametxt)
        Clients.Controls.Add(Label1)
        Clients.Location = New Point(4, 34)
        Clients.Name = "Clients"
        Clients.Padding = New Padding(3)
        Clients.Size = New Size(1192, 674)
        Clients.TabIndex = 0
        Clients.Text = "Clients"
        Clients.UseVisualStyleBackColor = True
        ' 
        ' Label23
        ' 
        Label23.AutoSize = True
        Label23.Location = New Point(80, 432)
        Label23.Name = "Label23"
        Label23.Size = New Size(60, 15)
        Label23.TabIndex = 20
        Label23.Text = "Pet Count"
        ' 
        ' pettotalcounttxt
        ' 
        pettotalcounttxt.Location = New Point(152, 424)
        pettotalcounttxt.Name = "pettotalcounttxt"
        pettotalcounttxt.ReadOnly = True
        pettotalcounttxt.Size = New Size(224, 23)
        pettotalcounttxt.TabIndex = 19
        ' 
        ' clrbtn
        ' 
        clrbtn.Location = New Point(208, 464)
        clrbtn.Name = "clrbtn"
        clrbtn.Size = New Size(75, 23)
        clrbtn.TabIndex = 18
        clrbtn.Text = "Clear"
        clrbtn.UseVisualStyleBackColor = True
        ' 
        ' sbmtcstmrbtn
        ' 
        sbmtcstmrbtn.Location = New Point(744, 408)
        sbmtcstmrbtn.Name = "sbmtcstmrbtn"
        sbmtcstmrbtn.Size = New Size(75, 23)
        sbmtcstmrbtn.TabIndex = 17
        sbmtcstmrbtn.Text = "Submit"
        sbmtcstmrbtn.UseVisualStyleBackColor = True
        ' 
        ' custidtxt
        ' 
        custidtxt.Location = New Point(512, 408)
        custidtxt.Name = "custidtxt"
        custidtxt.Size = New Size(224, 23)
        custidtxt.TabIndex = 16
        ' 
        ' Label21
        ' 
        Label21.AutoSize = True
        Label21.Location = New Point(440, 416)
        Label21.Name = "Label21"
        Label21.Size = New Size(73, 15)
        Label21.TabIndex = 15
        Label21.Text = "Customer ID"
        ' 
        ' lastnametxt
        ' 
        lastnametxt.Location = New Point(152, 136)
        lastnametxt.Name = "lastnametxt"
        lastnametxt.Size = New Size(224, 23)
        lastnametxt.TabIndex = 14
        ' 
        ' clientsavebtn
        ' 
        clientsavebtn.Location = New Point(304, 464)
        clientsavebtn.Name = "clientsavebtn"
        clientsavebtn.Size = New Size(75, 23)
        clientsavebtn.TabIndex = 13
        clientsavebtn.Text = "Save"
        clientsavebtn.UseVisualStyleBackColor = True
        ' 
        ' clientsdg
        ' 
        clientsdg.AllowUserToResizeColumns = False
        clientsdg.AllowUserToResizeRows = False
        clientsdg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        clientsdg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        clientsdg.Location = New Point(448, 136)
        clientsdg.Name = "clientsdg"
        clientsdg.ReadOnly = True
        clientsdg.Size = New Size(656, 256)
        clientsdg.TabIndex = 12
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(96, 376)
        Label6.Name = "Label6"
        Label6.Size = New Size(45, 15)
        Label6.TabIndex = 11
        Label6.Text = "Gender"
        ' 
        ' clientgendercmb
        ' 
        clientgendercmb.FormattingEnabled = True
        clientgendercmb.Items.AddRange(New Object() {"Male", "Female"})
        clientgendercmb.Location = New Point(152, 376)
        clientgendercmb.Name = "clientgendercmb"
        clientgendercmb.Size = New Size(224, 23)
        clientgendercmb.TabIndex = 10
        ' 
        ' numbertxt
        ' 
        numbertxt.Location = New Point(152, 328)
        numbertxt.Name = "numbertxt"
        numbertxt.Size = New Size(224, 23)
        numbertxt.TabIndex = 9
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(56, 336)
        Label5.Name = "Label5"
        Label5.Size = New Size(88, 15)
        Label5.TabIndex = 8
        Label5.Text = "Phone Number"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(96, 288)
        Label4.Name = "Label4"
        Label4.Size = New Size(49, 15)
        Label4.TabIndex = 7
        Label4.Text = "Address"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(64, 240)
        Label3.Name = "Label3"
        Label3.Size = New Size(79, 15)
        Label3.TabIndex = 6
        Label3.Text = "Middle Name"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(80, 192)
        Label2.Name = "Label2"
        Label2.Size = New Size(64, 15)
        Label2.TabIndex = 5
        Label2.Text = "First Name"
        ' 
        ' addresstxt
        ' 
        addresstxt.Location = New Point(152, 280)
        addresstxt.Name = "addresstxt"
        addresstxt.Size = New Size(224, 23)
        addresstxt.TabIndex = 4
        ' 
        ' midnametxt
        ' 
        midnametxt.Location = New Point(152, 232)
        midnametxt.Name = "midnametxt"
        midnametxt.Size = New Size(224, 23)
        midnametxt.TabIndex = 3
        ' 
        ' firstnametxt
        ' 
        firstnametxt.Location = New Point(152, 184)
        firstnametxt.Name = "firstnametxt"
        firstnametxt.Size = New Size(224, 23)
        firstnametxt.TabIndex = 2
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(80, 144)
        Label1.Name = "Label1"
        Label1.Size = New Size(63, 15)
        Label1.TabIndex = 0
        Label1.Text = "Last Name"
        ' 
        ' Pets
        ' 
        Pets.Controls.Add(clrtbtn)
        Pets.Controls.Add(petsearchtxt)
        Pets.Controls.Add(Label22)
        Pets.Controls.Add(Label9)
        Pets.Controls.Add(Label8)
        Pets.Controls.Add(Label7)
        Pets.Controls.Add(petnametxt)
        Pets.Controls.Add(clientownercmb)
        Pets.Controls.Add(petgendercmb)
        Pets.Controls.Add(speciescmb)
        Pets.Controls.Add(savepetbtn)
        Pets.Controls.Add(petdg)
        Pets.Controls.Add(Label10)
        Pets.Controls.Add(Label11)
        Pets.Controls.Add(petagetxt)
        Pets.Controls.Add(petbreedtxt)
        Pets.Controls.Add(Label12)
        Pets.Location = New Point(4, 34)
        Pets.Name = "Pets"
        Pets.Padding = New Padding(3)
        Pets.Size = New Size(1192, 674)
        Pets.TabIndex = 1
        Pets.Text = "Pets"
        Pets.UseVisualStyleBackColor = True
        ' 
        ' clrtbtn
        ' 
        clrtbtn.Location = New Point(184, 320)
        clrtbtn.Name = "clrtbtn"
        clrtbtn.Size = New Size(75, 23)
        clrtbtn.TabIndex = 37
        clrtbtn.Text = "Clear"
        clrtbtn.UseVisualStyleBackColor = True
        ' 
        ' petsearchtxt
        ' 
        petsearchtxt.Location = New Point(488, 352)
        petsearchtxt.Name = "petsearchtxt"
        petsearchtxt.Size = New Size(224, 23)
        petsearchtxt.TabIndex = 36
        ' 
        ' Label22
        ' 
        Label22.AutoSize = True
        Label22.Location = New Point(440, 360)
        Label22.Name = "Label22"
        Label22.Size = New Size(38, 15)
        Label22.TabIndex = 35
        Label22.Text = "Pet ID"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(64, 296)
        Label9.Name = "Label9"
        Label9.Size = New Size(42, 15)
        Label9.TabIndex = 34
        Label9.Text = "Owner"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(64, 248)
        Label8.Name = "Label8"
        Label8.Size = New Size(45, 15)
        Label8.TabIndex = 33
        Label8.Text = "Gender"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(64, 200)
        Label7.Name = "Label7"
        Label7.Size = New Size(46, 15)
        Label7.TabIndex = 32
        Label7.Text = "Species"
        ' 
        ' petnametxt
        ' 
        petnametxt.Location = New Point(128, 48)
        petnametxt.Name = "petnametxt"
        petnametxt.Size = New Size(224, 23)
        petnametxt.TabIndex = 31
        ' 
        ' clientownercmb
        ' 
        clientownercmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        clientownercmb.AutoCompleteSource = AutoCompleteSource.ListItems
        clientownercmb.FormattingEnabled = True
        clientownercmb.Location = New Point(128, 288)
        clientownercmb.Name = "clientownercmb"
        clientownercmb.Size = New Size(224, 23)
        clientownercmb.TabIndex = 30
        ' 
        ' petgendercmb
        ' 
        petgendercmb.FormattingEnabled = True
        petgendercmb.Items.AddRange(New Object() {"Male", "Female"})
        petgendercmb.Location = New Point(128, 240)
        petgendercmb.Name = "petgendercmb"
        petgendercmb.Size = New Size(224, 23)
        petgendercmb.TabIndex = 29
        ' 
        ' speciescmb
        ' 
        speciescmb.FormattingEnabled = True
        speciescmb.Items.AddRange(New Object() {"Dog", "Cat"})
        speciescmb.Location = New Point(128, 192)
        speciescmb.Name = "speciescmb"
        speciescmb.Size = New Size(224, 23)
        speciescmb.TabIndex = 28
        ' 
        ' savepetbtn
        ' 
        savepetbtn.Location = New Point(280, 320)
        savepetbtn.Name = "savepetbtn"
        savepetbtn.Size = New Size(75, 23)
        savepetbtn.TabIndex = 27
        savepetbtn.Text = "Save"
        savepetbtn.UseVisualStyleBackColor = True
        ' 
        ' petdg
        ' 
        petdg.AllowUserToResizeColumns = False
        petdg.AllowUserToResizeRows = False
        petdg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        petdg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        petdg.Location = New Point(64, 392)
        petdg.Name = "petdg"
        petdg.ReadOnly = True
        petdg.Size = New Size(928, 256)
        petdg.TabIndex = 26
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(64, 146)
        Label10.Name = "Label10"
        Label10.Size = New Size(48, 15)
        Label10.TabIndex = 20
        Label10.Text = "Pet Age"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Location = New Point(56, 98)
        Label11.Name = "Label11"
        Label11.Size = New Size(57, 15)
        Label11.TabIndex = 19
        Label11.Text = "Pet Breed"
        ' 
        ' petagetxt
        ' 
        petagetxt.Location = New Point(128, 138)
        petagetxt.Name = "petagetxt"
        petagetxt.Size = New Size(224, 23)
        petagetxt.TabIndex = 17
        ' 
        ' petbreedtxt
        ' 
        petbreedtxt.Location = New Point(128, 90)
        petbreedtxt.Name = "petbreedtxt"
        petbreedtxt.Size = New Size(224, 23)
        petbreedtxt.TabIndex = 16
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Location = New Point(56, 50)
        Label12.Name = "Label12"
        Label12.Size = New Size(59, 15)
        Label12.TabIndex = 14
        Label12.Text = "Pet Name"
        ' 
        ' Appointments
        ' 
        Appointments.Controls.Add(upddtbtn)
        Appointments.Controls.Add(upddt)
        Appointments.Controls.Add(selsevdg)
        Appointments.Controls.Add(newstatuscmb)
        Appointments.Controls.Add(updstatusbtn)
        Appointments.Controls.Add(addservicebtn)
        Appointments.Controls.Add(Label16)
        Appointments.Controls.Add(Label15)
        Appointments.Controls.Add(Label14)
        Appointments.Controls.Add(Label13)
        Appointments.Controls.Add(appdg)
        Appointments.Controls.Add(saveappbtn)
        Appointments.Controls.Add(statuscmb)
        Appointments.Controls.Add(dateandtimedtp)
        Appointments.Controls.Add(servicecmb)
        Appointments.Controls.Add(petcmb)
        Appointments.Location = New Point(4, 34)
        Appointments.Name = "Appointments"
        Appointments.Size = New Size(1192, 674)
        Appointments.TabIndex = 3
        Appointments.Text = "Appointments"
        Appointments.UseVisualStyleBackColor = True
        ' 
        ' upddtbtn
        ' 
        upddtbtn.Location = New Point(600, 568)
        upddtbtn.Name = "upddtbtn"
        upddtbtn.Size = New Size(80, 48)
        upddtbtn.TabIndex = 16
        upddtbtn.Text = "Update Date and Time"
        upddtbtn.UseVisualStyleBackColor = True
        ' 
        ' upddt
        ' 
        upddt.CustomFormat = "yyyy-MM-dd HH:mm"
        upddt.Format = DateTimePickerFormat.Custom
        upddt.Location = New Point(392, 576)
        upddt.Name = "upddt"
        upddt.ShowUpDown = True
        upddt.Size = New Size(200, 23)
        upddt.TabIndex = 15
        ' 
        ' selsevdg
        ' 
        selsevdg.AllowUserToAddRows = False
        selsevdg.AllowUserToDeleteRows = False
        selsevdg.AllowUserToResizeColumns = False
        selsevdg.AllowUserToResizeRows = False
        selsevdg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        selsevdg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        selsevdg.Location = New Point(416, 80)
        selsevdg.Name = "selsevdg"
        selsevdg.ReadOnly = True
        selsevdg.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        selsevdg.Size = New Size(384, 119)
        selsevdg.TabIndex = 14
        ' 
        ' newstatuscmb
        ' 
        newstatuscmb.FormattingEnabled = True
        newstatuscmb.Items.AddRange(New Object() {"Pending", "Still on Process", "Completed", "Canceled"})
        newstatuscmb.Location = New Point(392, 504)
        newstatuscmb.Name = "newstatuscmb"
        newstatuscmb.Size = New Size(200, 23)
        newstatuscmb.TabIndex = 13
        ' 
        ' updstatusbtn
        ' 
        updstatusbtn.Location = New Point(600, 496)
        updstatusbtn.Name = "updstatusbtn"
        updstatusbtn.Size = New Size(80, 48)
        updstatusbtn.TabIndex = 12
        updstatusbtn.Text = "Update Status"
        updstatusbtn.UseVisualStyleBackColor = True
        ' 
        ' addservicebtn
        ' 
        addservicebtn.Location = New Point(144, 256)
        addservicebtn.Name = "addservicebtn"
        addservicebtn.Size = New Size(104, 32)
        addservicebtn.TabIndex = 10
        addservicebtn.Text = "Add Service"
        addservicebtn.UseVisualStyleBackColor = True
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Location = New Point(88, 224)
        Label16.Name = "Label16"
        Label16.Size = New Size(39, 15)
        Label16.TabIndex = 9
        Label16.Text = "Status"
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Location = New Point(48, 176)
        Label15.Name = "Label15"
        Label15.Size = New Size(84, 15)
        Label15.TabIndex = 8
        Label15.Text = "Date and Time"
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Location = New Point(88, 128)
        Label14.Name = "Label14"
        Label14.Size = New Size(44, 15)
        Label14.TabIndex = 7
        Label14.Text = "Service"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Location = New Point(104, 80)
        Label13.Name = "Label13"
        Label13.Size = New Size(24, 15)
        Label13.TabIndex = 6
        Label13.Text = "Pet"
        ' 
        ' appdg
        ' 
        appdg.AllowUserToResizeColumns = False
        appdg.AllowUserToResizeRows = False
        appdg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        appdg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        appdg.Location = New Point(96, 336)
        appdg.Name = "appdg"
        appdg.ReadOnly = True
        appdg.Size = New Size(584, 144)
        appdg.TabIndex = 5
        ' 
        ' saveappbtn
        ' 
        saveappbtn.Location = New Point(272, 256)
        saveappbtn.Name = "saveappbtn"
        saveappbtn.Size = New Size(80, 32)
        saveappbtn.TabIndex = 4
        saveappbtn.Text = "Save"
        saveappbtn.UseVisualStyleBackColor = True
        ' 
        ' statuscmb
        ' 
        statuscmb.FormattingEnabled = True
        statuscmb.Items.AddRange(New Object() {"Pending", "Still on Process", "Success"})
        statuscmb.Location = New Point(144, 216)
        statuscmb.Name = "statuscmb"
        statuscmb.Size = New Size(200, 23)
        statuscmb.TabIndex = 3
        ' 
        ' dateandtimedtp
        ' 
        dateandtimedtp.CustomFormat = "yyyy-MM-dd HH:mm"
        dateandtimedtp.Format = DateTimePickerFormat.Custom
        dateandtimedtp.Location = New Point(144, 168)
        dateandtimedtp.Name = "dateandtimedtp"
        dateandtimedtp.ShowUpDown = True
        dateandtimedtp.Size = New Size(200, 23)
        dateandtimedtp.TabIndex = 2
        ' 
        ' servicecmb
        ' 
        servicecmb.FormattingEnabled = True
        servicecmb.Location = New Point(144, 120)
        servicecmb.Name = "servicecmb"
        servicecmb.Size = New Size(200, 23)
        servicecmb.TabIndex = 1
        ' 
        ' petcmb
        ' 
        petcmb.FormattingEnabled = True
        petcmb.Location = New Point(144, 72)
        petcmb.Name = "petcmb"
        petcmb.Size = New Size(200, 23)
        petcmb.TabIndex = 0
        ' 
        ' Billing
        ' 
        Billing.Controls.Add(Label24)
        Billing.Controls.Add(cashgiventxt)
        Billing.Controls.Add(Label20)
        Billing.Controls.Add(Label19)
        Billing.Controls.Add(Label18)
        Billing.Controls.Add(paymentcmb)
        Billing.Controls.Add(billingdt)
        Billing.Controls.Add(savebillbtn)
        Billing.Controls.Add(billdt)
        Billing.Controls.Add(totaltxt)
        Billing.Controls.Add(appcmb)
        Billing.Controls.Add(Label17)
        Billing.Location = New Point(4, 34)
        Billing.Name = "Billing"
        Billing.Size = New Size(1192, 674)
        Billing.TabIndex = 4
        Billing.Text = "Billing"
        Billing.UseVisualStyleBackColor = True
        ' 
        ' Label24
        ' 
        Label24.AutoSize = True
        Label24.Location = New Point(104, 272)
        Label24.Name = "Label24"
        Label24.Size = New Size(66, 15)
        Label24.TabIndex = 11
        Label24.Text = "Cash Given"
        ' 
        ' cashgiventxt
        ' 
        cashgiventxt.Location = New Point(184, 264)
        cashgiventxt.Name = "cashgiventxt"
        cashgiventxt.Size = New Size(152, 23)
        cashgiventxt.TabIndex = 10
        ' 
        ' Label20
        ' 
        Label20.AutoSize = True
        Label20.Location = New Point(136, 224)
        Label20.Name = "Label20"
        Label20.Size = New Size(33, 15)
        Label20.TabIndex = 9
        Label20.Text = "Total"
        ' 
        ' Label19
        ' 
        Label19.AutoSize = True
        Label19.Location = New Point(136, 176)
        Label19.Name = "Label19"
        Label19.Size = New Size(31, 15)
        Label19.TabIndex = 8
        Label19.Text = "Date"
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.Location = New Point(72, 128)
        Label18.Name = "Label18"
        Label18.Size = New Size(99, 15)
        Label18.TabIndex = 7
        Label18.Text = "Payment Method"
        ' 
        ' paymentcmb
        ' 
        paymentcmb.FormattingEnabled = True
        paymentcmb.Items.AddRange(New Object() {"Gcash", "Cash"})
        paymentcmb.Location = New Point(184, 120)
        paymentcmb.Name = "paymentcmb"
        paymentcmb.Size = New Size(200, 23)
        paymentcmb.TabIndex = 6
        ' 
        ' billingdt
        ' 
        billingdt.AllowUserToResizeColumns = False
        billingdt.AllowUserToResizeRows = False
        billingdt.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        billingdt.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        billingdt.ImeMode = ImeMode.On
        billingdt.Location = New Point(480, 72)
        billingdt.Name = "billingdt"
        billingdt.ReadOnly = True
        billingdt.Size = New Size(640, 150)
        billingdt.TabIndex = 5
        ' 
        ' savebillbtn
        ' 
        savebillbtn.Location = New Point(336, 320)
        savebillbtn.Name = "savebillbtn"
        savebillbtn.Size = New Size(75, 23)
        savebillbtn.TabIndex = 4
        savebillbtn.Text = "Save"
        savebillbtn.UseVisualStyleBackColor = True
        ' 
        ' billdt
        ' 
        billdt.CustomFormat = "yyyy-MM-dd HH:mm"
        billdt.Format = DateTimePickerFormat.Custom
        billdt.Location = New Point(184, 168)
        billdt.Name = "billdt"
        billdt.ShowUpDown = True
        billdt.Size = New Size(200, 23)
        billdt.TabIndex = 3
        ' 
        ' totaltxt
        ' 
        totaltxt.Location = New Point(184, 216)
        totaltxt.Name = "totaltxt"
        totaltxt.ReadOnly = True
        totaltxt.Size = New Size(152, 23)
        totaltxt.TabIndex = 2
        ' 
        ' appcmb
        ' 
        appcmb.FormattingEnabled = True
        appcmb.Location = New Point(184, 72)
        appcmb.Name = "appcmb"
        appcmb.Size = New Size(200, 23)
        appcmb.TabIndex = 1
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.Location = New Point(88, 80)
        Label17.Name = "Label17"
        Label17.Size = New Size(78, 15)
        Label17.TabIndex = 0
        Label17.Text = "Appointment"
        ' 
        ' clientformstaff
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1200, 712)
        Controls.Add(tabmain)
        FormBorderStyle = FormBorderStyle.None
        Name = "clientformstaff"
        Text = "clientformstaff"
        tabmain.ResumeLayout(False)
        Clients.ResumeLayout(False)
        Clients.PerformLayout()
        CType(clientsdg, ComponentModel.ISupportInitialize).EndInit()
        Pets.ResumeLayout(False)
        Pets.PerformLayout()
        CType(petdg, ComponentModel.ISupportInitialize).EndInit()
        Appointments.ResumeLayout(False)
        Appointments.PerformLayout()
        CType(selsevdg, ComponentModel.ISupportInitialize).EndInit()
        CType(appdg, ComponentModel.ISupportInitialize).EndInit()
        Billing.ResumeLayout(False)
        Billing.PerformLayout()
        CType(billingdt, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents tabmain As TabControl
    Friend WithEvents Clients As TabPage
    Friend WithEvents Pets As TabPage
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents addresstxt As TextBox
    Friend WithEvents midnametxt As TextBox
    Friend WithEvents firstnametxt As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Appointments As TabPage
    Friend WithEvents Billing As TabPage
    Friend WithEvents numbertxt As TextBox
    Friend WithEvents clientsavebtn As Button
    Friend WithEvents clientsdg As DataGridView
    Friend WithEvents Label6 As Label
    Friend WithEvents clientgendercmb As ComboBox
    Friend WithEvents savepetbtn As Button
    Friend WithEvents petdg As DataGridView
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents petagetxt As TextBox
    Friend WithEvents petbreedtxt As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents clientownercmb As ComboBox
    Friend WithEvents petgendercmb As ComboBox
    Friend WithEvents speciescmb As ComboBox
    Friend WithEvents petnametxt As TextBox
    Friend WithEvents lastnametxt As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents statuscmb As ComboBox
    Friend WithEvents dateandtimedtp As DateTimePicker
    Friend WithEvents servicecmb As ComboBox
    Friend WithEvents petcmb As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents appdg As DataGridView
    Friend WithEvents saveappbtn As Button
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents billingdt As DataGridView
    Friend WithEvents savebillbtn As Button
    Friend WithEvents billdt As DateTimePicker
    Friend WithEvents totaltxt As TextBox
    Friend WithEvents appcmb As ComboBox
    Friend WithEvents Label17 As Label
    Friend WithEvents addservicebtn As Button
    Friend WithEvents paymentcmb As ComboBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents custidtxt As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents sbmtcstmrbtn As Button
    Friend WithEvents clrbtn As Button
    Friend WithEvents petsearchtxt As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents clrtbtn As Button
    Friend WithEvents newstatuscmb As ComboBox
    Friend WithEvents updstatusbtn As Button
    Friend WithEvents pettotalcounttxt As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents cashgiventxt As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents selsevdg As DataGridView
    Friend WithEvents upddtbtn As Button
    Friend WithEvents upddt As DateTimePicker
End Class
