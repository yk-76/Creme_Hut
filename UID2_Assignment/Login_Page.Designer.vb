<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login_Page
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
        Me.pnlLogin = New System.Windows.Forms.Panel()
        Me.btnView = New System.Windows.Forms.Button()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.picUsername = New System.Windows.Forms.PictureBox()
        Me.picLock = New System.Windows.Forms.PictureBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.lblSignIn = New System.Windows.Forms.Label()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.pnlSignUp = New System.Windows.Forms.Panel()
        Me.btnSignUp = New System.Windows.Forms.Button()
        Me.lblWelcomeMsg1 = New System.Windows.Forms.Label()
        Me.lblWelcomeMsg2 = New System.Windows.Forms.Label()
        Me.pnlLogin.SuspendLayout()
        CType(Me.picUsername, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSignUp.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlLogin
        '
        Me.pnlLogin.BackColor = System.Drawing.Color.SeaShell
        Me.pnlLogin.Controls.Add(Me.btnView)
        Me.pnlLogin.Controls.Add(Me.btnLogin)
        Me.pnlLogin.Controls.Add(Me.picUsername)
        Me.pnlLogin.Controls.Add(Me.picLock)
        Me.pnlLogin.Controls.Add(Me.txtPassword)
        Me.pnlLogin.Controls.Add(Me.txtUsername)
        Me.pnlLogin.Controls.Add(Me.lblSignIn)
        Me.pnlLogin.Controls.Add(Me.lblPassword)
        Me.pnlLogin.Controls.Add(Me.lblUsername)
        Me.pnlLogin.Location = New System.Drawing.Point(637, 0)
        Me.pnlLogin.Name = "pnlLogin"
        Me.pnlLogin.Size = New System.Drawing.Size(848, 754)
        Me.pnlLogin.TabIndex = 1
        '
        'btnView
        '
        Me.btnView.BackColor = System.Drawing.Color.Tomato
        Me.btnView.Font = New System.Drawing.Font("Verdana", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.Image = Global.UID2_Assignment.My.Resources.Resources.picEye
        Me.btnView.Location = New System.Drawing.Point(620, 419)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(79, 45)
        Me.btnView.TabIndex = 3
        Me.btnView.UseVisualStyleBackColor = False
        '
        'btnLogin
        '
        Me.btnLogin.BackColor = System.Drawing.Color.Coral
        Me.btnLogin.FlatAppearance.BorderSize = 0
        Me.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogin.Font = New System.Drawing.Font("Verdana", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogin.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnLogin.Location = New System.Drawing.Point(145, 554)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(554, 74)
        Me.btnLogin.TabIndex = 3
        Me.btnLogin.Text = "Login"
        Me.btnLogin.UseVisualStyleBackColor = False
        '
        'picUsername
        '
        Me.picUsername.Image = Global.UID2_Assignment.My.Resources.Resources.picProfile_80
        Me.picUsername.Location = New System.Drawing.Point(146, 248)
        Me.picUsername.Name = "picUsername"
        Me.picUsername.Size = New System.Drawing.Size(65, 60)
        Me.picUsername.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picUsername.TabIndex = 2
        Me.picUsername.TabStop = False
        '
        'picLock
        '
        Me.picLock.Image = Global.UID2_Assignment.My.Resources.Resources.picLock
        Me.picLock.Location = New System.Drawing.Point(145, 413)
        Me.picLock.Name = "picLock"
        Me.picLock.Size = New System.Drawing.Size(65, 60)
        Me.picLock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picLock.TabIndex = 2
        Me.picLock.TabStop = False
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Verdana", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(231, 422)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(383, 40)
        Me.txtPassword.TabIndex = 1
        '
        'txtUsername
        '
        Me.txtUsername.Font = New System.Drawing.Font("Verdana", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsername.Location = New System.Drawing.Point(231, 257)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(468, 40)
        Me.txtUsername.TabIndex = 1
        '
        'lblSignIn
        '
        Me.lblSignIn.AutoSize = True
        Me.lblSignIn.Font = New System.Drawing.Font("Verdana", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSignIn.ForeColor = System.Drawing.Color.Firebrick
        Me.lblSignIn.Location = New System.Drawing.Point(133, 84)
        Me.lblSignIn.Name = "lblSignIn"
        Me.lblSignIn.Size = New System.Drawing.Size(157, 41)
        Me.lblSignIn.TabIndex = 0
        Me.lblSignIn.Text = "Sign In"
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Font = New System.Drawing.Font("Arial Rounded MT Bold", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPassword.ForeColor = System.Drawing.Color.IndianRed
        Me.lblPassword.Location = New System.Drawing.Point(140, 360)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(153, 32)
        Me.lblPassword.TabIndex = 0
        Me.lblPassword.Text = "Password:"
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Font = New System.Drawing.Font("Arial Rounded MT Bold", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsername.ForeColor = System.Drawing.Color.IndianRed
        Me.lblUsername.Location = New System.Drawing.Point(139, 201)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(158, 32)
        Me.lblUsername.TabIndex = 0
        Me.lblUsername.Text = "Username:"
        '
        'pnlSignUp
        '
        Me.pnlSignUp.BackgroundImage = Global.UID2_Assignment.My.Resources.Resources.bgLogin
        Me.pnlSignUp.Controls.Add(Me.btnSignUp)
        Me.pnlSignUp.Controls.Add(Me.lblWelcomeMsg1)
        Me.pnlSignUp.Controls.Add(Me.lblWelcomeMsg2)
        Me.pnlSignUp.Location = New System.Drawing.Point(-2, 0)
        Me.pnlSignUp.Name = "pnlSignUp"
        Me.pnlSignUp.Size = New System.Drawing.Size(639, 754)
        Me.pnlSignUp.TabIndex = 0
        '
        'btnSignUp
        '
        Me.btnSignUp.BackColor = System.Drawing.Color.Tomato
        Me.btnSignUp.FlatAppearance.BorderSize = 0
        Me.btnSignUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSignUp.Font = New System.Drawing.Font("Verdana", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSignUp.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSignUp.Location = New System.Drawing.Point(84, 413)
        Me.btnSignUp.Name = "btnSignUp"
        Me.btnSignUp.Size = New System.Drawing.Size(451, 74)
        Me.btnSignUp.TabIndex = 3
        Me.btnSignUp.Text = "Sign Up"
        Me.btnSignUp.UseVisualStyleBackColor = False
        '
        'lblWelcomeMsg1
        '
        Me.lblWelcomeMsg1.AutoSize = True
        Me.lblWelcomeMsg1.BackColor = System.Drawing.Color.Transparent
        Me.lblWelcomeMsg1.Font = New System.Drawing.Font("Verdana", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWelcomeMsg1.ForeColor = System.Drawing.Color.White
        Me.lblWelcomeMsg1.Location = New System.Drawing.Point(77, 252)
        Me.lblWelcomeMsg1.Name = "lblWelcomeMsg1"
        Me.lblWelcomeMsg1.Size = New System.Drawing.Size(458, 41)
        Me.lblWelcomeMsg1.TabIndex = 0
        Me.lblWelcomeMsg1.Text = "Welcome to Creme Hut"
        '
        'lblWelcomeMsg2
        '
        Me.lblWelcomeMsg2.AutoSize = True
        Me.lblWelcomeMsg2.BackColor = System.Drawing.Color.Transparent
        Me.lblWelcomeMsg2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWelcomeMsg2.ForeColor = System.Drawing.Color.White
        Me.lblWelcomeMsg2.Location = New System.Drawing.Point(147, 322)
        Me.lblWelcomeMsg2.Name = "lblWelcomeMsg2"
        Me.lblWelcomeMsg2.Size = New System.Drawing.Size(319, 32)
        Me.lblWelcomeMsg2.TabIndex = 0
        Me.lblWelcomeMsg2.Text = "Don't have an account?"
        '
        'Login_Page
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1482, 753)
        Me.Controls.Add(Me.pnlSignUp)
        Me.Controls.Add(Me.pnlLogin)
        Me.Name = "Login_Page"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Creme Hut - Login Page"
        Me.pnlLogin.ResumeLayout(False)
        Me.pnlLogin.PerformLayout()
        CType(Me.picUsername, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSignUp.ResumeLayout(False)
        Me.pnlSignUp.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlSignUp As Panel
    Friend WithEvents pnlLogin As Panel
    Friend WithEvents picLock As PictureBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents lblSignIn As Label
    Friend WithEvents lblPassword As Label
    Friend WithEvents lblUsername As Label
    Friend WithEvents picUsername As PictureBox
    Friend WithEvents btnView As Button
    Friend WithEvents btnLogin As Button
    Friend WithEvents btnSignUp As Button
    Friend WithEvents lblWelcomeMsg1 As Label
    Friend WithEvents lblWelcomeMsg2 As Label
End Class
