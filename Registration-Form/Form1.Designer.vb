<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RegistrationForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        FirstNameTxtBox = New TextBox()
        MiddleNameTxtBox = New TextBox()
        AddressTxtBox = New TextBox()
        SurnameTxtBox = New TextBox()
        FnameLbl = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        DateTimePicker1 = New DateTimePicker()
        Label1 = New Label()
        SuffixCmbBox = New ComboBox()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        SexCmbBox = New ComboBox()
        Label8 = New Label()
        ContactNoTxtBox = New TextBox()
        Label9 = New Label()
        EmailTxtBox = New TextBox()
        Label10 = New Label()
        Label11 = New Label()
        Label12 = New Label()
        Label13 = New Label()
        Label14 = New Label()
        Label15 = New Label()
        RegisterBtn = New Button()
        Label16 = New Label()
        MunicipalityCmbBox = New ComboBox()
        Label17 = New Label()
        Label18 = New Label()
        Label19 = New Label()
        PostalCodeTxtBox = New TextBox()
        Label20 = New Label()
        Panel1 = New Panel()
        Label22 = New Label()
        ConfirmationChckBox = New CheckBox()
        Label21 = New Label()
        Label23 = New Label()
        Label24 = New Label()
        ViewRecordBtn = New Button()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' FirstNameTxtBox
        ' 
        FirstNameTxtBox.Location = New Point(130, 84)
        FirstNameTxtBox.Margin = New Padding(3, 2, 3, 2)
        FirstNameTxtBox.Name = "FirstNameTxtBox"
        FirstNameTxtBox.Size = New Size(219, 23)
        FirstNameTxtBox.TabIndex = 0
        ' 
        ' MiddleNameTxtBox
        ' 
        MiddleNameTxtBox.Location = New Point(130, 130)
        MiddleNameTxtBox.Margin = New Padding(3, 2, 3, 2)
        MiddleNameTxtBox.Name = "MiddleNameTxtBox"
        MiddleNameTxtBox.Size = New Size(219, 23)
        MiddleNameTxtBox.TabIndex = 1
        ' 
        ' AddressTxtBox
        ' 
        AddressTxtBox.Location = New Point(130, 354)
        AddressTxtBox.Margin = New Padding(3, 2, 3, 2)
        AddressTxtBox.Name = "AddressTxtBox"
        AddressTxtBox.Size = New Size(534, 23)
        AddressTxtBox.TabIndex = 8
        ' 
        ' SurnameTxtBox
        ' 
        SurnameTxtBox.Location = New Point(130, 168)
        SurnameTxtBox.Margin = New Padding(3, 2, 3, 2)
        SurnameTxtBox.Name = "SurnameTxtBox"
        SurnameTxtBox.Size = New Size(219, 23)
        SurnameTxtBox.TabIndex = 2
        ' 
        ' FnameLbl
        ' 
        FnameLbl.AutoSize = True
        FnameLbl.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        FnameLbl.Location = New Point(53, 86)
        FnameLbl.Name = "FnameLbl"
        FnameLbl.Size = New Size(72, 17)
        FnameLbl.TabIndex = 4
        FnameLbl.Text = "First name"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        Label2.Location = New Point(37, 132)
        Label2.Name = "Label2"
        Label2.Size = New Size(87, 17)
        Label2.TabIndex = 5
        Label2.Text = "Middle name"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        Label3.Location = New Point(21, 355)
        Label3.Name = "Label3"
        Label3.Size = New Size(105, 17)
        Label3.TabIndex = 7
        Label3.Text = "Current address"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        Label4.Location = New Point(61, 170)
        Label4.Name = "Label4"
        Label4.Size = New Size(62, 17)
        Label4.TabIndex = 6
        Label4.Text = "Surname"
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.Location = New Point(130, 272)
        DateTimePicker1.Margin = New Padding(3, 2, 3, 2)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(220, 23)
        DateTimePicker1.TabIndex = 5
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        Label1.Location = New Point(60, 274)
        Label1.Name = "Label1"
        Label1.Size = New Size(68, 17)
        Label1.TabIndex = 9
        Label1.Text = "Birth date"
        ' 
        ' SuffixCmbBox
        ' 
        SuffixCmbBox.FormattingEnabled = True
        SuffixCmbBox.Items.AddRange(New Object() {"Jr.", "Sr.", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX"})
        SuffixCmbBox.Location = New Point(131, 219)
        SuffixCmbBox.Margin = New Padding(3, 2, 3, 2)
        SuffixCmbBox.Name = "SuffixCmbBox"
        SuffixCmbBox.Size = New Size(98, 23)
        SuffixCmbBox.TabIndex = 3
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        Label5.Location = New Point(85, 222)
        Label5.Name = "Label5"
        Label5.Size = New Size(41, 17)
        Label5.TabIndex = 11
        Label5.Text = "Suffix"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(131, 14)
        Label6.Name = "Label6"
        Label6.Size = New Size(165, 25)
        Label6.TabIndex = 12
        Label6.Text = "Registration Form"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 10F)
        Label7.Location = New Point(242, 220)
        Label7.Name = "Label7"
        Label7.Size = New Size(29, 19)
        Label7.TabIndex = 14
        Label7.Text = "Sex"
        ' 
        ' SexCmbBox
        ' 
        SexCmbBox.FormattingEnabled = True
        SexCmbBox.Items.AddRange(New Object() {"Male", "Female"})
        SexCmbBox.Location = New Point(275, 219)
        SexCmbBox.Margin = New Padding(3, 2, 3, 2)
        SexCmbBox.Name = "SexCmbBox"
        SexCmbBox.Size = New Size(98, 23)
        SexCmbBox.TabIndex = 4
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        Label8.Location = New Point(375, 85)
        Label8.Name = "Label8"
        Label8.Size = New Size(80, 17)
        Label8.TabIndex = 16
        Label8.Text = "Contact No."
        ' 
        ' ContactNoTxtBox
        ' 
        ContactNoTxtBox.Location = New Point(462, 84)
        ContactNoTxtBox.Margin = New Padding(3, 2, 3, 2)
        ContactNoTxtBox.Name = "ContactNoTxtBox"
        ContactNoTxtBox.Size = New Size(219, 23)
        ContactNoTxtBox.TabIndex = 6
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        Label9.Location = New Point(365, 131)
        Label9.Name = "Label9"
        Label9.Size = New Size(91, 17)
        Label9.TabIndex = 18
        Label9.Text = "Email address"
        ' 
        ' EmailTxtBox
        ' 
        EmailTxtBox.Location = New Point(462, 131)
        EmailTxtBox.Margin = New Padding(3, 2, 3, 2)
        EmailTxtBox.Name = "EmailTxtBox"
        EmailTxtBox.Size = New Size(219, 23)
        EmailTxtBox.TabIndex = 7
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Segoe UI Semibold", 7.8F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Label10.ForeColor = Color.Firebrick
        Label10.Location = New Point(131, 193)
        Label10.Name = "Label10"
        Label10.Size = New Size(51, 13)
        Label10.TabIndex = 19
        Label10.Text = "Required"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Segoe UI Semibold", 7.8F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Label11.ForeColor = Color.Firebrick
        Label11.Location = New Point(275, 245)
        Label11.Name = "Label11"
        Label11.Size = New Size(51, 13)
        Label11.TabIndex = 20
        Label11.Text = "Required"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Segoe UI Semibold", 7.8F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Label12.ForeColor = Color.Firebrick
        Label12.Location = New Point(131, 295)
        Label12.Name = "Label12"
        Label12.Size = New Size(51, 13)
        Label12.TabIndex = 21
        Label12.Text = "Required"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Segoe UI Semibold", 7.8F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Label13.ForeColor = Color.Firebrick
        Label13.Location = New Point(462, 109)
        Label13.Name = "Label13"
        Label13.Size = New Size(51, 13)
        Label13.TabIndex = 22
        Label13.Text = "Required"
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Font = New Font("Segoe UI Semibold", 7.8F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Label14.ForeColor = Color.Firebrick
        Label14.Location = New Point(131, 109)
        Label14.Name = "Label14"
        Label14.Size = New Size(51, 13)
        Label14.TabIndex = 23
        Label14.Text = "Required"
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Font = New Font("Segoe UI Semibold", 7.8F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Label15.ForeColor = Color.Firebrick
        Label15.Location = New Point(130, 379)
        Label15.Name = "Label15"
        Label15.Size = New Size(51, 13)
        Label15.TabIndex = 24
        Label15.Text = "Required"
        ' 
        ' RegisterBtn
        ' 
        RegisterBtn.BackColor = Color.LimeGreen
        RegisterBtn.FlatAppearance.BorderSize = 0
        RegisterBtn.FlatStyle = FlatStyle.Flat
        RegisterBtn.Location = New Point(591, 472)
        RegisterBtn.Name = "RegisterBtn"
        RegisterBtn.Size = New Size(107, 37)
        RegisterBtn.TabIndex = 12
        RegisterBtn.Text = "Register"
        RegisterBtn.UseVisualStyleBackColor = False
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Location = New Point(84, 410)
        Label16.Name = "Label16"
        Label16.Size = New Size(0, 15)
        Label16.TabIndex = 27
        ' 
        ' MunicipalityCmbBox
        ' 
        MunicipalityCmbBox.FormattingEnabled = True
        MunicipalityCmbBox.Location = New Point(130, 407)
        MunicipalityCmbBox.Margin = New Padding(3, 2, 3, 2)
        MunicipalityCmbBox.Name = "MunicipalityCmbBox"
        MunicipalityCmbBox.Size = New Size(157, 23)
        MunicipalityCmbBox.TabIndex = 9
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        Label17.Location = New Point(42, 408)
        Label17.Name = "Label17"
        Label17.Size = New Size(81, 17)
        Label17.TabIndex = 28
        Label17.Text = "Municipality"
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        Label18.Location = New Point(314, 408)
        Label18.Name = "Label18"
        Label18.Size = New Size(76, 17)
        Label18.TabIndex = 31
        Label18.Text = "PostalCode"
        ' 
        ' Label19
        ' 
        Label19.AutoSize = True
        Label19.Location = New Point(371, 410)
        Label19.Name = "Label19"
        Label19.Size = New Size(0, 15)
        Label19.TabIndex = 30
        ' 
        ' PostalCodeTxtBox
        ' 
        PostalCodeTxtBox.Location = New Point(397, 407)
        PostalCodeTxtBox.Margin = New Padding(3, 2, 3, 2)
        PostalCodeTxtBox.Name = "PostalCodeTxtBox"
        PostalCodeTxtBox.Size = New Size(79, 23)
        PostalCodeTxtBox.TabIndex = 10
        ' 
        ' Label20
        ' 
        Label20.AutoSize = True
        Label20.Font = New Font("Segoe UI Semibold", 7.8F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Label20.ForeColor = Color.Firebrick
        Label20.Location = New Point(131, 432)
        Label20.Name = "Label20"
        Label20.Size = New Size(51, 13)
        Label20.TabIndex = 33
        Label20.Text = "Required"
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.MediumAquamarine
        Panel1.Controls.Add(ViewRecordBtn)
        Panel1.Controls.Add(Label22)
        Panel1.Controls.Add(Label6)
        Panel1.Location = New Point(-1, -1)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(731, 54)
        Panel1.TabIndex = 34
        ' 
        ' Label22
        ' 
        Label22.AutoSize = True
        Label22.Font = New Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label22.Location = New Point(13, 14)
        Label22.Name = "Label22"
        Label22.Size = New Size(117, 25)
        Label22.TabIndex = 13
        Label22.Text = "Barangay ID"
        ' 
        ' ConfirmationChckBox
        ' 
        ConfirmationChckBox.AutoSize = True
        ConfirmationChckBox.Font = New Font("Segoe UI", 9.75F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        ConfirmationChckBox.Location = New Point(257, 472)
        ConfirmationChckBox.Name = "ConfirmationChckBox"
        ConfirmationChckBox.Size = New Size(328, 21)
        ConfirmationChckBox.TabIndex = 11
        ConfirmationChckBox.Text = "I confirm that all details above is correct and accurate"
        ConfirmationChckBox.UseVisualStyleBackColor = True
        ' 
        ' Label21
        ' 
        Label21.AutoSize = True
        Label21.Font = New Font("Segoe UI Semibold", 7.8F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Label21.ForeColor = Color.Firebrick
        Label21.Location = New Point(275, 496)
        Label21.Name = "Label21"
        Label21.Size = New Size(51, 13)
        Label21.TabIndex = 36
        Label21.Text = "Required"
        ' 
        ' Label23
        ' 
        Label23.AutoSize = True
        Label23.Font = New Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Label23.ForeColor = SystemColors.ControlDarkDark
        Label23.Location = New Point(130, 337)
        Label23.Name = "Label23"
        Label23.Size = New Size(49, 15)
        Label23.TabIndex = 37
        Label23.Text = "Blck/Lot"
        ' 
        ' Label24
        ' 
        Label24.AutoSize = True
        Label24.Font = New Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Label24.ForeColor = SystemColors.ControlDarkDark
        Label24.Location = New Point(210, 337)
        Label24.Name = "Label24"
        Label24.Size = New Size(70, 15)
        Label24.TabIndex = 38
        Label24.Text = "Street name"
        ' 
        ' ViewRecordBtn
        ' 
        ViewRecordBtn.BackColor = Color.Orange
        ViewRecordBtn.FlatAppearance.BorderSize = 0
        ViewRecordBtn.FlatStyle = FlatStyle.Flat
        ViewRecordBtn.Location = New Point(592, 12)
        ViewRecordBtn.Name = "ViewRecordBtn"
        ViewRecordBtn.Size = New Size(127, 35)
        ViewRecordBtn.TabIndex = 14
        ViewRecordBtn.Text = "View records"
        ViewRecordBtn.UseVisualStyleBackColor = False
        ' 
        ' RegistrationForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        BackColor = SystemColors.ControlLight
        ClientSize = New Size(730, 523)
        Controls.Add(Label24)
        Controls.Add(Label23)
        Controls.Add(Label21)
        Controls.Add(ConfirmationChckBox)
        Controls.Add(Panel1)
        Controls.Add(Label20)
        Controls.Add(PostalCodeTxtBox)
        Controls.Add(Label18)
        Controls.Add(Label19)
        Controls.Add(Label17)
        Controls.Add(Label16)
        Controls.Add(MunicipalityCmbBox)
        Controls.Add(RegisterBtn)
        Controls.Add(Label15)
        Controls.Add(Label14)
        Controls.Add(Label13)
        Controls.Add(Label12)
        Controls.Add(Label11)
        Controls.Add(Label10)
        Controls.Add(Label9)
        Controls.Add(EmailTxtBox)
        Controls.Add(Label8)
        Controls.Add(ContactNoTxtBox)
        Controls.Add(Label7)
        Controls.Add(SexCmbBox)
        Controls.Add(Label5)
        Controls.Add(SuffixCmbBox)
        Controls.Add(Label1)
        Controls.Add(DateTimePicker1)
        Controls.Add(Label3)
        Controls.Add(Label4)
        Controls.Add(Label2)
        Controls.Add(FnameLbl)
        Controls.Add(AddressTxtBox)
        Controls.Add(SurnameTxtBox)
        Controls.Add(MiddleNameTxtBox)
        Controls.Add(FirstNameTxtBox)
        Name = "RegistrationForm"
        Text = "Registration Form"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents FirstNameTxtBox As TextBox
    Friend WithEvents MiddleNameTxtBox As TextBox
    Friend WithEvents AddressTxtBox As TextBox
    Friend WithEvents SurnameTxtBox As TextBox
    Friend WithEvents FnameLbl As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents SuffixCmbBox As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents SexCmbBox As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents ContactNoTxtBox As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents EmailTxtBox As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents RegisterBtn As Button
    Friend WithEvents Label16 As Label
    Friend WithEvents MunicipalityCmbBox As ComboBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents PostalCodeTxtBox As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents ConfirmationChckBox As CheckBox
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents ViewRecordBtn As Button

End Class
