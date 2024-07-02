Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Imports JMS.Common_Cls
Public Class frmOpStockIssue
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState

    Dim strSQL As String = Nothing
    Dim TempRow As Integer

    Dim GridDoubleClick As Boolean

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
                    CType(Me.ParentForm, frmMain).FormMode.Text = "New Record"
                    Me.btnSave.Enabled = True
                    Me.btnSave.Text = "Save"
                    Me.btnDelete.Enabled = False
                Case FormState.EStateMode
                    CType(Me.ParentForm, frmMain).FormMode.Text = "Edit Record"
                    Me.btnSave.Text = "Update"
                    Me.btnDelete.Enabled = True
            End Select
        End Set
    End Property
    Private Sub frmOpeningStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Clear_Form()
        Me.filltemName()
        Me.fillParty()
        Me.bindDataGridView()
    End Sub
    Private Sub bindDataGridView()
        Dim dtdata As DataTable = fetchAllRecords()

        Try
            dgvStockIssueList.DataSource = dtdata
            dgvStockIssueList.EnableFiltering = True
            dgvStockIssueList.MasterTemplate.ShowFilteringRow = False
            dgvStockIssueList.MasterTemplate.ShowHeaderCellButtons = True
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
                .Add(dbManager.CreateParameter("@ActionType", "FetchOStockIssueData", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_OpStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub filltemName()

        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        parameters.Add(dbManager.CreateParameter("@ActionType", "FillItemName", DbType.String))
        Dim dr As SqlDataReader = dbManager.GetDataReader("SP_ItemMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)

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
    Private Function ChkDuplicate() As Boolean
        Dim exists As Boolean = False

        If GridDoubleClick = False Then
            For Each itm As GridViewRowInfo In dgvStockIssue.Rows
                If itm.Cells(4).Value = CStr(cmbItem.Text.Trim) Then
                    exists = True
                End If
            Next
        End If

        Return exists

    End Function
    Private Sub txtIssueWt_TextChanged(sender As Object, e As EventArgs) Handles txtGrossWt.TextChanged
        Try
            txtFineWt.Text = Format((Val(txtGrossWt.Text) * Val(txtGrossPr.Text)) / 100, "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtIssuePr_TextChanged(sender As Object, e As EventArgs) Handles txtGrossPr.TextChanged
        Try
            txtFineWt.Text = Format((Val(txtGrossWt.Text) * Val(txtGrossPr.Text)) / 100, "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Clear_Form()
        Try
            '' For Header Field Start
            txtVocucherNo.Tag = ""
            txtVocucherNo.Clear()
            TransDt.Value = DateTime.Now
            '' For Header Field End

            '' For Detail Field Start
            txtSrNo.Text = 1

            cmbItem.Text = ""
            cmbItem.Enabled = True

            txtGrossWt.Clear()
            txtGrossPr.Clear()
            txtNarration.Clear()
            txtNarration.Clear()

            dgvStockIssue.RowCount = 0
            '' For Detail Field End

            GridDoubleClick = False

            Fr_Mode = FormState.AStateMode

            TransDt.Focus()
            TransDt.Select()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Testing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Call Clear_Form()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Product_Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub cmbItem_Enter(sender As Object, e As EventArgs) Handles cmbItem.Enter
        cmbItem.ShowDropDown()
    End Sub
    Private Sub Btn_Find_Click(sender As Object, e As EventArgs) Handles Btn_Find.Click
        Try
            'If txtVocucherNo.Text.Trim = "" Then
            '    Dim Sql As String
            '    Dim Colwidth As String = ""
            '    Colwidth = "75|200|50|"
            '    Sql = "SELECT     [Bank Name], BankAcc_ID AS [bank Account ID], Acc_No AS [Account No], Acc_Balance AS [Balance Amount]  FROM Get_Bank_Account_Master_Vw where Br_Code = " & txtVocucherNo.Text & ""
            '    Call ShowSearchengine(TextBox1, Sql, 1, "Account Name", Colwidth, , 0)
            'End If

            'Validating Mandatory fields for locating
            If txtVocucherNo.Text.Trim = "" Then
                txtVocucherNo.Focus() : Exit Sub
            End If

            'If Locate_Values() Then
            '    Tr_Mode = Tran_Mode.Edit_Mode
            '    Btn_Delete.Enabled = True
            'Else
            '    MessageBox.Show("Voucher Number does not exists,Please Check", Product_Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Product_Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub fillGrid()

        If GridDoubleClick = False Then
            dgvStockIssue.Rows.Add(Val(txtSrNo.Text.Trim),
                                    cmbItem.SelectedValue,
                                    cmbItem.Text.Trim,
                                    Format(CDbl(txtGrossWt.Text.Trim), "0.00"),
                                    Format(CDbl(txtGrossPr.Text.Trim), "0.00"),
                                    Format(CDbl(txtFineWt.Text.Trim), "0.000"),
                                    cmbParty.SelectedValue,
                                    cmbParty.Text.Trim,
                                    CStr(txtNarration.Text.Trim()))
            GetSrNo(dgvStockIssue)
        Else
            dgvStockIssue.Rows(TempRow).Cells(0).Value = txtSrNo.Text.Trim
            dgvStockIssue.Rows(TempRow).Cells(1).Value = cmbItem.SelectedValue
            dgvStockIssue.Rows(TempRow).Cells(2).Value = cmbItem.Text.Trim
            dgvStockIssue.Rows(TempRow).Cells(3).Value = Format(CDbl(txtGrossWt.Text.Trim), "0.00")
            dgvStockIssue.Rows(TempRow).Cells(4).Value = Format(CDbl(txtGrossPr.Text.Trim), "0.00")
            dgvStockIssue.Rows(TempRow).Cells(5).Value = Format(CDbl(txtFineWt.Text.Trim), "0.000")
            dgvStockIssue.Rows(TempRow).Cells(6).Value = cmbParty.SelectedValue
            dgvStockIssue.Rows(TempRow).Cells(7).Value = cmbParty.Text.Trim
            dgvStockIssue.Rows(TempRow).Cells(8).Value = CStr(txtNarration.Text.Trim)
            GridDoubleClick = False
        End If
        ' Me.Total()
        dgvStockIssue.TableElement.ScrollToRow(dgvStockIssue.Rows.Last)

        txtSrNo.Text = dgvStockIssue.RowCount + 1
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
            For Each rowInfo As GridViewRowInfo In dgvStockIssue.Rows
                rowInfo.Cells(0).Value = rowInfo.Index + 1
            Next
        Catch ex As Exception
            Throw ex
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
        alParaval.Add(1)
        alParaval.Add(4)
        alParaval.Add(100)
        alParaval.Add(100)
        alParaval.Add(txtVocucherNo.Text.Trim)


        ''For Details
        For Each row As GridViewRowInfo In dgvStockIssue.Rows
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

                .Add(dbManager.CreateParameter("@HVoucherNo", alParaval.Item(iValue), DbType.String))
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

            Dt = dbManager.GetDataTable("SP_OStockIssue_Save", CommandType.StoredProcedure, Hparameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            Cursor.Current = Cursors.Default
        End Try

        Return Dt

    End Function
    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        Try
            If e.KeyCode = Keys.F1 Then Call Btn_Find_Click(Nothing, Nothing)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtIssueWt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtGrossWt.KeyPress
        numdotkeypress(e, txtGrossWt, Me)
    End Sub
    Private Sub txtIssuePr_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtGrossPr.KeyPress
        numdotkeypress(e, txtGrossPr, Me)
    End Sub
    Private Sub txtNarration_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtNarration.Validating
        Try
            If cmbItem.Text.Trim <> "" And txtGrossWt.Text.Trim <> "" And Val(txtGrossWt.Text.Trim) > 0 And Val(txtGrossPr.Text.Trim) > 0 Then

                'ErrorProvider1.SetError(txtRequirePr, "")

                If dgvStockIssue.Rows.Count > 0 AndAlso ChkDuplicate() = True Then
                    MsgBox("Duplicate Data")
                Else
                    Me.fillGrid()
                    'Me.Total()
                End If
            Else
                'ErrorProvider1.SetError(txtRequirePr, "Enter Required %")
                MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub fillHeaderFromListView(ByVal intIssueId As Integer)

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@IId", CInt(intIssueId), DbType.Int16))
            .Add(dbManager.CreateParameter("@ActionType", "FetchOpeningHeader", DbType.String))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader("SP_StockIssue_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

        If dr.HasRows = False Then
            Exit Sub
        Else
            dr.Read()
            txtVocucherNo.Tag = dr.Item("IssueId").ToString()
            txtVocucherNo.Text = dr.Item("VoucherNo").ToString()
            TransDt.Text = dr.Item("IssueDt").ToString()
            'cmbfDepartment.SelectedIndex = dr.Item("FrDeptId").ToString()
            'cmbtDepartment.SelectedIndex = dr.Item("ToDeptId").ToString()
            'txtFrKarigar.Tag = dr.Item("FrKarigarId").ToString()
            'txtFrKarigar.Text = dr.Item("FrKarigar").ToString()

            'cmbtKarigar.SelectedIndex = dr.Item("ToKarigarId").ToString()
            'cmbtKarigar.Text = CStr(dr.Item("ToKarigar"))
        End If

        dr.Close()
        Objcn.Close()

        Exit Sub
ErrHandler:
        MsgBox(Err.Description, MsgBoxStyle.Critical)
    End Sub
    Private Sub fillDetailsFromListView(ByVal intIssueId As Integer)
        Dim dttable As New DataTable
        dttable = fetchAllRecords(CInt(intIssueId))

        For Each ROW As DataRow In dttable.Rows
            dgvStockIssue.Rows.Add(1, Val(ROW("ItemId")), CStr(ROW("ItemName")), Format(Val(ROW("IssueWt")), "0.00"), Format(Val(ROW("IssuePr")), "0.00"), Format(Val(ROW("FineWt")), "0.000"), Val(ROW("PartyId")), CStr(ROW("PartyName")), CStr(ROW("Narration")))
        Next

        Me.GetSrNo(dgvStockIssue)
        'Me.Total()

        dgvStockIssue.ReadOnly = True

    End Sub
    'Sub Total()
    '    Dim sRPrTotal As Single = 0

    '    Try
    '        lblTotalIssueWt.Text = 0.00
    '        lblTotalIssuePr.Text = 0.00
    '        lblTotalFineWt.Text = 0.000
    '        For Each row As GridViewRowInfo In dgvIssue.Rows
    '            lblTotalIssueWt.Text = Format(Val(lblTotalIssueWt.Text) + Val(row.Cells(3).Value), "0.00")
    '            lblTotalFineWt.Text = Format(Val(lblTotalFineWt.Text) + Val(row.Cells(5).Value), "0.000")
    '        Next

    '        If lblTotalFineWt.Text > 0 Then
    '            sRPrTotal = Format((Val(lblTotalFineWt.Text) / Val(lblTotalIssueWt.Text)) * 100, "0.000")
    '        End If

    '        lblTotalIssuePr.Text = Format(sRPrTotal, "0.00")

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
    Private Function fetchAllRecords(ByVal intIssueId As Integer) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@IId", CInt(intIssueId), DbType.Int16))
                .Add(dbManager.CreateParameter("@ActionType", "FetchDetailRecord", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_StockIssue_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function

    Private Sub dgvStockIssueList_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles dgvStockIssueList.CellDoubleClick
        If dgvStockIssueList.SelectedRows.Count = 0 Then Exit Sub

        If dgvStockIssueList.Rows.Count > 0 Then
            Dim IssueId As Integer = Me.dgvStockIssueList.SelectedRows(0).Cells(0).Value

            Me.Clear_Form()

            Fr_Mode = FormState.EStateMode

            Me.fillHeaderFromListView(IssueId)

            Me.fillDetailsFromListView(IssueId)

            Me.TabOpStock.SelectedIndex = 0
        End If
    End Sub

    Private Sub dgvStockIssue_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles dgvStockIssue.CellDoubleClick
        Try
            If e.RowIndex = -1 Then Exit Sub

            If e.RowIndex >= 0 And dgvStockIssue.Rows(e.RowIndex).Cells(0).Value <> Nothing Then
                GridDoubleClick = True
                txtSrNo.Text = dgvStockIssue.Rows(e.RowIndex).Cells(0).Value.ToString()
                cmbItem.SelectedIndex = dgvStockIssue.Rows(e.RowIndex).Cells(1).Value.ToString()
                cmbItem.Text = dgvStockIssue.Rows(e.RowIndex).Cells(2).Value.ToString()
                txtGrossWt.Text = CStr(dgvStockIssue.Rows(e.RowIndex).Cells(3).Value)
                txtGrossPr.Text = CStr(dgvStockIssue.Rows(e.RowIndex).Cells(4).Value)
                txtFineWt.Text = dgvStockIssue.Rows(e.RowIndex).Cells(5).Value.ToString()
                cmbParty.SelectedIndex = dgvStockIssue.Rows(e.RowIndex).Cells(6).Value.ToString()
                cmbParty.Text = dgvStockIssue.Rows(e.RowIndex).Cells(7).Value.ToString()
                txtNarration.Text = dgvStockIssue.Rows(e.RowIndex).Cells(8).Value.ToString()
                TempRow = e.RowIndex
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

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

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not String.IsNullOrEmpty(txtVocucherNo.Text) And dgvStockIssue.Rows.Count > 0 Then
            If (MsgBox("Are You Sure To Delete This Record ?", vbYesNo + vbDefaultButton2 + vbQuestion, "User : " + UserName.Trim()) = vbYes) Then

                Try
                    Dim parameters = New List(Of SqlParameter)()
                    parameters.Clear()

                    With parameters
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
        Else
            MessageBox.Show("Delete This Record Only When You Sure !!!")
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim TmpLotNo As String = Nothing
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
        'alParaval.Add(cmbfDepartment.SelectedValue)
        'alParaval.Add(cmbtDepartment.SelectedIndex)
        alParaval.Add(txtVocucherNo.Text)
        'alParaval.Add(txtFrKarigar.Tag)
        'alParaval.Add(cmbtKarigar.SelectedValue)

        ''For Details
        For Each row As GridViewRowInfo In dgvStockIssue.Rows
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
                '.Add(dbManager.CreateParameter("@HfDeptId", alParaval.Item(iValue), DbType.Int16))
                'iValue += 1
                '.Add(dbManager.CreateParameter("@HtDeptId", alParaval.Item(iValue), DbType.Int16))
                'iValue += 1

                .Add(dbManager.CreateParameter("@HVoucherNo", alParaval.Item(iValue), DbType.String))
                iValue += 1

                '.Add(dbManager.CreateParameter("@HFrKarigarId", alParaval.Item(iValue), DbType.Int16))
                'iValue += 1
                '.Add(dbManager.CreateParameter("@HToKarigarId", alParaval.Item(iValue), DbType.String))
                'iValue += 1

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

            dbManager.Update("SP_OStockIssue_Update", CommandType.StoredProcedure, Hparameters.ToArray())
            MessageBox.Show("Data Updated !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub frmOpStockIssue_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                If MsgBox("Wish To Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    CType(Me.ParentForm, frmMain).FormMode.Text = ""
                    Me.Close()
                End If
            ElseIf e.KeyCode = Keys.Tab Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            End If

            With dgvStockIssue
                If e.KeyCode = Keys.F12 Then
                    .Rows.Remove(.CurrentRow)
                End If
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class