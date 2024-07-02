Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmLotFailBag
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState

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
                    CType(Me.ParentForm, frmMain).FormMode.Text = "New"
                    Me.btnSave.Enabled = True
                    Me.btnSave.Text = "&Save"
                    Me.btnDelete.Enabled = False
                Case FormState.EStateMode
                    CType(Me.ParentForm, frmMain).FormMode.Text = "Edit"
                    Me.btnSave.Text = "&Update"
                    Me.btnDelete.Enabled = True
            End Select
        End Set
    End Property
    Private Sub frmLotFail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tbLotFail.SelectedIndex = 0

        Me.TransDt.CustomFormat = "dd/MM/yyyy"
        Me.TransDt.Value = DateTime.Now

        Me.fillLotNo()
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

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))
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
        If tbLotFail.SelectedIndex = 0 Then     ''for Create LotFail Bag
            Me.fillLotNo()
            Me.Clear_CForm()
        ElseIf tbLotFail.SelectedIndex = 1 Then ''for Receive LotFail Bag
            Me.fillRecLotFailBagNo()
            Me.bindReceiveGridView()
            Me.Clear_RForm()
        ElseIf tbLotFail.SelectedIndex = 2 Then ''for Update LotFail Bag
            Me.fillUpdLotFailBagNo()
            Me.Clear_UForm()
        ElseIf tbLotFail.SelectedIndex = 3 Then ''for Fill LotFail Bag
            Me.FillUpdatedData()
        End If
    End Sub
    Private Sub getLastLotNoVAmt()

        Dim strSQL As String = Nothing

        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        strSQL = "SELECT OperationId, OperationName, FrLabourId, frKarigarName, ReceivePr, ReceiveWt, ItemId, ItemName FROM udf_GetMaxLotTransNo('" & cmbCLotNo.Text.Trim() & "') ORDER BY MaxTransId"

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@TLotNo", cmbCLotNo.Text.Trim(), DbType.String))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader(strSQL, CommandType.Text, connection, parameters.ToArray())

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
            dbManager.CloseConnection(connection)
        End Try
    End Sub

    Private Sub txtLRecieveWt_TextChanged(sender As Object, e As EventArgs) Handles txtRReceiveWt.TextChanged
        Try
            txtRTotalWt.Text = Format(Val(txtRReceiveWt.Text) + Val(txtRSample.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtLRSampleWt_TextChanged(sender As Object, e As EventArgs) Handles txtRSample.TextChanged
        Try
            txtRTotalWt.Text = Format(Val(txtRReceiveWt.Text) + Val(txtRSample.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtUreceivePr_TextChanged(sender As Object, e As EventArgs) Handles txtUReceivePr.TextChanged
        Try
            txtUreceiveFineWt.Text = Format(Val(txtUReceivePr.Text) * Val(txtUreceiveWt.Text) / 100, "0.00")
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
            .Add(dbManager.CreateParameter("@ActionType", "FetchLotNo", DbType.String))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)

        'If dr.HasRows = False Then
        '    MessageBox.Show("No Data Exists !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        '    Exit Sub
        'End If

        cmbCLotNo.Items.Clear()
        cmbCLotNo.ResetText()

        Try
            While dr.Read
                If Not IsDBNull(dr.Item("LotNo")) Then
                    cmbCLotNo.Items.Add(dr.Item("LotNo"))
                End If
            End While

            cmbCLotNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbCLotNo.AutoCompleteDataSource = AutoCompleteSource.ListItems

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try

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
                'cmbRBagNo.DataSource = Nothing
                'cmbRBagNo.Items.Clear()

                'Insert the Default Item to DataTable.
                Dim row As DataRow = dt.NewRow()
                row(0) = 0
                row(1) = "---Select---"
                dt.Rows.InsertAt(row, 0)

                'Assign DataTable as DataSource.
                'cmbRBagNo.DataSource = dt
                'cmbRBagNo.DisplayMember = "LotFailBagNo"
                'cmbRBagNo.ValueMember = "LotFailId"

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
                'cmbULotFailNo.DataSource = Nothing
                'cmbULotFailNo.Items.Clear()

                'Insert the Default Item to DataTable.
                Dim row As DataRow = dt.NewRow()
                row(0) = 0
                row(1) = "---Select---"
                dt.Rows.InsertAt(row, 0)

                'Assign DataTable as DataSource.
                'cmbULotFailNo.DataSource = dt
                'cmbULotFailNo.DisplayMember = "BagSrNo"
                'cmbULotFailNo.ValueMember = "UsedBagId"

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally
                dr.Close()
                dbManager.CloseConnection(connection)
            End Try
        End If
    End Sub

#End Region

#Region "UpdateLotFailBag"
    Private Sub FetchLotFailBagDetails(ByVal sBagNo As String)

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

                Me.RadCollapsiblePanel1.ExpandDirection = RadDirection.Down

                If tbLotFail.SelectedIndex = 2 Then
                    txtUBagSrNo.Text = cmbUpdBagNo.EditorControl.CurrentRow.Cells(1).Value.ToString()
                End If

                If tbLotFail.SelectedIndex = 3 Then
                    cmbUpdBagNo.Text = dtData.Rows(0).Item("BagSrNo").ToString()
                    txtUBagSrNo.Text = dtData.Rows(0).Item("ItemName").ToString()
                End If

                txtUTransId.Text = dtData.Rows(0).Item("UsedBagId").ToString()
                UTransDt.Text = dtData.Rows(0).Item("UsedBagDt").ToString()
                txtUreceiveWt.Text = dtData.Rows(0).Item("ReceiveWt").ToString()
                txtUReceivePr.Text = dtData.Rows(0).Item("ReportPr").ToString()
                txtUreceiveFineWt.Text = dtData.Rows(0).Item("ReceiveFineWt").ToString()
                txtUIssueWt.Text = dtData.Rows(0).Item("IssueWt").ToString()
                txtUIssuePr.Text = dtData.Rows(0).Item("IssuePr").ToString()
                txtUIssueFineWt.Text = dtData.Rows(0).Item("IssueFineWt").ToString()
                txtUWtOnScale.Text = dtData.Rows(0).Item("WtOnScale").ToString()
                txtUcarbonReceive.Text = dtData.Rows(0).Item("CarbonReceive").ToString()
                txtUGrossLoss.Text = dtData.Rows(0).Item("LossWt").ToString()
            End If

            txtUReceivePr.Focus()

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally

        End Try
    End Sub
    Private Sub clearUpdateAllData()

        txtUTransId.Tag = ""
        txtUTransId.Clear()

        UTransDt.CustomFormat = "dd/MM/yyyy"
        UTransDt.Value = DateTime.Now()

        txtUReceivePr.Clear()
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

        'dgvCLotFail.AutoGenerateColumns = False
        'dgvCLotFail.DataSource = fetchAllRecords()

        'dgvCLotFail.EnableFiltering = True
        'dgvCLotFail.MasterTemplate.EnableFiltering = True

    End Sub
    Private Sub btnUSave_Click(sender As Object, e As EventArgs) Handles btnUSave.Click
        If Not UpdateValidate_Fields() Then Exit Sub

        Try
            Dim parameters = New List(Of SqlParameter)()

            If btnUSave.Text = "&Save" Then
                With parameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@ActionType", "UpdateLotFailBag", DbType.String))
                    .Add(dbManager.CreateParameter("@UReportPr", Val(txtUReceivePr.Text), DbType.Decimal))
                    .Add(dbManager.CreateParameter("@UId", Val(txtUTransId.Text), DbType.Int16))
                    .Add(dbManager.CreateParameter("@UBagSrNo", Convert.ToString(cmbUpdBagNo.Text.Trim), DbType.String))
                End With

                dbManager.Insert("SP_UsedBags_Update", CommandType.StoredProcedure, parameters.ToArray())
                MessageBox.Show("Data Saved..!!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                With parameters
                    .Add(dbManager.CreateParameter("@ActionType", "UpdateReportPr", DbType.String))
                    .Add(dbManager.CreateParameter("@TId", Val(txtUTransId.Text.Trim()), DbType.Int16))
                    .Add(dbManager.CreateParameter("@ReportPr", Convert.ToDecimal(txtUReceivePr.Text.Trim()), DbType.Decimal))
                    .Add(dbManager.CreateParameter("@LossWt", Convert.ToDecimal(txtULossFine.Text.Trim()), DbType.Decimal))
                    .Add(dbManager.CreateParameter("@BagNo", (cmbUpdBagNo.Text), DbType.String))
                End With

                dbManager.Update("SP_UsedBagNo_Update", CommandType.StoredProcedure, parameters.ToArray())
                MessageBox.Show("Data Updated..!!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)

                btnUSave.Text = "&Save"
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            Me.btnUCancel_Click(sender, e)
        End Try
    End Sub

    Private Sub txtRLWtOnScale_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRWtOnScale.KeyPress
        numdotkeypress(e, txtRWtOnScale, Me)
    End Sub
    Private Sub txtLRecieveWt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRReceiveWt.KeyPress
        numdotkeypress(e, txtRReceiveWt, Me)
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
    Private Sub Clear_CForm()
        Try
            txtCTransId.Clear()

            TransDt.CustomFormat = "dd/MM/yyyy"
            TransDt.Value = DateTime.Now

            txtOperation.Tag = ""
            txtOperation.Clear()

            txtLabour.Tag = ""
            txtLabour.Clear()

            cmbCLotNo.Text = ""
            cmbCLotNo.SelectedIndex = -1

            txtItemName.Clear()

            txtCLotFailWt.Clear()
            txtCLotFailPr.Clear()
            txtRemarks.Clear()

            txtMaxNo.Clear()

            btnSave.Text = "&Save"
            btnDelete.Enabled = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub cmbCLotNo_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbCLotNo.SelectedIndexChanged
        If cmbCLotNo.Text.Trim <> "" Then
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
    Private Sub txtUreceivePr_Leave(sender As Object, e As EventArgs) Handles txtUReceivePr.Leave
        txtUReceivePr.Text = Format(Val(txtUReceivePr.Text), "0.00")
    End Sub
    Private Sub btnRExit_Click(sender As Object, e As EventArgs)
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
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not String.IsNullOrEmpty(txtCTransId.Text.Trim) Then

            Try
                Dim parameters = New List(Of SqlParameter)()

                With parameters
                    .Clear()
                    parameters.Add(dbManager.CreateParameter("@LId", Val(txtCTransId.Text.Trim), DbType.Int16))
                End With

                dbManager.Delete("SP_LotFail_Delete", CommandType.StoredProcedure, parameters.ToArray())

                MessageBox.Show("Data Deleted !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Me.btnCancel_Click(sender, e)

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            End Try
        Else
            MessageBox.Show("Please Select A Record !!!")
        End If
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not Validate_Fields() Then Exit Sub

        Try
            Dim parameters = New List(Of SqlParameter)()

            If btnSave.Text = "&Save" Then

                With parameters
                    .Clear()
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

                dbManager.Insert("SP_LotFail_Save", CommandType.StoredProcedure, parameters.ToArray())

                MessageBox.Show("Data Saved !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                With parameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@ActionType", "UpdateData", DbType.String))
                    .Add(dbManager.CreateParameter("@LId", CInt(txtCTransId.Text), DbType.Int16))
                    .Add(dbManager.CreateParameter("@LRemark", txtRemarks.Text.Trim(), DbType.String))
                    .Add(dbManager.CreateParameter("@CreatedBy", UserName.Trim(), DbType.String))
                End With

                dbManager.Insert("SP_LotFail_Update", CommandType.StoredProcedure, parameters.ToArray())

                MessageBox.Show("Data Updated !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Me.btnCancel_Click(sender, e)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub btnRCancel_Click(sender As Object, e As EventArgs) Handles btnRCancel.Click
        Try
            Call Clear_RForm()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnUCancel_Click(sender As Object, e As EventArgs) Handles btnUCancel.Click
        Try
            Call Clear_UForm()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
            ElseIf Val(txtRReceiveWt.Text) <= 0 Then
                MessageBox.Show("Enter Lagdi Received !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtRReceiveWt.Focus()
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
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Function UpdateValidate_Fields() As Boolean
        Try

            If String.IsNullOrWhiteSpace(cmbUpdBagNo.Text.Trim()) Then
                MessageBox.Show("Select Bag No...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbUpdBagNo.Focus()
            ElseIf Val(txtUReceivePr.Text) <= 0 Then
                MessageBox.Show("Enter Receive % !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtUReceivePr.Focus()
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Sub cmbRBagNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRBagNo.SelectedIndexChanged
        If cmbRBagNo.SelectedIndex = -1 Then
            With dgvRLotFail
                dgvRLotFail.DataSource = Nothing
            End With
        ElseIf cmbRBagNo.SelectedIndex > 0 Then
            Me.bindReceiveGridView()
            Me.DisableBtn()
        End If
    End Sub
    Private Sub Clear_RForm()
        Try
            txtRTransId.Tag = ""
            txtRTransId.Clear()

            Me.RTransDt.CustomFormat = "dd/MM/yyyy"
            RTransDt.Value = DateTime.Now

            cmbRBagNo.SelectedIndex = 0
            txtRBagName.Clear()

            txtRLotFailWt.Clear()
            txtRLotFailPr.Clear()
            txtRWtOnScale.Clear()
            txtRReceiveWt.Clear()
            txtRSample.Clear()
            txtRTotalWt.Clear()
            txtRCarbon.Clear()
            txtRGrossLoss.Clear()

            dgvRLotFail.DataSource = Nothing

            btnRSave.Text = "&Save"
            btnREdit.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub Clear_UForm()
        Try

            txtUTransId.Tag = ""
            txtUTransId.Clear()

            Me.UTransDt.CustomFormat = "dd/MM/yyyy"
            UTransDt.Value = DateTime.Now()

            cmbUpdBagNo.Text = ""
            txtUBagSrNo.Clear()

            txtUReceivePr.Clear()
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

            btnUSave.Text = "&Save"
            btnUEdit.Enabled = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub fillRecLotFailBagNo()
        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchRLotFailBag", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_LotFail_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)

        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            'Insert the Default Item to DataTable.
            Dim newBlankRow As DataRow = dt.NewRow()
            dt.Rows.InsertAt(newBlankRow, 0)
            'Assign DataTable as DataSource.
            cmbRBagNo.DataSource = dt
            cmbRBagNo.AutoFilter = True
            cmbRBagNo.DisplayMember = "LotFailBagNo"
            cmbRBagNo.ValueMember = "LotFailBagNo"
            cmbRBagNo.Text = ""
            cmbRBagNo.Refresh()
            cmbRBagNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbRBagNo.BestFitColumns(True, False)

            cmbRBagNo.Columns(0).IsVisible = True
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
    Private Sub fillUpdLotFailBagNo()
        Dim connection As SqlConnection = Nothing
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchULotFailBag", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_LotFail_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)

        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            'Insert the Default Item to DataTable.
            Dim newBlankRow As DataRow = dt.NewRow()
            dt.Rows.InsertAt(newBlankRow, 0)
            'Assign DataTable as DataSource.
            cmbUpdBagNo.DataSource = dt
            cmbUpdBagNo.AutoFilter = True
            cmbUpdBagNo.DisplayMember = "BagSrNo"
            cmbUpdBagNo.ValueMember = "BagSrNo"
            cmbUpdBagNo.Text = ""
            cmbUpdBagNo.Refresh()
            cmbUpdBagNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbUpdBagNo.BestFitColumns(True, False)

            cmbUpdBagNo.Columns(0).IsVisible = True
            cmbUpdBagNo.Columns(1).Width = 200
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
    Private Sub bindReceiveGridView()
        Dim dt As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "SearchByBagNo", DbType.String))
                .Add(dbManager.CreateParameter("@BagSrNo", Convert.ToString(cmbRBagNo.Text.Trim), DbType.String))
            End With

            dt = dbManager.GetDataTable("SP_LotFail_Select", CommandType.StoredProcedure, parameters.ToArray())

            dgvRLotFail.DataSource = Nothing

            If dt.Rows.Count > 0 Then
                dgvRLotFail.DataSource = dt
            End If

            Me.ReceiveGridViewTotal()

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

    End Sub
    Private Sub bindReceiveGridView(ByVal sUBagNo As String)
        Dim dt As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "SearchByBagNo", DbType.String))
                .Add(dbManager.CreateParameter("@BagSrNo", Convert.ToString(cmbRBagNo.Text.Trim), DbType.String))
            End With

            dt = dbManager.GetDataTable("SP_LotFail_Select", CommandType.StoredProcedure, parameters.ToArray())

            dgvRLotFail.DataSource = Nothing

            If dt.Rows.Count > 0 Then
                dgvRLotFail.DataSource = dt
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

    End Sub
    Private Sub ReceiveGridViewTotal()
        Dim dSumOfLossWt As Decimal = 0
        Dim dSumOfLossPr As Decimal = 0

        Try
            For Each row As GridViewRowInfo In dgvRLotFail.Rows
                dSumOfLossWt += CDec(Val(row.Cells(5).Value))
                dSumOfLossPr += CDec(Val(row.Cells(6).Value))
            Next

            txtRBagName.Text = cmbRBagNo.EditorControl.CurrentRow.Cells(1).Value.ToString()
            txtRLotFailWt.Text = dSumOfLossWt.ToString("N2")
            txtRLotFailPr.Text = dSumOfLossPr.ToString("N2")

            txtRWtOnScale.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub fillLotfailforReceive(ByVal sUBagNo As String)
        Dim dttable As New DataTable
        dttable = fetchAllDetailsRUpdate(Convert.ToString(sUBagNo))

        dgvRLotFail.DataSource = Nothing
        dgvRLotFail.DataSource = dttable

        Me.FetchUsedBagsDetails(sUBagNo)
    End Sub
    Private Sub dgvFinalUpdate_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles dgvFinalUpdate.CellDoubleClick
        If dgvFinalUpdate.Rows.Count > 0 Then
            Dim sLotFailBagNo As String = dgvFinalUpdate.Rows(e.RowIndex).Cells(2).Value.ToString()

            Me.FetchLotFailBagDetails(sLotFailBagNo)

            btnUSave.Text = "&Update"
            btnUEdit.Enabled = False
            tbLotFail.SelectedIndex = 2
        End If
    End Sub
    Private Function fetchAllDetailsRUpdate(ByVal sBagNo As String) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FillRScrapDetailsUpdate", DbType.String))
                .Add(dbManager.CreateParameter("@BagSrNo", Trim(sBagNo), DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_ScrapBags_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
    Private Sub FillUpdatedData()
        Dim dtable As DataTable = fetchAllDetails()

        If dtable.Rows.Count > 0 Then
            dgvFinalUpdate.DataSource = dtable
            dgvFinalUpdate.ReadOnly = True
        Else
            MessageBox.Show("Data Not Available For Update")
        End If

    End Sub
    Private Sub btnUpdEdit_Click(sender As Object, e As EventArgs) Handles btnUEdit.Click
        Fr_Mode = FormState.EStateMode

        If cmbUpdBagNo.SelectedIndex <= 0 Then
            MessageBox.Show("Please Select Bag No To Edit Records")
        Else
            cmbRBagNo.Text = Me.cmbUpdBagNo.EditorControl.CurrentRow.Cells(0).Value

            Me.bindReceiveGridView(cmbRBagNo.Text.Trim)
            Me.FetchUsedBagsDetails(cmbRBagNo.Text.Trim)

            tbLotFail.SelectedIndex = 1

            btnRSave.Text = "&Update"
            btnREdit.Enabled = False
        End If
    End Sub
    Private Function fetchAllDetails() As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchLUsedUBagData", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_LotFail_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
    Private Function fetchAllDetails(ByVal iUsedBagId As Integer) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchUpdatedBagDataById", DbType.String))
                .Add(dbManager.CreateParameter("@BId", CInt(iUsedBagId), DbType.Int16))
            End With

            dtData = dbManager.GetDataTable("SP_UsedBags_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
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
                txtRLotFailWt.Text = dtData.Rows(0).Item("IssueWt").ToString()
                txtRLotFailPr.Text = dtData.Rows(0).Item("IssuePr").ToString()
                txtRWtOnScale.Text = dtData.Rows(0).Item("WtOnScale").ToString()
                txtRReceiveWt.Text = dtData.Rows(0).Item("ReceiveWt").ToString()
                txtRSample.Text = dtData.Rows(0).Item("TFSampleWt").ToString()
                txtRCarbon.Text = dtData.Rows(0).Item("CarbonReceive").ToString()
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally

        End Try
    End Sub
    Private Sub FetchLotfailDataCUpdate(ByVal sBagNo As String)
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "SearchByBagNo", DbType.String))
                .Add(dbManager.CreateParameter("@BagSrNo", Trim(sBagNo), DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_LotFail_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                txtCTransId.Text = dtData.Rows(0).Item("LotFailId").ToString()
                txtMaxNo.Text = dtData.Rows(0).Item("LotFailBagNo").ToString()
                cmbCLotNo.Text = dtData.Rows(0).Item("LotNo").ToString()
                txtOperation.Tag = dtData.Rows(0).Item("OperationId").ToString()
                txtOperation.Text = dtData.Rows(0).Item("OperationName").ToString()
                txtLabour.Tag = dtData.Rows(0).Item("LabourId").ToString()
                txtLabour.Text = dtData.Rows(0).Item("LabourName").ToString()
                txtItemName.Tag = dtData.Rows(0).Item("ItemId").ToString()
                txtItemName.Text = dtData.Rows(0).Item("ItemName").ToString()
                txtCLotFailWt.Text = dtData.Rows(0).Item("LotFailWt").ToString()
                txtCLotFailPr.Text = dtData.Rows(0).Item("LotFailPr").ToString()
                txtRemarks.Text = dtData.Rows(0).Item("Remark").ToString()
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally

        End Try
    End Sub
    Private Sub btnREdit_Click(sender As Object, e As EventArgs) Handles btnREdit.Click
        If btnREdit.Text = "&Edit" Then
            Fr_Mode = FormState.EStateMode

            If dgvRLotFail.Rows.Count <= 0 And cmbRBagNo.SelectedIndex <= 0 Then
                MessageBox.Show("Please Select Bag No To Edit Records")
            Else
                lblMaxNo.Visible = True
                txtMaxNo.Visible = True

                cmbCLotNo.Text = Me.cmbRBagNo.EditorControl.CurrentRow.Cells(0).Value
                txtMaxNo.Text = Me.cmbRBagNo.EditorControl.CurrentRow.Cells(0).Value

                Me.FetchLotfailDataCUpdate(cmbRBagNo.Text.Trim)

                tbLotFail.SelectedIndex = 0

                btnSave.Text = "&Update"
                btnDelete.Enabled = True
            End If
        Else
            Me.UpdateReceiveData()
            Me.Clear_RForm()
            btnREdit.Text = "&Edit"
            btnRSave.Enabled = True
            Me.btnUCancel_Click(sender, e)
        End If
    End Sub
    Private Sub btnRSave_Click(sender As Object, e As EventArgs) Handles btnRSave.Click
        If Not ReceiveValidate_Fields() Then Exit Sub

        If String.IsNullOrWhiteSpace(cmbRBagNo.Text.Trim()) Then
            MessageBox.Show("Select Bag No !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            cmbRBagNo.Focus()
        Else
            Try
                Dim parameters = New List(Of SqlParameter)()

                If btnRSave.Text = "&Save" Then
                    With parameters
                        .Clear()
                        .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
                        .Add(dbManager.CreateParameter("@UBagDt", RTransDt.Value.ToString(), DbType.DateTime))

                        .Add(dbManager.CreateParameter("@UItemName", Convert.ToString(txtRBagName.Text.Trim), DbType.String))
                        .Add(dbManager.CreateParameter("@UBagSrNo", Convert.ToString(cmbRBagNo.EditorControl.CurrentRow.Cells(0).Value), DbType.String))

                        .Add(dbManager.CreateParameter("@UIssueWt", Val(txtRLotFailWt.Text), DbType.Decimal))
                        .Add(dbManager.CreateParameter("@UIssuePr", Val(txtRLotFailPr.Text), DbType.Decimal))

                        .Add(dbManager.CreateParameter("@UWtOnScale", Val(txtRWtOnScale.Text), DbType.Decimal))
                        .Add(dbManager.CreateParameter("@UReceiveWt", Val(txtRReceiveWt.Text), DbType.Decimal))
                        .Add(dbManager.CreateParameter("@UTFSample", Val(txtRSample.Text), DbType.Decimal))

                        .Add(dbManager.CreateParameter("@UCarbonReceive", Val(txtRCarbon.Text), DbType.Decimal))
                        .Add(dbManager.CreateParameter("@ULossWt", Val(txtRGrossLoss.Text), DbType.Decimal))

                        .Add(dbManager.CreateParameter("@UCreatedBy", UserName.Trim(), DbType.String))
                    End With

                    dbManager.Insert("SP_UsedBags_Save", CommandType.StoredProcedure, parameters.ToArray())
                    MessageBox.Show("Data Saved !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                If btnRSave.Text = "&Update" Then
                    With parameters
                        .Clear()
                        .Add(dbManager.CreateParameter("@ActionType", "EditData", DbType.String))
                        '.Add(dbManager.CreateParameter("@UBagDt", RTransDt.Value.ToString(), DbType.DateTime))

                        .Add(dbManager.CreateParameter("@UItemName", Convert.ToString(txtRBagName.Text.Trim), DbType.String))
                        .Add(dbManager.CreateParameter("@UBagSrNo", Convert.ToString(cmbRBagNo.Text.Trim()), DbType.String))

                        .Add(dbManager.CreateParameter("@UIssueWt", Val(txtRLotFailWt.Text), DbType.Decimal))
                        .Add(dbManager.CreateParameter("@UIssuePr", Val(txtRLotFailPr.Text), DbType.Decimal))

                        .Add(dbManager.CreateParameter("@UWtOnScale", Val(txtRWtOnScale.Text), DbType.String))
                        .Add(dbManager.CreateParameter("@UReceiveWt", Val(txtRReceiveWt.Text), DbType.String))
                        .Add(dbManager.CreateParameter("@UTFSample", Val(txtRSample.Text), DbType.String))

                        .Add(dbManager.CreateParameter("@UCarbonReceive", Val(txtRCarbon.Text), DbType.String))
                        .Add(dbManager.CreateParameter("@ULossWt", Val(txtRGrossLoss.Text), DbType.Decimal))

                        .Add(dbManager.CreateParameter("@UCreatedBy", UserName.Trim(), DbType.String))
                    End With

                    dbManager.Insert("SP_UsedBags_Edit", CommandType.StoredProcedure, parameters.ToArray())

                    MessageBox.Show("Data Update !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally
                Me.btnRCancel_Click(sender, e)
            End Try
        End If
    End Sub
    Private Sub txtUReceivePr_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUReceivePr.KeyPress
        numdotkeypress(e, txtUReceivePr, Me)
    End Sub
    Private Sub txtRWtOnScale_Leave(sender As Object, e As EventArgs) Handles txtRWtOnScale.Leave
        txtRWtOnScale.Text = Format(Val(txtRWtOnScale.Text), "0.00")
    End Sub
    Private Sub txtRReceiveWt_Leave(sender As Object, e As EventArgs) Handles txtRReceiveWt.Leave
        txtRReceiveWt.Text = Format(Val(txtRReceiveWt.Text), "0.00")
    End Sub
    Private Sub txtRSample_Leave(sender As Object, e As EventArgs) Handles txtRSample.Leave
        txtRSample.Text = Format(Val(txtRSample.Text), "0.00")
    End Sub
    Private Sub txtRCarbon_Leave(sender As Object, e As EventArgs) Handles txtRCarbon.Leave
        txtRCarbon.Text = Format(Val(txtRCarbon.Text), "0.00")
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Call Clear_CForm()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub cmbUpdBagNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUpdBagNo.SelectedIndexChanged
        If cmbUpdBagNo.SelectedIndex > 0 Then
            Me.FetchLotFailBagDetails(cmbUpdBagNo.Text.Trim)
        End If
    End Sub
    Private Sub UpdateReceiveData()
        Try
            Dim parameters = New List(Of SqlParameter)()

            If btnREdit.Text = "&Update" Then
                With parameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@ActionType", "UpdateRScrapBagData", DbType.String))
                    .Add(dbManager.CreateParameter("@UBagDt", RTransDt.Value.ToString(), DbType.DateTime))
                    .Add(dbManager.CreateParameter("@UBagSrNo", Convert.ToString(cmbRBagNo.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UWtOnScale", Val(txtRWtOnScale.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@URecieveWt", Val(txtRReceiveWt.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UTFSample", Val(txtRSample.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UCarbonReceive", Val(txtRCarbon.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UCreatedBy", UserName.Trim(), DbType.String))
                End With

                dbManager.Update("SP_UsedBags_Update", CommandType.StoredProcedure, parameters.ToArray())
                MessageBox.Show("Lotfail Bag Updated !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub DisableBtn()
        btnSave.Enabled = True
        btnCancel.Enabled = True
    End Sub
End Class
