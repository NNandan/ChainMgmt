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

    Dim dbManager As New SqlHelper(ConfigurationManager.ConnectionStrings("ConString").ToString())
    Dim Objcn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("ConString").ToString())
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
    Private Sub frmOpeningStock_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Clear_Form()
        Me.filltemName()
    End Sub
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
    Private Sub txtIssueWt_TextChanged(sender As Object, e As EventArgs) Handles txtIssueWt.TextChanged
        Try
            txtFineWt.Text = Format((Val(txtIssueWt.Text) * Val(txtIssuePr.Text)) / 100, "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtIssuePr_TextChanged(sender As Object, e As EventArgs) Handles txtIssuePr.TextChanged
        Try
            txtFineWt.Text = Format((Val(txtIssueWt.Text) * Val(txtIssuePr.Text)) / 100, "0.000")
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

            txtIssueWt.Clear()
            txtIssuePr.Clear()
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
            If txtVocucherNo.Text.Trim = "" Then
                Dim Sql As String
                Dim Colwidth As String = ""
                Colwidth = "75|200|50|"
                Sql = "SELECT     [Bank Name], BankAcc_ID AS [bank Account ID], Acc_No AS [Account No], Acc_Balance AS [Balance Amount]  FROM Get_Bank_Account_Master_Vw where Br_Code = " & txtVocucherNo.Text & ""
                Call ShowSearchengine(TextBox1, Sql, 1, "Account Name", Colwidth, , 0)
            End If

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
                                    Val(cmbItem.SelectedValue),
                                    cmbItem.Text.Trim(),
                                    Format(Val(txtIssueWt.Text.Trim), "0.00"),
                                    Format(Val(txtIssuePr.Text.Trim), "0.00"),
                                    Format(Val(txtFineWt.Text.Trim), "0.000"),
                                    CStr(txtNarration.Text.Trim))
            GetSrNo(dgvStockIssue)
        Else
            dgvStockIssue.Rows(TempRow).Cells(0).Value = txtSrNo.Text.Trim
            dgvStockIssue.Rows(TempRow).Cells(1).Value = cmbItem.SelectedIndex
            dgvStockIssue.Rows(TempRow).Cells(2).Value = cmbItem.Text.Trim
            dgvStockIssue.Rows(TempRow).Cells(3).Value = Format(CDbl(txtIssueWt.Text.Trim), "0.00")
            dgvStockIssue.Rows(TempRow).Cells(4).Value = Format(CDbl(txtIssuePr.Text.Trim), "0.00")
            dgvStockIssue.Rows(TempRow).Cells(5).Value = Format(CDbl(txtFineWt.Text.Trim), "0.00")
            dgvStockIssue.Rows(TempRow).Cells(6).Value = CStr(txtNarration.Text.Trim)
        End If

        dgvStockIssue.TableElement.ScrollToRow(dgvStockIssue.Rows.Last)

        txtSrNo.Text = dgvStockIssue.RowCount + 1
        cmbItem.SelectedIndex = 0
        txtIssueWt.Clear()
        txtIssuePr.Clear()
        txtNarration.Clear()
        txtNarration.Clear()
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
    Private Sub SaveData()
        Dim alParaval As New ArrayList

        Dim GridSrNo As String = Nothing
        Dim ItemId As String = Nothing
        Dim IssueWt As String = Nothing
        Dim IssuePr As String = Nothing
        Dim FineWt As String = Nothing
        Dim Narration As String = Nothing

        Dim IRowCount As Integer = 0
        Dim iValue As Integer = 0

        ''For Master
        alParaval.Add(TransDt.Value.ToString())
        alParaval.Add(1)
        alParaval.Add(4)
        alParaval.Add(txtVocucherNo.Text.Trim)
        alParaval.Add(100)
        alParaval.Add(100)

        ''For Details
        For Each row As GridViewRowInfo In dgvStockIssue.Rows
            If row.Cells(0).Value <> Nothing Then
                If GridSrNo = "" Then
                    GridSrNo = Val(row.Cells(0).Value)
                    ItemId = Val(row.Cells(1).Value)
                    IssueWt = Val(row.Cells(3).Value)
                    IssuePr = Val(row.Cells(4).Value)
                    FineWt = Val(row.Cells(5).Value)
                    Narration = Convert.ToString(row.Cells(6).Value)
                Else
                    GridSrNo = GridSrNo & "|" & Val(row.Cells(0).Value)
                    ItemId = ItemId & "|" & Val(row.Cells(1).Value)
                    IssueWt = IssueWt & "|" & Val(row.Cells(3).Value)
                    IssuePr = IssuePr & "|" & Val(row.Cells(4).Value)
                    FineWt = FineWt & "|" & Val(row.Cells(5).Value)
                    Narration = Narration & "|" & Convert.ToString(row.Cells(6).Value)
                End If
            End If
            IRowCount += 1
        Next

        alParaval.Add(ItemId)
        alParaval.Add(IssueWt)
        alParaval.Add(IssuePr)
        alParaval.Add(FineWt)
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
                .Add(dbManager.CreateParameter("@HToKarigarId", alParaval.Item(iValue), DbType.Int16))
                iValue += 1

                .Add(dbManager.CreateParameter("@HCreatedBy", UserName.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@GridCount", IRowCount, DbType.Int16))
                .Add(dbManager.CreateParameter("@HIsOpening", 0, DbType.Boolean))

                .Add(dbManager.CreateParameter("@DItemId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DIssueWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DIssuePr", alParaval.Item(iValue), DbType.String))
                iValue += 1

                .Add(dbManager.CreateParameter("@DFineWt", alParaval.Item(iValue), DbType.String))
                iValue += 1

                .Add(dbManager.CreateParameter("@DNarration", alParaval.Item(iValue), DbType.String))
                iValue += 1
            End With

            dbManager.Insert("SP_StockIssue_Save", CommandType.StoredProcedure, Hparameters.ToArray())

            MessageBox.Show("Data Saved !!!", Product_Name, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        Try
            If e.KeyCode = Keys.F1 Then Call Btn_Find_Click(Nothing, Nothing)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtIssueWt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIssueWt.KeyPress
        numdotkeypress(e, txtIssueWt, Me)
    End Sub
    Private Sub txtIssuePr_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIssuePr.KeyPress
        numdotkeypress(e, txtIssuePr, Me)
    End Sub
    Private Sub txtNarration_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtNarration.Validating
        Try
            If cmbItem.Text.Trim <> "" And txtIssueWt.Text.Trim <> "" And Val(txtIssueWt.Text.Trim) > 0 And Val(txtIssuePr.Text.Trim) > 0 Then

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
    Private Sub frmOpStockIssue_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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