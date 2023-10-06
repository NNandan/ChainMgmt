Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Public Class frmFaPendingVoucherRpt
    Dim dbManager As New SqlHelper()
    Dim strSQL As String = Nothing
    Dim newFont = New Font("Arial", 12.0F, FontStyle.Bold)
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Private Sub frmTest_Load(sender As Object, e As EventArgs) Handles Me.Load
        With rdgvPendingRpt
            .AutoGenerateColumns = False
            .EnableFiltering = True
            .MasterTemplate.ShowHeaderCellButtons = True
            .MasterTemplate.ShowFilteringRow = False
            .CurrentRow = Nothing
        End With

        rdgvPendingRpt.DataSource = FetchReceiptData()

        Dim template1 As GridViewTemplate = New GridViewTemplate()

        template1.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill
        template1.DataSource = FetchUsedData()

        template1.BestFitColumns()

        template1.Columns(0).IsVisible = False
        template1.Columns(1).IsVisible = False

        template1.Columns(5).TextAlignment = ContentAlignment.MiddleRight
        template1.Columns(6).TextAlignment = ContentAlignment.MiddleRight

        Me.rdgvPendingRpt.MasterTemplate.Templates.Add(template1)

        Dim relation1 As GridViewRelation = New GridViewRelation(rdgvPendingRpt.MasterTemplate, template1)

        relation1.ChildTemplate = template1

        relation1.RelationName = "ReceiptIssue"
        relation1.ParentColumnNames.Add("colReceiptDetailsId")
        relation1.ChildColumnNames.Add("ReceiptDetailsId")
        rdgvPendingRpt.Relations.Add(relation1)

        For Each item In rdgvPendingRpt.ChildRows
            EvaluateTotal(item)
        Next
    End Sub
    Private Function FetchReceiptData() As DataTable

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "GetReceiptData", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_fPendingVoucher_Select", CommandType.StoredProcedure, parameters.ToArray())

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
                parameters.Add(dbManager.CreateParameter("@ActionType", "GetUsedData", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_fPendingVoucher_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub EvaluateTotal(ByVal parent As GridViewRowInfo)
        'parent.Cells("colUsedWt").Value = rdgvPendingRpt.Evaluate("Sum(GrossWt)", parent.ChildRows)
    End Sub
    Private Sub BuildHierarchy()
        For Each item In rdgvPendingRpt.ChildRows
            EvaluateTotal(item)
        Next
    End Sub
    Private Sub rdgvPendingRpt_CellValueChanged(sender As Object, e As GridViewCellEventArgs) Handles rdgvPendingRpt.CellValueChanged
        If e.ColumnIndex = 8 AndAlso e.Column.OwnerTemplate IsNot Me.rdgvPendingRpt.MasterTemplate Then
            EvaluateTotal(CType(e.Row.Parent, GridViewRowInfo))
        End If
    End Sub
    Private Sub rdgvPendingRpt_GroupSummaryEvaluate(sender As Object, e As GroupSummaryEvaluationEventArgs) Handles rdgvPendingRpt.GroupSummaryEvaluate
        If TypeOf sender Is MasterGridViewTemplate Then
            Dim sum As Decimal = 0

            For Each masterRow As GridViewRowInfo In Me.rdgvPendingRpt.Rows
                Dim hierarchyRow As GridViewHierarchyRowInfo = TryCast(masterRow, GridViewHierarchyRowInfo)

                If hierarchyRow Is Nothing Then
                    Continue For
                End If

                For Each childRow As GridViewRowInfo In masterRow.ChildRows
                    sum += CDec(childRow.Cells("GrossWt").Value)
                Next
            Next

            e.FormatString = "Sum of all child rows: " & sum
        End If
    End Sub
    Private Sub rdgvPendingRpt_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs) Handles rdgvPendingRpt.ViewCellFormatting
        If TypeOf e.CellElement Is GridHeaderCellElement Then
            e.CellElement.SetThemeValueOverride(LightVisualElement.BackColorProperty, Color.LightGreen, "MouseOver")
            e.CellElement.SetThemeValueOverride(LightVisualElement.GradientStyleProperty, GradientStyles.Solid, "MouseOver")
        Else
            e.CellElement.ResetThemeValueOverride(LightVisualElement.BackColorProperty, "MouseOver")
            e.CellElement.ResetThemeValueOverride(LightVisualElement.GradientStyleProperty, "MouseOver")
        End If

    End Sub
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            If rdgvPendingRpt.RowCount > 0 Then
                Me.Cursor = Cursors.WaitCursor
                rdgvPendingRpt.PrintPreview()
            Else
                MessageBox.Show("No Data to Print")
            End If
        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class