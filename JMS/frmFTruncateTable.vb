Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Public Class frmfTruncateTable
    Dim dbManager As New SqlHelper()
    Dim strSQL As String = Nothing
    Private Sub BtnDeleteTrans_Click(sender As Object, e As EventArgs) Handles BtnDeleteTrans.Click
        If (MsgBox("[DELETION] Are You Sure To Delete All Data ?", vbYesNo + vbDefaultButton2 + vbQuestion, "Attn : " + UserName.Trim()) = vbYes) Then
            Try
                Me.DeleteData()
                Me.CheckPeriodNo()
            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            End Try
        End If
    End Sub
    Private Sub DeleteData()
        Try
            Me.Cursor = Cursors.WaitCursor

            strSQL = Nothing
            strSQL = "TRUNCATE TABLE tblfnewlotno"

            dbManager.Delete(strSQL, CommandType.Text)

            strSQL = Nothing
            strSQL = "TRUNCATE TABLE tblfIssueDetails"

            dbManager.Delete(strSQL, CommandType.Text)

            strSQL = Nothing
            strSQL = "TRUNCATE TABLE tblfReceiveDetails"

            dbManager.Delete(strSQL, CommandType.Text)

            strSQL = Nothing
            strSQL = "TRUNCATE TABLE tblfMelting"

            dbManager.Delete(strSQL, CommandType.Text)

            strSQL = Nothing
            strSQL = "TRUNCATE TABLE tblfMeltingDetails"

            dbManager.Delete(strSQL, CommandType.Text)

            strSQL = Nothing
            strSQL = "TRUNCATE TABLE tblfInterDeptIssue"

            dbManager.Delete(strSQL, CommandType.Text)

            strSQL = Nothing
            strSQL = "TRUNCATE TABLE tblfInterDeptIssueDetails"

            dbManager.Delete(strSQL, CommandType.Text)

            strSQL = Nothing
            strSQL = "TRUNCATE TABLE tblfInterDeptReceipt"

            dbManager.Delete(strSQL, CommandType.Text)

            strSQL = Nothing
            strSQL = "TRUNCATE TABLE tblfInterDeptReceiptDetails"

            dbManager.Delete(strSQL, CommandType.Text)

            strSQL = Nothing
            strSQL = "TRUNCATE TABLE tblstockissue"

            dbManager.Delete(strSQL, CommandType.Text)

            strSQL = Nothing
            strSQL = "TRUNCATE TABLE tblstockissuedetails"

            dbManager.Delete(strSQL, CommandType.Text)

            strSQL = Nothing
            strSQL = "TRUNCATE TABLE tblfUsedBags"

            dbManager.Delete(strSQL, CommandType.Text)

            strSQL = Nothing
            strSQL = "TRUNCATE TABLE tblfScrapBags"

            dbManager.Delete(strSQL, CommandType.Text)

            strSQL = Nothing
            strSQL = "TRUNCATE TABLE tblPeriod"

            dbManager.Delete(strSQL, CommandType.Text)

            strSQL = Nothing
            strSQL = "TRUNCATE TABLE tblPeriodDetails"

            dbManager.Delete(strSQL, CommandType.Text)

            strSQL = Nothing
            strSQL = "TRUNCATE TABLE tblTmpPeriodDetails"

            dbManager.Delete(strSQL, CommandType.Text)

            strSQL = Nothing
            strSQL = "TRUNCATE TABLE tblfLabIssue"

            dbManager.Delete(strSQL, CommandType.Text)

            strSQL = Nothing
            strSQL = "TRUNCATE TABLE tblfLabIssueDetails"

            dbManager.Delete(strSQL, CommandType.Text)

            strSQL = Nothing
            strSQL = "TRUNCATE TABLE tblGConvFactor"

            dbManager.Delete(strSQL, CommandType.Text)
            strSQL = Nothing
            strSQL = "TRUNCATE TABLE tblGTreeMaking"

            dbManager.Delete(strSQL, CommandType.Text)
            strSQL = Nothing
            strSQL = "TRUNCATE TABLE tblGTreeMakingDetails"

            dbManager.Delete(strSQL, CommandType.Text)

            MessageBox.Show("All Data Delete Successefully")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub CheckPeriodNo()
        Try

            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "CheckPeriodNo", DbType.String))
            End With

            Dim strName As Object = dbManager.GetScalarValue("SP_PeriodDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class
