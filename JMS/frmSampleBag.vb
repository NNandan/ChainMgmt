''New
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmSampleBag
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Private mFr_State As FormState
    Dim strSQL As String = Nothing
    Dim dbManager As New SqlHelper()
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
    Private Sub frmSampleBag_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbCBagtype.SelectedIndex = 1

        lblMaxNo.Visible = False
        txtMaxNo.Visible = False

        Me.fillBagType()
        Me.fillRecBagNo()
        Me.fillUpdBagNo()
        Me.FillUpdatedGridView()
    End Sub
    Private Sub fillBagType()
        Dim connection As SqlConnection = Nothing
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FillSampleBag", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_BagMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)

        Dim dt As DataTable = New DataTable()
        dt.Load(dr)

        If tbSampleBag.SelectedIndex = 0 And dt.Rows.Count > 0 Then
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
    Private Sub fillReceiveVacuumSrNo()
        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "GetReceiveSampleSrNo", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)

        Dim dt As DataTable = New DataTable()
        dt.Load(dr)

        Try
            ''Insert the Default Item to DataTable.
            Dim newBlankRow As DataRow = dt.NewRow()
            dt.Rows.InsertAt(newBlankRow, 0)
            ''Assign DataTable as DataSource.
            cmbRBagNo.DataSource = dt
            cmbRBagNo.AutoFilter = True
            cmbRBagNo.DisplayMember = "BagSrNo"
            cmbRBagNo.ValueMember = "BagSrNo"
            cmbRBagNo.Text = ""
            cmbRBagNo.Refresh()
            cmbRBagNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbRBagNo.BestFitColumns(True, False)
            cmbRBagNo.Columns(0).Width = 125
            cmbRBagNo.Columns(1).Width = 175
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
    Private Sub FillUpdatedGridView()
        Dim dtdata As DataTable = fetchAllDetails()

        Try
            dgvFinalUpdate.DataSource = dtdata
            dgvFinalUpdate.EnableFiltering = True
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

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchSUsedUBagData", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_UsedBags_Select", CommandType.StoredProcedure, parameters.ToArray())
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
        Return dtData
    End Function
    Private Sub bindReceiveGridView()
        Dim dt As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "GetSampleBagDetails", DbType.String))
            .Add(dbManager.CreateParameter("@BagSrNo", Convert.ToString(cmbRBagNo.Text), DbType.String))
        End With

        dt = dbManager.GetDataTable("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray())

        dgvReceiveSample.DataSource = Nothing

        Try
            dgvReceiveSample.DataSource = dt
            txtRBagName.Text = dt.Rows(0).Item("BagName").ToString()
            dgvReceiveSample.EnableFiltering = True
            dgvReceiveSample.MasterTemplate.ShowFilteringRow = False
            dgvReceiveSample.MasterTemplate.ShowHeaderCellButtons = True
            Me.ReceivelistViewTotal()
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
        End Try
    End Sub
    Private Sub ReceivelistViewTotal()
        If cmbRBagNo.SelectedIndex > 0 Then
            Dim dSumOfGrossWt As Decimal = 0
            Dim dSumOfReceivePr As Decimal = 0
            Dim dSumOfFineWt As Decimal = 0

            Try
                For Each row As GridViewRowInfo In dgvReceiveSample.Rows
                    dSumOfGrossWt += CDec(Val(row.Cells(3).Value))
                    dSumOfFineWt += CDec(Val(row.Cells(5).Value))
                Next

                dSumOfReceivePr = (dSumOfFineWt / dSumOfGrossWt) * 100
                'txtRBagName.Text = cmbRBagNo.EditorControl.CurrentRow.Cells(2).Value.ToString()
                txtRIssueWt.Text = dSumOfGrossWt.ToString("N2")
                txtRIssuePr.Text = dSumOfReceivePr.ToString("N2")
            Catch ex As Exception
                Throw ex
            End Try
        End If
    End Sub
    Private Sub fetchUpdateSampleBag(ByVal sBagNo As String, Optional sMode As String = Nothing)
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
                txtUIssueFineWt.Text = dtData.Rows(0).Item("IssueFineWt").ToString()
                txtUreceiveWt.Tag = dtData.Rows(0).Item("GrossReceive").ToString()
                txtUreceiveWt.Text = dtData.Rows(0).Item("ReceiveWt").ToString()
                txtUreceivePr.Text = dtData.Rows(0).Item("ReportPr").ToString()
                txtUreceiveFineWt.Text = dtData.Rows(0).Item("ReceiveFineWt").ToString()
                txtUWtOnScale.Text = dtData.Rows(0).Item("WtOnScale").ToString()
                txtUcarbonReceive.Text = dtData.Rows(0).Item("CarbonReceive").ToString()
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
        End Try
    End Sub
    Private Sub Clear_CForm()
        Try
            cmbCBagtype.SelectedIndex = 0
            txtCTransId.Clear()

            rbLabLotSampleTested.Checked = False
            rbLabBagSampleTested.Checked = False

            rbLabLotSampleTested.Checked = False
            rbLabBagSampleTested.Checked = False

            'Me.bindNotTestedSampleLot()
            'Me.bindNotTestedSampleBag()
            dgvFSampleBag.DataSource = Nothing
            dgvTSampleBag.DataSource = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Clear_RForm()
        Try
            Me.RTransDt.CustomFormat = "dd/MM/yyyy"
            Me.RTransDt.Value = DateTime.Now

            txtRTransId.Clear()

            cmbRBagNo.Enabled = True
            cmbRBagNo.Text = ""

            txtRBagName.Clear()
            txtRIssueWt.Clear()
            txtRIssuePr.Clear()
            txtRWtOnScale.Clear()
            txtRRecieveWt.Clear()
            txtRSample.Clear()
            txtRTotalWt.Clear()
            txtRCarbon.Clear()
            txtRGrossLoss.Clear()

            dgvReceiveSample.DataSource = Nothing

            btnRSave.Text = "&Save"
            BtnREdit.Enabled = True

            Me.fillRecBagNo()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                    .Add(dbManager.CreateParameter("@UItemName", (txtRBagName.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UBagSrNo", Convert.ToString(cmbRBagNo.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UIssueWt", Val(txtRIssueWt.Text), DbType.Decimal))
                    .Add(dbManager.CreateParameter("@UIssuePr", Val(txtRIssuePr.Text), DbType.Decimal))
                    .Add(dbManager.CreateParameter("@UWtOnScale", Val(txtRWtOnScale.Text), DbType.Decimal))
                    .Add(dbManager.CreateParameter("@UReceiveWt", Val(txtRRecieveWt.Text), DbType.Decimal))
                    .Add(dbManager.CreateParameter("@UTFSample", Val(txtRSample.Text), DbType.Decimal))
                    .Add(dbManager.CreateParameter("UCarbonReceive", Val(txtRCarbon.Text), DbType.Decimal))
                    .Add(dbManager.CreateParameter("@ULossWt", Val(txtRGrossLoss.Text), DbType.Decimal))
                    .Add(dbManager.CreateParameter("@UCreatedBy", UserName.Trim(), DbType.String))
                End With

                dbManager.Insert("SP_UsedBags_Save", CommandType.StoredProcedure, parameters.ToArray())

                Dim tparameters = New List(Of SqlParameter)()

                With tparameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@ActionType", "UpdateSampleSt", DbType.String))
                    .Add(dbManager.CreateParameter("@BagNo", Convert.ToString(cmbRBagNo.Text), DbType.String))
                End With

                dbManager.Update("SP_SampleBagNo_Update", CommandType.StoredProcedure, tparameters.ToArray())

                MessageBox.Show("Data Saved !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            If btnRSave.Text = "&Update" Then
                With parameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@ActionType", "EditData", DbType.String))

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

            btnRCancel_Click(sender, e)

            fillReceiveVacuumSrNo()
            fillUpdBagNo()
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub btnUSave_Click(sender As Object, e As EventArgs) Handles btnUSave.Click
        If Not UpdateValidate_Fields() Then Exit Sub

        Try
            Dim parameters = New List(Of SqlParameter)()

            If btnUSave.Text = "&Save" Or btnUSave.Text = "&Update" Then
                With parameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@ActionType", "UpdateReportPr", DbType.String))
                    .Add(dbManager.CreateParameter("@TId", Val(txtUTransId.Text.Trim()), DbType.Int16))
                    .Add(dbManager.CreateParameter("@ReportPr", Convert.ToDecimal(txtUreceivePr.Text.Trim()), DbType.Decimal))
                    .Add(dbManager.CreateParameter("@LossWt", Convert.ToDecimal(txtULossFine.Text.Trim()), DbType.Decimal))

                    If btnUSave.Text = "&Save" Then
                        .Add(dbManager.CreateParameter("@BagNo", Convert.ToString(cmbUpdBagNo.EditorControl.CurrentRow.Cells(0).Value), DbType.String))
                    Else
                        .Add(dbManager.CreateParameter("@BagNo", Convert.ToString(cmbUpdBagNo.Text.Trim()), DbType.String))
                    End If
                End With

                dbManager.Update("SP_UsedBagNo_Update", CommandType.StoredProcedure, parameters.ToArray())

                MessageBox.Show("Data Saved !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Me.btnUCancel_Click(sender, e)
                Me.FillUpdatedGridView()
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Me.fillUpdBagNo()
    End Sub
    Private Sub lstSampleBag_ItemChecked(sender As Object, e As ItemCheckedEventArgs)
        'Me.CalculateSampleWt()
    End Sub
    Private Sub frmSampleBag_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub bindNotTestedSampleLot()
        Dim dt As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "GetNonTestedSampleData", DbType.String))
            End With

            dt = dbManager.GetDataTable("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray())
            If dt.Rows.Count > 0 Then
                dgvTSampleBag.DataSource = dt
            Else
                MessageBox.Show("Bag Sample Not Tested Data Not Found")
                dgvTSampleBag.DataSource = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub bindNotTestedSampleBag()
        Dim dt As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "GetNotSentSampleBag", DbType.String))
            End With

            dt = dbManager.GetDataTable("SP_LabData_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dt.Rows.Count > 0 Then
                dgvTSampleBag.DataSource = Nothing
                dgvTSampleBag.DataSource = dt
            Else
                MessageBox.Show("Bag Sample Not Tested Data Not Found")
                dgvTSampleBag.DataSource = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub bindTestedSampleLot()
        Dim dt As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "GetTestedSampleLot", DbType.String))
            End With

            dt = dbManager.GetDataTable("SP_LabData_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dt.Rows.Count > 0 Then
                dgvTSampleBag.DataSource = Nothing
                dgvTSampleBag.DataSource = dt
            Else
                MessageBox.Show("Lot Sample Tested Data Not Found")
                dgvTSampleBag.DataSource = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub bindTestedSampleBags()
        Dim dt As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "GetTestedSampleBag", DbType.String))
            End With

            dt = dbManager.GetDataTable("SP_LabData_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dt.Rows.Count > 0 Then
                dgvTSampleBag.DataSource = Nothing
                dgvTSampleBag.DataSource = dt
            Else
                MessageBox.Show("Bag Sample Tested Data Not Found")
                dgvTSampleBag.DataSource = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub lstFSampleBag_KeyDown(sender As Object, e As KeyEventArgs)
        Try
            If (e.KeyCode = Keys.Delete) Then
                For Each listViewItem As ListViewItem In (CType(sender, ListView)).SelectedItems
                    listViewItem.Remove()
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub EnbledBtn()
        btnSave.Enabled = True
        BtnCancel.Enabled = True
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If btnSave.Text = "&Save" Then
                If Not Validate_Fields() Then Exit Sub
                If dgvFSampleBag.RowCount > 0 Then
                    If rbLotSampleNotTested.Checked = True Then
                        Dim TmpLotNo As String = Nothing
                        Dim Dt As DataTable = Me.UpdateSampleSrNoForTran()
                        TmpLotNo = Dt.Rows(0).Item(0)
                        MessageBoxTimer(TmpLotNo)
                        AddHandler rbLotSampleNotTested.CheckedChanged, AddressOf rbLotSampleNotTested_CheckedChanged
                    Else
                        Me.UpdateSampleSrNoForUsed()
                        Me.bindNotTestedSampleBag()
                    End If
                End If
            Else
                Try
                    If Not txtMaxNo.Text.Trim = "" Then
                        If dgvFSampleBag.RowCount > 0 Then
                            If (MsgBox("Are You Sure To Update This Sample Bag ?", vbYesNo + vbDefaultButton2 + vbQuestion, "User : " + UserName.Trim()) = vbYes) Then
                                If dgvFSampleBag.RowCount > 0 Then
                                    Dim parameters = New List(Of SqlParameter)()
                                    parameters.Clear()
                                    With parameters
                                        .Add(dbManager.CreateParameter("@ActionType", "SetSampleBagNoToNULL", DbType.String))
                                        .Add(dbManager.CreateParameter("@BagSrNo", txtMaxNo.Text, DbType.String))
                                    End With
                                    dbManager.Delete("SP_SampleBags_Select", CommandType.StoredProcedure, parameters.ToArray())
                                    Dim Dt As DataTable = Me.UpdateSameVaccumeBag()
                                    'Me.fillBagType()
                                End If
                                dgvFSampleBag.RowCount = 0
                            End If
                        Else
                            MessageBox.Show("Please Select Record And Click On 'Copy' Button")
                        End If
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error:- " & ex.Message)
                End Try
            End If
            BtnCancel_Click(sender, e)
            Me.fillRecBagNo()
            Me.fillUpdBagNo()
            btnSave.Text = "&Save"
        Catch ex As Exception
        End Try
    End Sub
    Private Function UpdateSameVaccumeBag() As DataTable
        Dim Dt As DataTable = Nothing
        Dim alParaval As New ArrayList
        Dim BagId As Int16 = 0
        Dim TranId As String = Nothing
        Dim IRowCount As Integer = 0
        Dim iValue As Integer = 0

        alParaval.Add(cmbCBagtype.Tag)

        If dgvFSampleBag.Rows.Count > 0 Then
            For Each row As GridViewRowInfo In dgvFSampleBag.Rows
                'If row.Cells(0).Value = True Then
                If TranId = "" Then
                    TranId = Val(row.Cells(8).Value)
                Else
                    TranId = TranId & "|" & Val(row.Cells(8).Value)
                End If
                'End If
                IRowCount += 1
            Next
            alParaval.Add(TranId)
            Try
                Dim Dparameters = New List(Of SqlParameter)()
                Dparameters.Clear()
                With Dparameters
                    .Add(dbManager.CreateParameter("@ActionType", "UpdateSampleNo", DbType.String))
                    .Add(dbManager.CreateParameter("@BId", alParaval.Item(iValue), DbType.Int16))
                    iValue += 1
                    .Add(dbManager.CreateParameter("@TId", alParaval.Item(iValue), DbType.String))
                    iValue += 1
                    .Add(dbManager.CreateParameter("@GridCount", IRowCount, DbType.Int16))
                    .Add(dbManager.CreateParameter("@BagType", "S", DbType.String))
                End With

                Dt = dbManager.GetDataTable("SP_UsedBagNo_Update", CommandType.StoredProcedure, Dparameters.ToArray())
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
        Select Case InfoBox.Popup("Click OK (Chain Saved Successfully With New Lot Number = " & strMsg.ToString(),
        AckTime, "Newly Created Lot Number", 0)
            Case 1, -1
                Exit Sub
        End Select
    End Sub
    Private Sub DisableBtn()
        btnSave.Enabled = True
        BtnCancel.Enabled = True
    End Sub
    Private Sub CalculateTotal()
        Dim sSampleTotal As Single = 0
        Dim sReceivePr As Single = 0
        Dim sFineTotal As Single = 0

        For Each row As GridViewRowInfo In dgvFSampleBag.Rows
            sSampleTotal += Single.Parse(row.Cells(4).Value)
            sReceivePr += Single.Parse(row.Cells(5).Value)
            sFineTotal += Single.Parse(row.Cells(6).Value)
        Next

        lblSampleTotal.Text = Format(sSampleTotal, "0.00")
        lblReceivePr.Text = Format(sReceivePr, "0.00")
        lblFineTotal.Text = Format(sFineTotal, "0.00")
    End Sub
    Private Function UpdateSampleSrNoForTran() As DataTable
        Dim Dt As DataTable = Nothing
        Dim alParaval As New ArrayList
        Dim BagId As Int16 = 0
        Dim TranId As String = Nothing
        Dim IRowCount As Integer = 0
        Dim iValue As Integer = 0

        alParaval.Add(cmbCBagtype.SelectedValue)

        If dgvFSampleBag.Rows.Count > 0 Then
            For Each row As GridViewRowInfo In dgvFSampleBag.Rows
                'If row.Cells(0).Value = True Then
                If TranId = "" Then
                    TranId = Val(row.Cells(8).Value)
                Else
                    TranId = TranId & "|" & Val(row.Cells(8).Value)
                End If
                'End If
                IRowCount += 1
            Next

            alParaval.Add(TranId)

            Try
                Dim Dparameters = New List(Of SqlParameter)()

                With Dparameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@ActionType", "UpdateSampleNo", DbType.String))
                    .Add(dbManager.CreateParameter("@BId", alParaval.Item(iValue), DbType.Int16))
                    iValue += 1
                    .Add(dbManager.CreateParameter("@TId", alParaval.Item(iValue), DbType.String))
                    iValue += 1
                    .Add(dbManager.CreateParameter("@GridCount", IRowCount, DbType.Int16))
                    .Add(dbManager.CreateParameter("@BagType", "S", DbType.String))
                End With

                Dt = dbManager.GetDataTable("SP_UsedBagNo_Update", CommandType.StoredProcedure, Dparameters.ToArray())

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            End Try
        End If
        Return Dt
    End Function
    Private Sub UpdateSampleSrNoForUsed()
        If dgvTSampleBag.Rows.Count > 0 Then

            Try
                Dim Dparameters = New List(Of SqlParameter)()
                'Dparameters.Clear()

                For i As Integer = 0 To dgvFSampleBag.Rows.Count - 1
                    With Dparameters
                        .Clear()
                        .Add(dbManager.CreateParameter("@ActionType", "UpdateSampleNoForBag", DbType.String))
                        .Add(dbManager.CreateParameter("@BId", Val(cmbCBagtype.SelectedValue), DbType.Int16))
                        .Add(dbManager.CreateParameter("@TId", Val(dgvTSampleBag.Rows(i).Cells(8).Value), DbType.Int16))
                        .Add(dbManager.CreateParameter("@BagType", "S", DbType.String))
                        dbManager.Update("SP_SampleBagNo_Update", CommandType.StoredProcedure, Dparameters.ToArray())
                    End With
                    Dparameters.Clear()
                Next
                MessageBox.Show("Sample Bag Updated !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            End Try
        End If
    End Sub
    Private Sub dgvFSampleBag_ValueChanged(sender As Object, e As EventArgs)
        If dgvTSampleBag.CurrentColumn.Name = "colChkBox" Then
            dgvTSampleBag.EndEdit()
        End If
    End Sub
    Private Sub bindSampleBag()
        Dim dt As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "GetSampleData", DbType.String))
            .Add(dbManager.CreateParameter("@BId", Val(cmbCBagtype.SelectedValue), DbType.Int16))
        End With

        dt = dbManager.GetDataTable("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray())

        If dt.Rows.Count = 0 Then
            MessageBox.Show("No Data Exists !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            dgvTSampleBag.DataSource = dt
            dgvTSampleBag.EnableFiltering = True
            dgvTSampleBag.MasterTemplate.ShowFilteringRow = False
            dgvTSampleBag.MasterTemplate.ShowHeaderCellButtons = True
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
        End Try
    End Sub
    Private Sub tbSampleBag_Click(sender As Object, e As EventArgs) Handles tbSampleBag.Click
        If tbSampleBag.SelectedIndex = 0 Then       ''for Create Bhuka Bag
            Me.fillBagType()
            Me.Clear_CForm()
        ElseIf tbSampleBag.SelectedIndex = 1 Then   ''for Receive Bhuka Bag
            Me.fillBagType()
            Me.Clear_RForm()
        ElseIf tbSampleBag.SelectedIndex = 2 Then   ''for Update Bhuka Bag
            Me.fillBagType()
            Me.Clear_UForm()
        End If
    End Sub
    Private Sub txtRIssueWt_TextChanged(sender As Object, e As EventArgs) Handles txtRIssueWt.TextChanged
        Try
            'txtRGrossLoss.Text = Format(Val(txtRIssueWt.Text) - Val(txtRRecieveWt.Text) - Val(txtRSample.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
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
    Private Sub txtRWtOnScale_Leave(sender As Object, e As EventArgs) Handles txtRWtOnScale.Leave
        txtRWtOnScale.Text = Format(Val(txtRWtOnScale.Text), "0.00")
    End Sub
    Private Sub txtRRecieveWt_Leave(sender As Object, e As EventArgs) Handles txtRRecieveWt.Leave
        txtRRecieveWt.Text = Format(Val(txtRRecieveWt.Text), "0.00")
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
            txtULossFine.Text = Format(Val(txtUIssueFineWt.Text) - Val(txtUreceiveFineWt.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtUissueFineWt_TextChanged(sender As Object, e As EventArgs) Handles txtUIssueFineWt.TextChanged
        Try
            txtULossFine.Text = Format(Val(txtUIssueFineWt.Text) - Val(txtUreceiveFineWt.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub bindIssueListviewTrans()
        Dim dt As DataTable = New DataTable()
        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "GetNotSentSampleBag", DbType.String))
            End With

            dt = dbManager.GetDataTable("SP_LabData_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dt.Rows.Count > 0 Then
                dgvTSampleBag.DataSource = dt
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

    End Sub
    Private Sub txtUreceivePr_TextChanged(sender As Object, e As EventArgs) Handles txtUreceivePr.TextChanged
        Try
            txtUreceiveFineWt.Text = Format((Val(txtUreceiveWt.Text) * Val(txtUreceivePr.Text)) / 100, "0.00")
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
    Private Sub btnUExit_Click(sender As Object, e As EventArgs) Handles btnUExit.Click
        Me.Close()
    End Sub
    Private Sub btnCExit_Click(sender As Object, e As EventArgs) Handles btnCExit.Click
        Me.Close()
    End Sub
    Private Sub btnRExit_Click(sender As Object, e As EventArgs) Handles btnRExit.Click
        Me.Close()
    End Sub
    Private Sub btnUCancel_Click(sender As Object, e As EventArgs) Handles btnUCancel.Click
        Try
            Call Clear_UForm()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Clear_UForm()
        Try
            txtUTransId.Clear()
            txtUTransId.Tag = ""

            cmbUpdBagNo.Enabled = True
            cmbUpdBagNo.SelectedIndex = 0

            txtUBagName.Text = ""
            txtUreceivePr.Clear()
            txtUreceiveWt.Clear()
            txtUreceiveFineWt.Clear()
            txtUissuePr.Clear()
            txtUissueWt.Clear()
            txtULossFine.Clear()
            txtUWtOnScale.Clear()
            txtUIssueFineWt.Clear()
            txtUcarbonReceive.Clear()
            txtUGrossLoss.Clear()
            txtULossFine.Clear()

            btnUSave.Text = "&Save"
            btnUEdit.Enabled = True

            fillUpdBagNo()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnRCancel_Click(sender As Object, e As EventArgs) Handles btnRCancel.Click
        Try
            Me.Clear_RForm()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub fillRecBagNo()
        Dim connection As SqlConnection = Nothing
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FillRSampleCmb", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_SampleBags_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)

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
            cmbRBagNo.Columns(1).Width = 135
            Me.cmbRBagNo.MultiColumnComboBoxElement.DropDownWidth = 250
            Me.BackColor = Color.White
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Try
            Call Clear_CForm()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub BtnREdit_Click(sender As Object, e As EventArgs) Handles BtnREdit.Click
        If BtnREdit.Text = "&Edit" Then
            If cmbRBagNo.SelectedIndex > -1 Then
                lblMaxNo.Visible = True
                txtMaxNo.Visible = True
                btnSave.Text = "&Update"
                txtMaxNo.Text = Me.cmbRBagNo.EditorControl.CurrentRow.Cells(0).Value
                FillCHeader(cmbRBagNo.Text)
                FillCGrid(cmbRBagNo.Text)
                tbSampleBag.SelectedIndex = 0
            Else
                MessageBox.Show("Please Select Bag To Edit")
            End If
        Else
            MessageBox.Show("Update Not Coded")
            Me.UpdateReceivedData()
            Me.btnUCancel_Click(sender, e)
            BtnREdit.Text = "&Edit"
            btnRSave.Enabled = True
            Me.btnRCancel_Click(sender, e)
            Me.btnUCancel_Click(sender, e)
            Me.fillRecBagNo()
            Me.fillUpdBagNo()
            Me.FillUpdatedGridView()
        End If
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
    Private Sub FillCHeader(ByVal RBagNo As String)
        Dim dt As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "GetHeaderSampleDatabyBag", DbType.String))
            .Add(dbManager.CreateParameter("@BagSrNo", RBagNo, DbType.String))
        End With

        dt = dbManager.GetDataTable("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray())

        If dt.Rows.Count = 0 Then
            MessageBox.Show("No Data Exists !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            cmbCBagtype.Tag = dt.Rows(0).Item("ItemId").ToString()
            cmbCBagtype.Text = dt.Rows(0).Item("ItemName").ToString()
        End If

    End Sub
    Private Sub FillCGrid(ByVal RBagNo As String)
        Dim dt As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "GetGridSampleDatabyBag", DbType.String))
            .Add(dbManager.CreateParameter("@BagSrNo", RBagNo, DbType.String))
        End With

        dt = dbManager.GetDataTable("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray())

        If dt.Rows.Count = 0 Then
            MessageBox.Show("No Data Exists !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            For Each ROW As DataRow In dt.Rows
                dgvTSampleBag.DataSource = Nothing
                dgvTSampleBag.DataSource = dt
            Next

            dgvTSampleBag.EnableFiltering = True
            dgvTSampleBag.MasterTemplate.ShowFilteringRow = False
            dgvTSampleBag.MasterTemplate.ShowHeaderCellButtons = True
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
        End Try
    End Sub
    Private Sub BtnCopy_Click(sender As Object, e As EventArgs) Handles BtnCopy.Click
        If txtMaxNo.Visible = False Then
            If dgvTSampleBag.RowCount > 0 Then
                Try
                    Dim dt As New DataTable
                    If Not dgvTSampleBag.Rows.Count > 0 Then
                        MessageBox.Show("No Data. !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                        Exit Sub
                    End If
                    dt = (CType(dgvTSampleBag.DataSource, DataTable)).Clone()
                    For Each row As GridViewRowInfo In dgvTSampleBag.Rows
                        Dim newRow As New GridViewDataRowInfo(dgvFSampleBag.MasterView)
                        If CBool(row.Cells()(0).Value) = True Then
                            newRow.Cells("colChkBox").Value = True
                            dt.ImportRow((CType(dgvTSampleBag.DataSource, DataTable)).Rows(row.Index))
                        End If
                    Next
                    dt.AcceptChanges()
                    dgvFSampleBag.DataSource = dt
                    Me.CalculateTotal()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Else
            dgvFSampleBag.Rows.Clear()
            ' Loop through the selected rows in RadGridView1
            For Each row As GridViewRowInfo In dgvTSampleBag.Rows
                For Each row1 As GridViewDataRowInfo In dgvTSampleBag.SelectedRows
                    ' Create a new row in RadGridView2
                    Dim newRow As New GridViewDataRowInfo(dgvFSampleBag.MasterView)
                    ' Copy the values from selected row in RadGridView1 to the new row in RadGridView2
                    If row.Cells("colChkBox").Value = "On" Or row.Cells("colChkBox").Value = "True" Then
                        newRow.Cells("colChkBox").Value = True
                        newRow.Cells("colTransDt").Value = row.Cells("colTransDt").Value
                        newRow.Cells("colOperation").Value = row.Cells("colOperation").Value
                        newRow.Cells("colLotNo").Value = row.Cells("colLotNo").Value
                        newRow.Cells("colSampleWt").Value = row.Cells("colSampleWt").Value
                        newRow.Cells("colReceivePr").Value = row.Cells("colReceivePr").Value
                        newRow.Cells("colFineWt").Value = row.Cells("colFineWt").Value
                        newRow.Cells("colOperationId").Value = row.Cells("colOperationId").Value
                        newRow.Cells("colTransId").Value = row.Cells("colTransId").Value
                        ' Repeat the above line for each column you want to copy
                        ' Add the new row to RadGridView2
                        dgvFSampleBag.Rows.Add(newRow)
                    End If
                Next
            Next
        End If
    End Sub
    Private Sub cmbRBagNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRBagNo.SelectedIndexChanged
        If cmbRBagNo.SelectedIndex > 0 Then
            Me.bindReceiveGridView()
        End If
    End Sub
    Private Sub cmbUpdBagNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUpdBagNo.SelectedIndexChanged
        If cmbUpdBagNo.SelectedIndex > 0 Then
            Me.fetchUpdateSampleBag(cmbUpdBagNo.Text.Trim)
        End If
    End Sub
    Private Sub BtnUUpdate_Click(sender As Object, e As EventArgs) Handles btnUEdit.Click
        If cmbUpdBagNo.SelectedIndex <= 0 Then
            MessageBox.Show("Please Select Bag No To Edit Records")
        Else
            cmbRBagNo.Text = Me.cmbUpdBagNo.EditorControl.CurrentRow.Cells(0).Value
            cmbRBagNo.Enabled = False

            BtnREdit.Enabled = False
            btnRSave.Text = "&Update"

            Me.bindReceiveGridView()
            'Me.GetSrNo(dgvReceiveSample)
            Me.FetchUsedBagsDetails(cmbRBagNo.Text.Trim)

            tbSampleBag.SelectedIndex = 1
        End If
    End Sub
    Sub GetSrNo(ByRef grid As Telerik.WinControls.UI.RadGridView)
        Try
            For Each rowInfo As GridViewRowInfo In dgvReceiveSample.Rows
                rowInfo.Cells(0).Value = rowInfo.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function fetchAllDetailsRUpdate(ByVal sBagNo As String) As DataTable
        Dim dtData As DataTable = New DataTable()
        Try
            Dim parameters = New List(Of SqlParameter)()
            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FillRSampleDetails", DbType.String))
                .Add(dbManager.CreateParameter("@BagSrNo", Trim(sBagNo), DbType.String))
            End With
            dtData = dbManager.GetDataTable("SP_SampleBags_Select", CommandType.StoredProcedure, parameters.ToArray())
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
        Return dtData
    End Function
    Private Sub FillGridU(ByVal sUBagNo As String)
        Dim dttable As New DataTable
        dttable = fetchAllDetailsRUpdate(CStr(sUBagNo))
        dgvReceiveSample.DataSource = Nothing
        dgvReceiveSample.DataSource = dttable
        Me.ReceivelistViewTotal()
        Me.FetchUsedBagsDetails(sUBagNo)
        Me.GetSrNo(dgvTSampleBag)
    End Sub
    Private Sub FetchUsedBagsDetails(sUBagNo)
        Dim dtData As DataTable = New DataTable()
        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()
            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchReceivedSample", DbType.String))
                .Add(dbManager.CreateParameter("@BagSrNo", sUBagNo, DbType.String))
            End With
            dtData = dbManager.GetDataTable("SP_SampleBags_Select", CommandType.StoredProcedure, parameters.ToArray())
            If dtData.Rows.Count > 0 Then
                txtRBagName.Text = dtData.Rows(0).Item("BagName").ToString()
                txtRIssueWt.Text = dtData.Rows(0).Item("IssueWt").ToString()
                txtRIssuePr.Text = dtData.Rows(0).Item("IssuePr").ToString()
                txtRWtOnScale.Text = dtData.Rows(0).Item("WtOnScale").ToString()
                txtRRecieveWt.Text = dtData.Rows(0).Item("ReceiveWt").ToString()
                'txtRTotalWt.Text = dtData.Rows(0).Item("ReceiveWt").ToString()
                txtRSample.Text = dtData.Rows(0).Item("TFSampleWt").ToString()
                txtRCarbon.Text = dtData.Rows(0).Item("CarbonReceive").ToString()
                'txtUGrossLoss.Text = dtData.Rows(0).Item("GrossLossWt").ToString()
            Else
                'MessageBox.Show("No Data Found !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
        End Try
    End Sub
    Private Sub dgvFinalUpdate_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles dgvFinalUpdate.CellDoubleClick
        If dgvFinalUpdate.Rows.Count > 0 Then
            Dim sSampleBagNo As String = dgvFinalUpdate.Rows(e.RowIndex).Cells(1).Value.ToString()

            Me.btnUCancel_Click(sender, e)
            fetchUpdateSampleBag(sSampleBagNo)

            btnUSave.Text = "&Update"
            btnUEdit.Enabled = False
            cmbUpdBagNo.Enabled = False

            tbSampleBag.SelectedIndex = 2
        End If
    End Sub
    Private Sub rbLotSampleNotTested_CheckedChanged(sender As Object, e As EventArgs) Handles rbLotSampleNotTested.CheckedChanged
        dgvTSampleBag.DataSource = Nothing
        If rbLotSampleNotTested.Checked = True Then
            Me.bindNotTestedSampleLot()
        End If
    End Sub
    Private Sub rbBagSampleNotTested_CheckedChanged(sender As Object, e As EventArgs) Handles rbBagSampleNotTested.CheckedChanged
        dgvTSampleBag.DataSource = Nothing
        If rbBagSampleNotTested.Checked = True Then
            If cmbCBagtype.SelectedIndex = 1 Then
                Me.bindNotTestedSampleBag()
            Else
                MessageBox.Show("Please Select Bag Type As Not Tested Bags")
            End If
        End If
    End Sub
    Private Sub rbLabLotSampleTested_CheckedChanged(sender As Object, e As EventArgs) Handles rbLabLotSampleTested.CheckedChanged
        dgvTSampleBag.DataSource = Nothing
        If rbLabLotSampleTested.Checked = True Then
            If cmbCBagtype.SelectedIndex = 2 Then
                Me.bindTestedSampleLot()
            Else
                MessageBox.Show("Please Select Bag Type As Tested Bags")
            End If
        End If
    End Sub
    Private Sub rbLabBagSampleTested_CheckedChanged(sender As Object, e As EventArgs) Handles rbLabBagSampleTested.CheckedChanged
        dgvTSampleBag.DataSource = Nothing
        If rbLabBagSampleTested.Checked = True Then
            If cmbCBagtype.SelectedIndex = 2 Then
                Me.bindTestedSampleBags()
            Else
                MessageBox.Show("Please Select Bag Type As Tested Bags")
                rbLabBagSampleTested.Checked = True
            End If
        End If
    End Sub
    Private Sub fillUpdBagNo()
        Dim connection As SqlConnection = Nothing
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "fillUSampleBag", DbType.String))
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
            Me.cmbUpdBagNo.MultiColumnComboBoxElement.DropDownWidth = 250
            Me.BackColor = Color.White
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
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
    Private Sub txtUreceivePr_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUreceivePr.KeyPress
        numdotkeypress(e, txtUreceivePr, Me)
    End Sub
    Private Sub txtUreceivePr_Leave(sender As Object, e As EventArgs) Handles txtUreceivePr.Leave
        txtUreceivePr.Text = Format(Val(txtUreceivePr.Text), "0.00")
    End Sub
    Private Sub txtRGrossLoss_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRGrossLoss.KeyDown
        If e.KeyCode = Keys.Tab Then
            btnRSave.Focus()
        End If
    End Sub
    Private Function ReceiveValidate_Fields() As Boolean
        Try
            If String.IsNullOrWhiteSpace(cmbRBagNo.Text.Trim()) Or Convert.ToInt32(cmbRBagNo.SelectedIndex) = -1 Then
                MessageBox.Show("Select Bag Type !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbRBagNo.Focus()
            ElseIf String.IsNullOrWhiteSpace(cmbRBagNo.Text.Trim()) Then
                MessageBox.Show("Select Lot No...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbRBagNo.Focus()
            ElseIf Val(txtRWtOnScale.Text.Trim) <= 0 Then
                MessageBox.Show("Enter Wt. On Scale !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtRWtOnScale.Focus()
                Return False
            ElseIf Val(txtRRecieveWt.Text.Trim) <= 0 Then
                MessageBox.Show("Enter Lagdi Received !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtRRecieveWt.Focus()
                Return False
            ElseIf Val(txtRSample.Text.Trim) <= 0 Then
                MessageBox.Show("Enter Sample Received !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtRSample.Focus()
                Return False
            ElseIf Val(txtRCarbon.Text.Trim) <= 0 Then
                MessageBox.Show("Enter Carbon Received !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtRCarbon.Focus()
                Return False
            End If
            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Function Validate_Fields() As Boolean
        Try
            'Assigning Default values
            If Val(cmbCBagtype.SelectedIndex) = -1 Or Val(cmbCBagtype.SelectedIndex) = 0 Then
                MessageBox.Show("Select Item Bag Type !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbCBagtype.Focus()
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
            If String.IsNullOrWhiteSpace(cmbUpdBagNo.Text.Trim()) Or Convert.ToInt32(cmbUpdBagNo.SelectedIndex) = -1 Then
                MessageBox.Show("Select Bag Type !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbUpdBagNo.Focus()
                Return False
            ElseIf Val(txtUreceivePr.Text) <= 0 Then
                MessageBox.Show("Enter Receive % !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtUreceivePr.Focus()
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

End Class


