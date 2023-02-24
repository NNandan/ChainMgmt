Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Imports JMS.Common_Cls
Public Class frmOpLotTransfer
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
    Private Sub frmOpLotFail_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Clear_Form()
        Me.filltemName()
        Me.fillOperationType()
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
    Private Sub fillOperationType()

        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        parameters.Add(dbManager.CreateParameter("@ActionType", "FillOperation", DbType.String))

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
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Call Clear_Form()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Testing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
    Private Sub cmbOperation_Enter(sender As Object, e As EventArgs) Handles cmbOperation.Enter
        cmbOperation.ShowDropDown()
    End Sub
    Private Sub txtMainLotNo_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtMainLotNo.Validating
        Try
            If cmbItem.Text.Trim <> "" And txtTransferWt.Text.Trim <> "" And Val(txtTransferPr.Text.Trim) > 0 Then

                'ErrorProvider1.SetError(txtRequirePr, "")

                If dgvLotTransfer.Rows.Count > 0 AndAlso ChkDuplicate() = True Then
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
    Private Sub Clear_Form()
        Try
            '' For Header Field Start
            'txtBagNo.Tag = ""
            'txtBagNo.Clear()
            TransDt.Text = "__/__/____"
            TransDt.Value = DateTime.Now
            '' For Header Field End

            '' For Detail Field Start
            txtSrNo.Text = 1

            cmbItem.SelectedIndex = 0

            cmbOperation.SelectedIndex = 0

            txtTransferWt.Clear()
            txtTransferPr.Clear()

            txtFrLotNo.Clear()
            txtToLotNo.Clear()
            txtMainLotNo.Clear()

            dgvLotTransfer.RowCount = 0
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

            For Each row As GridViewRowInfo In dgvLotTransfer.Rows
                With Hparameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))

                    .Add(dbManager.CreateParameter("@LDate", row.Cells(1).Value, DbType.DateTime))
                    .Add(dbManager.CreateParameter("@ItemId", row.Cells(2).Value, DbType.Int16))
                    .Add(dbManager.CreateParameter("@LOperationId", row.Cells(4).Value, DbType.Int16))

                    .Add(dbManager.CreateParameter("@LTransferWt", row.Cells(6).Value, DbType.String))
                    .Add(dbManager.CreateParameter("@LIssuePr", row.Cells(7).Value, DbType.String))

                    .Add(dbManager.CreateParameter("@LFrLotNo", row.Cells(8).Value, DbType.String))
                    .Add(dbManager.CreateParameter("@LToLotNo", row.Cells(9).Value, DbType.String))
                    .Add(dbManager.CreateParameter("@MainLotNumber", row.Cells(10).Value, DbType.String))

                    .Add(dbManager.CreateParameter("@FrKarigarId", Val(UserId), DbType.Int16))
                    .Add(dbManager.CreateParameter("@ToKarigarId", Val(UserId), DbType.Int16))
                    .Add(dbManager.CreateParameter("@CreatedBy", UserName.Trim(), DbType.String))
                    .Add(dbManager.CreateParameter("@HIsOpening", 0, DbType.Boolean))
                End With

                dbManager.Insert("SP_LotTransfer_Save", CommandType.StoredProcedure, Hparameters.ToArray())
            Next
            MessageBox.Show("Data Saved !!!", Product_Name, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub frmOpLotTransfer_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                If MsgBox("Wish To Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Me.Close()
            ElseIf e.KeyCode = Keys.Tab Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            End If

            With dgvLotTransfer
                If e.KeyCode = Keys.F12 Then
                    .Rows.Remove(.CurrentRow)
                End If
            End With

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtTransferWt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTransferWt.KeyPress
        numdotkeypress(e, txtTransferWt, Me)
    End Sub
    Private Sub txtTransferPr_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTransferPr.KeyPress
        numdotkeypress(e, txtTransferPr, Me)
    End Sub
    Private Sub txtTransferWt_Leave(sender As Object, e As EventArgs) Handles txtTransferWt.Leave
        txtTransferWt.Text = Format(Val(txtTransferWt.Text), "0.00")
    End Sub
    Private Sub txtTransferPr_Leave(sender As Object, e As EventArgs) Handles txtTransferPr.Leave
        txtTransferPr.Text = Format(Val(txtTransferPr.Text), "0.00")
    End Sub
    Private Sub txtFrLotNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFrLotNo.KeyPress
        '' If certain characters then allow
        If e.KeyChar = vbBack Then Exit Sub
        '' Do not allow the comma character (or any other invalid characters)
        If e.KeyChar = "." Or IsNumeric(e.KeyChar) = False Then e.KeyChar = Chr(0)
    End Sub
    Private Sub txtToLotNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtToLotNo.KeyPress
        '' If certain characters then allow
        If e.KeyChar = vbBack Then Exit Sub
        '' Do not allow the comma character (or any other invalid characters)
        If e.KeyChar = "." Or IsNumeric(e.KeyChar) = False Then e.KeyChar = Chr(0)
    End Sub
    Private Sub txtMainLotNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMainLotNo.KeyPress
        '' If certain characters then allow
        If e.KeyChar = vbBack Then Exit Sub
        '' Do not allow the comma character (or any other invalid characters)
        If e.KeyChar = "." Or IsNumeric(e.KeyChar) = False Then e.KeyChar = Chr(0)
    End Sub
    Private Function ChkDuplicate() As Boolean
        Dim exists As Boolean = False

        If GridDoubleClick = False Then
            For Each itm As GridViewRowInfo In dgvLotTransfer.Rows
                If itm.Cells(4).Value = CStr(cmbItem.Text.Trim) Then
                    exists = True
                End If
            Next
        End If

        Return exists
    End Function
    Sub fillGrid()
        If GridDoubleClick = False Then
            dgvLotTransfer.Rows.Add(Val(txtSrNo.Text.Trim),
                                    (TransDt.Text),
                                    cmbItem.SelectedIndex,
                                    cmbItem.Text.Trim(),
                                    cmbOperation.SelectedIndex,
                                    cmbOperation.Text.Trim(),
                                    Format(Val(txtTransferWt.Text.Trim), "0.00"),
                                    Format(Val(txtTransferPr.Text.Trim), "0.00"),
                                    Convert.ToString(txtFrLotNo.Text.Trim),
                                    Convert.ToString(txtToLotNo.Text.Trim),
                                    Convert.ToString(txtMainLotNo.Text.Trim))
            GetSrNo(dgvLotTransfer)
        Else
            dgvLotTransfer.Rows(TempRow).Cells(0).Value = txtSrNo.Text.Trim
            dgvLotTransfer.Rows(TempRow).Cells(1).Value = TransDt.Text
            dgvLotTransfer.Rows(TempRow).Cells(3).Value = cmbItem.SelectedIndex
            dgvLotTransfer.Rows(TempRow).Cells(4).Value = cmbItem.Text.Trim
            dgvLotTransfer.Rows(TempRow).Cells(5).Value = Format(CDbl(txtTransferWt.Text.Trim), "0.00")
            dgvLotTransfer.Rows(TempRow).Cells(6).Value = Format(CDbl(txtTransferWt.Text.Trim), "0.00")
            dgvLotTransfer.Rows(TempRow).Cells(7).Value = txtToLotNo.Text.Trim
            dgvLotTransfer.Rows(TempRow).Cells(8).Value = txtFrLotNo.Text.Trim
            dgvLotTransfer.Rows(TempRow).Cells(9).Value = txtMainLotNo.Text.Trim
            GridDoubleClick = False
        End If

        dgvLotTransfer.TableElement.ScrollToRow(dgvLotTransfer.Rows.Last)

        txtSrNo.Text = dgvLotTransfer.RowCount + 1
        TransDt.Clear()
        cmbItem.SelectedIndex = 0
        cmbOperation.SelectedIndex = 0

        txtTransferWt.Clear()
        txtTransferPr.Clear()

        txtToLotNo.Clear()
        txtFrLotNo.Clear()
        txtMainLotNo.Clear()
    End Sub
    Sub GetSrNo(ByRef grid As Telerik.WinControls.UI.RadGridView)
        Try
            For Each rowInfo As GridViewRowInfo In dgvLotTransfer.Rows
                rowInfo.Cells(0).Value = rowInfo.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class