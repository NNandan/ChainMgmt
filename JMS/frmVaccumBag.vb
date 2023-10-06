Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmVaccumBag
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState
    Dim blnEditMode As Boolean = False
    Dim dbManager As New SqlHelper()
    Dim Objcn As SqlConnection = New SqlConnection()
    Private Property Fr_Mode() As FormState
        Get
            Return mFr_State
        End Get
        Set(ByVal value As FormState)
            mFr_State = value
            Select Case mFr_State
                Case FormState.AStateMode
                    '    Me.Lbl_Tran_Mode.Text = "NEW MODE"
                    '    Me.txtAccountName.BackColor = Color.LemonChiffon
                    Me.btnSave.Enabled = True
                    Me.btnSave.Text = "&Save"
                Case FormState.EStateMode
                    'Me.Lbl_Tran_Mode.Text = "EDIT MODE"
                    'Me.txtAccountName.BackColor = Color.LemonChiffon
                    Me.btnSave.Text = "&Update"
            End Select
        End Set
    End Property
    Private Sub frmVaccumeBag_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.EnbledBtn()
        Me.FillBagType()
        Me.FillOperation()
        Me.FillLabour()
        Me.fillRecBagNo()
        Me.fillUpdBagNo()
        Me.FillUpdatedData()
        lblMaxNo.Visible = False
        txtMaxNo.Visible = False
    End Sub
    Private Sub fillUpdBagNo()
        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "fillUVaccumeBag", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_UsedBags_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            ''Insert the Default Item to DataTable.
            Dim newBlankRow As DataRow = dt.NewRow()
            dt.Rows.InsertAt(newBlankRow, 0)
            ''Assign DataTable as DataSource.
            cmbUpdBagNo.DataSource = dt
            cmbUpdBagNo.AutoFilter = True
            cmbUpdBagNo.DisplayMember = "BagSrNo"
            cmbUpdBagNo.ValueMember = "BagSrNo"
            cmbUpdBagNo.Text = ""
            cmbUpdBagNo.Refresh()

            cmbUpdBagNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbUpdBagNo.BestFitColumns(True, False)

            cmbUpdBagNo.Columns(0).Width = 125
            cmbUpdBagNo.Columns(1).Width = 175
            cmbUpdBagNo.Columns(1).TextAlignment = ContentAlignment.MiddleLeft

            Me.cmbUpdBagNo.MultiColumnComboBoxElement.DropDownWidth = 200
            Me.BackColor = Color.White
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub FillOperation()
        Dim connection As SqlConnection = Nothing
        Dim dt As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FillVacuumOperation", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_BagMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        dt.Load(dr)

        If tbVaccumeBag.SelectedIndex = 0 Then
            Try
                cmbOperation.DataSource = Nothing
                cmbOperation.Items.Clear()

                'Insert the Default Item to DataTable.
                Dim row As DataRow = dt.NewRow()
                row(0) = 0
                row(1) = "---Select---"
                dt.Rows.InsertAt(row, 0)
                'Assign DataTable as DataSource.
                cmbOperation.DataSource = dt
                cmbOperation.DisplayMember = "OperationName"
                cmbOperation.ValueMember = "OperationId"
            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally
                dr.Close()
                dbManager.CloseConnection(connection)
            End Try
        End If
    End Sub
    Private Sub FillLabour()
        Dim connection As SqlConnection = Nothing
        Dim dt As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FillVacOperationLabour", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_BagMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        dt.Load(dr)

        If tbVaccumeBag.SelectedIndex = 0 Then
            Try
                cmbLabour.DataSource = Nothing
                cmbLabour.Items.Clear()

                'Insert the Default Item to DataTable.
                Dim row As DataRow = dt.NewRow()
                row(0) = 0
                row(1) = "---Select---"
                dt.Rows.InsertAt(row, 0)
                'Assign DataTable as DataSource.
                cmbLabour.DataSource = dt
                cmbLabour.DisplayMember = "LabourName"
                cmbLabour.ValueMember = "ToLabourId"
            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally
                dr.Close()
                dbManager.CloseConnection(connection)
            End Try
        End If
    End Sub
    Private Sub bindVacuumBag()
        Dim dt As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "GetVaccumData", DbType.String))
            '.Add(dbManager.CreateParameter("@BId", Val(cmbCBagtype.SelectedValue), DbType.Int16))
            .Add(dbManager.CreateParameter("@OId", Val(cmbOperation.SelectedValue), DbType.Int16))
            .Add(dbManager.CreateParameter("@LId", Val(cmbLabour.SelectedValue), DbType.Int16))
        End With

        dt = dbManager.GetDataTable("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray())

        If dt.Rows.Count = 0 Then
            MessageBox.Show("No Data Exists !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            dgvVacuumBag.DataSource = dt
            dgvVacuumBag.EnableFiltering = True
            dgvVacuumBag.MasterTemplate.ShowFilteringRow = False
            dgvVacuumBag.MasterTemplate.ShowHeaderCellButtons = True

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally

        End Try
    End Sub
    Private Sub EnbledBtn()
        btnSave.Enabled = True
        btnCancel.Enabled = True
    End Sub
    Private Sub DisableBtn()
        btnSave.Enabled = True
        btnCancel.Enabled = True
    End Sub
    Private Sub FillBagType()
        Dim connection As SqlConnection = Nothing
        Dim dt As DataTable = New DataTable()
        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()
        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FillVacuumBag", DbType.String))
        End With
        Dim dr = dbManager.GetDataReader("SP_BagMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        dt.Load(dr)
        If tbVaccumeBag.SelectedIndex = 0 Then
            Try
                cmbCBagtype.DataSource = Nothing
                cmbCBagtype.Items.Clear()

                'Insert the Default Item to DataTable.
                Dim row As DataRow = dt.NewRow()
                row(0) = 0
                row(1) = "---Select---"
                dt.Rows.InsertAt(row, 0)
                'Assign DataTable as DataSource.
                cmbCBagtype.DataSource = dt
                cmbCBagtype.DisplayMember = "ItemName"
                cmbCBagtype.ValueMember = "ItemId"
            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally
                dr.Close()
                dbManager.CloseConnection(connection)
            End Try
        End If
    End Sub
    Private Sub Clear_CForm()
        cmbOperation.SelectedIndex = 0
        cmbCBagtype.SelectedIndex = 0
        cmbLabour.SelectedIndex = 0

        Me.FillOperation()
        Me.FillBagType()
        Me.FillLabour()

        dgvVacuumBag.DataSource = Nothing

        lblMaxNo.Visible = False
        txtMaxNo.Visible = False

        cmbCBagtype.Enabled = True
        cmbOperation.Enabled = True
        cmbLabour.Enabled = True

        lblVacuumTotal.Text = "0.00"
        lblFineTotal.Text = "0.00"
        lblReceivePrTotal.Text = "0.00"

        btnSave.Text = "&Save"

        If dgvVacuumBag.RowCount > 0 Then
            dgvVacuumBag.RowCount = 0
        End If
    End Sub
    Private Sub btnUCancel_Click(sender As Object, e As EventArgs) Handles btnUCancel.Click
        Try
            Call Clear_UForm()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Clear_RForm()
        Try

            Me.RTransDt.CustomFormat = "dd/MM/yyyy"
            Me.UTransDt.Value = DateTime.Now

            cmbRBagNo.Enabled = True
            cmbRBagNo.Text = ""

            txtRIssueWt.Clear()
            txtRIssuePr.Clear()
            txtRBagName.Clear()
            txtRWtOnScale.Clear()
            txtRRecieveWt.Clear()

            txtRSample.Clear()
            txtRTotalWt.Clear()

            txtRCarbon.Clear()
            txtRGrossLoss.Clear()
            txtRBagName.Clear()

            dgvRVacuumBag.DataSource = Nothing

            btnRSave.Text = "&Save"
            BtnREdit.Enabled = True

            Me.fillRecBagNo()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnRCancel_Click(sender As Object, e As EventArgs) Handles btnRCancel.Click
        Try
            Call Clear_RForm()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnUSave_Click(sender As Object, e As EventArgs) Handles btnUSave.Click
        If Not UpdateValidate_Fields() Then Exit Sub
        Try
            Dim parameters = New List(Of SqlParameter)()
            If btnUSave.Text = "&Save" Then
                With parameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@ActionType", "UpdateReportPr", DbType.String))
                    .Add(dbManager.CreateParameter("@TId", Val(txtUTransId.Text.Trim()), DbType.Int16))
                    .Add(dbManager.CreateParameter("@ReportPr", Convert.ToDecimal(txtUReceivePr.Text.Trim()), DbType.Decimal))
                    .Add(dbManager.CreateParameter("@LossWt", Convert.ToDecimal(txtUpdLossFine.Text.Trim()), DbType.Decimal))
                    .Add(dbManager.CreateParameter("@BagNo", Convert.ToString(cmbUpdBagNo.EditorControl.CurrentRow.Cells(0).Value), DbType.String))
                End With
                dbManager.Update("SP_UsedBagNo_Update", CommandType.StoredProcedure, parameters.ToArray())
                MessageBox.Show("Data Saved !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.btnUCancel_Click(sender, e)
                Me.FillUpdatedData()
            Else
                With parameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@ActionType", "UpdateReportPr", DbType.String))
                    .Add(dbManager.CreateParameter("@TId", Val(txtUTransId.Text.Trim()), DbType.Int16))
                    .Add(dbManager.CreateParameter("@ReportPr", Convert.ToDecimal(txtUReceivePr.Text.Trim()), DbType.Decimal))
                    .Add(dbManager.CreateParameter("@LossWt", Convert.ToDecimal(txtUpdLossFine.Text.Trim()), DbType.Decimal))
                    .Add(dbManager.CreateParameter("@BagNo", Convert.ToString(cmbUpdBagNo.Text.Trim), DbType.String))
                End With
                dbManager.Update("SP_UsedBagNo_Update", CommandType.StoredProcedure, parameters.ToArray())
                MessageBox.Show("Data Updated !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.btnUCancel_Click(sender, e)
                btnUSave.Text = "&Save"
                btnUEdit.Enabled = True
                Me.FillUpdatedData()
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
        End Try
    End Sub
    Private Sub FillUpdatedData()
        Dim dtable As DataTable = fetchAllDetails()

        Try
            dgvFinalUpdate.DataSource = dtable
            dgvFinalUpdate.ReadOnly = True
            dgvFinalUpdate.MasterTemplate.ShowFilteringRow = False
            dgvFinalUpdate.MasterTemplate.ShowHeaderCellButtons = True
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally

        End Try
    End Sub
    Private Function fetchAllDetails() As DataTable
        Dim dtData As DataTable = New DataTable()
        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchVUsedUBagData", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_UsedBags_Select", CommandType.StoredProcedure, parameters.ToArray())
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
        Return dtData
    End Function
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If btnSave.Text = "&Save" Then
                If dgvVacuumBag.RowCount > 0 Then
                    Dim TmpLotNo As String = Nothing
                    Dim Dt As DataTable = Me.UpdateVacuumSrNo()
                    TmpLotNo = Dt.Rows(0).Item(0)
                    MessageBoxTimer(TmpLotNo)
                    Me.FillBagType()
                    Me.fillRecBagNo()
                    Me.fillUpdBagNo()
                    Me.btnCancel_Click(sender, e)
                End If
                dgvVacuumBag.RowCount = 0
            Else
                Try
                    If Not cmbCBagtype.Text.Trim = "" Then
                        If (MsgBox("Are You Sure To Update This Scrap Bag ?", vbYesNo + vbDefaultButton2 + vbQuestion, "User : " + UserName.Trim()) = vbYes) Then
                            If dgvVacuumBag.RowCount > 0 Then

                                Dim parameters = New List(Of SqlParameter)()

                                With parameters
                                    .Clear()
                                    .Add(dbManager.CreateParameter("@ActionType", "SetVaccumeBagNoToNULL", DbType.String))
                                    .Add(dbManager.CreateParameter("@BagSrNo", Convert.ToString(txtMaxNo.Text.Trim), DbType.String))
                                End With

                                dbManager.Delete("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray())
                                Me.UpdateSameVaccumeBag()
                                Me.FillBagType()
                                Me.fillRecBagNo()
                                Me.fillUpdBagNo()
                                btnSave.Text = "&Save"
                                Me.btnCancel_Click(sender, e)
                            End If
                            dgvVacuumBag.RowCount = 0
                        End If
                    Else
                        Me.btnCancel_Click(sender, e)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error:- " & ex.Message)
                End Try
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub UpdateSameVaccumeBag()
        Dim alParaval As New ArrayList

        Dim TranId As String = Nothing
        Dim IRowCount As Integer = 0
        Dim iValue As Integer = 0

        'alParaval.Add(cmbCBagtype.Tag)

        If dgvVacuumBag.Rows.Count > 0 Then
            For Each row As GridViewRowInfo In dgvVacuumBag.Rows
                If row.Cells(0).Value = True Then
                    If TranId = "" Then
                        TranId = Val(row.Cells(7).Value)
                    Else
                        TranId = TranId & "|" & Val(row.Cells(7).Value)
                    End If
                Else

                End If
                IRowCount += 1
            Next
            alParaval.Add(TranId)

            Try
                Dim Dparameters = New List(Of SqlParameter)()

                With Dparameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@ActionType", "UpdateVaccumeBagNo", DbType.String))
                    .Add(dbManager.CreateParameter("@TId", alParaval.Item(iValue), DbType.String))
                    iValue += 1
                    .Add(dbManager.CreateParameter("@GridCount", IRowCount, DbType.Int16))
                    .Add(dbManager.CreateParameter("@BagSrNo", txtMaxNo.Text.Trim, DbType.String))
                End With

                dbManager.Update("SP_VaccumeSameBag_Update", CommandType.StoredProcedure, Dparameters.ToArray())

                MessageBox.Show("Vaccume Bag " + txtMaxNo.Text.Trim + " Update Succesfully..!!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Call Clear_CForm()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Clear_UForm()
        Try
            Me.UTransDt.CustomFormat = "dd/MM/yyyy"
            UTransDt.Value = DateTime.Now

            txtUTransId.Clear()

            cmbUpdBagNo.Enabled = True
            cmbUpdBagNo.SelectedIndex = 0

            txtUBagName.Clear()
            txtUReceivePr.Clear()
            txtUreceiveWt.Clear()
            txtUreceiveFineWt.Clear()
            txtUGrossLoss.Clear()
            txtUpdLossFine.Clear()
            txtUissuePr.Clear()
            txtUissueWt.Clear()
            txtUissueFineWt.Clear()
            txtUWtOnScale.Clear()
            txtUcarbonReceive.Clear()
            txtUGrossLoss.Text = ""
            txtUpdLossFine.Text = ""

            btnUSave.Text = "&Save"
            btnUEdit.Enabled = True

            fillUpdBagNo()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub frmVaccumeBag_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                If MsgBox("Wish To Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Me.Close()
            ElseIf e.KeyCode = Keys.Tab Then
                SendKeys.Send("{Tab}")
                SendKeys.Send("{HOME}+{END}")
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmbCBagtype_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbOperation.SelectedIndexChanged
        'If Convert.ToInt32(cmbOperation.SelectedIndex) > 0 Then
        '    Me.bindVacuumBag()

        '    If dgvVacuumBag.Rows.Count > 0 Then
        '        Me.DisableBtn()
        '    End If
        'End If
    End Sub
    Private Sub fetchUpdateVacuumBag(ByVal sBagNo As String, Optional sMode As String = Nothing)
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "SearchByBagNo", DbType.String))
                .Add(dbManager.CreateParameter("@BagSrNo", Convert.ToString(sBagNo), DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_UsedBags_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                txtUTransId.Text = dtData.Rows(0).Item("UsedBagId").ToString()
                'UTransDt.Text = dtData.Rows(0).Item("UsedBagDt").ToString()
                cmbUpdBagNo.Text = dtData.Rows(0).Item("BagSrNo").ToString()
                txtUBagName.Text = dtData.Rows(0).Item("ItemName").ToString()
                txtUissueWt.Text = dtData.Rows(0).Item("IssueWt").ToString()
                txtUissuePr.Text = dtData.Rows(0).Item("IssuePr").ToString()
                txtUissueFineWt.Text = dtData.Rows(0).Item("IssueFineWt").ToString()
                txtUreceiveWt.Tag = dtData.Rows(0).Item("GrossReceive").ToString()
                txtUreceiveWt.Text = dtData.Rows(0).Item("ReceiveWt").ToString()
                txtUReceivePr.Text = dtData.Rows(0).Item("ReportPr").ToString()
                txtUreceiveFineWt.Text = dtData.Rows(0).Item("ReceiveFineWt").ToString()
                txtUWtOnScale.Text = dtData.Rows(0).Item("WtOnScale").ToString()
                txtUcarbonReceive.Text = dtData.Rows(0).Item("CarbonReceive").ToString()
            End If

            txtUReceivePr.Focus()

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally

        End Try
    End Sub
    Private Sub btnRSave_Click(sender As Object, e As EventArgs) Handles btnRSave.Click
        If Not ReceiveValidate_Fields() Then Exit Sub

        Try
            Dim parameters = New List(Of SqlParameter)()

            If btnRSave.Text = "&Save" Then
                With parameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
                    .Add(dbManager.CreateParameter("@UBagDt", RTransDt.Value.ToString(), DbType.DateTime))
                    .Add(dbManager.CreateParameter("@UItemName", Convert.ToString(txtRBagName.Text.Trim), DbType.String))

                    .Add(dbManager.CreateParameter("@UBagSrNo", Convert.ToString(cmbRBagNo.EditorControl.CurrentRow.Cells(1).Value), DbType.String))

                    .Add(dbManager.CreateParameter("@UIssueWt", Val(txtRIssueWt.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UIssuePr", Val(txtRIssuePr.Text), DbType.String))

                    .Add(dbManager.CreateParameter("@UWtOnScale", Val(txtRWtOnScale.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UReceiveWt", Val(txtRRecieveWt.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UTFSample", Val(txtRSample.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UCarbonReceive", Val(txtRCarbon.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@ULossWt", Val(txtRGrossLoss.Text), DbType.Decimal))

                    .Add(dbManager.CreateParameter("@UCreatedBy", UserName.Trim(), DbType.String))
                End With

                dbManager.Insert("SP_UsedBags_Save", CommandType.StoredProcedure, parameters.ToArray())

                Dim tparameters = New List(Of SqlParameter)()

                With tparameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@ActionType", "UpdateVacuumSt", DbType.String))
                    .Add(dbManager.CreateParameter("@BagNo", Convert.ToString(cmbRBagNo.EditorControl.CurrentRow.Cells(1).Value), DbType.String))
                End With

                dbManager.Update("SP_UsedBagNo_Update", CommandType.StoredProcedure, tparameters.ToArray())

                MessageBox.Show("Data Saved !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            If btnRSave.Text = "&Update" Then
                With parameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@ActionType", "EditData", DbType.String))
                    '.Add(dbManager.CreateParameter("@UBagDt", RTransDt.Value.ToString(), DbType.DateTime))
                    .Add(dbManager.CreateParameter("@UItemName", Convert.ToString(txtRBagName.Text.Trim), DbType.String))

                    .Add(dbManager.CreateParameter("@UBagSrNo", Convert.ToString(cmbRBagNo.Text.Trim()), DbType.String))

                    .Add(dbManager.CreateParameter("@UIssueWt", Val(txtRIssueWt.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UIssuePr", Val(txtRIssuePr.Text), DbType.String))

                    .Add(dbManager.CreateParameter("@UWtOnScale", Val(txtRWtOnScale.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UReceiveWt", Val(txtRRecieveWt.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UTFSample", Val(txtRSample.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UCarbonReceive", Val(txtRCarbon.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@ULossWt", Val(txtRGrossLoss.Text), DbType.Decimal))

                    .Add(dbManager.CreateParameter("@UCreatedBy", UserName.Trim(), DbType.String))
                End With

                dbManager.Insert("SP_UsedBags_Edit", CommandType.StoredProcedure, parameters.ToArray())

                MessageBox.Show("Data Update !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Me.btnRCancel_Click(sender, e)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            Me.fillRecBagNo()
            Me.fillUpdBagNo()
        End Try
    End Sub
    Private Sub UpdateReceivedData()
        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()
            If BtnREdit.Text = "&Update" Then
                With parameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@ActionType", "UpdateRVaccumeBagData", DbType.String))
                    .Add(dbManager.CreateParameter("@UBagSrNo", Convert.ToString(cmbRBagNo.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UWtOnScale", Val(txtRWtOnScale.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UReceiveWt", Val(txtRRecieveWt.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UTFSample", Val(txtRSample.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UCarbonReceive", Val(txtRCarbon.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UCreatedBy", UserName.Trim(), DbType.String))
                End With
                dbManager.Update("SP_UsedBags_Update", CommandType.StoredProcedure, parameters.ToArray())
                MessageBox.Show("Data Updated !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch
        End Try
    End Sub
    Private Function UpdateVacuumSrNo()
        Dim Dt As DataTable = Nothing
        Dim alParaval As New ArrayList

        Dim BagId As Int16 = 0
        Dim TranId As String = Nothing

        Dim IRowCount As Integer = 0
        Dim iValue As Integer = 0

        alParaval.Add(cmbCBagtype.SelectedValue)

        If dgvVacuumBag.Rows.Count > 0 Then
            For Each row As GridViewRowInfo In dgvVacuumBag.Rows
                If row.Cells(0).Value = True Then
                    If TranId = "" Then
                        TranId = Val(row.Cells(7).Value)
                    Else
                        TranId = TranId & "|" & Val(row.Cells(7).Value)
                    End If
                End If
                IRowCount += 1
            Next

            alParaval.Add(TranId)

            Try

                Dim Dparameters = New List(Of SqlParameter)()

                With Dparameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@ActionType", "UpdateVacuumNo", DbType.String))
                    .Add(dbManager.CreateParameter("@BId", alParaval.Item(iValue), DbType.Int16))
                    iValue += 1
                    .Add(dbManager.CreateParameter("@TId", alParaval.Item(iValue), DbType.String))
                    iValue += 1
                    .Add(dbManager.CreateParameter("@GridCount", IRowCount, DbType.Int16))
                    .Add(dbManager.CreateParameter("@BagType", "V", DbType.String))
                End With

                Dt = dbManager.GetDataTable("SP_UsedBagNo_Update", CommandType.StoredProcedure, Dparameters.ToArray())

                MessageBox.Show("Vaccum Bag Updated !!!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            End Try

        End If
        Return Dt
    End Function
    Sub MessageBoxTimer(ByVal strMsg As String)
        Dim AckTime As Integer, InfoBox As Object
        InfoBox = CreateObject("WScript.Shell")
        'Set the message box to close after 1 seconds
        AckTime = 1
        Select Case InfoBox.Popup("Click OK (" & strMsg.ToString(),
        AckTime, "Bag Created Successfully", 0)
            Case 1, -1
                Exit Sub
        End Select
    End Sub
    Private Sub cmbRBagNo_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs)
        If cmbRBagNo.SelectedIndex >= 0 Then
            Me.bindReceiveGridView()
        End If
    End Sub
    Private Sub BindCreateVacuumBag()
        Dim dtdata As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "GetBhukaData", DbType.String))
            .Add(dbManager.CreateParameter("@BId", Val(cmbOperation.SelectedValue), DbType.Int16))
        End With

        dtdata = dbManager.GetDataTable("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray())
    End Sub
    Private Sub tbVaccumeBag_Click(sender As Object, e As EventArgs) Handles tbVaccumeBag.Click
        If tbVaccumeBag.SelectedIndex = 0 Then     ''for Create Bhuka Bag
            If blnEditMode = False Then
                Me.FillBagType()
            End If
        ElseIf tbVaccumeBag.SelectedIndex = 1 Then ''for Receive Bhuka Bag
            Me.FillBagType()
            Me.Clear_RForm()
        ElseIf tbVaccumeBag.SelectedIndex = 2 Then ''for Update Bhuka Bag
            Me.fillUpdBagNo()
            Me.Clear_UForm()
        ElseIf tbVaccumeBag.SelectedIndex = 3 Then ''for Grid Fill
            Me.FillUpdatedData()
        End If
    End Sub
    Private Sub CalculateTotal()
        Dim sVaccumTotal As Single = 0
        Dim sVaccumFineTotal As Single = 0

        For Each row As GridViewRowInfo In dgvVacuumBag.Rows
            If CBool(row.Cells()(0).Value) = True And Not String.IsNullOrEmpty(row.Cells(4).Value) Then
                sVaccumTotal += Single.Parse(row.Cells(4).Value)
                sVaccumFineTotal += Single.Parse(row.Cells(6).Value)
            End If
        Next

        lblVacuumTotal.Text = Format(sVaccumTotal, "0.00")
        lblFineTotal.Text = Format(sVaccumFineTotal, "0.00")

    End Sub
    Private Sub bindReceiveGridView()
        Dim dt As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "GetVaccumBagDetails", DbType.String))
                .Add(dbManager.CreateParameter("@BagSrNo", Convert.ToString(cmbRBagNo.Text.Trim), DbType.String))
            End With

            dt = dbManager.GetDataTable("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray())

            dgvRVacuumBag.DataSource = Nothing

            If dt.Rows.Count > 0 Then
                dgvRVacuumBag.DataSource = dt
            End If

            Me.ReceiveGridViewTotal()

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub lstVaccumBag_ItemChecked(sender As Object, e As ItemCheckedEventArgs)
        'Me.fillMaxsrno()
    End Sub
    Private Sub txtRRecieveWt_TextChanged(sender As Object, e As EventArgs) Handles txtRRecieveWt.TextChanged
        Try
            txtRTotalWt.Text = Format(Val(txtRRecieveWt.Text) + Val(txtRSample.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtRSample_TextChanged(sender As Object, e As EventArgs) Handles txtRSample.TextChanged
        Try
            txtRTotalWt.Text = Format(Val(txtRRecieveWt.Text) + Val(txtRSample.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtRIssueWt_TextChanged(sender As Object, e As EventArgs) Handles txtRIssueWt.TextChanged
        Try
            'txtRGrossLoss.Text = Format(Val(txtRIssueWt.Text) - Val(txtRRecieveWt.Text) - Val(txtRSample.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtUreceivePr_Leave(sender As Object, e As EventArgs) Handles txtUReceivePr.Leave
        txtUReceivePr.Text = Format(Val(txtUReceivePr.Text), "0.00")
    End Sub
    Private Sub txtUreceivePr_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUReceivePr.KeyPress
        numdotkeypress(e, txtUReceivePr, Me)
    End Sub
    Private Sub dgvFVacuumBag_ValueChanged(sender As Object, e As EventArgs) Handles dgvVacuumBag.ValueChanged
        If dgvVacuumBag.CurrentColumn.Name = "colChkBox" Then
            dgvVacuumBag.EndEdit()
        End If

        Me.CalculateTotal()
    End Sub
    Private Sub txtRWtOnScale_Leave(sender As Object, e As EventArgs) Handles txtRWtOnScale.Leave
        txtRWtOnScale.Text = Format(Val(txtRWtOnScale.Text), "0.00")
    End Sub
    Private Sub txtRRecieveWt_Leave(sender As Object, e As EventArgs)
        txtRWtOnScale.Text = Format(Val(txtRWtOnScale.Text), "0.00")
    End Sub
    Private Sub txtRSample_Leave(sender As Object, e As EventArgs) Handles txtRSample.Leave
        txtRSample.Text = Format(Val(txtRSample.Text), "0.00")
    End Sub
    Private Sub txtRCarbon_Leave(sender As Object, e As EventArgs) Handles txtRCarbon.Leave
        txtRCarbon.Text = Format(Val(txtRCarbon.Text), "0.00")
    End Sub
    Private Sub txtRTotalWt_TextChanged(sender As Object, e As EventArgs) Handles txtRTotalWt.TextChanged
        Try
            txtRGrossLoss.Text = Format(Val(txtRIssueWt.Text) - Val(txtRTotalWt.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtUreceiveFineWt_TextChanged(sender As Object, e As EventArgs) Handles txtUreceiveFineWt.TextChanged
        Try
            txtUpdLossFine.Text = Format(Val(txtUreceiveFineWt.Text) - Val(txtUissueFineWt.Text), "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtUissueFineWt_TextChanged(sender As Object, e As EventArgs) Handles txtUissueFineWt.TextChanged
        Try
            txtUpdLossFine.Text = Format(Val(txtUreceiveFineWt.Text) - Val(txtUissueFineWt.Text), "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ReceiveGridViewTotal()

        Dim dSumOfGrossWt As Decimal = 0
        Dim dSumOfReceivePr As Decimal = 0
        Dim dSumOfFineWt As Decimal = 0

        Try
            For Each row As GridViewRowInfo In dgvRVacuumBag.Rows
                dSumOfGrossWt += CDec(Val(row.Cells(5).Value))
                dSumOfFineWt += CDec(Val(row.Cells(7).Value))
            Next

            dSumOfReceivePr = (dSumOfFineWt / dSumOfGrossWt) * 100
            txtRBagName.Text = cmbRBagNo.EditorControl.CurrentRow.Cells(2).Value.ToString()
            txtRIssueWt.Text = dSumOfGrossWt.ToString("N2")
            txtRIssuePr.Text = dSumOfReceivePr.ToString("N2")

            txtRWtOnScale.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtUreceivePr_TextChanged(sender As Object, e As EventArgs) Handles txtUReceivePr.TextChanged
        Try
            txtUreceiveFineWt.Text = Format((Val(txtUreceiveWt.Text) * Val(txtUReceivePr.Text)) / 100, "0.00")
            txtUpdLossFine.Text = Format(Val(txtUissueFineWt.Text) - Val(txtUreceiveFineWt.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtUissueWt_TextChanged(sender As Object, e As EventArgs) Handles txtUissueWt.TextChanged
        Try
            txtUGrossLoss.Text = Format(Val(txtUissueWt.Text) - Val(txtUreceiveWt.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtUreceiveWt_TextChanged(sender As Object, e As EventArgs) Handles txtUreceiveWt.TextChanged
        Try
            txtUGrossLoss.Text = Format(Val(txtUissueWt.Text) - Val(txtUreceiveWt.Tag), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtRRecieveWt_Leave_1(sender As Object, e As EventArgs) Handles txtRRecieveWt.Leave
        txtRRecieveWt.Text = Format(Val(txtRRecieveWt.Text), "0.00")
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
    Private Sub fillRecBagNo()
        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FillRVaccumeCmb", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_VaccumeBags_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)

        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            'Insert the Default Item to DataTable.
            Dim newBlankRow As DataRow = dt.NewRow()
            dt.Rows.InsertAt(newBlankRow, 0)
            'Assign DataTable as DataSource.
            cmbRBagNo.DataSource = dt
            cmbRBagNo.AutoFilter = True
            cmbRBagNo.DisplayMember = "BagSrNo"
            cmbRBagNo.ValueMember = "BagSrNo"
            cmbRBagNo.Text = ""
            cmbRBagNo.Refresh()

            cmbRBagNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbRBagNo.BestFitColumns(True, False)

            cmbRBagNo.Columns(0).IsVisible = False
            cmbRBagNo.Columns(1).Width = 200
            cmbRBagNo.Columns(1).TextAlignment = ContentAlignment.MiddleLeft

            Me.cmbRBagNo.MultiColumnComboBoxElement.DropDownWidth = 250
            Me.BackColor = Color.White
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub cmbLabour_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbLabour.SelectedIndexChanged
        If cmbOperation.SelectedIndex > 0 And cmbCBagtype.SelectedIndex > 0 Then
            bindVacuumBag()
        End If
    End Sub
    Private Sub BtnREdit_Click(sender As Object, e As EventArgs) Handles BtnREdit.Click
        If cmbRBagNo.Text = "" Then
            MessageBox.Show("Please Select Bag To Edit")
        Else
            blnEditMode = True
            If BtnREdit.Text = "&Edit" Then
                If dgvVacuumBag.RowCount > 0 Then
                    dgvVacuumBag.RowCount = Nothing
                End If

                If dgvRVacuumBag.Rows.Count <= 0 And cmbRBagNo.SelectedIndex <= 0 Then
                    MessageBox.Show("Please Select Bag No To Edit Records")
                Else
                    dgvRVacuumBag.DataSource = Nothing
                    lblMaxNo.Visible = True
                    txtMaxNo.Visible = True
                    btnSave.Text = "&Update"
                    txtMaxNo.Tag = Me.cmbRBagNo.EditorControl.CurrentRow.Cells(0).Value
                    txtMaxNo.Text = Me.cmbRBagNo.EditorControl.CurrentRow.Cells(1).Value
                    Me.FillGridR(cmbRBagNo.Text.Trim)
                    Me.btnRCancel_Click(sender, e)
                    Me.btnUCancel_Click(sender, e)
                    tbVaccumeBag.SelectedIndex = 0
                End If
            Else
                Me.UpdateReceivedData()
                Me.btnUCancel_Click(sender, e)
                BtnREdit.Text = "&Edit"
                btnRSave.Enabled = True
                Me.btnRCancel_Click(sender, e)
                Me.btnUCancel_Click(sender, e)
                Me.fillRecBagNo()
                Me.fillUpdBagNo()
            End If
        End If
    End Sub
    Private Sub FillGridR(ByVal sRBagNo As String)
        Dim dttable As New DataTable
        dttable = fetchAllDetails(CStr(sRBagNo))
        If dttable.Rows.Count > 0 Then
            txtMaxNo.Text = dttable.Rows(0).Item("VaccumeBagNo").ToString()
            cmbCBagtype.Tag = dttable.Rows(0).Item("VItemId").ToString()
            cmbCBagtype.Text = dttable.Rows(0).Item("ItemName").ToString()
            cmbOperation.Tag = dttable.Rows(0).Item("OperationId").ToString()
            cmbOperation.Text = dttable.Rows(0).Item("OperationName").ToString()
            cmbLabour.Tag = dttable.Rows(0).Item("ToLabourId").ToString()
            cmbLabour.Text = dttable.Rows(0).Item("LabourName").ToString()
            cmbCBagtype.Enabled = False
            cmbOperation.Enabled = False
            cmbLabour.Enabled = False
            txtMaxNo.ReadOnly = True
        End If
        FetchGridData(CStr(sRBagNo))
    End Sub
    Private Sub FetchGridData(ByVal sBagNo As String)
        Dim dt As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FetchVaccumeGridData", DbType.String))
            .Add(dbManager.CreateParameter("@BId", Val(cmbCBagtype.Tag), DbType.Int16))
            .Add(dbManager.CreateParameter("@LId", Val(cmbLabour.Tag), DbType.Int16))
            .Add(dbManager.CreateParameter("@BagSrNo", sBagNo, DbType.String))
        End With

        dt = dbManager.GetDataTable("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray())

        If dt.Rows.Count = 0 Then
            MessageBox.Show("No Data Exists !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Try
            For Each ROW As DataRow In dt.Rows
                dgvVacuumBag.DataSource = Nothing
                dgvVacuumBag.Rows.Add(Convert.ToBoolean(ROW("lotNoBoolean")), CStr(ROW("TransDt")), CStr(ROW("OperationName")), CStr(ROW("LotNo")), Format(Val(ROW("VacuumWt")), "0.00"), Format(Val(ROW("ReceivePr")), "0.00"), Format(Val(ROW("FineWt")), "0.00"), CStr(ROW("TransId")), 0)
            Next
            dgvVacuumBag.EnableFiltering = True
            dgvVacuumBag.MasterTemplate.ShowFilteringRow = False
            dgvVacuumBag.MasterTemplate.ShowHeaderCellButtons = True

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally

        End Try
    End Sub
    Private Function fetchAllDetails(ByVal sBagNo As String) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "VaccumeHeaderSelect", DbType.String))
                .Add(dbManager.CreateParameter("@BagSrNo", Trim(sBagNo), DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
        Return dtData
    End Function
    Private Sub cmbRBagNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRBagNo.SelectedIndexChanged
        If cmbRBagNo.SelectedIndex = -1 Then
            With dgvRVacuumBag
                dgvRVacuumBag.DataSource = Nothing
            End With
        ElseIf cmbRBagNo.SelectedIndex > 0 Then
            Me.bindReceiveGridView()
            Me.DisableBtn()
        End If
    End Sub
    Private Sub BtnCDelete_Click(sender As Object, e As EventArgs) Handles BtnCDelete.Click
        If lblMaxNo.Visible = False And txtMaxNo.Visible = False And btnSave.Text = "&Save" Then
            With dgvVacuumBag
                .Rows.Remove(.CurrentRow)
            End With
        Else
            If (MsgBox("Are You Sure To Delete This VaccumeBag ?", vbYesNo + vbDefaultButton2 + vbQuestion, "User : " + UserName.Trim()) = vbYes) Then
                Try
                    If dgvVacuumBag.RowCount > 0 Then
                        Dim parameters = New List(Of SqlParameter)()

                        With parameters
                            .Clear()
                            .Add(dbManager.CreateParameter("@ActionType", "DeleteVaccumeBagSrNo", DbType.String))
                            .Add(dbManager.CreateParameter("@BagSrNo", txtMaxNo.Text, DbType.String))
                        End With

                        dbManager.Delete("SP_Transaction_Delete", CommandType.StoredProcedure, parameters.ToArray())

                        MessageBox.Show("Vaccume Bag Delete Succesfully..!!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        lblMaxNo.Visible = False
                        txtMaxNo.Visible = False
                        btnCancel_Click(sender, e)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error:- " & ex.Message)
                End Try
            End If
        End If

    End Sub
    Private Sub btnUEdit_Click(sender As Object, e As EventArgs) Handles btnUEdit.Click
        If cmbUpdBagNo.SelectedIndex <= 0 Then
            MessageBox.Show("Please Select Bag No To Edit Records")
        Else
            cmbRBagNo.Text = Me.cmbUpdBagNo.EditorControl.CurrentRow.Cells(0).Value
            cmbRBagNo.Enabled = False

            BtnREdit.Enabled = False
            btnRSave.Text = "&Update"
            Me.FillGridU(cmbUpdBagNo.Text.Trim)
            Me.GetSrNo(dgvVacuumBag)

            Me.FetchUsedBagsDetails(cmbRBagNo.Text.Trim)
            tbVaccumeBag.SelectedIndex = 1
        End If
    End Sub
    Private Sub FillGridU(ByVal sUBagNo As String)
        Dim dttable As New DataTable
        dttable = fetchAllDetailsRUpdate(CStr(sUBagNo))
        dgvRVacuumBag.DataSource = Nothing
        dgvRVacuumBag.DataSource = dttable

        Me.ReceiveGridViewTotal()

        Me.FetchUsedBagsDetails(sUBagNo)
        Me.GetSrNo(dgvRVacuumBag)
    End Sub
    Private Sub FetchUsedBagsDetails(ByVal sUBagNo As String)

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchReceivedScrap", DbType.String))
                .Add(dbManager.CreateParameter("@BagSrNo", sUBagNo, DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_UsedBags_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                txtRBagName.Text = dtData.Rows(0).Item("BagName").ToString()
                txtRIssueWt.Text = dtData.Rows(0).Item("IssueWt").ToString()
                txtRIssuePr.Text = dtData.Rows(0).Item("IssuePr").ToString()
                txtRWtOnScale.Text = dtData.Rows(0).Item("WtOnScale").ToString()
                txtRRecieveWt.Text = dtData.Rows(0).Item("ReceiveWt").ToString()
                'txtRTotalWt.Text = dtData.Rows(0).Item("ReceiveWt").ToString()
                txtRSample.Text = dtData.Rows(0).Item("TFSampleWt").ToString()
                txtRCarbon.Text = dtData.Rows(0).Item("CarbonReceive").ToString()
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally

        End Try

    End Sub
    Private Function fetchAllDetailsRUpdate(ByVal sBagNo As String) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FillRVaccumeDetails", DbType.String))
                .Add(dbManager.CreateParameter("@BagSrNo", Trim(sBagNo), DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_VaccumeBags_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
    Sub GetSrNo(ByRef grid As Telerik.WinControls.UI.RadGridView)
        Try
            For Each rowInfo As GridViewRowInfo In dgvVacuumBag.Rows
                rowInfo.Cells(0).Value = rowInfo.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmbUpdBagNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUpdBagNo.SelectedIndexChanged
        If cmbUpdBagNo.SelectedIndex > 0 Then
            Me.fetchUpdateVacuumBag(cmbUpdBagNo.Text.Trim)
        End If
    End Sub
    Private Sub dgvFinalUpdate_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles dgvFinalUpdate.CellDoubleClick
        If dgvFinalUpdate.Rows.Count > 0 Then
            Dim sVacuumBagNo As String = dgvFinalUpdate.Rows(e.RowIndex).Cells(2).Value.ToString()

            Me.btnUCancel_Click(sender, e)
            fetchUpdateVacuumBag(sVacuumBagNo)

            btnUSave.Text = "&Update"
            btnUEdit.Enabled = False
            cmbUpdBagNo.Enabled = False
            tbVaccumeBag.SelectedIndex = 2
        End If
    End Sub
    Private Function fetchAllDetailsById(ByVal UsedDetailsId As String) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchUpdatedBagDataById", DbType.String))
                .Add(dbManager.CreateParameter("@BId", CInt(UsedDetailsId), DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_UsedBags_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
    Private Sub txtRWtOnScale_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRWtOnScale.KeyPress
        numdotkeypress(e, txtRWtOnScale, Me)
    End Sub
    Private Sub txtRRecieveWt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRRecieveWt.KeyPress
        numdotkeypress(e, txtRRecieveWt, Me)
    End Sub
    Private Sub txtRSample_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRSample.KeyPress
        numdotkeypress(e, txtRSample, Me)
    End Sub
    Private Sub txtRCarbon_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRCarbon.KeyPress
        numdotkeypress(e, txtRCarbon, Me)
    End Sub
    Private Sub fillUpdateVacuumSrNo()
        If cmbUpdBagNo.SelectedIndex > 0 Then

            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@BId", Val(cmbUpdBagNo.SelectedValue), DbType.Int16))
                .Add(dbManager.CreateParameter("@ActionType", "GetUpdateVaccumSrNo", DbType.String))
            End With

            Dim dr As SqlDataReader = dbManager.GetDataReader("SP_Transaction_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

            If dr.HasRows = False Then
                MessageBox.Show("No Data Exists !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Exit Sub
            End If

            Try
                While dr.Read
                    'If Not IsDBNull(dr.Item("VaccumeBagNo")) Then
                    '    cmbUBagNo.Items.Add(dr.Item("VaccumeBagNo"))
                    'End If
                End While

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally
                dr.Close()
                Objcn.Close()
            End Try
        End If
    End Sub
    Private Function ReceiveValidate_Fields() As Boolean
        Try
            If String.IsNullOrWhiteSpace(cmbRBagNo.Text.Trim()) Then
                MessageBox.Show("Select Lot No...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbRBagNo.Focus()
            ElseIf Val(txtRWtOnScale.Text) <= 0 Then
                MessageBox.Show("Enter Wt. On Scale !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtRWtOnScale.Focus()
                Return False
            ElseIf Val(txtRRecieveWt.Text) <= 0 Then
                MessageBox.Show("Enter Lagdi Received !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtRRecieveWt.Focus()
                Return False
            ElseIf Val(txtRSample.Text) <= 0 Then
                MessageBox.Show("Enter Sample Received !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtRSample.Focus()
                Return False
            ElseIf Val(txtRCarbon.Text) <= 0 Then
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

            If String.IsNullOrWhiteSpace(cmbUpdBagNo.Text.Trim()) Then
                MessageBox.Show("Select Lot No...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbUpdBagNo.Focus()
            ElseIf Val(txtUReceivePr.Text) <= 0 Then
                MessageBox.Show("Enter Receive % !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtUReceivePr.Focus()
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
End Class