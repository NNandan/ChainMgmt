Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmLotAdditionReceive
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState

    Dim strSQL As String = Nothing
    Dim TempRow As Integer
    Dim GridDoubleClick As Boolean

    Dim dIssueWt As Double = 0
    Dim dReceiveWt As Double = 0

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
    Private Sub frmLotAdditionReceive_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.fillLotNo()
        Me.fillLabour()
        Me.filltemName()

        Me.Clear_Form()
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
    Private Sub fillLotNo()
        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        parameters.Add(dbManager.CreateParameter("@ActionType", "FetchLotNo", DbType.String))

        Dim dr = dbManager.GetDataReader("SP_LotAdditionIssue_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)

        Try
            While dr.Read
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
        parameters.Clear()

        parameters.Add(dbManager.CreateParameter("@ActionType", "FillItemName", DbType.String))

        Dim dr = dbManager.GetDataReader("SP_ItemMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
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
    Private Sub bindListView()
        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        parameters.Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))

        Dim dr As SqlDataReader = dbManager.GetDataReader("SP_LotAdditionReceive_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

        lstLotAddition.Items.Clear()

        Try
            While dr.Read
                Dim lvi As ListViewItem = New ListViewItem(dr("LotAdditionId").ToString())
                lvi.SubItems.Add(dr("LotAdditionDt").ToString())
                lvi.SubItems.Add(dr("LotNo").ToString())
                lvi.SubItems.Add(dr("ItemId").ToString())
                lvi.SubItems.Add(dr("ItemName").ToString())
                lvi.SubItems.Add(dr("IssueWt").ToString())
                lvi.SubItems.Add(dr("IssuePr").ToString())
                lstLotAddition.Items.Add(lvi)
            End While

            If lstLotAddition.Items.Count > 0 Then
                lstLotAddition.Items(0).Selected = True
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            Objcn.Close()
        End Try

    End Sub
    Private Sub txtRemark_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtRemark.Validating
        Try
            If cmbGridItem.Text.Trim <> "" And Val(txtReceiveWt.Text.Trim) > 0 And Val(txtReceivePr.Text.Trim) > 0 Then
                If dgvLotAddition.Rows.Count > 0 AndAlso ChkDuplicate() = True Then
                    MsgBox("Duplicate Data")
                Else
                    Me.fillGrid()
                    Me.GridTotal()
                End If
            Else
                MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub fillGrid()

        If GridDoubleClick = False Then
            dgvLotAddition.Rows.Add(Val(txtSrNo.Text.Trim),
                                    Convert.ToInt32(cmbGridItem.SelectedValue),
                                    cmbGridItem.Text.Trim(),
                                    Format(Val(txtReceiveWt.Text.Trim), "0.000"),
                                    Format(Val(txtReceivePr.Text.Trim), "0.000"),
                                    Format(Val(txtFineWt.Text.Trim), "0.000"),
                                    txtRemark.Text.Trim(),
                                    txtReceivePr.Tag,
                                    txtFineWt.Tag)
            GetSrNo(dgvLotAddition)
        Else
            dgvLotAddition.Rows(TempRow).Cells(0).Value = txtSrNo.Text.Trim
            dgvLotAddition.Rows(TempRow).Cells(1).Value = cmbGridItem.Text.Trim
            dgvLotAddition.Rows(TempRow).Cells(2).Value = Format(Val(txtReceiveWt.Text.Trim), "0.000")
            dgvLotAddition.Rows(TempRow).Cells(3).Value = Format(Val(txtReceivePr.Text.Trim), "0.000")
            dgvLotAddition.Rows(TempRow).Cells(4).Value = Format(Val(txtReceivePr.Text.Trim), "0.000")
            dgvLotAddition.Rows(TempRow).Cells(5).Value = txtRemark.Text.Trim()
            GridDoubleClick = False
        End If

        'Me.GridTotal()

        dgvLotAddition.TableElement.ScrollToRow(dgvLotAddition.Rows.Last)

        txtSrNo.Text = dgvLotAddition.RowCount + 1

        txtReceiveWt.Clear()
        txtReceivePr.Clear()
        txtFineWt.Clear()
        txtRemark.Clear()
        cmbGridItem.Focus()

    End Sub
    Sub GetSrNo(ByRef grid As Telerik.WinControls.UI.RadGridView)
        Try
            For Each rowInfo As GridViewRowInfo In dgvLotAddition.Rows
                rowInfo.Cells(0).Value = rowInfo.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub VisibleDataGrid(ByVal blnStatus As Boolean)
        txtSrNo.Visible = blnStatus
        cmbGridItem.Visible = blnStatus
        txtReceiveWt.Visible = blnStatus
        txtReceivePr.Visible = blnStatus
        txtFineWt.Visible = blnStatus
        txtRemark.Visible = blnStatus
        dgvLotAddition.Visible = blnStatus
    End Sub
    Private Sub SaveData()
        Dim alParaval As New ArrayList

        Dim iOperationId As Integer = 7  ''Operation Id for Lot Addition Receive
        Dim iOperationTypeId As Integer = 10 ''Operation Type Id for Lot Addition Receive

        Dim GridSrNo As String = ""
        Dim ItemId As String = ""
        Dim ReceiveWt As String = ""
        Dim ReceivePr As String = ""
        Dim FineWt As String = ""
        Dim Remarks As String = ""

        Dim ItemType As String = Nothing
        Dim SlipBagNo As String = Nothing

        Dim IRowCount As Integer = 0
        Dim iValue As Integer = 0

        alParaval.Add(TransDt.Value.ToString())
        alParaval.Add(cmbItem.SelectedIndex)
        alParaval.Add(iOperationId)
        alParaval.Add(iOperationTypeId)
        alParaval.Add(cmbLotNo.Text.Trim)
        alParaval.Add(txtLotRecieveId.Text.Trim())
        alParaval.Add(txtFrKarigar.Tag)
        alParaval.Add(cmbTLabour.SelectedIndex)

        For Each row As GridViewRowInfo In dgvLotAddition.Rows
            If row.Cells(0).Value <> Nothing Then
                If GridSrNo = "" Then
                    GridSrNo = Val(row.Cells(0).Value)
                    ItemId = Val(row.Cells(1).Value)
                    ReceiveWt = Val(row.Cells(3).Value)
                    ReceivePr = Val(row.Cells(4).Value)
                    FineWt = Val(row.Cells(5).Value)
                    Remarks = (row.Cells(6).Value)
                    'ItemType = (row.Cells(7).Value)
                    'SlipBagNo = (row.Cells(8).Value)
                Else
                    GridSrNo = GridSrNo & "|" & Val(row.Cells(0).Value)
                    ItemId = ItemId & "|" & Val(row.Cells(1).Value)
                    ReceiveWt = ReceiveWt & "|" & Val(row.Cells(3).Value)
                    ReceivePr = ReceivePr & "|" & Val(row.Cells(4).Value)
                    FineWt = FineWt & "|" & Val(row.Cells(5).Value)
                    Remarks = Remarks & "|" & (row.Cells(6).Value)
                    'ItemType = ItemType & "|" & Val(row.Cells(7).Value)
                    'SlipBagNo = SlipBagNo & "|" & (row.Cells(8).Value)
                End If
            End If
            IRowCount += 1
        Next

        alParaval.Add(ItemId)
        alParaval.Add(ReceiveWt)
        alParaval.Add(ReceivePr)
        alParaval.Add(FineWt)
        alParaval.Add(Remarks)
        alParaval.Add(ItemType)
        alParaval.Add(SlipBagNo)
        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()

            With Hparameters
                .Add(dbManager.CreateParameter("@HLotAdditionDt", alParaval.Item(iValue), DbType.DateTime))
                iValue += 1
                .Add(dbManager.CreateParameter("@HItemId", alParaval.Item(iValue), DbType.Int16))
                iValue += 1
                .Add(dbManager.CreateParameter("@HOperationId ", alParaval.Item(iValue), DbType.Int16))
                iValue += 1
                .Add(dbManager.CreateParameter("@HOperationTypeId", alParaval.Item(iValue), DbType.Int16))
                iValue += 1

                .Add(dbManager.CreateParameter("@HLotNo", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@HLotAdditionNo", alParaval.Item(iValue), DbType.String))
                iValue += 1
                '.Add(dbManager.CreateParameter("@HChain", alParaval.Item(iValue), DbType.String))
                'iValue += 1
                '.Add(dbManager.CreateParameter("@HBhuka", alParaval.Item(iValue), DbType.String))
                'iValue += 1
                '.Add(dbManager.CreateParameter("@HSample", alParaval.Item(iValue), DbType.String))
                'iValue += 1
                .Add(dbManager.CreateParameter("@FrKarigarId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@ToKarigarId", alParaval.Item(iValue), DbType.String))
                iValue += 1

                .Add(dbManager.CreateParameter("@HCreatedBy", UserName.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@GridCount", IRowCount, DbType.Int16))
                .Add(dbManager.CreateParameter("@HIsOpening", 1, DbType.Boolean))

                ''For Transaction
                .Add(dbManager.CreateParameter("@TReceiveWt", lblGTotalReceiveWt.Text.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@TReceivePr", lblGTotalReceivePr.Text.Trim(), DbType.String))

                .Add(dbManager.CreateParameter("@TIssueWt", txtBalanceWt.Text.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@TIssuePr", txtBalancePr.Text.Trim(), DbType.String))
                ''For Transaction

                .Add(dbManager.CreateParameter("@DItemId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DRecieveWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DRecievePr", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DFineWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DRemarks", alParaval.Item(iValue), DbType.String))
                iValue += 1
                '.Add(dbManager.CreateParameter("@DItemType", alParaval.Item(iValue), DbType.String))
                'iValue += 1
                '.Add(dbManager.CreateParameter("@DSlipBagNo", alParaval.Item(iValue), DbType.String))
                'iValue += 1
            End With

            dbManager.Insert("SP_LotAdditionReceive_Save", CommandType.StoredProcedure, Hparameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally

        End Try
    End Sub
    Private Sub UpdateData()
        Dim alParaval As New ArrayList

        Dim iOperationId As Integer = 23  ''Opreatin Id for Lot Addition Receive

        Dim GridSrNo As String = ""
        Dim ItemId As String = ""
        Dim ReceivePr As String = ""
        Dim ReceiveWt As String = ""
        Dim FineWt As String = ""
        Dim Remarks As String = ""

        Dim IRowCount As Integer = 0
        Dim iValue As Integer = 0

        alParaval.Add(TransDt.Value.ToString())
        alParaval.Add(cmbItem.SelectedIndex)
        alParaval.Add(iOperationId)
        alParaval.Add(cmbLotNo.Text.Trim)
        'alParaval.Add(txtChain.Text)
        'alParaval.Add(txtBhuka.Text)
        'alParaval.Add(txtSample.Text)
        alParaval.Add(txtFrKarigar.Tag)
        alParaval.Add(cmbTLabour.SelectedIndex)

        For Each row As GridViewRowInfo In dgvLotAddition.Rows
            If row.Cells(0).Value <> Nothing Then
                If GridSrNo = "" Then
                    GridSrNo = Val(row.Cells(0).Value)
                    ItemId = Val(row.Cells(1).Value)
                    ReceiveWt = Val(row.Cells(3).Value)
                    ReceivePr = Val(row.Cells(4).Value)
                    FineWt = Val(row.Cells(5).Value)
                    Remarks = (row.Cells(6).Value)
                Else
                    GridSrNo = GridSrNo & "|" & Val(row.Cells(0).Value)
                    ItemId = ItemId & "|" & Val(row.Cells(1).Value)
                    ReceiveWt = ReceiveWt & "|" & Val(row.Cells(3).Value)
                    ReceivePr = ReceivePr & "|" & Val(row.Cells(4).Value)
                    FineWt = FineWt & "|" & Val(row.Cells(5).Value)
                    Remarks = Remarks & "|" & (row.Cells(6).Value)
                End If
            End If
            IRowCount += 1
        Next

        alParaval.Add(ItemId)
        alParaval.Add(ReceivePr)
        alParaval.Add(ReceiveWt)
        alParaval.Add(FineWt)
        alParaval.Add(Remarks)

        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()

            With Hparameters
                .Add(dbManager.CreateParameter("@HLotAdditionDt", alParaval.Item(iValue), DbType.DateTime))
                iValue += 1
                .Add(dbManager.CreateParameter("@HItemId", alParaval.Item(iValue), DbType.Int16))
                iValue += 1
                .Add(dbManager.CreateParameter("@HOperationId ", alParaval.Item(iValue), DbType.Int16))
                iValue += 1
                .Add(dbManager.CreateParameter("@HLotNumber", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@HChain", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@HBhuka", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@HSample", alParaval.Item(iValue), DbType.String))
                iValue += 1

                .Add(dbManager.CreateParameter("@HCreatedBy", UserName.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@GridCount", IRowCount, DbType.Int16))

                .Add(dbManager.CreateParameter("@DItemId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DRecieveWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DRecievePr", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DFineWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DRemarks", alParaval.Item(iValue), DbType.String))
                iValue += 1
            End With

            dbManager.Update("SP_LotAdditionReceive_Update", CommandType.StoredProcedure, Hparameters.ToArray())

            MessageBox.Show("Data Updated !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub txtReceivePr_Leave(sender As Object, e As EventArgs) Handles txtReceiveWt.Leave
        txtReceiveWt.Text = Format(Val(txtReceiveWt.Text), "0.000")
    End Sub
    Private Sub txtReceiveWt_KeyPress(sender As Object, e As KeyPressEventArgs)
        numdotkeypress(e, txtReceivePr, Me)
    End Sub
    Private Sub txtReceiveWt_Leave(sender As Object, e As EventArgs) Handles txtReceivePr.Leave
        If Val(txtReceiveWt.Text) > Val(txtReceiveWt.Tag) Then
            MessageBox.Show("Receipt Value Cannot be Greater than Issue Value!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            txtReceivePr.SelectAll()
            Exit Sub
        End If

        txtReceiveWt.Text = Format(Val(txtReceiveWt.Text), "0.000")
    End Sub
    Private Sub lstLotAddition_DoubleClick(sender As Object, e As EventArgs) Handles lstLotAddition.DoubleClick
        If lstLotAddition.Items.Count > 0 Then

            Dim LotIssueId As Integer = lstLotAddition.SelectedItems(0).SubItems(0).Text

            Fr_Mode = FormState.EStateMode

            Me.Clear_Form()

            fillHeaderFromListView(LotIssueId)

            fillLotIssueDetail(LotIssueId)

            Me.TabControl1.SelectedIndex = 0
        End If
    End Sub
    Private Sub fillHeaderFromListView(ByVal intRecieveId As Integer)

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@LId", CInt(intRecieveId), DbType.Int16))
            .Add(dbManager.CreateParameter("@ActionType", "FetchHeaderRecord", DbType.String))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader("SP_LotAdditionIssue_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

        If dr.Read = False Then
            Exit Sub
        Else
            txtLotRecieveId.Tag = dr.Item("LotAdditionId").ToString()
            TransDt.Text = dr.Item("LotAdditionDt").ToString
            ''cmbOperation.SelectedIndex = dr.Item("OperationId").ToString
            cmbLotNo.Text = dr.Item("LotNumber").ToString
        End If

        dr.Close()
        Objcn.Close()

        Exit Sub
ErrHandler:
        MsgBox(Err.Description, MsgBoxStyle.Critical)
    End Sub
    Private Function FetchAllRecords(ByVal intRecieveId As Integer) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@LId", CInt(intRecieveId), DbType.Int16))
                .Add(dbManager.CreateParameter("@ActionType", "FetchDetailRecord", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_LotAdditionIssue_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        If Not String.IsNullOrEmpty(txtLotRecieveId.Tag) Then

            Try

                Dim parameters = New List(Of SqlParameter)()
                parameters.Clear()

                With parameters
                    .Add(dbManager.CreateParameter("@LId", Val(txtLotRecieveId.Tag), DbType.Int16))
                End With

                dbManager.Delete("SP_LotAdditionReceive_Delete", CommandType.StoredProcedure, parameters.ToArray())

                MessageBox.Show("Data Deleted !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Me.Clear_Form()

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            End Try
        Else
            MessageBox.Show("Please Select A Record !!!")
        End If
    End Sub
    Private Sub getLastLotNoAmt()

        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        strSQL = Nothing
        strSQL = "SELECT * FROM udf_GetMaxLotTransNo('" & cmbLotNo.Text.Trim() & "') ORDER BY MaxTransId"

        With parameters
            .Add(dbManager.CreateParameter("@TLotNo", cmbLotNo.Text.Trim(), DbType.String))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader(strSQL, CommandType.Text, Objcn, parameters.ToArray())

        Try
            If dr.Read = False Then
                Exit Sub
            Else
                'txtIssueWt.Text = Format(Val(dr("ReceiveWt")), "0.00")
                'txtIssuePr.Text = Format(Val(dr("ReceivePr")), "0.00")
                'lblFineWt.Text = Format(Val(txtReceiveWt.Text) * Val(txtReceivePr.Text) / 100, "0.00")
                'txtFrKarigar.Tag = dr("ToLabourId").ToString()
                'txtFrKarigar.Text = dr("toKarigarName").ToString()
                'cmbItem.SelectedIndex = dr("ItemId").ToString()

                ''txtBalanceWt.Text = Format(Val(dr("ReceiveWt")), "0.00")
                ''txtBalancePr.Text = Format(Val(dr("ReceivePr")), "0.00")
                ''lblFineWt.Text = Format(Val(txtBalanceWt.Text) * Val(txtBalancePr.Text) / 100, "0.000")
                ''txtFrKarigar.Tag = dr("ToLabourId").ToString()
                ''txtFrKarigar.Text = dr("toKarigarName").ToString()
                ''cmbItem.SelectedIndex = dr("ItemId").ToString()
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            Objcn.Close()
        End Try
    End Sub
    Private Sub GenerateMaxLotNo()
        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        Dim strMaxLotNo As String = Nothing

        strSQL = ""
        strSQL = "SELECT TOP 1 MaxLotNo FROM vwGetMaxLotNo ORDER BY MaxLotNo DESC"

        Dim dr As SqlDataReader = dbManager.GetDataReader(strSQL, CommandType.Text, Objcn, parameters.ToArray())

        Try
            If dr.Read = False Then
                Exit Sub
            Else
                strMaxLotNo = dr("MaxLotNo")
                txtLotRecieveId.Text = IncrementString(strMaxLotNo)
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            Objcn.Close()
        End Try
    End Sub
    Private Function IncrementString(ByVal Sender As String) As String
        Dim Index As Integer
        For Item As Integer = Sender.Length - 1 To 0 Step -1
            Select Case Sender.Substring(Item, 1)
                Case "000" To "999"
                Case Else
                    Index = Item
                    Exit For
            End Select
        Next
        If Index = Sender.Length - 1 Then
            Return Sender & "1" '  Optionally throw an exception ?
        Else
            Dim x As Integer = Index + 1
            Dim value As Integer = Integer.Parse(Sender.Substring(x)) + 1
            Return Sender.Substring(0, x) & value.ToString()
        End If
    End Function
    Private Sub fillLabour()

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        parameters.Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))

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
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            Objcn.Close()
        End Try
    End Sub
    Private Function ChkDuplicate() As Boolean
        Dim exists As Boolean = False

        For Each itm As GridViewRowInfo In dgvLotAddition.Rows
            If itm.Cells(1).Value = Val(cmbGridItem.SelectedValue) Then
                exists = True
            End If
        Next

        Return exists

    End Function
    Private Sub fillLotIssueHeader(ByVal sLotNo As String)

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@LotNo", Convert.ToString(sLotNo), DbType.String))
            .Add(dbManager.CreateParameter("@ActionType", "FetchHeaderRecord", DbType.String))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader("SP_LotAdditionIssue_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

        If dr.HasRows = False Then
            Exit Sub
        Else
            dr.Read()
            txtLotRecieveId.Tag = dr.Item("LotAdditionId").ToString
            txtLotRecieveId.Text = dr.Item("LotAdditionNo").ToString
            cmbItem.SelectedIndex = dr.Item("ItemId").ToString

            txtBalanceWt.Text = dr.Item("IssueWt").ToString
            txtBalancePr.Text = dr.Item("IssuePr").ToString
            lblFineWt.Text = Format(Val(txtBalancePr.Text) * Val(txtBalanceWt.Text) / 100, "0.000")

            txtFrKarigar.Tag = dr.Item("FrKarigarId").ToString
            txtFrKarigar.Text = dr.Item("FrKarigar").ToString
            cmbTLabour.SelectedIndex = dr.Item("ToKarigarId").ToString
        End If

        dr.Close()
        Objcn.Close()

        Exit Sub
ErrHandler:
        MsgBox(Err.Description, MsgBoxStyle.Critical)
    End Sub
    Private Sub fillLotReceiveDetail(ByVal sLotNo As String)
        Dim dttable As New DataTable
        dttable = FetchAllRecords(CStr(sLotNo))

        For Each ROW As DataRow In dttable.Rows
            dgvReceive.Rows.Add(CStr(ROW("SrNo")), CStr(ROW("ItemName")), Format(Val(ROW("IssueWt")), "0.000"), Format(Val(ROW("IssuePr")), "0.000"))
            dgvIssue.Rows.Add(CStr(ROW("SrNo")), CStr(ROW("ItemName")), Format(Val(ROW("IssueWt")), "0.000"), Format(Val(ROW("IssuePr")), "0.000"))
        Next

        Me.GetSrNo(dgvLotAddition)

        dgvLotAddition.ReadOnly = True
    End Sub
    Private Sub fillLotIssueDetail(ByVal sLotNo As String)
        Dim dttable As New DataTable
        dttable = FetchAllRecords(CStr(sLotNo))

        For Each ROW As DataRow In dttable.Rows
            dgvLotAddition.Rows.Add(1, Val(ROW("ItemId")), CStr(ROW("ItemName")), Format(Val(ROW("IssuePr")), "0.000"), Format(Val(ROW("IssueWt")), "0.000"), Format(Val(ROW("FineWt")), "0.000"), CStr(ROW("Remarks")))
        Next

        Me.GetSrNo(dgvLotAddition)

        dgvLotAddition.ReadOnly = True
    End Sub
    Private Sub frmLotAdditionReceive_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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

            If (e.Alt AndAlso (e.KeyCode = Keys.S)) Then
                ' When Alt + S is pressed, the Click event for the print
                ' button is raised.
                btnSave().PerformClick()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub fillGridItemName()

        Dim dt As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FetchItemForLotReceive", DbType.String))
            .Add(dbManager.CreateParameter("@TLotNo", cmbLotNo.Text.Trim(), DbType.String))
        End With
        dt = dbManager.GetDataTable("SP_ItemMaster_Select", CommandType.StoredProcedure, parameters.ToArray())

        Try
            cmbGridItem.DataSource = Nothing

            With cmbGridItem
                .DataSource = dt
                .DisplayMember = "ItemName"
                .ValueMember = "ItemId"
                .Columns(1).TextAlignment = ContentAlignment.MiddleRight
                .Columns(2).TextAlignment = ContentAlignment.MiddleRight
                .Columns(3).TextAlignment = ContentAlignment.MiddleRight
                .Columns(4).TextAlignment = ContentAlignment.MiddleRight
                .Columns(5).IsVisible = False
                .Columns(6).IsVisible = False
                .AutoSizeDropDownToBestFit = True
                .BestFitColumns()
                .AutoFilter = True
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .NullText = "---Select---"
            End With

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
        End Try
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Call Clear_Form()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Testing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function FetchAllIssueRecords(ByVal strLotNo As String) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@LotNo", CStr(strLotNo), DbType.String))
                .Add(dbManager.CreateParameter("@ActionType", "FetchDetailRecord", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_LotAdditionIssue_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
    Private Function FetchAllReceiveRecords(ByVal strLotNo As String) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchDetailRecord", DbType.String))
                .Add(dbManager.CreateParameter("@LotNo", CStr(strLotNo), DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_LotAdditionIssue_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
    Private Sub fillReceiveData(ByVal sLotNo As String)
        Dim dttable As New DataTable
        dttable = FetchReceiveData(CStr(sLotNo))

        For Each Row As DataRow In dttable.Rows
            dgvReceive.Rows.Add(CStr(Row("SrNo")), CStr(Row("ItemName")), Format(Val(Row("ReceiveWt")), "0.000"), Format(Val(Row("ReceivePr")), "0.000"), Format(Val(Row("FineWt")), "0.000"))
        Next

        Me.GetSrNo(dgvReceive)
        dgvLotAddition.ReadOnly = True

    End Sub
    Private Sub fillIssueData(ByVal sLotNo As String)
        Dim dttable As New DataTable
        dttable = FetchIssueData(CStr(sLotNo))

        For Each Row As DataRow In dttable.Rows
            dgvIssue.Rows.Add(CStr(Row("SrNo")), CStr(Row("ItemName")), Format(Val(Row("IssueWt")), "0.000"), Format(Val(Row("IssuePr")), "0.000"), Format(Val(Row("FineWt")), "0.000"))
        Next

        Me.GetSrNo(dgvIssue)
        dgvLotAddition.ReadOnly = True

    End Sub
    Private Function FetchReceiveData(ByVal strLotNo As String) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchReceiveData", DbType.String))
                .Add(dbManager.CreateParameter("@LotNo", CStr(strLotNo), DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_LotAdditionReceive_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
    Private Function FetchIssueData(ByVal strLotNo As String) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@LotNo", CStr(strLotNo), DbType.String))
                .Add(dbManager.CreateParameter("@ActionType", "FetchIssueData", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_LotAdditionReceive_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
    Private Function FetchIssueDataById(ByVal iItemId As Integer) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchIssueData", DbType.String))
                .Add(dbManager.CreateParameter("@LotNo", CInt(iItemId), DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_LotAdditionReceive_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
    Private Sub fillGridWithIssuedItem(ByVal sLotNo As String, ByVal iItemId As Integer, ByVal dItemPr As Double)
        Dim dtIData As DataTable = New DataTable()

        Try
            Dim iparameters = New List(Of SqlParameter)()
            iparameters.Clear()

            With iparameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchIssueDataByItemId", DbType.String))
                .Add(dbManager.CreateParameter("@LotNo", Convert.ToString(sLotNo), DbType.String))
                .Add(dbManager.CreateParameter("@IId", Convert.ToInt16(iItemId), DbType.Int16))
                .Add(dbManager.CreateParameter("@IIssuePr", Convert.ToDouble(dItemPr), DbType.Double))
            End With

            dtIData = dbManager.GetDataTable("SP_LotAdditionReceive_Select", CommandType.StoredProcedure, iparameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub fillGridWithReceivedItem(ByVal sLotNo As String, ByVal iItemId As Integer, ByVal dItemPr As Double)
        Dim dtRData As DataTable = New DataTable()

        Try
            Dim iparameters = New List(Of SqlParameter)()
            iparameters.Clear()

            With iparameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchReceiveDataByItemId", DbType.String))
                .Add(dbManager.CreateParameter("@LotNo", Convert.ToString(sLotNo), DbType.String))
                .Add(dbManager.CreateParameter("@IId", Convert.ToInt16(iItemId), DbType.Int16))
                .Add(dbManager.CreateParameter("@IIssuePr", Convert.ToDouble(dItemPr), DbType.Double))
            End With

            dtRData = dbManager.GetDataTable("SP_LotAdditionReceive_Select", CommandType.StoredProcedure, iparameters.ToArray())

            If dtRData.Rows.Count > 0 Then
                dReceiveWt = dtRData.Rows(0)("RecieveWt").ToString()
            Else
                dReceiveWt = 0
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub dgvLotAddition_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvLotAddition.KeyDown
        Try
            If e.KeyCode = Keys.Delete And dgvLotAddition.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                If GridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                dgvLotAddition.Rows.RemoveAt(dgvLotAddition.CurrentRow.Index)

                Me.GridTotal()
                Me.GetSrNo(dgvLotAddition)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmbGridItem_KeyDown(sender As Object, e As KeyEventArgs)
        If cmbGridItem.Text.Length > 0 AndAlso (e.KeyData = Keys.Back OrElse e.KeyData = Keys.Delete) Then
            cmbGridItem.SelectedValue = Nothing
            e.Handled = True
        End If
    End Sub
    Private Sub cmbLotNo_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbLotNo.SelectedIndexChanged
        If cmbLotNo.Text.Trim <> "" Then
            Me.fillLotIssueHeader(cmbLotNo.Text.Trim())

            ''Fill Receive Data Start
            Me.fillReceiveData(cmbLotNo.Text.Trim())

            If dgvReceive.RowCount > 0 Then
                Me.GridReceiveTotal()
            End If
            ''Fill Receive Data End

            ''Fill Issue Data Start
            fillIssueData(cmbLotNo.Text.Trim())

            If dgvIssue.RowCount > 0 Then
                Me.GridIssueTotal()
            End If
            ''Fill Issue Data End

            Me.CalculateBalanceTotal()
        End If
    End Sub
    Private Sub cmbGridItem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGridItem.SelectedIndexChanged
        Dim dtRowCount As DataTable = CType(cmbGridItem.DataSource, DataTable)

        If dtRowCount.Rows.Count > 0 Then
            cmbGridItem.SelectedValue = CType(cmbGridItem.DataSource, DataTable).Rows(cmbGridItem.SelectedIndex).Item("ItemId").ToString()
            cmbGridItem.Text = CType(cmbGridItem.DataSource, DataTable).Rows(cmbGridItem.SelectedIndex).Item("ItemName").ToString()

            'txtReceivePr.Tag = CType(cmbGridItem.DataSource, DataTable).Rows(cmbGridItem.SelectedIndex).Item("ItemType").ToString()
            txtReceivePr.Text = CType(cmbGridItem.DataSource, DataTable).Rows(cmbGridItem.SelectedIndex).Item("IssuePr").ToString()

            txtReceiveWt.Tag = CType(cmbGridItem.DataSource, DataTable).Rows(cmbGridItem.SelectedIndex).Item("BalanceWt").ToString()
            txtReceiveWt.Text = CType(cmbGridItem.DataSource, DataTable).Rows(cmbGridItem.SelectedIndex).Item("BalanceWt").ToString()

            'txtFineWt.Tag = CType(cmbGridItem.DataSource, DataTable).Rows(cmbGridItem.SelectedIndex).Item("SlipBagNo").ToString()

            txtReceiveWt.Focus()
        End If
    End Sub
    Private Sub txtReceiveWt_TextChanged(sender As Object, e As EventArgs) Handles txtReceivePr.TextChanged
        Try
            txtFineWt.Text = Format((Val(txtReceiveWt.Text) * Val(txtReceivePr.Text)) / 100, "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtReceivePr_TextChanged(sender As Object, e As EventArgs) Handles txtReceiveWt.TextChanged
        Try
            txtFineWt.Text = Format((Val(txtReceiveWt.Text) * Val(txtReceivePr.Text)) / 100, "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtReceiveWt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtReceivePr.Validating
        Try
            If Val(txtReceiveWt.Text) > Val(txtReceiveWt.Tag) Then
                MsgBox("Receive Wt. Greater than Issue Wt")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub cmbGridItem_Click(sender As Object, e As EventArgs) Handles cmbGridItem.Click
        Me.fillGridItemName()
    End Sub
    Private Sub GridReceiveTotal()
        Try

            Dim dSumOfTotalReceivePr As Double = 0
            Dim dSumOfTotalReceiveWt As Double = 0
            Dim dSumOfTotalFineWt As Double = 0

            For Each row As GridViewRowInfo In dgvReceive.Rows
                dSumOfTotalReceiveWt += Convert.ToDecimal(row.Cells(2).Value)
                dSumOfTotalFineWt += Convert.ToDecimal(row.Cells(4).Value)
            Next

            If dgvReceive.RowCount > 0 Then
                lblGridRTotal.Text = Format(dSumOfTotalReceiveWt, "0.00")
                lblGridRFine.Text = Format(dSumOfTotalFineWt, "0.00")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub GridIssueTotal()
        Try
            Dim dSumOfTotalIssuePr As Double = 0
            Dim dSumOfTotalIssueWt As Double = 0
            Dim dSumOfTotalFineWt As Double = 0

            For Each row As GridViewRowInfo In dgvIssue.Rows
                dSumOfTotalIssueWt += Convert.ToDecimal(row.Cells(2).Value)
                dSumOfTotalFineWt += Convert.ToDecimal(row.Cells(4).Value)
            Next

            If dgvIssue.RowCount > 0 Then
                lblGridITotal.Text = Format(dSumOfTotalIssueWt, "0.00")
                lblGridIFine.Text = Format(dSumOfTotalFineWt, "0.00")
                'lblGridIPr.Text = Format(Val(lblGridIFine.Text) / Val(lblGridITotal.Text) * 100, "0.00")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmbTLabour_Enter(sender As Object, e As EventArgs) Handles cmbTLabour.Enter
        cmbTLabour.ShowDropDown()
    End Sub
    Private Sub cmbLotNo_Enter(sender As Object, e As EventArgs) Handles cmbLotNo.Enter
        cmbLotNo.ShowDropDown()
    End Sub
    Private Sub cmbTLabour_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbTLabour.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbGridItem.Focus()
            cmbGridItem.Select()
            cmbGridItem.BackColor = Color.LemonChiffon
        End If
    End Sub
    Private Sub CalculateBalanceTotal()
        Try
            Dim dSumOfTotalWt As Double = 0
            Dim dSumOfTotalFineWt As Double = 0

            If dgvIssue.RowCount > 0 OrElse dgvReceive.RowCount > 0 Then
                dSumOfTotalWt = Val(lblGridITotal.Text.Trim) - Val(lblGridRTotal.Text.Trim)
                dSumOfTotalFineWt = Val(lblGridIFine.Text.Trim) - Val(lblGridRFine.Text.Trim)
                txtBalanceWt.Text = Format(dSumOfTotalWt, "0.00")
                txtBalancePr.Text = Format((Val(dSumOfTotalFineWt) / Val(dSumOfTotalWt)) * 100, "0.00")
            Else
                txtBalanceWt.Text = Format(lblGridITotal.Text.Trim, "0.00")
                txtBalancePr.Text = Format((Val(dSumOfTotalFineWt) / Val(dSumOfTotalWt)) * 100, "0.00")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub GridTotal()
        Try

            Dim dSumOfTotalReceivePr As Double = 0
            Dim dSumOfTotalReceiveWt As Double = 0
            Dim dSumOfTotalFineWt As Double = 0

            For Each row As GridViewRowInfo In dgvLotAddition.Rows
                dSumOfTotalReceiveWt += Convert.ToDecimal(row.Cells(3).Value)
                dSumOfTotalReceivePr += Convert.ToDecimal(row.Cells(4).Value)
                dSumOfTotalFineWt += Convert.ToDecimal(row.Cells(5).Value)
            Next

            If dgvLotAddition.RowCount > 0 AndAlso dgvReceive.RowCount > 0 Then
                lblTotalReceiveWt.Text = Format(dSumOfTotalReceiveWt, "0.00")
                lblTotalReceivePr.Text = Format(dSumOfTotalReceivePr, "0.00")
                lblTotalFineWt.Text = Format(dSumOfTotalFineWt, "0.000")

                lbGlTotalFineWt.Text = Format(Val(lblGridIFine.Text) - (Val(lblTotalFineWt.Text) + Val(lblGridRFine.Text)), "0.00")
                lblGTotalReceiveWt.Text = Format(Val(lblGridITotal.Text) - (Val(lblTotalReceiveWt.Text) + Val(lblGridRTotal.Text)), "0.00")

                lblGTotalReceivePr.Text = Format(Val(lbGlTotalFineWt.Text) / Val(lblGTotalReceiveWt.Text) * 100, "0.00")
            Else
                lblTotalReceiveWt.Text = Format(dSumOfTotalReceiveWt, "0.00")
                lblTotalReceivePr.Text = Format(dSumOfTotalReceivePr, "0.00")
                lblTotalFineWt.Text = Format(dSumOfTotalFineWt, "0.000")

                lblGTotalReceiveWt.Text = Format(Val(lblGridITotal.Text) - Val(lblTotalReceiveWt.Text), "0.00")
                lbGlTotalFineWt.Text = Format(Val(lblGridIFine.Text) - Val(lblTotalFineWt.Text), "0.000")

                lblGTotalReceivePr.Text = Format(Val(lbGlTotalFineWt.Text) / Val(lblGTotalReceiveWt.Text) * 100, "0.00")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub Clear_Form()
        Try
            ObjEp.Clear()

            ''For Header Field Start
            txtLotRecieveId.Tag = ""
            txtLotRecieveId.Clear()
            TransDt.Value = DateTime.Now()

            'cmbGridItem.SelectedIndex = 0
            cmbItem.SelectedIndex = 0
            txtFrKarigar.Clear()
            cmbTLabour.SelectedIndex = 0

            ''cmbLotNo.Items.Clear()
            cmbLotNo.SelectedIndex = -1
            txtBalanceWt.Clear()
            txtBalancePr.Clear()

            ''For Header Field End

            ''For Detail Field Start
            txtSrNo.Text = 1

            cmbGridItem.Text = ""
            cmbGridItem.Enabled = True

            txtReceiveWt.Clear()
            txtReceivePr.Clear()

            txtBalanceWt.Clear()
            txtBalancePr.Clear()
            txtRemark.Clear()

            dgvLotAddition.RowCount = 0

            dgvIssue.RowCount = 0
            dgvReceive.RowCount = 0
            ''For Detail Field End

            ''For Calculation Label Start
            lblTotalReceivePr.Text = ""
            lblGTotalReceivePr.Text = ""

            lblTotalReceiveWt.Text = ""
            lblGTotalReceiveWt.Text = ""

            lblTotalFineWt.Text = ""
            lbGlTotalFineWt.Text = ""
            ''For Calculation Label End

            GridDoubleClick = False

            Me.bindListView()

            Fr_Mode = FormState.AStateMode

            TransDt.Focus()
            TransDt.Select()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Testing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Function Validate_Fields() As Boolean
        Try

            If Not dgvLotAddition.RowCount > 0 Then
                MessageBox.Show("Cannot Save Without Detail Information!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False
                Exit Function
            End If

            If cmbLotNo.Text.Trim() = "" Then
                MessageBox.Show("Enter Lot Number !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbLotNo.Focus()
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Sub cmbGridItem_GotFocus(sender As Object, e As EventArgs) Handles cmbGridItem.GotFocus
        'Me.cmbGridItem.MultiColumnComboBoxElement.ShowPopup()
    End Sub
End Class