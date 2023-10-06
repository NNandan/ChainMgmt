Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Public Class frmFaBalancePendingBags
    Dim dbManager As New SqlHelper()
    Dim strSQL As String = Nothing
    Dim newFont = New Font("Arial", 12.0F, FontStyle.Bold)
    Private Sub frmBalancePendingBags_Load(sender As Object, e As EventArgs) Handles Me.Load
        With rdgbPendingRpt
            .AutoGenerateColumns = False
            .EnableFiltering = True
            .MasterTemplate.ShowHeaderCellButtons = True
            .MasterTemplate.ShowFilteringRow = False
            .CurrentRow = Nothing
        End With

        Dim totalLotNumber As GridViewSummaryItem = New GridViewSummaryItem("colItemName", "Total", GridAggregateFunction.Count)
        Dim totalReceiveWt As GridViewSummaryItem = New GridViewSummaryItem("colReceiveWt", "{0}", GridAggregateFunction.Sum)
        Dim totalFineWt As GridViewSummaryItem = New GridViewSummaryItem("colFineWt", "{0}", GridAggregateFunction.Sum)
        Dim totalUsedWt As GridViewSummaryItem = New GridViewSummaryItem("colUsedWt", "{0}", GridAggregateFunction.Sum)
        Dim totalBalancedWt As GridViewSummaryItem = New GridViewSummaryItem("colBalanceWt", "{0}", GridAggregateFunction.Sum)

        Dim totalReceivePr As GridViewSummaryItem = New GridViewSummaryItem("colReceivePr", "{0: 0.00}", GridAggregateFunction.None)
        totalReceivePr.AggregateExpression = "(Sum(colFineWt) / Sum(colReceiveWt)  * 100)"

        Dim totalRow As GridViewSummaryRowItem = New GridViewSummaryRowItem(New GridViewSummaryItem() {totalLotNumber, totalReceiveWt, totalReceivePr, totalFineWt, totalUsedWt, totalBalancedWt})
        Me.rdgbPendingRpt.SummaryRowsBottom.Add(totalRow)
        rdgbPendingRpt.DataSource = FetchReceiptData()

        Dim template1 As GridViewTemplate = New GridViewTemplate()

        template1.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill
        template1.DataSource = FetchUsedData()

        template1.BestFitColumns()

        template1.Columns(0).IsVisible = False

        template1.Columns(4).TextAlignment = ContentAlignment.MiddleRight
        template1.Columns(5).TextAlignment = ContentAlignment.MiddleRight

        template1.Columns(5).Width = 100

        Me.rdgbPendingRpt.MasterTemplate.Templates.Add(template1)

        Dim relation1 As GridViewRelation = New GridViewRelation(rdgbPendingRpt.MasterTemplate, template1)

        relation1.ChildTemplate = template1
        relation1.RelationName = "UsedBagIssue"
        relation1.ParentColumnNames.Add("colUsedBagId")
        relation1.ChildColumnNames.Add("UsedBagId")
        rdgbPendingRpt.Relations.Add(relation1)

        For Each item In rdgbPendingRpt.ChildRows
            EvaluateTotal(item)
        Next

        BuildHierarchy()
    End Sub
    Private Function FetchReceiptData() As DataTable

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "GetBagsData", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_fPendingBags_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Function FetchUsedData() As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "GetUsedData", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_PendingBags_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub EvaluateTotal(ByVal parent As GridViewRowInfo)
        'parent.Cells("colUsedWt").Value = rdgvPendingRpt.Evaluate("Sum(GrossWt)", parent.ChildRows)
    End Sub
    Private Sub BuildHierarchy()
        For Each item In rdgbPendingRpt.ChildRows
            EvaluateTotal(item)
        Next
    End Sub
    Private Sub rdgbPendingRpt_CellValueChanged(sender As Object, e As GridViewCellEventArgs) Handles rdgbPendingRpt.CellValueChanged
        If e.ColumnIndex = 8 AndAlso e.Column.OwnerTemplate IsNot Me.rdgbPendingRpt.MasterTemplate Then
            EvaluateTotal(CType(e.Row.Parent, GridViewRowInfo))
        End If
    End Sub
    Private Sub frmBalancePendingBags_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                If MsgBox("Wish To Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub rdgbPendingRpt_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs) Handles rdgbPendingRpt.ViewCellFormatting
        If TypeOf e.Row Is GridViewSummaryRowInfo Then

            If e.Column.Name = "colItemName" Then
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
End Class