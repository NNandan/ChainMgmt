Imports System.Data.SqlClient
Imports DataAccessHandler
Imports System.ComponentModel
Imports System.IO
Imports Microsoft.Reporting.WinForms

Public Class frmMainChart
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState

    Dim strSQL As String = Nothing
    Dim GridDoubleClick As Boolean

    Dim dblOldVaccumWt As Double

    Dim dbManager As New SqlHelper()
    Dim Objcn As SqlConnection = New SqlConnection()
    Dim iItemId As Int16

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
                    Me.btnDelete.Enabled = False
                    Me.btnSave.Text = "&Save"
                Case FormState.EStateMode
                    CType(Me.ParentForm, frmMain).FormMode.Text = "Edit"
                    Me.btnDelete.Enabled = True
                    Me.btnSave.Text = "&Update"
            End Select
        End Set
    End Property
    Private Sub frmMainChart_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.fillLotNo()
        Me.Clear_Form()
        Me.fillPartyName()
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not Common_Validate_Fields() Then Exit Sub

        Try
            If btnSave.Text = "&Save" Then
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
    Private Sub fillLabour()
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FillLabour", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_LabourMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), Objcn)
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

            cmbTLabour.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbTLabour.AutoCompleteDataSource = AutoCompleteSource.ListItems
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            Objcn.Close()
        End Try
    End Sub
    Private Sub fillOperationType()
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FillMainChartOperation", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_OperationMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), Objcn)
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
            cmbOperation.SelectedIndex = 0

            cmbOperation.AutoCompleteMode = AutoCompleteMode.SuggestAppend ' This is necessary
            cmbOperation.AutoCompleteDataSource = AutoCompleteSource.ListItems
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            Objcn.Close()
        End Try
    End Sub
    Private Sub fillItemName()
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
    Private Sub fillPartyName()
        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader("SP_PartyMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)

        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            'Insert the Default Item to DataTable.
            Dim row As DataRow = dt.NewRow()
            row(0) = 0
            row(1) = "---Select---"
            dt.Rows.InsertAt(row, 0)

            'Assign DataTable as DataSource.
            cmbPartyName.DataSource = dt
            cmbPartyName.DisplayMember = "PartyName"
            cmbPartyName.ValueMember = "PartyId"

            cmbItem.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbItem.AutoCompleteDataSource = AutoCompleteSource.ListItems
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub getLastLotNoValue()
        strSQL = Nothing
        strSQL = "SELECT * FROM udf_GetMaxLotTransNo('" & cmbLotNo.Text.Trim() & "') ORDER BY MaxTransId"

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@TLotNo", cmbLotNo.Text.Trim(), DbType.String))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader(strSQL, CommandType.Text, Objcn, parameters.ToArray())

        Try
            If dr.HasRows = False Then
                Exit Sub
            Else
                dr.Read()
                txtTransNo.Text = dr("MaxTransId").ToString()
                iItemId = dr("ItemId")
                cmbItem.Text = dr("ItemName").ToString()
                txtIssuePr.Text = Format(Val(dr("ReceivePr")), "0.00")
                txtIssueWt.Text = Format(Val(dr("ReceiveWt")), "0.00")
                txtReceivePr.Text = Format(Val(dr("IssuePr")), "0.00")
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
    Private Function FetchAllRecords(ByVal oprationId As Integer) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@OId", CInt(oprationId), DbType.Int16))
                .Add(dbManager.CreateParameter("@ActionType", "FetchType", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_OperationMaster_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
    'Private Function FetchAllRecords(sLotNo As String) As DataTable
    '    Dim barcode As Zen.Barcode.Code128BarcodeDraw = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum

    '    Dim dtData As DataTable = New DataTable()
    '    Dim NewDt As DataTable = New DataTable()

    '    Try
    '        Dim parameters = New List(Of SqlParameter)()
    '        parameters.Clear()

    '        With parameters
    '            .Add(dbManager.CreateParameter("@ActionType", "PrintReceipt", DbType.String))
    '            .Add(dbManager.CreateParameter("@TLotNo", Trim(sLotNo), DbType.String))
    '        End With

    '        dtData = dbManager.GetDataTable("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray())

    '        NewDt = dtData.Clone()

    '        Dim dcolColumn As DataColumn = New DataColumn("BarCode", GetType(System.Byte()))
    '        NewDt.Columns.Add(dcolColumn)

    '        Dim Img As Image = barcode.Draw(Trim(cmbLotNo.Text.Trim), 50)
    '        'PictureBox1.Image = Img

    '        For Each sourcerow As DataRow In dtData.Rows
    '            Dim destRow As DataRow = NewDt.NewRow()
    '            destRow("TransactionId") = sourcerow("TransactionId")
    '            destRow("TransactionDt") = sourcerow("TransactionDt")
    '            destRow("LotNo") = sourcerow("LotNo")
    '            destRow("ItemName") = sourcerow("ItemName")
    '            destRow("ReceiveWt") = sourcerow("ReceiveWt")
    '            destRow("ReceivePr") = sourcerow("ReceivePr")
    '            destRow("LabourName") = sourcerow("LabourName")

    '            If Img IsNot Nothing Then
    '                Dim ms As MemoryStream = New MemoryStream()
    '                Img.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
    '                Dim imagedata As Byte() = ms.ToArray()
    '                destRow("BarCode") = imagedata
    '                'destRow("LotNo") = ms.ToArray()
    '            End If
    '            NewDt.Rows.Add(destRow)
    '        Next

    '    Catch ex As Exception
    '        MessageBox.Show("Error:- " & ex.Message)
    '    End Try

    '    Return NewDt

    'End Function
    Private Sub txtReceivedWt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtReceiveWt.KeyPress
        numdotkeypress(e, txtReceiveWt, Me)
    End Sub
    Private Sub txtSample_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSample.KeyPress
        numdotkeypress(e, txtSample, Me)
    End Sub
    Private Sub lvList_KeyDown(sender As Object, e As KeyEventArgs) Handles lvList.KeyDown
        Dim strLotName As String = Nothing
        Dim intId As Integer = 0
        Dim intNewSelIndex As Integer = 0

        Try
            If e.KeyCode = Keys.Tab Then cmbOperation.Select()
            ''If Len(Txt_Pat_Employer.Text) > 150 Then Txt_Pat_Employer.ScrollBars = ScrollBars.Both Else Txt_Pat_Employer.ScrollBars = ScrollBars.None
        Catch ex As Exception

        End Try

        If e.KeyCode = Keys.Delete Then
            If lvList.SelectedItems.Count = 0 Then
                MsgBox("No Record selected to delete.", vbExclamation, "Delete")
                Exit Sub
            End If

            With lvList.SelectedItems(0)
                intId = .SubItems(0).Text.ToString()
                strLotName = .SubItems(1).Text
            End With

            If MsgBox("Are you sure Delete Record " & intId & " '" & strLotName & "'?", vbYesNo + vbQuestion, "Confirm Delete") = vbNo Then
                Exit Sub
            Else
                Me.DeleteRecord(intId, strLotName)
            End If

            With lvList
                If .Items(.Items.Count - 1).Selected Then
                    intNewSelIndex = .Items.Count - 2
                Else
                    intNewSelIndex = .SelectedItems(0).Index
                End If

                .SelectedItems(0).Remove()

                If .Items.Count > 0 Then
                    .Items(intNewSelIndex).Selected = True
                Else
                    Me.Clear_Form()
                End If
            End With

        End If
    End Sub
    Private Sub DeleteRecord(ByVal iTransId As Integer, ByVal sLotName As String)

        If Not String.IsNullOrEmpty(iTransId) Or Not String.IsNullOrEmpty(sLotName) Then

            strSQL = "DELETE FROM tblTransaction WHERE TransactionId = " & Val(iTransId) & " AND LotNumber = '" & CStr(sLotName) & "'"

            Try

                dbManager.Delete(strSQL, CommandType.Text)

                MessageBox.Show("Record Deleted Successfully !!!")

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            End Try
        Else
            MessageBox.Show("Please Select A Record !!!")
        End If
    End Sub
    Private Sub txtSample_Enter(sender As Object, e As EventArgs) Handles txtSample.Enter
        If cmbOperation.SelectedIndex = 0 Then
            MessageBox.Show("Please Fill Operation")
            cmbOperation.Focus()
        ElseIf txtReceiveWt.Text.Trim.Length = 0 Then
            MessageBox.Show("Enter Recieve Wt.")
            txtReceiveWt.Focus()
        ElseIf txtBhukaWt.Text.Trim.Length = 0 Then
            MessageBox.Show("Enter Bhuka Wt.")
            txtBhukaWt.Focus()
        End If
    End Sub
    Private Sub txtBhuka_Enter(sender As Object, e As EventArgs)
        If cmbOperation.SelectedIndex = 0 Then
            MessageBox.Show("Please Fill Operation")
            cmbOperation.Focus()
        ElseIf txtReceiveWt.Text.Trim.Length = 0 Then
            MessageBox.Show("Enter Recieve Wt.")
            txtReceiveWt.Focus()
        End If
    End Sub
    Private Sub txtReceivedWt_Enter(sender As Object, e As EventArgs) Handles txtReceiveWt.Enter
        If cmbOperation.SelectedIndex = 0 Then
            MessageBox.Show("Please Fill Operation")
            cmbOperation.Focus()
        End If
    End Sub
    Private Sub txtReceivedWt_Leave(sender As Object, e As EventArgs) Handles txtReceiveWt.Leave
        txtReceiveWt.Text = Format(Val(txtReceiveWt.Text), "0.00")
    End Sub
    Private Sub txtVaccume_Leave(sender As Object, e As EventArgs) Handles txtVaccume.Leave
        txtVaccume.Text = Format(Val(txtVaccume.Text), "0.00")
    End Sub
    Private Sub txtSample_Validating(sender As Object, e As CancelEventArgs) Handles txtSample.Validating
        Dim sIWt As Single = 0
        Dim sRWt As Single = 0
        Dim sBWt As Single = 0
        Dim sSWt As Single = 0
        Dim sIp As Single = 0
        Dim sRp As Single = 0
        Dim sLoss As Single = 0
        Dim sVaccume As Single = 0

        sIWt = Val(txtIssueWt.Text.Trim)
        sRWt = Val(txtReceiveWt.Text.Trim)
        sBWt = Val(txtBhukaWt.Text.Trim)
        sSWt = Val(txtSample.Text.Trim)
        sIp = Val(txtIssuePr.Text.Trim)

        If txtOprationType.Tag = 4 Then
            txtVaccume.Text = Format(Val(sIWt - sRWt - sBWt - sSWt), "0.000")
            sRp = sIp
            sLoss = 0
        Else
            If txtOprationType.Tag = 5 Then
                sRp = 1 * ((sIWt * sIp) / (sRWt + sBWt + sSWt))
                sLoss = 0
            Else
                sRp = sIp
                sLoss = Format(Val(sIWt - sRWt - sBWt - sSWt), "0.000")
            End If
        End If

        txtReceivePr.Text = Format(Val(sRp), "0.000")
        txtLossWt.Text = Format(Val(sLoss), "0.000")
        txtSample.Text = Format(Val(txtSample.Text), "0.000")
    End Sub
    Private Sub lvList_DoubleClick(sender As Object, e As EventArgs) Handles lvList.DoubleClick
        Try
            Dim selectedIndex As Int32 = lvList.SelectedIndices(0)

            If Not selectedIndex = -1 Then

                If lvList.Items.Count > 0 Then
                    lvList.Items(0).Selected = False
                    lvList.Items(0).SubItems(1).BackColor = Color.DarkMagenta
                End If

                If lvList.SelectedItems(0).SubItems(0).Text IsNot Nothing Then
                    'SET THEM TO TEXTBOXES

                    If lvList.SelectedItems(0).SubItems(13).Text = False Then
                        lblLocked.Visible = True
                        pbLock.Visible = True
                    Else
                        lblLocked.Visible = False
                        pbLock.Visible = False

                        If lvList.SelectedItems(0).SubItems(14).Text = 8 Then
                            MessageBox.Show("Cannot Make Operation  !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If

                        Fr_Mode = FormState.EStateMode

                        cmbOperation.SelectedIndex = lvList.SelectedItems(0).SubItems(14).Text
                        txtIssuePr.Text = lvList.SelectedItems(0).SubItems(3).Text
                        txtIssueWt.Text = lvList.SelectedItems(0).SubItems(4).Text
                        txtReceiveWt.Text = lvList.SelectedItems(0).SubItems(5).Text
                        txtBhukaWt.Text = lvList.SelectedItems(0).SubItems(6).Text
                        txtSample.Text = lvList.SelectedItems(0).SubItems(7).Text
                        txtReceivePr.Text = lvList.SelectedItems(0).SubItems(8).Text
                        txtLossWt.Text = lvList.SelectedItems(0).SubItems(9).Text

                        txtVaccume.Text = lvList.SelectedItems(0).SubItems(10).Text.Trim

                        dblOldVaccumWt = lvList.SelectedItems(0).SubItems(10).Text.Trim

                        txtFrKarigar.Text = lvList.SelectedItems(0).SubItems(11).Text
                        cmbTLabour.Text = lvList.SelectedItems(0).SubItems(12).Text

                        '' Main Chart Editing Start

                        Me.Validate_EditFields()

                        '' Main Chart Editing End

                    End If
                End If

            End If
        Catch ex As ArgumentOutOfRangeException

        Finally

        End Try
    End Sub
    Private Sub SaveData()

        Dim trans As SqlTransaction = Nothing

        If Objcn.State = ConnectionState.Open Then Objcn.Close()
        Objcn.Open()

        trans = Objcn.BeginTransaction(System.Data.IsolationLevel.Serializable)

        Try
            Dim lparameters = New List(Of SqlParameter)()
            lparameters.Clear()

            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@TDate", TransDt.Value.ToString(), DbType.DateTime))
                .Add(dbManager.CreateParameter("@TLotNo", cmbLotNo.Text, DbType.String))
                .Add(dbManager.CreateParameter("@TItemId", Val(iItemId), DbType.Int16))

                .Add(dbManager.CreateParameter("@TOperationId", Val(cmbOperation.SelectedValue), DbType.Int16))
                .Add(dbManager.CreateParameter("@TOperationTypeId", Val(txtOprationType.Tag), DbType.Int16))

                .Add(dbManager.CreateParameter("@TIssuePr", Convert.ToString(txtIssuePr.Text), DbType.String))
                .Add(dbManager.CreateParameter("@TIssueWt", Convert.ToString(txtIssueWt.Text), DbType.String))

                .Add(dbManager.CreateParameter("@TRecievePr", Convert.ToString(txtReceivePr.Text), DbType.String))
                .Add(dbManager.CreateParameter("@TRecieveWt", Convert.ToString(txtReceiveWt.Text), DbType.String))

                .Add(dbManager.CreateParameter("@TBhukaWt", Val(txtBhukaWt.Text), DbType.String))
                .Add(dbManager.CreateParameter("@TSampleWt", Val(txtSample.Text), DbType.String))
                .Add(dbManager.CreateParameter("@TVaccumeWt", Convert.ToString(txtVaccume.Text), DbType.String))

                .Add(dbManager.CreateParameter("@TfLabourName", CStr(txtFrKarigar.Text.Trim), DbType.String))
                .Add(dbManager.CreateParameter("@TtLabourName", CStr(cmbTLabour.Text.Trim), DbType.String))

                .Add(dbManager.CreateParameter("@TPartyName", CStr(cmbPartyName.Text.Trim), DbType.String))

                If String.IsNullOrEmpty(txtLossWt.Text) = False Then
                    .Add(dbManager.CreateParameter("@TLossWt", Convert.ToString(txtLossWt.Text), DbType.String))
                End If

                .Add(dbManager.CreateParameter("@HCreatedBy", UserName.Trim(), DbType.String))
            End With

            dbManager.Insert("SP_Transaction_Save", CommandType.StoredProcedure, parameters.ToArray())

            If chkLotFinal.Checked = True Then
                With lparameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@ActionType", "UpdateFinalLot", DbType.String))
                    .Add(dbManager.CreateParameter("@TLotNo", cmbLotNo.Text, DbType.String))
                    .Add(dbManager.CreateParameter("@TFinalLot", 0, DbType.Boolean))
                End With
                dbManager.Insert("SP_Transaction_FinalLot", CommandType.StoredProcedure, lparameters.ToArray())
            End If

            trans.Commit()

            If btnSave.Text = "&Save" Then
                MessageBox.Show("Data Saved !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Data Updated !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            trans.Rollback()
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            Objcn.Close()
        End Try
    End Sub
    Private Sub DeleteData()

        Dim trans As SqlTransaction = Nothing

        If Objcn.State = ConnectionState.Open Then Objcn.Close()
        Objcn.Open()
        trans = Objcn.BeginTransaction(System.Data.IsolationLevel.Serializable)

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@TId", txtTransNo.Text.Trim(), DbType.Int16))
            End With

            dbManager.Insert("SP_Transaction_Delete", CommandType.StoredProcedure, parameters.ToArray())

            trans.Commit()

        Catch ex As Exception
            trans.Rollback()
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            Objcn.Close()
        End Try
    End Sub
    Private Sub frmMainChart_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
    Private Sub cmbLotNo_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbLotNo.KeyDown
        If e.KeyCode = Keys.Tab Then
            e.Handled = True
            cmbOperation.Focus()
        End If
    End Sub
    Private Sub cmbOperation_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbOperation.KeyDown
        If e.KeyCode = Keys.Tab Then
            e.Handled = True
            txtReceiveWt.Focus()
        End If
    End Sub
    Private Sub txtReceiveWt_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReceiveWt.KeyDown
        If e.KeyCode = Keys.Tab Then
            txtBhukaWt.Focus()
        End If
    End Sub
    Private Sub lvList_ColumnWidthChanging(sender As Object, e As ColumnWidthChangingEventArgs) Handles lvList.ColumnWidthChanging
        Dim DisableColumns As Integer() = {0, 1, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14}

        For Each DCol As Integer In DisableColumns
            If e.ColumnIndex = DCol Then
                e.Cancel = True
                e.NewWidth = lvList.Columns(DCol).Width
            End If
        Next DCol
    End Sub
    Private Sub cmbOperation_SelectedIndexChanged(sender As Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles cmbOperation.SelectedIndexChanged
        Dim dttable As New DataTable

        If cmbOperation.SelectedIndex > 0 Then
            dttable = FetchAllRecords(CInt(cmbOperation.SelectedValue))

            If dttable.Rows.Count > 0 Then
                txtOprationType.Tag = ""
                txtOprationType.Text = dttable.Rows(0).Item("OperationType").ToString()
                txtOprationType.Tag = dttable.Rows(0).Item("OperationTypeId").ToString
            End If

            If txtOprationType.Tag = 7 Then
                txtBhukaWt.Enabled = False
                txtSample.Enabled = False
            End If

            Me.fillItemName()
            Me.fillLabour()
            Me.getLastLotNoValue()

            If lvList.Items.Count > 0 Then
                lvList.Items(lvList.Items.Count - 1).EnsureVisible()
            End If
        End If
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Call Clear_Form()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub txtBhukaWt_Enter(sender As Object, e As EventArgs) Handles txtBhukaWt.Enter
        If cmbOperation.SelectedIndex = 0 Then
            MessageBox.Show("Please Fill Operation")
            cmbOperation.Focus()
        ElseIf txtReceiveWt.Text.Trim = "" Then
            MessageBox.Show("Please Fill Recieve Wieght")
            txtReceiveWt.Focus()
        End If
    End Sub
    Private Sub txtBhukaWt_Leave(sender As Object, e As EventArgs) Handles txtBhukaWt.Leave
        txtBhukaWt.Text = Format(Val(txtBhukaWt.Text), "0.00")
    End Sub
    Private Sub txtBhukaWt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBhukaWt.KeyPress
        numdotkeypress(e, txtBhukaWt, Me)
    End Sub
    Private Sub cmbLotNo_SelectedIndexChanged(sender As Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles cmbLotNo.SelectedIndexChanged
        If cmbLotNo.SelectedIndex <> -1 Then

            lblLocked.Visible = False
            pbLock.Visible = False

            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "SelectLotNo", DbType.String))
                .Add(dbManager.CreateParameter("@TLotNo", cmbLotNo.Text.Trim(), DbType.String))
            End With

            Dim dr As SqlDataReader = dbManager.GetDataReader("SP_Transaction_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

            lvList.Items.Clear()

            Try

                If dr.HasRows Then
                    lvList.BeginUpdate()
                    While dr.Read
                        Dim lvi As ListViewItem = New ListViewItem(dr("TransId").ToString())
                        lvi.SubItems.Add(dr("LotNo").ToString())
                        lvi.SubItems.Add(dr("OperationName").ToString())
                        lvi.SubItems.Add(dr("IssuePr").ToString())
                        lvi.SubItems.Add(dr("IssueWt").ToString())
                        lvi.SubItems.Add(dr("ReceiveWt").ToString())
                        lvi.SubItems.Add(dr("BhukaWt").ToString())
                        lvi.SubItems.Add(dr("SampleWt").ToString())
                        lvi.SubItems.Add(dr("ReceivePr").ToString())
                        lvi.SubItems.Add(dr("LossWt").ToString())
                        lvi.SubItems.Add(dr("VacuumWt").ToString())
                        lvi.SubItems.Add(dr("FrLabour").ToString())
                        lvi.SubItems.Add(dr("ToLabour").ToString())
                        lvi.SubItems.Add(dr("LotNoDone").ToString())
                        lvi.SubItems.Add(dr("OperationId").ToString())
                        lvList.Items.Add(lvi)
                    End While
                    lvList.EndUpdate()
                End If

                If lvList.Items.Count > 0 Then
                    lvList.Items(0).Selected = True
                End If

                Me.fillOperationType()

                cmbOperation.Focus()
                cmbOperation.Select()

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally
                dr.Close()
                Objcn.Close()
            End Try
        End If
    End Sub
    Private Sub cmbLotNo_Enter(sender As Object, e As EventArgs) Handles cmbLotNo.Enter
        cmbLotNo.ShowDropDown()
    End Sub
    Private Sub cmbTLabour_Enter(sender As Object, e As EventArgs) Handles cmbTLabour.Enter
        If cmbLotNo.Text.Trim = "" Then
            MessageBox.Show("Select LotNo")
            cmbLotNo.Focus()
        ElseIf cmbOperation.SelectedIndex = 0 Then
            MessageBox.Show("Select Operation")
            cmbOperation.Focus()
        ElseIf txtReceiveWt.Text.Trim = "" Then
            MessageBox.Show("Enter Receive Wt")
            txtReceiveWt.Focus()
        ElseIf txtReceivePr.Text.Trim = "" Then
            MessageBox.Show("Enter Receive %")
            txtReceivePr.Focus()
        ElseIf txtLossWt.Text.Trim = "" Then
            MessageBox.Show("Please Calculate Loss Or Check Your Entry")
            txtLossWt.Focus()
        End If

        cmbTLabour.ShowDropDown()
    End Sub
    Private Sub txtSample_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSample.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            cmbTLabour.Focus()
        End If
    End Sub
    Private Sub Clear_Form()
        Try
            '' For Header Field Start
            txtTransNo.Clear()
            TransDt.CustomFormat = "dd/MM/yyyy"
            TransDt.Value = DateTime.Now

            btnSave.Text = "&Save"

            txtOprationType.Clear()
            txtOprationType.Tag = ""

            cmbItem.Text = ""
            cmbItem.Enabled = True

            cmbLotNo.Text = ""
            cmbItem.Enabled = True

            txtVaccume.Clear()

            '' For Header Field End

            lvList.Items.Clear()

            '' For Detail Field Start
            cmbOperation.Text = ""

            txtReceivePr.Clear()
            txtReceiveWt.Clear()

            txtIssuePr.Clear()
            txtIssueWt.Clear()

            txtSample.Clear()
            txtBhukaWt.Clear()
            txtLossWt.Clear()

            txtVaccume.Clear()

            dblOldVaccumWt = 0

            txtFrKarigar.Text = ""
            txtFrKarigar.Tag = ""
            cmbTLabour.Text = ""
            '' For Detail Field End

            cmbLotNo.Focus()
            cmbLotNo.Select()

            Fr_Mode = FormState.AStateMode

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Testing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Function Common_Validate_Fields() As Boolean
        Dim dVaccume As Double = 0

        Try
            If String.IsNullOrWhiteSpace(cmbLotNo.Text.Trim()) Then
                MessageBox.Show("Select Lot No !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbLotNo.Focus()
                Return False
            ElseIf cmbOperation.SelectedIndex = 0 Then
                MessageBox.Show("Select Operation !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbOperation.Focus()
                Return False
            ElseIf Val(txtReceiveWt.Text.Trim.Length) = 0 Then
                MsgBox("Please Enter Receive Wt.", MsgBoxStyle.Critical)
                txtReceiveWt.Focus()
                Return False
            ElseIf txtBhukaWt.Text.Trim.Length = 0 Then
                MsgBox("Please Enter Scrap Wt.", MsgBoxStyle.Critical)
                txtBhukaWt.Focus()
                Return False
            ElseIf txtSample.Text.Trim.Length = 0 Then
                MsgBox("Please Enter Sample Wt.", MsgBoxStyle.Critical)
                txtSample.Focus()
                Return False
            ElseIf CheckMaxLossValue(cmbOperation.SelectedValue) = False Then
                MessageBox.Show("Check Loss Wt !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbOperation.Focus()
                Return False
            ElseIf (txtOprationType.Tag = "3") And Val(txtLossWt.Text) < 0 Then     ''For Normal 
                MessageBox.Show("Receive Wt. Cannot Be Greater than Issue Wt. !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbOperation.Focus()
                Return False
            ElseIf (txtOprationType.Tag = "4") And Val(txtVaccume.Text.Trim) <= 0 Then      ''For Cutting
                MessageBox.Show("Vaccume Wt. Cannot be 0 or (-)Negative !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbOperation.Focus()
                Return False
            ElseIf (txtOprationType.Tag = "5") And (Val(txtReceivePr.Text) > Val(txtIssuePr.Text)) Then     ''For Touch Change
                MessageBox.Show("Receive % Cannot Be Greater than Issue % !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbOperation.Focus()
                Return False
            ElseIf cmbTLabour.SelectedIndex = 0 Or cmbTLabour.SelectedIndex = -1 Then
                MessageBox.Show("Select To Employee  !", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbTLabour.Focus()
                Return False
            End If

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Private Sub txtBhukaWt_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBhukaWt.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            txtSample.Focus()
        End If
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not String.IsNullOrEmpty(txtTransNo.Text.Trim) Then

            If CheckBhukaBag(txtTransNo.Text.Trim) = False Or CheckSampleBag(txtTransNo.Text.Trim) = False Or CheckVacuumBag(txtTransNo.Text.Trim) = False Then
                MessageBox.Show("Cannot Delete Entry !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Exit Sub
            End If

            If (MsgBox("[DELETION] Are You Sure To Delete This Entry ?", vbYesNo + vbDefaultButton2 + vbQuestion, "Attn : " + UserName.Trim()) = vbYes) Then
                Try
                    Me.DeleteData()
                    Dim LotNo As String = Nothing
                    LotNo = cmbLotNo.Text.ToString
                    Me.btnCancel_Click(sender, e)
                    cmbLotNo.Text = LotNo
                    Dim parameters = New List(Of SqlParameter)()

                    With parameters
                        .Clear()
                        .Add(dbManager.CreateParameter("@ActionType", "SelectLotNo", DbType.String))
                        .Add(dbManager.CreateParameter("@TLotNo", cmbLotNo.Text.Trim(), DbType.String))
                    End With

                    Dim dr As SqlDataReader = dbManager.GetDataReader("SP_Transaction_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

                    lvList.Items.Clear()

                    Try

                        If dr.HasRows Then
                            lvList.BeginUpdate()
                            While dr.Read
                                Dim lvi As ListViewItem = New ListViewItem(dr("TransId").ToString())
                                lvi.SubItems.Add(dr("LotNo").ToString())
                                lvi.SubItems.Add(dr("OperationName").ToString())
                                lvi.SubItems.Add(dr("IssuePr").ToString())
                                lvi.SubItems.Add(dr("IssueWt").ToString())
                                lvi.SubItems.Add(dr("ReceiveWt").ToString())
                                lvi.SubItems.Add(dr("BhukaWt").ToString())
                                lvi.SubItems.Add(dr("SampleWt").ToString())
                                lvi.SubItems.Add(dr("ReceivePr").ToString())
                                lvi.SubItems.Add(dr("LossWt").ToString())
                                lvi.SubItems.Add(dr("VacuumWt").ToString())
                                lvi.SubItems.Add(dr("FrLabour").ToString())
                                lvi.SubItems.Add(dr("ToLabour").ToString())
                                lvi.SubItems.Add(dr("LotNoDone").ToString())
                                lvi.SubItems.Add(dr("OperationId").ToString())
                                lvList.Items.Add(lvi)
                            End While
                            lvList.EndUpdate()
                        End If

                        If lvList.Items.Count > 0 Then
                            lvList.Items(0).Selected = True
                        End If

                        Me.fillOperationType()

                        cmbOperation.Focus()
                        cmbOperation.Select()

                    Catch ex As Exception
                        MessageBox.Show("Error:- " & ex.Message)
                    Finally
                        dr.Close()
                        Objcn.Close()
                    End Try
                Catch ex As Exception
                    MessageBox.Show("Error:- " & ex.Message)
                End Try
            End If
        End If
    End Sub
    Private Function CheckBhukaBag(ByVal Trn_ID As Integer) As Boolean
        Try
            Dim iValue As String = Nothing

            Dim dt As DataTable = New DataTable()

            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "CheckBhukaBag", DbType.String))
                .Add(dbManager.CreateParameter("@TId", Val(Trn_ID), DbType.Int16))
            End With

            Dim o As Object = dbManager.GetScalarValue("SP_CheckBhukaBag_Select", CommandType.StoredProcedure, parameters.ToArray())

            If o IsNot Nothing Then
                iValue = o.ToString()
            End If

            If iValue = 0 Then
                Return False
            End If

            Return True

        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Function CheckSampleBag(ByVal Trn_ID As Integer) As Boolean
        Try
            Dim iValue As String = Nothing

            Dim dt As DataTable = New DataTable()

            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "CheckSampleBag", DbType.String))
                .Add(dbManager.CreateParameter("@TId", Val(Trn_ID), DbType.Int16))
            End With

            Dim o As Object = dbManager.GetScalarValue("SP_CheckSampleBag_Select", CommandType.StoredProcedure, parameters.ToArray())

            If o IsNot Nothing Then
                iValue = o.ToString()
            End If

            If iValue = 0 Then
                Return False
            End If

            Return True

        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Function CheckVacuumBag(ByVal Trn_ID As Integer) As Boolean
        Try
            Dim iValue As String = Nothing

            Dim dt As DataTable = New DataTable()

            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "CheckVacuumBag", DbType.String))
                .Add(dbManager.CreateParameter("@TId", Val(Trn_ID), DbType.Int16))
            End With

            Dim o As Object = dbManager.GetScalarValue("SP_CheckVacuumBag_Select", CommandType.StoredProcedure, parameters.ToArray())

            If o IsNot Nothing Then
                iValue = o.ToString()
            End If

            If iValue = 0 Then
                Return False
            End If

            Return True

        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Function CheckLotTransferUsed(ByVal Trn_ID As Integer) As Boolean
        Try
            Dim iValue As String = Nothing

            Dim dt As DataTable = New DataTable()

            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "CheckLotTransferUsed", DbType.String))
                .Add(dbManager.CreateParameter("@TId", Val(Trn_ID) - 1, DbType.Int16))
            End With

            Dim o As Object = dbManager.GetScalarValue("SP_CheckLotTransfer_Select", CommandType.StoredProcedure, parameters.ToArray())

            If o IsNot Nothing Then
                iValue = o.ToString()
            End If

            If iValue = 0 Then
                Return False
            End If

            Return True

        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Sub Validate_EditFields()
        Try

            If CheckBhukaBag(txtTransNo.Text.Trim) = False Then        ''Check Bhuka Bag Made
                MessageBox.Show("Bhuka Bag Made !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtBhukaWt.Enabled = False
                btnDelete.Enabled = False
            Else
                txtBhukaWt.Enabled = True
                btnDelete.Enabled = True
            End If

            If CheckSampleBag(txtTransNo.Text.Trim()) = False Then      ''Check Sample Bag Made
                MessageBox.Show("Sample Bag Made !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtSample.Enabled = False
                btnDelete.Enabled = False
            End If

            If CheckBhukaBag(txtTransNo.Text.Trim) = False And CheckSampleBag(txtTransNo.Text.Trim) = False Then        ''Check Sample And Bhuka Bag Made
                MessageBox.Show("Bhuka And Sample Bag Made !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtBhukaWt.Enabled = False
                txtSample.Enabled = False
                btnDelete.Enabled = False
            End If

            If txtOprationType.Tag = 4 Then
                If CheckVacuumBag(txtTransNo.Text.Trim()) = False Then    ''Checking Vacuum Bag 
                    MessageBox.Show("Vaccum Bag Made !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtReceiveWt.Enabled = True
                    txtBhukaWt.Enabled = True
                    txtSample.Enabled = True
                    btnDelete.Enabled = False
                End If
            End If

            If txtOprationType.Tag = 7 Then            ''Checking Receive Lot Transfer For Editing
                If CheckLotTransferUsed(txtTransNo.Text.Trim()) = False Then
                    MessageBox.Show("Lot Transfer Used !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtReceiveWt.Enabled = False
                    btnDelete.Enabled = False
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub UpdateData()

        If Not Validate_OperationsTypeFields() Then Exit Sub

        Dim trans As SqlTransaction = Nothing

        If Objcn.State = ConnectionState.Open Then Objcn.Close()
        Objcn.Open()
        trans = Objcn.BeginTransaction(System.Data.IsolationLevel.Serializable)

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@TId", txtTransNo.Text.Trim, DbType.Int16))
                .Add(dbManager.CreateParameter("@TDate", TransDt.Value.ToString(), DbType.DateTime))
                .Add(dbManager.CreateParameter("@TLotNo", cmbLotNo.Text, DbType.String))
                .Add(dbManager.CreateParameter("@TItemId", Val(iItemId), DbType.Int16))

                .Add(dbManager.CreateParameter("@TOperationId", Val(cmbOperation.SelectedValue), DbType.Int16))
                .Add(dbManager.CreateParameter("@TOperationTypeId", Val(txtOprationType.Tag), DbType.Int16))

                .Add(dbManager.CreateParameter("@TIssuePr", Convert.ToString(txtIssuePr.Text), DbType.String))
                .Add(dbManager.CreateParameter("@TIssueWt", Convert.ToString(txtIssueWt.Text), DbType.String))

                .Add(dbManager.CreateParameter("@TRecievePr", Convert.ToString(txtReceivePr.Text), DbType.String))
                .Add(dbManager.CreateParameter("@TRecieveWt", Convert.ToString(txtReceiveWt.Text), DbType.String))

                .Add(dbManager.CreateParameter("@TBhukaWt", Val(txtBhukaWt.Text), DbType.String))
                .Add(dbManager.CreateParameter("@TSampleWt", Val(txtSample.Text), DbType.String))
                .Add(dbManager.CreateParameter("@TVaccumeWt", Convert.ToString(txtVaccume.Text), DbType.String))

                .Add(dbManager.CreateParameter("@TfLabourId", Val(txtFrKarigar.Tag), DbType.Int16))
                .Add(dbManager.CreateParameter("@TtLabourId", Val(cmbTLabour.SelectedIndex), DbType.Int16))

                If String.IsNullOrEmpty(txtLossWt.Text) = False Then
                    .Add(dbManager.CreateParameter("@TLossWt", Convert.ToString(txtLossWt.Text), DbType.String))
                End If

                .Add(dbManager.CreateParameter("@HCreatedBy", UserName.Trim(), DbType.String))
            End With

            dbManager.Insert("SP_Transaction_Update", CommandType.StoredProcedure, parameters.ToArray())

            'Update Lot Transfter Wt. Start
            If txtOprationType.Tag = 7 Then
                If CheckLotTransferUsed(txtTransNo.Text.Trim()) = True Then
                    Dim dblTransferAmt As Double

                    dblTransferAmt = CDbl(txtIssueWt.Text.Trim) - CDbl(txtReceiveWt.Text.Trim)

                    Dim ltparameters = New List(Of SqlParameter)()
                    ltparameters.Clear()

                    With ltparameters
                        .Clear()
                        .Add(dbManager.CreateParameter("@ActionType", "UpdateTransferData", DbType.String))
                        .Add(dbManager.CreateParameter("@LTransId", (txtTransNo.Text.Trim) - 1, DbType.Int16))
                        .Add(dbManager.CreateParameter("@LTransferWt", dblTransferAmt, DbType.String))
                        .Add(dbManager.CreateParameter("@CreatedBy", UserName.Trim(), DbType.String))
                    End With

                    dbManager.Insert("SP_LotTransfer_Update", CommandType.StoredProcedure, ltparameters.ToArray())
                End If
            End If

            'Update Lot Transfter Wt. End
            trans.Commit()

            MessageBox.Show("Data Updated !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            trans.Rollback()
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            Objcn.Close()
        End Try
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        'Try
        '    Me.Cursor = Cursors.WaitCursor

        '    Dim rds1 As ReportDataSource = New ReportDataSource()
        '    rds1.Name = "DataSet_Report"
        '    rds1.Value = FetchAllRecords(cmbLotNo.Text.Trim)

        '    '' Dynaimc Path
        '    Dim path As String = Directory.GetCurrentDirectory()
        '    Dim CRPath As String = path.Replace("\bin\Debug", "") & "\Reports\" & "RptReceipt.rdlc"
        '    ''
        '    Dim report As LocalReport = New LocalReport()

        '    report.ReportPath = CRPath

        'Catch ex As Exception
        '    MessageBox.Show("Error:- " & ex.Message)
        'Finally
        '    Me.Cursor = Cursors.Default
        'End Try

        Dim sLotNo As String = Nothing
        sLotNo = cmbLotNo.Text.Trim
        Dim frm As New frmRptViewer(sLotNo)
        frm.ShowDialog()
        frm.BringToFront()
        frm.Focus()

        Try
            Me.PrintRpt()
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub
    Private Sub txtReceiveWt_Validating(sender As Object, e As CancelEventArgs) Handles txtReceiveWt.Validating
        Try
            If txtReceiveWt.Text.Trim.Length = 0 Then
                MessageBox.Show("Enter Receive Wt. !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtReceiveWt.Focus()
                Exit Sub
            End If

            If Not Val(txtOprationType.Tag) = 5 Then
                If Val(txtReceiveWt.Text.Trim) > Val(txtIssueWt.Text.Trim) Then
                    e.Cancel = True
                    MsgBox("Receive Wt. Cannot be Greater than Issue Wt.", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Sub PrintRpt()
        Dim barcode As Zen.Barcode.Code128BarcodeDraw = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum

        Dim Img As Image = barcode.Draw(Trim(cmbLotNo.Text), 20)

        'for item sales 
        Dim dtItem As DataTable

        'declaring printing format class
        Dim c As New PrintingFormat

        Printer.NewPrint()

        Printer.Print(Img, 75, 25)

        ''spacing
        Printer.Print(" ")

        dtItem = New DataTable

        dtItem = FetchAllRecords(cmbLotNo.Text.Trim)

        Printer.SetFont("Courier New", 9, FontStyle.Bold)
        Printer.Print(dtItem.Rows(0).Item("TransactionDt"))
        Printer.Print("Lot No.  :" & dtItem.Rows(0).Item("LotNo"))
        Printer.Print("Item     :" & dtItem.Rows(0).Item("ItemName"))
        Printer.Print("Rec Wt.  :" & dtItem.Rows(0).Item("ReceiveWt"))
        Printer.Print("Rec %    :" & dtItem.Rows(0).Item("ReceivePr"))
        Printer.Print("Employee :" & dtItem.Rows(0).Item("LabourName"))

        'Release the job for actual printing
        Printer.DoPrint()
    End Sub

    Private Sub cmbTLabour_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbTLabour.KeyDown
        If e.KeyCode = Keys.Tab Then
            e.Handled = True
            btnSave.Focus()
        End If
    End Sub
    Private Function Validate_OperationsTypeFields() As Boolean
        Dim dblNewVaccumWt As Double

        Try
            If Fr_Mode <> FormState.AStateMode Then
                If txtTransNo.Text.Trim = "" Then
                    MessageBox.Show("Select Trans. ID !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return False
                End If
            End If

            ''Validation for Operation Type Vaccum Bag Start

            If txtOprationType.Tag = 4 Then
                If CheckVacuumBag(txtTransNo.Text.Trim()) = False Then    ''Checking Vacuum Bag 
                    dblNewVaccumWt = CDbl(txtVaccume.Text.Trim)
                    If (Val(dblOldVaccumWt) <> Val(dblNewVaccumWt)) Then
                        MessageBox.Show("Vaccume Wt Not Same !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    End If
                Else
                    If txtIssueWt.Text.Trim() = txtReceiveWt.Text.Trim() Then
                        MessageBox.Show("Issue Wt. And Receive Wt. Should be Same !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    End If
                End If
            End If

            ''Validation for Vaccum Bag End

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

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchLossWt", DbType.String))
                .Add(dbManager.CreateParameter("@OId", Val(Opreation_ID), DbType.Int16))
            End With

            Dim o As Object = dbManager.GetScalarValue("SP_OperationMaster_Select", CommandType.StoredProcedure, parameters.ToArray())

            If o IsNot Nothing Then
                iValue = o.ToString()
            End If

            If Not iValue = "0" Then
                Select Case Opreation_ID
                    Case = 21
                        If Val(txtLossWt.Text) > Val(iValue) Or iValue < 0 Then
                            Return False
                        End If
                    Case = 15
                        If Val(txtLossWt.Text) > Val(iValue) Or iValue < 0 Then
                            Return False
                        End If
                    Case = 2
                        If Val(txtVaccume.Text) > Val(iValue) Or iValue < 0 Then
                            Return False
                        End If
                    Case = 3
                        If Val(txtVaccume.Text) > Val(iValue) Or iValue < 0 Then
                            Return False
                        End If
                    Case = 4
                        If Val(txtVaccume.Text) > Val(iValue) Or iValue < 0 Then
                            Return False
                        End If
                    Case = 5
                        If Val(txtLossWt.Text) > Val(iValue) Or iValue < 0 Then
                            Return False
                        End If
                    Case = 3
                        If Val(txtVaccume.Text) > Val(iValue) Or iValue < 0 Then
                            Return False
                        End If
                End Select
            End If

            Return True

        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function FetchAllRecords(sLotNo As String) As DataTable
        Dim barcode As Zen.Barcode.Code128BarcodeDraw = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum

        Dim dtData As DataTable = New DataTable()
        Dim NewDt As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "PrintReceipt", DbType.String))
                .Add(dbManager.CreateParameter("@TLotNo", Trim(sLotNo), DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray())

            NewDt = dtData.Clone()

            Dim dcolColumn As DataColumn = New DataColumn("BarCode", GetType(System.Byte()))
            NewDt.Columns.Add(dcolColumn)

            Dim Img As Image = barcode.Draw(Trim(cmbLotNo.Text.Trim), 20)
            'PictureBox1.Image = Img

            For Each sourcerow As DataRow In dtData.Rows
                Dim destRow As DataRow = NewDt.NewRow()
                destRow("TransactionId") = sourcerow("TransactionId")
                destRow("TransactionDt") = sourcerow("TransactionDt")
                destRow("LotNo") = sourcerow("LotNo")
                destRow("ItemName") = sourcerow("ItemName")
                destRow("ReceiveWt") = sourcerow("ReceiveWt")
                destRow("ReceivePr") = sourcerow("ReceivePr")
                destRow("LabourName") = sourcerow("LabourName")
                If Img IsNot Nothing Then
                    Dim ms As MemoryStream = New MemoryStream()
                    Img.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                    Dim imagedata As Byte() = ms.ToArray()
                    destRow("BarCode") = imagedata
                    'destRow("LotNo") = ms.ToArray()
                End If
                NewDt.Rows.Add(destRow)
            Next

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return NewDt

    End Function


End Class