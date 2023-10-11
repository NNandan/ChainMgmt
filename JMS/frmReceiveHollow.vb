Imports System.Data.SqlClient
Imports DataAccessHandler
Public Class frmReceiveHollow
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState

    Dim strSQL As String = Nothing

    Dim GridDoubleClick As Boolean

    Dim dbManager As New SqlHelper()
    Dim Objcn As SqlConnection = New SqlConnection()
    Dim iItemId As Int16 = 0
    Dim iOpTypeId As Int16 = 0

    Dim dblGoldIssued As Double = 0
    Dim dblCoreIssu As Double = 0
    Dim dblCoreRece As Double = 0
    Dim dblCoreRemain As Double = 0

    Dim dblTotalSum As Double = 0

    Dim dSkinPr As Double = 75.1
    Private Property Fr_Mode() As FormState
        Get
            Return mFr_State
        End Get
        Set(ByVal value As FormState)
            mFr_State = value
            Select Case mFr_State
                Case FormState.AStateMode
                    CType(Me.ParentForm, frmMain).FormMode.Text = "&New"
                    Me.btnSave.Enabled = True
                    Me.btnSave.Text = "&Save"
                    Me.btnDelete.Enabled = False
                Case FormState.EStateMode
                    CType(Me.ParentForm, frmMain).FormMode.Text = "&Edit"
                    Me.btnSave.Text = "&Update"
                    Me.btnDelete.Enabled = True
            End Select
        End Set
    End Property
    Private Sub frmReceiveHollow_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.fillLabour()
        Me.fillLotNo()

        Me.Clear_Form()
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not Validate_Fields() Then Exit Sub

        Try
            If Fr_Mode = FormState.AStateMode Then
                Me.SaveData()
                Me.btnCancel_Click(sender, e)
            Else
                Me.UpdateData()
                Me.btnCancel_Click(sender, e)
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub cmbLotNo_SelectedIndexChanged(sender As Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles cmbLotNo.SelectedIndexChanged
        If cmbLotNo.SelectedIndex > -1 Then
            bindReceiveHeaderView()
        End If
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub fillLabour()

        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FillLabour", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_LabourMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            ''Insert the Default Item to DataTable.
            Dim trow As DataRow = dt.NewRow()
            trow(0) = 0
            trow(1) = "---Select---"
            dt.Rows.InsertAt(trow, 0)

            cmbtKarigar.DataSource = dt
            cmbtKarigar.DisplayMember = "LabourName"
            cmbtKarigar.ValueMember = "LabourId"

            cmbtKarigar.AutoCompleteMode = AutoCompleteMode.SuggestAppend ' This is necessary
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub fillLotNo()
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchLotNo", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_HollowReceive_Select", CommandType.StoredProcedure, parameters.ToArray(), Objcn)
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
            cmbLotNo.ValueMember = "HollowIssueId"
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            Objcn.Close()
        End Try
    End Sub
    Private Sub txtSample_TextChanged(sender As Object, e As EventArgs) Handles txtSample.TextChanged
        Try
            txtRTotalWt.Text = Format(Val(txtChain.Text) + Val(txtBhuka.Text) + Val(txtSample.Text), "0.00")

            txtRTotalFw.Text = Format(Val(txtReceiveFine.Text) + Val(txtReceiveBhukaFine.Text) + Val(txtReceiveSampleFine.Text), "0.000")

            dblCoreRece = Format(Val(dblTotalSum) - Val(txtRTotalWt.Text), "0.00")

            'If Not String.IsNullOrEmpty(txtReceivePr.Text) Then
            '    txtReceiveFine.Text = Format(Val(txtReceiveTotalGross.Text) * Val(txtReceivePr.Text) / 100, "0.00")
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtChain_TextChanged(sender As Object, e As EventArgs) Handles txtChain.TextChanged
        Try
            txtRTotalWt.Text = Format(Val(txtChain.Text) + Val(txtBhuka.Text) + Val(txtSample.Text), "0.00")

            txtRTotalFw.Text = Format(Val(txtReceiveFine.Text) + Val(txtReceiveBhukaFine.Text) + Val(txtReceiveSampleFine.Text), "0.000")

            dblCoreRece = Format(Val(dblTotalSum) - Val(txtRTotalWt.Text), "0.00")

            'If Not String.IsNullOrEmpty(txtReceivePr.Text) Then
            '    txtReceiveFine.Text = Format(Val(txtReceiveTotalGross.Text) * Val(txtReceivePr.Text) / 100, "0.00")
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtBhuka_TextChanged(sender As Object, e As EventArgs) Handles txtBhuka.TextChanged
        Try
            txtRTotalWt.Text = Format(Val(txtChain.Text) + Val(txtBhuka.Text) + Val(txtSample.Text), "0.00")

            txtRTotalFw.Text = Format(Val(txtReceiveFine.Text) + Val(txtReceiveBhukaFine.Text) + Val(txtReceiveSampleFine.Text), "0.000")

            dblCoreRece = Format(Val(dblTotalSum) - Val(txtRTotalWt.Text), "0.00")

            'If Not String.IsNullOrEmpty(txtReceivePr.Text) Then
            '    txtReceiveFine.Text = Format(Val(txtReceiveTotalGross.Text) * Val(txtReceivePr.Text) / 100, "0.00")
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub bindReceiveHeaderView()
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchLotNoDetails", DbType.String))
                .Add(dbManager.CreateParameter("@HollowNo", Convert.ToString(cmbLotNo.Text.Trim), DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_HollowReceive_Select", CommandType.StoredProcedure, parameters.ToArray())

            txtTransNo.Text = dtData.Rows(0).Item(0)
            TransDt.Text = dtData.Rows(0).Item(1)
            iOpTypeId = dtData.Rows(0).Item(2)
            txtLotNo.Text = dtData.Rows(0).Item(3)
            txtCoreAddNo.Text = dtData.Rows(0).Item(4)
            iItemId = dtData.Rows(0).Item(5)
            txtIssueWt.Text = dtData.Rows(0).Item(7)
            txtIssuePr.Text = dtData.Rows(0).Item(8)
            txtIssueFw.Text = dtData.Rows(0).Item(9)
            txtFrKarigar.Tag = dtData.Rows(0).Item(10)
            txtFrKarigar.Text = dtData.Rows(0).Item(11)
            cmbtKarigar.Tag = dtData.Rows(0).Item(12)
            cmbtKarigar.Text = dtData.Rows(0).Item(13)

            SumOfGoldIssued()
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub SaveData()
        Dim iOperationTypeId As Integer = 16 ''Operation Id for Hollow Receive

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@HollowReceiveDt", TransDt.Value.ToString(), DbType.DateTime))
                .Add(dbManager.CreateParameter("@ItemId", iItemId, DbType.Int16))
                .Add(dbManager.CreateParameter("@OperationTypeId", iOperationTypeId, DbType.Int16))
                .Add(dbManager.CreateParameter("@LotNo", txtLotNo.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@IssueWt", txtIssueWt.Text, DbType.String))
                .Add(dbManager.CreateParameter("@IssuePr", txtIssuePr.Text, DbType.String))
                .Add(dbManager.CreateParameter("@MeltingPr", txtMeltingPr.Text, DbType.String))
                .Add(dbManager.CreateParameter("@ChainRecWt", txtChain.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@BhukaRecWt", txtBhuka.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@SampleRecWt", txtSample.Text, DbType.String))
                .Add(dbManager.CreateParameter("@TgtGoldWt", txtTgtGoldWt.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@CoreIssueWt", dblCoreIssu, DbType.String))
                .Add(dbManager.CreateParameter("@CoreRemainsWt", txtCoreRemains.Text.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@LossWt", txtLossWt.Text.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@FrKarigar", txtFrKarigar.Tag, DbType.Int16))
                .Add(dbManager.CreateParameter("@ToKarigar", cmbtKarigar.SelectedValue, DbType.String))
                .Add(dbManager.CreateParameter("@CreatedBy", UserName.Trim(), DbType.String))
            End With

            dbManager.Insert("SP_HollowReceive_Save", CommandType.StoredProcedure, parameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub txtChain_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtChain.KeyPress
        numdotkeypress(e, txtChain, Me)
    End Sub
    Private Sub txtBhuka_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBhuka.KeyPress
        numdotkeypress(e, txtBhuka, Me)
    End Sub
    Private Sub txtSample_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSample.KeyPress
        numdotkeypress(e, txtSample, Me)
    End Sub
    Private Sub SumOfGoldIssued()
        Try
            dblGoldIssued = Format((CDbl(txtIssueFw.Text) / CDbl(dSkinPr)) * 100, "0.00")
            txtTgtGoldWt.Text = dblGoldIssued

            dblCoreIssu = Format(CDbl(txtIssueWt.Text) - CDbl(dblGoldIssued), "0.00")

            dblTotalSum = Format(CDbl(dblGoldIssued) + CDbl(dblCoreIssu), "0.00")

        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Call Clear_Form()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SumOfGoldIssueMinusTotalRec()
        Dim dblLoss As Double = 0

        Try
            dblCoreRemain = Format(CDbl(dblTotalSum) - CDbl(txtRTotalWt.Text), "0.00")
            dblLoss = dblCoreIssu - dblCoreRemain

            If (dblLoss < 0) Then
                txtCoreRemains.Text = Format(0.00, "0.00")
                txtLossWt.Text = Format(dblLoss, "0.00")
            Else
                txtLossWt.Text = Format(0.00, "0.00")
                txtCoreRemains.Text = Format(dblLoss, "0.00")
            End If

        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtSample_LostFocus(sender As Object, e As EventArgs) Handles txtSample.LostFocus
        Try
            SumOfGoldIssueMinusTotalRec()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtReceivePr_TextChanged(sender As Object, e As EventArgs) Handles txtReceivePr.TextChanged
        Try
            txtReceiveFine.Text = Format((Val(txtChain.Text) * Val(txtReceivePr.Text)) / 100, "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtRTotalWt_TextChanged(sender As Object, e As EventArgs) Handles txtRTotalWt.TextChanged
        Try
            If Not String.IsNullOrEmpty(txtRTotalWt.Text) Then
                txtReceivePr.Text = Format(Val(txtIssueFw.Text) / Val(txtRTotalWt.Text) * 100, "0.00")


                txtReceiveSamplePr.Text = Format(Val(txtReceivePr.Text), "0.00")
                txtReceiveBhukaPr.Text = Format(Val(txtReceivePr.Text), "0.00")
            End If

            'txtRTotalPr.Text = Format(Val(txtRTotalFw.Text) * Val(txtRTotalWt.Text) / 100, "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtReceiveBhukaPr_TextChanged(sender As Object, e As EventArgs) Handles txtReceiveBhukaPr.TextChanged
        Try
            txtReceiveBhukaFine.Text = Format((Val(txtBhuka.Text) * Val(txtReceiveBhukaPr.Text)) / 100, "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtReceiveSamplePr_TextChanged(sender As Object, e As EventArgs) Handles txtReceiveSamplePr.TextChanged
        Try
            txtReceiveSampleFine.Text = Format((Val(txtSample.Text) * Val(txtReceiveSamplePr.Text)) / 100, "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtRTotalFw_TextChanged(sender As Object, e As EventArgs) Handles txtRTotalFw.TextChanged
        'Try
        '    txtReceivePr.Text = Format(Val(txtIssueFw.Text) / Val(txtRTotalWt.Text) * 100, "0.00")

        '    txtReceiveSamplePr.Text = Format(Val(txtReceivePr.Text), "0.00")
        '    txtReceiveBhukaPr.Text = Format(Val(txtReceivePr.Text), "0.00")

        '    txtRTotalPr.Text = Format(Val(txtRTotalFw.Text) * Val(txtRTotalWt.Text) / 100, "0.00")
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub

    Private Function Validate_Fields() As Boolean
        Try
            If Val(txtChain.Text) <= 0 Then
                MessageBox.Show("Enter Chain Wt. !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtChain.Focus()
                Return False
            ElseIf Val(txtBhuka.Text) <= 0 Then
                MessageBox.Show("Enter Bhuka Wt. !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtBhuka.Focus()
                Return False
            ElseIf Val(txtSample.Text) <= 0 Then
                MessageBox.Show("Enter Sample Wt. !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtSample.Focus()
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not String.IsNullOrEmpty(txtTransNo.Text) Then

            If (MsgBox("[DELETION] Are You Sure To Delete This Entry ?", vbYesNo + vbDefaultButton2 + vbQuestion, "Attn : " + UserName.Trim()) = vbYes) Then

                Try
                    Dim parameters = New List(Of SqlParameter)()

                    With parameters
                        .Clear()
                        .Add(dbManager.CreateParameter("@HId", txtTransNo.Text, DbType.Int16))
                    End With

                    dbManager.Delete("SP_HollowReceive_Delete", CommandType.StoredProcedure, parameters.ToArray())

                    MessageBox.Show("Data Deleted !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Me.Clear_Form()

                Catch ex As Exception
                    MessageBox.Show("Error:- " & ex.Message)
                End Try
            End If
        Else
            MessageBox.Show("Please Select A Record !!!")
        End If
    End Sub

    Private Sub Clear_Form()
        Try
            txtTransNo.Tag = ""
            txtTransNo.Clear()

            TransDt.Value = DateTime.Now

            cmbLotNo.SelectedIndex = -1
            txtFrKarigar.Tag = ""
            txtFrKarigar.Clear()

            cmbtKarigar.SelectedIndex = -1

            txtFrKarigar.Tag = ""
            txtFrKarigar.Clear()

            txtCoreAddNo.Clear()
            txtLotNo.Clear()

            txtChain.Clear()
            txtBhuka.Clear()
            txtSample.Clear()
            txtRTotalWt.Clear()

            txtIssueWt.Clear()
            txtIssuePr.Clear()
            txtIssueFw.Clear()

            txtLossWt.Clear()
            txtMeltingPr.Clear()

            txtTgtGoldWt.Clear()
            txtCoreRemains.Clear()

            Me.bindDataGridView()

            Fr_Mode = FormState.AStateMode

            TransDt.Focus()
            TransDt.Select()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub dgvHollowReceive_CellDoubleClick(sender As Object, e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles dgvHollowReceive.CellDoubleClick
        If dgvHollowReceive.SelectedRows.Count = 0 Then Exit Sub

        If dgvHollowReceive.Rows.Count > 0 Then
            Dim IssueId As Integer = Me.dgvHollowReceive.SelectedRows(0).Cells(0).Value

            Me.Clear_Form()

            Fr_Mode = FormState.EStateMode

            Me.fillHeaderFromListView(IssueId)

            Me.fillDetailsFromListView(IssueId)

            Me.TbStockIssue.SelectedIndex = 0
        End If
    End Sub

    Private Sub UpdateData()

        Dim iOperationTypeId As Integer = 16 ''Operation Id for Hollow Receive

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@HollowReceiveDt", TransDt.Value.ToString(), DbType.DateTime))
                .Add(dbManager.CreateParameter("@OperationTypeId", iOperationTypeId, DbType.Int16))
                .Add(dbManager.CreateParameter("@LotNo", txtLotNo.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@ChainRecWt", txtChain.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@BhukaRecWt", txtBhuka.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@SampleRecWt", txtSample.Text, DbType.String))
                .Add(dbManager.CreateParameter("@FrKarigar", txtFrKarigar.Tag.Trim(), DbType.Int16))
                .Add(dbManager.CreateParameter("@ToKarigar", cmbtKarigar.SelectedValue, DbType.String))
                .Add(dbManager.CreateParameter("@CreatedBy", UserName.Trim(), DbType.String))
            End With

            dbManager.Insert("SP_HollowReceive_Update", CommandType.StoredProcedure, parameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub bindDataGridView()
        Dim dtdata As DataTable = fetchAllRecords()

        Try
            dgvHollowReceive.DataSource = dtdata
            dgvHollowReceive.EnableFiltering = True
            dgvHollowReceive.MasterTemplate.ShowFilteringRow = False
            dgvHollowReceive.MasterTemplate.ShowHeaderCellButtons = True
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
        End Try
    End Sub
    Private Function fetchAllRecords() As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_HollowReceive_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function

    Private Sub fillHeaderFromGridView(ByVal intIssueId As Integer)
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@IId", CInt(intIssueId), DbType.Int16))
            .Add(dbManager.CreateParameter("@ActionType", "FetchHeaderRecord", DbType.String))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader("SP_StockIssue_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

        If dr.HasRows = False Then
            Exit Sub
        Else
            dr.Read()
            txtVocucherNo.Tag = dr.Item("IssueId").ToString()
            txtVocucherNo.Text = dr.Item("VoucherNo").ToString()
            TransDt.Text = dr.Item("IssueDt").ToString()
            cmbfDepartment.SelectedIndex = dr.Item("FrDeptId").ToString()
            cmbtDepartment.SelectedIndex = dr.Item("ToDeptId").ToString()
            txtFrKarigar.Tag = dr.Item("FrKarigarId").ToString()
            txtFrKarigar.Text = dr.Item("FrKarigar").ToString()

            cmbtKarigar.SelectedIndex = dr.Item("ToKarigarId").ToString()
            cmbtKarigar.Text = CStr(dr.Item("ToKarigar"))
        End If

        dr.Close()
        Objcn.Close()

        Exit Sub
ErrHandler:
        MsgBox(Err.Description, MsgBoxStyle.Critical)
    End Sub
End Class