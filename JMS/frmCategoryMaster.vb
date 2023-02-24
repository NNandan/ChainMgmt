Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Public Class frmCategoryMaster
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
    Private Sub frmCategoryMaster_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.Clear_Form()

        If dtUserRights.Rows.Count > 0 Then
            Dim DTROW() As DataRow = dtUserRights.Select("FormName = 'Category Master'")
            USERADD = DTROW(0).Item(3)
            USEREDIT = DTROW(0).Item(4)
            USERVIEW = DTROW(0).Item(5)
            USERDELETE = DTROW(0).Item(6)

            If USEREDIT = False And USERDELETE = False Then
                MsgBox("Insufficient Rights")
                btnDelete.Enabled = False
            End If
        End If

        txtCategoryName.Select()

        dgvCategoryList.DataSource = FetchAllRecords()
        dgvCategoryList.EnableFiltering = True
        dgvCategoryList.MasterTemplate.ShowHeaderCellButtons = True
        dgvCategoryList.MasterTemplate.ShowFilteringRow = False
        dgvCategoryList.CurrentRow = Nothing
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If Not Validate_Fields() Then Exit Sub

        Try

            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            If Fr_Mode = FormState.AStateMode Then

                If IsExists() = False Then
                    MessageBox.Show(String.Format("Category Name. {0} already exists.", Me.txtCategoryName.Text))
                    Me.txtCategoryName.Focus()
                    Exit Sub
                End If

                With parameters
                    .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
                    .Add(dbManager.CreateParameter("@CName", txtCategoryName.Text.Trim, DbType.String))
                    .Add(dbManager.CreateParameter("@CreatedBy", UserName.Trim(), DbType.String))
                End With
            Else
                With parameters
                    .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
                    .Add(dbManager.CreateParameter("@CId", txtCategoryName.Tag, DbType.Int16))
                    .Add(dbManager.CreateParameter("@CName", txtCategoryName.Text, DbType.String))
                    .Add(dbManager.CreateParameter("@CreatedBy", UserName.Trim(), DbType.String))
                End With
            End If

            dbManager.Insert("SP_CategoryMaster_Save", CommandType.StoredProcedure, parameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.btnCancel_Click(sender, e)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not String.IsNullOrEmpty(txtCategoryName.Tag) Then

            If (MsgBox("[DELETION] Are You Sure To Delete This Entry ?", vbYesNo + vbDefaultButton2 + vbQuestion, "Attn : " + UserName.Trim()) = vbYes) Then

                Try
                    Dim parameters = New List(Of SqlParameter)()
                    parameters.Clear()

                    With parameters
                        .Add(dbManager.CreateParameter("@CId", txtCategoryName.Tag, DbType.Int16))
                    End With

                    dbManager.Delete("SP_CategoryMaster_Delete", CommandType.StoredProcedure, parameters.ToArray())

                    MessageBox.Show("Data Deleted !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Me.btnCancel_Click(sender, e)

                Catch ex As Exception
                    MessageBox.Show("Error:- " & ex.Message)
                End Try
            Else
                MessageBox.Show("Please Select A Record !!!")
            End If

        End If
    End Sub
    Private Function FetchAllRecords() As DataTable

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_CategoryMaster_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Function FetchAllRecords(ByVal iCategoryId As Integer) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchRecord", DbType.String))
                .Add(dbManager.CreateParameter("@CId", CInt(iCategoryId), DbType.Int16))
            End With

            dtData = dbManager.GetDataTable("SP_CategoryMaster_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
    Private Function FetchAllRecords(ByVal sCategoryName As String) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "SearchRecord", DbType.String))
                .Add(dbManager.CreateParameter("@CName", CStr(sCategoryName), DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_CategoryMaster_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
    Private Sub txtCategoryName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCategoryName.KeyPress
        e.Handled = e.KeyChar <> ChrW(Keys.Back) And Not Char.IsSeparator(e.KeyChar) And Not Char.IsLetter(e.KeyChar)
    End Sub
    Private Sub txtCategoryName_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            btnSave.Select()
        End If
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Me.Clear_Form()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub dgvCategoryList_CellDoubleClick(sender As Object, e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles dgvCategoryList.CellDoubleClick
        If e.RowIndex >= 0 Then
            Fr_Mode = FormState.EStateMode
            txtCategoryName.Tag = dgvCategoryList.Rows(e.RowIndex).Cells(0).Value.ToString()
            txtCategoryName.Text = dgvCategoryList.Rows(e.RowIndex).Cells(1).Value.ToString()
        Else
            Me.Clear_Form()
        End If
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub txtCategoryName_Leave(sender As Object, e As EventArgs) Handles txtCategoryName.Leave
        txtCategoryName.Text = ToProper(txtCategoryName.Text)
    End Sub
    Private Sub frmCategoryMaster_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
    Private Sub Clear_Form()
        Try
            txtCategoryName.Tag = ""
            txtCategoryName.Clear()
            txtCategoryName.Focus()

            dgvCategoryList.DataSource = FetchAllRecords()

            Fr_Mode = FormState.AStateMode

            txtCategoryName.Select()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Function Validate_Fields() As Boolean
        Try

            If String.IsNullOrWhiteSpace(txtCategoryName.Text) Then
                MessageBox.Show("Enter Category Name !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtCategoryName.Focus()
                Return False
            End If
            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Function IsExists() As Boolean
        Try

            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "SearchDuplicate", DbType.String))
                .Add(dbManager.CreateParameter("@CName", CStr(txtCategoryName.Text.Trim), DbType.String))
            End With

            Dim strName As Object = dbManager.GetScalarValue("SP_CategoryMaster_Select", CommandType.StoredProcedure, parameters.ToArray())

            If Not IsNothing(strName) Then
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
End Class