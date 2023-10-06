Imports DataAccessHandler
Public Class frmTruncateTable
    Dim dbManager As New SqlHelper()
    Dim strSQL As String = Nothing
    Private Sub btnTruncate_Click(sender As Object, e As EventArgs) Handles btnTruncate.Click
        If (MsgBox("[DELETION] Are You Sure To Delete All Data ?", vbYesNo + vbDefaultButton2 + vbQuestion, "Attn : " + UserName.Trim()) = vbYes) Then
            Try
                Me.DeleteData()
            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            End Try
        End If
    End Sub
    Private Sub DeleteData()
        Try
            Me.Cursor = Cursors.WaitCursor

            strSQL = Nothing
            strSQL = "TRUNCATE TABLE tblStockIssue"

            dbManager.Delete(strSQL, CommandType.Text)

            strSQL = Nothing
            strSQL = "TRUNCATE TABLE tblStockIssueDetails"

            dbManager.Delete(strSQL, CommandType.Text)

            strSQL = Nothing
            strSQL = "TRUNCATE TABLE tblUsedBags"

            dbManager.Delete(strSQL, CommandType.Text)

            strSQL = Nothing
            strSQL = "TRUNCATE TABLE tblMelting"

            dbManager.Delete(strSQL, CommandType.Text)

            strSQL = Nothing
            strSQL = "TRUNCATE TABLE tblMeltingDetails"

            dbManager.Delete(strSQL, CommandType.Text)

            strSQL = Nothing
            strSQL = "TRUNCATE TABLE tblLotTransfer"

            dbManager.Delete(strSQL, CommandType.Text)

            strSQL = Nothing
            strSQL = "TRUNCATE TABLE tblLotFail"

            dbManager.Delete(strSQL, CommandType.Text)

            strSQL = Nothing
            strSQL = "TRUNCATE TABLE tblLotAdditionReceive"

            dbManager.Delete(strSQL, CommandType.Text)

            strSQL = Nothing
            strSQL = "TRUNCATE TABLE tblLotAdditionReceiveDetails"

            dbManager.Delete(strSQL, CommandType.Text)

            strSQL = Nothing
            strSQL = "TRUNCATE TABLE tblLotAdditionIssue"

            dbManager.Delete(strSQL, CommandType.Text)

            strSQL = Nothing
            strSQL = "TRUNCATE TABLE tblLotAdditionIssueDetails"

            dbManager.Delete(strSQL, CommandType.Text)

            strSQL = Nothing
            strSQL = "TRUNCATE TABLE tblLabIssue"

            dbManager.Delete(strSQL, CommandType.Text)

            strSQL = Nothing
            strSQL = "TRUNCATE TABLE tblLabIssueDetails"

            dbManager.Delete(strSQL, CommandType.Text)

            strSQL = Nothing
            strSQL = "TRUNCATE TABLE tblInterDeptReceipt"

            dbManager.Delete(strSQL, CommandType.Text)

            strSQL = Nothing
            strSQL = "TRUNCATE TABLE tblInterDeptReceiptDetails"

            dbManager.Delete(strSQL, CommandType.Text)

            strSQL = Nothing
            strSQL = "TRUNCATE TABLE tblInterDeptIssue"

            dbManager.Delete(strSQL, CommandType.Text)

            strSQL = Nothing
            strSQL = "TRUNCATE TABLE tblInterDeptIssueDetails"

            dbManager.Delete(strSQL, CommandType.Text)

            strSQL = Nothing
            strSQL = "TRUNCATE TABLE tbltransaction"

            dbManager.Delete(strSQL, CommandType.Text)

            strSQL = Nothing
            strSQL = "TRUNCATE TABLE tblCoreAdditionIssue"

            dbManager.Delete(strSQL, CommandType.Text)

            strSQL = Nothing
            strSQL = "TRUNCATE TABLE tblCoreAdditionIssueDetails"

            dbManager.Delete(strSQL, CommandType.Text)

            strSQL = Nothing
            strSQL = "TRUNCATE TABLE tblCoreAdditionReceive"

            dbManager.Delete(strSQL, CommandType.Text)

            strSQL = Nothing
            strSQL = "TRUNCATE TABLE tblCoreAdditionReceiveDetails"

            dbManager.Delete(strSQL, CommandType.Text)

            strSQL = Nothing
            strSQL = "TRUNCATE TABLE tblHollowIssue"

            dbManager.Delete(strSQL, CommandType.Text)

            MessageBox.Show("Tables Truncate Successefuly")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
End Class