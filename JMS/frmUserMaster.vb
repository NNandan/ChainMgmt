Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmUserMaster
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState

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
    Private Sub frmUserMaster_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.Clear_Form()

        If dtUserRights.Rows.Count > 0 Then
            Dim DTROW() As DataRow = dtUserRights.Select("FormName = 'USER MASTER'")
            USERADD = DTROW(0).Item(3)
            USEREDIT = DTROW(0).Item(4)
            USERVIEW = DTROW(0).Item(5)
            USERDELETE = DTROW(0).Item(6)

            If USEREDIT = False And USERDELETE = False Then
                MsgBox("Insufficient Rights")
                btnDelete.Enabled = False
            End If
        End If

        Me.fillDepartment()
        Me.fillLabour()

        dgvUserDetails.AutoGenerateColumns = False
        dgvUserDetails.DataSource = fetchAllRecords("SP_FormMaster_Select")

        Me.InitializeListView()
        Me.bindListview()

    End Sub
    Private Sub frmUserMaster_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                If MsgBox("Wish To Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
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
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not String.IsNullOrEmpty(cmbLabour.SelectedValue) Then

            If (MsgBox("[DELETION] Are You Sure To Delete This Entry ?", vbYesNo + vbDefaultButton2 + vbQuestion, "Attn : " + UserName.Trim()) = vbYes) Then

                Try
                    Dim parameters = New List(Of SqlParameter)()

                    With parameters
                        .Clear()
                        .Add(dbManager.CreateParameter("@UId", cmbLabour.SelectedValue, DbType.Int16))
                    End With

                    dbManager.Delete("SP_UserMaster_Delete", CommandType.StoredProcedure, parameters.ToArray())

                    MessageBox.Show("Record Deleted Successfully !!!")

                    Me.Clear_Form()

                Catch ex As Exception
                    MessageBox.Show("Error:- " & ex.Message)
                End Try
            End If
        Else
            MessageBox.Show("Please Select A Record !!!")
        End If
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If Not Validate_Fields() Then Exit Sub

        Try
            If Fr_Mode = FormState.AStateMode Then
                Me.SaveData()
            Else
                Me.UpdateData()
            End If

            Me.btnCancel_Click(sender, e)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Me.Clear_Form()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Testing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub chkAll_CheckStateChanged(sender As Object, e As EventArgs) Handles chkAll.CheckStateChanged
        If chkAll.Checked = True Then
            For Each row As GridViewRowInfo In dgvUserDetails.Rows
                row.Cells(1).Value = True
                row.Cells(2).Value = True
                row.Cells(3).Value = True
                row.Cells(4).Value = True
            Next
        Else
            For Each row As GridViewRowInfo In dgvUserDetails.Rows
                row.Cells(1).Value = False
                row.Cells(2).Value = False
                row.Cells(3).Value = False
                row.Cells(4).Value = False
            Next
        End If
    End Sub
    Private Sub fillLabour()

        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
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

            cmbLabour.DataSource = dt
            cmbLabour.DisplayMember = "LabourName"
            cmbLabour.ValueMember = "LabourId"

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub fillDepartment()

        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_DepartmentMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            ''Insert the Default Item to DataTable.
            Dim frow As DataRow = dt.NewRow()
            frow(0) = 0
            frow(1) = "---Select---"
            dt.Rows.InsertAt(frow, 0)

            ''Assign DataTable as DataSource.
            cmbDept.DataSource = dt
            cmbDept.DisplayMember = "DepartmentName"
            cmbDept.ValueMember = "DepartmentId"

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub SaveData()
        Dim alParaval As New ArrayList

        Dim IRowCount As Integer = 0
        Dim iValue As Integer = 0

        ''For Master
        alParaval.Add(cmbLabour.SelectedValue)
        alParaval.Add(cmbDept.SelectedValue)

        alParaval.Add(txtUserName.Text.Trim())
        alParaval.Add(txtPassword.Text)
        alParaval.Add(cmbUType.Text.Trim())

        Dim FORMNAME As String = ""
        Dim GADD As String = ""
        Dim GEDIT As String = ""
        Dim GVIEW As String = ""
        Dim GDELETE As String = ""

        ''For Details
        For Each row As GridViewRowInfo In dgvUserDetails.Rows

            If row.Cells(0).Value <> Nothing Then

                If FORMNAME = "" Then

                    FORMNAME = Convert.ToString(row.Cells(0).Value)

                    If Convert.ToBoolean(row.Cells("ChkAdd").Value) = False Then
                        GADD = "0"
                    Else
                        GADD = "1"
                    End If

                    If Convert.ToBoolean(row.Cells("ChkEdit").Value) = False Then
                        GEDIT = "0"
                    Else
                        GEDIT = "1"
                    End If

                    If Convert.ToBoolean(row.Cells("ChkView").Value) = False Then
                        GVIEW = "0"
                    Else
                        GVIEW = "1"
                    End If

                    If Convert.ToBoolean(row.Cells("ChkDelete").Value) = False Then
                        GDELETE = "0"
                    Else
                        GDELETE = "1"
                    End If
                Else
                    FORMNAME = FORMNAME & "|" & Convert.ToString(row.Cells(0).Value)

                    If Convert.ToBoolean(row.Cells(1).Value) = False Then
                        GADD = GADD & "|" & "0"
                    Else
                        GADD = GADD & "|" & "1"
                    End If

                    If Convert.ToBoolean(row.Cells(2).Value) = False Then
                        GEDIT = GEDIT & "|" & "0"
                    Else
                        GEDIT = GEDIT & "|" & "1"
                    End If

                    If Convert.ToBoolean(row.Cells(3).Value) = False Then
                        GVIEW = GVIEW & "|" & "0"
                    Else
                        GVIEW = GVIEW & "|" & "1"
                    End If

                    If Convert.ToBoolean(row.Cells(4).Value) = False Then
                        GDELETE = GDELETE & "|" & "0"
                    Else
                        GDELETE = GDELETE & "|" & "1"
                    End If
                End If
            End If
            IRowCount += 1
        Next

        alParaval.Add(FORMNAME)
        alParaval.Add(GADD)
        alParaval.Add(GEDIT)
        alParaval.Add(GVIEW)
        alParaval.Add(GDELETE)

        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()

            With Hparameters
                .Add(dbManager.CreateParameter("@UserId", alParaval.Item(iValue), DbType.String))
                iValue += 1

                .Add(dbManager.CreateParameter("@DeptId", alParaval.Item(iValue), DbType.String))
                iValue += 1

                .Add(dbManager.CreateParameter("@UserName", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@UserPass", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@UserType", alParaval.Item(iValue), DbType.String))
                iValue += 1

                ''.Add(dbManager.CreateParameter("@GridCount", IRowCount, DbType.Int16))
                .Add(dbManager.CreateParameter("@CreatedBy", UserName.Trim(), DbType.String))

                ''Details Start
                .Add(dbManager.CreateParameter("@FORMNAME", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@GADD", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@GEDIT", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@GVIEW", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@GDELETE", alParaval.Item(iValue), DbType.String))
                iValue += 1

            End With

            dbManager.Insert("SP_UserMaster_Save", CommandType.StoredProcedure, Hparameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub UpdateData()
        Dim alParaval As New ArrayList

        Dim IRowCount As Integer = 0
        Dim iValue As Integer = 0

        ''For Master

        alParaval.Add(txtUserName.Text.Trim())
        alParaval.Add(txtPassword.Text)
        alParaval.Add(cmbUType.Text.Trim())

        Dim FORMNAME As String = ""
        Dim GADD As String = ""
        Dim GEDIT As String = ""
        Dim GVIEW As String = ""
        Dim GDELETE As String = ""

        ''For Details
        For Each row As GridViewRowInfo In dgvUserDetails.Rows
            If row.Cells(0).Value <> Nothing Then

                If FORMNAME = "" Then

                    FORMNAME = Convert.ToString(row.Cells(0).Value)

                    If Convert.ToBoolean(row.Cells(1).Value) = False Then
                        GADD = "0"
                    Else
                        GADD = "1"
                    End If

                    If Convert.ToBoolean(row.Cells(2).Value) = False Then
                        GEDIT = "0"
                    Else
                        GEDIT = "1"
                    End If

                    If Convert.ToBoolean(row.Cells(3).Value) = False Then
                        GVIEW = "0"
                    Else
                        GVIEW = "1"
                    End If

                    If Convert.ToBoolean(row.Cells(4).Value) = False Then
                        GDELETE = "0"
                    Else
                        GDELETE = "1"
                    End If

                Else
                    FORMNAME = FORMNAME & "|" & Convert.ToString(row.Cells(0).Value)

                    If Convert.ToBoolean(row.Cells(1).Value) = False Then
                        GADD = GADD & "|" & "0"
                    Else
                        GADD = GADD & "|" & "1"
                    End If

                    If Convert.ToBoolean(row.Cells(2).Value) = False Then
                        GEDIT = GEDIT & "|" & "0"
                    Else
                        GEDIT = GEDIT & "|" & "1"
                    End If

                    If Convert.ToBoolean(row.Cells(3).Value) = False Then
                        GVIEW = GVIEW & "|" & "0"
                    Else
                        GVIEW = GVIEW & "|" & "1"
                    End If

                    If Convert.ToBoolean(row.Cells(4).Value) = False Then
                        GDELETE = GDELETE & "|" & "0"
                    Else
                        GDELETE = GDELETE & "|" & "1"
                    End If
                End If
            End If
            IRowCount += 1
        Next

        alParaval.Add(FORMNAME)
        alParaval.Add(GADD)
        alParaval.Add(GEDIT)
        alParaval.Add(GVIEW)
        alParaval.Add(GDELETE)

        alParaval.Add(UserId)

        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()

            With Hparameters
                .Add(dbManager.CreateParameter("@UserName", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@UserPass", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@UserType", alParaval.Item(iValue), DbType.String))
                iValue += 1

                .Add(dbManager.CreateParameter("@USERID", CInt(cmbLabour.SelectedValue), DbType.Int16))
                .Add(dbManager.CreateParameter("@CreatedBy", UserName.Trim(), DbType.String))

                ''Details Start
                .Add(dbManager.CreateParameter("@FORMNAME", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@GADD", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@GEDIT", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@GVIEW", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@GDELETE", alParaval.Item(iValue), DbType.String))
                iValue += 1

            End With

            dbManager.Insert("SP_UserMaster_Update", CommandType.StoredProcedure, Hparameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub InitializeListView()
        'CONSTRUCT COLUMNS
        With lvUserList
            .View = View.Details
            .LabelEdit = False
            .FullRowSelect = True
            .GridLines = True
            .Sorting = SortOrder.Ascending
            .Columns.Add("User Id", 0, HorizontalAlignment.Right)
            .Columns.Add("User Name", 110, HorizontalAlignment.Left)
            .Columns.Add("User Type", 110, HorizontalAlignment.Left)
            .Columns.Add("Department", 110, HorizontalAlignment.Left)
        End With
    End Sub
    Private Sub lvUserList_DoubleClick(sender As Object, e As EventArgs) Handles lvUserList.DoubleClick
        If lvUserList.SelectedItems.Count = 0 Then Exit Sub

        If lvUserList.Items.Count > 0 Then

            Dim iUserId As Integer = CInt(lvUserList.SelectedItems(0).SubItems(0).Text)

            Fr_Mode = FormState.EStateMode

            fillHeaderFromListView(iUserId)

            fillDetailsFromListView(iUserId)

            Me.TabControl1.SelectedIndex = 0
        End If
    End Sub
    Private Sub bindListview()
        Dim dtable As DataTable = fetchAllRecords("SP_UserMaster_Select")

        lvUserList.Items.Clear()

        For i As Integer = 0 To dtable.Rows.Count - 1
            Dim drow As DataRow = dtable.Rows(i)

            If drow.RowState <> DataRowState.Deleted Then
                Dim lvi As ListViewItem = New ListViewItem(drow("UserId").ToString())
                lvi.SubItems.Add(drow("UserName").ToString())
                lvi.SubItems.Add(drow("UserType").ToString())
                lvi.SubItems.Add(drow("departmentname").ToString())
                lvUserList.Items.Add(lvi)
            End If
        Next

    End Sub
    Private Function fetchAllRecords(ByVal strSpName As String) As DataTable

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))
            End With

            dtData = dbManager.GetDataTable(strSpName, CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Function FetchAllRecords(ByVal LabourId As Integer) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@UId", CInt(LabourId), DbType.Int16))
                .Add(dbManager.CreateParameter("@ActionType", "FetchUserRights", DbType.String))
            End With
            dtData = dbManager.GetDataTable("SP_UserMaster_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
    Private Sub cmbLabour_Enter(sender As Object, e As EventArgs) Handles cmbLabour.Enter
        cmbLabour.ShowDropDown()
    End Sub
    Private Sub cmbDept_Enter(sender As Object, e As EventArgs) Handles cmbDept.Enter
        cmbDept.ShowDropDown()
    End Sub
    Private Sub cmbUType_Enter(sender As Object, e As EventArgs) Handles cmbUType.Enter
        cmbUType.ShowDropDown()
    End Sub
    Private Sub fillHeaderFromListView(ByVal intUserId As Integer)

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@UId", CInt(intUserId), DbType.Int16))
            .Add(dbManager.CreateParameter("@ActionType", "FetchRecord", DbType.String))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader("SP_UserMaster_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

        If dr.HasRows = False Then
            Exit Sub
        Else
            dr.Read()
            cmbLabour.SelectedIndex = dr.Item("UserId").ToString()
            txtUserName.Text = dr.Item("UserName").ToString()
            txtPassword.Text = dr.Item("UserPass").ToString()
            txtConfirmPass.Text = dr.Item("UserPass").ToString()
            cmbDept.SelectedIndex = dr.Item("deptid").ToString
            cmbUType.Text = dr.Item("UserType").ToString
        End If

        dr.Close()
        Objcn.Close()

        Exit Sub
ErrHandler:
        MsgBox(Err.Description, MsgBoxStyle.Critical)
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub Btn_Find_Click(sender As Object, e As EventArgs) Handles Btn_Find.Click
        Try
            If Txt_Emp_ID.Text.Trim = "" Then
                Dim Sql As String
                Dim Colwidth As String = ""
                Colwidth = "150|75|200|200"
                Sql = "SELECT  Name, Patient_ID, [Family], Address, [Social-Security-No], City, State, Country FROM Get_Patient_Info_Vw"
                Call ShowSearchengine(Txt_Emp_ID, Sql, 1, "Name", Colwidth, , 0)
            End If

            'Validating Mandatory fields for locating
            If Txt_Emp_ID.Text.Trim = "" Then
                'MessageBox.Show("Invalid Employee ID,Please Check", Product_Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Txt_Emp_ID.Focus() : Exit Sub
            End If


            'If Locate_EmpDetails(Txt_Emp_ID.Text.Trim) Then
            '    If Locate_Userdetails(Txt_Emp_ID.Text.Trim) Then
            '        Tr_Mode = Tran_Mode.Edit_Mode
            '        Txt_Username.ReadOnly = True
            '        Txt_CurrPWD.Enabled = True
            '        Txt_CurrPWD.Focus()
            '    Else
            '        Txt_CurrPWD.Enabled = False
            '        Txt_Username.ReadOnly = False
            '        Txt_Username.Focus()
            '    End If

            'Else
            '    MessageBox.Show("Employee ID does not exists, Please Check", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub fillDetailsFromListView(ByVal intUserId As Integer)
        Dim dttable As New DataTable
        dttable = FetchAllRecords(CInt(intUserId))

        dgvUserDetails.DataSource = dttable

    End Sub
    Private Sub Clear_Form()
        Try
            cmbLabour.SelectedIndex = 0

            txtPassword.Clear()
            txtPassword.Tag = ""

            txtConfirmPass.Clear()
            txtConfirmPass.Tag = ""

            cmbUType.SelectedIndex = 0

            Fr_Mode = FormState.AStateMode

            cmbLabour.Focus()
            cmbLabour.Select()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Testing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Function Validate_Fields() As Boolean
        Try

            If Not dgvUserDetails.RowCount > 0 Then
                MessageBox.Show("Cannot Save Without Detail Information!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False
            End If

            If cmbLabour.SelectedIndex = 0 Then
                MessageBox.Show("Negative Cannot be Save !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbLabour.Focus()
                Return False
            End If

            If cmbUType.SelectedItem Is Nothing Then
                MessageBox.Show("Select Item Name !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbUType.Focus()
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
End Class