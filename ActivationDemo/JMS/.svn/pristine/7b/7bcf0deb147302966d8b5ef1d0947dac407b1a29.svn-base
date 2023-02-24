Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Imports JMS.Common_Cls
Public Class frmOpStockBags
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
    Private Sub frmOpStockBags_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Clear_Form()
        Me.filltemName()
    End Sub
    Private Sub txtReportPr_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Try
            If cmbItem.Text.Trim <> "" And txtIssueWt.Text.Trim <> "" And Val(txtIssueWt.Text.Trim) > 0 And Val(txtIssuePr.Text.Trim) > 0 Then

                'ErrorProvider1.SetError(txtRequirePr, "")

                If dgvUsedBags.Rows.Count > 0 AndAlso ChkDuplicate() = True Then
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
            dgvUsedBags.Rows.Add(Val(txtSrNo.Text.Trim),
                                    (TransDt.Text),
                                    CStr(txtBagNo.Text.Trim),
                                    cmbItem.SelectedIndex,
                                    cmbItem.Text.Trim(),
                                    Format(Val(txtIssueWt.Text.Trim), "0.00"),
                                    Format(Val(txtIssuePr.Text.Trim), "0.00"),
                                    Format(Val(txtReceiveWt.Text.Trim), "0.00"))
            GetSrNo(dgvUsedBags)
        Else
            dgvUsedBags.Rows(TempRow).Cells(0).Value = txtSrNo.Text.Trim
            dgvUsedBags.Rows(TempRow).Cells(1).Value = TransDt.Text
            dgvUsedBags.Rows(TempRow).Cells(2).Value = txtBagNo.Text
            dgvUsedBags.Rows(TempRow).Cells(3).Value = cmbItem.SelectedIndex
            dgvUsedBags.Rows(TempRow).Cells(4).Value = cmbItem.Text.Trim
            dgvUsedBags.Rows(TempRow).Cells(5).Value = Format(CDbl(txtIssueWt.Text.Trim), "0.00")
            dgvUsedBags.Rows(TempRow).Cells(6).Value = Format(CDbl(txtIssuePr.Text.Trim), "0.00")
            dgvUsedBags.Rows(TempRow).Cells(7).Value = Format(CDbl(txtReceiveWt.Text.Trim), "0.00")
            GridDoubleClick = False
        End If

        dgvUsedBags.TableElement.ScrollToRow(dgvUsedBags.Rows.Last)

        txtSrNo.Text = dgvUsedBags.RowCount + 1
        TransDt.Clear()
        txtBagNo.Clear()
        cmbItem.SelectedIndex = 0
        txtIssueWt.Clear()
        txtIssuePr.Clear()
        txtReceiveWt.Clear()
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
    Private Sub cmbItem_Enter(sender As Object, e As EventArgs) Handles cmbItem.Enter
        cmbItem.ShowDropDown()
    End Sub
    Private Sub frmOpStockBags_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                If MsgBox("Wish To Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Me.Close()
            ElseIf e.KeyCode = Keys.Tab Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            End If

            With dgvUsedBags
                If e.KeyCode = Keys.F12 Then
                    .Rows.Remove(.CurrentRow)
                End If
            End With

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub dgvUsedBags_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles dgvUsedBags.CellDoubleClick
        Try
            If e.RowIndex = -1 Then Exit Sub

            If e.RowIndex >= 0 And dgvUsedBags.Rows(e.RowIndex).Cells(0).Value <> Nothing Then
                GridDoubleClick = True
                txtSrNo.Text = dgvUsedBags.Rows(e.RowIndex).Cells(0).Value.ToString()
                TransDt.Text = dgvUsedBags.Rows(e.RowIndex).Cells(1).Value.ToString()
                txtBagNo.Text = CStr(dgvUsedBags.Rows(e.RowIndex).Cells(2).Value)
                cmbItem.SelectedIndex = CInt(dgvUsedBags.Rows(e.RowIndex).Cells(3).Value)
                txtIssueWt.Text = dgvUsedBags.Rows(e.RowIndex).Cells(5).Value.ToString()
                txtIssuePr.Text = dgvUsedBags.Rows(e.RowIndex).Cells(5).Value.ToString()
                txtReceiveWt.Text = dgvUsedBags.Rows(e.RowIndex).Cells(6).Value.ToString()
                TempRow = e.RowIndex
                cmbItem.Focus()
            End If

        Catch ex As Exception
            Throw ex
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
    Sub GetSrNo(ByRef grid As Telerik.WinControls.UI.RadGridView)
        Try
            For Each rowInfo As GridViewRowInfo In dgvUsedBags.Rows
                rowInfo.Cells(0).Value = rowInfo.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Call Clear_Form()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Testing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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

    Private Sub txtIssueWt_Leave(sender As Object, e As EventArgs) Handles txtIssueWt.Leave
        txtIssueWt.Text = Format(Val(txtIssueWt.Text), "0.00")
    End Sub

    Private Sub txtIssuePr_Leave(sender As Object, e As EventArgs) Handles txtIssuePr.Leave
        txtIssuePr.Text = Format(Val(txtIssuePr.Text), "0.00")
    End Sub

    Private Sub txtReceiveWt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtReceiveWt.Validating
        Try
            If cmbItem.Text.Trim <> "" And txtIssueWt.Text.Trim <> "" And Val(txtIssueWt.Text.Trim) > 0 And Val(txtIssuePr.Text.Trim) > 0 Then

                'ErrorProvider1.SetError(txtRequirePr, "")

                If dgvUsedBags.Rows.Count > 0 AndAlso ChkDuplicate() = True Then
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

    Private Function ChkDuplicate() As Boolean
        Dim exists As Boolean = False

        If GridDoubleClick = False Then
            For Each itm As GridViewRowInfo In dgvUsedBags.Rows
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

            dgvUsedBags.RowCount = 0
            '' For Detail Field End

            GridDoubleClick = False

            Fr_Mode = FormState.AStateMode

            TransDt.Focus()
            TransDt.Select()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Testing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub SaveData()
        Try
            Dim Hparameters = New List(Of SqlParameter)()

            For Each row As GridViewRowInfo In dgvUsedBags.Rows
                With Hparameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))

                    .Add(dbManager.CreateParameter("@UBagDt", row.Cells(1).Value, DbType.DateTime))
                    .Add(dbManager.CreateParameter("@UBagSrNo", row.Cells(2).Value, DbType.String))
                    .Add(dbManager.CreateParameter("@UItemId", row.Cells(3).Value, DbType.String))
                    .Add(dbManager.CreateParameter("@UIssueWt", row.Cells(5).Value, DbType.String))
                    .Add(dbManager.CreateParameter("@UIssuePr", row.Cells(6).Value, DbType.String))
                    .Add(dbManager.CreateParameter("@URecieveWt", row.Cells(7).Value, DbType.String))
                    .Add(dbManager.CreateParameter("@UReportPr", row.Cells(8).Value, DbType.String))
                    .Add(dbManager.CreateParameter("@UCreatedBy", UserName.Trim(), DbType.String))
                    .Add(dbManager.CreateParameter("@HIsOpening", 0, DbType.Boolean))
                End With

                dbManager.Insert("SP_UsedBags_Save", CommandType.StoredProcedure, Hparameters.ToArray())
            Next

            MessageBox.Show("Data Saved !!!", Product_Name, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

    End Sub
End Class