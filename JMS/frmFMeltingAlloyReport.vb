Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmFMeltingAlloyReport
    Dim strSQL As String = Nothing
    Dim TempRow As Integer

    Dim dbManager As New SqlHelper()
    Dim Objcn As SqlConnection = New SqlConnection()
    Private Sub cmbLotNo_SelectedIndexChanged(sender As Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles cmbLotNo.SelectedIndexChanged
        If cmbLotNo.SelectedIndex > 0 Then

            Dim iLotId As Integer = Val(cmbLotNo.SelectedValue)

            Me.Clear_Form()

            Me.fillHeaderFromListView(iLotId)

            Me.fillDetailsFromListView(iLotId)

            Me.TbMelting.SelectedIndex = 0
        End If
    End Sub
    Private Sub fillHeaderFromListView(ByVal intMeltingId As Integer)
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchHeaderRecord", DbType.String))
            .Add(dbManager.CreateParameter("@MId", CInt(intMeltingId), DbType.Int16))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader("SP_fMelting_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

        If dr.HasRows = False Then
            Exit Sub
        Else
            dr.Read()
            TransDt.Text = dr.Item("MeltingDt").ToString
            cmbLotNo.Text = dr.Item("LotNo").ToString()
            txtItem.Tag = dr.Item("ItemId").ToString
            txtItem.Text = dr.Item("ItemName").ToString
            txtMelting.Text = dr.Item("RequirePr").ToString()
            txtConvertToMelting.Text = dr.Item("ConvertToMelting").ToString()
            lblAlloyTotal.Text = dr.Item("GrossWt").ToString
            txtFrKarigar.Tag = dr.Item("FrKarigarId").ToString
            txtFrKarigar.Text = dr.Item("FrKarigar").ToString
            txtToKarigar.Tag = dr.Item("ToKarigarId").ToString
            txtToKarigar.Text = dr.Item("ToKarigar").ToString
        End If

        dr.Close()
        Objcn.Close()

        Exit Sub
ErrHandler:
        MsgBox(Err.Description, MsgBoxStyle.Critical)
    End Sub
    Private Sub fillDetailsFromListView(ByVal MeltingId As Integer)
        Dim dttable As New DataTable
        dttable = fetchAllFancys(CInt(MeltingId))

        For Each ROW As DataRow In dttable.Rows
            dgvMelting.Rows.Add(1, CStr(ROW("ItemType")), CStr(ROW("SlipBagNo")), Val(ROW("ItemBagId")), CStr(ROW("ItemName")), Format(Val(ROW("GrossWt")), "0.000"), Format(Val(ROW("GrossPr")), "0.000"), Format(Val(ROW("FineWt")), "0.000"))
        Next

        Me.GetSrNo(dgvMelting)
        Me.Total()

        dgvMelting.ReadOnly = True
    End Sub
    Private Function fetchAllFancys(ByVal intMeltingId As Integer) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@MId", CInt(intMeltingId), DbType.Int16))
                .Add(dbManager.CreateParameter("@ActionType", "FetchDetailRecord", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_fMelting_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
    Sub GetSrNo(ByRef grid As Telerik.WinControls.UI.RadGridView)
        Try
            For Each rowInfo As GridViewRowInfo In dgvMelting.Rows
                rowInfo.Cells(0).Value = rowInfo.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub Total()
        Dim dblTempTotal As Double = 0

        Try
            lblTotal.Text = 0.00
            lblAlloyTotal.Text = 0.00
            lblGrossTotal.Text = 0.00

            lblTotalFineWt.Text = 0.000

            For Each row As GridViewRowInfo In dgvMelting.Rows
                lblTotal.Text = Format(Val(lblTotal.Text) + Val(row.Cells(5).Value), "0.00")
                lblTotalFineWt.Text = Format(Val(lblTotalFineWt.Text) + Val(row.Cells(7).Value), "0.000")
                lblGrossTotal.Text = Format(Val(lblTotalFineWt.Text * 100) / Val(txtMelting.Text.Trim), "0.00")

                lblAlloyTotal.Text = Format(Val(lblGrossTotal.Text) - Val(lblTotal.Text), "0.00")
            Next

            lblTmpTotal.Text = Val(lblGrossTotal.Text * Val(txtConvertToMelting.Text)) / 100

            txtFineAdd.Text = Format(Val(lblTmpTotal.Text) - Val(lblTotalFineWt.Text), "0.00")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Clear_Form()
        Try

            '' For Header Field Start
            'cmbLotNo.SelectedIndex = 0
            TransDt.Value = DateTime.Now
            txtMelting.Clear()
            txtItem.Clear()

            txtFrKarigar.Tag = ""
            txtFrKarigar.Clear()

            txtToKarigar.Clear()
            txtFineAdd.Clear()

            '' For Header Field End

            '' For Detail Field Start
            txtConvertToMelting.Tag = ""
            txtConvertToMelting.Clear()

            dgvMelting.RowCount = 0

            '' For Detail Field End


            lblTotal.Text = 0.0
            lblAlloyTotal.Text = 0.0
            lblGrossTotal.Text = 0.0

            lblTotalFineWt.Text = 0.00

            txtFrKarigar.Tag = CInt(UserId)
            txtFrKarigar.Text = Convert.ToString(KarigarName.Trim)

            cmbLotNo.Focus()
            cmbLotNo.Select()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmMeltingAlloyReport_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.fillLotNo()
    End Sub
    Private Sub fillLotNo()
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchLotNoForReport", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_Melting_Select", CommandType.StoredProcedure, parameters.ToArray(), Objcn)
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
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            Objcn.Close()
        End Try
    End Sub
    Private Sub frmMeltingAlloyReport_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                If MsgBox("Wish To Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class