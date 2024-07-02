Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Imports JMS.Common_Cls
Public Class frmOpTransaction
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
    Private Sub frmOpTransaction_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Clear_Form()
        Me.filltemName()
        Me.fillOperationType()
    End Sub
    Private Sub txtVacuumWt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtVacuumWt.Validating
        Try
            If cmbItem.Text.Trim <> "" And txtIssueWt.Text.Trim <> "" And Val(txtIssueWt.Text.Trim) > 0 And Val(txtIssuePr.Text.Trim) > 0 Then

                'ErrorProvider1.SetError(txtRequirePr, "")

                If dgvTransactions.Rows.Count > 0 AndAlso ChkDuplicate() = True Then
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
    Sub fillGrid()
        If GridDoubleClick = False Then
            dgvTransactions.Rows.Add(Val(txtSrNo.Text.Trim),
                                    (TransDt.Text),
                                    CStr(txtBagNo.Text.Trim),
                                    cmbItem.SelectedIndex,
                                    cmbItem.Text.Trim(),
                                    cmbOperation.SelectedIndex,
                                    cmbOperation.Text.Trim(),
                                    Format(Val(txtIssueWt.Text.Trim), "0.00"),
                                    Format(Val(txtIssuePr.Text.Trim), "0.00"),
                                    Format(Val(txtReceiveWt.Text.Trim), "0.00"),
                                    Format(Val(txtReceivePr.Text.Trim), "0.00"),
                                    Format(Val(txtBhukaWt.Text.Trim), "0.00"),
                                    Format(Val(txtSampleWt.Text.Trim), "0.00"),
                                    Format(Val(txtVacuumWt.Text.Trim), "0.00"))
            GetSrNo(dgvTransactions)
        Else
            dgvTransactions.Rows(TempRow).Cells(0).Value = txtSrNo.Text.Trim
            dgvTransactions.Rows(TempRow).Cells(1).Value = TransDt.Text
            dgvTransactions.Rows(TempRow).Cells(2).Value = txtBagNo.Text
            dgvTransactions.Rows(TempRow).Cells(3).Value = cmbItem.SelectedIndex
            dgvTransactions.Rows(TempRow).Cells(4).Value = cmbItem.Text.Trim
            dgvTransactions.Rows(TempRow).Cells(5).Value = Format(CDbl(txtIssueWt.Text.Trim), "0.00")
            dgvTransactions.Rows(TempRow).Cells(6).Value = Format(CDbl(txtIssuePr.Text.Trim), "0.00")
            dgvTransactions.Rows(TempRow).Cells(7).Value = Format(CDbl(txtReceiveWt.Text.Trim), "0.00")
            dgvTransactions.Rows(TempRow).Cells(8).Value = Format(CDbl(txtBhukaWt.Text.Trim), "0.00")
            GridDoubleClick = False
        End If

        dgvTransactions.TableElement.ScrollToRow(dgvTransactions.Rows.Last)

        txtSrNo.Text = dgvTransactions.RowCount + 1
        TransDt.Clear()
        txtBagNo.Clear()
        cmbItem.SelectedIndex = 0
        cmbOperation.SelectedIndex = 0
        txtIssueWt.Clear()
        txtIssuePr.Clear()
        txtReceiveWt.Clear()
        txtReceivePr.Clear()

        txtBhukaWt.Clear()
        txtSampleWt.Clear()
        txtVacuumWt.Clear()
    End Sub
    Private Sub fillOperationType()

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
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
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
            For Each itm As GridViewRowInfo In dgvTransactions.Rows
                If itm.Cells(4).Value = CStr(cmbItem.Text.Trim) Then
                    exists = True
                End If
            Next
        End If

        Return exists

    End Function
    Private Sub Clear_Form()
        Try
            '' For Header Field Start
            txtBagNo.Tag = ""
            txtBagNo.Clear()
            TransDt.Text = "__/__/____"
            TransDt.Value = DateTime.Now
            '' For Header Field End

            '' For Detail Field Start
            txtSrNo.Text = 1

            cmbItem.Text = ""
            cmbItem.Enabled = True

            txtIssueWt.Clear()
            txtIssuePr.Clear()
            txtReceiveWt.Clear()
            txtBhukaWt.Clear()

            dgvTransactions.RowCount = 0
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
            MessageBox.Show(ex.Message, "Testing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub cmbItem_Enter(sender As Object, e As EventArgs) Handles cmbItem.Enter
        cmbItem.ShowDropDown()
    End Sub
    Private Sub cmbOperation_Enter(sender As Object, e As EventArgs) Handles cmbOperation.Enter
        cmbOperation.ShowDropDown()
    End Sub
    Private Sub txtIssueWt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIssueWt.KeyPress
        numdotkeypress(e, txtIssueWt, Me)
    End Sub
    Private Sub txtIssuePr_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIssuePr.KeyPress
        numdotkeypress(e, txtIssuePr, Me)
    End Sub
    Private Sub txtReceiveWt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtReceiveWt.KeyPress
        numdotkeypress(e, txtReceiveWt, Me)
    End Sub
    Private Sub txtReceivePr_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtReceivePr.KeyPress
        numdotkeypress(e, txtReceivePr, Me)
    End Sub
    Private Sub txtBhukaWt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBhukaWt.KeyPress
        numdotkeypress(e, txtBhukaWt, Me)
    End Sub
    Private Sub txtSampleWt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSampleWt.KeyPress
        numdotkeypress(e, txtSampleWt, Me)
    End Sub
    Private Sub txtVacuumWt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtVacuumWt.KeyPress
        numdotkeypress(e, txtVacuumWt, Me)
    End Sub
    Private Sub txtIssueWt_Leave(sender As Object, e As EventArgs) Handles txtIssueWt.Leave
        txtIssueWt.Text = Format(Val(txtIssueWt.Text), "0.00")
    End Sub
    Private Sub txtIssuePr_Leave(sender As Object, e As EventArgs) Handles txtIssuePr.Leave
        txtIssuePr.Text = Format(Val(txtIssuePr.Text), "0.00")
    End Sub
    Private Sub txtReceiveWt_Leave(sender As Object, e As EventArgs) Handles txtReceiveWt.Leave
        txtReceiveWt.Text = Format(Val(txtReceiveWt.Text), "0.00")
    End Sub
    Private Sub txtReceivePr_Leave(sender As Object, e As EventArgs) Handles txtReceivePr.Leave
        txtReceivePr.Text = Format(Val(txtReceivePr.Text), "0.00")
    End Sub
    Private Sub txtBhukaWt_Leave(sender As Object, e As EventArgs) Handles txtBhukaWt.Leave
        txtBhukaWt.Text = Format(Val(txtBhukaWt.Text), "0.00")
    End Sub
    Private Sub txtSampleWt_Leave(sender As Object, e As EventArgs) Handles txtSampleWt.Leave
        txtSampleWt.Text = Format(Val(txtSampleWt.Text), "0.00")
    End Sub
    Private Sub txtVacuumWt_Leave(sender As Object, e As EventArgs) Handles txtVacuumWt.Leave
        txtVacuumWt.Text = Format(Val(txtVacuumWt.Text), "0.00")
    End Sub
    Sub GetSrNo(ByRef grid As Telerik.WinControls.UI.RadGridView)
        Try
            For Each rowInfo As GridViewRowInfo In dgvTransactions.Rows
                rowInfo.Cells(0).Value = rowInfo.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub frmOpTransaction_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                If MsgBox("Wish To Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Me.Close()
            ElseIf e.KeyCode = Keys.Tab Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            End If

            With dgvTransactions
                If e.KeyCode = Keys.F12 Then
                    .Rows.Remove(.CurrentRow)
                End If
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub SaveData()
        Try
            Dim Hparameters = New List(Of SqlParameter)()

            For Each row As GridViewRowInfo In dgvTransactions.Rows
                With Hparameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@TDate", row.Cells(1).Value, DbType.DateTime))
                    .Add(dbManager.CreateParameter("@TLotNo", Convert.ToString(row.Cells(2).Value), DbType.String))
                    .Add(dbManager.CreateParameter("@TItemId", Val(row.Cells(3).Value), DbType.Int16))
                    .Add(dbManager.CreateParameter("@TOperationId", Val(row.Cells(5).Value), DbType.Int16))

                    .Add(dbManager.CreateParameter("@TIssueWt", Convert.ToString(row.Cells(7).Value), DbType.String))
                    .Add(dbManager.CreateParameter("@TIssuePr", Convert.ToString(row.Cells(8).Value), DbType.String))

                    .Add(dbManager.CreateParameter("@TRecieveWt", Convert.ToString(row.Cells(9).Value), DbType.String))
                    .Add(dbManager.CreateParameter("@TRecievePr", Convert.ToString(row.Cells(10).Value), DbType.String))

                    .Add(dbManager.CreateParameter("@TBhukaWt", Val(row.Cells(11).Value), DbType.String))
                    .Add(dbManager.CreateParameter("@TSampleWt", Val(row.Cells(12).Value), DbType.String))
                    .Add(dbManager.CreateParameter("@TVaccumeWt", Val(row.Cells(13).Value), DbType.String))

                    .Add(dbManager.CreateParameter("@TfLabourId", Val(UserId), DbType.Int16))
                    .Add(dbManager.CreateParameter("@TtLabourId", Val(UserId), DbType.Int16))
                    .Add(dbManager.CreateParameter("@HIsOpening", 0, DbType.Boolean))
                End With

                dbManager.Insert("SP_Transaction_Save", CommandType.StoredProcedure, Hparameters.ToArray())
            Next

            MessageBox.Show("Data Saved !!!", Product_Name, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub

End Class