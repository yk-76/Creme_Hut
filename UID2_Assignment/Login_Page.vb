Imports System.Data.OleDb
Imports System.Drawing.Drawing2D

Public Class Login_Page
    Private Sub Login_Page_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MakeRoundedButton(btnLogin)
        MakeRoundedButton(btnSignUp)
    End Sub

    Private Sub MakeRoundedButton(btn As Button)
        Dim path As New GraphicsPath()
        Dim radius As Integer = 60

        path.AddArc(0, 0, radius, radius, 180, 90)
        path.AddArc(btn.Width - radius, 0, radius, radius, 270, 90)
        path.AddArc(btn.Width - radius, btn.Height - radius, radius, radius, 0, 90)
        path.AddArc(0, btn.Height - radius, radius, radius, 90, 90)
        path.CloseFigure()

        btn.Region = New Region(path)
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\CakeHouseDatabase.accdb")
        Dim cmd As New OleDbCommand
        Dim sql As String
        Dim reader As OleDbDataReader

        If txtUsername.Text = "" Then
            MessageBox.Show("Username should not be blank! Please enter your username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf txtPassword.Text = "" Then
            MessageBox.Show("Password should not be blank! Please enter your password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        Try
            con.Open()

            sql = "SELECT * FROM [User] WHERE [Username] = '" & txtUsername.Text & "' AND [Password] = '" & txtPassword.Text & "'"
            cmd = New OleDbCommand(sql, con)
            reader = cmd.ExecuteReader()

            If reader.HasRows Then
                Dim MainPage As New Main_Page()
                MainPage.Show()
                Me.Hide()

            Else
                MessageBox.Show("Incorrect username or password. Please try again or contact the administrator immediately.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        ' Toggle password visibility
        If txtPassword.PasswordChar = "*"c Then
            txtPassword.PasswordChar = ControlChars.NullChar
        Else
            txtPassword.PasswordChar = "*"c
        End If
    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        txtPassword.PasswordChar = "*"c
    End Sub

    Private Sub btnSignUp_Click(sender As Object, e As EventArgs) Handles btnSignUp.Click
        Dim register As New Register_Page
        register.Show()
        Me.Hide()
    End Sub
End Class