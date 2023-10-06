Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.IO
Imports DataAccessHandler
Imports Microsoft.Reporting.WinForms
Public Class frmRptViewer
    Dim dbManager As New SqlHelper()
    Dim Objcn As SqlConnection = New SqlConnection()
    Dim _LotNo As String
    Public Sub New(strLotNo As String)
        _LotNo = strLotNo

        InitializeComponent()
    End Sub
    Private Sub frmRptViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim rds1 As ReportDataSource = New ReportDataSource()

        rds1.Name = "DataSet_Report"
        rds1.Value = FetchAllRecords(_LotNo)

        '' Dynaimc Path
        Dim path As String = Directory.GetCurrentDirectory()
        Dim CRPath As String = path.Replace("\bin\Debug", "") & "\Reports\" & "RptReceipt.rdlc"
        ''
        ReportViewer1.LocalReport.ReportPath = CRPath
        ReportViewer1.LocalReport.DataSources.Clear()

        ReportViewer1.PrinterSettings.DefaultPageSettings.PaperSize = New PaperSize("Custom", 550, 275)

        ReportViewer1.LocalReport.DataSources.Add(rds1)

        ReportViewer1.RefreshReport()

        ReportViewer1.LocalReport.PrintToPrinter()
    End Sub
    Private Function FetchAllRecords(sLotNo As String) As DataTable
        Dim barcode As Zen.Barcode.Code128BarcodeDraw = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum

        Dim dtData As DataTable = New DataTable()
        Dim NewDt As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "PrintReceipt", DbType.String))
                .Add(dbManager.CreateParameter("@TLotNo", Trim(sLotNo), DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray())

            NewDt = dtData.Clone()

            Dim dcolColumn As DataColumn = New DataColumn("BarCode", GetType(System.Byte()))
            NewDt.Columns.Add(dcolColumn)

            Dim Img As Image = barcode.Draw(Trim(_LotNo), 20)
            'PictureBox1.Image = Img

            For Each sourcerow As DataRow In dtData.Rows
                Dim destRow As DataRow = NewDt.NewRow()
                destRow("TransactionId") = sourcerow("TransactionId")
                destRow("TransactionDt") = sourcerow("TransactionDt")
                destRow("LotNo") = sourcerow("LotNo")
                destRow("ItemName") = sourcerow("ItemName")
                destRow("ReceiveWt") = sourcerow("ReceiveWt")
                destRow("ReceivePr") = sourcerow("ReceivePr")
                destRow("LabourName") = sourcerow("LabourName")
                If Img IsNot Nothing Then
                    Dim ms As MemoryStream = New MemoryStream()
                    Img.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                    Dim imagedata As Byte() = ms.ToArray()
                    destRow("BarCode") = imagedata
                    'destRow("LotNo") = ms.ToArray()
                End If
                NewDt.Rows.Add(destRow)
            Next

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return NewDt

    End Function
End Class