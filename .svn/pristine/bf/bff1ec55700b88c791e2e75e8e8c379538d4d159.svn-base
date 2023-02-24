Imports System.ComponentModel
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Globalization
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmLotNo
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState

    Dim GridDoubleClick As Boolean
    Dim strSQL As String = Nothing

    Dim dbManager As New SqlHelper(ConfigurationManager.ConnectionStrings("ConString").ToString())
    Dim Objcn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("ConString").ToString())
    Private Objerr As New ErrorProvider()
    Private Property Fr_Mode() As FormState
        Get
            Return mFr_State
        End Get
        Set(ByVal value As FormState)
            mFr_State = value
            Select Case mFr_State
                Case FormState.AStateMode
                    'Me.Lbl_Tran_Mode.Text = "NEW MODE"
                    Me.btnSave.Enabled = True
                    Me.btnSave.Text = "&Save"
                    Me.btnCancel.Enabled = True
                Case FormState.EStateMode
                    'Me.Lbl_Tran_Mode.Text = "EDIT MODE"
                    Me.btnSave.Text = "&Update"
            End Select
        End Set
    End Property
    Private Sub frmLotNo_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.fillLotNo()
        Me.fillLabour()

        Me.setupListView()
        Me.bindListView()

        Me.Clear_Form()

        txtFrKarigar.Tag = CInt(UserId)
        txtFrKarigar.Text = Convert.ToString(KarigarName.Trim)

        txtLotNo.Visible = False
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
        Finally
            Me.bindListView()
        End Try

    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs)

        If Not String.IsNullOrEmpty(txtTransNo.Text) Then

            If MsgBox("Are you sure to Delete Lot  '" & txtLotNo.Text.Trim() & "'", vbYesNo + vbQuestion, "Confirm Delete") = vbNo Then
                Exit Sub
            End If

            Try

                Dim parameters = New List(Of SqlParameter)()
                parameters.Clear()

                With parameters
                    .Add(dbManager.CreateParameter("@TId", Val(txtTransNo.Text), DbType.Int16))
                End With

                dbManager.Delete("SP_Transaction_Delete", CommandType.StoredProcedure, parameters.ToArray())

                MessageBox.Show("Data Deleted !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            End Try
        Else
            MessageBox.Show("Please Select A Record !!!")
        End If
    End Sub
    Private Sub setupListView()
        With lstLotNo
            .View = View.Details
            .LabelEdit = False
            .Items.Clear()
            .AllowColumnReorder = True
            .FullRowSelect = True
            .GridLines = True
            .Sorting = SortOrder.Ascending
            .Columns.Add("Tran. No", 60, HorizontalAlignment.Left)
            .Columns.Add("Tran. Dt", 70, HorizontalAlignment.Left)
            .Columns.Add("Lot Number", 80, HorizontalAlignment.Left)
            .Columns.Add("Item Name", 110, HorizontalAlignment.Left)
            .Columns.Add("Operatin Name", 95, HorizontalAlignment.Left)
            .Columns.Add("Issue %", 65, HorizontalAlignment.Right)
            .Columns.Add("Issue Wt.", 65, HorizontalAlignment.Right)
            .Columns.Add("Rec. %", 65, HorizontalAlignment.Right)
            .Columns.Add("Rec. Wt.", 65, HorizontalAlignment.Right)
            .Columns.Add("Fr Karigar", 135, HorizontalAlignment.Left)
        End With
    End Sub
    Private Sub bindListView()
        Dim dtable As DataTable = fetchAllRecords()

        lstLotNo.Items.Clear()

        For i As Integer = 0 To dtable.Rows.Count - 1
            Dim drow As DataRow = dtable.Rows(i)
            If drow.RowState <> DataRowState.Deleted Then
                Dim lvi As ListViewItem = New ListViewItem(drow("TransactionId").ToString())
                lvi.SubItems.Add(drow("TransactionDt").ToString())
                lvi.SubItems.Add(drow("LotNo").ToString())
                lvi.SubItems.Add(drow("ItemName").ToString())
                lvi.SubItems.Add(drow("OperationName").ToString())
                lvi.SubItems.Add(drow("IssuePr").ToString())
                lvi.SubItems.Add(drow("IssueWt").ToString())
                lvi.SubItems.Add(drow("ReceivePr").ToString())
                lvi.SubItems.Add(drow("ReceiveWt").ToString())
                lvi.SubItems.Add(drow("FrLabour").ToString())
                lstLotNo.Items.Add(lvi)
            End If
        Next
    End Sub
    Private Sub fillLotNo()

        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FetchLotNo", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_Melting_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            'Insert the Default Item to DataTable.
            Dim row As DataRow = dt.NewRow()
            row(0) = 0
            row(1) = "---Select---"
            dt.Rows.InsertAt(row, 0)

            'Assign DataTable as DataSource.
            cmbLotNo.DataSource = dt
            cmbLotNo.DisplayMember = "LotNo"
            cmbLotNo.ValueMember = "MeltingId"

            cmbLotNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbLotNo.AutoCompleteDataSource = AutoCompleteSource.ListItems
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
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Function FetchAllRecords(ByVal transId As Integer) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@TId", CInt(transId), DbType.Int16))
                .Add(dbManager.CreateParameter("@ActionType", "FetchRecord", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
    Private Sub cmbLotNo_SelectedIndexChanged(sender As Object, e As EventArgs)

        If cmbLotNo.SelectedIndex > 0 Then

            Dim connection As SqlConnection = Nothing

            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchRecordByLotNo", DbType.String))
                .Add(dbManager.CreateParameter("@MLotNo", cmbLotNo.Text.Trim(), DbType.String))
            End With

            Dim dr As SqlDataReader = dbManager.GetDataReader("SP_Melting_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

            Try
                If dr.Read = False Then
                    Exit Sub
                Else
                    txtOperation.Tag = 2
                    txtOperation.Text = "Receive Melting"
                    txtOperation.Enabled = False
                    txtItemName.Tag = dr.Item("MeltingId").ToString
                    txtItemName.Text = dr.Item("ItemName").ToString
                    txtIssuePr.Text = dr.Item("RequirePr").ToString
                    txtIssueWt.Text = dr.Item("GrossWt").ToString
                    txtReceivePr.Text = dr.Item("RequirePr").ToString
                    txtFrKarigar.Tag = dr.Item("ToKarigarId").ToString
                    txtFrKarigar.Text = dr.Item("ToKarigar").ToString
                    cmbTLabour.Enabled = True
                End If
            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally
                dr.Close()
                Objcn.Close()
            End Try
        End If
    End Sub
    Private Sub fillLabour()

        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            parameters.Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_LabourMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim Odt As DataTable = New DataTable()

        Odt.Load(dr)

        Dim Cdt As DataTable = Odt.Copy()

        Try
            ''Insert the Default Item to DataTable.
            Dim frow As DataRow = Odt.NewRow()
            frow(0) = 0
            frow(1) = "---Select---"
            Odt.Rows.InsertAt(frow, 0)

            'Assign DataTable as DataSource.
            cmbTLabour.DataSource = Odt
            cmbTLabour.DisplayMember = "LabourName"
            cmbTLabour.ValueMember = "LabourId"

            cmbTLabour.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub lstLotNo_ColumnWidthChanging(sender As Object, e As ColumnWidthChangingEventArgs)
        Dim DisableColumns As Integer() = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9}

        For Each DCol As Integer In DisableColumns
            If e.ColumnIndex = DCol Then
                e.Cancel = True
                e.NewWidth = lstLotNo.Columns(DCol).Width
            End If
        Next DCol
    End Sub
    Private Sub lstLotNo_DoubleClick(sender As Object, e As EventArgs) Handles lstLotNo.DoubleClick
        If lstLotNo.Items.Count > 0 Then

            Dim TransId As Integer = lstLotNo.SelectedItems(0).SubItems(0).Text

            Me.Clear_Form()

            btnSave.Text = "&Update"

            fillRecordFromListView(TransId)

            Me.TabControl1.SelectedIndex = 0
        End If
    End Sub
    Private Sub fillRecordFromListView(ByVal TransId As Integer)
        Dim dttable As New DataTable

        dttable = FetchAllRecords(CInt(TransId))

        If dttable.Rows.Count > 0 Then

            txtTransNo.Text = dttable.Rows(0).Item("TransactionId").ToString()
            TransDt.Text = dttable.Rows(0).Item("TransactionDt").ToString()

            If btnSave.Text = "Update" Then
                'cmbLotNo.Text = dttable.Rows(0).Item("LotNo").ToString()
                'cmbLotNo.SelectedIndex = 0
                'cmbLotNo.Enabled = False

                cmbLotNo.Visible = False
                txtLotNo.Location = New Point(108, 63)
                txtLotNo.Visible = True
                txtLotNo.Text = dttable.Rows(0).Item("LotNo").ToString()
                txtLotNo.Width = 85
                txtLotNo.Enabled = False
            End If

            txtItemName.Tag = dttable.Rows(0).Item("ItemId").ToString()
            txtItemName.Text = dttable.Rows(0).Item("ItemName").ToString()

            For Each row As DataRow In dttable.Rows
                ''  dgvNewLot.Rows.Add(1, Val(row("OperationId")), CStr(row("OperationName")), Format(Val(row("IssuePr")), "0.000"), Format(Val(row("IssueWt")), "0.000"), Format(Val(row("ReceivePr")), "0.000"), Format(Val(row("ReceiveWt")), "0.000"), Format(Val(row("BhukaWt")), "0.000"), Format(Val(row("SampleWt")), "0.000"), Format(Val(row("LossWt")), "0.000"), Val(row("FrLabourId")), CStr(row("FrLabour")))
            Next
        End If
    End Sub
    Private Sub lstLotNo_ItemChecked(sender As Object, e As ItemCheckedEventArgs) Handles lstLotNo.ItemChecked
        Dim x As Integer = e.Item.Index

        If e.Item.Checked Then
            For i As Integer = 0 To lstLotNo.Items.Count - 1
                If Not i = x Then lstLotNo.Items.Item(i).Checked = False
            Next
        End If
    End Sub
    Private Sub TabControl1_Click(sender As Object, e As EventArgs) Handles TabControl1.Click
        If TabControl1.SelectedIndex = 1 Then
            lblTotal.Text = CStr(lstLotNo.Items.Count())
            Me.bindListView()
        End If
    End Sub
    Private Sub SaveData()

        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()

            With Hparameters
                .Add(dbManager.CreateParameter("@TDate", TransDt.Value.ToString(), DbType.DateTime))
                .Add(dbManager.CreateParameter("@TLotNo", cmbLotNo.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@TItemId", txtItemName.Tag, DbType.Int16))

                .Add(dbManager.CreateParameter("@TfLabourId", txtFrKarigar.Tag, DbType.Int16))
                .Add(dbManager.CreateParameter("@TtLabourId", Val(cmbTLabour.SelectedIndex), DbType.Int16))

                .Add(dbManager.CreateParameter("@TOperationId", Val(txtOperation.Tag), DbType.Int16))
                .Add(dbManager.CreateParameter("@TOperationTypeId", 1, DbType.Int16))

                .Add(dbManager.CreateParameter("@TIssuePr", txtIssuePr.Text, DbType.String))
                .Add(dbManager.CreateParameter("@TIssueWt", txtIssueWt.Text, DbType.String))
                .Add(dbManager.CreateParameter("@TRecievePr", txtReceivePr.Text, DbType.String))
                .Add(dbManager.CreateParameter("@TRecieveWt", txtReceiveWt.Text, DbType.String))
                .Add(dbManager.CreateParameter("@HCreatedBy", UserName.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@TBhukaWt", txtBhukaWt.Text, DbType.String))
                .Add(dbManager.CreateParameter("@TSampleWt", txtSampleWt.Text, DbType.String))
                .Add(dbManager.CreateParameter("@TLossWt", txtLossWt.Text, DbType.String))
            End With

            dbManager.Insert("SP_Transaction_Save", CommandType.StoredProcedure, Hparameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally

        End Try
    End Sub
    Private Sub UpdateData()

        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()

            With Hparameters
                .Add(dbManager.CreateParameter("@TDate", TransDt.Value.ToString(), DbType.DateTime))
                .Add(dbManager.CreateParameter("@TLotNo", cmbLotNo.Text, DbType.String))
                .Add(dbManager.CreateParameter("@TItemId", txtItemName.Tag, DbType.Int16))

                .Add(dbManager.CreateParameter("@TfLabourId", txtFrKarigar.Tag, DbType.Int16))
                .Add(dbManager.CreateParameter("@TtLabourId", Val(cmbTLabour.SelectedIndex), DbType.Int16))

                .Add(dbManager.CreateParameter("@TOperationId", Val(txtOperation.Tag), DbType.Int16))
                .Add(dbManager.CreateParameter("@TOperationTypeId", 1, DbType.Int16))

                .Add(dbManager.CreateParameter("@TIssuePr", txtIssuePr.Text, DbType.String))
                .Add(dbManager.CreateParameter("@TIssueWt", txtIssueWt.Text, DbType.String))
                .Add(dbManager.CreateParameter("@TRecievePr", txtReceivePr.Text, DbType.String))
                .Add(dbManager.CreateParameter("@TRecieveWt", txtReceiveWt.Text, DbType.String))

                .Add(dbManager.CreateParameter("@TId", txtTransNo.Text.Trim(), DbType.Int16))

                .Add(dbManager.CreateParameter("@HCreatedBy", UserName.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@TBhukaWt", txtBhukaWt.Text, DbType.String))
                .Add(dbManager.CreateParameter("@TSampleWt", txtSampleWt.Text, DbType.String))
                .Add(dbManager.CreateParameter("@TLossWt", txtLossWt.Text, DbType.String))
            End With

            dbManager.Insert("SP_Transaction_Update", CommandType.StoredProcedure, Hparameters.ToArray())

            MessageBox.Show("Data Updated !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally

        End Try
    End Sub
    Private Sub frmLotNo_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                If MsgBox("Wish To Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Me.Close()
            ElseIf e.KeyCode = Keys.Tab Then
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
    Private Sub txtReceiveWt_TextChanged(sender As Object, e As EventArgs) Handles txtReceiveWt.TextChanged
        Try
            txtLossWt.Text = Format((Val(txtIssueWt.Text) - Val(txtReceiveWt.Text) - Val(txtBhukaWt.Text) - Val(txtSampleWt.Text)), "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtBhukaWt_TextChanged(sender As Object, e As EventArgs) Handles txtBhukaWt.TextChanged
        Try
            txtLossWt.Text = Format((Val(txtIssueWt.Text) - Val(txtReceiveWt.Text) - Val(txtBhukaWt.Text) - Val(txtSampleWt.Text)), "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtSampleWt_TextChanged(sender As Object, e As EventArgs) Handles txtSampleWt.TextChanged
        Try
            txtLossWt.Text = Format((Val(txtIssueWt.Text) - Val(txtReceiveWt.Text) - Val(txtBhukaWt.Text) - Val(txtSampleWt.Text)), "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtReceiveWt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtReceiveWt.KeyPress
        numdotkeypress(e, txtReceiveWt, Me)
    End Sub
    Private Sub txtReceiveWt_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReceiveWt.KeyDown
        If e.KeyCode = Keys.Tab Then
            txtBhukaWt.Select()
        End If
    End Sub
    Private Sub txtBhukaWt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBhukaWt.KeyPress
        numdotkeypress(e, txtBhukaWt, Me)
    End Sub
    Private Sub txtBhukaWt_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBhukaWt.KeyDown
        If e.KeyCode = Keys.Tab Then
            txtSampleWt.Select()
        End If
    End Sub
    Private Sub txtBhukaWt_Leave(sender As Object, e As EventArgs) Handles txtBhukaWt.Leave
        txtBhukaWt.Text = Format(Val(txtBhukaWt.Text), "0.00")
    End Sub
    Private Sub txtSampleWt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSampleWt.KeyPress
        numdotkeypress(e, txtSampleWt, Me)
    End Sub
    Private Sub txtSampleWt_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSampleWt.KeyDown
        If e.KeyCode = Keys.Tab Then
            txtLossWt.Select()
        End If
    End Sub
    Private Sub cmbLotNo_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbLotNo.SelectedIndexChanged

        If cmbLotNo.SelectedIndex > 0 Then

            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchRecordByLotNo", DbType.String))
                .Add(dbManager.CreateParameter("@MLotNo", cmbLotNo.Text.Trim(), DbType.String))
            End With

            Dim dr As SqlDataReader = dbManager.GetDataReader("SP_Melting_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

            Try
                If dr.Read = False Then
                    Exit Sub
                Else
                    txtOperation.Tag = 2
                    txtOperation.Text = "Receive Melting"
                    txtOperation.Enabled = False
                    txtItemName.Tag = dr.Item("ItemId").ToString
                    txtItemName.Text = dr.Item("ItemName").ToString
                    txtIssuePr.Text = dr.Item("RequirePr").ToString
                    txtIssueWt.Text = Convert.ToString(dr.Item("GrossWt"))
                    txtReceivePr.Text = dr.Item("RequirePr").ToString
                    txtFrKarigar.Tag = dr.Item("ToKarigarId").ToString
                    txtFrKarigar.Text = dr.Item("ToKarigar").ToString
                    cmbTLabour.Enabled = True
                End If
            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally
                dr.Close()
                Objcn.Close()
            End Try

        End If
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Call Clear_Form()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub txtReceiveWt_Leave(sender As Object, e As EventArgs) Handles txtReceiveWt.Leave
        If txtReceiveWt.TextLength > 0 Then
            txtReceiveWt.Text = Format(Val(txtReceiveWt.Text), "0.00")
        End If
    End Sub
    Private Sub txtSampleWt_Leave(sender As Object, e As EventArgs) Handles txtSampleWt.Leave
        txtSampleWt.Text = Format(Val(txtSampleWt.Text), "0.00")
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub cmbLotNo_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbLotNo.KeyDown
        If e.KeyCode = Keys.Tab Then
            SendKeys.Send("{tab}")
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub txtReceiveWt_Validating(sender As Object, e As CancelEventArgs) Handles txtReceiveWt.Validating
        If String.IsNullOrEmpty(txtReceiveWt.Text.Trim) Or Val(txtReceiveWt.TextLength) = 0 Then
            e.Cancel = True
            Objerr.SetError(txtReceiveWt, "Receive Wt. is required.")
        Else
            Objerr.Clear()
        End If
    End Sub
    Private Sub txtLossWt_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLossWt.KeyDown
        If e.KeyCode = Keys.Tab Then
            SendKeys.Send("{tab}")
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub cmbTLabour_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbTLabour.KeyDown
        If e.KeyCode = Keys.Tab Then
            txtReceiveWt.Focus()
        End If
    End Sub
    Private Sub Clear_Form()
        Try
            btnSave.Text = "Save"
            cmbLotNo.SelectedIndex = 0

            txtTransNo.Clear()
            txtLotNo.Clear()

            txtItemName.Tag = ""
            txtItemName.Clear()
            txtIssuePr.Clear()
            txtIssueWt.Clear()
            txtReceivePr.Clear()
            txtReceiveWt.Clear()

            txtBhukaWt.Clear()
            txtSampleWt.Clear()
            txtLossWt.Clear()

            cmbTLabour.SelectedIndex = 0

            Fr_Mode = FormState.AStateMode

            Me.fillLotNo()

            cmbLotNo.Focus()
            cmbLotNo.Select()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Function Validate_Fields() As Boolean

        Try
            If cmbLotNo.SelectedIndex = 0 And btnSave.Text = "&Save" Then
                MessageBox.Show("Select Lot No !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbLotNo.Focus()
                Return False
            ElseIf txtItemName.Text.Trim.Length = 0 Then
                MessageBox.Show("Select Item Name !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtItemName.Focus()
                Return False
            ElseIf cmbTLabour.SelectedIndex = -1 Or cmbTLabour.SelectedIndex = 0 Then
                MessageBox.Show("Select To Employee !", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbTLabour.Focus()
                Return False
                'ElseIf (Val(txtReceiveWt.Text.Trim) + Val(txtSampleWt.Text.Trim) + Val(txtBhukaWt.Text.Trim)) >= Val(txtIssueWt.Text.Trim) Then
            ElseIf Val(txtReceiveWt.Text + txtSampleWt.Text + txtBhukaWt.Text) >= val(txtIssueWt.Text) Then
                MessageBox.Show("Receive Wt. Should not Be More than Issue Wt. !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtReceiveWt.Focus()
                Return False
                'ElseIf CheckMaxLossValue(txtLossWt.Text.Trim) = False Then
                '    MessageBox.Show("Check Loss Wt !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                '    txtLossWt.Focus()
                '    Return False
            End If
            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Function CheckMaxLossValue(ByVal Opreation_ID As Integer) As Boolean
        Try

            Dim iValue As String = Nothing

            Dim dt As DataTable = New DataTable()

            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchLossWt", DbType.String))
                .Add(dbManager.CreateParameter("@OId", Val(Opreation_ID), DbType.Int16))
            End With

            Dim o As Object = dbManager.GetScalarValue("SP_OperationMaster_Select", CommandType.StoredProcedure, parameters.ToArray())

            If o IsNot Nothing Then
                iValue = o.ToString()
            End If

            If Not iValue = "0" Then
                If Val(txtLossWt.Text) > Val(iValue) Or iValue < 0 Then
                    Return False
                End If
            End If

            Return True

        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
End Class