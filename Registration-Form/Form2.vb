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

End Class