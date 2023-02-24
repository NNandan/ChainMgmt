﻿Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmLotFailBag
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState

    Dim dbManager As New SqlHelper(ConfigurationManager.ConnectionStrings("ConString").ToString())
    Dim Objcn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("ConString").ToString())
    Private Sub frmLotFail_Load(sender As Object, e As EventArgs) Handles Me.Load
        tbLotFail.SelectedIndex = 0

        TransDt.Focus()
        TransDt.Value = DateTime.Now

        Me.fillLotNo()
        Me.FillBagType()

        dgvCLotFail.AutoGenerateColumns = False
        dgvCLotFail.DataSource = fetchAllRecords()

        dgvCLotFail.EnableFiltering = True
        dgvCLotFail.MasterTemplate.ShowHeaderCellButtons = True
        dgvCLotFail.MasterTemplate.ShowFilteringRow = False
        ''AddHandler dgvLotFail.FilterChanged, AddressOf dgvLotFail_FilterChanged

    End Sub
    Private Sub btnCDelete_Click(sender As Object, e As EventArgs) Handles btnCDelete.Click
        If Not String.IsNullOrEmpty(txtCTransId.Tag) Then

            Try
                Dim parameters = New List(Of SqlParameter)()
                parameters.Clear()

                With parameters
                    parameters.Add(dbManager.CreateParameter("@LId", Val(txtCTransId.Tag), DbType.Int16))
                End With

                dbManager.Delete("SP_LotFail_Delete", CommandType.StoredProcedure, parameters.ToArray())

                MessageBox.Show("Data Deleted !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Me.clearCreateAllData()

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            End Try
        Else
            MessageBox.Show("Please Select A Record !!!")
        End If
    End Sub
    Private Sub btnCSave_Click(sender As Object, e As EventArgs) Handles btnCSave.Click
        If Not Validate_Fields() Then Exit Sub

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            If btnCSave.Text = "&Save" Then

                With parameters
                    .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))

                    .Add(dbManager.CreateParameter("@LDate", TransDt.Value.ToString(), DbType.DateTime))
                    .Add(dbManager.CreateParameter("@LotNo", cmbCLotNo.Text.Trim(), DbType.String))

                    .Add(dbManager.CreateParameter("@LotFailWt", Format(CDec(txtCLotFailWt.Text.Trim()), "0.00"), DbType.Decimal))
                    .Add(dbManager.CreateParameter("@LotFailPr", Format(CDec(txtCLotFailPr.Text.Trim()), "0.00"), DbType.Decimal))

                    .Add(dbManager.CreateParameter("@LItemId", CInt(txtItemName.Tag), DbType.Int16))
                    .Add(dbManager.CreateParameter("@LOperationId", CInt(txtOperation.Tag), DbType.Int16))
                    .Add(dbManager.CreateParameter("@LabourId", CInt(txtLabour.Tag), DbType.Int16))

                    .Add(dbManager.CreateParameter("@LRemark", CStr(txtRemarks.Text.Trim()), DbType.String))
                    .Add(dbManager.CreateParameter("@CreatedBy", UserName.Trim(), DbType.String))
                End With
            Else
                With parameters
                    .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
                    .Add(dbManager.CreateParameter("@LId", CInt(txtCTransId.Tag), DbType.Int16))

                    .Add(dbManager.CreateParameter("@LDate", TransDt.Value.ToString(), DbType.DateTime))
                    .Add(dbManager.CreateParameter("@LotNo", cmbCLotNo.Text.Trim(), DbType.String))

                    .Add(dbManager.CreateParameter("@LotFailWt", Format(CDec(txtCLotFailWt.Text.Trim()), "0.00"), DbType.Decimal))
                    .Add(dbManager.CreateParameter("@LotFailPr", Format(CDec(txtCLotFailPr.Text.Trim()), "0.00"), DbType.Decimal))

                    .Add(dbManager.CreateParameter("@LOperationId", CInt(txtOperation.Tag), DbType.Int16))
                    .Add(dbManager.CreateParameter("@LabourId", CInt(txtLabour.Tag), DbType.Int16))
                    .Add(dbManager.CreateParameter("@LItemId", CInt(txtItemName.Tag), DbType.Int16))

                    .Add(dbManager.CreateParameter("@LRemark", txtRemarks.Text.Trim(), DbType.String))
                    .Add(dbManager.CreateParameter("@CreatedBy", UserName.Trim(), DbType.String))
                End With
            End If

            dbManager.Insert("SP_LotFail_Save", CommandType.StoredProcedure, parameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.btnCCancel_Click(sender, e)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub txtFailWt_Leave(sender As Object, e As EventArgs)
        txtCLotFailWt.Text = Format(Val(txtCLotFailWt.Text), "0.00")
    End Sub
    Private Sub txtFailPr_Leave(sender As Object, e As EventArgs)
        txtCLotFailPr.Text = Format(Val(txtCLotFailPr.Text), "0.00")
    End Sub
    Private Function fetchAllRecords() As DataTable

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_LotFail_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub dgvLotFail_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 Then

            btnCSave.Text = "&Update"

            txtCTransId.Tag = dgvCLotFail.Rows(e.RowIndex).Cells(0).Value.ToString()

            Dim dtData As DataTable = fetchAllRecords(CInt(txtCTransId.Tag))

            If dtData.Rows.Count > 0 Then
                txtCTransId.Tag = dtData.Rows(0)("LotFailId").ToString()
                TransDt.Text = dtData.Rows(0)("LotFailDt").ToString()
                txtOperation.Tag = dtData.Rows(0)("OperationId").ToString()
                txtLabour.Tag = dtData.Rows(0)("LabourId").ToString()
                cmbCLotNo.Text = dtData.Rows(0)("LotNumber").ToString()
                txtCLotFailWt.Text = dtData.Rows(0)("LotFailWt").ToString()
                txtCLotFailPr.Text = dtData.Rows(0)("LotFailPr").ToString()
                txtRemarks.Text = dtData.Rows(0)("Remark").ToString()
            Else
                Me.clearCreateAllData()
            End If
        End If
    End Sub
    Private Function fetchAllRecords(ByVal LotFailId As Integer) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@LId", LotFailId, DbType.String))
                .Add(dbManager.CreateParameter("@ActionType", "FetchRecord", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_LotFail_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
    Private Sub txtFailWt_KeyPress(sender As Object, e As KeyPressEventArgs)
        OnlyAllowPostiveNumbers(sender, e, 2)
    End Sub
    Private Sub txtFailPr_KeyPress(sender As Object, e As KeyPressEventArgs)
        OnlyAllowPostiveNumbers(sender, e, 2)
    End Sub
    Private Sub tbLotFail_Click(sender As Object, e As EventArgs) Handles tbLotFail.Click
        If tbLotFail.SelectedIndex = 0 Then  ''for Create LotFail Bag
            Me.fillLotNo()
        ElseIf tbLotFail.SelectedIndex = 1 Then ''for Receive LotFail Bag
            Me.FillBagType()
        ElseIf tbLotFail.SelectedIndex = 2 Then ''for Update LotFail Bag
            Me.FillBagType()
        End If
    End Sub
    Private Sub getLastLotNoVAmt()

        Dim strSQL As String = Nothing

        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        strSQL = "SELECT OperationId, OperationName, FrLabourId, frKarigarName, ReceivePr, ReceiveWt, ItemId, ItemName FROM udf_GetMaxLotTransNo('" & cmbCLotNo.Text.Trim() & "') ORDER BY MaxTransId"

        parameters.Add(dbManager.CreateParameter("@TLotNo", cmbCLotNo.Text.Trim(), DbType.String))

        Dim dr As SqlDataReader = dbManager.GetDataReader(strSQL, CommandType.Text, Objcn, parameters.ToArray())

        Try
            If dr.Read = False Then
                Exit Sub
            Else
                txtOperation.Tag = dr("OperationId").ToString()
                txtOperation.Text = dr("OperationName").ToString()
                txtLabour.Tag = dr("FrLabourId").ToString()
                txtLabour.Text = dr("frKarigarName").ToString()
                txtCLotFailWt.Text = Format(Val(dr("ReceiveWt")), "0.00")
                txtCLotFailPr.Text = Format(Val(dr("ReceivePr")), "0.00")
                txtItemName.Tag = dr("ItemId").ToString()
                txtItemName.Text = dr("ItemName").ToString()
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            Objcn.Close()
        End Try
    End Sub
    Private Sub txtLRecieveWt_TextChanged(sender As Object, e As EventArgs) Handles txtRRecieveWt.TextChanged
        Try
            txtRTotalWt.Text = Format(Val(txtRRecieveWt.Text) + Val(txtRSample.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtLRSampleWt_TextChanged(sender As Object, e As EventArgs) Handles txtRSample.TextChanged
        Try
            txtRTotalWt.Text = Format(Val(txtRRecieveWt.Text) + Val(txtRSample.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtUreceivePr_TextChanged(sender As Object, e As EventArgs) Handles txtUreceivePr.TextChanged
        Try
            txtUreceiveFineWt.Text = Format(Val(txtUreceivePr.Text) * Val(txtUreceiveWt.Text) / 100, "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtUreceiveFineWt_TextChanged(sender As Object, e As EventArgs) Handles txtUreceiveFineWt.TextChanged
        Try
            txtULossFine.Text = Format(Val(txtUIssueFineWt.Text) - Val(txtUreceiveFineWt.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtUIssueFineWt_TextChanged(sender As Object, e As EventArgs) Handles txtUIssueFineWt.TextChanged
        Try
            txtULossFine.Text = Format(Val(txtUIssueFineWt.Text) - Val(txtUreceiveFineWt.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#Region "CreateLotFailBag"
    Private Sub fillLotNo()

        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FetchLotNoForLotAddition", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            'Insert the Default Item to DataTable.
            Dim row As DataRow = dt.NewRow()
            row(0) = 0
            row(1) = "---Select---"
            dt.Rows.InsertAt(row, 0)

            'Assign DataTable as DataSource.
            cmbCLotNo.DataSource = dt
            cmbCLotNo.DisplayMember = "LotNo"
            cmbCLotNo.ValueMember = "TransactionId"
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub clearCreateAllData()
        btnCSave.Text = "Save"
        txtCTransId.Tag = ""
        txtCTransId.Clear()
        txtCTransId.Tag = ""

        TransDt.Value = DateTime.Now

        txtOperation.Tag = ""
        txtOperation.Clear()

        txtLabour.Tag = ""
        txtLabour.Clear()

        cmbCLotNo.SelectedIndex = -1

        txtCLotFailWt.Clear()
        txtCLotFailPr.Clear()
        txtRemarks.Clear()

        dgvCLotFail.AutoGenerateColumns = False
        dgvCLotFail.DataSource = fetchAllRecords()

    End Sub

#End Region

#Region "ReceiveLotFailBag"
    Private Sub fillRLotFailBagNo()

        Dim connection As SqlConnection = Nothing
        Dim dt As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FetchRLotFailBag", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_LotFail_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)

        dt.Load(dr)

        If dt.Rows.Count = 0 Then
            MessageBox.Show("No LotFail Bags Avilable !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If tbLotFail.SelectedIndex = 1 Then
            Try
                cmbRBagNo.DataSource = Nothing
                cmbRBagNo.Items.Clear()

                'Insert the Default Item to DataTable.
                Dim row As DataRow = dt.NewRow()
                row(0) = 0
                row(1) = "---Select---"
                dt.Rows.InsertAt(row, 0)

                'Assign DataTable as DataSource.
                cmbRBagNo.DataSource = dt
                cmbRBagNo.DisplayMember = "LotFailBagNo"
                cmbRBagNo.ValueMember = "LotFailId"

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally
                dr.Close()
                dbManager.CloseConnection(connection)
            End Try
        End If
    End Sub
    Private Sub fillULotFailBagNo()

        Dim connection As SqlConnection = Nothing
        Dim dt As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FetchULotFailBag", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_LotFail_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)

        dt.Load(dr)

        If dt.Rows.Count = 0 Then
            MessageBox.Show("No LotFail Bags Avilable !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If tbLotFail.SelectedIndex = 2 Then
            Try
                cmbULotFailNo.DataSource = Nothing
                cmbULotFailNo.Items.Clear()

                'Insert the Default Item to DataTable.
                Dim row As DataRow = dt.NewRow()
                row(0) = 0
                row(1) = "---Select---"
                dt.Rows.InsertAt(row, 0)

                'Assign DataTable as DataSource.
                cmbULotFailNo.DataSource = dt
                cmbULotFailNo.DisplayMember = "BagSrNo"
                cmbULotFailNo.ValueMember = "UsedBagId"

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally
                dr.Close()
                dbManager.CloseConnection(connection)
            End Try
        End If
    End Sub
    Private Sub clearReceiveAllData()

        'txtRLotFailId.Tag = ""
        'txtRLotFailId.Clear()
        txtRTransId.Tag = ""
        txtRTransId.Clear()

        RTransDt.Value = DateTime.Now
        cmbRBagtype.SelectedIndex = 0
        cmbRBagNo.SelectedIndex = 0

        txtRLotFailWt.Clear()
        txtRLotFailPr.Clear()
        txtRWtOnScale.Clear()
        txtRRecieveWt.Clear()
        txtRSample.Clear()
        txtRTotalWt.Clear()
        txtRCarbon.Clear()
        txtRGrossLoss.Clear()

        dgvCLotFail.AutoGenerateColumns = False
        dgvCLotFail.DataSource = fetchAllRecords()

        ''lblRowCount.Text = "Total Count : " & dgvLotFail.Rows.Count & ""

    End Sub
#End Region

#Region "UpdateLotFailBag"
    Private Sub FetchLotFailBagDetails()

        Dim dtData As DataTable = New DataTable()

        If tbLotFail.SelectedIndex = 1 Then

            Try
                Dim parameters = New List(Of SqlParameter)()
                parameters.Clear()

                With parameters
                    .Add(dbManager.CreateParameter("@ActionType", "SearchByBagNo", DbType.String))
                    .Add(dbManager.CreateParameter("@BagNumber", Convert.ToString(cmbRBagNo.SelectedItem.Text), DbType.String))
                End With

                dtData = dbManager.GetDataTable("SP_LotFail_Select", CommandType.StoredProcedure, parameters.ToArray())

                If dtData.Rows.Count > 0 Then
                    txtRLotFailWt.Text = dtData.Rows(0).Item("LotFailWt").ToString()
                    txtRLotFailPr.Text = dtData.Rows(0).Item("LotFailPr").ToString()
                Else
                    MessageBox.Show("No Data Found !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally
            End Try
        ElseIf tbLotFail.SelectedIndex = 2 Then
            Try
                Dim parameters = New List(Of SqlParameter)()
                parameters.Clear()

                With parameters
                    .Add(dbManager.CreateParameter("@ActionType", "SearchByBagNo", DbType.String))
                    .Add(dbManager.CreateParameter("@BagSrNo", Convert.ToString(cmbULotFailNo.SelectedItem.Text.Trim), DbType.String))
                End With

                dtData = dbManager.GetDataTable("SP_UsedBags_Select", CommandType.StoredProcedure, parameters.ToArray())

                If dtData.Rows.Count > 0 Then

                    Me.RadCollapsiblePanel1.ExpandDirection = RadDirection.Down

                    txtUTransId.Text = dtData.Rows(0).Item("UsedBagId").ToString()
                    UTransDt.Text = dtData.Rows(0).Item("UsedBagDt").ToString()

                    txtUreceiveWt.Text = dtData.Rows(0).Item("RecieveWt").ToString()
                    txtUreceivePr.Text = dtData.Rows(0).Item("ReportPr").ToString()
                    txtUreceiveFineWt.Text = dtData.Rows(0).Item("RecieveFineWt").ToString()

                    txtUIssueWt.Text = dtData.Rows(0).Item("IssueWt").ToString()
                    txtUIssuePr.Text = dtData.Rows(0).Item("IssuePr").ToString()
                    txtUIssueFineWt.Text = dtData.Rows(0).Item("IssueFineWt").ToString()

                    txtUWtOnScale.Text = dtData.Rows(0).Item("WtOnScale").ToString()
                    txtUcarbonReceive.Text = dtData.Rows(0).Item("CarbonRecieve").ToString()

                    txtUGrossLoss.Text = dtData.Rows(0).Item("GrossLossWt").ToString()

                End If
            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally

            End Try
        End If
    End Sub
    Private Sub clearUpdateAllData()

        txtUTransId.Tag = ""
        txtUTransId.Clear()

        UTransDt.Value = DateTime.Now()

        cmbUpdBagtype.SelectedIndex = 0
        cmbULotFailNo.SelectedIndex = 0

        txtUreceivePr.Clear()
        txtUreceiveWt.Clear()
        txtUreceiveFineWt.Clear()
        txtUGrossLoss.Clear()
        txtULossFine.Clear()

        txtUIssuePr.Clear()
        txtUIssueWt.Clear()
        txtUIssueFineWt.Clear()
        txtUWtOnScale.Clear()
        txtUcarbonReceive.Clear()

        txtUGrossLoss.Clear()
        txtULossFine.Clear()

        dgvCLotFail.AutoGenerateColumns = False
        dgvCLotFail.DataSource = fetchAllRecords()
        dgvCLotFail.EnableFiltering = True
        dgvCLotFail.MasterTemplate.EnableFiltering = True

    End Sub
    Private Sub txtRLWtOnScale_Leave(sender As Object, e As EventArgs) Handles txtRWtOnScale.Leave
        txtRWtOnScale.Text = Format(Val(txtRWtOnScale.Text), "0.00")
    End Sub
    Private Sub txtLRecieveWt_Leave(sender As Object, e As EventArgs) Handles txtRRecieveWt.Leave
        txtRRecieveWt.Text = Format(Val(txtRRecieveWt.Text), "0.00")
    End Sub
    Private Sub txtLRSampleWt_Leave(sender As Object, e As EventArgs) Handles txtRSample.Leave
        txtRSample.Text = Format(Val(txtRSample.Text), "0.00")
    End Sub
    Private Sub txtLRCarbon_Leave(sender As Object, e As EventArgs) Handles txtRCarbon.Leave
        txtRCarbon.Text = Format(Val(txtRCarbon.Text), "0.00")
    End Sub
    Private Sub btnUSave_Click(sender As Object, e As EventArgs) Handles btnUSave.Click
        If Not UpdateValidate_Fields() Then Exit Sub

        Try

            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "UpdateLotFailBag", DbType.String))
                .Add(dbManager.CreateParameter("@UReportPr", Val(txtUreceivePr.Text), DbType.Decimal))
                .Add(dbManager.CreateParameter("@UId", Val(txtUTransId.Text), DbType.Int16))
                .Add(dbManager.CreateParameter("@UBagSrNo", Convert.ToString(cmbULotFailNo.SelectedItem.Text), DbType.String))
            End With

            dbManager.Insert("SP_UsedBags_Update", CommandType.StoredProcedure, parameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.clearUpdateAllData()
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub btnRSave_Click(sender As Object, e As EventArgs) Handles btnRSave.Click
        If Not ReceiveValidate_Fields() Then Exit Sub

        If String.IsNullOrWhiteSpace(cmbRBagNo.Text.Trim()) Then
            MessageBox.Show("Select Bag No !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            cmbRBagNo.Focus()
        Else
            Try

                Dim parameters = New List(Of SqlParameter)()
                parameters.Clear()

                With parameters
                    .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
                    .Add(dbManager.CreateParameter("@UBagDt", RTransDt.Value.ToString(), DbType.DateTime))
                    .Add(dbManager.CreateParameter("@UItemId", Val(cmbRBagtype.SelectedValue), DbType.Int16))
                    .Add(dbManager.CreateParameter("@UBagSrNo", Convert.ToString(cmbRBagNo.SelectedItem), DbType.String))
                    .Add(dbManager.CreateParameter("@UIssueWt", Val(txtRLotFailWt.Text), DbType.Decimal))
                    .Add(dbManager.CreateParameter("@UIssuePr", Val(txtRLotFailPr.Text), DbType.Decimal))

                    .Add(dbManager.CreateParameter("@UWtOnScale", Val(txtRWtOnScale.Text), DbType.Decimal))
                    .Add(dbManager.CreateParameter("@URecieveWt", Val(txtRRecieveWt.Text), DbType.Decimal))
                    .Add(dbManager.CreateParameter("@UTFSample", Val(txtRSample.Text), DbType.Decimal))
                    .Add(dbManager.CreateParameter("@UCarbonRecieve", Val(txtRCarbon.Text), DbType.Decimal))

                    .Add(dbManager.CreateParameter("@UCreatedBy", UserName.Trim(), DbType.String))
                End With

                dbManager.Insert("SP_UsedBags_Save", CommandType.StoredProcedure, parameters.ToArray())

                MessageBox.Show("Data Saved !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                clearReceiveAllData()
            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            End Try
        End If
    End Sub
    Private Sub txtRLWtOnScale_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRWtOnScale.KeyPress
        numdotkeypress(e, txtRWtOnScale, Me)
    End Sub
    Private Sub txtLRecieveWt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRRecieveWt.KeyPress
        numdotkeypress(e, txtRRecieveWt, Me)
    End Sub
    Private Sub txtLRSampleWt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRSample.KeyPress
        numdotkeypress(e, txtRSample, Me)
    End Sub
    Private Sub txtLRCarbon_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRCarbon.KeyPress
        numdotkeypress(e, txtRCarbon, Me)
    End Sub
    Private Sub frmLotFailBag_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Tab Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region
    Private Sub btnCCancel_Click(sender As Object, e As EventArgs) Handles btnCCancel.Click
        Me.clearCreateAllData()
    End Sub
    Private Sub btnUCancel_Click(sender As Object, e As EventArgs) Handles btnUCancel.Click
        Me.clearUpdateAllData()
    End Sub
    Private Sub btnRCancel_Click(sender As Object, e As EventArgs) Handles btnRCancel.Click
        Me.clearCreateAllData()
    End Sub
    Private Sub cmbRLotFailNo_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbRBagNo.SelectedIndexChanged
        If cmbRBagNo.SelectedIndex > 0 Then
            Me.FetchLotFailBagDetails()
        End If
    End Sub
    Private Sub cmbULotFailNo_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbULotFailNo.SelectedIndexChanged
        If cmbULotFailNo.SelectedIndex > 0 Then
            Me.FetchLotFailBagDetails()
        End If
    End Sub
    Private Sub cmbCLotNo_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbCLotNo.SelectedIndexChanged
        If Convert.ToInt32(cmbCLotNo.SelectedIndex) > 0 Then
            Me.getLastLotNoVAmt()
        End If
    End Sub
    Private Sub cmbCLotNo_Enter(sender As Object, e As EventArgs) Handles cmbCLotNo.Enter
        cmbCLotNo.ShowDropDown()
    End Sub
    Private Sub txtRTotalWt_TextChanged(sender As Object, e As EventArgs) Handles txtRTotalWt.TextChanged
        Try
            txtRGrossLoss.Text = Format(Val(txtRLotFailWt.Text) - Val(txtRTotalWt.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtLRCarbon_TextChanged(sender As Object, e As EventArgs) Handles txtRCarbon.TextChanged
        Try
            txtRGrossLoss.Text = Format(Val(txtRLotFailWt.Text) - Val(txtRTotalWt.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmbRBagtype_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbRBagtype.SelectedIndexChanged
        If cmbRBagtype.SelectedIndex > 0 Then
            Me.fillRLotFailBagNo()
        End If
    End Sub
    Private Sub cmbUBagtype_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbUpdBagtype.SelectedIndexChanged
        If cmbUpdBagtype.SelectedIndex > 0 Then
            Me.fillULotFailBagNo()
        End If
    End Sub
    Private Sub txtUreceivePr_Leave(sender As Object, e As EventArgs) Handles txtUreceivePr.Leave
        txtUreceivePr.Text = Format(Val(txtUreceivePr.Text), "0.00")
    End Sub
    Private Sub btnCExit_Click(sender As Object, e As EventArgs) Handles btnCExit.Click
        Me.Close()
    End Sub
    Private Sub btnRExit_Click(sender As Object, e As EventArgs) Handles btnRExit.Click
        Me.Close()
    End Sub
    Private Sub btnUExit_Click(sender As Object, e As EventArgs) Handles btnUExit.Click
        Me.Close()
    End Sub
    Private Sub txtUIssueWt_TextChanged(sender As Object, e As EventArgs) Handles txtUIssueWt.TextChanged
        Try
            txtUGrossLoss.Text = Format(Val(txtUIssueWt.Text) - Val(txtUreceiveWt.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function Validate_Fields() As Boolean
        Try

            If String.IsNullOrWhiteSpace(cmbCLotNo.Text) Then
                MessageBox.Show("Select Lot No. !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbCLotNo.Focus()
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Sub FillBagType()

        Dim connection As SqlConnection = Nothing
        Dim dt As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            parameters.Add(dbManager.CreateParameter("@ActionType", "FillLotFailBag", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_BagMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim Odt As DataTable = New DataTable()

        Odt.Load(dr)

        Dim Cdt As DataTable = Odt.Copy()

        If tbLotFail.SelectedIndex = 1 Then
            Try
                cmbRBagtype.DataSource = Nothing
                cmbRBagtype.Items.Clear()

                'Insert the Default Item to DataTable.
                Dim frow As DataRow = Odt.NewRow()
                frow(0) = 0
                frow(1) = "---Select---"
                Odt.Rows.InsertAt(frow, 0)

                'Assign DataTable as DataSource.
                cmbRBagtype.DataSource = Odt
                cmbRBagtype.DisplayMember = "ItemName"
                cmbRBagtype.ValueMember = "ItemId"
                cmbRBagtype.AutoCompleteMode = AutoCompleteMode.Suggest

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally
                dr.Close()
                dbManager.CloseConnection(connection)
            End Try
        Else
            Try
                cmbUpdBagtype.DataSource = Nothing
                cmbUpdBagtype.Items.Clear()

                ''Insert the Default Item to DataTable.
                Dim trow As DataRow = Cdt.NewRow()
                trow(0) = 0
                trow(1) = "---Select---"
                Cdt.Rows.InsertAt(trow, 0)

                'Assign DataTable as DataSource.
                cmbUpdBagtype.DataSource = Cdt
                cmbUpdBagtype.DisplayMember = "ItemName"
                cmbUpdBagtype.ValueMember = "ItemId"
                cmbUpdBagtype.AutoCompleteMode = AutoCompleteMode.Suggest
            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally
                dr.Close()
                dbManager.CloseConnection(connection)
            End Try
        End If
    End Sub
    Private Function ReceiveValidate_Fields() As Boolean
        Try

            If String.IsNullOrWhiteSpace(cmbRBagtype.Text.Trim()) Or Convert.ToInt32(cmbRBagtype.SelectedIndex) = -1 Then
                MessageBox.Show("Select Bag Type !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbRBagtype.Focus()
            ElseIf String.IsNullOrWhiteSpace(cmbRBagNo.Text.Trim()) Then
                MessageBox.Show("Select Lot No...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbRBagNo.Focus()
            ElseIf txtRWtOnScale.Text.Trim.Length = 0 Then
                MessageBox.Show("Enter Wt. On Scale !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtRWtOnScale.Focus()
                Return False
            ElseIf txtRRecieveWt.Text.Trim.Length = 0 Then
                MessageBox.Show("Enter Lagdi Received !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtRRecieveWt.Focus()
                Return False
            ElseIf txtRSample.Text.Trim.Length = 0 Then
                MessageBox.Show("Enter Sample Received !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtRSample.Focus()
                Return False
            ElseIf txtRCarbon.Text.Trim.Length = 0 Then
                MessageBox.Show("Enter Carbon Recived !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtRCarbon.Focus()
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Function UpdateValidate_Fields() As Boolean
        Try

            If String.IsNullOrWhiteSpace(cmbUpdBagtype.Text.Trim()) Or Convert.ToInt32(cmbUpdBagtype.SelectedIndex) = -1 Then
                MessageBox.Show("Select Bag Type !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbUpdBagtype.Focus()
            ElseIf String.IsNullOrWhiteSpace(cmbULotFailNo.Text.Trim()) Then
                MessageBox.Show("Select Bag No...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbULotFailNo.Focus()
            ElseIf txtUreceivePr.Text.Trim.Length = 0 Then
                MessageBox.Show("Enter Receive % !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtUreceivePr.Focus()
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
End Class