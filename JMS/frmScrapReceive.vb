Imports System.Data.SqlClient
Imports DataAccessHandler
Public Class frmScrapReceive
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState

    Dim dbManager As New SqlHelper()
    Dim Objcn As SqlConnection = New SqlConnection()

    ' Scrap LV SubItem Indexes ...
    Private Const mintExtraScrap_Dt_IDX As Integer = 1
    Private Const mintLabour_Id_IDX As Integer = 2
    Private Const mintLabour_Name_IDX As Integer = 3
    Private Const mintLot_Number_IDX As Integer = 4
    Private Const mintOperation_Id_IDX As Integer = 5
    Private Const mintGross_Wt_IDX As Integer = 6
    Private Const mintGross_Pr_IDX As Integer = 7
    Private Const mintCreated_By_IDX As Integer = 8

    Private Const mintRBSLot_IDX As Integer = 9
    Private Const mintRBMLot_IDX As Integer = 10
    Private Const mintRBMOp_IDX As Integer = 11
    Private Const mintCUST_ID_IDX As Integer = 12
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
                    CType(Me.ParentForm, frmMain).FormMode.Text = "Editd"
                    Me.btnSave.Text = "&Update"
                    Me.btnDelete.Enabled = True
            End Select
        End Set
    End Property
    Private Sub frmScrapReceive_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Clear_Form()

        TransDt.Select()

        Me.fillLabour()
        Me.fillOperation()
        Me.fillLotNo()

        Me.SetupCustLVCols()
        Me.LoadListView()

        txtReceiveBy.Text = UserName.ToString()

        RbSpecificLots.Checked = True

        Me.cmbLabour.AutoCompleteMode = AutoCompleteMode.Suggest
        Me.cmbOperation.AutoCompleteMode = AutoCompleteMode.Suggest
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
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Call Clear_Form()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Testing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not String.IsNullOrEmpty(txtTransId.Text) Then

            Try

                Dim parameters = New List(Of SqlParameter)()

                With parameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@SId", txtTransId.Text, DbType.Int16))
                End With

                dbManager.Delete("SP_ExtraScrap_Delete", CommandType.StoredProcedure, parameters.ToArray())

                MessageBox.Show("Data Deleted !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Me.Clear_Form()

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            End Try
        Else
            MessageBox.Show("Please Select A Record !!!")
        End If
    End Sub
    Private Sub txtWeight_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtWeight.KeyPress
        numdotkeypress(e, txtWeight, Me)
    End Sub
    Private Sub LoadListView()

        Dim objLI As ListViewItem

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader("SP_ExtraScrap_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

        If dr.HasRows = False Then
            ''MessageBox.Show("No Data Exists !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        lvwScrap.Items.Clear()

        Try

            While dr.Read

                objLI = New ListViewItem(ReplaceDBNull(dr("ExtraScrapDt").ToString()))
                objLI.SubItems.Add(ReplaceDBNull(dr("LabourId")))
                objLI.SubItems.Add(ReplaceDBNull(dr("LabourName")))
                objLI.SubItems.Add(ReplaceDBNull(dr("LotNumber")))
                objLI.SubItems.Add(ReplaceDBNull(dr("OperationId")))
                objLI.SubItems.Add(ReplaceDBNull(dr("OperationName")))
                objLI.SubItems.Add(ReplaceDBNull(dr("GrossWt")))
                objLI.SubItems.Add(ReplaceDBNull(dr("GrossPr")))
                objLI.SubItems.Add(ReplaceDBNull(dr("CreatedBy")))

                objLI.SubItems.Add(ReplaceDBNull(dr("RBSLot")))
                objLI.SubItems.Add(ReplaceDBNull(dr("RBMLot")))
                objLI.SubItems.Add(ReplaceDBNull(dr("RBMOp")))

                objLI.SubItems.Add(ReplaceDBNull(dr("ExtraScrapId")))
                lvwScrap.Items.Add(objLI)

            End While

        Catch ex As Exception

        End Try

        If lvwScrap.Items.Count > 0 Then
            lvwScrap.Items(0).Selected = True
        End If

    End Sub
    Private Sub RbSpecificLots_CheckedChanged(sender As Object, e As EventArgs) Handles RbSpecificLots.CheckedChanged
        EnbledDisabled()
    End Sub
    Private Sub RbMultipleLots_CheckedChanged(sender As Object, e As EventArgs) Handles RbMultipleLots.CheckedChanged
        EnbledDisabled()
    End Sub
    Private Sub RbMultipleOperations_CheckedChanged(sender As Object, e As EventArgs) Handles RbMultipleOperations.CheckedChanged
        EnbledDisabled()
    End Sub
    Private Sub SaveData()

        If RbSpecificLots.Checked = True Then
            If String.IsNullOrWhiteSpace(cmbOperation.Text.Trim()) Or Convert.ToInt32(cmbOperation.SelectedIndex) = -1 Then
                MessageBox.Show("Enter Operation !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbOperation.Focus()
            ElseIf String.IsNullOrEmpty(txtWeight.Text.Trim()) Then
                MessageBox.Show("Enter Weight !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtWeight.Focus()
            Else
                Dim parameters = New List(Of SqlParameter)()

                With parameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
                    .Add(dbManager.CreateParameter("@ExtraScrapDt", TransDt.Value.ToString(), DbType.DateTime))
                    .Add(dbManager.CreateParameter("@LabourId", cmbLabour.SelectedValue, DbType.Int16))
                    .Add(dbManager.CreateParameter("@LotNumber", cmbLotNo.Text.Trim, DbType.String))
                    .Add(dbManager.CreateParameter("@OperationId", cmbOperation.SelectedValue, DbType.Int16))
                    .Add(dbManager.CreateParameter("@GrossWt", txtWeight.Text.Trim(), DbType.String))
                    .Add(dbManager.CreateParameter("@GrossPr", txtPercent.Text.Trim(), DbType.String))
                    .Add(dbManager.CreateParameter("@CreatedBy", UserName.Trim(), DbType.String))

                    .Add(dbManager.CreateParameter("@RBSLot", RbSpecificLots.Checked, DbType.Boolean))
                    .Add(dbManager.CreateParameter("@RBMLot", RbMultipleLots.Checked, DbType.Boolean))
                    .Add(dbManager.CreateParameter("@RBMOp", RbMultipleOperations.Checked, DbType.Boolean))
                End With
                dbManager.Insert("SP_ExtraScrap_Save", CommandType.StoredProcedure, parameters.ToArray())

                MessageBox.Show("Data Saved !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        End If

        If RbMultipleLots.Checked = True Then
            If String.IsNullOrWhiteSpace(cmbLabour.Text.Trim()) Or Convert.ToInt32(cmbLabour.SelectedIndex) = -1 Then
                MessageBox.Show("Select Labour !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbLabour.Focus()
            ElseIf String.IsNullOrWhiteSpace(cmbOperation.Text.Trim()) Or Convert.ToInt32(cmbOperation.SelectedIndex) = -1 Then
                MessageBox.Show("Enter Operation !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbOperation.Focus()
            ElseIf String.IsNullOrEmpty(txtWeight.Text.Trim()) Then
                MessageBox.Show("Enter Weight !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtWeight.Focus()
            Else
                Dim parameters = New List(Of SqlParameter)()

                With parameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
                    .Add(dbManager.CreateParameter("@ExtraScrapDt", TransDt.Value.ToString(), DbType.DateTime))
                    .Add(dbManager.CreateParameter("@LabourId", cmbLabour.SelectedValue, DbType.Int16))
                    .Add(dbManager.CreateParameter("@OperationId", cmbOperation.SelectedValue, DbType.Int16))
                    .Add(dbManager.CreateParameter("@GrossWt", txtWeight.Text.Trim(), DbType.String))
                    .Add(dbManager.CreateParameter("@GrossPr", txtPercent.Text.Trim(), DbType.String))
                    .Add(dbManager.CreateParameter("@CreatedBy", UserName.Trim(), DbType.String))

                    .Add(dbManager.CreateParameter("@RBSLot", RbSpecificLots.Checked, DbType.Boolean))
                    .Add(dbManager.CreateParameter("@RBMLot", RbMultipleLots.Checked, DbType.Boolean))
                    .Add(dbManager.CreateParameter("@RBMOp", RbMultipleOperations.Checked, DbType.Boolean))
                End With

                dbManager.Insert("SP_ExtraScrap_Save", CommandType.StoredProcedure, parameters.ToArray())

                MessageBox.Show("Data Saved !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

        If RbMultipleOperations.Checked = True Then
            If String.IsNullOrEmpty(txtWeight.Text.Trim()) Then
                MessageBox.Show("Enter Weight !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtWeight.Focus()
            Else
                Dim parameters = New List(Of SqlParameter)()

                With parameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
                    .Add(dbManager.CreateParameter("@ExtraScrapDt", TransDt.Value.ToString(), DbType.DateTime))
                    .Add(dbManager.CreateParameter("@LabourId", cmbLabour.SelectedValue, DbType.Int16))
                    .Add(dbManager.CreateParameter("@GrossWt", txtWeight.Text.Trim(), DbType.String))
                    .Add(dbManager.CreateParameter("@GrossPr", txtPercent.Text.Trim(), DbType.String))
                    .Add(dbManager.CreateParameter("@CreatedBy", UserName.Trim(), DbType.String))

                    .Add(dbManager.CreateParameter("@RBSLot", RbSpecificLots.Checked, DbType.Boolean))
                    .Add(dbManager.CreateParameter("@RBMLot", RbMultipleLots.Checked, DbType.Boolean))
                    .Add(dbManager.CreateParameter("@RBMOp", RbMultipleOperations.Checked, DbType.Boolean))
                End With

                dbManager.Insert("SP_ExtraScrap_Save", CommandType.StoredProcedure, parameters.ToArray())

                MessageBox.Show("Data Saved !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

    End Sub
    Private Sub UpdateData()

        If RbSpecificLots.Checked = True Then
            If String.IsNullOrWhiteSpace(cmbOperation.Text.Trim()) Or Convert.ToInt32(cmbOperation.SelectedIndex) = -1 Then
                MessageBox.Show("Enter Operation !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbOperation.Focus()
            ElseIf String.IsNullOrEmpty(txtWeight.Text.Trim()) Then
                MessageBox.Show("Enter Weight !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtWeight.Focus()
            Else
                Dim parameters = New List(Of SqlParameter)()

                With parameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
                    .Add(dbManager.CreateParameter("@ExtraScrapDt", TransDt.Value.ToString(), DbType.DateTime))
                    .Add(dbManager.CreateParameter("@LabourId", cmbLabour.SelectedValue, DbType.Int16))
                    .Add(dbManager.CreateParameter("@LotNumber", cmbLotNo.Text.Trim, DbType.String))
                    .Add(dbManager.CreateParameter("@OperationId", cmbOperation.SelectedValue, DbType.Int16))
                    .Add(dbManager.CreateParameter("@GrossWt", txtWeight.Text.Trim(), DbType.String))
                    .Add(dbManager.CreateParameter("@GrossPr", txtPercent.Text.Trim(), DbType.String))
                    .Add(dbManager.CreateParameter("@CreatedBy", UserName.Trim(), DbType.String))

                    .Add(dbManager.CreateParameter("@RBSLot", RbSpecificLots.Checked, DbType.Boolean))
                    .Add(dbManager.CreateParameter("@RBMLot", RbMultipleLots.Checked, DbType.Boolean))
                    .Add(dbManager.CreateParameter("@RBMOp", RbMultipleOperations.Checked, DbType.Boolean))
                    .Add(dbManager.CreateParameter("@SId", txtTransId.Text, DbType.Int16))
                End With

                dbManager.Insert("SP_ExtraScrap_Save", CommandType.StoredProcedure, parameters.ToArray())

                MessageBox.Show("Data Updated !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

        If RbMultipleLots.Checked = True Then
            If String.IsNullOrWhiteSpace(cmbOperation.Text.Trim()) Or Convert.ToInt32(cmbOperation.SelectedIndex) = -1 Then
                MessageBox.Show("Enter Operation !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbOperation.Focus()
            ElseIf String.IsNullOrEmpty(txtWeight.Text.Trim()) Then
                MessageBox.Show("Enter Weight !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtWeight.Focus()
            Else
                Dim parameters = New List(Of SqlParameter)()
                parameters.Clear()

                With parameters
                    .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
                    .Add(dbManager.CreateParameter("@ExtraScrapDt", TransDt.Value.ToString(), DbType.DateTime))
                    .Add(dbManager.CreateParameter("@LabourId", cmbLabour.SelectedValue, DbType.Int16))
                    .Add(dbManager.CreateParameter("@OperationId", cmbOperation.SelectedValue, DbType.Int16))
                    .Add(dbManager.CreateParameter("@GrossWt", txtWeight.Text.Trim(), DbType.String))
                    .Add(dbManager.CreateParameter("@GrossPr", txtPercent.Text.Trim(), DbType.String))
                    .Add(dbManager.CreateParameter("@CreatedBy", UserName.Trim(), DbType.String))

                    .Add(dbManager.CreateParameter("@RBSLot", RbSpecificLots.Checked, DbType.Boolean))
                    .Add(dbManager.CreateParameter("@RBMLot", RbMultipleLots.Checked, DbType.Boolean))
                    .Add(dbManager.CreateParameter("@RBMOp", RbMultipleOperations.Checked, DbType.Boolean))
                    .Add(dbManager.CreateParameter("@SId", txtTransId.Text, DbType.Int16))
                End With

                dbManager.Insert("SP_ExtraScrap_Save", CommandType.StoredProcedure, parameters.ToArray())

                MessageBox.Show("Data Updated !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

        If RbMultipleOperations.Checked = True Then
            If String.IsNullOrWhiteSpace(cmbOperation.Text.Trim()) Or Convert.ToInt32(cmbOperation.SelectedIndex) = -1 Then
                MessageBox.Show("Enter Operation !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbOperation.Focus()
            ElseIf String.IsNullOrEmpty(txtWeight.Text.Trim()) Then
                MessageBox.Show("Enter Weight !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtWeight.Focus()
            Else
                Dim parameters = New List(Of SqlParameter)()
     
                With parameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
                    .Add(dbManager.CreateParameter("@ExtraScrapDt", TransDt.Value.ToString(), DbType.DateTime))
                    .Add(dbManager.CreateParameter("@LabourId", cmbLabour.SelectedValue, DbType.Int16))
                    .Add(dbManager.CreateParameter("@GrossWt", txtWeight.Text.Trim(), DbType.String))
                    .Add(dbManager.CreateParameter("@GrossPr", txtPercent.Text.Trim(), DbType.String))
                    .Add(dbManager.CreateParameter("@CreatedBy", UserName.Trim(), DbType.String))

                    .Add(dbManager.CreateParameter("@RBSLot", RbSpecificLots.Checked, DbType.Boolean))
                    .Add(dbManager.CreateParameter("@RBMLot", RbMultipleLots.Checked, DbType.Boolean))
                    .Add(dbManager.CreateParameter("@RBMOp", RbMultipleOperations.Checked, DbType.Boolean))
                    .Add(dbManager.CreateParameter("@SId", txtTransId.Text, DbType.Int16))
                End With

                dbManager.Insert("SP_ExtraScrap_Save", CommandType.StoredProcedure, parameters.ToArray())

                MessageBox.Show("Data Updated !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub
    Private Sub fillLotNo()
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchLotNo", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray(), Objcn)

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
    Private Sub fillLabour()

        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))
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

            ''Insert the Default Item to DataTable.
            Dim trow As DataRow = Cdt.NewRow()
            trow(0) = 0
            trow(1) = "---Select---"
            Cdt.Rows.InsertAt(trow, 0)

            cmbLabour.DataSource = Cdt
            cmbLabour.DisplayMember = "LabourName"
            cmbLabour.ValueMember = "LabourId"

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

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub EnbledDisabled()

        Select Case True
            Case RbSpecificLots.Checked
                TransDt.Enabled = True
                cmbLabour.Enabled = True
                txtReceiveBy.Enabled = True
                cmbOperation.Enabled = True
                cmbLotNo.Enabled = True
                txtWeight.Enabled = True
                txtPercent.Enabled = True
            Case RbMultipleLots.Checked
                TransDt.Enabled = True
                cmbLabour.Enabled = True
                txtReceiveBy.Enabled = True
                cmbOperation.Enabled = True
                cmbLotNo.Enabled = False
                txtWeight.Enabled = True
                txtPercent.Enabled = True
            Case RbMultipleOperations.Checked
                TransDt.Enabled = True
                cmbLabour.Enabled = True
                txtReceiveBy.Enabled = True
                cmbOperation.Enabled = False
                cmbLotNo.Enabled = False
                txtWeight.Enabled = True
                txtPercent.Enabled = True
        End Select
    End Sub
    Private Sub SetupCustLVCols()
        With lvwScrap
            .Items.Clear()
            With .Columns
                .Add("Scrap Dt", CInt(lvwScrap.Width * 0.15), HorizontalAlignment.Left)
                .Add("Labour Id", CInt(lvwScrap.Width * 0))
                .Add("Karigar", CInt(lvwScrap.Width * 0.2))
                .Add("LotNumber", CInt(lvwScrap.Width * 0.15))
                .Add("OperationId", CInt(lvwScrap.Width * 0))
                .Add("Operation", CInt(lvwScrap.Width * 0.15))
                .Add("GrossWt", CInt(lvwScrap.Width * 0.1), HorizontalAlignment.Right)
                .Add("GrossPr", CInt(lvwScrap.Width * 0.1), HorizontalAlignment.Right)
                .Add("CreatedBy", CInt(lvwScrap.Width * 0.18))

                .Add("Specific Lot", CInt(lvwScrap.Width * 0.1), HorizontalAlignment.Left)
                .Add("Multiple Lot", CInt(lvwScrap.Width * 0.1), HorizontalAlignment.Left)
                .Add("Multiple Operation", CInt(lvwScrap.Width * 0.18), HorizontalAlignment.Left)

                .Add("ScrapId", 0)
            End With
        End With
    End Sub
    Private Sub lvwScrap_DoubleClick(sender As Object, e As EventArgs) Handles lvwScrap.DoubleClick
        If lvwScrap.SelectedItems.Count = 0 Then Exit Sub

        Dim iScrapId As Integer = lvwScrap.SelectedItems(0).SubItems(12).Text

        Me.Clear_Form()

        Fr_Mode = FormState.EStateMode

        Me.bindListView(iScrapId)

        Me.TbScrapBags.SelectedIndex = 0
    End Sub
    Private Sub bindListView(ByVal iScrapId As Integer)
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchRecord", DbType.String))
            .Add(dbManager.CreateParameter("@SId", CInt(iScrapId), DbType.Int16))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader("SP_ExtraScrap_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

        If dr.HasRows = False Then
            Exit Sub
        Else
            dr.Read()
            txtTransId.Text = dr.Item("ExtraScrapId").ToString
            TransDt.Text = dr.Item("ExtraScrapDt").ToString
            cmbLabour.SelectedIndex = dr.Item("LabourId").ToString()
            cmbLotNo.Text = dr.Item("LotNumber").ToString()
            cmbOperation.SelectedIndex = dr.Item("OperationId").ToString()
            txtWeight.Text = dr.Item("GrossWt").ToString()
            txtPercent.Text = dr.Item("GrossPr").ToString()
            txtReceiveBy.Text = dr.Item("CreatedBy").ToString()

            RbSpecificLots.Checked = Convert.ToBoolean(dr.Item("RBSLot"))
            RbMultipleLots.Checked = Convert.ToBoolean(dr.Item("RBMLot"))
            RbMultipleOperations.Checked = Convert.ToBoolean(dr.Item("RBMOp"))
        End If

        dr.Close()
        Objcn.Close()

        Exit Sub
ErrHandler:
        MsgBox(Err.Description, MsgBoxStyle.Critical)
    End Sub
    Private Function FetchAllRecords() As DataTable

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_ExtraScrap_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub cmbLabour_Enter(sender As Object, e As EventArgs) Handles cmbLabour.Enter
        cmbLabour.ShowDropDown()
    End Sub
    Private Sub cmbOperation_Enter(sender As Object, e As EventArgs) Handles cmbOperation.Enter
        cmbOperation.ShowDropDown()
    End Sub
    Private Sub txtPercent_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPercent.KeyPress
        numdotkeypress(e, txtPercent, Me)
    End Sub
    Private Sub txtPercent_Leave(sender As Object, e As EventArgs) Handles txtPercent.Leave
        txtPercent.Text = Format(Val(txtPercent.Text), "0.00")
    End Sub
    Private Sub txtWeight_Leave(sender As Object, e As EventArgs) Handles txtWeight.Leave
        txtWeight.Text = Format(Val(txtWeight.Text), "0.00")
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub TbScrapBags_Click(sender As Object, e As EventArgs) Handles TbScrapBags.Click
        If TbScrapBags.SelectedIndex = 1 Then
            Me.LoadListView()
        End If
    End Sub
    Private Sub frmScrapReceive_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                If MsgBox("Wish To Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    CType(Me.ParentForm, frmMain).FormMode.Text = ""
                    Me.Close()
                End If
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
    Private Sub Clear_Form()
        Try
            txtTransId.Clear()
            cmbLabour.SelectedIndex = -1
            cmbOperation.SelectedIndex = -1
            cmbLotNo.SelectedIndex = -1
            txtWeight.Clear()
            txtPercent.Clear()

            Fr_Mode = FormState.AStateMode

            TransDt.Focus()
            TransDt.Select()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Testing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Function Validate_Fields() As Boolean

        Try
            If cmbLabour.SelectedIndex <= 0 Then
                MessageBox.Show("Select Karigar Name !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbLabour.Focus()
                Return False
            End If

            If FormState.AStateMode AndAlso String.IsNullOrEmpty(txtTransId.Text.Trim()) Then
                MessageBox.Show("Select Id !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
End Class