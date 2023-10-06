Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmNewLotNo
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState

    Dim strSQL As String = Nothing
    Dim TempRow As Integer

    Dim GridDoubleClick As Boolean

    Dim dbManager As New SqlHelper()
    Dim Objcn As SqlConnection = New SqlConnection()

    Private Objerr As New ErrorProvider()
    Public Sub New()
        InitializeComponent()
        'AddHandler cmbTLabour.PreviewKeyDown, AddressOf Me.cmbTLabour_PreviewKeyDown
    End Sub
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
                    lblLotNo.Visible = False
                    txtLotNo.Visible = False
                Case FormState.EStateMode
                    CType(Me.ParentForm, frmMain).FormMode.Text = "Edit"
                    Me.btnSave.Text = "&Update"
                    Me.btnDelete.Enabled = True
                    lblLotNo.Visible = True
                    txtLotNo.Visible = True
            End Select
        End Set
    End Property
    Private Sub frmNewLotNo_Load(sender As Object, e As EventArgs) Handles Me.Load
        fillOperation()
        fillAccounting()
        fillItemName()
        fillEmployee()
        fillParty()
        fillStamp()
        Me.Clear_Form()
        Me.ClearTreeDetails()
        TreeDetailsVisibleFalse()
    End Sub
    Private Sub TreeDetailsVisibleFalse()
        GrpTreeDetails.Visible = False
        lblTreeNo.Visible = False
        cmbTreeNo.Visible = False
        lblRecycleMetalPer.Visible = False
        txtRecycleMetalPer.Visible = False
        lblTreeMaterial.Visible = False
        lblConvFactor.Visible = False
        lblConvFactor.Visible = False
        txtConvFactor.Visible = False
        lblTreeWeight.Visible = False
        txtTreeWeight.Visible = False
        lblTotalGoldWt.Visible = False
        txtTotalGoldWt.Visible = False
    End Sub
    Private Sub TreeDetailsVisibleTrue()
        GrpTreeDetails.Visible = True
        lblTreeNo.Visible = True
        cmbTreeNo.Visible = True
        lblRecycleMetalPer.Visible = True
        txtRecycleMetalPer.Visible = True
        lblTreeMaterial.Visible = True
        lblConvFactor.Visible = True
        lblConvFactor.Visible = True
        txtConvFactor.Visible = True
        lblTreeWeight.Visible = True
        txtTreeWeight.Visible = True
        lblTotalGoldWt.Visible = True
        txtTotalGoldWt.Visible = True
        Me.FillTreeNo()
    End Sub
    Private Sub FillTreeNo()
        Dim connection As SqlConnection = Nothing
        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FetchTreeNo", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_TreeMaking_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim dt As DataTable = New DataTable()
        dt.Load(dr)
        Try
            ''Insert the Default Item to DataTable.
            Dim row As DataRow = dt.NewRow()
            row(0) = 0
            row(1) = "---Select---"
            dt.Rows.InsertAt(row, 0)
            'Assign DataTable as DataSource.
            cmbTreeNo.DataSource = dt
            cmbTreeNo.DisplayMember = "TreeNo"
            cmbTreeNo.ValueMember = "TreeMakingId"
            'Newly Added
            cmbTreeNo.Refresh()
            If cmbTreeNo.Items.Count > 0 Then cmbTreeNo.SelectedIndex = 0
            'Set AutoCompleteMode.
            cmbTreeNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbTreeNo.AutoCompleteDataSource = AutoCompleteSource.ListItems
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub fillOperation()

        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FillOperation", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_fOperationMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
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

            'Newly Added
            cmbOperation.Refresh()
            If cmbOperation.Items.Count > 0 Then cmbOperation.SelectedIndex = 0

            'Set AutoCompleteMode.
            cmbOperation.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbOperation.AutoCompleteDataSource = AutoCompleteSource.ListItems
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub fillAccounting()
        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FillMeltingCmb", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_MeltingMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), Objcn)

        Dim dt As DataTable = New DataTable()

        dt.Load(dr)
        Try
            'Insert the Default Item to DataTable.
            Dim row As DataRow = dt.NewRow()
            row(0) = 0
            row(1) = "---Select---"
            dt.Rows.InsertAt(row, 0)
            'Assign DataTable as DataSource.
            cmbMelting.DataSource = dt
            cmbMelting.DisplayMember = "MeltingValue"
            cmbMelting.ValueMember = "MeltingId"
            'Newly Added
            cmbMelting.Refresh()
            If cmbMelting.Items.Count > 0 Then cmbMelting.SelectedIndex = 0
            cmbMelting.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbMelting.AutoCompleteDataSource = AutoCompleteSource.ListItems
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
            .Add(dbManager.CreateParameter("@ActionType", "FillfItemCmb", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_ItemMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), Objcn)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            'Insert the Default Item to DataTable.
            Dim row As DataRow = dt.NewRow()
            row(0) = 0
            row(1) = "---Select---"
            dt.Rows.InsertAt(row, 0)

            'Assign DataTable as DataSource.
            cmbItemName.DataSource = dt
            cmbItemName.DisplayMember = "ItemName"
            cmbItemName.ValueMember = "ItemId"

            'Set AutoCompleteMode.
            cmbItemName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbItemName.AutoCompleteDataSource = AutoCompleteSource.ListItems
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            Objcn.Close()
        End Try
    End Sub
    Private Sub fillEmployee()
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FillLabour", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_LabourMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), Objcn)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            Dim row As DataRow = dt.NewRow()
            row(0) = 0
            row(1) = "---Select---"
            dt.Rows.InsertAt(row, 0)
            ''Insert the Default Item to DataTable.
            'Dim trow As DataRow = dt.NewRow()
            'trow(0) = 0
            'trow(1) = "---Select---"
            'dt.Rows.InsertAt(trow, 0)

            cmbTLabour.DataSource = dt
            cmbTLabour.DisplayMember = "LabourName"
            cmbTLabour.ValueMember = "LabourId"

            cmbTLabour.Refresh()
            If cmbTLabour.Items.Count > 0 Then cmbTLabour.SelectedIndex = 0

            'Set AutoCompleteMode.
            cmbTLabour.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbTLabour.AutoCompleteDataSource = AutoCompleteSource.ListItems
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
        End Try
    End Sub
    Private Sub fillParty()
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FillPartyCmb", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_PartyMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), Objcn)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            ''Insert the Default Item to DataTable.
            Dim trow As DataRow = dt.NewRow()
            trow(0) = 0
            trow(1) = "---Select---"
            dt.Rows.InsertAt(trow, 0)

            cmbParty.DataSource = dt
            cmbParty.DisplayMember = "PartyName"
            cmbParty.ValueMember = "PartyId"

            'Set AutoCompleteMode.
            cmbParty.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbParty.AutoCompleteDataSource = AutoCompleteSource.ListItems
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            Objcn.Close()
        End Try
    End Sub
    Private Sub fillStamp()
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FillStampCmb", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_StampMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), Objcn)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            ''Insert the Default Item to DataTable.
            Dim trow As DataRow = dt.NewRow()
            trow(0) = 0
            trow(1) = "---Select---"
            dt.Rows.InsertAt(trow, 0)

            cmbStamp.DataSource = dt
            cmbStamp.DisplayMember = "StampName"
            cmbStamp.ValueMember = "StampId"

            cmbStamp.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbStamp.AutoCompleteDataSource = AutoCompleteSource.ListItems
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            Objcn.Close()
        End Try
    End Sub
    Private Sub BindGridView()
        rdgvData.AutoGenerateColumns = False
        rdgvData.DataSource = fetchAllFancys()
        rdgvData.EnableFiltering = True
        rdgvData.MasterTemplate.ShowHeaderCellButtons = True
        rdgvData.MasterTemplate.ShowFilteringRow = False
        rdgvData.CurrentRow = Nothing
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim TmpLotNo As String
        Dim TmpOpId As Int16
        Dim TmpTransId As Int16
        Dim trans As SqlTransaction = Nothing

        If Objcn.State = ConnectionState.Open Then Objcn.Close()
        Objcn.Open()
        trans = Objcn.BeginTransaction(System.Data.IsolationLevel.Serializable)

        Try
            If Fr_Mode = FormState.AStateMode Then
                If Not Validate_Fields() Then Exit Sub
                If txtOpType.Tag = "7" Or txtOpType.Tag = "9" Then
                    If Not ValidateTree_Field() Then Exit Sub
                    Me.SaveTreeDetails()
                End If
                Dim DT As DataTable = Me.SaveData()
                Me.btnCancel_Click(sender, e)

                TmpLotNo = DT.Rows(0).Item(0)
                TmpOpId = DT.Rows(0).Item(1)
                TmpTransId = DT.Rows(0).Item(2)
                trans.Commit()
                MessageBoxTimer(TmpLotNo)
                Me.btnCancel_Click(sender, e)
            Else
                If Not EditValidate_Fields() Then Exit Sub
                Dim dttable As New DataTable
                dttable = fetchEmployeeId(CStr(cmbTLabour.Text.Trim))
                If dttable.Rows.Count > 0 Then
                    cmbTLabour.Tag = dttable.Rows(0).Item("LabourId").ToString()
                End If
                Dim DttableItm As New DataTable
                DttableItm = fetchItemId(CStr(cmbItemName.Text.Trim))
                If DttableItm.Rows.Count > 0 Then
                    cmbItemName.Tag = DttableItm.Rows(0).Item("ItemId").ToString()
                End If
                Me.UpdateData()
                If txtOpType.Tag = "7" Or txtOpType.Tag = "9" Then
                    If Not ValidateTree_Field() Then Exit Sub
                    Me.UpdateTreeDetails()
                End If
                Me.btnCancel_Click(sender, e)
            End If
        Catch ex As Exception
            trans.Rollback()
            MessageBox.Show("Error:- " & ex.Message)
        Finally
        End Try
    End Sub
    Private Function fetchEmployeeId(ByVal sBagNo As String) As DataTable
        Dim dtData As DataTable = New DataTable()
        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "fetchEmployeeId", DbType.String))
                .Add(dbManager.CreateParameter("@LName", cmbTLabour.SelectedItem.Text, DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_LabourMaster_Select", CommandType.StoredProcedure, parameters.ToArray())
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
        Return dtData
    End Function
    Private Function fetchItemId(ByVal ItemID As String) As DataTable
        Dim dtData As DataTable = New DataTable()
        Try
            Dim parameters = New List(Of SqlParameter)()
            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "fetchItemId", DbType.String))
                .Add(dbManager.CreateParameter("@IName", cmbItemName.Text, DbType.String))
            End With
            dtData = dbManager.GetDataTable("SP_ItemMaster_Select", CommandType.StoredProcedure, parameters.ToArray())
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
        Return dtData
    End Function
    Private Function SaveData() As DataTable
        Dim Dt As DataTable = Nothing
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()
            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
                .Add(dbManager.CreateParameter("@NNewLotDt", TransDt.Value.ToString(), DbType.DateTime))
                .Add(dbManager.CreateParameter("@NOperationId", Val(cmbOperation.SelectedValue), DbType.Int16))
                .Add(dbManager.CreateParameter("@NMeltingId", Val(cmbMelting.SelectedValue), DbType.Int16))
                .Add(dbManager.CreateParameter("@NLabourId", Val(cmbTLabour.SelectedValue), DbType.Int16))
                .Add(dbManager.CreateParameter("@NItemId", Val(cmbItemName.SelectedValue), DbType.Int16))
                .Add(dbManager.CreateParameter("@NPartyId", Val(cmbParty.SelectedValue), DbType.Int16))
                .Add(dbManager.CreateParameter("@NStampId", Val(cmbStamp.SelectedValue), DbType.Int16))
                .Add(dbManager.CreateParameter("@NOrderNo", Convert.ToString(txtOrderNo.Text.Trim), DbType.String))
                .Add(dbManager.CreateParameter("@NCreatedBy", UserName.Trim(), DbType.String))
            End With
            Dt = dbManager.GetDataTable("SP_NewLotNo_Save", CommandType.StoredProcedure, parameters.ToArray())
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            Cursor.Current = Cursors.Default
        End Try
        Return Dt
    End Function
    Private Sub UpdateData()

        Try
            Cursor.Current = Cursors.WaitCursor

            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "UpdateData", DbType.String))
                .Add(dbManager.CreateParameter("@NNewLotDt", TransDt.Value.ToString(), DbType.DateTime))


                .Add(dbManager.CreateParameter("@NMeltingId", Val(cmbMelting.SelectedIndex), DbType.Int16))
                .Add(dbManager.CreateParameter("@DMeltingName", Val(cmbMelting.Text), DbType.String))


                .Add(dbManager.CreateParameter("@NLabourId", Val(cmbTLabour.Tag), DbType.Int16))
                .Add(dbManager.CreateParameter("@DLabourName", Val(cmbTLabour.Text), DbType.String))

                .Add(dbManager.CreateParameter("@OpId", Val(cmbOperation.SelectedValue), DbType.Int16))
                .Add(dbManager.CreateParameter("@DOpeartionName", Val(cmbOperation.Text), DbType.String))


                .Add(dbManager.CreateParameter("@NItemId", cmbItemName.Tag, DbType.Int16))
                .Add(dbManager.CreateParameter("@DItemName", Val(cmbItemName.Text), DbType.String))

                .Add(dbManager.CreateParameter("@NPartyId", Val(cmbParty.SelectedValue), DbType.Int16))
                .Add(dbManager.CreateParameter("@DPartyName", Val(cmbParty.Text), DbType.String))

                .Add(dbManager.CreateParameter("@NStampId", Val(cmbStamp.SelectedValue), DbType.Int16))
                .Add(dbManager.CreateParameter("@DStampName", Val(cmbStamp.Text), DbType.String))

                .Add(dbManager.CreateParameter("@NOrderNo", Convert.ToString(txtOrderNo.Text.Trim), DbType.String))

                .Add(dbManager.CreateParameter("@NCreatedBy", UserName.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@NId", txtLotNo.Tag, DbType.Int16))
            End With

            dbManager.Update("SP_NewLotNo_Update", CommandType.StoredProcedure, parameters.ToArray())

            MessageBox.Show("Data Updated !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub
    Private Sub SaveTreeDetails()

        Try
            Cursor.Current = Cursors.WaitCursor

            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "UpdateTransId", DbType.String))
                .Add(dbManager.CreateParameter("@DMeltingName", Val(cmbMelting.Text), DbType.String))
                .Add(dbManager.CreateParameter("@ScrapPer", Val(txtRecycleMetalPer.Text), DbType.String))
                .Add(dbManager.CreateParameter("@ConvFactor", Val(txtConvFactor.Text), DbType.String))
                .Add(dbManager.CreateParameter("@TotalGNeed", Val(txtTotalGoldWt.Text), DbType.String))
                .Add(dbManager.CreateParameter("@TID", cmbTreeNo.SelectedValue, DbType.Int16))
            End With
            dbManager.Update("SP_TreeMakingTrans_Update", CommandType.StoredProcedure, parameters.ToArray())

            MessageBox.Show("Data Updated !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub
    Private Sub UpdateTreeDetails()
        Me.TransIdToNULL()
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "TransIdNullToUpdate", DbType.String))
                .Add(dbManager.CreateParameter("@DMeltingName", Val(cmbMelting.Text), DbType.String))
                .Add(dbManager.CreateParameter("@ScrapPer", Val(txtRecycleMetalPer.Text), DbType.String))
                .Add(dbManager.CreateParameter("@ConvFactor", Val(txtConvFactor.Text), DbType.String))
                .Add(dbManager.CreateParameter("@TotalGNeed", Val(txtTotalGoldWt.Text), DbType.String))
                .Add(dbManager.CreateParameter("@UTransId", Val(txtLotNo.Tag), DbType.String))
                .Add(dbManager.CreateParameter("@TID", cmbTreeNo.SelectedValue, DbType.Int16))
            End With
            dbManager.Update("SP_TreeMakingTrans_Update", CommandType.StoredProcedure, parameters.ToArray())

            MessageBox.Show("Data Updated !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub
    Private Sub TransIdToNULL()
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "UpdateTransIdNull", DbType.String))
                .Add(dbManager.CreateParameter("@TID", txtLotNo.Tag, DbType.Int16))
            End With
            dbManager.Update("SP_TreeMakingTrans_Update", CommandType.StoredProcedure, parameters.ToArray())
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Me.Clear_Form()
            Me.ClearTreeDetails()
            Me.TreeDetailsVisibleFalse()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ClearTreeDetails()
        cmbTreeNo.Text = ""
        cmbTreeNo.SelectedIndex = 0
        txtRecycleMetalPer.Text = ""
        txtTreeMaterial.Text = ""
        txtConvFactor.Text = ""
        txtTreeWeight.Text = ""
        txtTotalGoldWt.Text = ""
    End Sub
    Private Function ValidateTree_Field() As Boolean
        Try

            If cmbMelting.SelectedValue = 0 Then
                MessageBox.Show("Select Melting % !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False

            ElseIf cmbTreeNo.SelectedValue = 0 Then
                MessageBox.Show("Select Tree No !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False

            ElseIf txtTreeMaterial.Text.Trim.Length = 0 Then
                MessageBox.Show("Select Tree No Tree Material Empty Not Allow.!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False

            ElseIf txtTreeWeight.Text.Trim.Length = 0 Then
                MessageBox.Show("Select Tree No Tree Weight Empty Not Allow.!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False

            ElseIf txtConvFactor.Text.Trim.Length = 0 Then
                MessageBox.Show("Select Melting & TreeNo Conv Factor Empty Not Allow.!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False

            ElseIf txtTotalGoldWt.Text.Trim.Length = 0 Then
                MessageBox.Show("Select Melting & TreeNo TotalGold Needed Empty Not Allow.!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False
            End If

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

    End Function
    Private Function Validate_Fields() As Boolean
        Try

            If cmbMelting.SelectedValue = 0 Then
                MessageBox.Show("Select Melting % !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False

            ElseIf cmbOperation.SelectedValue = 0 Then
                MessageBox.Show("Select Operation Name !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False


            ElseIf cmbItemName.SelectedValue = 0 Then
                MessageBox.Show("Select Item Name !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False


            ElseIf cmbTLabour.SelectedValue = 0 Then
                MessageBox.Show("Select Employee Name !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False

            ElseIf txtOrderNo.Text.Trim.Length = 0 Then
                MessageBox.Show("Enter Order No. !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False


            ElseIf cmbParty.SelectedValue = 0 Then
                MessageBox.Show("Select Party Name !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False


            ElseIf cmbStamp.SelectedValue = 0 Then
                MessageBox.Show("Select Stamp Name !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False
            End If

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

    End Function
    Private Function EditValidate_Fields() As Boolean
        Try

            If cmbMelting.SelectedValue = 0 Then
                MessageBox.Show("Select Melting % !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False

            ElseIf cmbOperation.SelectedValue = 0 Then
                MessageBox.Show("Select Operation Name !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False


            ElseIf cmbItemName.SelectedValue = 0 Then
                MessageBox.Show("Select Item Name !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False


            ElseIf cmbTLabour.SelectedValue = 0 Then
                MessageBox.Show("Select Employee Name !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False

            ElseIf txtOrderNo.Text.Trim.Length = 0 Then
                MessageBox.Show("Enter Order No. !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False


            ElseIf cmbParty.SelectedValue = 0 Then
                MessageBox.Show("Select Party Name !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False


            ElseIf cmbStamp.SelectedValue = 0 Then
                MessageBox.Show("Select Stamp Name !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False
            End If

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

    End Function
    Private Sub Clear_Form()
        Try

            txtLotNo.Tag = ""
            txtLotNo.Clear()
            txtOpType.Tag = ""
            txtOpType.Clear()
            TransDt.Value = DateTime.Now
            txtOrderNo.Clear()
            btnSave.Text = "&Save"
            cmbOperation.SelectedIndex = 0
            cmbMelting.SelectedIndex = 0
            cmbTLabour.Text = ""
            cmbTLabour.SelectedIndex = 0
            cmbItemName.SelectedIndex = 0
            cmbItemName.Enabled = True
            cmbParty.SelectedIndex = 0
            cmbStamp.SelectedIndex = 2
            cmbMelting.Focus()
            cmbMelting.Select()
            Me.BindGridView()
            Fr_Mode = FormState.AStateMode
            Me.fillAccounting()
            Me.fillEmployee()
            Me.fillOperation()
            Me.fillItemName()
            Me.fillParty()
            Me.fillStamp()
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub txtOrderNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOrderNo.KeyPress
        numdotkeypress(e, txtOrderNo, Me)
    End Sub
    Private Sub cmbParty_LostFocus(sender As Object, e As EventArgs)
        btnSave.Focus()
    End Sub
    Private Sub cmbMelting_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbMelting.KeyDown
        If e.KeyCode = Keys.Tab Then
            cmbTLabour.Focus()
        End If
    End Sub
    Private Sub cmbTLabour_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Tab Then
            cmbOperation.Focus()
        End If
    End Sub
    Private Sub cmbOperation_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Tab Then
            TransDt.Focus()
        End If
    End Sub
    Private Sub TransDt_KeyDown(sender As Object, e As KeyEventArgs) Handles TransDt.KeyDown
        If e.KeyCode = Keys.Tab Then
            cmbItemName.Focus()
        End If
    End Sub
    Private Sub cmbItemName_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Tab Then
            txtOrderNo.Focus()
        End If
    End Sub
    Private Sub txtOrderNo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOrderNo.KeyDown
        If e.KeyCode = Keys.Tab Then
            cmbParty.Focus()
        End If
    End Sub
    Private Sub cmbParty_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Tab Then
            cmbStamp.Focus()
        End If
    End Sub
    Private Sub cmbStamp_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbStamp.KeyDown
        If e.KeyCode = Keys.Tab Then
            btnSave.Focus()
        End If
    End Sub
    Private Function fetchAllFancys() As DataTable
        Dim dtData As DataTable = New DataTable()
        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()
            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchListLotNotIssued", DbType.String))
            End With
            dtData = dbManager.GetDataTable("SP_NewLotNo_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
        Return dtData
    End Function
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not String.IsNullOrEmpty(txtLotNo.Tag) Then
            If (MsgBox("[DELETION] Are You Sure To Delete This Entry ?", vbYesNo + vbDefaultButton2 + vbQuestion, "Attn : " + UserName.Trim()) = vbYes) Then
                Try
                    Dim parameters = New List(Of SqlParameter)()
                    parameters.Clear()
                    With parameters
                        .Add(dbManager.CreateParameter("@NId", CInt(txtLotNo.Tag), DbType.Int16))
                    End With
                    dbManager.Delete("SP_NewLotNo_Delete", CommandType.StoredProcedure, parameters.ToArray())

                    MessageBox.Show("Data Deleted !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Me.btnCancel_Click(sender, e)
                Catch ex As Exception
                    MessageBox.Show("Error:- " & ex.Message)
                End Try
            End If
        End If
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub cmbOperation_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbOperation.SelectedIndexChanged
        Try
            Dim dt As DataTable = New DataTable()
            If cmbOperation.SelectedIndex > 0 Then
                Dim parameters = New List(Of SqlParameter)()

                With parameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@ActionType", "FetchOpType", DbType.String))
                    .Add(dbManager.CreateParameter("@OId", cmbOperation.SelectedValue, DbType.Int16))
                End With

                Dim dr As SqlDataReader = dbManager.GetDataReader("SP_fOperationMaster_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

                If dr.HasRows = True Then
                    dr.Read()
                    txtOpType.Text = dr.Item("OperationType").ToString
                    txtOpType.Tag = dr.Item("OperationTypeId").ToString
                    If txtOpType.Tag = "7" Or txtOpType.Tag = "9" Then
                        If Not CheckTreeNoExist() Then Exit Sub
                        If cmbMelting.SelectedIndex > 0 Then
                            Me.ClearTreeDetails()
                            Me.TreeDetailsVisibleTrue()
                        Else
                            MessageBox.Show("Melting Selection compulsory..!")
                            cmbOperation.Text = ""
                            cmbOperation.SelectedIndex = 0
                            txtOpType.Text = ""
                            cmbMelting.Focus()

                        End If
                    Else
                        Me.ClearTreeDetails()
                        Me.TreeDetailsVisibleFalse()
                    End If
                End If
                dr.Close()
                Objcn.Close()
                Exit Sub
ErrHandler:
                MsgBox(Err.Description, MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Function CheckTreeNoExist() As Boolean
        Try
            Dim dt As DataTable = New DataTable()
            If cmbOperation.SelectedIndex > 0 Then
                Dim parameters = New List(Of SqlParameter)()

                With parameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@ActionType", "CheckTreeNoExist", DbType.String))
                End With

                Dim dr As SqlDataReader = dbManager.GetDataReader("SP_TreeMaking_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

                If dr.HasRows = True Then
                    Return True
                Else
                    cmbOperation.Text = ""
                    txtOpType.Text = ""
                    cmbOperation.SelectedIndex = 0
                    MessageBox.Show("'TreeNo' Not Exist..!To Continue Create Tree..!")
                    Return False
                End If
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub rdgvData_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles rdgvData.CellDoubleClick
        Try
            If rdgvData.RowCount = 0 Then Exit Sub
            If rdgvData.RowCount > 0 Then
                Dim NewLotId As Integer = e.Row.Cells(0).Value
                Me.Clear_Form()
                Fr_Mode = FormState.EStateMode
                Me.fillHeaderFromDataView(NewLotId)
                Me.TbMelting.SelectedIndex = 0
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub fillHeaderFromDataView(ByVal iLotId As Integer)
        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchHeaderRecord", DbType.String))
                .Add(dbManager.CreateParameter("@NId", CInt(iLotId), DbType.Int16))
            End With

            Dim dr As SqlDataReader = dbManager.GetDataReader("SP_NewLotNo_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

            If dr.HasRows = False Then
                Exit Sub
            Else
                dr.Read()
                txtLotNo.Tag = dr.Item("NewLotId").ToString
                txtLotNo.Text = dr.Item("LotNo").ToString()
                TransDt.Text = dr.Item("NewLotDt").ToString
                cmbMelting.Text = ""
                cmbMelting.SelectedIndex = 0
                cmbMelting.SelectedIndex = dr.Item("meltingId").ToString
                txtOpType.Text = dr.Item("OperationType").ToString()
                cmbOperation.Text = ""
                cmbOperation.SelectedIndex = 0
                cmbOperation.SelectedIndex = dr.Item("OperationId").ToString
                cmbItemName.Text = ""
                cmbItemName.SelectedIndex = 0
                cmbItemName.SelectedIndex = dr.Item("ItemId").ToString
                cmbItemName.SelectedItem.Text = dr.Item("ItemName").ToString
                cmbTLabour.Text = ""
                cmbTLabour.SelectedIndex = 0
                cmbTLabour.SelectedIndex = dr.Item("LabourId").ToString
                cmbTLabour.SelectedItem.Text = dr.Item("LabourName").ToString
                cmbParty.Text = ""
                cmbParty.SelectedIndex = 0
                cmbParty.SelectedIndex = dr.Item("PartyId").ToString
                cmbStamp.Text = ""
                cmbStamp.SelectedIndex = 0
                cmbStamp.SelectedIndex = dr.Item("stampId").ToString
                txtOrderNo.Text = dr.Item("OrderNo").ToString
                txtOpType.Tag = dr.Item("OperationTypeId").ToString

                If txtOpType.Tag = "7" Or txtOpType.Tag = "9" Then
                    Me.ClearTreeDetails()
                    Me.TreeDetailsVisibleTrue()
                    Dim TransId As Integer = txtLotNo.Tag
                    Me.FetchHeaderCasting(TransId)
                Else
                    Me.ClearTreeDetails()
                    Me.TreeDetailsVisibleFalse()
                End If

            End If
            dr.Close()
            Objcn.Close()
            Exit Sub
ErrHandler:
            MsgBox(Err.Description, MsgBoxStyle.Critical)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FetchHeaderCasting(ByVal TransId As Integer)
        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchHeaderCasting", DbType.String))
                .Add(dbManager.CreateParameter("@TId", CInt(TransId), DbType.Int16))
            End With

            Dim dr As SqlDataReader = dbManager.GetDataReader("SP_TreeMaking_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

            If dr.HasRows = False Then
                Exit Sub
            Else
                dr.Read()
                txtLotNo.Tag = dr.Item("NewLotId").ToString
                txtLotNo.Text = dr.Item("LotNo").ToString()
                cmbTreeNo.Text = dr.Item("TreeNo").ToString()
                txtTreeMaterial.Tag = dr.Item("MaterialId").ToString()
                txtTreeMaterial.Text = dr.Item("MaterialName").ToString()
                txtTreeWeight.Text = dr.Item("TreeWt").ToString()
                txtRecycleMetalPer.Text = dr.Item("ScrapPer").ToString()
                txtConvFactor.Text = dr.Item("ConvFactor").ToString()
                txtTotalGoldWt.Text = dr.Item("TotalGoldNeed").ToString()
                'Me.FillTreeNo()
                'cmbTreeNo.SelectedIndex = dr.Item("TreeMakingId").ToString()
            End If
            dr.Close()
            Objcn.Close()
            Exit Sub
ErrHandler:
            MsgBox(Err.Description, MsgBoxStyle.Critical)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub frmNewLotNo_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                If MsgBox("Wish To Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                Me.SelectNextControl(Me.ActiveControl, True, True, True, False) 'for Select Next Control
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            End If

            If (e.Alt AndAlso (e.KeyCode = Keys.S)) Then
                btnSave().PerformClick()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub MessageBoxTimer(ByVal strMsg As String)
        Dim AckTime As Integer, InfoBox As Object
        InfoBox = CreateObject("WScript.Shell")
        'Set the message box to close after 1 seconds
        AckTime = 1
        'Select Case InfoBox.Popup("Click OK (Fancy Saved Successfully With New Lot Number = " & strMsg.ToString(),
        'AckTime, "Newly Created Lot Number", 0)
        '    Case 1, -1
        Select Case InfoBox.Popup("(New Lot Number " & strMsg.ToString() & " Is Saved Successfully", AckTime,, 0)
            Case 1, -1
                Exit Sub
        End Select
    End Sub
    Private Sub cmbMelting_GotFocus(sender As Object, e As EventArgs) Handles cmbMelting.GotFocus
        cmbMelting.ShowDropDown()
    End Sub
    Private Sub cmbMelting_PopupOpening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbMelting.PopupOpening
        Try
            Dim list As RadDropDownListElement = TryCast(sender, RadDropDownListElement)
            Dim width As Single = 0
            For x As Integer = 0 To list.Items.Count() - 1
                width = Math.Max(width, TextRenderer.MeasureText(list.Items(x).Text, list.Font).Width)
            Next
            If list.Items.Count * (list.ItemHeight - 1) > list.DropDownHeight Then
                width += list.ListElement.VScrollBar.Size.Width
            End If
            list.Popup.Width = CInt(width)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FillConvFactor()
        Try
            Dim dt As DataTable = New DataTable()
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchConvFactor", DbType.String))
                .Add(dbManager.CreateParameter("@MeltingId", cmbMelting.SelectedValue, DbType.String))
                .Add(dbManager.CreateParameter("@MaterialId", lblTreeMaterial.Tag, DbType.String))
            End With

            Dim dr As SqlDataReader = dbManager.GetDataReader("SP_TreeMaking_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

            If dr.HasRows = True Then
                dr.Read()
                txtConvFactor.Text = dr.Item("ConvPerFactor").ToString
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtTreeMaterial_TextChanged(sender As Object, e As EventArgs)
        Try
            If cmbTreeNo.SelectedIndex > 0 And txtRecycleMetalPer.Text > 0 Then
                Me.FillConvFactor()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub cmbTreeNo_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbTreeNo.SelectedIndexChanged
        Try
            If cmbTreeNo.SelectedIndex > 0 And cmbMelting.SelectedIndex > 0 Then
                Dim dt As DataTable = New DataTable()

                If cmbOperation.SelectedIndex > 0 Then

                    Dim parameters = New List(Of SqlParameter)()

                    With parameters
                        .Clear()
                        .Add(dbManager.CreateParameter("@ActionType", "FetchMaterialTreeWeight", DbType.String))
                        .Add(dbManager.CreateParameter("@TreeNo", cmbTreeNo.Text.Trim, DbType.String))
                    End With

                    Dim dr As SqlDataReader = dbManager.GetDataReader("SP_TreeMaking_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

                    If dr.HasRows = True Then
                        dr.Read()
                        lblTreeMaterial.Tag = dr.Item("MaterialId").ToString
                        txtTreeMaterial.Text = dr.Item("MaterialName").ToString
                        txtTreeWeight.Text = dr.Item("TreeWt").ToString
                        FillConvFactor()
                    End If
                    dr.Close()
                    Objcn.Close()

                    Exit Sub
ErrHandler:
                    MsgBox(Err.Description, MsgBoxStyle.Critical)

                End If

            Else

            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtConvFactor_TextChanged(sender As Object, e As EventArgs) Handles txtConvFactor.TextChanged
        Try
            If cmbMelting.SelectedIndex > 0 Then
                If Not txtConvFactor.Text.Trim = "" Then
                    txtTotalGoldWt.Text = Convert.ToInt32((txtTreeWeight.Text.ToString) * (txtConvFactor.Text.ToString))
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtRecycleMetalPer_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRecycleMetalPer.KeyPress
        Try
            If Asc(e.KeyChar) <> 8 Then
                If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                    e.Handled = True
                End If
            End If
            If Char.IsNumber(e.KeyChar) Then
                Dim newtext As String = txtRecycleMetalPer.Text.Insert(txtRecycleMetalPer.SelectionStart, e.KeyChar.ToString)
                If Not IsNumeric(newtext) OrElse CInt(newtext) > 100 OrElse CInt(newtext) < 0 Then e.Handled = True
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub cmbStamp_GotFocus(sender As Object, e As EventArgs) Handles cmbStamp.GotFocus
        cmbStamp.ShowDropDown()
    End Sub
    Private Sub cmbTLabour_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)
        If e.KeyCode = Keys.Return Then
            Text = Me.cmbTLabour.Text
        End If
    End Sub
    Private Sub cmbTLabour_GotFocus(sender As Object, e As EventArgs) Handles cmbTLabour.GotFocus
        cmbTLabour.ShowDropDown()
    End Sub
End Class