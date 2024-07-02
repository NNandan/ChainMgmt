Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Public Class frmILotTransfer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState

    Dim strSQL As String = Nothing

    Dim GridDoubleClick As Boolean
    Dim TempRow As Integer

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
    Private Sub frmLotTransfer_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Clear_Form()

        Me.fillfrLotNo()
        Me.fillLabour()

        dgvLotTransfer.AutoGenerateColumns = False
        dgvLotTransfer.DataSource = fetchAllRecords()
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim iOperationTypeId As Integer = 6

        If Not Validate_Fields() Then Exit Sub

        Dim trans As SqlTransaction = Nothing

        Try
            If Objcn.State = ConnectionState.Open Then Objcn.Close()
            Objcn.Open()
            trans = Objcn.BeginTransaction()

            Dim lparameters = New List(Of SqlParameter)()
            lparameters.Clear()

            Dim mparameters = New List(Of SqlParameter)()
            mparameters.Clear()

            Dim tparameters = New List(Of SqlParameter)()
            tparameters.Clear()

            If btnSave.Text = "&Save" Then
                ''For Lot Transfered Table Start
                With lparameters
                    .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
                    .Add(dbManager.CreateParameter("@LDate", TransDt.Value.ToString(), DbType.DateTime))
                    .Add(dbManager.CreateParameter("@ItemName", CStr(txtItemName.Text.Trim), DbType.String))
                    .Add(dbManager.CreateParameter("@LOperationId", Val(txtOperation.Tag), DbType.Int16))
                    .Add(dbManager.CreateParameter("@LFrLotNo", cmbFrLotNo.Text, DbType.String))

                    .Add(dbManager.CreateParameter("@LTransferWt", Format(CDec(txtTransferWt.Text), "0.00"), DbType.String))
                    .Add(dbManager.CreateParameter("@LIssuePr", Format(CDec(txtIssuePr.Text), "0.00"), DbType.String))

                    .Add(dbManager.CreateParameter("@TfLabourName", CStr(txtFrKarigar.Text.Trim), DbType.String))
                    .Add(dbManager.CreateParameter("@TtLabourName", CStr(cmbTLabour.Text.Trim), DbType.String))
                    .Add(dbManager.CreateParameter("@CreatedBy", UserName.Trim(), DbType.String))
                End With
                ''For Lot Transfered Table End

                ''For Transaction Table Start
                tparameters.Clear()
                With tparameters
                    .Add(dbManager.CreateParameter("@TDate", TransDt.Value.ToString(), DbType.DateTime))
                    .Add(dbManager.CreateParameter("@TLotNo", CStr(cmbFrLotNo.Text.Trim()), DbType.String))
                    .Add(dbManager.CreateParameter("@TItemId", txtItemName.Tag, DbType.Int16))
                    .Add(dbManager.CreateParameter("@TOperationTypeId", iOperationTypeId, DbType.Int16))

                    .Add(dbManager.CreateParameter("@TRecievePr", Convert.ToString(txtIssuePr.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@TRecieveWt", Convert.ToString(txtBalanceWt.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@TIssuePr", Convert.ToString(txtIssuePr.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@TIssueWt", Convert.ToString(txtTotalWt.Text), DbType.String))

                    .Add(dbManager.CreateParameter("@TfLabourName", CStr(txtFrKarigar.Text.Trim), DbType.String))
                    .Add(dbManager.CreateParameter("@TtLabourName", CStr(cmbTLabour.Text.Trim), DbType.String))
                End With
                ''For Transaction Table End
            End If

            dbManager.Insert("SP_LotTransfer_Save", CommandType.StoredProcedure, lparameters.ToArray())

            dbManager.Insert("SP_Transaction_Save", CommandType.StoredProcedure, tparameters.ToArray())

            trans.Commit()

            MessageBox.Show("Data Saved !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.Clear_Form()
        Catch ex As Exception
            MessageBox.Show("Error: - " & ex.Message)
        End Try

    End Sub
    Private Sub fillfrLotNo()

        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FetchLotNoForLotAddition", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            'Insert the Default Item to DataTable.
            Dim row As DataRow = dt.NewRow()
            row(0) = 0
            row(1) = "---Select---"
            dt.Rows.InsertAt(row, 0)

            'Assign DataTable as DataSource.
            cmbFrLotNo.DataSource = dt
            cmbFrLotNo.DisplayMember = "LotNo"
            cmbFrLotNo.ValueMember = "TransId"
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub txtTransfrWt_Validating(sender As Object, e As ComponentModel.CancelEventArgs)
        If Val(txtTransferWt.Text) > Val(txtTotalWt.Text) Then
            MessageBox.Show("Transfer Wt should not be Greater thane Total Wt")
            txtTransferWt.Focus()
            Exit Sub
        End If
    End Sub
    Private Sub txtTotalWt_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            txtTransferWt.Select()
        End If
    End Sub
    Private Sub txtTransfrWt_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            txtBalanceWt.Select()
        End If
    End Sub
    Private Sub txtIssuePr_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            txtTransNo.Select()
        End If
    End Sub
    Private Sub txtTransferNo_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            txtIssuePr.Select()
        End If
    End Sub
    Private Sub txtBalanceWt_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            btnSave.Select()
        End If
    End Sub
    Private Sub txtTotalWt_KeyPress(sender As Object, e As KeyPressEventArgs)
        numdotkeypress(e, txtTotalWt, Me)
    End Sub
    Private Sub txtIssuePr_KeyPress(sender As Object, e As KeyPressEventArgs)
        numdotkeypress(e, txtIssuePr, Me)
    End Sub
    Private Sub txtBalanceWt_KeyPress(sender As Object, e As KeyPressEventArgs)
        numdotkeypress(e, txtBalanceWt, Me)
    End Sub
    Private Sub getLastLotNoAmt()

        Dim strSQL As String = Nothing

        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        strSQL = Nothing
        strSQL = "SELECT * FROM udf_GetMaxLotTransNo('" & cmbFrLotNo.Text.Trim() & "') ORDER BY MaxTransId"

        With parameters
            .Add(dbManager.CreateParameter("@TLotNo", cmbFrLotNo.Text.Trim(), DbType.String))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader(strSQL, CommandType.Text, Objcn, parameters.ToArray())

        Try
            If dr.Read = False Then
                Exit Sub
            Else
                txtTransNo.Text = dr("MaxTransId").ToString()
                txtOperation.Tag = dr("OperationId").ToString()
                txtOperation.Text = dr("OperationName").ToString()
                txtItemName.Tag = dr("ItemId").ToString()
                txtItemName.Text = dr("ItemName").ToString()
                txtTotalWt.Text = Format(Val(dr("ReceiveWt")), "0.00")
                txtIssuePr.Text = Format(Val(dr("ReceivePr")), "0.00")
                txtFrKarigar.Tag = dr("ToLabourId").ToString()
                txtFrKarigar.Text = dr("toKarigarName").ToString()
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            Objcn.Close()
        End Try
    End Sub
    Private Sub txtTransfrWt_Leave(sender As Object, e As EventArgs) Handles txtTransferWt.Leave
        If Not Val(txtTransferWt.Text) > Val(txtTotalWt.Text) Then
            txtBalanceWt.Text = Format(Val(txtTotalWt.Text) - Val(txtTransferWt.Text), "0.00")
        End If

        txtTransferWt.Text = Format(Val(txtTransferWt.Text), "0.00")
    End Sub
    Private Function fetchAllRecords() As DataTable

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_LotTransfer_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub dgvLotTransfer_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        Try
            If e.RowIndex = -1 Then Exit Sub

            If e.RowIndex >= 0 And dgvLotTransfer.Rows(e.RowIndex).Cells(0).Value <> Nothing Then
                GridDoubleClick = True
                txtTransNo.Text = dgvLotTransfer.Rows(e.RowIndex).Cells(0).Value.ToString()
                txtItemName.Text = dgvLotTransfer.Rows(e.RowIndex).Cells(1).Value.ToString()
                'Rmccmb.Text = CStr(dgvLotTransfer.Rows(e.RowIndex).Cells(2).Value)
                txtItemName.Tag = CInt(dgvLotTransfer.Rows(e.RowIndex).Cells(3).Value)
                txtItemName.Text = dgvLotTransfer.Rows(e.RowIndex).Cells(4).Value.ToString()
                txtTransferWt.Tag = dgvLotTransfer.Rows(e.RowIndex).Cells(5).Value.ToString()
                'txtIssueWt.Text = dgvLotTransfer.Rows(e.RowIndex).Cells(5).Value.ToString()
                'txtIssuePr.Text = dgvLotTransfer.Rows(e.RowIndex).Cells(6).Value.ToString()
                'txtFineWt.Text = dgvLotTransfer.Rows(e.RowIndex).Cells(7).Value.ToString()
                TempRow = e.RowIndex
            End If

            'TransDt
            'cmbFrLotNo
            'txtOperation
            'txtTotalWt
            'txtTransferWt
            'txtBalanceWt
            'txtItemName
            'txtIssuePr
            'txtFrKarigar
            'cmbTLabour

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    'Private Function fetchAllRecords(ByVal LotTransferId As Integer) As DataTable
    '    Dim dtData As DataTable = New DataTable()

    '    Try
    '        Dim parameters = New List(Of SqlParameter)()
    '        parameters.Clear()

    '        With parameters
    '            .Add(dbManager.CreateParameter("@LId", LotTransferId, DbType.String))
    '            .Add(dbManager.CreateParameter("@ActionType", "FetchRecord", DbType.String))
    '        End With

    '        dtData = dbManager.GetDataTable("SP_LotTransfer_Select", CommandType.StoredProcedure, parameters.ToArray())

    '    Catch ex As Exception
    '        MessageBox.Show("Error:- " & ex.Message)
    '    End Try

    '    Return dtData
    'End Function
    Private Sub txtTransfrWt_TextChanged(sender As Object, e As EventArgs) Handles txtTransferWt.TextChanged
        txtBalanceWt.Text = Format(Val(txtTotalWt.Text) - Val(txtTransferWt.Text), "0.00")
    End Sub
    Private Sub txtTransferWt_KeyPress(sender As Object, e As KeyPressEventArgs)
        numdotkeypress(e, txtTransferWt, Me)
    End Sub
    Private Sub fillLabour()

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
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
            cmbTLabour.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            Objcn.Close()
            ''cmbTLabour.Enabled = False
        End Try
    End Sub
    Private Sub frmLotTransfer_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                If MsgBox("Wish To Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Me.Close()
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
    Private Sub cmbFrLotNo_SelectedIndexChanged(sender As Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles cmbFrLotNo.SelectedIndexChanged
        If cmbFrLotNo.Text.Trim <> "" Then

            txtOperation.Clear()
            txtTotalWt.Clear()
            txtTransferWt.Clear()
            txtBalanceWt.Clear()
            txtTransNo.Clear()
            txtItemName.Clear()
            txtIssuePr.Clear()
            txtFrKarigar.Clear()

            Me.getLastLotNoAmt()
        End If
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Call Clear_Form()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub txtTransferWt_KeyPress_1(sender As Object, e As KeyPressEventArgs) Handles txtTransferWt.KeyPress
        numdotkeypress(e, txtTransferWt, Me)
    End Sub
    Private Sub txtTransferWt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtTransferWt.Validating
        Try
            If Val(txtTransferWt.Text.Trim() > Val(txtTotalWt.Text.Trim)) Then
                e.Cancel = True
                MsgBox("Cannot be more than Total Wt.", MsgBoxStyle.Critical)
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub cmbTLabour_Enter(sender As Object, e As EventArgs) Handles cmbTLabour.Enter
        cmbTLabour.ShowDropDown()
    End Sub
    Private Sub Clear_Form()
        Try
            TransDt.Value = DateTime.Now()

            txtTransNo.Clear()

            cmbFrLotNo.SelectedIndex = -1

            txtOperation.Tag = ""
            txtOperation.Clear()

            txtItemName.Tag = ""
            txtItemName.Clear()

            txtTotalWt.Clear()
            txtIssuePr.Clear()
            txtTransferWt.Clear()
            txtBalanceWt.Clear()
            txtIssuePr.Clear()

            txtFrKarigar.Tag = ""
            txtFrKarigar.Clear()

            cmbTLabour.SelectedIndex = 0

            dgvLotTransfer.AutoGenerateColumns = False
            dgvLotTransfer.DataSource = fetchAllRecords()

            Fr_Mode = FormState.AStateMode

            TransDt.Focus()
            TransDt.Value = DateTime.Now

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Function Validate_Fields() As Boolean
        Try
            If String.IsNullOrWhiteSpace(cmbFrLotNo.Text) Then
                MessageBox.Show("Select Lot No !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbFrLotNo.Focus()
                Return False
            ElseIf String.IsNullOrWhiteSpace(txtTransferWt.Text.Trim) Then
                MessageBox.Show("Enter Wt. !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtTransferWt.Focus()
                Return False
            ElseIf txtFrKarigar.Text.Equals(cmbTLabour.Text.Trim()) Then
                MessageBox.Show("Cannot have the same Karigar Name")
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
End Class