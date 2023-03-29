Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Public Class frmRLotTransfer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState

    Dim strSQL As String = Nothing
    Dim TempRow As Integer

    Dim GRIDDOUBLECLICK As Boolean

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
    Private Sub frmTransferedLot_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Clear_Form()

        Me.fillLotNo()
        Me.filltemName()
        Me.fillOperationType()
        Me.fillLabour()

        Me.GetNewLotNoWitId()
    End Sub
    Private Sub fillLotNo()

        Dim parameters = New List(Of SqlParameter)()

        parameters.Add(dbManager.CreateParameter("@ActionType", "FetchLotNo", DbType.String))

        Dim dr = dbManager.GetDataReader("SP_LotTransfer_Select", CommandType.StoredProcedure, parameters.ToArray(), Objcn)

        Try
            cmbLotNo.Items.Clear()

            While dr.Read()
                cmbLotNo.Items.Add(dr(0).ToString())
            End While

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            Objcn.Close()
        End Try
    End Sub
    Private Sub filltemName()

        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FillOnlyItemName", DbType.String))
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
    Private Sub fillOperationType()

        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

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

            cmbOperation.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbOperation.AutoCompleteDataSource = AutoCompleteSource.ListItems
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub fillLabour()

        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        parameters.Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))

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

            cmbTLabour.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbTLabour.AutoCompleteDataSource = AutoCompleteSource.ListItems

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not Validate_Fields() Then Exit Sub

        Dim iOperationTypeId As Integer = 7
        Dim iOperationId As Integer = 20 ''Use Transfer Lot

        Dim trans As SqlTransaction = Nothing

        If Fr_Mode = FormState.AStateMode Then

            If Objcn.State = ConnectionState.Open Then Objcn.Close()
            Objcn.Open()
            trans = Objcn.BeginTransaction()

            Try
                Dim parameters = New List(Of SqlParameter)()
                parameters.Clear()

                With parameters
                    .Add(dbManager.CreateParameter("@TDate", LotTransDt.Value.ToString(), DbType.DateTime))
                    .Add(dbManager.CreateParameter("@TLotNo", cmbLotNo.Text, DbType.String))
                    .Add(dbManager.CreateParameter("@TItemId", cmbItem.SelectedValue, DbType.Int16))

                    .Add(dbManager.CreateParameter("@TOperationTypeId", iOperationTypeId, DbType.Int16))

                    .Add(dbManager.CreateParameter("@TIssuePr", txtIssuePr.Text.Trim(), DbType.Decimal))
                    .Add(dbManager.CreateParameter("@TIssueWt", txtIssueWt.Text.Trim(), DbType.Decimal))

                    .Add(dbManager.CreateParameter("@TRecievePr", txtReceivePr.Text.Trim(), DbType.Decimal))
                    .Add(dbManager.CreateParameter("@TRecieveWt", txtReceiveWt.Text(), DbType.Decimal))

                    .Add(dbManager.CreateParameter("@TfLabourId", CInt(txtFrKarigar.Tag), DbType.Int16))
                    .Add(dbManager.CreateParameter("@TtLabourId", Val(cmbTLabour.SelectedIndex), DbType.Int16))
                End With

                dbManager.Insert("SP_Transaction_Save", CommandType.StoredProcedure, parameters.ToArray())

                Dim lparameters = New List(Of SqlParameter)()
                lparameters.Clear()

                With lparameters
                    .Add(dbManager.CreateParameter("@ActionType", "UpdateLotTransferUsed", DbType.String))
                    .Add(dbManager.CreateParameter("@LId", CInt(txtTransNo.Text.Trim), DbType.Int16))
                    .Add(dbManager.CreateParameter("@ToKarigarId", CInt(cmbTLabour.SelectedValue), DbType.Int16))
                    .Add(dbManager.CreateParameter("@CreatedBy", UserName.Trim(), DbType.String))
                End With

                dbManager.Insert("SP_LotTransfer_Update", CommandType.StoredProcedure, lparameters.ToArray())

                trans.Commit()

                Me.btnCancel_Click(sender, e)

                MessageBox.Show("Data Saved !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                trans.Rollback()
                MessageBox.Show("Error:- " & ex.Message)
            Finally
                Objcn.Close()
            End Try
        End If

    End Sub
    Private Sub txtIssuePr_Leave(sender As Object, e As EventArgs) Handles txtIssuePr.Leave
        txtIssuePr.Text = Format(Val(txtIssuePr.Text), "0.00")
    End Sub
    Private Sub txtIssueWt_Leave(sender As Object, e As EventArgs) Handles txtIssueWt.Leave
        txtIssueWt.Text = Format(Val(txtIssueWt.Text), "0.00")
    End Sub
    Private Sub txtReceivePr_Leave(sender As Object, e As EventArgs) Handles txtReceivePr.Leave
        txtReceivePr.Text = Format(Val(txtReceivePr.Text), "0.00")
    End Sub
    Private Sub txtReceiveWt_Leave(sender As Object, e As EventArgs) Handles txtReceiveWt.Leave
        txtReceiveWt.Text = Format(Val(txtReceiveWt.Text), "0.00")
    End Sub
    Private Sub txtIssuePr_KeyPress(sender As Object, e As KeyPressEventArgs)
        OnlyAllowPostiveNumbers(sender, e, 2)
    End Sub
    Private Sub txtIssueWt_KeyPress(sender As Object, e As KeyPressEventArgs)
        OnlyAllowPostiveNumbers(sender, e, 2)
    End Sub
    Private Sub txtReceivePr_KeyPress(sender As Object, e As KeyPressEventArgs)
        OnlyAllowPostiveNumbers(sender, e, 2)
    End Sub
    Private Sub txtReceiveWt_KeyPress(sender As Object, e As KeyPressEventArgs)
        OnlyAllowPostiveNumbers(sender, e, 2)
    End Sub
    Private Sub GetNewLotNoWitId()
        Dim iDigit As Integer = 0

        Dim strDateSeq As String = Nothing
        Dim tmpDateSeq As String = Nothing

        Dim dt As DateTime = DateTime.Now

        tmpDateSeq = dt.Year.ToString() + "" + dt.Month.ToString()

        strDateSeq = tmpDateSeq

        If tmpDateSeq > 4 Then
            strDateSeq = tmpDateSeq.Substring(2)
        End If

        strSQL = Nothing
        strSQL = "SELECT ISNULL(MAX(MeltingId),0) AS MaxId FROM tblMelting"

        Try
            iDigit = dbManager.GetScalarValue(strSQL, CommandType.Text)

            iDigit = iDigit + 1
            txtTransNo.Tag = iDigit
            txtTransNo.Text = strDateSeq + iDigit.ToString("D3")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
        End Try
    End Sub
    Private Sub fillLotTransfer()

        Dim sIPr As Single = 0
        Dim sIWt As Single = 0

        Dim sRPr As Single = 0
        Dim sRWt As Single = 0

        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FetchLotNoForTransfer", DbType.String))
            .Add(dbManager.CreateParameter("@LotNo", cmbLotNo.Text.Trim(), DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_LotTransfer_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)

        Try
            If dr.Read = False Then
                Exit Sub
            Else
                txtTransNo.Text = dr("LotTransferId").ToString()
                cmbItem.SelectedIndex = dr("ItemId").ToString()

                txtFrKarigar.Tag = dr.Item("ToKarigarId").ToString()
                txtFrKarigar.Text = dr("ToLabour").ToString()

                cmbOperation.SelectedIndex = dr("OperationId").ToString()

                sIPr = dr("IssuePr").ToString()
                sIWt = dr("TransferWt").ToString()

                sRPr = sIPr
                sRWt = sIWt

                txtIssuePr.Text = Format(Val(sIPr), "0.00")
                txtIssueWt.Text = Format(Val(sIWt), "0.00")

                txtReceivePr.Text = Format(Val(sRPr), "0.00")
                txtReceiveWt.Text = Format(Val(sRWt), "0.00")

            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            Objcn.Close()
        End Try
    End Sub
    Private Sub frmTransferedLot_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Call Clear_Form()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Testing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub cmbLotNo_SelectedIndexChanged(sender As Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles cmbLotNo.SelectedIndexChanged
        If cmbLotNo.Text.Trim <> "" Then
            fillLotTransfer()
            cmbTLabour.Focus()
            cmbTLabour.Select()
        End If
    End Sub
    Private Sub cmbTLabour_Enter(sender As Object, e As EventArgs) Handles cmbTLabour.Enter
        cmbTLabour.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub
    Private Sub cmbOperation_Enter(sender As Object, e As EventArgs) Handles cmbOperation.Enter
        cmbOperation.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub cmbLotNo_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbLotNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub cmbItem_Enter(sender As Object, e As EventArgs) Handles cmbItem.Enter
        cmbItem.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub
    Private Sub cmbTLabour_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbTLabour.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub Clear_Form()
        Try
            LotTransDt.Value = DateTime.Now
            cmbLotNo.SelectedIndex = 0
            txtTransNo.Clear()
            cmbLotNo.SelectedIndex = 0
            cmbItem.SelectedIndex = 0
            cmbOperation.SelectedIndex = 0
            txtIssuePr.Clear()
            txtIssueWt.Clear()
            txtReceivePr.Clear()
            txtReceiveWt.Clear()
            txtFrKarigar.Clear()
            cmbTLabour.SelectedIndex = 0

            Fr_Mode = FormState.AStateMode

            LotTransDt.Focus()
            LotTransDt.Select()

            Me.fillLotNo()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Testing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Function Validate_Fields() As Boolean
        Try
            If cmbItem.SelectedIndex = -1 Or cmbItem.SelectedIndex = 0 Then
                MessageBox.Show("Select Item Name !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbItem.Focus()
                Return False
            ElseIf cmbLotNo.Text.Trim() = "" Then
                MessageBox.Show("Select Lot Number !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbItem.Focus()
                Return False
            ElseIf cmbTLabour.SelectedIndex = -1 Or cmbTLabour.SelectedIndex = 0 Then
                MessageBox.Show("Select To Employee !", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Sub LotTransDt_KeyDown(sender As Object, e As KeyEventArgs) Handles LotTransDt.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
            e.SuppressKeyPress = True
        End If
    End Sub
End Class