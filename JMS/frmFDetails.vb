Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Imports System.Linq
Imports Telerik.WinControls.Data
Public Class frmFDetails
    Dim dbManager As New SqlHelper()
    Public Sub New()
        InitializeComponent()

    End Sub
    Private Sub frmDetails_Load(sender As Object, e As EventArgs) Handles Me.Load
        rdgvDetails.AutoGenerateColumns = False
        rdgvDetails.DataSource = FetchDetailsData()
        rdgvDetails.EnableFiltering = True
        rdgvDetails.MasterTemplate.ShowHeaderCellButtons = True
        rdgvDetails.MasterTemplate.ShowFilteringRow = False
        rdgvDetails.CurrentRow = Nothing
    End Sub
    Private Function FetchDetailsData() As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchNewLotDetails", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_NewLotNo_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        rdgvDetails.PrintPreview()
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class