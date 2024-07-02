Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Imports System.ComponentModel
Public Class frmFLotHistoryRpt
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Dim intOpId As Int16

    Private mFr_State As FormState

    Dim strSQL As String = Nothing
    Dim TempRow As Integer

    Dim IGridDoubleClick As Boolean
    Dim RGridDoubleClick As Boolean

    Dim blnRecieveStatus As Boolean
    Dim blnIssueStatus As Boolean

    Dim dbManager As New SqlHelper()
    Dim Objcn As SqlConnection = New SqlConnection()

    Private Objerr As New ErrorProvider()
    Private Sub cmbLotNo_SelectedIndexChanged(sender As Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles cmbLotNo.SelectedIndexChanged
        Dim dt As DataTable = New DataTable()

        If cmbLotNo.SelectedIndex > 0 Then

            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchHeaderForTrans", DbType.String))
                .Add(dbManager.CreateParameter("@NLotNo", cmbLotNo.SelectedItem.Text.Trim, DbType.String))
            End With

            Dim dr As SqlDataReader = dbManager.GetDataReader("SP_NewLotNo_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

            If dr.HasRows = True Then
                dr.Read()
                txtMelting.Tag = dr.Item("MeltingId").ToString
                txtMelting.Text = dr.Item("MeltingValue").ToString
                txtItem.Tag = dr.Item("ItemId").ToString
                txtItem.Text = dr.Item("ItemName").ToString
                txtOperation.Tag = dr.Item("OperationId").ToString
                txtOperation.Text = dr.Item("OperationName").ToString
                txtLabour.Tag = dr.Item("LabourId").ToString
                txtLabour.Text = dr.Item("LabourName").ToString
                txtOrderNo.Text = dr.Item("orderNo").ToString
                txtOpreationType.Tag = dr.Item("OperationTypeId").ToString
                txtOpreationType.Text = dr.Item("OperationType").ToString

                BindAllGrid()
            End If

            dr.Close()
            Objcn.Close()

            Exit Sub
ErrHandler:
            MsgBox(Err.Description, MsgBoxStyle.Critical)
        End If

    End Sub
    Private Sub lblLoss_TextChanged(sender As Object, e As EventArgs) Handles lblLoss.TextChanged
        Select Case txtOperation.Tag
            Case = 1, 4
                lblLoss.Text = "Vaccum Wt."
            Case = 2, 3
                lblLoss.Text = "Loss Wt."
            Case = 44
                lblLoss.Text = "Stock Add. Wt."
            Case = 45
                lblLoss.Text = "Stock Rem. Wt."
            Case Else
        End Select
    End Sub
    Private Sub frmLotHistoryRpt_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.fillLotNo()
        Me.Clear_Form()
    End Sub
    Private Sub fillLotNo()
        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FillHistoryLotNoCmb", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_NewLotNo_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            ''Insert the Default Item to DataTable.
            Dim row As DataRow = dt.NewRow()
            row(0) = 0
            row(1) = "---Select---"
            dt.Rows.InsertAt(row, 0)

            'Assign DataTable as DataSource.
            cmbLotNo.DataSource = dt
            cmbLotNo.DisplayMember = "LotNo"
            cmbLotNo.ValueMember = "NewLotId"

            cmbLotNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbLotNo.AutoCompleteDataSource = AutoCompleteSource.ListItems
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub Clear_Form()
        Try
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub BindAllGrid()
        ''For Receive Gold
        rdgvReceive.AutoGenerateColumns = False
        rdgvReceive.DataSource = FetchRGData()
        rdgvReceive.EnableFiltering = True
        rdgvReceive.MasterTemplate.ShowHeaderCellButtons = True
        rdgvReceive.MasterTemplate.ShowFilteringRow = False
        rdgvReceive.CurrentRow = Nothing
        Me.FetchRGTotal()

        ''For Issue Gold
        rdgvIssue.AutoGenerateColumns = False
        rdgvIssue.DataSource = FetchOGData()
        rdgvIssue.EnableFiltering = True
        rdgvIssue.MasterTemplate.ShowHeaderCellButtons = True
        rdgvIssue.MasterTemplate.ShowFilteringRow = False
        rdgvIssue.CurrentRow = Nothing
        Me.FetchOGTotal()

        rdgvMReceive.AutoGenerateColumns = False
        rdgvMReceive.DataSource = FetchRMData()
        rdgvMReceive.EnableFiltering = True
        rdgvMReceive.MasterTemplate.ShowHeaderCellButtons = True
        rdgvMReceive.MasterTemplate.ShowFilteringRow = False
        rdgvMReceive.CurrentRow = Nothing
        Me.FetchRMTotal()

        rdgvMIssue.AutoGenerateColumns = False
        rdgvMIssue.DataSource = FetchIMData()
        rdgvMIssue.EnableFiltering = True
        rdgvMIssue.MasterTemplate.ShowHeaderCellButtons = True
        rdgvMIssue.MasterTemplate.ShowFilteringRow = False
        rdgvMIssue.CurrentRow = Nothing
        Me.FetchIMTotal()

        Me.CalculateTotal()
        Me.FetchWorkDoneData()
    End Sub
    Private Function FetchRGData() As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchGData", DbType.String))
                .Add(dbManager.CreateParameter("@LotNo", cmbLotNo.SelectedItem.Text.Trim, DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_fReceiveDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub FetchRGTotal()
        lblRGTotal.Text = 0.00

        Try
            For Each row As GridViewRowInfo In rdgvReceive.Rows
                lblRGTotal.Text = Format(Val(lblRGTotal.Text) + Val(row.Cells(4).Value), "0.00")
            Next
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Function FetchOGData() As DataTable
        Dim dtData As DataTable = New DataTable()
        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchGData", DbType.String))
                .Add(dbManager.CreateParameter("@LotNo", cmbLotNo.SelectedItem.Text.Trim, DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_fIssueDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub FetchOGTotal()
        lblIGTotal.Text = 0.00

        Try
            For Each row As GridViewRowInfo In rdgvIssue.Rows
                lblIGTotal.Text = Format(Val(lblIGTotal.Text) + Val(row.Cells(4).Value), "0.00")
            Next
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Function FetchRMData() As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchOData", DbType.String))
                .Add(dbManager.CreateParameter("@LotNo", cmbLotNo.SelectedItem.Text.Trim, DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_fReceiveDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub FetchRMTotal()
        lblRMTotal.Text = 0.00
        Try
            For Each row As GridViewRowInfo In rdgvMReceive.Rows
                lblRMTotal.Text = Format(Val(lblRMTotal.Text) + Val(row.Cells(4).Value), "0.00")
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function FetchIMData() As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchOData", DbType.String))
                .Add(dbManager.CreateParameter("@LotNo", cmbLotNo.SelectedItem.Text.Trim, DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_fIssueDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub FetchIMTotal()
        lblIMTotal.Text = 0.00
        Try
            For Each row As GridViewRowInfo In rdgvMIssue.Rows
                lblIMTotal.Text = Format(Val(lblIMTotal.Text) + Val(row.Cells(4).Value), "0.00")
            Next
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Sub CalculateTotal()
        Dim dRTotal As Double = 0
        Dim dITotal As Double = 0

        Dim dGTotal As Double = 0

        dRTotal = Val(lblRGTotal.Text.Trim) + Val(lblRMTotal.Text.Trim)

        dITotal = Val(lblIGTotal.Text.Trim) + Val(lblIMTotal.Text.Trim)

        txtLossWt.Text = Format(Val(dITotal - dRTotal), "0.00")

        Select Case txtOperation.Tag
            Case = 1, 4
                lblLoss.Text = "Loss Wt."
            Case = 2, 3
                lblLoss.Text = "Vaccum Wt."
            Case = 43
                lblLoss.Text = "Melting Wt."
            Case = 44
                lblLoss.Text = "Stock Add. Wt."
            Case = 45
                lblLoss.Text = "Stock Rem. Wt."
        End Select
    End Sub
    Private Sub FetchWorkDoneData()
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchWorkDoneData", DbType.String))
                .Add(dbManager.CreateParameter("@LotNo", cmbLotNo.SelectedItem.Text.Trim, DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_fReceiveDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                txtWorkDone.Text = dtData.Rows(0).Item("RecWt").ToString()
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

    End Sub

End Class