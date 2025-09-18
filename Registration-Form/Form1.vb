Imports System.Data.OleDb
Imports System.IO
Imports Windows.Win32.System

Public Class RegistrationForm
    Public ConnectionString As String
    Public CurrentUser As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim CurrentPath As String = Directory.GetCurrentDirectory()
        Dim DirInfo As New DirectoryInfo(CurrentPath)

        ' move 4 up para tumutok sa parent dir ng project
        For i As Integer = 1 To 4
            If DirInfo.Parent IsNot Nothing Then
                DirInfo = DirInfo.Parent
            Else
                Exit For
            End If
        Next

        ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & DirInfo.FullName & "\MSAccess\OOPact.accdb ;Persist Security Info=False;"
        LoadMunicipalityDB()
        'Form2.Show(Me)
    End Sub


    ' crud Functions
    Private Sub AddRecord(lname As String, fname As String, mname As String, suffix As String, sex As String, contactno As String, emailaddr As String, birthdate As String, address As String, municipality As String, postalCode As String)
        Dim conn As New OleDbConnection(ConnectionString)
        Dim cmd As OleDbCommand
        'Dim reader As OleDbDataReader

        Try
            conn.Open()
            Dim sql As String = "INSERT INTO Registration (LastName, FirstName, MiddleName, Suffix, Sex, ContactNo, EmailAddress, BirthDate, AddressIn, Municipality, PostalCode) VALUES (@lname, @fname, @mname, @suffix, @sex, @contactno, @email, @birthdate, @addr, @muni, @postc)"
            cmd = New OleDbCommand(sql, conn)
            cmd.Parameters.AddWithValue("@lname", lname)
            cmd.Parameters.AddWithValue("@fname", fname)
            cmd.Parameters.AddWithValue("@mname", mname)
            cmd.Parameters.AddWithValue("@suffix", suffix)
            cmd.Parameters.AddWithValue("@sex", sex)
            cmd.Parameters.AddWithValue("@contactno", contactno)
            cmd.Parameters.AddWithValue("@email", emailaddr)
            cmd.Parameters.AddWithValue("@birthdate", birthdate)
            cmd.Parameters.AddWithValue("@addr", address)
            cmd.Parameters.AddWithValue("@muni", municipality)
            cmd.Parameters.AddWithValue("@postc", postalCode)

            Dim result As Integer = cmd.ExecuteNonQuery()
            If result > 0 Then
                MessageBox.Show("Record Added Successfully!")
            Else
                MessageBox.Show("Failed to Add Record.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub LoadMunicipalityDB()
        Dim conn As New OleDbConnection(ConnectionString)
        Dim cmd As OleDbCommand
        Dim reader As OleDbDataReader

        Try
            conn.Open()
            Dim sql = "SELECT MunicipalityName FROM Table_municipality"
            cmd = New OleDbCommand(sql, conn)
            reader = cmd.ExecuteReader

            While reader.Read()
                Dim municipality As String = If(IsDBNull(reader("MunicipalityName")), "NULL", reader("MunicipalityName"))
                MunicipalityCmbBox.Items.Add(municipality)
            End While

        Catch ex As Exception
            MsgBox("Error connecting to database: " & ex.Message)
        End Try
    End Sub


    Private Sub LetterOnly_KeyPress(sender As Object, e As KeyPressEventArgs) Handles FirstNameTxtBox.KeyPress, SurnameTxtBox.KeyPress, MiddleNameTxtBox.KeyPress
        If Char.IsDigit(e.KeyChar) And Not Asc(e.KeyChar) = 8 Then
            e.Handled = True
        End If
    End Sub

    Private Sub NumberOnly_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ContactNoTxtBox.KeyPress, PostalCodeTxtBox.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Asc(e.KeyChar) = 8 Then
            e.Handled = True
        End If
    End Sub

    Private Sub ContactNoLimit(sender As Object, e As EventArgs) Handles ContactNoTxtBox.TextChanged
        If ContactNoTxtBox.TextLength >= 12 Then
            ContactNoTxtBox.Text = ContactNoTxtBox.Text.Remove(ContactNoTxtBox.TextLength - 1)
            ContactNoTxtBox.Select(ContactNoTxtBox.TextLength, 1)
        End If
    End Sub



    Private Sub RegisterBtn_Click(sender As Object, e As EventArgs) Handles RegisterBtn.Click
        If Not ValidateRequiredFields() Then
            Exit Sub
        End If

        Dim firstName = FirstNameTxtBox.Text
        Dim middleName = If((MiddleNameTxtBox.Text = ""), "N/A", MiddleNameTxtBox.Text)
        Dim surName = SurnameTxtBox.Text
        Dim suffix = If((SuffixCmbBox.Text = ""), "N/A", SuffixCmbBox.Text)
        Dim sex = SexCmbBox.Text

        Dim contactNo = ContactNoTxtBox.Text
        Dim emailAddr = If((EmailTxtBox.Text = ""), "N/A", EmailTxtBox.Text)

        Dim birthDate = DateTimePicker1.Value
        Dim birthDateFix = birthDate.ToString("M/d/yyyy")

        Dim address = AddressTxtBox.Text
        Dim municipality = MunicipalityCmbBox.Text
        Dim postalCode = If((PostalCodeTxtBox.Text = ""), "N/A", PostalCodeTxtBox.Text)

        AddRecord(surName, firstName, middleName, suffix, sex, contactNo, emailAddr, birthDateFix, address, municipality, postalCode)
    End Sub

    Private Sub ConfirmationChckBox_KeyDown(sender As Object, e As KeyEventArgs) Handles ConfirmationChckBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            If ConfirmationChckBox.Checked = False Then
                ConfirmationChckBox.Checked = True
            Else
                ConfirmationChckBox.Checked = False
            End If
        End If
    End Sub

    Private Function ValidateRequiredFields() As Boolean

        If String.IsNullOrWhiteSpace(FirstNameTxtBox.Text) Then
            MessageBox.Show("Name is required.")
            FirstNameTxtBox.Focus()
            Return False
        End If


        If String.IsNullOrWhiteSpace(SurnameTxtBox.Text) Then
            MessageBox.Show("Surname is required.")
            SurnameTxtBox.Focus()
            Return False
        End If

        If (ContactNoTxtBox.TextLength < 11) Then
            If String.IsNullOrWhiteSpace(ContactNoTxtBox.Text) Then
                MessageBox.Show("Contact No. is required.")
            Else
                MessageBox.Show("Contact No. is less than 11 digits.")
            End If
            ContactNoTxtBox.Focus()
            Return False
        End If

        If Not String.IsNullOrWhiteSpace(EmailTxtBox.Text) Then
            Dim atSignIndex = EmailTxtBox.Text.IndexOf("@")
            If (atSignIndex = -1) Then
                MessageBox.Show("E-Mail Address is invalid.")
                EmailTxtBox.Focus()
                Return False
            End If

            Dim lastPart As String = EmailTxtBox.Text.Substring(atSignIndex)
            If Not lastPart.Contains(".") Then
                MessageBox.Show("E-Mail Address is invalid.")
                EmailTxtBox.Focus()
                Return False
            End If
        End If

        If String.IsNullOrWhiteSpace(AddressTxtBox.Text) Then
            MessageBox.Show("Home Address is required.")
            AddressTxtBox.Focus()
            Return False
        End If

        If (SexCmbBox.SelectedIndex = -1) Or (String.IsNullOrWhiteSpace(SexCmbBox.Text)) Then
            MessageBox.Show("Sex is required.")
            SexCmbBox.Focus()
            Return False
        End If

        If Not ConfirmationChckBox.Checked Then
            MsgBox("Please confirm that all information above is correct.")
            ConfirmationChckBox.Focus()
            Return False
        End If

        If (MunicipalityCmbBox.SelectedIndex = -1) Or (String.IsNullOrWhiteSpace(MunicipalityCmbBox.Text)) Then
            MessageBox.Show("Municipality is required.")
            MunicipalityCmbBox.Focus()
            Return False
        End If

        Return True
    End Function

    'Doesn't handle anything?
    'Private Sub TextBox_KeyPress(sender As Object, e As KeyPressEventArgs)
    '    If Char.IsDigit(e.KeyChar) = "1" Then
    '        e.Handled = True
    '    End If
    'End Sub
End Class
