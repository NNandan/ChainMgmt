Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmVaccumBagByNumber
    Dim dbManager As New SqlHelper(ConfigurationManager.ConnectionStrings("ConString").ToString())
    Dim Objcn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("ConString").ToString())

    Dim strSQL As String = Nothing
    Private Sub frmVaccumBagByNumber_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.fillBagType()
    End Sub
    Private Sub fillBagType()

        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "GetVacuumBagForReport", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            cmbVacuumBag.DataSource = Nothing
            cmbVacuumBag.Items.Clear()

            'Insert the Default Item to DataTable.
            Dim row As DataRow = dt.NewRow()
            row(0) = 0
            row(1) = "---Select---"
            dt.Rows.InsertAt(row, 0)

            'Assign DataTable as DataSource.
            cmbVacuumBag.DataSource = dt
            cmbVacuumBag.DisplayMember = "VaccumeBagNo"
            cmbVacuumBag.ValueMember = "TransactionId"

            cmbVacuumBag.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbVacuumBag.AutoCompleteDataSource = AutoCompleteSource.ListItems
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try

    End Sub
    Private Sub cmbCBagtype_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbVacuumBag.SelectedIndexChanged
        If Convert.ToInt32(cmbVacuumBag.SelectedIndex) > 0 Then
            Me.BindVacuumBag()
        End If
    End Sub
    Private Sub BindVacuumBag()
        Dim dtdata As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "GetVacuumBagReport", DbType.String))
            .Add(dbManager.CreateParameter("@TId", Val(cmbVacuumBag.SelectedValue), DbType.Int16))
        End With

        dtdata = dbManager.GetDataTable("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray())

        Try
            With dgvVacuumBag
                .DataSource = dtdata
                .EnableFiltering = True
                .MasterTemplate.ShowFilteringRow = False
                .MasterTemplate.ShowHeaderCellButtons = True
            End With

            Dim totalLotNo As GridViewSummaryItem = New GridViewSummaryItem("colLotNumber", "Total", GridAggregateFunction.Count)

            Dim totalIssueWt As GridViewSummaryItem = New GridViewSummaryItem("colIssueWt", "{0}", GridAggregateFunction.Sum)
            Dim totalReceivePr As GridViewSummaryItem = New GridViewSummaryItem("colReceivePr", "{0}", GridAggregateFunction.Sum)

            Dim totalReceiveWt As GridViewSummaryItem = New GridViewSummaryItem("colReceiveWt", "{0}", GridAggregateFunction.Sum)
            Dim totalVacuumWt As GridViewSummaryItem = New GridViewSummaryItem("colVacuumWt", "{0}", GridAggregateFunction.Sum)

            Dim totalRow As GridViewSummaryRowItem = New GridViewSummaryRowItem(New GridViewSummaryItem() {totalLotNo, totalIssueWt, totalReceivePr, totalReceiveWt, totalVacuumWt})
            Me.dgvVacuumBag.SummaryRowsBottom.Add(totalRow)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
        End Try

    End Sub
    Private Sub frmVaccumBagByNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                If MsgBox("Wish To Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Me.Close()
            ElseIf e.KeyCode = Keys.Tab Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmbVacuumBag_Enter(sender As Object, e As EventArgs) Handles cmbVacuumBag.Enter
        cmbVacuumBag.ShowDropDown()
    End Sub
    Private Sub dgvVacuumBag_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs) Handles dgvVacuumBag.ViewCellFormatting
        If TypeOf e.Row Is GridViewSummaryRowInfo Then

            If e.Column.Name = "colLotNumber" Then
                e.CellElement.TextAlignment = ContentAlignment.MiddleLeft
            Else
                e.CellElement.TextAlignment = ContentAlignment.MiddleRight
            End If
        End If

        If TypeOf e.CellElement Is GridSummaryCellElement Then
            Dim summaryFont As Font = New Font("Tahoma", 9, FontStyle.Bold)
            e.CellElement.Font = summaryFont
        End If
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            If dgvVacuumBag.RowCount > 0 Then
                Me.Cursor = Cursors.WaitCursor

                Dim doc As New RadPrintDocument()
                doc.AssociatedObject = Me.dgvVacuumBag

                doc.LeftFooter = "Page [Page #] of [Total Pages]"
                doc.LeftHeader = "[Time Printed]"
                doc.MiddleFooter = "***"
                doc.MiddleHeader = "Report Name"
                doc.RightHeader = "[Date Printed]"

                Dim dialog As New RadPrintPreviewDialog(doc)
                dialog.WindowState = FormWindowState.Maximized

                dialog.ThemeName = Me.dgvVacuumBag.ThemeName
                dialog.ShowDialog()
            Else
                MessageBox.Show("No Data to Print")
            End If
        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
End Class