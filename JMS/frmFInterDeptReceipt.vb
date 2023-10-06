Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Public Class frmFInterDeptReceipt
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Private mFr_State As FormState
    Dim strSQL As String = Nothing
    Dim TempRow As Integer
    Dim GridDoubleClick As Boolean
    Dim dbltempCalculate As Double = 0
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
    Private Sub frmInterDeptReceipt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If dtUserRights.Rows.Count > 0 Then

            Dim DtRow() As DataRow = dtUserRights.Select("FormName ='ACCOUNT MASTER'")
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

        'BackWrd.Enabled = True
        'With GRDFinal
        '    If GRDFinal.Rows.Count = Nothing Then
        '        BackWrd.Enabled = False
        '    Else
        '        BackWrd.Enabled = True
        '    End If
        'End With

        Me.fillDepartment()
        Me.UnableText()
        Me.fillConversion()
        Me.fillVoucherNo()
        Me.bindDataGridView()
        Me.Clear_Form()
        txtToKarigar.Tag = CInt(UserId)
        txtToKarigar.Text = Convert.ToString(KarigarName.Trim)
    End Sub
    Private Sub UnableText()
        txtSrNo.Enabled = False
        txtItemName.Enabled = False
        txtReceiveWt.Enabled = False
        txtReceivePr.Enabled = False
        txtFineWt.Enabled = False
        txtStockAdd.Enabled = False
        txtFrKarigar.Enabled = False
        txtToKarigar.Enabled = False
        TransDt.Enabled = False
        cmbfDepartment.Enabled = False
        cmbtDepartment.Enabled = False
    End Sub
    Private Sub fillDepartment()
        Dim connection As SqlConnection = Nothing
        Dim parameters = New List(Of SqlParameter)()
        With parameters
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

    Private Sub fillConversion()
        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_MeltingMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), Objcn)
        Dim dt As DataTable = New DataTable()
        dt.Load(dr)
        Try
            ''Insert the Default Item to DataTable.
            Dim row As DataRow = dt.NewRow()
            row(0) = 0
            row(1) = "---Select---"
            dt.Rows.InsertAt(row, 0)
            'Assign DataTable as DataSource.
            cmbConversion.DataSource = dt
            cmbConversion.DisplayMember = "MeltingValue"
            cmbConversion.ValueMember = "MeltingId"
            'Newly Added
            cmbConversion.Refresh()
            If cmbConversion.Items.Count > 0 Then cmbConversion.SelectedIndex = 0
            cmbConversion.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbConversion.AutoCompleteDataSource = AutoCompleteSource.ListItems
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            Objcn.Close()
        End Try
    End Sub
    Private Sub fillVoucherNo()
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchVoucherNo", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_fStockIssue_Select", CommandType.StoredProcedure, parameters.ToArray(), Objcn)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            Dim row As DataRow = dt.NewRow()
            row(0) = 0
            row(1) = "---Select---"
            dt.Rows.InsertAt(row, 0)
            cmbVoucherNo.DataSource = dt
            cmbVoucherNo.DisplayMember = "VoucherNo"
            cmbVoucherNo.ValueMember = "IssueId"
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            Objcn.Close()
        End Try
    End Sub
    Sub Total()
        Try
            lblTotalGrossWt.Text = 0.00
            lblTotalFineWt.Text = 0.00
            lblTotalStockAdd.Text = 0.00

            For Each row As GridViewRowInfo In GRDFinal.Rows
                lblTotalGrossWt.Text = Format(Val(lblTotalGrossWt.Text) + CDbl(row.Cells(5).Value), "0.00")
                lblTotalFineWt.Text = Format(Val(lblTotalFineWt.Text) + CDbl(row.Cells(8).Value), "0.00")
                lblTotalStockAdd.Text = Format(Val(lblTotalStockAdd.Text) + CDbl(row.Cells(10).Value), "0.00")
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub GetSrNo(ByRef grid As Telerik.WinControls.UI.RadGridView)
        Try
            For Each rowInfo As GridViewRowInfo In dgvReceipt.Rows
                rowInfo.Cells(0).Value = rowInfo.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
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
    Private Sub bindDataGridView()
        Dim dtdata As DataTable = fetchAllRecords()

        Try
            dgvInterDeptReceipt.DataSource = dtdata
            dgvInterDeptReceipt.EnableFiltering = True
            dgvInterDeptReceipt.MasterTemplate.ShowFilteringRow = False
            dgvInterDeptReceipt.MasterTemplate.ShowHeaderCellButtons = True
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

            dtData = dbManager.GetDataTable("SP_fReceipt_Select", CommandType.StoredProcedure, parameters.ToArray())
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
        Return dtData
    End Function
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not String.IsNullOrEmpty(txtId.Tag) Then
            Try
                Dim parameters = New List(Of SqlParameter)()

                With parameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@RId", CInt(txtId.Tag), DbType.Int16))
                End With

                dbManager.Delete("SP_InterDeptReceipt_Delete", CommandType.StoredProcedure, parameters.ToArray())
                MessageBox.Show("Data Deleted !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Clear_Form()
            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            End Try
        Else
            MessageBox.Show("Please Select A Fancy !!!")
        End If
    End Sub
    Private Sub fillHeaderFromListView(ByVal intReceiptId As Integer)
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@RId", CInt(intReceiptId), DbType.Int16))
            .Add(dbManager.CreateParameter("@ActionType", "FetchHeaderRecord", DbType.String))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader("SP_Receipt_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

        If dr.HasRows = False Then
            Exit Sub
        Else
            dr.Read()

            txtId.Tag = dr.Item("ReceiptId").ToString
            txtId.Tag = dr.Item("ReceiptDetailsId").ToString
            cmbVoucherNo.Text = dr.Item("VoucherNo").ToString()
            TransDt.Text = dr.Item("ReceiptDt").ToString
            cmbfDepartment.SelectedIndex = dr.Item("FrDeptId").ToString()
            cmbtDepartment.SelectedIndex = dr.Item("ToDeptId").ToString()
            txtFrKarigar.Tag = dr.Item("FrKarigarId").ToString
            txtFrKarigar.Text = dr.Item("FrKarigar").ToString
            txtToKarigar.Tag = dr.Item("ToKarigarId").ToString()
            txtToKarigar.Name = dr.Item("ToKarigar").ToString()
        End If
        dr.Close()
        Objcn.Close()
        Exit Sub
ErrHandler:
        MsgBox(Err.Description, MsgBoxStyle.Critical)
    End Sub
    Private Sub fillDetailsFromListView(ByVal intReceiptId As Integer)
        Dim dttable As New DataTable

        dttable = fetchAllFancys(CInt(intReceiptId))

        For Each ROW As DataRow In dttable.Rows
            dgvReceipt.DataSource = Nothing
            dgvReceipt.Rows.Add(Val(ROW("ReceiptDetailsId")), Val(ROW("ReceiptId")), CStr(ROW("IssueId")), Val(ROW("ItemId")), CStr(ROW("ItemName")), Format(Val(ROW("ReceiveWt")), "0.00"), Format(Val(ROW("ReceivePr")), "0.00"), Format(Val(ROW("ConvPr")), "0.00"), Format(Val(ROW("FineWt")), "0.00"), Convert.ToBoolean(ROW("ForMelting")), Format(Val(ROW("StockAdd")), "0.00"))
        Next

        Me.GetSrNo(dgvReceipt)
        Me.Total()
        dgvReceipt.ReadOnly = True
    End Sub
    Private Function fetchAllFancys(ByVal intReceiptId As Integer) As DataTable
        Dim dtData As DataTable = New DataTable()
        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@RId", CInt(intReceiptId), DbType.Int16))
                .Add(dbManager.CreateParameter("@ActionType", "FetchDetailRecord", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_Receipt_Select", CommandType.StoredProcedure, parameters.ToArray())
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
        Return dtData
    End Function
    Private Sub SaveData()
        Dim alParaval As New ArrayList

        Dim IssueDetailsId As String = ""
        Dim IssueId As String = ""
        Dim ItemId As String = ""
        Dim ItemName As String = ""
        Dim ReceivePr As String = ""
        Dim ReceiveWt As String = ""
        Dim ConvPr As String = ""
        Dim FineWt As String = ""
        Dim ForMelting As String = Nothing
        Dim StockAdd As String = ""
        Dim IRowCount As Integer = 0
        Dim iValue As Integer = 0

        alParaval.Add(TransDt.Value.ToString())
        alParaval.Add(cmbfDepartment.SelectedValue)
        alParaval.Add(cmbtDepartment.SelectedValue)
        alParaval.Add(cmbVoucherNo.Text.Trim())
        alParaval.Add(txtFrKarigar.Tag)
        alParaval.Add(txtToKarigar.Tag)

        For Each row As GridViewRowInfo In GRDFinal.Rows
            If row.Cells(0).Value <> Nothing Then
                If IssueDetailsId = "" Then
                    IssueDetailsId = Val(row.Cells(1).Value)
                    IssueId = Val(row.Cells(2).Value)
                    ItemId = Val(row.Cells(3).Value)
                    ReceiveWt = Val(row.Cells(5).Value)
                    ReceivePr = Val(row.Cells(6).Value)

                    ConvPr = row.Cells(7).Value
                    FineWt = row.Cells(8).Value

                    ForMelting = row.Cells(9).Value
                    StockAdd = row.Cells(10).Value
                Else
                    IssueDetailsId = IssueDetailsId & "|" & Val(row.Cells(1).Value)
                    IssueId = IssueId & "|" & Val(row.Cells(2).Value)
                    ItemId = ItemId & "|" & Val(row.Cells(3).Value)
                    ReceiveWt = ReceiveWt & "|" & row.Cells(5).Value
                    ReceivePr = ReceivePr & "|" & row.Cells(6).Value
                    ConvPr = ConvPr & "|" & row.Cells(7).Value
                    FineWt = FineWt & "|" & row.Cells(8).Value
                    ForMelting = ForMelting & "|" & row.Cells(9).Value
                    StockAdd = StockAdd & "|" & row.Cells(10).Value
                End If
            End If
            IRowCount += 1
        Next

        alParaval.Add(IssueDetailsId)
        alParaval.Add(IssueId)
        alParaval.Add(ItemId)
        alParaval.Add(ReceiveWt)
        alParaval.Add(ReceivePr)
        alParaval.Add(ConvPr)
        alParaval.Add(FineWt)
        alParaval.Add(ForMelting)
        alParaval.Add(StockAdd)

        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()
            With Hparameters
                .Add(dbManager.CreateParameter("@HReceiptDt", alParaval.Item(iValue), DbType.DateTime))
                iValue += 1
                .Add(dbManager.CreateParameter("@HfDeptId ", alParaval.Item(iValue), DbType.Int16))
                iValue += 1
                .Add(dbManager.CreateParameter("@HtDeptId ", alParaval.Item(iValue), DbType.Int16))
                iValue += 1
                .Add(dbManager.CreateParameter("@HVoucherNo", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@HFrKarigarId", alParaval.Item(iValue), DbType.Int16))
                iValue += 1
                .Add(dbManager.CreateParameter("@HToKarigarId", alParaval.Item(iValue), DbType.Int16))
                iValue += 1
                .Add(dbManager.CreateParameter("@HCreatedBy", UserName.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@GridCount", IRowCount, DbType.Int16))

                .Add(dbManager.CreateParameter("@DIssueDetailsId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DIssueId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DItemId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DReceiveWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DReceivePr", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DConvPr", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DFineWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DChkforMelting", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DStockAdd", alParaval.Item(iValue), DbType.String))
                iValue += 1
            End With

            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@IssueDetailsId", IssueDetailsId, DbType.String))
                .Add(dbManager.CreateParameter("@HVoucherNo", "@HVoucherNo", DbType.String))
                dbManager.Insert("SP_fReceipt_Save", CommandType.StoredProcedure, Hparameters.ToArray())
                MessageBox.Show("Data Saved !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End With

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub UpdateData()
        Dim alParaval As New ArrayList
        Dim ReceiptDetailsId As String = ""
        Dim IssueId As String = ""
        Dim ItemId As String = ""
        Dim ReceivePr As String = ""
        Dim ReceiveWt As String = ""
        Dim ConvPr As String = ""
        Dim FineWt As String = ""
        Dim ForMelting As String = Nothing
        Dim StockAdd As String = ""
        Dim IRowCount As Integer = 0
        Dim iValue As Integer = 0
        alParaval.Add(TransDt.Value.ToString())
        alParaval.Add(cmbfDepartment.SelectedValue)
        alParaval.Add(cmbtDepartment.SelectedValue)
        alParaval.Add(cmbVoucherNo.Text.Trim())
        alParaval.Add(txtFrKarigar.Tag)
        alParaval.Add(txtToKarigar.Tag)

        For Each row As GridViewRowInfo In GRDFinal.Rows
            If row.Cells(0).Value <> Nothing Then
                'ReceiptDetailsId = Val(row.Cells(1).Value)
                IssueId = Val(row.Cells(2).Value)
                ItemId = Val(row.Cells(3).Value)
                ReceiveWt = Val(row.Cells(5).Value)
                ReceivePr = Val(row.Cells(6).Value)

                ConvPr = row.Cells(7).Value
                FineWt = row.Cells(8).Value

                ForMelting = row.Cells(9).Value
                StockAdd = row.Cells(10).Value
            Else
                'ReceiptDetailsId = ReceiptDetailsId & "|" & Val(row.Cells(1).Value)
                ReceiveWt = ReceiveWt & "|" & row.Cells(5).Value
                ReceivePr = ReceivePr & "|" & row.Cells(6).Value
                ConvPr = ConvPr & "|" & row.Cells(7).Value
                FineWt = FineWt & "|" & row.Cells(8).Value
                ForMelting = ForMelting & "|" & row.Cells(9).Value
                StockAdd = StockAdd & "|" & row.Cells(10).Value
            End If
            IRowCount += 1
        Next

        'alParaval.Add(ReceiptDetailsId)
        alParaval.Add(IssueId)
        alParaval.Add(ItemId)
        alParaval.Add(ReceiveWt)
        alParaval.Add(ReceivePr)
        alParaval.Add(ConvPr)
        alParaval.Add(FineWt)
        alParaval.Add(ForMelting)
        alParaval.Add(StockAdd)

        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()
            With Hparameters
                .Add(dbManager.CreateParameter("@HReceiptDt", alParaval.Item(iValue), DbType.DateTime))
                iValue += 1
                .Add(dbManager.CreateParameter("@HfDeptId ", alParaval.Item(iValue), DbType.Int16))
                iValue += 1
                .Add(dbManager.CreateParameter("@HtDeptId ", alParaval.Item(iValue), DbType.Int16))
                iValue += 1
                .Add(dbManager.CreateParameter("@HVoucherNo", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@HFrKarigarId", alParaval.Item(iValue), DbType.Int16))
                iValue += 1
                .Add(dbManager.CreateParameter("@HToKarigarId", alParaval.Item(iValue), DbType.Int16))
                iValue += 1
                .Add(dbManager.CreateParameter("@HCreatedBy", UserName.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@GridCount", IRowCount, DbType.Int16))
                .Add(dbManager.CreateParameter("@RId", Val(txtId.Tag), DbType.Int16))
                .Add(dbManager.CreateParameter("@DIssueId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DItemId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DReceiveWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DReceivePr", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DConvPr", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DFineWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DChkforMelting", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DStockAdd", alParaval.Item(iValue), DbType.String))
                iValue += 1
            End With

            dbManager.Insert("SP_fReceipt_Update", CommandType.StoredProcedure, Hparameters.ToArray())
            MessageBox.Show("Data Updated !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.fillVoucherNo()
            Me.TabControl1.SelectedIndex = 1

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Function ChkDuplicate() As Boolean
        Dim exists As Boolean = False
        For Each row As GridViewRowInfo In dgvReceipt.Rows
        Next
        Return exists
    End Function
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Me.Clear_Form()
            Dim dtData As DataTable = New DataTable()
            If cmbVoucherNo.SelectedIndex <> -1 Then
                Dim parameters = New List(Of SqlParameter)()

                With parameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@ActionType", "FetchVoucherNoWiseDetails", DbType.String))
                    .Add(dbManager.CreateParameter("@VouNo", cmbVoucherNo.Text.Trim(), DbType.String))
                End With

                dtData = dbManager.GetDataTable("SP_StockIssue_Select", CommandType.StoredProcedure, parameters.ToArray())

                Try
                    If dtData.Rows.Count > 0 Then
                        dgvReceipt.DataSource = dtData
                    End If
                    Me.Total()
                Catch ex As Exception
                    MessageBox.Show("Error:- " & ex.Message)
                Finally
                End Try
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmInterDeptReceipt_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmbVoucherNo_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbVoucherNo.SelectedIndexChanged
        Dim dtData As DataTable = New DataTable()
        If cmbVoucherNo.SelectedIndex <> -1 Then
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchVoucherNoWiseDetails", DbType.String))
                .Add(dbManager.CreateParameter("@VouNo", cmbVoucherNo.Text.Trim(), DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_fStockIssue_Select", CommandType.StoredProcedure, parameters.ToArray())

            Try
                If dtData.Rows.Count > 0 Then
                    dgvReceipt.DataSource = dtData
                End If
                Me.Total()
            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally
            End Try
        End If
    End Sub
    Private Sub dgvReceipt_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs) Handles dgvReceipt.ViewCellFormatting
        If e.CellElement.ColumnInfo.Name = "colSrNo" AndAlso e.CellElement.Value Is Nothing Then
            e.CellElement.Value = e.CellElement.RowIndex + 1
        End If
    End Sub
    Private Sub EnableControls(enable As Boolean)
        TransDt.Enabled = enable
        cmbVoucherNo.Enabled = enable
        cmbfDepartment.Enabled = enable
        cmbtDepartment.Enabled = enable
        txtFrKarigar.Enabled = enable
        txtToKarigar.Enabled = enable
        dgvReceipt.Enabled = enable
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub dgvReceipt_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvReceipt.KeyDown
        Try
            If e.KeyCode = Keys.Delete And dgvReceipt.RowCount > 0 Then
                If GridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                If TypeOf dgvReceipt.CurrentRow Is Telerik.WinControls.UI.GridViewNewRowInfo Then
                    Exit Sub
                End If
                Me.dgvReceipt.Rows.RemoveAt(dgvReceipt.CurrentRow.Index)
                Me.Total()
                Me.GetSrNo(dgvReceipt)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Clear_Form()
        Try
            GRDFinal.DataSource = Nothing
            txtSrNo.Text = String.Empty
            txtItemName.Text = String.Empty
            txtReceiveWt.Text = String.Empty
            txtReceivePr.Text = String.Empty
            cmbConversion.SelectedIndex = 0
            txtFineWt.Text = String.Empty
            chkForMelting.Checked = False
            txtStockAdd.Text = String.Empty
            If Fr_Mode = FormState.AStateMode Then
                GRDFinal.RowCount = 0
            Else
                GRDFinal.RowCount = 0
            End If

            GridDoubleClick = False
            lblTotalGrossWt.Text = 0.0
            lblTotalFineWt.Text = 0.0
            lblTotalStockAdd.Text = 0.0

            Me.bindDataGridView()

            Fr_Mode = FormState.AStateMode
            cmbfDepartment.SelectedIndex = DeptId
            cmbfDepartment.Enabled = False
            cmbtDepartment.SelectedIndex = 6
            cmbtDepartment.Enabled = False
            txtFrKarigar.Tag = CInt(UserId)
            txtFrKarigar.Text = Convert.ToString(KarigarName.Trim)
            TransDt.Focus()
            TransDt.Select()
            Me.fillVoucherNo()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function Validate_Fields() As Boolean
        Try
            If Not GRDFinal.RowCount > 0 Then
                MessageBox.Show("Cannot Save Without Detail Information!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False
                Exit Function
            End If
            If cmbfDepartment.SelectedIndex = 0 Then
                MessageBox.Show("Select Department !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbfDepartment.Focus()
                Return False
            End If
            If cmbVoucherNo.SelectedIndex < 0 Then
                MessageBox.Show("Select Voucher !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbVoucherNo.Focus()
            End If

            For i As Integer = 0 To GRDFinal.Rows.Count - 1
                If CType(GRDFinal.Rows(i).Cells(6).Value, String) Is Nothing Then
                    MessageBox.Show("Conversion % Cannot Be Empty")
                    Return False
                End If
            Next
            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Sub dgvReceipt_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles dgvReceipt.CellDoubleClick
        Try

            If e.RowIndex = -1 Then Exit Sub
            If e.RowIndex >= 0 And dgvReceipt.Rows(e.RowIndex).Cells(0).Value <> Nothing Then
                GridDoubleClick = True
                txtSrNo.Text = dgvReceipt.Rows(e.RowIndex).Cells(0).Value.ToString()
                txtSrNo.Tag = dgvReceipt.Rows(e.RowIndex).Cells(1).Value.ToString()
                txtReceiveWt.Tag = dgvReceipt.Rows(e.RowIndex).Cells(2).Value.ToString()
                txtItemName.Tag = dgvReceipt.Rows(e.RowIndex).Cells(3).Value.ToString()
                txtItemName.Text = dgvReceipt.Rows(e.RowIndex).Cells(4).Value.ToString
                txtReceiveWt.Text = dgvReceipt.Rows(e.RowIndex).Cells(5).Value.ToString()
                txtReceivePr.Text = dgvReceipt.Rows(e.RowIndex).Cells(6).Value.ToString()
                txtFineWt.Tag = dgvReceipt.Rows(e.RowIndex).Cells(8).Value.ToString()
                If dgvReceipt.Rows(e.RowIndex).Cells(7).Value = "" Then
                    cmbConversion.Text = txtReceivePr.Text
                Else
                    cmbConversion.Text = txtReceivePr.Text
                End If
                txtFineWt.Text = dgvReceipt.Rows(e.RowIndex).Cells(8).Value.ToString()
                If IsNothing(dgvReceipt.Rows(e.RowIndex).Cells(10).Value) OrElse String.IsNullOrEmpty(dgvReceipt.Rows(e.RowIndex).Cells(8).Value) Then
                    chkForMelting.Checked = False
                Else
                    chkForMelting.Checked = True
                End If
                If Not dgvReceipt.Rows(e.RowIndex).Cells(10).Value = "" Then
                    txtStockAdd.Text = dgvReceipt.Rows(e.RowIndex).Cells(10).Value.ToString()
                Else
                    txtStockAdd.Text = String.Empty
                End If
                TempRow = e.RowIndex
            End If
            BackWrd.Enabled = False
            'BackWrd.ForeColor = Color.Red
            FRWD.Enabled = True
            'FRWD.ForeColor = Color.Green
            cmbConversion.Enabled = True
            chkForMelting.Enabled = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmbConversion_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs) Handles cmbConversion.SelectedIndexChanged
        Dim dblFineWt As Double = 0
        Dim dblstockAddWt As Double = 0
        Try
            If cmbConversion.SelectedIndex = 0 Then
                txtFineWt.Text = Format((CDbl(Val(txtReceiveWt.Text)) * CDbl(Val(txtReceivePr.Text))) / 100, "0.000")
                txtStockAdd.Text = "0.00"
            Else
                If txtReceiveWt.Text.Trim.Length <> 0 Then
                    dblFineWt = Format((CDbl(Val(txtReceiveWt.Text)) * CDbl(Val(txtReceivePr.Text))) / 100, "0.000")

                    dblstockAddWt = Format((CDbl(txtReceiveWt.Text) * CDbl(cmbConversion.Text)) / 100, "0.00")

                    txtStockAdd.Text = Format(CDbl(dblstockAddWt) - CDbl(dblFineWt), "0.00")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtReceiveWt_TextChanged(sender As Object, e As EventArgs) Handles txtReceiveWt.TextChanged
        Try
            If txtReceivePr.Text <> "" Then
                txtFineWt.Text = Format((CDbl(Val(txtReceiveWt.Text)) * CDbl(Val(txtReceivePr.Text))) / 100, "0.000")
            Else
                txtFineWt.Text = Format((CDbl(Val(txtReceiveWt.Text)) * CDbl(Val(cmbConversion.Text))) / 100, "0.000")
            End If
            dbltempCalculate = 0
            dbltempCalculate = Format((CDbl(Val(txtReceiveWt.Text)) * CDbl(Val(txtReceivePr.Text))) / 100, "0.00")
            txtStockAdd.Text = Format(CDbl(Val(txtFineWt.Text)) - CDbl(Val(dbltempCalculate)), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtStockAdd_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtStockAdd.Validating
        Try
            If txtItemName.Text.Trim <> "" And Val(txtReceiveWt.Text.Trim) > 0 And Val(txtReceivePr.Text.Trim) > 0 And Val(txtFineWt.Text) > 0 Then
                If dgvReceipt.Rows.Count > 0 AndAlso ChkDuplicate() = True Then
                    MsgBox("Duplicate Data")
                Else
                    Me.fillGrid()
                End If
            Else
                MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmbVoucherNo_GotFocus(sender As Object, e As EventArgs) Handles cmbVoucherNo.GotFocus
        cmbVoucherNo.ShowDropDown()
    End Sub
    Private Sub FRWD_Click(sender As Object, e As EventArgs) Handles FRWD.Click
        If dgvReceipt.RowCount > 0 Then
            Try

                With dgvReceipt
                    If GridDoubleClick = False Then
                        With dgvReceipt
                            .SelectedRows.Contains(.CurrentRow)
                        End With
                    Else
                        .Rows.Remove(.CurrentRow)
                    End If
                End With
                With GRDFinal
                    GridDoubleClick = False
                End With
                Me.fillGrid()
                Me.fillConversion()
            Catch
            End Try
        End If
    End Sub
    Private Sub BackWrd_Click(sender As Object, e As EventArgs) Handles BackWrd.Click
        If GRDFinal.RowCount > 0 Then
            Try

                Me.fillGridBack()
                Me.fillConversion()
                With GRDFinal
                    If GridDoubleClick = False Then
                        With GRDFinal
                            .SelectedRows.Contains(.CurrentRow)
                        End With
                        With dgvReceipt
                            .SelectedRows.Contains(.CurrentRow)
                        End With
                    Else
                        .Rows.Remove(.CurrentRow)
                    End If
                End With
                With dgvReceipt
                    GridDoubleClick = False
                End With
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub GRDFinal_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles GRDFinal.CellDoubleClick
        Try
            If e.RowIndex = -1 Then Exit Sub
            If e.RowIndex >= 0 And GRDFinal.Rows(e.RowIndex).Cells(0).Value <> Nothing Then
                GridDoubleClick = True
                txtSrNo.Text = GRDFinal.Rows(e.RowIndex).Cells(0).Value.ToString()
                txtSrNo.Tag = GRDFinal.Rows(e.RowIndex).Cells(1).Value.ToString()
                txtReceiveWt.Tag = GRDFinal.Rows(e.RowIndex).Cells(2).Value.ToString()
                txtItemName.Tag = GRDFinal.Rows(e.RowIndex).Cells(3).Value.ToString()
                txtItemName.Text = GRDFinal.Rows(e.RowIndex).Cells(4).Value.ToString()
                txtReceiveWt.Text = GRDFinal.Rows(e.RowIndex).Cells(5).Value.ToString()
                txtReceivePr.Text = GRDFinal.Rows(e.RowIndex).Cells(6).Value.ToString()
                'If GRDFinal.Rows(e.RowIndex).Cells(6).Value = "" Then
                '    cmbConversion.Text = txtReceivePr.Text
                'Else
                '    cmbConversion.Text = GRDFinal.Rows(e.RowIndex).Cells(7).Value.ToString()
                'End If
                'cmbConversion.SelectedIndex = 0
                cmbConversion.Text = txtReceivePr.Text
                txtFineWt.Text = GRDFinal.Rows(e.RowIndex).Cells(8).Value.ToString()
                'If IsNothing(GRDFinal.Rows(e.RowIndex).Cells(8).Value) OrElse String.IsNullOrEmpty(GRDFinal.Rows(e.RowIndex).Cells(8).Value) Then
                '    chkForMelting.Checked = False
                'Else
                '    chkForMelting.Checked = True
                'End If
                chkForMelting.Checked = False
                txtStockAdd.Text = String.Empty
                'If Not GRDFinal.Rows(e.RowIndex).Cells(10).Value = "" Then
                '    txtStockAdd.Text = GRDFinal.Rows(e.RowIndex).Cells(10).Value.ToString()
                'Else
                '    txtStockAdd.Text = String.Empty
                'End If
                TempRow = e.RowIndex
            End If
            FRWD.Enabled = False
            'FRWD.ForeColor = Color.Red
            BackWrd.Enabled = True
            'BackWrd.ForeColor = Color.Green
            cmbConversion.Enabled = False
            chkForMelting.Checked = False
            chkForMelting.Enabled = False
            'With GRDFinal
            '    GridDoubleClick = False
            'End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtReceivePr_Leave(sender As Object, e As EventArgs) Handles txtReceivePr.Leave
        cmbConversion.Text = txtReceivePr.Text
    End Sub
    Private Sub RadGridView1_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles dgvInterDeptReceipt.CellDoubleClick
        If dgvInterDeptReceipt.Rows.Count > 0 Then
            Try
                'Dim ReceiptId As Integer = GridView1.SelectedItems(0).SubItems(0).Text
                Dim ReceiptId As Integer = dgvInterDeptReceipt.Rows(e.RowIndex).Cells(0).Value.ToString()
                Me.Clear_Form()
                Fr_Mode = FormState.EStateMode
                fillHeaderFromListView(ReceiptId)
                fillDetailsFromListView(ReceiptId)
                btnSave.Text = "Update"
                Me.TabControl1.SelectedIndex = 0
            Catch ex As Exception
                Throw ex
            End Try

        End If
    End Sub
    Private Function GetDescriptionTable() As DataTable
        Dim dtData As DataTable = New DataTable()
        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_MeltingMaster_Select", CommandType.StoredProcedure, parameters.ToArray())
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
        Return dtData
    End Function
    Sub fillGrid()
        Try
            If txtSrNo.Text.Trim() = "" Then
                GRDFinal.DataSource = False
            Else
                GRDFinal.Rows.Add(Val(txtSrNo.Text.Trim), txtSrNo.Tag, txtReceiveWt.Tag, txtItemName.Tag, txtItemName.Text.Trim(), Format(Val(txtReceiveWt.Text.Trim), "0.00"), Format(Val(txtReceivePr.Text.Trim), "0.00"), Format(Val(cmbConversion.Text.Trim), "0.00"), Format(Val(txtFineWt.Text.Trim), "0.00"), chkForMelting.CheckState, Format(Val(txtStockAdd.Text.Trim), "0.00"))
                Me.Total()
                txtSrNo.Clear()
                txtItemName.Clear()
                txtReceiveWt.Clear()
                txtReceivePr.Clear()
                cmbConversion.SelectedIndex = 0
                txtFineWt.Clear()
                chkForMelting.CheckState = False
                txtStockAdd.Clear()
            End If
        Catch
        End Try
    End Sub
    Sub fillGridBack()
        Try
            If txtSrNo.Text.Trim() = "" Then
                'dgvReceipt.DataSource = Nothing
            Else
                'dgvReceipt.Rows.Add(Val(txtSrNo.Text.Trim), txtSrNo.Tag, txtReceiveWt.Tag, txtItemName.Tag, txtItemName.Text.Trim(), Format(Val(txtReceiveWt.Text.Trim), "0.00"), Format(Val(txtReceivePr.Text.Trim), "0.00"), Format(Val(cmbConversion.Text.Trim), "0.00"), Format(Val(txtFineWt.Text.Trim), "0.00"), chkForMelting.CheckState, Format(Val(txtStockAdd.Text.Trim), "0.00"))
                dgvReceipt.Rows.Add(Val(txtSrNo.Text.Trim), txtSrNo.Tag, txtReceiveWt.Tag, txtItemName.Tag, txtItemName.Text.Trim(), Format(Val(txtReceiveWt.Text.Trim), "0.00"), Format(Val(txtReceivePr.Text.Trim), "0.00"), "", Format(Val(txtFineWt.Text.Trim), "0.00"), chkForMelting.CheckState, "")
                Me.Total()
                txtSrNo.Clear()
                txtItemName.Tag = ""
                txtItemName.Clear()
                txtReceiveWt.Tag = 0
                txtReceiveWt.Clear()
                txtReceivePr.Clear()
                cmbConversion.SelectedIndex = 0
                txtFineWt.Clear()
                chkForMelting.CheckState = False
                txtStockAdd.Clear()
                GetSrNo(dgvReceipt)
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
