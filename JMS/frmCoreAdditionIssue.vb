Imports System.Data.SqlClient
Imports DataAccessHandler
Public Class frmCoreAdditionIssue
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState

    Dim strSQL As String = Nothing

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
    Private Sub frmCoreAdditionIssue_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Clear_Form()

        Me.fillLabour()
        Me.fillLotNo()
        Me.bindGridView()
    End Sub
    Private Sub txtCoreWt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCoreWt.KeyPress
        numdotkeypress(e, txtCoreWt, Me)
    End Sub
    Private Sub fillLabour()

        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FillLabour", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_LabourMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            ''Insert the Default Item to DataTable.
            Dim trow As DataRow = dt.NewRow()
            trow(0) = 0
            trow(1) = "---Select---"
            dt.Rows.InsertAt(trow, 0)

            cmbTLabour.DataSource = dt
            cmbTLabour.DisplayMember = "LabourName"
            cmbTLabour.ValueMember = "LabourId"

            cmbTLabour.AutoCompleteMode = AutoCompleteMode.SuggestAppend ' This is necessary
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub

    Private Sub fillLotNo()
        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
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
            cmbLotNo.DataSource = dt
            cmbLotNo.DisplayMember = "LotNo"
            cmbLotNo.ValueMember = "TransId"
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
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
    Private Sub SaveData()
        Dim iOperationTypeId As Integer = 13 ''Operation Id for Core Addition Issue

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
                .Add(dbManager.CreateParameter("@CoreAdditionDt", TransDt.Value.ToString(), DbType.DateTime))
                .Add(dbManager.CreateParameter("@IssueWt", txtIssueWt.Text.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@IssuePr", txtIssuePr.Text.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@CoreIssueWt", txtCoreWt.Text.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@LotNumber", cmbLotNo.SelectedItem.ToString(), DbType.String))

                .Add(dbManager.CreateParameter("@ItemId", txtTransNo.Tag, DbType.Int16))
                .Add(dbManager.CreateParameter("@OperationTypeId", iOperationTypeId, DbType.Int16))

                .Add(dbManager.CreateParameter("@FrKarigar", txtFrKarigar.Tag, DbType.Int16))
                .Add(dbManager.CreateParameter("@ToKarigar", Val(cmbTLabour.SelectedValue), DbType.Int16))
                .Add(dbManager.CreateParameter("@CreatedBy", UserName.Trim(), DbType.String))
            End With

            dbManager.Insert("SP_CoreAdditionIssue_Save", CommandType.StoredProcedure, parameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub UpdateData()
        Dim iOperationTypeId As Integer = 13 ''Operation Id for Core Addition Issue

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
                .Add(dbManager.CreateParameter("@CoreAdditionDt", TransDt.Value.ToString(), DbType.DateTime))
                .Add(dbManager.CreateParameter("@IssueWt", txtIssueWt.Text.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@IssuePr", txtIssuePr.Text.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@CoreIssueWt", txtCoreWt.Text.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@LotNumber", cmbLotNo.SelectedItem.ToString(), DbType.String))

                .Add(dbManager.CreateParameter("@ItemId", txtTransNo.Tag, DbType.Int16))
                .Add(dbManager.CreateParameter("@OperationTypeId", iOperationTypeId, DbType.Int16))

                .Add(dbManager.CreateParameter("@FrKarigar", txtFrKarigar.Text.Trim(), DbType.Int16))
                .Add(dbManager.CreateParameter("@ToKarigar", cmbTLabour.SelectedIndex, DbType.String))
                .Add(dbManager.CreateParameter("@CreatedBy", UserName.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@CId", txtTransNo.Text, DbType.Int16))
            End With

            dbManager.Insert("SP_CoreAdditionIssue_Save", CommandType.StoredProcedure, parameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub txtIssueWt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIssueWt.KeyPress
        Try
            txtTotal.Text = Format((Val(txtIssueWt.Text) * Val(txtCoreWt.Text)) / 100, "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtCoreWt_TextChanged(sender As Object, e As EventArgs) Handles txtCoreWt.TextChanged
        Try
            txtTotal.Text = Format((Val(txtIssueWt.Text) + Val(txtCoreWt.Text)), "0.00")
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Sub lstCoreAddition_DoubleClick(sender As Object, e As EventArgs)
        'If lstCoreAddition.Items.Count > 0 Then
        '    Dim CoreIssueId As Integer = lstCoreAddition.SelectedItems(0).SubItems(0).Text

        '    Fr_Mode = FormState.EStateMode

        '    Me.Clear_Form()

        '    fillHeaderFromListView(CoreIssueId)

        '    Me.TabControl1.SelectedIndex = 0
        'End If
    End Sub
    Private Sub fillHeaderFromListView(ByVal intCoreIssueId As Integer)

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchRecord", DbType.String))
            .Add(dbManager.CreateParameter("@CId", Val(intCoreIssueId), DbType.Int16))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader("SP_CoreAdditionIssue_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

        If dr.Read = False Then
            Exit Sub
        Else
            txtTransNo.Text = dr.Item("CoreAdditionId").ToString()
            TransDt.Text = dr.Item("CoreAdditionDt").ToString
            cmbLotNo.Text = dr.Item("LotNo").ToString

            txtIssueWt.Text = dr.Item("IssueWt").ToString()
            txtIssuePr.Text = dr.Item("IssuePr").ToString()
            txtCoreWt.Text = dr.Item("CoreIssueWt").ToString()

            txtFrKarigar.Tag = dr.Item("FrKarigarId").ToString()
            txtFrKarigar.Text = dr.Item("frKarigarName").ToString()
            cmbTLabour.SelectedIndex = dr.Item("ToKarigarId").ToString()
            ''txtFrKarigar.Tag = dr.Item().ToString()
        End If

        dr.Close()
        Objcn.Close()

        Exit Sub
ErrHandler:
        MsgBox(Err.Description, MsgBoxStyle.Critical)
    End Sub
    Private Sub bindGridView()
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader("SP_CoreAdditionIssue_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

        'lstCoreAddition.Items.Clear()

        Try

            While dr.Read
                Dim lvi As ListViewItem = New ListViewItem(dr("CoreAdditionId").ToString())
                lvi.SubItems.Add(dr("CoreAdditionDt").ToString())
                lvi.SubItems.Add(dr("LotNo").ToString())
                lvi.SubItems.Add(dr("IssueWt").ToString())
                lvi.SubItems.Add(dr("IssuePr").ToString())
                lvi.SubItems.Add(dr("CoreIssueWt").ToString())
                lvi.SubItems.Add(dr("FrKarigarId").ToString())
                lvi.SubItems.Add(dr("frKarigarName").ToString())
                lvi.SubItems.Add(dr("ToKarigarId").ToString())
                lvi.SubItems.Add(dr("toKarigarName").ToString())
                lvi.SubItems.Add(dr("CreatedBy").ToString())
                'lstCoreAddition.Items.Add(lvi)
            End While

            'If lstCoreAddition.Items.Count > 0 Then
            '    lstCoreAddition.Items(0).Selected = True
            'End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            Objcn.Close()
        End Try

    End Sub
    'Private Function fetchAllRecords() As DataTable

    '    Dim dtData As DataTable = New DataTable()

    '    Try
    '        Dim parameters = New List(Of SqlParameter)()

    '        With parameters
    '            .Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))
    '        End With

    '        dtData = dbManager.GetDataTable("SP_CoreAdditionIssue_Select", CommandType.StoredProcedure, parameters.ToArray())

    '    Catch ex As Exception
    '        MessageBox.Show("Error:- " & ex.Message)
    '    End Try

    '    Return dtData

    'End Function
    Private Sub txtIssueWt_TextChanged(sender As Object, e As EventArgs) Handles txtIssueWt.TextChanged
        Try

            If Not String.IsNullOrWhiteSpace(txtIssueWt.Text) Or Not IsNumeric(txtCoreWt.Text) Then
                txtTotal.Text = Format((Val(txtIssueWt.Text) + Val(txtCoreWt.Text)), "0.00")
            End If

            If Not String.IsNullOrEmpty(txtIssuePr.Text) Then
                txtIssueFw.Text = Format((Val(txtIssueWt.Text) * Val(txtIssuePr.Text)) / 100, "0.00")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not String.IsNullOrEmpty(txtTransNo.Text) Then

            Try
                Dim parameters = New List(Of SqlParameter)()

                With parameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@CId", Val(txtTransNo.Text), DbType.Int16))
                End With

                dbManager.Delete("SP_CoreAdditionIssue_Delete", CommandType.StoredProcedure, parameters.ToArray())

                MessageBox.Show("Data Deleted !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Me.Clear_Form()

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            End Try
        Else
            MessageBox.Show("Please Select A Record !!!")
        End If
    End Sub
    Private Sub getLastLotNoVAmt()

        Dim connection As SqlConnection = Nothing

        strSQL = Nothing
        strSQL = "SELECT * FROM  udf_GetMaxLotTransNo('" & cmbLotNo.Text.Trim() & "') ORDER BY MaxTransId"

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@TLotNo", cmbLotNo.Text.Trim(), DbType.String))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader(strSQL, CommandType.Text, Objcn, parameters.ToArray())

        Try
            If dr.Read = False Then
                Exit Sub
            Else
                txtTransNo.Tag = dr.Item("ItemId").ToString()
                txtTransNo.Text = dr.Item("MaxTransId").ToString()
                'txtOperation.Tag = dr("OperationId").ToString()
                'txtOperation.Text = dr("OperationName").ToString()
                txtIssueWt.Text = Format(Val(dr.Item("ReceiveWt")), "0.00")
                txtIssuePr.Text = Format(Val(dr.Item("ReceivePr")), "0.00")
                txtFrKarigar.Tag = dr.Item("FrLabourId").ToString()
                txtFrKarigar.Text = dr.Item("frKarigarName").ToString()
                cmbTLabour.SelectedIndex = dr.Item("ToLabourId").ToString()

                txtTotalPr.Text = Format(Val(dr.Item("ReceivePr")), "0.00")
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            Objcn.Close()
        End Try
    End Sub
    Private Sub frmCoreAdditionIssue_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
    Private Sub cmbLotNo_SelectedIndexChanged(sender As Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles cmbLotNo.SelectedIndexChanged
        If cmbLotNo.Text.Trim <> "" Then
            Me.getLastLotNoVAmt()
        End If
    End Sub
    Private Sub cmbLotNo_Enter(sender As Object, e As EventArgs) Handles cmbLotNo.Enter
        cmbLotNo.ShowDropDown()
    End Sub
    Private Sub cmbTLabour_Enter(sender As Object, e As EventArgs) Handles cmbTLabour.Enter
        cmbTLabour.ShowDropDown()
    End Sub
    Private Sub txtIssuePr_TextChanged(sender As Object, e As EventArgs) Handles txtIssuePr.TextChanged
        Try
            If Not String.IsNullOrWhiteSpace(txtIssuePr.Text.Trim) Then
                txtIssueFw.Text = Format(Val(txtIssueWt.Text) * Val(txtIssuePr.Text) / 100, "0.00")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtIssueFw_TextChanged(sender As Object, e As EventArgs) Handles txtIssueFw.TextChanged
        Try
            If Not String.IsNullOrWhiteSpace(txtIssueFw.Text) Or Not IsNumeric(txtIssueFw.Text) Then
                txtTotalFw.Text = Format((Val(txtIssueFw.Text) + Val(txtCoreFw.Text)), "0.00")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtTotal_TextChanged(sender As Object, e As EventArgs) Handles txtTotal.TextChanged
        Try
            If Not String.IsNullOrWhiteSpace(txtTotalFw.Text) And Not String.IsNullOrWhiteSpace(txtTotal.Text) Then
                txtTotalPr.Text = Format((Val(txtTotalFw.Text) / Val(txtTotal.Text)) * 100, "0.00")
            Else
                txtTotalPr.Text = Format(txtTotalPr.Text, "0.00")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtTotalFw_TextChanged(sender As Object, e As EventArgs) Handles txtTotalFw.TextChanged
        'Try
        '    If Not String.IsNullOrWhiteSpace(txtTotalFw.Text) Or Not IsNumeric(txtTotalFw.Text) Then
        '        txtTotalPr.Text = Format((Val(txtTotalFw.Text) / Val(txtTotal.Text)) * 100, "0.00")
        '    End If
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub txtCoreWt_Leave(sender As Object, e As EventArgs) Handles txtCoreWt.Leave
        txtCoreWt.Text = Format(Val(txtCoreWt.Text), "0.00")
    End Sub
    Private Sub Clear_Form()
        Try

            txtTransNo.Tag = ""
            txtTransNo.Clear()

            cmbLotNo.SelectedIndex = -1
            cmbTLabour.SelectedIndex = -1

            txtIssueWt.Clear()
            txtIssuePr.Clear()
            txtCoreWt.Clear()
            txtTotal.Clear()
            txtFrKarigar.Tag = ""
            txtFrKarigar.Clear()

            txtIssueFw.Clear()
            txtCoreFw.Clear()
            txtCorePr.Clear()

            txtTotal.Clear()
            txtTotalPr.Clear()
            txtTotalFw.Clear()

            Fr_Mode = FormState.AStateMode

            TransDt.Focus()
            TransDt.Select()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Testing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Function Validate_Fields() As Boolean
        Try

            If String.IsNullOrWhiteSpace(cmbTLabour.Text.Trim()) Or Convert.ToInt32(cmbTLabour.SelectedIndex) = -1 Then
                MessageBox.Show("Select Labour !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbTLabour.Focus()
                Return False
            End If

            If FormState.EStateMode AndAlso String.IsNullOrEmpty(txtTransNo.Text.Trim()) Then
                MessageBox.Show("Select Id !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Function fetchAllRecords() As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_StockIssue_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
End Class