Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Imports JMS.Common_Cls
Imports System.ComponentModel
Public Class frmOpLotAddIssue
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
    Private Sub frmOpLotAddIssue_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Clear_Form()
        Me.filltemName()
        Me.fillOperation()
    End Sub
    Private Sub fillOperation()
        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FillOperation", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_OperationMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            ''Insert the Default Item to DataTable.
            Dim row As DataRow = dt.NewRow()
            row(0) = 0
            row(1) = "---Select---"
            dt.Rows.InsertAt(row, 0)

            'Assign DataTable as DataSource.
            cmbOperation.DataSource = dt
            cmbOperation.DisplayMember = "OperationName"
            cmbOperation.ValueMember = "OperationId"

            cmbOperation.AutoCompleteMode = AutoCompleteMode.SuggestAppend ' This is necessary
            cmbOperation.AutoCompleteDataSource = AutoCompleteSource.ListItems
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub filltemName()

        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FillItemName", DbType.String))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader("SP_ItemMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)

        Dim dt As DataTable = New DataTable()
        Dim dt1 As DataTable = New DataTable

        dt.Load(dr)

        Try
            'Insert the Default Item to DataTable.
            Dim row As DataRow = dt.NewRow()
            row(0) = 0
            row(1) = "---Select---"
            dt.Rows.InsertAt(row, 0)

            'Assign DataTable as DataSource.
            cmbGItem.DataSource = dt
            cmbGItem.DisplayMember = "ItemName"
            cmbGItem.ValueMember = "ItemId"
            cmbGItem.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbGItem.AutoCompleteDataSource = AutoCompleteSource.ListItems

            cmbItem.BindingContext = New BindingContext()
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
    Sub fillGrid()

        If GridDoubleClick = False Then
            dgvLotIssue.Rows.Add(Val(txtSrNo.Text.Trim),
                                    Convert.ToString(cmbItemType.Text.Trim),
                                    Convert.ToString(txtBagNo.Text.Trim),
                                    Val(cmbGItem.SelectedValue),
                                    Convert.ToString(cmbGItem.Text.Trim),
                                    Format(Val(txtIssueWt.Text.Trim), "0.00"),
                                    Format(Val(txtIssuePr.Text.Trim), "0.00"),
                                    Format(Val(txtFineWt.Text.Trim), "0.000"),
                                    Convert.ToString(txtRemarks.Text.Trim))
            GetSrNo(dgvLotIssue)
        Else
            dgvLotIssue.Rows(TempRow).Cells(0).Value = txtSrNo.Text.Trim
            dgvLotIssue.Rows(TempRow).Cells(5).Value = Format(Val(txtIssueWt.Text.Trim), "0.00")
            dgvLotIssue.Rows(TempRow).Cells(6).Value = Format(Val(txtIssueWt.Text.Trim), "0.00")
            dgvLotIssue.Rows(TempRow).Cells(7).Value = Format(Val(txtRemarks.Text.Trim), "0.000")
            dgvLotIssue.Rows(TempRow).Cells(8).Value = Val(txtRemarks.Tag.Trim)
            GridDoubleClick = False
        End If

        dgvLotIssue.TableElement.ScrollToRow(dgvLotIssue.Rows.Last)

        txtSrNo.Text = dgvLotIssue.RowCount + 1
        cmbItem.SelectedIndex = 0
        txtIssueWt.Clear()
        txtIssuePr.Clear()
        txtRemarks.Clear()
        txtFineWt.Clear()
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'If Not Validate_Fields() Then Exit Sub

        Try
            If Fr_Mode = FormState.AStateMode Then
                Me.SaveData()
                Me.btnCancel_Click(sender, e)
            Else
                'Me.UpdateData()
                Me.btnCancel_Click(sender, e)
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Function ChkDuplicate() As Boolean
        Dim exists As Boolean = False

        If GridDoubleClick = False Then
            For Each itm As GridViewRowInfo In dgvLotIssue.Rows
                If itm.Cells(4).Value = CStr(cmbItem.Text.Trim) Then
                    exists = True
                End If
            Next
        End If

        Return exists

    End Function
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Call Clear_Form()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Product_Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub txtIssueWt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIssueWt.KeyPress
        numdotkeypress(e, txtIssueWt, Me)
    End Sub
    Private Sub txtIssuePr_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIssuePr.KeyPress
        numdotkeypress(e, txtIssuePr, Me)
    End Sub
    Private Sub txtIssuePr_TextChanged(sender As Object, e As EventArgs) Handles txtIssuePr.TextChanged
        Try
            txtFineWt.Text = Format((Val(txtIssueWt.Text) * Val(txtIssuePr.Text)) / 100, "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtIssueWt_TextChanged(sender As Object, e As EventArgs) Handles txtIssueWt.TextChanged
        Try
            txtFineWt.Text = Format((Val(txtIssueWt.Text) * Val(txtIssuePr.Text)) / 100, "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub GetSrNo(ByRef grid As Telerik.WinControls.UI.RadGridView)
        Try
            For Each rowInfo As GridViewRowInfo In dgvLotIssue.Rows
                rowInfo.Cells(0).Value = rowInfo.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmbItem_Enter(sender As Object, e As EventArgs) Handles cmbItem.Enter
        cmbItem.ShowDropDown()
    End Sub
    Private Sub cmbOperation_Enter(sender As Object, e As EventArgs) Handles cmbOperation.Enter
        cmbOperation.ShowDropDown()
    End Sub
    Private Sub cmbItemType_Enter(sender As Object, e As EventArgs) Handles cmbItemType.Enter
        cmbItemType.ShowDropDown()
    End Sub
    Private Sub cmbGItem_Enter(sender As Object, e As EventArgs) Handles cmbGItem.Enter
        cmbGItem.ShowDropDown()
    End Sub
    Private Sub txtIssuePr_Leave(sender As Object, e As EventArgs) Handles txtIssuePr.Leave
        txtIssuePr.Text = Format(Val(txtIssuePr.Text), "0.00")
    End Sub
    Private Sub txtIssueWt_Leave(sender As Object, e As EventArgs) Handles txtIssueWt.Leave
        txtIssueWt.Text = Format(Val(txtIssueWt.Text), "0.00")
    End Sub
    Private Sub txtLotNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLotNo.KeyPress
        '' If certain characters then allow
        If e.KeyChar = vbBack Then Exit Sub
        '' Do not allow the comma character (or any other invalid characters)
        If e.KeyChar = "." Or IsNumeric(e.KeyChar) = False Then e.KeyChar = Chr(0)
    End Sub
    Private Sub txtRemarks_Validating(sender As Object, e As CancelEventArgs) Handles txtRemarks.Validating
        Try
            If cmbItemType.Text.Trim <> "" And txtIssueWt.Text.Trim <> "" And cmbGItem.Text.Trim <> "" And Val(txtIssueWt.Text.Trim) > 0 And Val(txtIssuePr.Text.Trim) > 0 Then

                'ErrorProvider1.SetError(txtRequirePr, "")

                If dgvLotIssue.Rows.Count > 0 AndAlso ChkDuplicate() = True Then
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
    Private Sub SaveData()
        Dim alParaval As New ArrayList

        Dim GridSrNo As String = Nothing
        Dim ItemType As String = Nothing
        Dim SlipBagNo As String = Nothing
        Dim ItemId As String = Nothing
        Dim IssuePr As String = Nothing
        Dim IssueWt As String = Nothing
        Dim Remarks As String = Nothing

        Dim IRowCount As Integer = 0
        Dim iValue As Integer = 0

        alParaval.Add(TransDt.Value.ToString())
        alParaval.Add(cmbOperation.SelectedValue)
        alParaval.Add(txtLotNo.Text.Trim)
        alParaval.Add(cmbItem.SelectedValue)
        alParaval.Add(txtLotAddNo.Text.Trim())
        alParaval.Add(UserId)
        alParaval.Add(UserId)

        For Each row As GridViewRowInfo In dgvLotIssue.Rows
            If row.Cells(0).Value <> Nothing Then
                If GridSrNo = "" Then
                    GridSrNo = Val(row.Cells(0).Value)
                    ItemType = Convert.ToString(row.Cells(1).Value)
                    SlipBagNo = Convert.ToString(row.Cells(2).Value)
                    ItemId = Val(row.Cells(3).Value)
                    IssuePr = CDbl(row.Cells(5).Value)
                    IssueWt = Val(row.Cells(6).Value)
                    Remarks = (row.Cells(8).Value)
                Else
                    GridSrNo = GridSrNo & "|" & Val(row.Cells(0).Value)
                    ItemType = ItemType & "|" & Convert.ToString(row.Cells(1).Value)
                    SlipBagNo = SlipBagNo & "|" & Convert.ToString(row.Cells(2).Value)
                    ItemId = ItemId & "|" & Val(row.Cells(3).Value)
                    IssuePr = IssuePr & "|" & Val(row.Cells(5).Value)
                    IssueWt = IssueWt & "|" & Val(row.Cells(6).Value)
                    Remarks = Remarks & "|" & (row.Cells(8).Value)
                End If
            End If
            IRowCount += 1
        Next

        alParaval.Add(ItemType)
        alParaval.Add(SlipBagNo)
        alParaval.Add(ItemId)
        alParaval.Add(IssuePr)
        alParaval.Add(IssueWt)
        alParaval.Add(Remarks)

        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()

            With Hparameters
                .Add(dbManager.CreateParameter("@HLotAdditionDt", alParaval.Item(iValue), DbType.DateTime))
                iValue += 1
                .Add(dbManager.CreateParameter("@HOperationId ", alParaval.Item(iValue), DbType.Int16))
                iValue += 1
                .Add(dbManager.CreateParameter("@HLotNumber", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@HItemId", alParaval.Item(iValue), DbType.Int16))
                iValue += 1
                .Add(dbManager.CreateParameter("@HLotAdditionNumber", alParaval.Item(iValue), DbType.String))
                iValue += 1

                .Add(dbManager.CreateParameter("@FrKarigarId", alParaval.Item(iValue), DbType.Int16))
                iValue += 1
                .Add(dbManager.CreateParameter("@ToKarigarId", alParaval.Item(iValue), DbType.Int16))
                iValue += 1

                .Add(dbManager.CreateParameter("@HCreatedBy", UserName.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@GridCount", IRowCount, DbType.Int16))
                .Add(dbManager.CreateParameter("@HIsOpening", 0, DbType.Boolean))

                ''''For Transaction
                '.Add(dbManager.CreateParameter("@TReceiveWt", lblGTotalIssueWt.Text.Trim(), DbType.String))
                '.Add(dbManager.CreateParameter("@TReceivePr", lblGTotalIssuePr.Text.Trim, DbType.String))

                '.Add(dbManager.CreateParameter("@TIssueWt", txtBalanceWt.Text.Trim, DbType.String))
                '.Add(dbManager.CreateParameter("@TIssuePr", txtBalancePr.Text.Trim, DbType.String))
                ''''For Transaction

                .Add(dbManager.CreateParameter("@DItemType", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DSlipBagNo", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DItemId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DIssuePr", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DIssueWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DRemarks", alParaval.Item(iValue), DbType.String))
                iValue += 1
            End With

            dbManager.Insert("SP_LotAdditionIssue_Save", CommandType.StoredProcedure, Hparameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub Clear_Form()
        Try
            '' For Header Field Start
            cmbItem.SelectedIndex = 0
            '' For Header Field End

            '' For Detail Field Start
            txtSrNo.Text = 1

            txtLotNo.Tag = ""
            txtLotNo.Clear()

            cmbOperation.Text = ""
            cmbOperation.Enabled = True

            txtIssueWt.Clear()
            txtIssuePr.Clear()
            txtFineWt.Clear()
            txtRemarks.Clear()

            dgvLotIssue.RowCount = 0
            '' For Detail Field End

            GridDoubleClick = False

            'Fr_Mode = FormState.AStateMode

            TransDt.Focus()
            TransDt.Select()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Testing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub frmOpLotAddIssue_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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

            With dgvLotIssue
                If e.KeyCode = Keys.F12 Then
                    .Rows.Remove(.CurrentRow)
                End If
            End With

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class