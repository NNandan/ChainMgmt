<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFaVStockRemoval
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim GridViewTextBoxColumn31 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn32 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn33 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn34 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn35 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn36 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn37 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn38 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn39 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn40 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition4 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.dgvVStockRemv = New Telerik.WinControls.UI.RadGridView()
        Me.BtnPrint = New Telerik.WinControls.UI.RadButton()
        Me.BtnExit = New Telerik.WinControls.UI.RadButton()
        CType(Me.dgvVStockRemv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvVStockRemv.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvVStockRemv
        '
        Me.dgvVStockRemv.BackColor = System.Drawing.SystemColors.Control
        Me.dgvVStockRemv.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvVStockRemv.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.dgvVStockRemv.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvVStockRemv.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvVStockRemv.Location = New System.Drawing.Point(0, 0)
        '
        '
        '
        GridViewTextBoxColumn31.EnableExpressionEditor = False
        GridViewTextBoxColumn31.FieldName = "ReceiptDt"
        GridViewTextBoxColumn31.HeaderText = "ReceiptDt"
        GridViewTextBoxColumn31.Name = "colReceiptDt"
        GridViewTextBoxColumn31.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn31.Width = 93
        GridViewTextBoxColumn32.EnableExpressionEditor = False
        GridViewTextBoxColumn32.FieldName = "VoucherNo"
        GridViewTextBoxColumn32.HeaderText = "VoucherNo"
        GridViewTextBoxColumn32.Name = "colVoucherNo"
        GridViewTextBoxColumn32.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn32.Width = 70
        GridViewTextBoxColumn33.EnableExpressionEditor = False
        GridViewTextBoxColumn33.FieldName = "ReceivePr"
        GridViewTextBoxColumn33.HeaderText = "ReceivePr"
        GridViewTextBoxColumn33.Name = "colReceivePr"
        GridViewTextBoxColumn33.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn33.Width = 70
        GridViewTextBoxColumn34.EnableExpressionEditor = False
        GridViewTextBoxColumn34.FieldName = "ConvPr"
        GridViewTextBoxColumn34.HeaderText = "ConvPr"
        GridViewTextBoxColumn34.Name = "colConvPr"
        GridViewTextBoxColumn34.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn34.Width = 70
        GridViewTextBoxColumn35.EnableExpressionEditor = False
        GridViewTextBoxColumn35.FieldName = "ReceiveWt"
        GridViewTextBoxColumn35.HeaderText = "ReceiveWt"
        GridViewTextBoxColumn35.Name = "colReceiveWt"
        GridViewTextBoxColumn35.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn35.Width = 90
        GridViewTextBoxColumn36.EnableExpressionEditor = False
        GridViewTextBoxColumn36.FieldName = "RecFineWt"
        GridViewTextBoxColumn36.HeaderText = "RecFineWt"
        GridViewTextBoxColumn36.Name = "colRecFineWt"
        GridViewTextBoxColumn36.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn36.Width = 70
        GridViewTextBoxColumn37.EnableExpressionEditor = False
        GridViewTextBoxColumn37.FieldName = "PercentAdd"
        GridViewTextBoxColumn37.HeaderText = "PercentAdd"
        GridViewTextBoxColumn37.Name = "colPercentAdd"
        GridViewTextBoxColumn37.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn37.Width = 70
        GridViewTextBoxColumn38.EnableExpressionEditor = False
        GridViewTextBoxColumn38.FieldName = "ConFineWt"
        GridViewTextBoxColumn38.HeaderText = "ConFineWt"
        GridViewTextBoxColumn38.Name = "colConFineWt"
        GridViewTextBoxColumn38.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn38.Width = 70
        GridViewTextBoxColumn39.EnableExpressionEditor = False
        GridViewTextBoxColumn39.FieldName = "StockAddGross"
        GridViewTextBoxColumn39.HeaderText = "StockAddGross"
        GridViewTextBoxColumn39.Name = "colStockAddGross"
        GridViewTextBoxColumn39.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn39.Width = 100
        GridViewTextBoxColumn40.EnableExpressionEditor = False
        GridViewTextBoxColumn40.FieldName = "StockAddFine"
        GridViewTextBoxColumn40.HeaderText = "StockAddFine"
        GridViewTextBoxColumn40.Name = "colStockAddFine"
        GridViewTextBoxColumn40.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn40.Width = 90
        Me.dgvVStockRemv.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn31, GridViewTextBoxColumn32, GridViewTextBoxColumn33, GridViewTextBoxColumn34, GridViewTextBoxColumn35, GridViewTextBoxColumn36, GridViewTextBoxColumn37, GridViewTextBoxColumn38, GridViewTextBoxColumn39, GridViewTextBoxColumn40})
        Me.dgvVStockRemv.MasterTemplate.ViewDefinition = TableViewDefinition4
        Me.dgvVStockRemv.Name = "dgvVStockRemv"
        Me.dgvVStockRemv.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvVStockRemv.Size = New System.Drawing.Size(815, 440)
        Me.dgvVStockRemv.TabIndex = 0
        '
        'BtnPrint
        '
        Me.BtnPrint.Location = New System.Drawing.Point(329, 456)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(75, 25)
        Me.BtnPrint.TabIndex = 1
        Me.BtnPrint.Text = "&Print"
        '
        'BtnExit
        '
        Me.BtnExit.Location = New System.Drawing.Point(410, 456)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(75, 25)
        Me.BtnExit.TabIndex = 2
        Me.BtnExit.Text = "E&xit"
        '
        'frmVStockRemoval
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(816, 506)
        Me.Controls.Add(Me.BtnExit)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.dgvVStockRemv)
        Me.Name = "frmVStockRemoval"
        Me.Text = "frmVStockRemoval"
        CType(Me.dgvVStockRemv.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvVStockRemv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnPrint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnExit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvVStockRemv As Telerik.WinControls.UI.RadGridView
    Friend WithEvents BtnPrint As Telerik.WinControls.UI.RadButton
    Friend WithEvents BtnExit As Telerik.WinControls.UI.RadButton
End Class
