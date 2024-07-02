Imports System.Data.SqlClient
Imports DataAccessHandler
Public Class frmChAccountOpening
    Dim dbManager As New SqlHelper()
    Dim Objcn As SqlConnection = New SqlConnection()
    Private Sub btnMelting_Click(sender As Object, e As EventArgs) Handles btnMelting.Click
        Try
            Show_ChildForm("frmOpMelting", Me.MdiParent, Me.Tag)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnStockIssue_Click(sender As Object, e As EventArgs) Handles btnStockIssue.Click
        Try
            Show_ChildForm("frmOpStockIssue", Me.MdiParent, Me.Tag)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnStockReceipt_Click(sender As Object, e As EventArgs) Handles btnStockReceipt.Click
        Try
            Show_ChildForm("frmOpInterReceipt", Me.MdiParent, Me.Tag)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnUsedBags_Click(sender As Object, e As EventArgs) Handles btnBagReceived.Click
        Try
            Show_ChildForm("frmOpStockBags", Me.MdiParent, Me.Tag)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnTransactions_Click(sender As Object, e As EventArgs) Handles btnTransactions.Click
        Try
            Show_ChildForm("frmOpTransaction", Me.MdiParent, Me.Tag)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnLotTransfer_Click(sender As Object, e As EventArgs) Handles btnLotTransfer.Click
        Try
            Show_ChildForm("frmOpLotTransfer", Me.MdiParent, Me.Tag)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btn_Click(sender As Object, e As EventArgs) Handles btnStockIIssue.Click
        Try
            Show_ChildForm("frmOpInterIssue", Me.MdiParent, Me.Tag)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnLabIssue_Click(sender As Object, e As EventArgs) Handles btnLabIssue.Click
        Try
            Show_ChildForm("frmOpLabIssue", Me.MdiParent, Me.Tag)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnLotIssue_Click(sender As Object, e As EventArgs) Handles btnLotIssue.Click
        Try
            Show_ChildForm(" frmOpLotAddIssue", Me.MdiParent, Me.Tag)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnLotReceive_Click(sender As Object, e As EventArgs)
        Try
            Show_ChildForm(" frmOpLotAddReceive", Me.MdiParent, Me.Tag)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub frmAccountOpening_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.GetOpIssueStock()
        Me.GetOpInterReceipt()
        Me.GetOpMeltingStock()

        Me.GetOpTransactionStock()
        Me.GetOpLotTransferStock()
        Me.GetOpInterIssue()
        Me.GetOpLabIssue()
        Me.GetOpLotAdditionIssue()

        Me.GetOpBhukagBagCreated()
        Me.GetOpBhukagBagNotUsed()

        OpGrossWt = 0
        OpGrossPr = 0
        OpGrossFw = 0

        ''btnGetTotal_Click(Nothing, Nothing)

        Me.GetSumTxtTotal()
    End Sub
    Private Sub GetOpIssueStock()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchOpStockIssue", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_OpStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If row.RowState <> DataRowState.Deleted Then
                        If Not IsDBNull(row("IssueWt")) Then
                            sRWtTotal += Single.Parse(row("IssueWt"))
                        End If

                        If Not IsDBNull(row("FineWt")) Then
                            sFWtTotal += Single.Parse(row("FineWt"))
                        End If
                    End If
                Next

                If Not sFWtTotal = 0 Then
                    sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.00")
                End If

                txtOpIssueWt.Text = Format(sRWtTotal, "0.00")
                txtIssuePr.Text = Format(sRPrTotal, "0.00")
                txtOpIssueFw.Text = Format(sFWtTotal, "0.00")
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetOpInterReceipt()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchOpStockReceive", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_OpStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If row.RowState <> DataRowState.Deleted Then
                        If Not IsDBNull(row("ReceiveWt")) Then
                            sRWtTotal += Single.Parse(row("ReceiveWt"))
                        End If

                        If Not IsDBNull(row("FineWt")) Then
                            sFWtTotal += Single.Parse(row("FineWt"))
                        End If
                    End If
                Next

                If Not sFWtTotal = 0 Then
                    sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.00")
                End If

                txtOpReceiptWt.Text = Format(sRWtTotal, "0.00")
                txtReceiptPr.Text = Format(sRPrTotal, "0.00")
                txtOpReceiptFw.Text = Format(sFWtTotal, "0.00")
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetOpMeltingStock()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchOpStockMelting", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_OpStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If row.RowState <> DataRowState.Deleted Then
                        If Not IsDBNull(row("ReceiveWt")) Then
                            sRWtTotal += Single.Parse(row("ReceiveWt"))
                        End If

                        If Not IsDBNull(row("FineWt")) Then
                            sFWtTotal += Single.Parse(row("FineWt"))
                        End If
                    End If
                Next

                If Not sFWtTotal = 0 Then
                    sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.00")
                End If

                txtOpMReceiptWt.Text = Format(sRWtTotal, "0.00")
                txtOpMReceiptPr.Text = Format(sRPrTotal, "0.00")
                txtOpMReceiptFw.Text = Format(sFWtTotal, "0.00")
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetOpTransactionStock()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchOpStockTransaction", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_OpStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If row.RowState <> DataRowState.Deleted Then
                        If Not IsDBNull(row("ReceiveWt")) Then
                            sRWtTotal += Single.Parse(row("ReceiveWt"))
                        End If

                        If Not IsDBNull(row("FineWt")) Then
                            sFWtTotal += Single.Parse(row("FineWt"))
                        End If
                    End If
                Next

                If Not sFWtTotal = 0 Then
                    sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.00")
                End If

                txtOpTReceiptWt.Text = Format(sRWtTotal, "0.00")
                txtOpTReceiptPr.Text = Format(sRPrTotal, "0.00")
                txtOpTReceiptFw.Text = Format(sFWtTotal, "0.00")
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetOpLotTransferStock()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchOpStockLotTransfer", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_OpStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If row.RowState <> DataRowState.Deleted Then
                        If Not IsDBNull(row("ReceiveWt")) Then
                            sRWtTotal += Single.Parse(row("ReceiveWt"))
                        End If

                        If Not IsDBNull(row("FineWt")) Then
                            sFWtTotal += Single.Parse(row("FineWt"))
                        End If
                    End If
                Next

                If Not sFWtTotal = 0 Then
                    sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.00")
                End If

                txtOpLReceiptWt.Text = Format(sRWtTotal, "0.00")
                txtOpLReceiptPr.Text = Format(sRPrTotal, "0.00")
                txtOpLReceiptFw.Text = Format(sFWtTotal, "0.00")
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetOpInterIssue()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchOpStockInterIssue", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_OpStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If row.RowState <> DataRowState.Deleted Then
                        If Not IsDBNull(row("ReceiveWt")) Then
                            sRWtTotal += Single.Parse(row("ReceiveWt"))
                        End If

                        If Not IsDBNull(row("FineWt")) Then
                            sFWtTotal += Single.Parse(row("FineWt"))
                        End If
                    End If
                Next

                If Not sFWtTotal = 0 Then
                    sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.00")
                End If

                txtOpIReceiptWt.Text = Format(sRWtTotal, "0.00")
                txtOpIReceiptPr.Text = Format(sRPrTotal, "0.00")
                txtOpIReceiptFw.Text = Format(sFWtTotal, "0.00")
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetOpLabIssue()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchOpStockLabIssue", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_OpStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If row.RowState <> DataRowState.Deleted Then
                        If Not IsDBNull(row("ReceiveWt")) Then
                            sRWtTotal += Single.Parse(row("ReceiveWt"))
                        End If

                        If Not IsDBNull(row("FineWt")) Then
                            sFWtTotal += Single.Parse(row("FineWt"))
                        End If
                    End If
                Next

                If Not sFWtTotal = 0 Then
                    sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.00")
                End If

                txtOpLabReceiptWt.Text = Format(sRWtTotal, "0.00")
                txtOpLabReceiptPr.Text = Format(sRPrTotal, "0.00")
                txtOpLabReceiptFw.Text = Format(sFWtTotal, "0.00")
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetOpLotAdditionIssue()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchOpStockLotAdditionIssue", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_OpStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If row.RowState <> DataRowState.Deleted Then
                        If Not IsDBNull(row("ReceiveWt")) Then
                            sRWtTotal += Single.Parse(row("ReceiveWt"))
                        End If

                        If Not IsDBNull(row("FineWt")) Then
                            sFWtTotal += Single.Parse(row("FineWt"))
                        End If
                    End If
                Next

                If Not sFWtTotal = 0 Then
                    sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.00")
                End If

                txtOpLotIssuetWt.Text = Format(sRWtTotal, "0.00")
                txtOpLoIIssuePr.Text = Format(sRPrTotal, "0.00")
                txtOpLotIssueFw.Text = Format(sFWtTotal, "0.00")
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    'Private Sub GetOpLotAdditionReceive()
    '    Dim dtData As DataTable = New DataTable()

    '    Dim sRWtTotal As Single = 0
    '    Dim sRPrTotal As Single = 0
    '    Dim sFWtTotal As Single = 0

    '    Try
    '        Dim parameters = New List(Of SqlParameter)()
    '        parameters.Clear()

    '        With parameters
    '            .Add(dbManager.CreateParameter("@ActionType", "FetchOpStockLotAdditionReceive", DbType.String))
    '        End With

    '        dtData = dbManager.GetDataTable("SP_OpStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

    '        If dtData.Rows.Count > 0 Then
    '            For Each row As DataRow In dtData.Rows
    '                If row.RowState <> DataRowState.Deleted Then
    '                    If Not IsDBNull(row("ReceiveWt")) Then
    '                        sRWtTotal += Single.Parse(row("ReceiveWt"))
    '                    End If

    '                    If Not IsDBNull(row("FineWt")) Then
    '                        sFWtTotal += Single.Parse(row("FineWt"))
    '                    End If
    '                End If
    '            Next

    '            If Not sFWtTotal = 0 Then
    '                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.00")
    '            End If

    '            txtOpLotReceiptWt.Text = Format(sRWtTotal, "0.00")
    '            txtOpLoIReceiptPr.Text = Format(sRPrTotal, "0.00")
    '            txtOpLotReceiptFw.Text = Format(sFWtTotal, "0.00")
    '        End If

    '    Catch ex As Exception
    '        MessageBox.Show("Error:- " & ex.Message)
    '    End Try
    'End Sub
    Private Sub GetOpBhukagBagCreated()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchOpBhukaBagCreated", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_OpStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If row.RowState <> DataRowState.Deleted Then
                        If Not IsDBNull(row("RecieveWt")) Then
                            sRWtTotal += Single.Parse(row("RecieveWt"))
                        End If

                        If Not IsDBNull(row("ReceivePr")) Then
                            sRPrTotal += Single.Parse(row("ReceivePr"))
                        End If
                    End If
                Next

                If Not sRPrTotal = 0 Then
                    sFWtTotal = Format((Val(sRWtTotal) / Val(sRPrTotal)) * 100, "0.00")
                End If

                txtOpBhukaBagCreatedWt.Text = Format(sRWtTotal, "0.00")
                txtOpBhukaBagCreatedPr.Text = Format(sRPrTotal, "0.00")
                txtOpBhukaBagCreatedFw.Text = Format(sFWtTotal, "0.00")
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetOpBhukagBagNotUsed()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchOpBhukaBagNotUsed", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_OpStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If row.RowState <> DataRowState.Deleted Then
                        If Not IsDBNull(row("RecieveWt")) Then
                            sRWtTotal += Single.Parse(row("RecieveWt"))
                        End If

                        If Not IsDBNull(row("ReportPr")) Then
                            sRPrTotal += Single.Parse(row("ReportPr"))
                        End If
                    End If
                Next

                If Not sRPrTotal = 0 Then
                    sFWtTotal = Format((Val(sRWtTotal) * Val(sRPrTotal)) / 100, "0.00")
                End If

                txtOpBagNotUsedWt.Text = Format(sRWtTotal, "0.00")
                txtOpBagNotUsedPr.Text = Format(sRPrTotal, "0.00")
                txtOpBagNotUsedFw.Text = Format(sFWtTotal, "0.00")
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetTxtTotal()
        Dim dTotalWt As Double = 0
        Dim dTotalFw As Double = 0

        dTotalWt =
    GetValue(txtOpIssueWt.Text.Trim) +
    GetValue(txtOpReceiptWt.Text.Trim) +
    GetValue(txtOpMReceiptWt.Text.Trim) +
    GetValue(txtOpTReceiptWt.Text.Trim) +
    GetValue(txtOpLReceiptWt.Text.Trim) +
    GetValue(txtOpIReceiptWt.Text.Trim) +
    GetValue(txtOpLabReceiptWt.Text.Trim) +
    GetValue(txtOpLotIssuetWt.Text.Trim)

        dTotalFw =
    GetValue(txtOpIssueFw.Text.Trim) +
    GetValue(txtOpReceiptFw.Text.Trim) +
    GetValue(txtOpMReceiptWt.Text.Trim) +
    GetValue(txtOpTReceiptWt.Text.Trim) +
    GetValue(txtOpLReceiptWt.Text.Trim) +
    GetValue(txtOpIReceiptWt.Text.Trim) +
    GetValue(txtOpLabReceiptWt.Text.Trim) +
    GetValue(txtOpLotIssuetWt.Text.Trim)

        lblReceiveWt.Text = Format(dTotalWt, "0.00")
        OpGrossWt = Format(dTotalWt, "0.00")

        If Val(dTotalWt) > 0 Or Val(dTotalFw) > 0 Then
            lblReceivePr.Text = Format((Val(dTotalFw) / Val(dTotalWt)) * 100, "0.00")
        End If

        OpGrossPr = Format((Val(dTotalFw) / Val(dTotalWt)) * 100, "0.00")

        lblReceiveFw.Text = Format(dTotalFw, "0.00")
        OpGrossFw = Format(dTotalFw, "0.00")

    End Sub
    Public Function GetValue(ByVal text As String) As Double
        If String.IsNullOrEmpty(text) Then Return 0
        Dim value As Double
        If Double.TryParse(text, value) Then Return value
        Return 0
    End Function
    Private Function AsDouble(ByVal t As TextBox) As Double
        Dim val As Double
        Double.TryParse(t.Text, val)
        Return val
    End Function
    Private Sub btnGetTotal_Click(sender As Object, e As EventArgs) Handles btnGetTotal.Click
        Me.GetTxtTotal()
    End Sub
    Private Sub btnOpStockIssue_Click(sender As Object, e As EventArgs) Handles btnOpStockIssue.Click
        Dim ObjAcctOpIssue As New frmAcctOpIssue
        ObjAcctOpIssue.ShowDialog()
    End Sub
    Private Sub btnOpStockReceipt_Click(sender As Object, e As EventArgs) Handles btnOpStockReceipt.Click
        Dim ObjAcctOpIntReceipt As New frmAcctOpIntReceipt
        ObjAcctOpIntReceipt.ShowDialog()
    End Sub
    Private Sub btnMeltingDetails_Click(sender As Object, e As EventArgs) Handles btnMeltingDetails.Click
        Dim ObjAcctOpMelting As New frmAcctOpMelting
        ObjAcctOpMelting.ShowDialog()
    End Sub
    Private Sub btnTransDetails_Click(sender As Object, e As EventArgs) Handles btnTransDetails.Click
        Dim ObjAcctOpTransaction As New frmAcctOpTransaction
        ObjAcctOpTransaction.ShowDialog()
    End Sub
    Private Sub frmAccountOpening_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                If MsgBox("Wish To Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Me.Close()
            ElseIf e.KeyCode = Keys.Tab Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub btnLotTransferDetails_Click(sender As Object, e As EventArgs) Handles btnLotTransferDetails.Click
        Dim ObjAcctOpLotTransfer As New frmAcctOpLotTransfer
        ObjAcctOpLotTransfer.ShowDialog()
    End Sub
    Private Sub btnInterDeptIssue_Click(sender As Object, e As EventArgs) Handles btnInterDeptIssue.Click
        Dim ObjAcctOpInterDeptIssue As New frmAcctOpInterDeptIssue
        ObjAcctOpInterDeptIssue.ShowDialog()
    End Sub
    Private Sub btnLabIssueDetails_Click(sender As Object, e As EventArgs) Handles btnLabIssueDetails.Click
        Dim ObjAcctOpLabIssue As New frmAcctOpLabIssue
        ObjAcctOpLabIssue.ShowDialog()
    End Sub
    Private Sub btnLotAddIssue_Click(sender As Object, e As EventArgs) Handles btnLotAddIssue.Click
        Dim ObjAcctOpLotAddIssue As New frmAcctOpLotAddIssue
        ObjAcctOpLotAddIssue.ShowDialog()
    End Sub
    Private Sub btnLotAddReceive_Click(sender As Object, e As EventArgs)
        Dim ObjAcctOpLotAddReceive As New frmAcctOpLotAddReceive
        ObjAcctOpLotAddReceive.ShowDialog()
    End Sub
    Private Sub btnBagNotUsed_Click(sender As Object, e As EventArgs) Handles btnBagNotUsed.Click
        Try
            Show_ChildForm("frmOpStockBagsNotUsed", Me.MdiParent, Me.Tag)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnBhukaBagCreated_Click(sender As Object, e As EventArgs) Handles btnBhukaBagCreated.Click
        Dim ObjAcctOpBagNotCreated As New frmAcctOpBagNotCreated
        ObjAcctOpBagNotCreated.ShowDialog()
    End Sub
    Private Sub btnBhukaBagNotUsed_Click(sender As Object, e As EventArgs) Handles btnBhukaBagNotUsed.Click
        Dim ObjAcctOpBagNotCreated As New frmAcctOpBagNotUsed
        ObjAcctOpBagNotCreated.ShowDialog()
    End Sub

    Private Sub GetSumTxtTotal()

        Dim dTotalWt As Double = 0
        Dim dTotalFw As Double = 0

        '' For Gross Wt Calculation Start
        Dim dValueWI As Double = Double.Parse(If(Not String.IsNullOrEmpty(txtOpIssueWt.Text), txtOpIssueWt.Text, 0))
        Dim dValueWR As Double = Double.Parse(If(Not String.IsNullOrEmpty(txtOpReceiptWt.Text), txtOpReceiptWt.Text, 0))
        Dim dValueWM As Double = Double.Parse(If(Not String.IsNullOrEmpty(txtOpMReceiptWt.Text), txtOpMReceiptWt.Text, 0))

        Dim dValueWBa As Double = Double.Parse(If(Not String.IsNullOrEmpty(txtOpBhukaBagCreatedWt.Text), txtOpBhukaBagCreatedWt.Text, 0))
        Dim dValueWBu As Double = Double.Parse(If(Not String.IsNullOrEmpty(txtOpBagNotUsedWt.Text), txtOpBagNotUsedWt.Text, 0))
        Dim dValueWT As Double = Double.Parse(If(Not String.IsNullOrEmpty(txtOpTReceiptWt.Text), txtOpTReceiptWt.Text, 0))

        Dim dValueWL As Double = Double.Parse(If(Not String.IsNullOrEmpty(txtOpLReceiptWt.Text), txtOpLReceiptWt.Text, 0))
        Dim dValueWIR As Double = Double.Parse(If(Not String.IsNullOrEmpty(txtOpIReceiptWt.Text), txtOpIReceiptWt.Text, 0))
        Dim dValueWLA As Double = Double.Parse(If(Not String.IsNullOrEmpty(txtOpLabReceiptWt.Text), txtOpLabReceiptWt.Text, 0))

        Dim dValueWLI As Double = Double.Parse(If(Not String.IsNullOrEmpty(txtOpLotIssuetWt.Text), txtOpLotIssuetWt.Text, 0))
        '' For Gross Wt Calculation

        '' For Fine Wt Calculation Start
        Dim dValueFI As Double = Double.Parse(If(Not String.IsNullOrEmpty(txtOpIssueFw.Text), txtOpIssueFw.Text, 0))
        Dim dValueFR As Double = Double.Parse(If(Not String.IsNullOrEmpty(txtOpReceiptFw.Text), txtOpReceiptFw.Text, 0))
        Dim dValueFM As Double = Double.Parse(If(Not String.IsNullOrEmpty(txtOpMReceiptFw.Text), txtOpMReceiptFw.Text, 0))

        Dim dValueFBa As Double = Double.Parse(If(Not String.IsNullOrEmpty(txtOpBhukaBagCreatedFw.Text), txtOpBhukaBagCreatedFw.Text, 0))
        Dim dValueFBu As Double = Double.Parse(If(Not String.IsNullOrEmpty(txtOpBagNotUsedFw.Text), txtOpBagNotUsedFw.Text, 0))
        Dim dValueFT As Double = Double.Parse(If(Not String.IsNullOrEmpty(txtOpTReceiptFw.Text), txtOpTReceiptFw.Text, 0))

        Dim dValueFL As Double = Double.Parse(If(Not String.IsNullOrEmpty(txtOpLReceiptFw.Text), txtOpLReceiptFw.Text, 0))
        Dim dValueFIR As Double = Double.Parse(If(Not String.IsNullOrEmpty(txtOpIReceiptFw.Text), txtOpIReceiptFw.Text, 0))
        Dim dValueFLA As Double = Double.Parse(If(Not String.IsNullOrEmpty(txtOpLabReceiptFw.Text), txtOpLabReceiptFw.Text, 0))

        Dim dValueFLI As Double = Double.Parse(If(Not String.IsNullOrEmpty(txtOpLotIssueFw.Text), txtOpLotIssueFw.Text, 0))

        dTotalWt = dValueWI + dValueWR + dValueWM + dValueWBa + dValueWBu + dValueWT + dValueWL + dValueWIR + dValueWLA + dValueWLI
        dTotalFw = dValueFI + dValueFR + dValueFM + dValueFBa + dValueFBu + dValueFT + dValueFL + dValueFIR + dValueFLA + dValueFLI

        lblReceiveWt.Text = Format(dTotalWt, "0.00")
        OpGrossWt = Format(dTotalWt, "0.00")

        lblReceiveFw.Text = Format(dTotalFw, "0.00")
        OpGrossFw = Format(dTotalFw, "0.00")

        If Val(dTotalWt) > 0 Or Val(dTotalFw) > 0 Then
            lblReceivePr.Text = Format((Val(dTotalFw) / Val(dTotalWt)) * 100, "0.00")
        End If

        OpGrossPr = Format((Val(dTotalFw) / Val(dTotalWt)) * 100, "0.00")

    End Sub

    Private Sub BtnBhukaBagNotUpdaed_Click(sender As Object, e As EventArgs) Handles BtnBhukaBagNotUpdaed.Click
        Try
            Show_ChildForm("frmOpStockBagsNotUpdated", Me.MdiParent, Me.Tag)
        Catch ex As Exception
        End Try
    End Sub
End Class