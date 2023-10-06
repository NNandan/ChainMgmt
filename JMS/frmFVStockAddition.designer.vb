<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVStockAddition
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim GridViewTextBoxColumn21 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn22 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn23 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn24 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn25 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn26 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn27 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn28 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn29 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn30 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition3 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.dgvVStockAdd = New Telerik.WinControls.UI.RadGridView()
        Me.BtnPrint = New Telerik.WinControls.UI.RadButton()
        Me.BtnExit = New Telerik.WinControls.UI.RadButton()
        CType(Me.dgvVStockAdd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvVStockAdd.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvVStockAdd
        '
        Me.dgvVStockAdd.BackColor = System.Drawing.SystemColors.Control
        Me.dgvVStockAdd.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvVStockAdd.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvVStockAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvVStockAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvVStockAdd.Location = New System.Drawing.Point(0, 0)
        '
        '
        '
        Me.dgvVStockAdd.MasterTemplate.AllowAddNewRow = False
        Me.dgvVStockAdd.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn21.EnableExpressionEditor = False
        GridViewTextBoxColumn21.FieldName = "ReceiptDt"
        GridViewTextBoxColumn21.HeaderText = "ReceiptDt"
        GridViewTextBoxColumn21.Name = "colReceiptDt"
        GridViewTextBoxColumn21.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn21.Width = 105
        GridViewTextBoxColumn22.EnableExpressionEditor = False
        GridViewTextBoxColumn22.FieldName = "VoucherNo"
        GridViewTextBoxColumn22.HeaderText = "VoucherNo"
        GridViewTextBoxColumn22.Name = "colVoucherNo"
        GridViewTextBoxColumn22.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn22.Width = 117
        GridViewTextBoxColumn23.EnableExpressionEditor = False
        GridViewTextBoxColumn23.FieldName = "RequirePr"
        GridViewTextBoxColumn23.HeaderText = "Require [%]"
        GridViewTextBoxColumn23.Name = "colRequirePr"
        GridViewTextBoxColumn23.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn23.Width = 93
        GridViewTextBoxColumn24.EnableExpressionEditor = False
        GridViewTextBoxColumn24.FieldName = "ConvPr"
        GridViewTextBoxColumn24.HeaderText = "Conv [%]"
        GridViewTextBoxColumn24.Name = "colConvPr"
        GridViewTextBoxColumn24.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn24.Width = 93
        GridViewTextBoxColumn25.EnableExpressionEditor = False
        GridViewTextBoxColumn25.FieldName = "ReceiveWt"
        GridViewTextBoxColumn25.HeaderText = "Receive Wt."
        GridViewTextBoxColumn25.Name = "colReceiveWt"
        GridViewTextBoxColumn25.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn25.Width = 93
        GridViewTextBoxColumn26.EnableExpressionEditor = False
        GridViewTextBoxColumn26.FieldName = "RecFineWt"
        GridViewTextBoxColumn26.HeaderText = "Rec Fine Wt."
        GridViewTextBoxColumn26.Name = "colRecFineWt"
        GridViewTextBoxColumn26.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn26.Width = 105
        GridViewTextBoxColumn27.EnableExpressionEditor = False
        GridViewTextBoxColumn27.FieldName = "PercentAdd"
        GridViewTextBoxColumn27.HeaderText = "Add [%]"
        GridViewTextBoxColumn27.Name = "colPercentAdd"
        GridViewTextBoxColumn27.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn27.Width = 93
        GridViewTextBoxColumn28.EnableExpressionEditor = False
        GridViewTextBoxColumn28.FieldName = "ConFineWt"
        GridViewTextBoxColumn28.HeaderText = "ConFineWt"
        GridViewTextBoxColumn28.Name = "colConFineWt"
        GridViewTextBoxColumn28.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn28.Width = 105
        GridViewTextBoxColumn29.EnableExpressionEditor = False
        GridViewTextBoxColumn29.FieldName = "StockAddGross"
        GridViewTextBoxColumn29.HeaderText = "StockAddGross"
        GridViewTextBoxColumn29.Name = "colStockAddGross"
        GridViewTextBoxColumn29.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn29.Width = 111
        GridViewTextBoxColumn30.EnableExpressionEditor = False
        GridViewTextBoxColumn30.FieldName = "StockAddFine"
        GridViewTextBoxColumn30.HeaderText = "StockAddFine"
        GridViewTextBoxColumn30.Name = "colStockAddFine"
        GridViewTextBoxColumn30.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn30.Width = 99
        Me.dgvVStockAdd.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn21, GridViewTextBoxColumn22, GridViewTextBoxColumn23, GridViewTextBoxColumn24, GridViewTextBoxColumn25, GridViewTextBoxColumn26, GridViewTextBoxColumn27, GridViewTextBoxColumn28, GridViewTextBoxColumn29, GridViewTextBoxColumn30})
        Me.dgvVStockAdd.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvVStockAdd.MasterTemplate.ViewDefinition = TableViewDefinition3
        Me.dgvVStockAdd.Name = "dgvVStockAdd"
        Me.dgvVStockAdd.ReadOnly = True
        Me.dgvVStockAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvVStockAdd.Size = New System.Drawing.Size(1016, 530)
        Me.dgvVStockAdd.TabIndex = 0
        '
        'BtnPrint
        '
        Me.BtnPrint.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.BtnPrint.Location = New System.Drawing.Point(458, 536)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(75, 25)
        Me.BtnPrint.TabIndex = 0
        Me.BtnPrint.Text = "&Print"
        '
        'BtnExit
        '
        Me.BtnExit.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.BtnExit.Location = New System.Drawing.Point(534, 536)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(75, 25)
        Me.BtnExit.TabIndex = 1
        Me.BtnExit.Text = "E&xit"
        '
        'frmVStockAddition
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1006, 565)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.BtnExit)
        Me.Controls.Add(Me.dgvVStockAdd)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.MaximizeBox = False
        Me.Name = "frmVStockAddition"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Voucher Stock Addition"
        CType(Me.dgvVStockAdd.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvVStockAdd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnPrint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnExit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvVStockAdd As Telerik.WinControls.UI.RadGridView
    Friend WithEvents BtnPrint As Telerik.WinControls.UI.RadButton
    Friend WithEvents BtnExit As Telerik.WinControls.UI.RadButton
End Class
