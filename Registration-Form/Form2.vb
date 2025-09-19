Imports System.Data.Common
Imports System.Data.OleDb
Imports System.IO
Imports System.Runtime
Imports Windows.Win32.System
Public Class Form2
    Dim ConnectionString As String
    Dim CurrentUser As String

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
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.Columns(0).Width = 20
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

    Private Sub DataGridView1_CellUpdate(sender As Object, e As KeyPressEventArgs) Handles DataGridView1.KeyPress
        If Asc(e.KeyChar) = 19 Then
            MsgBox("Save shortcut key")
        End If
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
End Class