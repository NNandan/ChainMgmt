Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmEditVBags
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState

    Dim strSQL As String = Nothing

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
                    '    Me.Lbl_Tran_Mode.Text = "NEW MODE"
                    '    Me.txtAccountName.BackColor = Color.LemonChiffon
                    Me.btnUpdate.Enabled = True
                    Me.btnUpdate.Text = "&Save"
                Case FormState.EStateMode
                    'Me.Lbl_Tran_Mode.Text = "EDIT MODE"
                    'Me.txtAccountName.BackColor = Color.LemonChiffon
                    Me.btnUpdate.Text = "&Update"
            End Select
        End Set
    End Property
    Private Sub cmbEBagtype_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbEBagtype.SelectedIndexChanged
        If Convert.ToInt32(cmbEBagtype.SelectedIndex) > 0 Then
            Me.FillVacuumBag()
        End If
    End Sub
    Private Sub frmEditVBags_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.EnbledBtn()
        Me.fillBagType()
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Call Clear_Form()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Testing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If IsExists() = False Then
            MessageBox.Show(String.Format("Cannot Delete Record.", Me.cmbRBagNo.Text))
            Me.cmbRBagNo.Focus()
            Exit Sub
        Else
            DeleteVacuumBagNo()
        End If
    End Sub
    Private Sub EnbledBtn()
        btnUpdate.Enabled = True
        btnCancel.Enabled = True
    End Sub
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If Not Validate_Fields() Then Exit Sub

        Try
            Me.UpdateVacuumBagNo()
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            Me.btnCancel_Click(sender, e)
        End Try
    End Sub
    Private Sub fillBagType()

        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FillVacuumBag", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_BagMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            cmbEBagtype.DataSource = Nothing
            cmbEBagtype.Items.Clear()

            'Insert the Default Item to DataTable.
            Dim row As DataRow = dt.NewRow()
            row(0) = 0
            row(1) = "---Select---"
            dt.Rows.InsertAt(row, 0)

            'Assign DataTable as DataSource.
            cmbEBagtype.DataSource = dt
            cmbEBagtype.DisplayMember = "ItemName"
            cmbEBagtype.ValueMember = "ItemId"
            cmbEBagtype.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub FillVacuumBag()
        Dim dt As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()
        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "GetVaccumData", DbType.String))
            .Add(dbManager.CreateParameter("@BId", Val(cmbEBagtype.SelectedValue), DbType.Int16))
        End With

        dt = dbManager.GetDataTable("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray())

        If dt.Rows.Count = 0 Then
            MessageBox.Show("No Data Exists !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            dgvVacuumBag.DataSource = dt
            dgvVacuumBag.EnableFiltering = True
            dgvVacuumBag.MasterTemplate.ShowFilteringRow = False
            dgvVacuumBag.MasterTemplate.ShowHeaderCellButtons = True

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally

        End Try
    End Sub
    Private Sub Clear_Form()
        Try

            '' For Header Field Start

            cmbEBagtype.SelectedIndex = 0
            cmbRBagNo.SelectedIndex = -1
            '' For Header Field End

            '' For Detail Field Start

            dgvVacuumBag.DataSource = Nothing

            '' For Detail Field End

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub UpdateVacuumBagNo()

        If dgvVacuumBag.Rows.Count > 0 Then

            Try

                Dim Dparameters = New List(Of SqlParameter)()
                Dparameters.Clear()

                For i As Integer = 0 To dgvVacuumBag.RowCount - 1
                    If dgvVacuumBag.Rows(i).Cells(0).Value = True And dgvVacuumBag.Rows(i).Cells(8).Value IsNot Nothing Then
                        With Dparameters
                            .Add(dbManager.CreateParameter("@ActionType", "UpdateBhukaData", DbType.String))
                            .Add(dbManager.CreateParameter("@BagSrNo", CStr(cmbRBagNo.Text.Trim()), DbType.String))
                            .Add(dbManager.CreateParameter("@TId", Val(dgvVacuumBag.Rows(i).Cells(8).Value), DbType.Int16))
                        End With

                        dbManager.Update("SP_EditBags_Update", CommandType.StoredProcedure, Dparameters.ToArray())
                    End If
                    Dparameters.Clear()
                Next

                MessageBox.Show("Bhuka Bag Updated !!!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            End Try

        End If
    End Sub
    Private Function Validate_Fields() As Boolean
        Dim iCount As Int16 = 0

        Try
            If cmbRBagNo.SelectedIndex = -1 Then
                MessageBox.Show("Select To Bag !", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbRBagNo.Focus()
                Return False
            End If

            iCount = CountCheckedRows()

            If Not iCount > 0 Then
                MessageBox.Show("Select Atleast One Row !", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                dgvVacuumBag.Focus()
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Function CountCheckedRows() As Int16
        Dim iCount As Integer = 0

        For Each row As GridViewRowInfo In dgvVacuumBag.Rows
            If row.Cells(0).Value = True Then
                iCount += 1
            End If
        Next

        Return iCount

    End Function
    Private Function IsExists() As Boolean
        Dim iCnt As Int16 = 0

        Try

            Using cmd As New SqlCommand("SP_CheckBagNo_Select", Objcn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@ActionType", "GetVaccumBagNo")
                cmd.Parameters.AddWithValue("@BagNo", CStr(cmbRBagNo.Text.Trim()))
                cmd.Parameters.Add("@Exists", SqlDbType.Int)
                cmd.Parameters("@Exists").Direction = ParameterDirection.Output
                Objcn.Open()
                cmd.ExecuteNonQuery()
                Objcn.Close()

                iCnt = cmd.Parameters("@Exists").Value

            End Using

            If iCnt = 1 Then
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function
    Private Sub DeleteVacuumBagNo()

        If dgvVacuumBag.Rows.Count > 0 Then

            Try

                Dim Dparameters = New List(Of SqlParameter)()
                Dparameters.Clear()

                For i As Integer = 0 To dgvVacuumBag.RowCount - 1
                    If dgvVacuumBag.Rows(i).Cells(0).Value = True And dgvVacuumBag.Rows(i).Cells(8).Value IsNot Nothing Then
                        With Dparameters
                            .Add(dbManager.CreateParameter("@ActionType", "DeleteBhukaData", DbType.String))
                            .Add(dbManager.CreateParameter("@BagNo", CStr(cmbRBagNo.Text.Trim()), DbType.String))
                            .Add(dbManager.CreateParameter("@TId", Val(dgvVacuumBag.Rows(i).Cells(8).Value), DbType.Int16))
                        End With

                        dbManager.Update("SP_EditBags_Delete", CommandType.StoredProcedure, Dparameters.ToArray())
                    End If
                    Dparameters.Clear()
                Next

                MessageBox.Show("Bhuka Bag Deleted !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            End Try

        End If
    End Sub
End Class