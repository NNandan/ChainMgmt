﻿Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.UI.Data
Public Class frmStockIssue
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState

    Dim strSQL As String = Nothing
    Dim TempRow As Integer
    Dim GridDoubleClick As Boolean

    Dim dbManager As New SqlHelper()
    Dim Objcn As SqlConnection = New SqlConnection()
    Private Objerr As New ErrorProvider()
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
                    lblLotNo.Visible = False
                    txtVocucherNo.Visible = False
                Case FormState.EStateMode
                    CType(Me.ParentForm, frmMain).FormMode.Text = "Edit"
                    Me.btnSave.Text = "&Update"
                    Me.btnDelete.Enabled = True
                    lblLotNo.Visible = True
                    txtVocucherNo.Visible = True
            End Select
        End Set
    End Property
    Private Sub frmStockIssue_Load(sender As Object, e As EventArgs) Handles Me.Load

        If dtUserRights.Rows.Count > 0 Then
            Dim DtRow() As DataRow = dtUserRights.Select("FormName = 'ACCOUNT MASTER'")
            USERADD = DtRow(0).Item(3)
            USEREDIT = DtRow(0).Item(4)
            USERVIEW = DtRow(0).Item(5)
            USERDELETE = DtRow(0).Item(6)
            DeptId = DtRow(0).Item(7)

            If USEREDIT = False And USERDELETE = False Then
                MsgBox("Insufficient Rights")
                btnDelete.Enabled = False
            End If
        End If

        cmbfDepartment.Select()

        Me.fillDepartment()
        Me.fillLabour()
        Me.fillGridCmbItemName()
        Me.fillParty()
        Me.Clear_Form()
    End Sub
    Private Sub fillDepartment()
        Dim connection As SqlConnection = Nothing
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_DepartmentMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim Odt As DataTable = New DataTable()

        Odt.Load(dr)

        Dim Cdt As DataTable = Odt.Copy()

        Try
            ''Insert the Default Item to DataTable.
            Dim frow As DataRow = Odt.NewRow()
            frow(0) = 0
            frow(1) = "---Select---"
            Odt.Rows.InsertAt(frow, 0)

            ''Assign DataTable as DataSource.
            cmbfDepartment.DataSource = Odt
            cmbfDepartment.DisplayMember = "DepartmentName"
            cmbfDepartment.ValueMember = "DepartmentId"

            ''Insert the Default Item to DataTable.
            Dim trow As DataRow = Cdt.NewRow()
            trow(0) = 0
            trow(1) = "---Select---"
            Cdt.Rows.InsertAt(trow, 0)

            cmbtDepartment.DataSource = Cdt
            cmbtDepartment.DisplayMember = "DepartmentName"
            cmbtDepartment.ValueMember = "DepartmentId"
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
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
            cmbtEmployee.DataSource = dt
            cmbtEmployee.DisplayMember = "LabourName"
            cmbtEmployee.ValueMember = "LabourId"

            cmbtEmployee.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbtEmployee.AutoCompleteDataSource = AutoCompleteSource.ListItems
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            Objcn.Close()
        End Try
    End Sub
    Private Sub fillParty()
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FillPartyCmb", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_PartyMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), Objcn)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            ''Insert the Default Item to DataTable.
            Dim trow As DataRow = dt.NewRow()
            trow(0) = 0
            trow(1) = "---Select---"
            dt.Rows.InsertAt(trow, 0)

            cmbParty.DataSource = dt
            cmbParty.DisplayMember = "PartyName"
            cmbParty.ValueMember = "PartyId"

            'Set AutoCompleteMode.
            cmbParty.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbParty.AutoCompleteDataSource = AutoCompleteSource.ListItems
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            Objcn.Close()
        End Try
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim TmpLotNo As String = Nothing

        If Not Validate_Fields() Then Exit Sub

        Try
            If Fr_Mode = FormState.AStateMode Then
                Dim Dt As DataTable = Me.SaveData()

                TmpLotNo = Dt.Rows(0).Item(0)

                MessageBoxTimer(TmpLotNo)

                Me.btnCancel_Click(sender, e)
            Else
                Me.UpdateData()
                Me.btnCancel_Click(sender, e)
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub txtGrossWt_TextChanged(sender As Object, e As EventArgs) Handles txtGrossWt.TextChanged
        Try
            txtFineWt.Text = Format((Val(txtGrossWt.Text) * Val(txtGrossPr.Text)) / 100, "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtGrossPr_TextChanged(sender As Object, e As EventArgs) Handles txtGrossPr.TextChanged
        Try
            txtFineWt.Text = Format((Val(txtGrossWt.Text) * Val(txtGrossPr.Text)) / 100, "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtNarration_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtNarration.Validating
        Try
            If cmbItem.SelectedIndex > 0 And Val(txtGrossWt.Text.Trim) > 0 And Val(txtGrossPr.Text.Trim) > 0 And cmbParty.SelectedIndex > 0 Then
                Me.fillGrid()
                Me.Total()
            Else
                MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub fillGridCmbItemName()
        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FillOnlyItemName", DbType.String))
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
    Private Function SaveData() As DataTable
        Dim Dt As DataTable = Nothing

        Dim alParaval As New ArrayList

        Dim GridSrNo As String = Nothing
        Dim ItemName As String = Nothing
        Dim IssueWt As String = Nothing
        Dim IssuePr As String = Nothing
        Dim FineWt As String = Nothing
        Dim PartyName As String = Nothing
        Dim Narration As String = Nothing

        Dim IRowCount As Integer = 0
        Dim iValue As Integer = 0

        ''For Master
        alParaval.Add(TransDt.Value.ToString())
        alParaval.Add(cmbfDepartment.SelectedValue)
        alParaval.Add(cmbtDepartment.SelectedIndex)
        alParaval.Add(txtFrEmployee.Tag)
        alParaval.Add(cmbtEmployee.SelectedValue)

        ''For Details
        For Each row As GridViewRowInfo In dgvIssue.Rows
            If row.Cells(0).Value <> Nothing Then
                If GridSrNo = "" Then
                    GridSrNo = Val(row.Cells(0).Value)
                    ItemName = row.Cells(2).Value.ToString()
                    IssueWt = Val(row.Cells(3).Value)
                    IssuePr = Val(row.Cells(4).Value)
                    FineWt = Convert.ToDouble(row.Cells(5).Value)
                    PartyName = row.Cells(7).Value.ToString
                    Narration = Convert.ToString(row.Cells(8).Value)
                Else
                    GridSrNo = GridSrNo & "|" & Val(row.Cells(0).Value)
                    ItemName = ItemName & "|" & row.Cells(2).Value.ToString()
                    IssueWt = IssueWt & "|" & Val(row.Cells(3).Value)
                    IssuePr = IssuePr & "|" & Val(row.Cells(4).Value)
                    FineWt = FineWt & "|" & Val(row.Cells(5).Value)
                    PartyName = PartyName & "|" & row.Cells(7).Value.ToString()
                    Narration = Narration & "|" & Convert.ToString(row.Cells(8).Value)
                End If
            End If
            IRowCount += 1
        Next

        alParaval.Add(ItemName)
        alParaval.Add(IssueWt)
        alParaval.Add(IssuePr)
        alParaval.Add(FineWt)
        alParaval.Add(PartyName)
        alParaval.Add(Narration)

        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()

            With Hparameters
                .Add(dbManager.CreateParameter("@HIssueDt", alParaval.Item(iValue), DbType.DateTime))
                iValue += 1
                .Add(dbManager.CreateParameter("@HfDeptId", alParaval.Item(iValue), DbType.Int16))
                iValue += 1
                .Add(dbManager.CreateParameter("@HtDeptId", alParaval.Item(iValue), DbType.Int16))
                iValue += 1

                .Add(dbManager.CreateParameter("@HFrKarigarId", alParaval.Item(iValue), DbType.Int16))
                iValue += 1
                .Add(dbManager.CreateParameter("@HToKarigarId", alParaval.Item(iValue), DbType.Int16))
                iValue += 1

                .Add(dbManager.CreateParameter("@HCreatedBy", UserName.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@GridCount", IRowCount, DbType.Int16))
                .Add(dbManager.CreateParameter("@HIsOpening", 1, DbType.Boolean))

                .Add(dbManager.CreateParameter("@DItemName", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DIssueWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DIssuePr", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DFineWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DPartyName", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DNarration", alParaval.Item(iValue), DbType.String))
                iValue += 1
            End With

            Dt = dbManager.GetDataTable("SP_StockIssue_Save", CommandType.StoredProcedure, Hparameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            Cursor.Current = Cursors.Default
        End Try

        Return Dt

    End Function
    Private Sub UpdateData()
        Dim alParaval As New ArrayList

        Dim GridSrNo As String = Nothing
        Dim ItemName As String = Nothing
        Dim IssueWt As String = Nothing
        Dim IssuePr As String = Nothing
        Dim FineWt As String = Nothing
        Dim PartyName As String = Nothing
        Dim Narration As String = Nothing

        Dim IRowCount As Integer = 0
        Dim iValue As Integer = 0

        ''For Master
        alParaval.Add(TransDt.Value.ToString())
        alParaval.Add(cmbfDepartment.SelectedValue)
        alParaval.Add(cmbtDepartment.SelectedIndex)
        alParaval.Add(txtVocucherNo.Text)
        alParaval.Add(txtFrEmployee.Tag)
        alParaval.Add(cmbtEmployee.SelectedValue)

        ''For Details
        For Each row As GridViewRowInfo In dgvIssue.Rows
            If row.Cells(0).Value <> Nothing Then
                If GridSrNo = "" Then
                    GridSrNo = Val(row.Cells(0).Value)
                    ItemName = row.Cells(2).Value.ToString()
                    IssueWt = Val(row.Cells(3).Value)
                    IssuePr = Val(row.Cells(4).Value)
                    FineWt = Val(row.Cells(5).Value)
                    PartyName = row.Cells(7).Value.ToString
                    Narration = Convert.ToString(row.Cells(8).Value)
                Else
                    GridSrNo = GridSrNo & "|" & Val(row.Cells(0).Value)
                    ItemName = ItemName & "|" & row.Cells(2).Value.ToString()
                    IssueWt = IssueWt & "|" & Val(row.Cells(3).Value)
                    IssuePr = IssuePr & "|" & Val(row.Cells(4).Value)
                    FineWt = FineWt & "|" & Val(row.Cells(5).Value)
                    PartyName = PartyName & "|" & row.Cells(7).Value.ToString()
                    Narration = Narration & "|" & Convert.ToString(row.Cells(8).Value)
                End If
            End If
            IRowCount += 1
        Next

        alParaval.Add(ItemName)
        alParaval.Add(IssueWt)
        alParaval.Add(IssuePr)
        alParaval.Add(FineWt)
        alParaval.Add(PartyName)
        alParaval.Add(Narration)

        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()
            With Hparameters
                .Add(dbManager.CreateParameter("@HIssueDt", alParaval.Item(iValue), DbType.DateTime))
                iValue += 1
                .Add(dbManager.CreateParameter("@HfDeptId", alParaval.Item(iValue), DbType.Int16))
                iValue += 1
                .Add(dbManager.CreateParameter("@HtDeptId", alParaval.Item(iValue), DbType.Int16))
                iValue += 1

                .Add(dbManager.CreateParameter("@HVoucherNo", alParaval.Item(iValue), DbType.String))
                iValue += 1

                .Add(dbManager.CreateParameter("@HFrKarigarId", alParaval.Item(iValue), DbType.Int16))
                iValue += 1
                .Add(dbManager.CreateParameter("@HToKarigarId", alParaval.Item(iValue), DbType.String))
                iValue += 1

                .Add(dbManager.CreateParameter("@IId", CInt(txtVocucherNo.Tag), DbType.Int16))
                .Add(dbManager.CreateParameter("@HCreatedBy", UserName.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@GridCount", IRowCount, DbType.Int16))

                .Add(dbManager.CreateParameter("@DItemName", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DIssueWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DIssuePr", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DFineWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DPartyName", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DNarration", alParaval.Item(iValue), DbType.String))
                iValue += 1
            End With

            dbManager.Update("SP_StockIssue_Update", CommandType.StoredProcedure, Hparameters.ToArray())
            MessageBox.Show("Data Updated !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Sub fillGrid()

        If GridDoubleClick = False Then
            dgvIssue.Rows.Add(Val(txtSrNo.Text.Trim),
                                    cmbItem.SelectedValue,
                                    cmbItem.Text.Trim,
                                    Format(CDbl(txtGrossWt.Text.Trim), "0.00"),
                                    Format(CDbl(txtGrossPr.Text.Trim), "0.00"),
                                    Format(CDbl(txtFineWt.Text.Trim), "0.000"),
                                    cmbParty.SelectedValue,
                                    cmbParty.Text.Trim,
                                    CStr(txtNarration.Text.Trim()))
            GetSrNo(dgvIssue)
        Else
            dgvIssue.Rows(TempRow).Cells(0).Value = txtSrNo.Text.Trim
            dgvIssue.Rows(TempRow).Cells(1).Value = cmbItem.SelectedValue
            dgvIssue.Rows(TempRow).Cells(2).Value = cmbItem.Text.Trim
            dgvIssue.Rows(TempRow).Cells(3).Value = Format(CDbl(txtGrossWt.Text.Trim), "0.00")
            dgvIssue.Rows(TempRow).Cells(4).Value = Format(CDbl(txtGrossPr.Text.Trim), "0.00")
            dgvIssue.Rows(TempRow).Cells(5).Value = Format(CDbl(txtFineWt.Text.Trim), "0.000")
            dgvIssue.Rows(TempRow).Cells(6).Value = cmbParty.SelectedValue
            dgvIssue.Rows(TempRow).Cells(7).Value = cmbParty.Text.Trim
            dgvIssue.Rows(TempRow).Cells(8).Value = CStr(txtNarration.Text.Trim)
            GridDoubleClick = False
        End If
        ' Me.Total()
        dgvIssue.TableElement.ScrollToRow(dgvIssue.Rows.Last)

        txtSrNo.Text = dgvIssue.RowCount + 1
        cmbItem.SelectedIndex = 0
        txtGrossWt.Clear()
        txtGrossPr.Clear()
        txtFineWt.Clear()
        cmbParty.SelectedIndex = 0
        txtNarration.Clear()
        cmbItem.Focus()
    End Sub
    Sub GetSrNo(ByRef grid As Telerik.WinControls.UI.RadGridView)
        Try
            For Each rowInfo As GridViewRowInfo In dgvIssue.Rows
                rowInfo.Cells(0).Value = rowInfo.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub Total()
        Dim sRPrTotal As Single = 0

        Try
            lblTotalIssueWt.Text = 0.00
            lblTotalIssuePr.Text = 0.00
            lblTotalFineWt.Text = 0.000

            For Each row As GridViewRowInfo In dgvIssue.Rows
                lblTotalIssueWt.Text = Format(Val(lblTotalIssueWt.Text) + Val(row.Cells(3).Value), "0.00")
                lblTotalFineWt.Text = Format(Val(lblTotalFineWt.Text) + Val(row.Cells(5).Value), "0.000")
            Next

            If lblTotalFineWt.Text > 0 Then
                sRPrTotal = Format((Val(lblTotalFineWt.Text) / Val(lblTotalIssueWt.Text)) * 100, "0.000")
            End If

            lblTotalIssuePr.Text = Format(sRPrTotal, "0.00")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub frmOpeingStock_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                If MsgBox("Wish To Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    CType(Me.ParentForm, frmMain).FormMode.Text = ""
                    Me.Close()
                End If
            ElseIf e.KeyCode = Keys.Enter Then
                Me.SelectNextControl(Me.ActiveControl, True, True, True, False) 'for Select Next Control
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            End If

            If (e.Alt AndAlso (e.KeyCode = Keys.S)) Then
                ' When Alt + S is pressed, the Click event for the print
                ' button is raised.
                btnSave().PerformClick()
            End If

            If e.KeyCode = Keys.F2 Then
                cmbItem.Text = ""
                txtGrossWt.Clear()
                txtGrossPr.Clear()
                txtFineWt.Clear()
                txtNarration.Clear()
                cmbItem.Focus()
            End If

            With dgvIssue
                If e.KeyCode = Keys.F12 Then
                    .Rows.Remove(.CurrentRow)
                End If
                'Me.Total()
            End With

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub fillHeaderFromListView(ByVal intReceiveId As Integer)
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@HId", CInt(intReceiveId), DbType.Int16))
            .Add(dbManager.CreateParameter("@ActionType", "FetchHeaderRecord", DbType.String))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader("SP_HollowReceive_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

        If dr.HasRows = False Then
            Exit Sub
        Else
            dr.Read()
            txtVocucherNo.Tag = dr.Item("IssueId").ToString()
            txtVocucherNo.Text = dr.Item("VoucherNo").ToString()
            TransDt.Text = dr.Item("IssueDt").ToString()
            cmbfDepartment.SelectedIndex = dr.Item("FrDeptId").ToString()
            cmbtDepartment.SelectedIndex = dr.Item("ToDeptId").ToString()
            txtFrEmployee.Tag = dr.Item("FrKarigarId").ToString()
            txtFrEmployee.Text = dr.Item("FrKarigar").ToString()

            cmbtEmployee.SelectedIndex = dr.Item("ToKarigarId").ToString()
            cmbtEmployee.Text = CStr(dr.Item("ToKarigar"))
        End If

        dr.Close()
        Objcn.Close()

        Exit Sub
ErrHandler:
        MsgBox(Err.Description, MsgBoxStyle.Critical)
    End Sub
    Private Sub dgvIssue_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles dgvIssue.CellDoubleClick
        Try
            If e.RowIndex = -1 Then Exit Sub

            If e.RowIndex >= 0 And dgvIssue.Rows(e.RowIndex).Cells(0).Value <> Nothing Then
                GridDoubleClick = True
                txtSrNo.Text = dgvIssue.Rows(e.RowIndex).Cells(0).Value.ToString()
                cmbItem.SelectedIndex = dgvIssue.Rows(e.RowIndex).Cells(1).Value.ToString()
                cmbItem.Text = dgvIssue.Rows(e.RowIndex).Cells(2).Value.ToString()
                txtGrossWt.Text = CStr(dgvIssue.Rows(e.RowIndex).Cells(3).Value)
                txtGrossPr.Text = CStr(dgvIssue.Rows(e.RowIndex).Cells(4).Value)
                txtFineWt.Text = dgvIssue.Rows(e.RowIndex).Cells(5).Value.ToString()
                cmbParty.SelectedIndex = dgvIssue.Rows(e.RowIndex).Cells(6).Value.ToString()
                cmbParty.Text = dgvIssue.Rows(e.RowIndex).Cells(7).Value.ToString()
                txtNarration.Text = dgvIssue.Rows(e.RowIndex).Cells(8).Value.ToString()
                TempRow = e.RowIndex
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not String.IsNullOrEmpty(txtVocucherNo.Text) And dgvIssue.Rows.Count > 0 Then

            Try
                Dim parameters = New List(Of SqlParameter)()

                With parameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@IId", CInt(txtVocucherNo.Tag), DbType.Int16))
                End With

                dbManager.Delete("SP_StockIssue_Delete", CommandType.StoredProcedure, parameters.ToArray())

                MessageBox.Show("Record Deleted Successfully !!!")

                Me.Clear_Form()

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            End Try
        Else
            MessageBox.Show("Please Select Record !!!")
        End If
    End Sub
    Private Sub txtGrossWt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtGrossWt.KeyPress
        numdotkeypress(e, txtGrossWt, Me)
    End Sub
    Private Sub txtGrossPr_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtGrossPr.KeyPress
        numdotkeypress(e, txtGrossPr, Me)
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Call Clear_Form()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub fillDetailsFromListView(ByVal intIssueId As Integer)
        Dim dttable As New DataTable
        dttable = fetchAllRecords(CInt(intIssueId))

        For Each ROW As DataRow In dttable.Rows
            dgvIssue.Rows.Add(1, Val(ROW("ItemId")), CStr(ROW("ItemName")), Format(Val(ROW("IssueWt")), "0.00"), Format(Val(ROW("IssuePr")), "0.00"), Format(Val(ROW("FineWt")), "0.000"), Val(ROW("PartyId")), CStr(ROW("PartyName")), CStr(ROW("Narration")))
        Next

        Me.GetSrNo(dgvIssue)
        Me.Total()

        dgvIssue.ReadOnly = True

    End Sub
    Private Function fetchAllRecords(ByVal intIssueId As Integer) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@IId", CInt(intIssueId), DbType.Int16))
                .Add(dbManager.CreateParameter("@ActionType", "FetchDetailRecord", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_StockIssue_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub txtGrossPr_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtGrossPr.Validating
        If Val(txtGrossPr.Text) < 1 Or Val(txtGrossPr.Text) > 100 Then
            e.Cancel = True
            Objerr.SetError(txtGrossPr, "Percent in Between 0 to 100 !")
        Else
            Objerr.Clear()
        End If
    End Sub
    Private Sub dgvStockIssue_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles dgvStockIssue.CellDoubleClick
        If dgvStockIssue.SelectedRows.Count = 0 Then Exit Sub

        If dgvStockIssue.Rows.Count > 0 Then
            Dim IssueId As Integer = Me.dgvStockIssue.SelectedRows(0).Cells(0).Value

            Me.Clear_Form()

            Fr_Mode = FormState.EStateMode

            Me.fillHeaderFromListView(IssueId)

            Me.fillDetailsFromListView(IssueId)

            Me.TbStockIssue.SelectedIndex = 0
        End If
    End Sub
    Private Sub Clear_Form()
        Try
            '' For Header Field Start
            txtVocucherNo.Tag = ""
            txtVocucherNo.Clear()
            TransDt.Value = DateTime.Now

            cmbfDepartment.SelectedIndex = 0
            txtFrEmployee.Clear()
            cmbtEmployee.SelectedIndex = 0
            '' For Header Field End

            '' For Detail Field Start
            txtSrNo.Text = 1

            cmbItem.SelectedIndex = 0
            cmbItem.Enabled = True

            txtGrossWt.Clear()
            txtGrossPr.Clear()
            txtFineWt.Clear()

            dgvIssue.RowCount = 0

            '' For Detail Field End

            GridDoubleClick = False

            lblTotalIssueWt.Text = 0.0
            lblTotalIssuePr.Text = 0.0

            lblTotalFineWt.Text = 0.0

            Me.bindDataGridView()

            Fr_Mode = FormState.AStateMode

            cmbfDepartment.SelectedIndex = DeptId
            cmbfDepartment.Enabled = False

            cmbtDepartment.SelectedIndex = 4
            'cmbtDepartment.Enabled = False

            txtFrEmployee.Tag = CInt(UserId)
            txtFrEmployee.Text = Convert.ToString(KarigarName.Trim)

            TransDt.Focus()
            TransDt.Select()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Function Validate_Fields() As Boolean
        Try
            If Not dgvIssue.RowCount > 0 Then
                MessageBox.Show("Cannot Save Without Detail Information!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False
                Exit Function
            End If

            If cmbfDepartment.SelectedIndex = 0 Then
                MessageBox.Show("Select Department !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbfDepartment.Focus()
                Return False
            ElseIf cmbtEmployee.SelectedIndex = -1 Or cmbtEmployee.SelectedIndex = 0 Or cmbtEmployee.Text.Contains("---Select---") Then
                MessageBox.Show("Select To Karigar !", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbtEmployee.Focus()
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
    Private Sub bindDataGridView()
        Dim dtdata As DataTable = fetchAllRecords()

        Try
            dgvStockIssue.DataSource = dtdata
            dgvStockIssue.EnableFiltering = True
            dgvStockIssue.MasterTemplate.ShowFilteringRow = False
            dgvStockIssue.MasterTemplate.ShowHeaderCellButtons = True
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

            dtData = dbManager.GetDataTable("SP_StockIssue_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function

End Class