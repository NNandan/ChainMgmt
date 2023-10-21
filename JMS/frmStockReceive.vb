Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmStockReceive
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
                    Me.btnSave.Text = "&Save"
                    Me.btnDelete.Enabled = False
                Case FormState.EStateMode
                    CType(Me.ParentForm, frmMain).FormMode.Text = "Edit Record"
                    Me.btnSave.Text = "&Update"
                    Me.btnDelete.Enabled = True
            End Select
        End Set
    End Property
    Private Sub frmStockReceive_Load(sender As Object, e As EventArgs) Handles Me.Load
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

        Me.fillDepartment()
        Me.fillLabour()
        Me.fillVoucherNo()

        Me.bindDataGridView()

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
    Private Function fetchAllRecords() As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchIssueData", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_Issue_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub bindDataGridView()
        Dim dtdata As DataTable = fetchAllRecords()

        Try
            dgvStockReceive.DataSource = dtdata
            dgvStockReceive.EnableFiltering = True
            dgvStockReceive.MasterTemplate.ShowFilteringRow = False
            dgvStockReceive.MasterTemplate.ShowHeaderCellButtons = True
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
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
    Private Sub fillVoucherNo()
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchVoucherNo", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_Issue_Select", CommandType.StoredProcedure, parameters.ToArray(), Objcn)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            ''Insert the Default Item to DataTable.
            Dim row As DataRow = dt.NewRow()
            row(0) = 0
            row(1) = "---Select---"
            dt.Rows.InsertAt(row, 0)

            'Assign DataTable as DataSource.
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
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Call Clear_Form()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Testing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub GetSrNo(ByRef grid As Telerik.WinControls.UI.RadGridView)
        Try
            For Each rowInfo As GridViewRowInfo In dgvReceive.Rows
                rowInfo.Cells(0).Value = rowInfo.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub SaveData()
        Dim alParaval As New ArrayList

        Dim ItemType As String = Nothing
        Dim LotNo As String = ""
        Dim ItemId As String = ""
        Dim ReceiveWt As String = ""
        Dim ReceivePr As String = ""
        Dim ConvPr As String = ""
        Dim FineWt As String = ""

        Dim IRowCount As Integer = 0
        Dim iValue As Integer = 0

        alParaval.Add(TransDt.Value.ToString())
        alParaval.Add(cmbfDepartment.SelectedValue)
        alParaval.Add(cmbtDepartment.SelectedValue)
        alParaval.Add(cmbVoucherNo.Text.Trim())
        alParaval.Add(txtFrKarigar.Tag)
        alParaval.Add(cmbTLabour.SelectedValue)

        For Each row As GridViewRowInfo In dgvReceive.Rows
            If row.Cells(0).Value <> Nothing Then
                If ItemType = "" Then
                    ItemType = Convert.ToString(row.Cells(1).Value)
                    LotNo = Convert.ToString(row.Cells(2).Value)
                    ItemId = Val(row.Cells(3).Value)
                    ReceiveWt = Val(row.Cells(5).Value)
                    ReceivePr = Val(row.Cells(6).Value)
                    ConvPr = Val(row.Cells(7).Value)
                    FineWt = Val(row.Cells(8).Value)
                Else
                    ItemType = ItemType & "|" & Convert.ToString(row.Cells(1).Value)
                    LotNo = LotNo & "|" & Convert.ToString(row.Cells(2).Value)
                    ItemId = ItemId & "|" & Val(row.Cells(3).Value)
                    ReceiveWt = ReceiveWt & "|" & row.Cells(5).Value
                    ReceivePr = ReceivePr & "|" & row.Cells(6).Value
                    ConvPr = ConvPr & "|" & Val(row.Cells(7).Value)
                    FineWt = FineWt & "|" & row.Cells(8).Value
                End If
            End If
            IRowCount += 1
        Next

        alParaval.Add(ItemType)
        alParaval.Add(LotNo)
        alParaval.Add(ItemId)
        alParaval.Add(ReceiveWt)
        alParaval.Add(ReceivePr)
        alParaval.Add(ConvPr)
        alParaval.Add(FineWt)

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

                ''For Transaction
                '.Add(dbManager.CreateParameter("@TReceiveWt", txtReceiveWt.Text, DbType.String))
                '.Add(dbManager.CreateParameter("@TReceivePr", txtReceivePr.Text, DbType.String))
                '.Add(dbManager.CreateParameter("@TIssueWt", lblTotalIssueWt.Text, DbType.String))
                '.Add(dbManager.CreateParameter("@TIssuePr", lblTotalIssuePr.Text, DbType.String))
                ''For Transaction

                .Add(dbManager.CreateParameter("@DItemType", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DLotNo", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DItemId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DReceiveWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DReceivePr", alParaval.Item(iValue), DbType.String))
                iValue += 1

                If DeptId = 7 Then
                    .Add(dbManager.CreateParameter("@DConvPr", alParaval.Item(iValue), DbType.String))
                    iValue += 1
                Else

                End If

                .Add(dbManager.CreateParameter("@DFineWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
            End With

            dbManager.Insert("SP_StockReceive_Save", CommandType.StoredProcedure, Hparameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub UpdateData()
        Dim alParaval As New ArrayList

        Dim ItemId As String = ""
        Dim ReceivePr As String = ""
        Dim ReceiveWt As String = ""
        Dim FineWt As String = ""

        Dim IRowCount As Integer = 0
        Dim iValue As Integer = 0

        alParaval.Add(TransDt.Value.ToString())
        alParaval.Add(cmbfDepartment.SelectedValue)
        alParaval.Add(cmbtDepartment.SelectedValue)
        alParaval.Add(cmbVoucherNo.Text.Trim())
        alParaval.Add(txtFrKarigar.Tag)
        alParaval.Add(cmbTLabour.SelectedValue)

        For Each row As GridViewRowInfo In dgvReceive.Rows
            If row.Cells(0).Value <> Nothing Then
                If ItemId = "" Then
                    ItemId = Val(row.Cells(1).Value)
                    ReceiveWt = Val(row.Cells(3).Value)
                    ReceivePr = Val(row.Cells(4).Value)
                    FineWt = Val(row.Cells(5).Value)
                Else
                    ItemId = ItemId & "|" & Val(row.Cells(1).Value)
                    ReceiveWt = ReceiveWt & "|" & row.Cells(3).Value
                    ReceivePr = ReceivePr & "|" & row.Cells(4).Value
                    FineWt = FineWt & "|" & row.Cells(5).Value
                End If
            End If
            IRowCount += 1
        Next

        alParaval.Add(ItemId)
        alParaval.Add(ReceiveWt)
        alParaval.Add(ReceivePr)
        alParaval.Add(FineWt)

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

                .Add(dbManager.CreateParameter("@RId", Val(txtTransNo.Tag), DbType.Int16))
                .Add(dbManager.CreateParameter("@HCreatedBy", UserName.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@GridCount", IRowCount, DbType.Int16))

                ''For Transaction
                '.Add(dbManager.CreateParameter("@TReceiveWt", txtReceiveWt.Text, DbType.String))
                '.Add(dbManager.CreateParameter("@TReceivePr", txtReceivePr.Text, DbType.String))
                '.Add(dbManager.CreateParameter("@TIssueWt", lblTotalIssueWt.Text, DbType.String))
                '.Add(dbManager.CreateParameter("@TIssuePr", lblTotalIssuePr.Text, DbType.String))
                ''For Transaction

                .Add(dbManager.CreateParameter("@DItemId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DReceiveWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DReceivePr", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DFineWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
            End With

            dbManager.Insert("SP_Receipt_Update", CommandType.StoredProcedure, Hparameters.ToArray())

            MessageBox.Show("Data Updated !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

    End Sub
    Private Sub Clear_Form()
        Try

            '' For Header Field Start
            cmbVoucherNo.Enabled = True
            cmbVoucherNo.SelectedIndex = 0
            TransDt.Value = DateTime.Now

            cmbfDepartment.SelectedIndex = 0
            cmbtDepartment.SelectedIndex = 0

            txtFrKarigar.Tag = ""
            txtFrKarigar.Clear()
            cmbTLabour.SelectedIndex = 0
            '' For Header Field End

            '' For Detail Field Start
            dgvReceive.DataSource = Nothing
            dgvReceive.Rows.Clear()

            '' For Detail Field End

            GridDoubleClick = False

            'lblTotalGrossWt.Text = 0.0
            'lblTotalGrossPr.Text = 0.0

            'lblTotalFineWt.Text = 0.0

            Me.bindDataGridView()

            Fr_Mode = FormState.AStateMode

            cmbfDepartment.SelectedIndex = 4
            cmbfDepartment.Enabled = False

            cmbtDepartment.SelectedIndex = DeptId
            cmbtDepartment.Enabled = False

            txtFrKarigar.Tag = CInt(UserId)
            txtFrKarigar.Text = Convert.ToString(KarigarName.Trim)

            TransDt.Focus()
            TransDt.Select()

            Me.fillVoucherNo()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Function Validate_Fields() As Boolean
        Try
            If Not dgvReceive.RowCount > 0 Then
                MessageBox.Show("Cannot Save Without Detail Information!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False
                Exit Function
            End If

            If cmbfDepartment.SelectedIndex = 0 Then
                MessageBox.Show("Select Department !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbfDepartment.Focus()
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Sub Total()
        Try
            'lblTotalGrossWt.Text = 0.00
            'lblTotalGrossPr.Text = 0.00
            'lblTotalFineWt.Text = 0.00

            For Each row As GridViewRowInfo In dgvReceive.Rows
                'lblTotalGrossWt.Text = Format(Val(lblTotalGrossWt.Text) + CDbl(row.Cells(4).Value), "0.00")
                'lblTotalGrossPr.Text = Format(Val(lblTotalGrossPr.Text) + CDbl(row.Cells(5).Value), "0.00")
                'lblTotalFineWt.Text = Format(Val(lblTotalGrossWt.Text) * CDbl(lblTotalGrossPr.Text) / 100, "0.000")
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmbVoucherNo_SelectionChangeCommitted(sender As Object, e As EventArgs)
        Dim dtData As DataTable = New DataTable()

        If cmbVoucherNo.SelectedIndex > 0 Then
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchDetailRecord", DbType.String))
                .Add(dbManager.CreateParameter("@IId", cmbVoucherNo.SelectedValue, DbType.Int16))
            End With

            dtData = dbManager.GetDataTable("SP_Issue_Select", CommandType.StoredProcedure, parameters.ToArray())

            Try

                If dtData.Rows.Count > 0 Then
                    dgvReceive.DataSource = dtData
                End If

                Me.GetSrNo(dgvReceive)
                Me.Total()

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally

            End Try
        End If
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not String.IsNullOrEmpty(txtTransNo.Text) Then

            If (MsgBox("[DELETION] Are You Sure To Delete This Entry ?", vbYesNo + vbDefaultButton2 + vbQuestion, "Attn : " + UserName.Trim()) = vbYes) Then

                Try
                    Dim parameters = New List(Of SqlParameter)()

                    With parameters
                        .Clear()
                        .Add(dbManager.CreateParameter("@RId", txtTransNo.Text, DbType.Int16))
                    End With

                    dbManager.Delete("SP_StockReceive_Delete", CommandType.StoredProcedure, parameters.ToArray())

                    MessageBox.Show("Data Deleted !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Me.Clear_Form()

                Catch ex As Exception
                    MessageBox.Show("Error:- " & ex.Message)
                End Try
            Else
                MessageBox.Show("Please Select A Record !!!")
            End If
        End If
    End Sub
    Private Sub fillHeaderFromListView(ByVal iReceiveId As Integer)

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@RId", CInt(iReceiveId), DbType.Int16))
            .Add(dbManager.CreateParameter("@ActionType", "FetchHeaderRecord", DbType.String))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader("SP_StockReceive_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

        If dr.HasRows = False Then
            Exit Sub
        Else
            dr.Read()
            txtTransNo.Text = dr.Item("ReceiptId").ToString()
            cmbVoucherNo.SelectedIndex = dr.Item("ReceiptId").ToString()
            TransDt.Text = dr.Item("ReceiptDt").ToString()
            cmbfDepartment.SelectedIndex = dr.Item("FrDeptId").ToString()
            cmbtDepartment.SelectedIndex = dr.Item("ToDeptId").ToString()
            txtFrKarigar.Tag = dr.Item("FrKarigarId").ToString()
            txtFrKarigar.Text = dr.Item("FrKarigar").ToString()
            cmbTLabour.SelectedIndex = dr.Item("ToKarigarId").ToString()
        End If

        dr.Close()
        Objcn.Close()

        Exit Sub
ErrHandler:
        MsgBox(Err.Description, MsgBoxStyle.Critical)
    End Sub
    Private Sub fillDetailsFromListView(ByVal iReceiveId As Integer)
        Dim dttable As New DataTable
        dttable = fetchAllRecords(CInt(iReceiveId))

        dgvReceive.DataSource = Nothing

        For Each ROW As DataRow In dttable.Rows
            dgvReceive.Rows.Add(1, CStr(ROW("ItemType")), CStr(ROW("SlipBagNo")), Val(ROW("ItemId")), CStr(ROW("ItemName")), Format(Val(ROW("ReceiveWt")), "0.00"), Format(Val(ROW("ReceivePr")), "0.00"), Format(Val(ROW("ConvPr")), "0.00"), Format(Val(ROW("FineWt")), "0.000"))
        Next

        Me.GetSrNo(dgvReceive)
        Me.Total()

        dgvReceive.ReadOnly = True

    End Sub
    Private Sub cmbVoucherNo_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbVoucherNo.SelectedIndexChanged
        Dim dtData As DataTable = New DataTable()

        If cmbVoucherNo.SelectedIndex <> -1 Then
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchIssueNoWiseDetails", DbType.String))
                .Add(dbManager.CreateParameter("@IId", cmbVoucherNo.SelectedIndex, DbType.Int16))
            End With

            dtData = dbManager.GetDataTable("SP_Issue_Select", CommandType.StoredProcedure, parameters.ToArray())

            Try

                If dtData.Rows.Count > 0 Then
                    dgvReceive.DataSource = dtData
                End If

                Me.Total()

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally

            End Try
        End If
    End Sub
    Private Function fetchAllRecords(ByVal iReceiveId As Integer) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@RId", CInt(iReceiveId), DbType.Int16))
                .Add(dbManager.CreateParameter("@ActionType", "FetchDetailRecord", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_StockReceive_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function

    Private Sub dgvStockReceive_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles dgvStockReceive.CellDoubleClick
        If dgvStockReceive.SelectedRows.Count = 0 Then Exit Sub

        If dgvStockReceive.Rows.Count > 0 Then
            Dim ReceiveId As Integer = Me.dgvStockReceive.SelectedRows(0).Cells(0).Value

            Me.Clear_Form()

            Fr_Mode = FormState.EStateMode

            Me.fillHeaderFromListView(ReceiveId)

            Me.fillDetailsFromListView(ReceiveId)

            Me.tbStockReceive.SelectedIndex = 0
        End If
    End Sub

    Private Sub frmStockReceive_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
    Private Sub cmbVoucherNo_GotFocus(sender As Object, e As EventArgs)
        cmbVoucherNo.ShowDropDown()
    End Sub

    Private Sub dgvReceive_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs) Handles dgvReceive.ViewCellFormatting
        If e.CellElement.ColumnInfo.Name = "colSrNo" AndAlso e.CellElement.Value Is Nothing Then
            e.CellElement.Value = e.CellElement.RowIndex + 1
        End If
    End Sub
End Class