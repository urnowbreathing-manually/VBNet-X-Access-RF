Imports System.Data.Common
Imports System.Data.OleDb
Imports System.IO
Imports System.Runtime
Imports Windows.Win32.System
Public Class Form2
    Dim ConnectionString As String
    Dim CurrentUser As String

    Private Sub LoadMunicipalityDB()
        Dim conn As New OleDbConnection(ConnectionString)
        Dim cmd As OleDbCommand
        Dim reader As OleDbDataReader

        Try
            conn.Open()
            Dim sql = "SELECT MunicipalityName FROM Table_municipality ORDER BY MunicipalityName ASC"
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

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles Me.Load
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

        LoadRegistrationDB()
        LoadMunicipalityDB()

        DataGridView1.AllowUserToAddRows = False
        DataGridView1.Columns(0).Width = 20

        If String.IsNullOrWhiteSpace(IdTxtBox.Text) Then
            Panel1.Enabled = False
        End If
    End Sub

    Private Sub UpdateRow(rowIndex As Integer, columnName As String, newValue As String)
        Dim sql As String = "UPDATE Registration SET [" & columnName & "] = @newVal WHERE ID = @id"
        Dim dbConnection As New OleDbConnection
        dbConnection = New OleDbConnection(ConnectionString)
        Dim cmd As OleDbCommand

        'MsgBox("Row index: " + rowIndex.ToString + " Column name: " + columnName + " new value: " + newValue)
        'MsgBox(sql)

        Try
            dbConnection.Open()
            cmd = New OleDbCommand(sql, dbConnection)
            cmd.Parameters.AddWithValue("@newVal", newValue)
            cmd.Parameters.AddWithValue("@id", rowIndex)
            Dim res = cmd.ExecuteNonQuery()

            If res > 0 Then
                MsgBox("Successfully saved update")
            Else
                MsgBox("Error on update")
            End If
        Catch ex As Exception
            MsgBox("Failed to save update: " + ex.ToString)
        End Try


    End Sub

    Private Sub LoadRegistrationDB()
        Dim sql As String = "SELECT * FROM Registration ORDER BY ID ASC"
        Dim dbConnection As OleDbConnection
        Dim dbCommand As New OleDbCommand
        Dim dbDataTable As New DataTable
        Dim dbDataAdapter As New OleDbDataAdapter

        dbConnection = New OleDbConnection(ConnectionString)

        Try
            dbConnection.Open()
            dbCommand.Connection = dbConnection
            dbCommand = New OleDbCommand(sql, dbConnection)

            dbDataAdapter.SelectCommand = dbCommand
            dbDataAdapter.Fill(dbDataTable)

            DataGridView1.DataSource = dbDataTable
            dbConnection.Close()
        Catch ex As Exception
            MsgBox("Error connecting to database: " & ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

        For Each cell As DataGridViewCell In row.Cells
            If cell.ColumnIndex = 0 Then
                IdTxtBox.Text = cell.Value.ToString
            ElseIf cell.ColumnIndex = 1 Then   'surname
                SurnameTxtBox.Text = cell.Value.ToString
            ElseIf cell.ColumnIndex = 2 Then   'first name
                FirstNameTxtBox.Text = cell.Value.ToString
            ElseIf cell.ColumnIndex = 3 Then   'middle name
                MiddleNameTxtBox.Text = cell.Value.ToString
            ElseIf cell.ColumnIndex = 4 Then   'suffix
                SuffixCmbBox.Text = cell.Value.ToString
            ElseIf cell.ColumnIndex = 5 Then   'sex
                SexCmbBox.Text = cell.Value.ToString
            ElseIf cell.ColumnIndex = 6 Then   'contact no
                ContactNoTxtBox.Text = cell.Value.ToString
            ElseIf cell.ColumnIndex = 7 Then   'email addr
                EmailTxtBox.Text = cell.Value.ToString
            ElseIf cell.ColumnIndex = 8 Then   'birth date
                DateTimePicker1.Value = cell.Value.ToString
            ElseIf cell.ColumnIndex = 9 Then   'address
                AddressTxtBox.Text = cell.Value.ToString
            ElseIf cell.ColumnIndex = 10 Then   'municipality
                MunicipalityCmbBox.Text = cell.Value.ToString
            ElseIf cell.ColumnIndex = 11 Then   'postal code
                PostalCodeTxtBox.Text = cell.Value.ToString
            End If
        Next
    End Sub

    Private Sub IDTextbox_TextChange(sender As Object, e As EventArgs) Handles IdTxtBox.TextChanged
        Panel1.Enabled = True
    End Sub

    Private Sub DataGridView1_CellLoseFocus(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles DataGridView1.CellValidating
        'MsgBox(e.FormattedValue)
        Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
        Dim editedCellValue As String = e.FormattedValue.ToString
        Dim columnName = DataGridView1.Columns(e.ColumnIndex).Name
        'MsgBox("row index: " + e.RowIndex.ToString + " column name: " + columnName + " edited cell value: " + editedCellValue)
        'MsgBox(DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)

        Dim prevVal = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
        If Not editedCellValue = prevVal Then
            MsgBox("not changed")
            UpdateRow(e.RowIndex + 1, columnName, editedCellValue)
        End If

    End Sub

    Private Sub UpdateBtn_Click(sender As Object, e As EventArgs) Handles UpdateBtn.Click

        If ValidateRequiredFields() = False Then
            Return
        End If

        Dim id = IdTxtBox.Text
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

        Dim sql As String = "UPDATE Registration SET LastName = @lname, FirstName = @fname, MiddleName = @mname, Suffix = @suffix, Sex = @sex, ContactNo = @contactno, EmailAddress = @emailaddr, BirthDate = @dbirth, AddressIn = @addr, Municipality = @muni, PostalCode = @pcode WHERE ID = @id"
        Dim dbConnection As New OleDbConnection
        dbConnection = New OleDbConnection(ConnectionString)
        Dim cmd As OleDbCommand

        'MsgBox(sql)

        Try
            dbConnection.Open()
            cmd = New OleDbCommand(sql, dbConnection)
            cmd.Parameters.AddWithValue("@lname", surName)
            cmd.Parameters.AddWithValue("@fname", firstName)
            cmd.Parameters.AddWithValue("@mname", middleName)
            cmd.Parameters.AddWithValue("@suffix", suffix)
            cmd.Parameters.AddWithValue("@sex", sex)
            cmd.Parameters.AddWithValue("@contactno", contactNo)
            cmd.Parameters.AddWithValue("@emailaddr", emailAddr)
            cmd.Parameters.AddWithValue("@dbrith", birthDateFix)
            cmd.Parameters.AddWithValue("@addr", address)
            cmd.Parameters.AddWithValue("@muni", municipality)
            cmd.Parameters.AddWithValue("@pcode", postalCode)
            cmd.Parameters.AddWithValue("@id", id)

            Dim res = cmd.ExecuteNonQuery()

            If res > 0 Then
                MsgBox("Successfully saved update")
                LoadRegistrationDB()
            Else
                MsgBox("Error on update")
            End If
        Catch ex As Exception
            MsgBox("Failed to save update: " + ex.ToString)
        End Try

        'AddRecord(surName, firstName, middleName, suffix, sex, contactNo, emailAddr, birthDateFix, address, municipality, postalCode)
    End Sub

    Private Sub DeleteBtn_Click(sender As Object, e As EventArgs) Handles DeleteBtn.Click
        If IdTxtBox.Text = "" Then
            Return
        End If

        Dim sql As String = "DELETE FROM Registration WHERE ID = @id"
        Dim dbConnection As New OleDbConnection
        dbConnection = New OleDbConnection(ConnectionString)
        Dim cmd As OleDbCommand

        Try
            dbConnection.Open()
            cmd = New OleDbCommand(sql, dbConnection)
            cmd.Parameters.AddWithValue("@id", IdTxtBox.Text)
            Dim opt = MsgBox("Are you sure? ", vbYesNoCancel)

            If opt = vbYes Then
                Dim res = cmd.ExecuteNonQuery()
                If (res > 0) Then
                    MsgBox("Succesfully deleted")
                    LoadRegistrationDB()
                Else
                    MsgBox("Error on updating")
                End If
            Else
                MsgBox("Operation cancelled")
            End If
        Catch ex As Exception
            MsgBox("Error connecting to database: " & ex.Message)
        End Try

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

        If Not String.IsNullOrWhiteSpace(ContactNoTxtBox.Text) Then
            If Not ContactNoTxtBox.Text.Chars(0) = "9" Then
                MessageBox.Show("Invalid phone number: Must start with 9")
                ContactNoTxtBox.Focus()
                Return False
            ElseIf ContactNoTxtBox.TextLength < 9 Then
                MessageBox.Show("Phone number less than 10.")
                ContactNoTxtBox.Focus()
                Return False
            End If
        End If

        If Not String.IsNullOrWhiteSpace(EmailTxtBox.Text) And Not EmailTxtBox.Text = "N/A" Then
            Dim atSignIndex = EmailTxtBox.Text.IndexOf("@")
            If (atSignIndex = -1) Then
                MessageBox.Show("E-Mail Address is invalid.")
                EmailTxtBox.Focus()
                Return False
            End If

            Dim lastPart As String = EmailTxtBox.Text.Substring(atSignIndex)
            If String.IsNullOrWhiteSpace(lastPart) And Not lastPart.Contains(".") Then
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

        'If Not ConfirmationChckBox.Checked Then
        'MsgBox("Please confirm that all information above is correct.")
        'ConfirmationChckBox.Focus()
        'Return False
        'End If

        If String.IsNullOrWhiteSpace(MunicipalityCmbBox.Text) Then
            MessageBox.Show("Municipality is required.")
            MunicipalityCmbBox.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub SexOrientation_Limit(sender As Object, e As KeyPressEventArgs) Handles SexCmbBox.KeyPress
        e.Handled = True
    End Sub

    Private Sub Textbox_Limit(sender As Object, e As EventArgs) Handles FirstNameTxtBox.TextChanged, SurnameTxtBox.TextChanged, MiddleNameTxtBox.TextChanged
        Dim caller As TextBox = DirectCast(sender, TextBox)
        If caller.TextLength > 255 Then
            MsgBox("Limit reached")
            caller.Text = caller.Text.Remove(caller.TextLength - 1)
            caller.Select(caller.TextLength, 1)
        End If
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
        If ContactNoTxtBox.TextLength >= 10 Then
            ContactNoTxtBox.Text = ContactNoTxtBox.Text.Remove(ContactNoTxtBox.TextLength - 1)
            ContactNoTxtBox.Select(ContactNoTxtBox.TextLength, 1)
        End If
    End Sub
End Class