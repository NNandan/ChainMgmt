Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmListLabIssue
    Dim dbManager As New SqlHelper()
    Dim Objcn As SqlConnection = New SqlConnection()
    Dim strSQL As String = Nothing
    Dim GridDoubleClick As Boolean
    Private Sub frmEditELabIssue_Load(sender As Object, e As EventArgs) Handles Me.Load
        With dgvELabIssue
            .AutoGenerateColumns = False
            .DataSource = FetchAllRecords()
            .EnableFiltering = True
            .MasterTemplate.ShowHeaderCellButtons = True
            .MasterTemplate.ShowFilteringRow = False
            .CurrentRow = Nothing
        End With
    End Sub
    Private Function FetchAllRecords() As DataTable

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchEditLabIssue", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_LabIssue_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub dgvELabIssue_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles dgvELabIssue.CellDoubleClick
        Dim i As Int16 = dgvELabIssue.Rows(e.RowIndex).Cells(0).Value

        If dgvELabIssue.Rows.Count = 0 Then Exit Sub

        If dgvELabIssue.Rows.Count > 0 Then

            Dim iLabIssueId As Integer = dgvELabIssue.Rows(e.RowIndex).Cells(0).Value
            'Dim sTitle As String
            'Dim sText As String
            'sTitle = TextBox1.Text
            'sText = TextBox2.Text
            Dim frm As New frmEditLabIssue(iLabIssueId)
            frm.Show()
        End If

        'Dim cellValue As Object = e.Row.Cells(e.Column.Name).Value
    End Sub
    Private Sub frmEditELabIssue_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                If MsgBox("Wish To Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    CType(Me.ParentForm, frmMain).FormMode.Text = ""
                    Me.Close()
                End If
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class