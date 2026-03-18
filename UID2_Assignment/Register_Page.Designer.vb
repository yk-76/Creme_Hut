<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Register_Page
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
        Me.pnlMiddle = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmbGender = New System.Windows.Forms.ComboBox()
        Me.dtpDateOfBirth = New System.Windows.Forms.DateTimePicker()
        Me.txtConfirmPassword = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtPhoneNumber = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.lblConfirmPassword = New System.Windows.Forms.Label()
        Me.lblDateOfBirth = New System.Windows.Forms.Label()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblPhoneNumber = New System.Windows.Forms.Label()
        Me.lblGender = New System.Windows.Forms.Label()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.lblLastName = New System.Windows.Forms.Label()
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.gbDescription = New System.Windows.Forms.GroupBox()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.btnReturn = New System.Windows.Forms.Button()
        Me.btnSignUp = New System.Windows.Forms.Button()
        Me.pnlTop = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlMiddle.SuspendLayout()
        Me.pnlBottom.SuspendLayout()
        Me.gbDescription.SuspendLayout()
        Me.pnlTop.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMiddle
        '
        Me.pnlMiddle.BackColor = System.Drawing.Color.SeaShell
        Me.pnlMiddle.Controls.Add(Me.Button2)
        Me.pnlMiddle.Controls.Add(Me.Button1)
        Me.pnlMiddle.Controls.Add(Me.cmbGender)
        Me.pnlMiddle.Controls.Add(Me.dtpDateOfBirth)
        Me.pnlMiddle.Controls.Add(Me.txtConfirmPassword)
        Me.pnlMiddle.Controls.Add(Me.txtPassword)
        Me.pnlMiddle.Controls.Add(Me.txtPhoneNumber)
        Me.pnlMiddle.Controls.Add(Me.txtEmail)
        Me.pnlMiddle.Controls.Add(Me.txtLastName)
        Me.pnlMiddle.Controls.Add(Me.txtUsername)
        Me.pnlMiddle.Controls.Add(Me.txtFirstName)
        Me.pnlMiddle.Controls.Add(Me.lblConfirmPassword)
        Me.pnlMiddle.Controls.Add(Me.lblDateOfBirth)
        Me.pnlMiddle.Controls.Add(Me.lblPassword)
        Me.pnlMiddle.Controls.Add(Me.lblEmail)
        Me.pnlMiddle.Controls.Add(Me.lblPhoneNumber)
        Me.pnlMiddle.Controls.Add(Me.lblGender)
        Me.pnlMiddle.Controls.Add(Me.lblUsername)
        Me.pnlMiddle.Controls.Add(Me.lblLastName)
        Me.pnlMiddle.Controls.Add(Me.lblFirstName)
        Me.pnlMiddle.Location = New System.Drawing.Point(0, 120)
        Me.pnlMiddle.Name = "pnlMiddle"
        Me.pnlMiddle.Size = New System.Drawing.Size(1487, 467)
        Me.pnlMiddle.TabIndex = 1
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Coral
        Me.Button2.BackgroundImage = Global.UID2_Assignment.My.Resources.Resources.picEye
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button2.Location = New System.Drawing.Point(1325, 289)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(71, 44)
        Me.Button2.TabIndex = 4
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Coral
        Me.Button1.BackgroundImage = Global.UID2_Assignment.My.Resources.Resources.picEye
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button1.Location = New System.Drawing.Point(1325, 205)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(71, 44)
        Me.Button1.TabIndex = 4
        Me.Button1.UseVisualStyleBackColor = False
        '
        'cmbGender
        '
        Me.cmbGender.Font = New System.Drawing.Font("Verdana", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbGender.FormattingEnabled = True
        Me.cmbGender.Items.AddRange(New Object() {"Male", "Female", "Other"})
        Me.cmbGender.Location = New System.Drawing.Point(289, 288)
        Me.cmbGender.Name = "cmbGender"
        Me.cmbGender.Size = New System.Drawing.Size(326, 40)
        Me.cmbGender.TabIndex = 3
        '
        'dtpDateOfBirth
        '
        Me.dtpDateOfBirth.Font = New System.Drawing.Font("Verdana", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateOfBirth.Location = New System.Drawing.Point(289, 370)
        Me.dtpDateOfBirth.Name = "dtpDateOfBirth"
        Me.dtpDateOfBirth.Size = New System.Drawing.Size(326, 40)
        Me.dtpDateOfBirth.TabIndex = 2
        '
        'txtConfirmPassword
        '
        Me.txtConfirmPassword.Font = New System.Drawing.Font("Verdana", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConfirmPassword.Location = New System.Drawing.Point(1004, 289)
        Me.txtConfirmPassword.Name = "txtConfirmPassword"
        Me.txtConfirmPassword.Size = New System.Drawing.Size(315, 40)
        Me.txtConfirmPassword.TabIndex = 1
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Verdana", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(1004, 205)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(315, 40)
        Me.txtPassword.TabIndex = 1
        '
        'txtPhoneNumber
        '
        Me.txtPhoneNumber.Font = New System.Drawing.Font("Verdana", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPhoneNumber.Location = New System.Drawing.Point(1004, 121)
        Me.txtPhoneNumber.Name = "txtPhoneNumber"
        Me.txtPhoneNumber.Size = New System.Drawing.Size(392, 40)
        Me.txtPhoneNumber.TabIndex = 1
        '
        'txtEmail
        '
        Me.txtEmail.Font = New System.Drawing.Font("Verdana", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(1004, 43)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(392, 40)
        Me.txtEmail.TabIndex = 1
        '
        'txtLastName
        '
        Me.txtLastName.Font = New System.Drawing.Font("Verdana", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastName.Location = New System.Drawing.Point(289, 204)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(326, 40)
        Me.txtLastName.TabIndex = 1
        '
        'txtUsername
        '
        Me.txtUsername.Font = New System.Drawing.Font("Verdana", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsername.Location = New System.Drawing.Point(289, 39)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(326, 40)
        Me.txtUsername.TabIndex = 1
        '
        'txtFirstName
        '
        Me.txtFirstName.Font = New System.Drawing.Font("Verdana", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFirstName.Location = New System.Drawing.Point(289, 120)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(326, 40)
        Me.txtFirstName.TabIndex = 1
        '
        'lblConfirmPassword
        '
        Me.lblConfirmPassword.AutoSize = True
        Me.lblConfirmPassword.Font = New System.Drawing.Font("Arial Rounded MT Bold", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConfirmPassword.Location = New System.Drawing.Point(709, 292)
        Me.lblConfirmPassword.Name = "lblConfirmPassword"
        Me.lblConfirmPassword.Size = New System.Drawing.Size(264, 32)
        Me.lblConfirmPassword.TabIndex = 0
        Me.lblConfirmPassword.Text = "Confirm Password:"
        '
        'lblDateOfBirth
        '
        Me.lblDateOfBirth.AutoSize = True
        Me.lblDateOfBirth.Font = New System.Drawing.Font("Arial Rounded MT Bold", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateOfBirth.Location = New System.Drawing.Point(63, 377)
        Me.lblDateOfBirth.Name = "lblDateOfBirth"
        Me.lblDateOfBirth.Size = New System.Drawing.Size(192, 32)
        Me.lblDateOfBirth.TabIndex = 0
        Me.lblDateOfBirth.Text = "Date Of Birth:"
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Font = New System.Drawing.Font("Arial Rounded MT Bold", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPassword.Location = New System.Drawing.Point(820, 210)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(153, 32)
        Me.lblPassword.TabIndex = 0
        Me.lblPassword.Text = "Password:"
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Font = New System.Drawing.Font("Arial Rounded MT Bold", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmail.Location = New System.Drawing.Point(879, 47)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(94, 32)
        Me.lblEmail.TabIndex = 0
        Me.lblEmail.Text = "Email:"
        '
        'lblPhoneNumber
        '
        Me.lblPhoneNumber.AutoSize = True
        Me.lblPhoneNumber.Font = New System.Drawing.Font("Arial Rounded MT Bold", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPhoneNumber.Location = New System.Drawing.Point(756, 125)
        Me.lblPhoneNumber.Name = "lblPhoneNumber"
        Me.lblPhoneNumber.Size = New System.Drawing.Size(217, 32)
        Me.lblPhoneNumber.TabIndex = 0
        Me.lblPhoneNumber.Text = "Phone Number:"
        '
        'lblGender
        '
        Me.lblGender.AutoSize = True
        Me.lblGender.Font = New System.Drawing.Font("Arial Rounded MT Bold", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGender.Location = New System.Drawing.Point(135, 293)
        Me.lblGender.Name = "lblGender"
        Me.lblGender.Size = New System.Drawing.Size(120, 32)
        Me.lblGender.TabIndex = 0
        Me.lblGender.Text = "Gender:"
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Font = New System.Drawing.Font("Arial Rounded MT Bold", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsername.Location = New System.Drawing.Point(97, 46)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(158, 32)
        Me.lblUsername.TabIndex = 0
        Me.lblUsername.Text = "Username:"
        '
        'lblLastName
        '
        Me.lblLastName.AutoSize = True
        Me.lblLastName.Font = New System.Drawing.Font("Arial Rounded MT Bold", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastName.Location = New System.Drawing.Point(92, 209)
        Me.lblLastName.Name = "lblLastName"
        Me.lblLastName.Size = New System.Drawing.Size(163, 32)
        Me.lblLastName.TabIndex = 0
        Me.lblLastName.Text = "Last Name:"
        '
        'lblFirstName
        '
        Me.lblFirstName.AutoSize = True
        Me.lblFirstName.Font = New System.Drawing.Font("Arial Rounded MT Bold", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFirstName.Location = New System.Drawing.Point(89, 125)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(166, 32)
        Me.lblFirstName.TabIndex = 0
        Me.lblFirstName.Text = "First Name:"
        '
        'pnlBottom
        '
        Me.pnlBottom.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.pnlBottom.Controls.Add(Me.gbDescription)
        Me.pnlBottom.Controls.Add(Me.btnReturn)
        Me.pnlBottom.Controls.Add(Me.btnSignUp)
        Me.pnlBottom.Location = New System.Drawing.Point(0, 587)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(1489, 170)
        Me.pnlBottom.TabIndex = 2
        '
        'gbDescription
        '
        Me.gbDescription.BackColor = System.Drawing.Color.OldLace
        Me.gbDescription.Controls.Add(Me.lblDescription)
        Me.gbDescription.Font = New System.Drawing.Font("Verdana", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDescription.ForeColor = System.Drawing.Color.Firebrick
        Me.gbDescription.Location = New System.Drawing.Point(74, 30)
        Me.gbDescription.Name = "gbDescription"
        Me.gbDescription.Size = New System.Drawing.Size(541, 114)
        Me.gbDescription.TabIndex = 1
        Me.gbDescription.TabStop = False
        Me.gbDescription.Text = "Welcome to Creme Hut Cake House" & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblDescription
        '
        Me.lblDescription.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.ForeColor = System.Drawing.Color.IndianRed
        Me.lblDescription.Location = New System.Drawing.Point(40, 45)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(473, 51)
        Me.lblDescription.TabIndex = 0
        Me.lblDescription.Text = """Delicious, handcrafted cakes made for every occasion. Sign up to start ordering " &
    "your favorites today!"""
        '
        'btnReturn
        '
        Me.btnReturn.BackColor = System.Drawing.Color.DarkGray
        Me.btnReturn.Font = New System.Drawing.Font("Verdana", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReturn.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnReturn.Location = New System.Drawing.Point(846, 50)
        Me.btnReturn.Name = "btnReturn"
        Me.btnReturn.Size = New System.Drawing.Size(283, 76)
        Me.btnReturn.TabIndex = 0
        Me.btnReturn.Text = "Return To Login"
        Me.btnReturn.UseVisualStyleBackColor = False
        '
        'btnSignUp
        '
        Me.btnSignUp.BackColor = System.Drawing.Color.LimeGreen
        Me.btnSignUp.Font = New System.Drawing.Font("Verdana", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSignUp.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSignUp.Location = New System.Drawing.Point(1158, 50)
        Me.btnSignUp.Name = "btnSignUp"
        Me.btnSignUp.Size = New System.Drawing.Size(283, 76)
        Me.btnSignUp.TabIndex = 0
        Me.btnSignUp.Text = "Sign Up"
        Me.btnSignUp.UseVisualStyleBackColor = False
        '
        'pnlTop
        '
        Me.pnlTop.BackColor = System.Drawing.Color.SandyBrown
        Me.pnlTop.Controls.Add(Me.lblTitle)
        Me.pnlTop.Location = New System.Drawing.Point(-2, -3)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(1489, 124)
        Me.pnlTop.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Verdana", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblTitle.Location = New System.Drawing.Point(480, 43)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(512, 41)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "ACCOUNT REGISTRATION"
        '
        'Register_Page
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1482, 753)
        Me.Controls.Add(Me.pnlTop)
        Me.Controls.Add(Me.pnlMiddle)
        Me.Controls.Add(Me.pnlBottom)
        Me.Name = "Register_Page"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Creme Hut - Register Page"
        Me.pnlMiddle.ResumeLayout(False)
        Me.pnlMiddle.PerformLayout()
        Me.pnlBottom.ResumeLayout(False)
        Me.gbDescription.ResumeLayout(False)
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTop As Panel
    Friend WithEvents pnlMiddle As Panel
    Friend WithEvents pnlBottom As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents cmbGender As ComboBox
    Friend WithEvents dtpDateOfBirth As DateTimePicker
    Friend WithEvents txtConfirmPassword As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtPhoneNumber As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents lblConfirmPassword As Label
    Friend WithEvents lblDateOfBirth As Label
    Friend WithEvents lblPassword As Label
    Friend WithEvents lblEmail As Label
    Friend WithEvents lblPhoneNumber As Label
    Friend WithEvents lblGender As Label
    Friend WithEvents lblLastName As Label
    Friend WithEvents lblFirstName As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents btnSignUp As Button
    Friend WithEvents gbDescription As GroupBox
    Friend WithEvents lblDescription As Label
    Friend WithEvents btnReturn As Button
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents lblUsername As Label
End Class
