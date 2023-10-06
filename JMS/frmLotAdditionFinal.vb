Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmLotAdditionFinal
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState

    Dim strSQL As String = Nothing
    Dim TempRow As Integer
    Dim GridDoubleClick As Boolean

    Dim dbManager As New SqlHelper()
    Dim Objcn As SqlConnection = New SqlConnection()

    Dim dIssueWt As Double = 0
    Dim dReceiveWt As Double = 0
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
    Private Sub frmLotAdditionFinal_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.fillLotNo()
        Me.fillLabour()
        Me.filltemName()

        Me.Clear_Form()

    End Sub
    Private Sub cmbLotNo_SelectedIndexChanged(sender As Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles cmbLotNo.SelectedIndexChanged
        If cmbLotNo.Text.Trim <> "" Then
            Me.fillLotIssueHeader(cmbLotNo.Text.Trim())

            ''Fill Receive Data Start
            Me.fillReceiveData(cmbLotNo.Text.Trim())

            If dgvReceive.RowCount > 0 Then
                Me.GridReceiveTotal()
            End If
            ''Fill Receive Data End

            ''Fill Issue Data Start
            fillIssueData(cmbLotNo.Text.Trim())

            If dgvIssue.RowCount > 0 Then
                Me.GridIssueTotal()
            End If
            ''Fill Issue Data End

            Me.ActualIssue()
        End If
    End Sub
    Private Sub fillLotIssueHeader(ByVal sLotNo As String)
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchHeaderRecord", DbType.String))
            .Add(dbManager.CreateParameter("@LotNo", Convert.ToString(sLotNo), DbType.String))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader("SP_LotAdditionIssue_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

        If dr.HasRows = False Then
            Exit Sub
        Else
            dr.Read()
            txtLotRecieveId.Tag = dr.Item("LotAdditionId").ToString
            txtLotRecieveId.Text = dr.Item("LotAdditionNo").ToString
            cmbItem.SelectedIndex = dr.Item("ItemId").ToString
            cmbItem.Text = dr.Item("ItemName").ToString
            txtIssueWt.Text = dr.Item("IssueWt").ToString
            txtIssuePr.Text = dr.Item("IssuePr").ToString
            txtFrKarigar.Tag = dr.Item("FrKarigarId").ToString
            txtFrKarigar.Text = dr.Item("FrKarigar").ToString
            cmbTLabour.SelectedIndex = dr.Item("ToKarigarId").ToString
        End If

        dr.Close()
        Objcn.Close()

        Exit Sub
ErrHandler:
        MsgBox(Err.Description, MsgBoxStyle.Critical)
    End Sub
    Private Sub fillReceiveData(ByVal sLotNo As String)
        Dim dttable As New DataTable
        dttable = FetchReceiveData(CStr(sLotNo))

        For Each Row As DataRow In dttable.Rows
            dgvReceive.Rows.Add(CStr(Row("SrNo")), CStr(Row("ItemName")), Format(Val(Row("ReceiveWt")), "0.00"), Format(Val(Row("ReceivePr")), "0.00"), Format(Val(Row("FineWt")), "0.000"))
        Next

    End Sub
    Private Sub fillIssueData(ByVal sLotNo As String)
        Dim dttable As New DataTable
        dttable = FetchIssueData(CStr(sLotNo))

        For Each Row As DataRow In dttable.Rows
            dgvIssue.Rows.Add(CStr(Row("SrNo")), CStr(Row("ItemName")), Format(Val(Row("IssueWt")), "0.00"), Format(Val(Row("IssuePr")), "0.00"), Format(Val(Row("FineWt")), "0.000"))
        Next

    End Sub
    Private Function FetchIssueData(ByVal strLotNo As String) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchIssueData", DbType.String))
                .Add(dbManager.CreateParameter("@LotNo", CStr(strLotNo), DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_LotAdditionReceive_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
    Private Function FetchReceiveData(ByVal strLotNo As String) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchReceiveData", DbType.String))
                .Add(dbManager.CreateParameter("@LotNo", CStr(strLotNo), DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_LotAdditionReceive_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
    Private Sub fillLotNo()
        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchLotNo", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_LotAdditionIssue_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)

        Try
            While dr.Read
                cmbLotNo.Items.Add(dr(0).ToString())
            End While

            cmbLotNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbLotNo.AutoCompleteDataSource = AutoCompleteSource.ListItems

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            Objcn.Close()
        End Try
    End Sub
    Private Sub fillLabour()
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FillLabour", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_LabourMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), Objcn)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            ''Insert the Default Item to DataTable.
            Dim row As DataRow = dt.NewRow()
            row(0) = 0
            row(1) = "---Select---"
            dt.Rows.InsertAt(row, 0)

            'Assign DataTable as DataSource.
            cmbTLabour.DataSource = dt
            cmbTLabour.DisplayMember = "LabourName"
            cmbTLabour.ValueMember = "LabourId"

            cmbTLabour.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbTLabour.AutoCompleteDataSource = AutoCompleteSource.ListItems

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            Objcn.Close()
        End Try
    End Sub
    Private Sub filltemName()

        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FillItemName", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_ItemMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            'Insert the Default Item to DataTable.
            Dim row As DataRow = dt.NewRow()
            row(0) = 0
            row(1) = "---Select---"
            dt.Rows.InsertAt(row, 0)

            'Assign DataTable as DataSource.
            cmbItem.DataSource = dt
            cmbItem.DisplayMember = "ItemName"
            cmbItem.ValueMember = "ItemId"

            cmbItem.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbItem.AutoCompleteDataSource = AutoCompleteSource.ListItems
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub GridIssueTotal()
        Try
            Dim dSumOfTotalIssueWt As Double = 0
            Dim dSumOfTotalIssueFine As Double = 0

            For Each row As GridViewRowInfo In dgvIssue.Rows
                dSumOfTotalIssueWt += Convert.ToDecimal(row.Cells(2).Value)
                dSumOfTotalIssueFine += Convert.ToDecimal(row.Cells(2).Value) * Convert.ToDecimal(row.Cells(3).Value) / 100
            Next

            txtTotalIssueWt.Text = Format(dSumOfTotalIssueWt, "0.00")
            txtTotalIssueFine.Text = Format(dSumOfTotalIssueFine, "0.000")

            txtTotalIssuePr.Text = Format((Val(dSumOfTotalIssueFine) / Val(dSumOfTotalIssueWt)) * 100, "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub GridReceiveTotal()
        Try
            Dim dSumOfTotalReceiveWt As Double = 0
            Dim dSumOfTotalReceiveFine As Double = 0

            For Each row As GridViewRowInfo In dgvReceive.Rows
                dSumOfTotalReceiveWt += Convert.ToDecimal(row.Cells(2).Value)
                dSumOfTotalReceiveFine += Convert.ToDecimal(row.Cells(2).Value) * Convert.ToDecimal(row.Cells(3).Value) / 100
            Next

            txtTotalReceiveWt.Text = Format(dSumOfTotalReceiveWt, "0.00")
            txtTotalReceiveFine.Text = Format(dSumOfTotalReceiveFine, "0.000")

            txtTotalReceivePr.Text = Format((Val(dSumOfTotalReceiveFine) / Val(dSumOfTotalReceiveWt)) * 100, "0.00")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtChain_Leave(sender As Object, e As EventArgs) Handles txtChain.Leave
        txtChain.Text = Format(Val(txtChain.Text), "0.00")
    End Sub
    Private Sub txtBhuka_Leave(sender As Object, e As EventArgs) Handles txtBhuka.Leave
        txtBhuka.Text = Format(Val(txtBhuka.Text), "0.00")
    End Sub
    Private Sub txtSample_Leave(sender As Object, e As EventArgs) Handles txtSample.Leave
        txtSample.Text = Format(Val(txtSample.Text), "0.00")
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Call Clear_Form()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub bindDataGridView()
        Dim dtdata As DataTable = fetchAllRecords()

        Try
            dgvLotFinal.DataSource = dtdata
            dgvLotFinal.EnableFiltering = True
            dgvLotFinal.MasterTemplate.ShowFilteringRow = False
            dgvLotFinal.MasterTemplate.ShowHeaderCellButtons = True
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

            dtData = dbManager.GetDataTable("SP_LotAdditionReceive_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not Validate_Fields() Then Exit Sub

        Try
            If Fr_Mode = FormState.AStateMode Then
                Me.SaveData()
                Me.btnCancel_Click(sender, e)
            Else

            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub SaveData()
        Dim alParaval As New ArrayList

        Dim iOperationId As Integer = 24      ''Operation Id for Lot Addition Final
        Dim iOperationTypeId As Integer = 11  ''Operation Type Id for Lot Addition Final

        Dim GridSrNo As String = ""
        Dim ItemId As String = ""
        Dim ReceivePr As String = ""
        Dim ReceiveWt As String = ""
        Dim Remarks As String = ""

        Dim IRowCount As Integer = 0
        Dim iValue As Integer = 0

        alParaval.Add(TransDt.Value.ToString())
        alParaval.Add(cmbItem.SelectedIndex)
        alParaval.Add(iOperationId)
        alParaval.Add(iOperationTypeId)
        alParaval.Add(cmbLotNo.Text.Trim)
        alParaval.Add(txtLotRecieveId.Text.Trim())
        alParaval.Add(txtChain.Text)
        alParaval.Add(txtBhuka.Text)
        alParaval.Add(txtSample.Text)

        alParaval.Add(txtLoss.Text)

        alParaval.Add(txtFrKarigar.Tag)
        alParaval.Add(cmbTLabour.SelectedIndex)

        alParaval.Add(cmbItem.SelectedIndex)
        alParaval.Add(txtActualIssuePr.Text.Trim)
        alParaval.Add(txtActualIssueWt.Text.Trim)
        alParaval.Add(Remarks)

        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()

            With Hparameters
                .Add(dbManager.CreateParameter("@HLotAdditionDt", alParaval.Item(iValue), DbType.DateTime))
                iValue += 1
                .Add(dbManager.CreateParameter("@HItemId", alParaval.Item(iValue), DbType.Int16))
                iValue += 1
                .Add(dbManager.CreateParameter("@HOperationId ", alParaval.Item(iValue), DbType.Int16))
                iValue += 1
                .Add(dbManager.CreateParameter("@HOperationTypeId", alParaval.Item(iValue), DbType.Int16))
                iValue += 1
                .Add(dbManager.CreateParameter("@HLotNo", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@HLotAdditionNo", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@HChain", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@HBhuka", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@HSample", alParaval.Item(iValue), DbType.String))
                iValue += 1

                .Add(dbManager.CreateParameter("@HLoss", alParaval.Item(iValue), DbType.String))
                iValue += 1

                .Add(dbManager.CreateParameter("@FrKarigarId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@ToKarigarId", alParaval.Item(iValue), DbType.String))
                iValue += 1

                .Add(dbManager.CreateParameter("@HCreatedBy", UserName.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@HIsOpening", 1, DbType.Boolean))

                'For Transaction
                .Add(dbManager.CreateParameter("@TReceiveWt", txtChain.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@TReceivePr", txtActualIssuePr.Text.Trim(), DbType.String))

                .Add(dbManager.CreateParameter("@TIssueWt", txtActualIssueWt.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@TIssuePr", txtActualReceivePr.Text.Trim, DbType.String))
                'For Transaction

                .Add(dbManager.CreateParameter("@DItemId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DRecievePr", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DRecieveWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DRemarks", alParaval.Item(iValue), DbType.String))
                iValue += 1
            End With

            dbManager.Insert("SP_LotAdditionTReceive_Save", CommandType.StoredProcedure, Hparameters.ToArray())

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
    Private Sub frmLotAdditionFinal_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
            If (e.Alt AndAlso (e.KeyCode = Keys.S)) Then
                ' When Alt + S is pressed, the Click event for the print
                ' button is raised.
                btnSave().PerformClick()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function ErrorValid() As Boolean
        Try
            Dim bln As Boolean = True

            'If txtChain.Text.Trim.Length = 0 Then
            '    ObjEp.SetError(txtChain, "Enter Chain Wt.")
            '    bln = False
            'End If

            'If txtBhuka.Text.Trim.Length = 0 Then
            '    ObjEp.SetError(txtBhuka, "Select Bhuka Wt.")
            '    bln = False
            'End If

            'If txtSample.Text.Trim.Length = 0 Then
            '    ObjEp.SetError(txtBhuka, "Select Sample Wt.")
            '    bln = False
            'End If

            Return bln
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Sub cmbLotNo_Enter(sender As Object, e As EventArgs) Handles cmbLotNo.Enter
        cmbLotNo.ShowDropDown()
    End Sub
    Private Sub cmbItem_Enter(sender As Object, e As EventArgs) Handles cmbItem.Enter
        cmbItem.ShowDropDown()
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub rbKdm_CheckedChanged(sender As Object, e As EventArgs) Handles rbKdm.CheckedChanged
        Me.Calculate()

        If rbKdm.Checked = True Then
            txtLoss.Text = Format(Val(txtActualIssueWt.Text) - Val(txtActualRecieveWt.Text), "0.00")
            txtPowder.Text = 0
        Else
            txtPowder.Text = Format(Val(txtActualIssueWt.Text) - Val(txtActualRecieveWt.Text), "0.00")
            txtLoss.Text = 0
        End If
    End Sub
    Private Sub cmbTLabour_Enter(sender As Object, e As EventArgs) Handles cmbTLabour.Enter
        cmbTLabour.ShowDropDown()
    End Sub
    Private Sub Clear_Form()
        Try

            'ObjEp.Clear()

            ''For Header Field Start
            txtLotRecieveId.Tag = ""
            txtLotRecieveId.Clear()
            TransDt.Value = DateTime.Now()
            rbKdm.Checked = True

            'cmbGridItem.SelectedIndex = 0
            cmbItem.SelectedIndex = 0
            txtFrKarigar.Clear()
            cmbTLabour.SelectedIndex = 0

            ''cmbLotNo.Items.Clear()
            cmbLotNo.SelectedIndex = -1
            txtIssueWt.Clear()
            txtIssuePr.Clear()

            ''For Header Field End

            dgvIssue.RowCount = 0
            dgvReceive.RowCount = 0

            txtChain.Clear()
            txtBhuka.Clear()
            txtSample.Clear()
            txtLoss.Clear()
            txtTotal.Clear()

            txtPowder.Clear()
            txtReceivePr.Clear()
            txtTotalIssueWt.Clear()
            txtTotalReceiveWt.Clear()
            txtActualIssueWt.Clear()
            txtActualRecieveWt.Clear()

            txtTotalIssuePr.Clear()
            txtTotalReceivePr.Clear()
            txtActualReceivePr.Clear()
            txtActualIssuePr.Clear()

            txtTotalIssueFine.Clear()
            txtTotalReceiveFine.Clear()
            txtActualIssueFine.Clear()
            txtActualRecieveFine.Clear()

            ''For Detail Field End

            GridDoubleClick = False

            Me.bindDataGridView()

            Fr_Mode = FormState.AStateMode

            TransDt.Focus()
            TransDt.Select()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        Me.Calculate()
    End Sub
    Private Function Validate_Fields() As Boolean
        Try
            If cmbLotNo.Text.Trim() = "" Then
                MessageBox.Show("Enter Lot Number !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbLotNo.Focus()
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Sub Calculate()
        Me.ActualReceiveWt()
        Me.ActualReceivePr()
    End Sub
    Private Sub ActualIssue()
        Try
            txtActualIssueWt.Text = Format(Val(txtTotalIssueWt.Text) - Val(txtTotalReceiveWt.Text), "0.00")
            txtActualIssueFine.Text = Format((Val(txtTotalIssueFine.Text) - Val(txtTotalReceiveFine.Text)), "0.00")

            txtActualRecieveFine.Text = Format(Val(txtActualIssueFine.Text), "0.00")

            txtActualIssuePr.Text = Format((Val(txtActualIssueFine.Text) / Val(txtActualIssueWt.Text)) * 100, "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtChain_TextChanged(sender As Object, e As EventArgs) Handles txtChain.TextChanged
        Try
            If rbKdm.Checked = True Then
                txtTotal.Text = Format(Val(txtChain.Text) + Val(txtBhuka.Text) + Val(txtSample.Text) + Val(txtLoss.Text), "0.00")
                txtActualRecieveWt.Text = Format(Val(txtChain.Text) + Val(txtBhuka.Text) + Val(txtSample.Text), "0.00")
            Else
                txtTotal.Text = Format(Val(txtChain.Text) + Val(txtBhuka.Text) + Val(txtSample.Text) + Val(txtLoss.Text), "0.00")
                txtActualRecieveWt.Text = Format(Val(txtChain.Text) + Val(txtBhuka.Text) + Val(txtSample.Text) + Val(txtLoss.Text), "0.00")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtActualIssueWt_TextChanged(sender As Object, e As EventArgs) Handles txtActualIssueWt.TextChanged
        Try
            If rbKdm.Checked = True Then
                txtLoss.Text = Format(Val(txtActualIssueWt.Text) - Val(txtActualRecieveWt.Text), "0.00")
                txtPowder.Text = 0
            Else
                txtPowder.Text = Format(Val(txtActualIssueWt.Text) - Val(txtActualRecieveWt.Text), "0.00")
                txtLoss.Text = 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtActualRecieveWt_TextChanged(sender As Object, e As EventArgs) Handles txtActualRecieveWt.TextChanged
        Try
            ''txtActualIssuePr.Text = IIf(Val(txtActualRecieveFine.Text) = 0 Or Val(txtActualRecieveWt.Text) = 0, 0, Format((Val(txtActualRecieveFine.Text) / Val(txtActualRecieveWt.Text)) * 100, "0.00"))
            ''txtActualIssuePr.Text = Format((Val(txtActualRecieveFine.Text) / Val(txtActualRecieveWt.Text)) * 100, "0.00")

            'txtActualIssuePr.Text = IIf(Val(txtActualIssueFine.Text) = 0 Or Val(txtActualIssueWt.Text) = 0, 0, Format((Val(txtActualIssueFine.Text) / Val(txtActualIssueWt.Text)) * 100, "0.00"))
            'txtActualIssuePr.Text = Format((Val(txtActualIssueFine.Text) / Val(txtActualIssueWt.Text)) * 100, "0.00")

            If rbKdm.Checked = True Then
                txtLoss.Text = Format(Val(txtActualIssueWt.Text) - Val(txtActualRecieveWt.Text), "0.00")
                txtPowder.Text = 0
            Else
                txtPowder.Text = Format(Val(txtActualIssueWt.Text) - Val(txtActualRecieveWt.Text), "0.00")
                txtLoss.Text = 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtBhuka_TextChanged(sender As Object, e As EventArgs) Handles txtBhuka.TextChanged
        Try
            If rbKdm.Checked = True Then
                txtTotal.Text = Format(Val(txtChain.Text) + Val(txtBhuka.Text) + Val(txtSample.Text) + Val(txtLoss.Text), "0.00")
                txtActualRecieveWt.Text = Format(Val(txtChain.Text) + Val(txtBhuka.Text) + Val(txtSample.Text), "0.00")
            Else
                txtTotal.Text = Format(Val(txtChain.Text) + Val(txtBhuka.Text) + Val(txtSample.Text) + Val(txtLoss.Text), "0.00")
                txtActualRecieveWt.Text = Format(Val(txtChain.Text) + Val(txtBhuka.Text) + Val(txtSample.Text) + Val(txtLoss.Text), "0.00")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtSample_TextChanged(sender As Object, e As EventArgs) Handles txtSample.TextChanged
        Try
            If rbKdm.Checked = True Then
                txtTotal.Text = Format(Val(txtChain.Text) + Val(txtBhuka.Text) + Val(txtSample.Text) + Val(txtLoss.Text), "0.00")
                txtActualRecieveWt.Text = Format(Val(txtChain.Text) + Val(txtBhuka.Text) + Val(txtSample.Text), "0.00")
            Else
                txtTotal.Text = Format(Val(txtChain.Text) + Val(txtBhuka.Text) + Val(txtSample.Text) + Val(txtLoss.Text), "0.00")
                txtActualRecieveWt.Text = Format(Val(txtChain.Text) + Val(txtBhuka.Text) + Val(txtSample.Text) + Val(txtLoss.Text), "0.00")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ActualReceiveWt()
        Try

            If rbKdm.Checked = True Then
                txtActualRecieveWt.Text = Format(Val(txtChain.Text) + Val(txtBhuka.Text) + Val(txtSample.Text), "0.00")
                txtTotal.Text = Format(Val(txtChain.Text) + Val(txtBhuka.Text) + Val(txtSample.Text) + Val(txtLoss.Text), "0.00")

                txtLoss.Text = Format(Val(txtActualIssueWt.Text) - Val(txtActualRecieveWt.Text), "0.00")
                txtPowder.Text = 0
            Else
                txtActualRecieveWt.Text = Format(Val(txtChain.Text) + Val(txtBhuka.Text) + Val(txtSample.Text) + Val(txtLoss.Text), "0.00")
                txtTotal.Text = Format(Val(txtChain.Text) + Val(txtBhuka.Text) + Val(txtSample.Text) + Val(txtLoss.Text), "0.00")

                txtPowder.Text = Format(Val(txtActualIssueWt.Text) - Val(txtActualRecieveWt.Text), "0.00")
                txtLoss.Text = 0
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ActualReceivePr()
        Try
            If rbKdm.Checked = True Then
                txtActualIssuePr.Text = Format((Val(txtActualIssueFine.Text) / Val(txtActualIssueWt.Text)) * 100, "0.00")
                txtActualReceivePr.Text = Format(Val(txtActualIssuePr.Text), "0.00")

                txtReceivePr.Text = Format(Val(txtActualReceivePr.Text), "0.00")
            Else
                If Not txtActualRecieveFine.Text.Trim.Length = 0 Or txtActualRecieveWt.Text.Trim.Length = 0 Then
                    txtActualReceivePr.Text = Format((Val(txtActualRecieveFine.Text) / Val(txtActualRecieveWt.Text)) * 100, "0.00")

                    txtReceivePr.Text = Format(Val(txtActualReceivePr.Text), "0.00")
                Else
                    txtActualReceivePr.Clear()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub rbPowder_CheckedChanged(sender As Object, e As EventArgs) Handles rbPowder.CheckedChanged
        'Me.Calculate()

        If rbKdm.Checked = True Then
            txtLoss.Text = Format(Val(txtActualIssueWt.Text) - Val(txtActualRecieveWt.Text), "0.00")
            txtPowder.Text = 0
        Else
            txtPowder.Text = Format(Val(txtActualIssueWt.Text) - Val(txtActualRecieveWt.Text), "0.00")
            txtLoss.Text = 0
        End If
    End Sub
    Private Sub txtSample_LostFocus(sender As Object, e As EventArgs) Handles txtSample.LostFocus
        Me.btnCalculate_Click(sender, e)
    End Sub
End Class