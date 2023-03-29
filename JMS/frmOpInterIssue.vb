Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Imports JMS.Common_Cls
Public Class frmOpInterIssue
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState

    Dim strSQL As String = Nothing
    Dim TempRow As Integer
    Dim GridDoubleClick As Boolean

    Dim dbltempCalculate As Double = 0

    Dim dbManager As New SqlHelper()
    Dim Objcn As SqlConnection = New SqlConnection()
    Private Sub frmOpInterIssue_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Clear_Form()
        Me.filltemName()
        Me.fillConversion()
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'If Not Validate_Fields() Then Exit Sub

        Try
            If Fr_Mode = FormState.AStateMode Then
                Me.SaveData()
                Me.btnCancel_Click(sender, e)
            Else
                'Me.UpdateData()
                'Me.btnCancel_Click(sender, e)
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Call Clear_Form()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Product_Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
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

            txtIssueWt.Clear()
            txtIssuePr.Clear()
            txtFineWt.Clear()

            dgvIssue.RowCount = 0
            '' For Detail Field End

            GridDoubleClick = False

            Fr_Mode = FormState.AStateMode

            TransDt.Focus()
            TransDt.Select()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Product_Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub txtIssueWt_TextChanged(sender As Object, e As EventArgs) Handles txtIssueWt.TextChanged
        Try
            If txtIssuePr.Text <> "" Then
                txtFineWt.Text = Format((Val(txtIssueWt.Text) * Val(txtIssuePr.Text)) / 100, "0.000")
            Else
                txtFineWt.Text = Format((Val(txtIssueWt.Text) * Val(cmbConversion.Text)) / 100, "0.000")
            End If

            dbltempCalculate = 0

            dbltempCalculate = Format((Val(txtIssueWt.Text) * Val(txtIssuePr.Text)) / 100, "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmbConversion_TextChanged(sender As Object, e As EventArgs) Handles cmbConversion.TextChanged
        Try
            txtFineWt.Text = Format((Val(txtIssueWt.Text) * Val(cmbConversion.Text)) / 100, "0.000")

            dbltempCalculate = 0

            dbltempCalculate = Format((Val(txtIssueWt.Text) * Val(txtIssuePr.Text)) / 100, "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub SaveData()
        Dim alParaval As New ArrayList

        Dim GridSrNo As String = ""
        Dim ItemType As String = Nothing
        Dim LotNo As String = ""
        Dim ItemId As String = ""
        Dim IssuePr As String = ""
        Dim IssueWt As String = ""

        Dim ConvPr As String = ""
        Dim FineWt As String = ""
        Dim StockAdd As String = ""

        Dim IRowCount As Integer = 0
        Dim iValue As Integer = 0

        alParaval.Add(TransDt.Value.ToString())
        alParaval.Add(1)
        alParaval.Add(4)
        alParaval.Add(txtVocucherNo.Text.Trim())

        For Each row As GridViewRowInfo In dgvIssue.Rows
            If row.Cells(0).Value <> Nothing Then
                If GridSrNo = "" Then
                    GridSrNo = Val(row.Cells(0).Value)
                    ItemType = Convert.ToString(row.Cells(1).Value)
                    LotNo = Convert.ToString(row.Cells(2).Value)
                    ItemId = row.Cells(3).Value
                    IssueWt = row.Cells(5).Value
                    IssuePr = row.Cells(6).Value

                    ConvPr = row.Cells(7).Value
                    FineWt = row.Cells(8).Value
                Else
                    GridSrNo = GridSrNo & "|" & Val(row.Cells(0).Value)
                    ItemType = ItemType & "|" & Convert.ToString(row.Cells(1).Value)
                    LotNo = LotNo & "|" & Convert.ToString(row.Cells(2).Value)
                    ItemId = ItemId & "|" & row.Cells(3).Value
                    IssueWt = IssueWt & "|" & row.Cells(5).Value
                    IssuePr = IssuePr & "|" & row.Cells(6).Value

                    ConvPr = ConvPr & "|" & row.Cells(7).Value
                    FineWt = FineWt & "|" & row.Cells(8).Value
                End If
            End If
            IRowCount += 1
        Next

        alParaval.Add(ItemType)
        alParaval.Add(LotNo)
        alParaval.Add(ItemId)
        alParaval.Add(IssueWt)
        alParaval.Add(IssuePr)

        alParaval.Add(ConvPr)
        alParaval.Add(FineWt)

        Try
            Dim tparameters = New List(Of SqlParameter)()
            tparameters.Clear()

            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()

            With Hparameters
                .Add(dbManager.CreateParameter("@HIssueDt", alParaval.Item(iValue), DbType.DateTime))
                iValue += 1
                .Add(dbManager.CreateParameter("@HfDeptId ", alParaval.Item(iValue), DbType.Int16))
                iValue += 1
                .Add(dbManager.CreateParameter("@HtDeptId ", alParaval.Item(iValue), DbType.Int16))
                iValue += 1

                .Add(dbManager.CreateParameter("@HVoucherNo", alParaval.Item(iValue), DbType.String))
                iValue += 1

                .Add(dbManager.CreateParameter("@HCreatedBy", UserName.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@GridCount", IRowCount, DbType.Int16))
                .Add(dbManager.CreateParameter("@HIsOpening", 0, DbType.Boolean))

                .Add(dbManager.CreateParameter("@DItemType", alParaval.Item(iValue), DbType.String))
                iValue += 1

                .Add(dbManager.CreateParameter("@DLotNo", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DItemId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DIssueWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DIssuePr", alParaval.Item(iValue), DbType.String))
                iValue += 1

                .Add(dbManager.CreateParameter("@DConvPr", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DFineWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
            End With

            dbManager.Insert("SP_Issue_Save", CommandType.StoredProcedure, Hparameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub txtFineWt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtFineWt.Validating
        Try
            If Not cmbItem.SelectedIndex > 0 Then
                MsgBox("Select Item")
                cmbItem.Focus()
                Exit Sub
            End If

            If txtBagNo.Text.Trim <> "" And Val(txtIssueWt.Text.Trim) > 0 And Val(txtIssuePr.Text.Trim) > 0 Then
                fillGrid()
                'Total()
            Else
                MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtIssueWt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIssueWt.KeyPress
        numdotkeypress(e, txtIssueWt, Me)
    End Sub
    Private Sub cmbItemType_Enter(sender As Object, e As EventArgs) Handles cmbItemType.Enter
        cmbItemType.ShowDropDown()
    End Sub
    Private Sub cmbItem_Enter(sender As Object, e As EventArgs) Handles cmbItem.Enter
        cmbItem.ShowDropDown()
    End Sub
    Private Sub txtIssuePr_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIssuePr.KeyPress
        numdotkeypress(e, txtIssuePr, Me)
    End Sub
    Sub fillGrid()

        If GridDoubleClick = False Then

            dgvIssue.Rows.Add(Val(txtSrNo.Text.Trim),
                                    cmbItemType.Text.Trim(),
                                    txtBagNo.Text.Trim(),
                                    cmbItem.SelectedIndex,
                                    cmbItem.Text.Trim(),
                                    Format(Val(txtIssueWt.Text.Trim), "0.00"),
                                    Format(Val(txtIssuePr.Text.Trim), "0.00"),
                                    Format(Val(cmbConversion.Text.Trim), "0.00"),
                                    Format(Val(txtFineWt.Text.Trim), "0.00"),
                                    Format(dbltempCalculate, "0.00"))
            GetSrNo(dgvIssue)
        Else
            dgvIssue.Rows(TempRow).Cells(0).Value = txtSrNo.Text.Trim
            dgvIssue.Rows(TempRow).Cells(1).Value = cmbItemType.Text.Trim()
            dgvIssue.Rows(TempRow).Cells(2).Value = cmbItemType.Text.Trim()
            dgvIssue.Rows(TempRow).Cells(3).Value = txtBagNo.Tag
            dgvIssue.Rows(TempRow).Cells(4).Value = txtBagNo.Text.Trim()
            dgvIssue.Rows(TempRow).Cells(5).Value = Format(Val(txtIssueWt.Text.Trim), "0.00")
            dgvIssue.Rows(TempRow).Cells(6).Value = Format(Val(txtIssuePr.Text.Trim), "0.00")
            dgvIssue.Rows(TempRow).Cells(7).Value = Format(Val(cmbConversion.Text.Trim), "0.00")
            dgvIssue.Rows(TempRow).Cells(8).Value = Format(Val(txtFineWt.Text.Trim), "0.00")

            GridDoubleClick = False
        End If


        dgvIssue.TableElement.ScrollToRow(dgvIssue.Rows.Last)

        txtSrNo.Text = dgvIssue.RowCount + 1

        cmbItemType.SelectedIndex = 0
        txtBagNo.Tag = ""
        txtBagNo.Clear()
        cmbItem.SelectedIndex = 0
        txtIssueWt.Tag = 0
        txtIssueWt.Clear()
        txtIssuePr.Clear()
        cmbConversion.SelectedIndex = 0
        txtFineWt.Clear()
    End Sub
    Private Sub txtIssueWt_Leave(sender As Object, e As EventArgs) Handles txtIssueWt.Leave
        txtIssueWt.Text = Format(Val(txtIssueWt.Text), "0.00")
    End Sub
    Private Sub txtIssuePr_Leave(sender As Object, e As EventArgs) Handles txtIssuePr.Leave
        txtIssuePr.Text = Format(Val(txtIssuePr.Text), "0.00")
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
    Private Sub fillConversion()
        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        parameters.Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))

        Dim dr = dbManager.GetDataReader("SP_AccountMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), Objcn)
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
            cmbConversion.DisplayMember = "AccountAmt"
            cmbConversion.ValueMember = "AccountId"
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            Objcn.Close()
        End Try
    End Sub
    Private Sub frmOpInterIssue_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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

            With dgvIssue
                If e.KeyCode = Keys.F12 Then
                    .Rows.Remove(.CurrentRow)
                End If
            End With

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class