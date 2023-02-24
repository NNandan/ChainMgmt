﻿Imports System.Data.SqlClient
Imports DataAccessHandler
Public Class frmStockSummary
    Dim rs As New ClsResizer
    Dim strSQL As String = Nothing
    Dim iRowCnt As Integer = 0

    Dim dbManager As New SqlHelper()
    Dim Objcn As SqlConnection = New SqlConnection()
    Private Sub frmStockSummaryRuntime_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.WindowState = FormWindowState.Maximized

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.GetWIPLots()
            Me.GetWIPMelting()
            Me.GetWIPLotTransfered()
            Me.GetFinishedLots()

            '' Bags Started
            Me.GetBhukaBagNotCreated()
            Me.GetVacuumBagNotCreated()
            Me.GetSampleBagNotCreated()

            Me.GetBhukaBagNotReceived()
            Me.GetVacuumBagNotReceived()
            Me.GetSampleBagNotReceived()
            Me.GetLotFailBagNotReceived()

            Me.GetBhukaBagNotUpdated()
            Me.GetVaccumBagNotUpdated()
            Me.GetSampleBagNotUpdated()
            Me.GetLotFailBagNotUpdated()

            Me.GetBhukaBagNotUsed()
            Me.GetVaccumBagNotUsed()
            Me.GetSampleBagNotUsed()
            Me.GetLotFailBagNotUsed()
            '' Bags Ended

            Me.GetVoucherMetalUnused()

            Me.GetLotAdditionStock()

            Me.GetLossBag()
            Me.GetLossTransaction()
            Me.GetLossLab()

            Me.GetMetalReceipt()
            Me.GetMetalIssue()

            Me.GetTxtTotal()

            ''Setting OpStock Value Start

            txtOpeningStockWt.Text = Format(OpGrossWt, "0.00")

            If Val(OpGrossPr) > 0 Then
                txtOpeningStockPr.Text = Format(OpGrossPr, "0.00")
            Else
                txtOpeningStockPr.Text = Format(0, "0.00")
            End If

            txtOpeningStockFw.Text = Format(OpGrossFw, "0.00")
            ''Setting OpStock Value End
        Catch ex As Exception

        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub
    Private Sub CreateGroupBoxForWIPLots()
        Dim groupBox1 As GroupBox = New GroupBox()
        groupBox1.SetBounds(460, 5, 320, 120)
        groupBox1.Text = "WIP (Work In Process)"
        Me.Controls.Add(groupBox1)

        Dim lblWipLots As New Label
        lblWipLots.Name = "lblWipLots"
        lblWipLots.Text = "Wip Lots"
        lblWipLots.AutoSize = True
        lblWipLots.Location = New Point(65, 26)
        groupBox1.Controls.Add(lblWipLots)

        Dim WipLGrossWt As New TextBox
        WipLGrossWt.Name = "WipLGrossWt"
        WipLGrossWt.Size = New Size(55, 20)
        WipLGrossWt.Location = New Point(121, 22)
        groupBox1.Controls.Add(WipLGrossWt)

        Dim WipLGrossPr As New TextBox
        WipLGrossPr.Name = "WipLGrossPr"
        WipLGrossPr.Size = New Size(55, 20)
        WipLGrossPr.Location = New Point(178, 22)
        groupBox1.Controls.Add(WipLGrossPr)

        Dim WipLGrossFw As New TextBox
        WipLGrossFw.Name = "WipLGrossFw"
        WipLGrossFw.Size = New Size(55, 20)
        WipLGrossFw.Location = New Point(235, 22)
        groupBox1.Controls.Add(WipLGrossFw)

        Dim lblWipMelting As New Label
        lblWipMelting.Name = "WIPMelting"
        lblWipMelting.Text = "WIP Melting"
        lblWipMelting.AutoSize = True
        lblWipMelting.Location = New Point(45, 46)
        groupBox1.Controls.Add(lblWipMelting)

        Dim WipMGrossWt As New TextBox
        WipMGrossWt.Name = "WipMGrossWt"
        WipMGrossWt.Size = New Size(55, 20)
        WipMGrossWt.Location = New Point(121, 43)
        groupBox1.Controls.Add(WipMGrossWt)

        Dim WipMGrossPr As New TextBox
        WipMGrossPr.Name = "WipMGrossPr"
        WipMGrossPr.Size = New Size(55, 20)
        WipMGrossPr.Location = New Point(178, 43)
        groupBox1.Controls.Add(WipMGrossPr)

        Dim WipMGrossFine As New TextBox
        WipMGrossFine.Name = "WipMGrossFine"
        WipMGrossFine.Size = New Size(55, 20)
        WipMGrossFine.Location = New Point(235, 43)
        groupBox1.Controls.Add(WipMGrossFine)

        Dim lblWipLotTransferred As New Label
        lblWipLotTransferred.Name = "lblWipLotTransferred"
        lblWipLotTransferred.Text = "WIP Lots Transferred"
        lblWipLotTransferred.AutoSize = True
        lblWipLotTransferred.Location = New Point(7, 68)
        groupBox1.Controls.Add(lblWipLotTransferred)

    End Sub
    Private Sub GetWIPLots()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "WIPLotsDetails", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_StockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If row.RowState <> DataRowState.Deleted Then
                        If Not IsDBNull(row("ReceiveWt")) Then
                            sRWtTotal += Single.Parse(row("ReceiveWt"))
                        End If

                        If Not IsDBNull(row("FineWt")) Then
                            sFWtTotal += Single.Parse(row("FineWt"))
                        End If
                    End If
                Next

                If Not sFWtTotal = 0 Then
                    sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.00")
                End If

                WipLGrossWt.Text = Format(sRWtTotal, "0.00")
                WipLGrossPr.Text = Format(sRPrTotal, "0.00")
                WipLGrossFw.Text = Format(sFWtTotal, "0.00")
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetWIPMelting()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "WIPMeltingDetails", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_StockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(row("ReceiveWt")) Then
                        sRWtTotal += Single.Parse(row("ReceiveWt"))
                    End If

                    If Not IsDBNull(row("FineWt")) Then
                        sFWtTotal += Single.Parse(row("FineWt"))
                    End If
                Next
            End If

            If Not sFWtTotal = 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.000")
            End If

            WipMGrossWt.Text = Format(sRWtTotal, "0.00")
            WipMGrossPr.Text = Format(sRPrTotal, "0.00")
            WipMGrossFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetWIPLotTransfered()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "WIPLotTransferedDetails", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_StockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("TransferWt")) Then
                        sRWtTotal += Single.Parse(row("TransferWt"))
                    End If

                    If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                        sFWtTotal += Single.Parse(row("FineWt"))
                    End If
                Next
            End If

            If Not sFWtTotal = 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.000")
            End If

            WipTGrossWt.Text = Format(sRWtTotal, "0.00")
            WipTGrossPr.Text = Format(sRPrTotal, "0.00")
            WipTGrossFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetFinishedLots()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FinishedLotsDetails", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_StockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("ReceiveWt")) Then
                        sRWtTotal += Single.Parse(row("ReceiveWt"))
                    End If

                    If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                        sFWtTotal += Single.Parse(row("FineWt"))
                    End If
                Next
            End If

            If sFWtTotal > 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.000")
            End If

            WipFGrossWt.Text = Format(sRWtTotal, "0.00")
            WipFGrossPr.Text = Format(sRPrTotal, "0.00")
            WipFGrossFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetLotAdditionStock()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "LotAdditionStockDetails", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_StockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("ReceiveWt")) Then
                        sRWtTotal += Single.Parse(row("ReceiveWt"))
                    End If

                    If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                        sFWtTotal += Single.Parse(row("FineWt"))
                    End If
                Next
            End If

            If sFWtTotal > 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.000")
            End If

            LotAddStockWt.Text = Format(sRWtTotal, "0.00")
            LotAddStockPr.Text = Format(sRPrTotal, "0.00")
            LotAddStockFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetBhukaBagNotCreated()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "BhukaBagNotCreated", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_BagsStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("ReceiveWt")) Then
                        sRWtTotal += Single.Parse(row("ReceiveWt"))
                    End If

                    If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                        sFWtTotal += Single.Parse(row("FineWt"))
                    End If
                Next
            End If

            If Not sFWtTotal = 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.000")
            End If

            BhukaBagNCWt.Text = Format(sRWtTotal, "0.00")
            BhukaBagNCPr.Text = Format(sRPrTotal, "0.00")
            BhukaBagNCFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error: - " & ex.Message)
        End Try
    End Sub
    Private Sub GetVacuumBagNotCreated()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "VacuumBagNotCreated", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_BagsStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("ReceiveWt")) Then
                        sRWtTotal += Single.Parse(row("ReceiveWt"))
                    End If

                    If Not IsDBNull(dtData.Rows(0)("ReceivePr")) Then
                        sRPrTotal += Single.Parse(row("ReceivePr"))
                    End If

                    If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                        sFWtTotal += Single.Parse(row("FineWt"))
                    End If
                Next
            End If

            'If sFWtTotal > 0 Then
            '    sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.000")
            'End If

            VacuumBagNCWt.Text = Format(sRWtTotal, "0.00")
            VacuumBagNCPr.Text = Format(sRPrTotal, "0.00")
            VacuumBagNCFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
        End Try
    End Sub
    Private Sub GetSampleBagNotCreated()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "SampleBagNotCreated", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_BagsStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("ReceiveWt")) Then
                        sRWtTotal += Single.Parse(row("ReceiveWt"))
                    End If

                    If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                        sFWtTotal += Single.Parse(row("FineWt"))
                    End If
                Next
            End If

            If sFWtTotal > 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.000")
            End If

            SampleBagNCWt.Text = Format(sRWtTotal, "0.00")
            SampleBagNCPr.Text = Format(sRPrTotal, "0.00")
            SampleBagNCFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetBhukaBagNotReceived()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "BhukaBagNotReceived", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_BagsStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("ReceiveWt")) Then
                        sRWtTotal += Single.Parse(row("ReceiveWt"))
                    End If

                    If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                        sFWtTotal += Single.Parse(row("FineWt"))
                    End If
                Next
            End If

            If sFWtTotal > 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.00")
            End If

            BhukaBagNrWt.Text = Format(sRWtTotal, "0.00")
            BhukaBagNrPr.Text = Format(sRPrTotal, "0.00")
            BhukaBagNrFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetVacuumBagNotReceived()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "VaccumBagNotReceived", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_BagsStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("ReceiveWt")) Then
                        sRWtTotal += Single.Parse(row("ReceiveWt"))
                    End If

                    If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                        sFWtTotal += Single.Parse(row("FineWt"))
                    End If
                Next
            End If

            If sFWtTotal > 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.00")
            End If

            VacuumBagWt.Text = Format(sRWtTotal, "0.00")
            VacuumBagPr.Text = Format(sRPrTotal, "0.00")
            VacuumBagFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetSampleBagNotReceived()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "SampleBagNotReceived", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_BagsStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("ReceiveWt")) Then
                        sRWtTotal += Single.Parse(row("ReceiveWt"))
                    End If

                    If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                        sFWtTotal += Single.Parse(row("FineWt"))
                    End If
                Next
            End If

            If sFWtTotal > 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.00")
            End If

            SampleBagWt.Text = Format(sRWtTotal, "0.00")
            SampleBagPr.Text = Format(sRPrTotal, "0.00")
            SampleBagFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetBhukaBagNotUsed()
        Dim dtData As DataTable = New DataTable()

        Dim sBRWtTotal As Single = 0
        Dim sBRPrTotal As Single = 0
        Dim sBFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "ScrapBagNotUsed", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_BagsStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            Dim dataView As DataView = dtData.DefaultView

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows

                    ''For Bhuka Bags
                    If row("ItemTypeId").ToString() = 2 Then
                        If Not IsDBNull(dtData.Rows(0)("BalanceWt")) Then
                            sBRWtTotal += Single.Parse(row("BalanceWt"))
                        End If

                        If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                            sBFWtTotal += Single.Parse(row("FineWt"))
                        End If
                    End If

                Next
            End If

            ''Bhuka Wt
            If sBFWtTotal > 0 Then
                sBRPrTotal = Format((Val(sBFWtTotal) / Val(sBRWtTotal)) * 100, "0.00")
            End If

            ''Bhuka Wt
            BhukaBagUWt.Text = Format(sBRWtTotal, "0.00")
            BhukaBagUPr.Text = Format(sBRPrTotal, "0.00")
            BhukaBagUFw.Text = Format(sBFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetVaccumBagNotUsed()
        Dim dtData As DataTable = New DataTable()

        Dim sVRWtTotal As Single = 0
        Dim sVRPrTotal As Single = 0
        Dim sVFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "VaccumBagNotUsed", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_BagsStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            Dim dataView As DataView = dtData.DefaultView

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows

                    ''For Vaccum Bags
                    If row("ItemTypeId").ToString() = 5 Then
                        If Not IsDBNull(dtData.Rows(0)("BalanceWt")) Then
                            sVRWtTotal += Single.Parse(row("BalanceWt"))
                        End If

                        If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                            sVFWtTotal += Single.Parse(row("FineWt"))
                        End If
                    End If
                Next
            End If

            ''Vaccum Wt
            If sVFWtTotal > 0 Then
                sVRPrTotal = Format((Val(sVFWtTotal) / Val(sVRWtTotal)) * 100, "0.00")
            End If

            ''vacuum Wt
            VacuumBagUWt.Text = Format(sVRWtTotal, "0.00")
            VacuumBagUPr.Text = Format(sVRPrTotal, "0.00")
            VacuumBagUFw.Text = Format(sVFWtTotal, "0.00")
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetSampleBagNotUsed()
        Dim dtData As DataTable = New DataTable()

        Dim sSRWtTotal As Single = 0
        Dim sSRPrTotal As Single = 0
        Dim sSFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "SampleBagNotUsed", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_BagsStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            Dim dataView As DataView = dtData.DefaultView

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    ''For Sample Bags
                    If row("ItemTypeId").ToString() = 2 Then
                        If Not IsDBNull(dtData.Rows(0)("BalanceWt")) Then
                            sSRWtTotal += Single.Parse(row("BalanceWt"))
                        End If

                        If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                            sSFWtTotal += Single.Parse(row("FineWt"))
                        End If
                    End If
                Next
            End If

            ''Sample Wt
            If sSFWtTotal > 0 Then
                sSRPrTotal = Format((Val(sSFWtTotal) / Val(sSRWtTotal)) * 100, "0.00")
            End If

            ''Sample Wt
            SampleBagUWt.Text = Format(sSRWtTotal, "0.00")
            SampleBagUPr.Text = Format(sSRPrTotal, "0.00")
            SampleBagUFw.Text = Format(sSFWtTotal, "0.00")
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetLotFailBagNotUsed()
        Dim dtData As DataTable = New DataTable()

        Dim sLRWtTotal As Single = 0
        Dim sLRPrTotal As Single = 0
        Dim sLFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "LotFailBagNotUsed", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_BagsStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            Dim dataView As DataView = dtData.DefaultView

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows

                    ''For Lotfail Bags
                    If row("ItemTypeId").ToString() = 4 Then
                        If Not IsDBNull(dtData.Rows(0)("BalanceWt")) Then
                            sLRWtTotal += Single.Parse(row("BalanceWt"))
                        End If

                        If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                            sLFWtTotal += Single.Parse(row("FineWt"))
                        End If
                    End If
                Next
            End If

            ''LotFail Wt
            If sLFWtTotal > 0 Then
                sLRPrTotal = Format((Val(sLFWtTotal) / Val(sLRWtTotal)) * 100, "0.00")
            End If

            ''LotFail Wt
            LotFailBagUWt.Text = Format(sLRWtTotal, "0.00")
            LotFailBagUPr.Text = Format(sLRPrTotal, "0.00")
            LotFailBagUFw.Text = Format(sLFWtTotal, "0.00")
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetVoucherMetalUnused()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "VoucherMetalUnusedDetails", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_StockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("ReceiveWt")) Then
                        sRWtTotal += Single.Parse(row("ReceiveWt"))
                    End If


                    If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                        sFWtTotal += Single.Parse(row("FineWt"))
                    End If
                Next
            End If

            If sFWtTotal > 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.00")
            End If

            VoucherMetalWt.Text = Format(sRWtTotal, "0.00")
            VoucherMetalPr.Text = Format(sRPrTotal, "0.00")
            VoucherMetalFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetLossBag()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "LossBagsDetails", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_StockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("GrossWt")) Then
                        sRWtTotal += Single.Parse(row("GrossWt"))
                    End If
                    If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                        sFWtTotal += Single.Parse(row("FineWt"))
                    End If
                Next
            End If

            If sFWtTotal > 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.00")
            End If

            LossBagsWt.Text = Format(sRWtTotal, "0.00")
            LossBagsPr.Text = Format(sRPrTotal, "0.00")
            LossBagsFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetLossLab()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "LossLabsDetails", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_StockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("ReceiveWt")) Then
                        sRWtTotal += Single.Parse(row("ReceiveWt"))
                    End If

                    'If Not IsDBNull(dtData.Rows(0)("ReceivePr")) Then
                    '    sRPrTotal += Single.Parse(row("ReceivePr"))
                    'End If

                    If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                        sFWtTotal += Single.Parse(row("FineWt"))
                    End If
                Next
            End If

            If sFWtTotal > 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.00")
            End If

            LabReceiveWt.Text = Format(sRWtTotal, "0.00")
            LabReceivePr.Text = Format(sRPrTotal, "0.00")
            LabReceiveFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetMetalReceipt()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "LossDeptReceiptDetails", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_StockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("ReceiveWt")) Then
                        sRWtTotal += Single.Parse(row("ReceiveWt"))
                    End If

                    'If Not IsDBNull(dtData.Rows(0)("ReceivePr")) Then
                    '    sRPrTotal += Single.Parse(row("ReceivePr"))
                    'End If

                    If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                        sFWtTotal += Single.Parse(row("FineWt"))
                    End If
                Next
            End If

            If sFWtTotal > 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.00")
            End If

            ReceiptGrossWt.Text = Format(sRWtTotal, "0.00")
            ReceiptGrossPr.Text = Format(sRPrTotal, "0.00")
            ReceiptGrossFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetMetalIssue()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "LossDeptIssueDetails", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_StockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("IssueWt")) Then
                        sRWtTotal += Single.Parse(row("IssueWt"))
                    End If

                    If Not IsDBNull(dtData.Rows(0)("IssuePr")) Then
                        sRPrTotal += Single.Parse(row("IssuePr"))
                    End If

                    If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                        sFWtTotal += Single.Parse(row("FineWt"))
                    End If
                Next
            End If

            'If sFWtTotal > 0 Then
            '    sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.00")
            'End If

            IssueGrossWt.Text = Format(sRWtTotal, "0.00")
            IssueGrossPr.Text = Format(sRPrTotal, "0.00")
            IssueGrossFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetLotFailBagNotReceived()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "LotFailBagNotReceived", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_BagsStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("ReceiveWt")) Then
                        sRWtTotal += Single.Parse(row("ReceiveWt"))
                    End If

                    If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                        sFWtTotal += Single.Parse(row("FineWt"))
                    End If
                Next
            End If

            If sFWtTotal > 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.000")
            End If

            LotFailBagWt.Text = Format(sRWtTotal, "0.00")
            LotFailBagPr.Text = Format(sRPrTotal, "0.00")
            LotFailBagFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetBhukaBagNotUpdated()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "BhukaBagNotUpdated", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_BagsStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("ReceiveWt")) Then
                        sRWtTotal += Single.Parse(row("ReceiveWt"))
                    End If

                    If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                        sFWtTotal += Single.Parse(row("FineWt"))
                    End If
                Next
            End If

            If sFWtTotal > 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.000")
            End If


            BhukaBagNuWt.Text = Format(sRWtTotal, "0.00")
            BhukaBagNuPr.Text = Format(sRPrTotal, "0.00")
            BhukaBagNuFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetVaccumBagNotUpdated()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "VaccumBagNotUpdated", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_BagsStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("ReceiveWt")) Then
                        sRWtTotal += Single.Parse(row("ReceiveWt"))
                    End If

                    If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                        sFWtTotal += Single.Parse(row("FineWt"))
                    End If
                Next
            End If

            If sFWtTotal > 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.000")
            End If

            VacuumBagNuWt.Text = Format(sRWtTotal, "0.00")
            VacuumBagNuPr.Text = Format(sRWtTotal, "0.00")
            VacuumBagNuFw.Text = Format(sRWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetSampleBagNotUpdated()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "SampleBagNotUpdated", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_BagsStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("ReceiveWt")) Then
                        sRWtTotal += Single.Parse(row("ReceiveWt"))
                    End If

                    If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                        sFWtTotal += Single.Parse(row("FineWt"))
                    End If
                Next
            End If

            If sFWtTotal > 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.000")
            End If

            LotFailBagWt.Text = Format(sRWtTotal, "0.00")
            LotFailBagPr.Text = Format(sRPrTotal, "0.00")
            LotFailBagFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetLotFailBagNotUpdated()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "LotFailBagNotUpdated", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_BagsStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("ReceiveWt")) Then
                        sRWtTotal += Single.Parse(row("ReceiveWt"))
                    End If

                    If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                        sFWtTotal += Single.Parse(row("FineWt"))
                    End If
                Next
            End If

            If sFWtTotal > 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.000")
            End If

            LotFailBagNuWt.Text = Format(sRWtTotal, "0.00")
            LotFailBagNuPr.Text = Format(sRPrTotal, "0.00")
            LotFailBagNuFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetLossTransaction()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "LossTransactionDetails", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_StockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("ReceiveWt")) Then
                        sRWtTotal += Single.Parse(row("ReceiveWt"))
                    End If

                    If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                        sFWtTotal += Single.Parse(row("FineWt"))
                    End If
                Next
            End If

            If sFWtTotal > 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.00")
            End If

            LossTransWt.Text = Format(sRWtTotal, "0.00")
            LossTransPr.Text = Format(sRPrTotal, "0.00")
            LossTransFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub btnWIPLots_Click(sender As Object, e As EventArgs) Handles btnWIPLots.Click
        Dim ObjStockWipMelting As New frmStockWipLots
        ObjStockWipMelting.ShowDialog()
    End Sub
    Private Sub btnMeltingDetails_Click(sender As Object, e As EventArgs) Handles btnMeltingDetails.Click
        Dim ObjStockWipMelting As New frmStockWipMelting
        ObjStockWipMelting.ShowDialog()
    End Sub
    Private Sub btnWipLotTransferred_Click(sender As Object, e As EventArgs) Handles btnWipLotTransferred.Click
        Dim ObjStockFinishedLots As New frmStockWipLotTransferred
        ObjStockFinishedLots.ShowDialog()
    End Sub
    Private Sub btnWipFinishLots_Click(sender As Object, e As EventArgs) Handles btnWipFinishLots.Click
        Dim ObjStockFinishedLots As New frmStockFinishedLots
        ObjStockFinishedLots.ShowDialog()
    End Sub
    Private Sub btnBBagNotCreated_Click(sender As Object, e As EventArgs) Handles btnBBagNotCreated.Click
        Dim ObjStockBhukaBagNotCreated As New frmStockBhukaBagNotCreated
        ObjStockBhukaBagNotCreated.ShowDialog()
    End Sub
    Private Sub btnVBagNotCreated_Click(sender As Object, e As EventArgs) Handles btnVBagNotCreated.Click
        Dim ObjStockWipMelting As New frmStockVaccumBagNotCreated
        ObjStockWipMelting.ShowDialog()
    End Sub
    Private Sub btnSBagNotCreated_Click(sender As Object, e As EventArgs) Handles btnSBagNotCreated.Click
        Dim ObjStockSampleBagNotCreated As New frmStockSampleBagNotCreated
        ObjStockSampleBagNotCreated.ShowDialog()
    End Sub
    Private Sub btnBBagCreated_Click(sender As Object, e As EventArgs) Handles btnBBagCreated.Click
        Dim ObjStockBhukaBagCreated As New frmStockBhukaBagCreated
        ObjStockBhukaBagCreated.ShowDialog()
    End Sub
    Private Sub btnVBagCreated_Click(sender As Object, e As EventArgs) Handles btnVBagCreated.Click
        Dim ObjStockVacuumBagCreated As New frmStockVacuumBagCreated
        ObjStockVacuumBagCreated.ShowDialog()
    End Sub
    Private Sub btnSBagCreated_Click(sender As Object, e As EventArgs) Handles btnSBagCreated.Click
        Dim ObjStockSampleBagCreated As New frmStockSampleBagCreated
        ObjStockSampleBagCreated.ShowDialog()
    End Sub
    Private Sub btnVoucherMetalUnused_Click(sender As Object, e As EventArgs) Handles btnVoucherMetalUnused.Click
        Dim ObjStockMetalUnused As New frmStockMetalUnused
        ObjStockMetalUnused.ShowDialog()
    End Sub
    Private Sub btnLotAdditionStock_Click(sender As Object, e As EventArgs) Handles btnLotAdditionStock.Click
        Dim ObjStockLotAddition As New frmStockLotAddition
        ObjStockLotAddition.ShowDialog()
    End Sub
    Private Sub btnLossBags_Click(sender As Object, e As EventArgs) Handles btnLossBags.Click
        Dim ObjStockLossBags As New frmStockLossBags
        ObjStockLossBags.ShowDialog()
    End Sub
    Private Sub btnLossTransaction_Click(sender As Object, e As EventArgs) Handles btnLossTransaction.Click
        Dim ObjStockLossTransaction As New frmStockLossTransaction
        ObjStockLossTransaction.ShowDialog()
    End Sub
    Private Sub BtnLossLabs_Click(sender As Object, e As EventArgs) Handles BtnLossLabs.Click
        Dim ObjStockLossLabs As New frmStockLossLabs
        ObjStockLossLabs.ShowDialog()
    End Sub
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        ''creating And initializing the connection string
        'Dim myConnectionString As SqlConnection = New SqlConnection("Data Source=(local)\SQLEXPRESS;Initial Catalog=Chain;Integrated Security=True;Pooling=False")
        ''since we need to create a New database set the Initial Catalog as Master
        ''Which means we are creating database under master DB
        Dim strMyDBName As String = Today.Date()
        Dim myCommand As String
        myCommand = "CREATE database my_db"
        Dim cmd As SqlCommand = New SqlCommand(myCommand, Objcn)
        Try
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
            cmd.Connection.Close()
        Catch
            MsgBox(" Already installed database", MsgBoxStyle.Critical, " Chain Experts- Warning")
        End Try
        ''Creating table to the dynamicaly created database
        Try
            'Dim cn As SqlConnection = New SqlConnection("Data Source=(local)\SQLEXPRESS;Initial Catalog=my_db;Integrated Security=True;Pooling=False")
            ''here the connection string Is initialized with Initial Catalog as my_db
            Dim sql As String
            sql = "CREATE TABLE customer(cus_name varchar(50) NULL,address varchar(50) NULL,mobno numeric(18, 0) NULL,tin varchar(50) NULL,kg varchar(50) NULL)"
            cmd = New SqlCommand(sql, Objcn)
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
            cmd.Connection.Close()

        Catch
            MsgBox(" Already installed database", MsgBoxStyle.Critical, "Chain - Warning")
        End Try

        'Dim connectionString As String = ' CONNECTION STRING IS HERE
        'Dim conn As New SqlClient.SqlConnection(connectionString)
        Dim ObjCmd As New SqlClient.SqlCommand
        Dim objReader As System.IO.StreamReader

        Try
            cmd.CommandType = CommandType.Text
            cmd.Connection = Objcn

            'Dim file As New FileInfo("C:\Temp\table.sql")
            'Dim script As String = file.OpenText().ReadToEnd()
            'Dim conn As New SqlConnection(Objcn)
            'Dim server As New Server(New ServerConnection(conn))
            'server.ConnectionContext.ExecuteNonQuery(script)

            'objReader = New System.IO.StreamReader("C:\dbs\table.sql")
            objReader = New System.IO.StreamReader("C:\Temp\table.sql")
            cmd.CommandText = objReader.ReadToEnd
            cmd.ExecuteNonQuery()

            objReader = New System.IO.StreamReader("C:\dbs\view.sql")
            cmd.CommandText = objReader.ReadToEnd
            cmd.ExecuteNonQuery()

            objReader = New System.IO.StreamReader("C:\dbs\sp.sql")
            cmd.CommandText = objReader.ReadToEnd
            cmd.ExecuteNonQuery()

            objReader = New System.IO.StreamReader("C:\dbs\udf.sql")
            cmd.CommandText = objReader.ReadToEnd
            cmd.ExecuteNonQuery()

            objReader.Close()
            Objcn.Close()
            Objcn = Nothing
            MsgBox("New Database Created")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnLBagCreated_Click(sender As Object, e As EventArgs) Handles btnLBagCreated.Click
        Dim ObjStockLotFailBags As New frmStockLotFailBags
        ObjStockLotFailBags.ShowDialog()
    End Sub
    Private Sub frmStockSummary_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                If MsgBox("Wish To Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Me.Close()
            ElseIf e.KeyCode = Keys.Tab Then
                SendKeys.Send("{Tab}")
                SendKeys.Send("{HOME}+{END}")
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub btnBBagNotUsed_Click(sender As Object, e As EventArgs) Handles btnBBagNotUsed.Click
        Dim ObjStockBagsNotUsed As New frmStockBagsNotUsed
        ObjStockBagsNotUsed.ShowDialog()
    End Sub
    Private Sub btnDeptReceive_Click(sender As Object, e As EventArgs) Handles btnDeptReceive.Click
        Dim ObjStockLossMetalReceived As New frmStockLossMetalReceived
        ObjStockLossMetalReceived.ShowDialog()
    End Sub
    Private Sub GetTxtTotal()
        Dim dTotalWt As Double = 0
        Dim dTotalFw As Double = 0

        dTotalWt =
    GetValue(WipLGrossWt.Text.Trim) +
    GetValue(WipMGrossWt.Text.Trim) +
    GetValue(WipTGrossWt.Text.Trim) +
    GetValue(WipFGrossWt.Text.Trim) +
    GetValue(BhukaBagNCWt.Text.Trim) +
    GetValue(VacuumBagNCWt.Text.Trim) +
    GetValue(SampleBagNCWt.Text.Trim) +
    GetValue(BhukaBagNrWt.Text.Trim) +
    GetValue(VacuumBagWt.Text.Trim) +
    GetValue(SampleBagWt.Text.Trim) +
    GetValue(LotFailBagWt.Text.Trim) +
    GetValue(BhukaBagUWt.Text.Trim) +
    GetValue(VacuumBagUWt.Text.Trim) +
    GetValue(SampleBagUWt.Text.Trim) +
    GetValue(LotFailBagUWt.Text.Trim) +
    GetValue(VoucherMetalWt.Text.Trim) +
    GetValue(LotAddStockWt.Text.Trim) +
    GetValue(LossBagsWt.Text.Trim) +
    GetValue(LossTransWt.Text.Trim) +
    GetValue(LabReceiveWt.Text.Trim)

        dTotalFw =
    GetValue(WipLGrossFw.Text.Trim) +
    GetValue(WipMGrossFw.Text.Trim) +
    GetValue(WipTGrossFw.Text.Trim) +
    GetValue(WipFGrossFw.Text.Trim) +
    GetValue(BhukaBagNCFw.Text.Trim) +
    GetValue(VacuumBagNCFw.Text.Trim) +
    GetValue(SampleBagNCFw.Text.Trim) +
    GetValue(BhukaBagNrFw.Text.Trim) +
    GetValue(VacuumBagFw.Text.Trim) +
    GetValue(SampleBagFw.Text.Trim) +
    GetValue(LotFailBagFw.Text.Trim) +
    GetValue(BhukaBagUFw.Text.Trim) +
    GetValue(VacuumBagUFw.Text.Trim) +
    GetValue(SampleBagUFw.Text.Trim) +
    GetValue(LotFailBagUFw.Text.Trim) +
    GetValue(VoucherMetalFw.Text.Trim) +
    GetValue(LotAddStockFw.Text.Trim) +
    GetValue(LossBagsFw.Text.Trim) +
    GetValue(LossTransFw.Text.Trim) +
    GetValue(LabReceiveFw.Text.Trim)

        lblGrossWt.Text = Format(dTotalWt, "0.00")

        lblGrossPr.Text = Format((Val(dTotalFw) / Val(dTotalWt)) * 100, "0.00")

        lblGrossFw.Text = Format(dTotalFw, "0.00")
    End Sub
    Private Function GetValue(ByVal text As String) As Double
        If String.IsNullOrEmpty(text) Then Return 0
        Dim value As Double
        If Double.TryParse(text, value) Then Return value
        Return 0
    End Function
    Private Sub txtOpeningStockWt_TextChanged(sender As Object, e As EventArgs) Handles txtOpeningStockWt.TextChanged
        GetFinalTxtTotal()
    End Sub
    Private Sub GetFinalTxtTotal()
        Dim dTotalWt As Double = 0
        Dim dTotalFw As Double = 0
        Dim dTotalPr As Double = 0

        dTotalWt =
    GetValue(txtOpeningStockWt.Text.Trim) +
    GetValue(ReceiptGrossWt.Text.Trim) -
    GetValue(IssueGrossWt.Text.Trim)

        dTotalFw =
    GetValue(txtOpeningStockFw.Text.Trim) +
    GetValue(ReceiptGrossFw.Text.Trim) -
    GetValue(IssueGrossFw.Text.Trim)

        txtClosingStockWt.Text = Format(dTotalWt, "0.00")

        dTotalPr = Format((Val(dTotalFw) / Val(dTotalWt)) * 100, "0.00")

        txtClosingStockPr.Text = Format(dTotalPr, "0.00")

        txtClosingStockFw.Text = Format(dTotalFw, "0.00")
    End Sub
    Private Sub btnDeptIssue_Click(sender As Object, e As EventArgs) Handles btnDeptIssue.Click
        Dim ObjLessMetalIssued As New frmLessMetalIssued
        ObjLessMetalIssued.ShowDialog()
    End Sub
    Private Sub txtClosingStockWt_TextChanged(sender As Object, e As EventArgs) Handles txtClosingStockWt.TextChanged
        'Dim dfinalWt As Double = 0
        'Dim dFinalFw As Double = 0

        'Double.TryParse(txtClosingStockWt.Text, dfinalWt)

        'Double.TryParse(txtClosingStockFw.Text, dFinalFw)

        'If dfinalWt > 0 And dFinalFw > 0 Then
        '    lblDiffWt.Text = Val(txtClosingStockWt.Text - lblGrossWt.Text)
        '    lblDiffFw.Text = Val(txtClosingStockFw.Text - lblGrossFw.Text)
        'End If

    End Sub
    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        Dim dfinalWt As Double = 0
        Dim dFinalFw As Double = 0

        Double.TryParse(txtClosingStockWt.Text, dfinalWt)

        Double.TryParse(txtClosingStockFw.Text, dFinalFw)

        If dfinalWt > 0 And dFinalFw > 0 Then
            lblDiffFw.Text = Val(txtClosingStockFw.Text - lblGrossFw.Text)
        End If
    End Sub
    Private Sub btnOpStock_Click(sender As Object, e As EventArgs) Handles btnOpStock.Click
        Dim ObjAccountOpening As New frmAccountOpening
        ObjAccountOpening.ShowDialog()
    End Sub
    Private Sub btnLBagNotUsed_Click(sender As Object, e As EventArgs) Handles btnLBagNotUsed.Click
        Dim ObjLotFailBagNotUsed As New frmLotFailBagNotUsed
        ObjLotFailBagNotUsed.ShowDialog()
    End Sub

    Private Sub VacuumBagWt_TextChanged(sender As Object, e As EventArgs) Handles VacuumBagWt.TextChanged

    End Sub

    Private Sub BhukaBagNrWt_TextChanged(sender As Object, e As EventArgs) Handles BhukaBagNrWt.TextChanged

    End Sub
End Class