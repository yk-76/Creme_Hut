Imports System.Data.OleDb


Public Class Register_Page
    Private Sub btnSignUp_Click(sender As Object, e As EventArgs) Handles btnSignUp.Click
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\CakeHouseDatabase.accdb")
        Dim cmd As New OleDbCommand
        Dim sql As String

        If txtUsername.Text = "" Then
            MessageBox.Show("Username should not be blank! Please enter your username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf txtFirstName.Text = "" Then
            MessageBox.Show("First name should not be blank! Please enter your first name. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf txtLastName.Text = "" Then
            MessageBox.Show("Last name should not be blank! Please enter your last name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf cmbGender.SelectedIndex = -1 Then
            MessageBox.Show("Please select your gender.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf txtEmail.text = "" Then
            MessageBox.Show("Email should not be blank! Please enter your email.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf Not txtEmail.Text.EndsWith("@gmail.com") Then
            MessageBox.Show("Invalid Email! Email be ends with @gmail.com like Example@gmail.com", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf txtPhoneNumber.Text = "" Then
            MessageBox.Show("Phone number should not be blank! Please enter your phone number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf Not IsNumeric(txtPhoneNumber.text) Then
            MessageBox.Show("Invalid phone number! Phone number must be in numeric form.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf Len(txtPhoneNumber.text) < 11 Or Len(txtPhoneNumber.text) > 11 Then
            MessageBox.Show("Invalid phone number! Phone number must be 11 numbers.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf txtPassword.Text <> txtConfirmPassword.Text Then
            MessageBox.Show("Passwords do not match. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf txtPassword.Text = "" Or txtConfirmPassword.Text = "" Then
            MessageBox.Show("Both password field do not blank. Please enter your password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf Len(txtPassword.Text) < 8 Then
            MessageBox.Show("Passwords must be at least 8 characters includes words and numeric numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Try
                con.Open()

                sql = "SELECT * FROM [User] WHERE [Username] = '" & txtUsername.Text & "'"
                cmd = New OleDbCommand(sql, con)
                Dim reader As OleDbDataReader = cmd.ExecuteReader()

                If reader.HasRows Then
                    MessageBox.Show("The username '" & txtUsername.Text & "' is already taken. Please choose a different one.", "Username Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    reader.Close()
                    Exit Sub
                End If
                reader.Close()

                sql = "INSERT INTO [User] ([Username], [FirstName], [LastName], [Gender],[Email], [PhoneNumber], [Password], [DateOfBirth]) " &
                      "VALUES ('" & txtUsername.Text & "', '" & txtFirstName.Text & "', '" & txtLastName.Text & "', '" &
                      cmbGender.SelectedItem.ToString() & "','" & txtEmail.Text & "', '" & txtPhoneNumber.Text & "', '" & txtPassword.Text & "', #" &
                      dtpDateOfBirth.Value.ToString("MM/dd/yyyy") & "#)"

                cmd = New OleDbCommand(sql, con)
                Dim i As Integer = cmd.ExecuteNonQuery()

                If i > 0 Then
                    MessageBox.Show("New user record added successfully!", "Added Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtUsername.Clear()
                    txtFirstName.Clear()
                    txtLastName.Clear()
                    cmbGender.SelectedIndex = -1
                    txtEmail.Clear()
                    txtPhoneNumber.Clear()
                    txtPassword.Clear()
                    txtConfirmPassword.Clear()
                    dtpDateOfBirth.Value = DateTime.Now
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                con.Close()
            End Try
        End If
    End Sub
    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        txtPassword.PasswordChar = "*"c
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Toggle password visibility
        If txtPassword.PasswordChar = "*"c Then
            txtPassword.PasswordChar = ControlChars.NullChar
        Else
            txtPassword.PasswordChar = "*"c
        End If
    End Sub

    Private Sub txtConfirmPassword_TextChanged(sender As Object, e As EventArgs) Handles txtConfirmPassword.TextChanged
        txtConfirmPassword.PasswordChar = "*"c
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Toggle password visibility
        If txtConfirmPassword.PasswordChar = "*"c Then
            txtConfirmPassword.PasswordChar = ControlChars.NullChar
        Else
            txtConfirmPassword.PasswordChar = "*"c
        End If
    End Sub

    Private Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click
        Dim login As New Login_Page()
        login.Show()
        Me.Close()
    End Sub
End Class