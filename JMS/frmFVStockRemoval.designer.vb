<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFVStockRemoval
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
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn4 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn5 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn6 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn7 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn8 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn9 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn10 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
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
        Me.dgvVStockRemv.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvVStockRemv.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvVStockRemv.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvVStockRemv.Location = New System.Drawing.Point(0, 2)
        '
        '
        '
        Me.dgvVStockRemv.MasterTemplate.AllowAddNewRow = False
        Me.dgvVStockRemv.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "ReceiptDt"
        GridViewTextBoxColumn1.HeaderText = "ReceiptDt"
        GridViewTextBoxColumn1.MinWidth = 6
        GridViewTextBoxColumn1.Name = "colReceiptDt"
        GridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn1.Width = 90
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "VoucherNo"
        GridViewTextBoxColumn2.HeaderText = "VoucherNo"
        GridViewTextBoxColumn2.MinWidth = 6
        GridViewTextBoxColumn2.Name = "colVoucherNo"
        GridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn2.Width = 90
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.FieldName = "ReceivePr"
        GridViewTextBoxColumn3.HeaderText = "Receive [%]"
        GridViewTextBoxColumn3.MinWidth = 6
        GridViewTextBoxColumn3.Name = "colReceivePr"
        GridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn3.Width = 82
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.FieldName = "ConvPr"
        GridViewTextBoxColumn4.HeaderText = "Conv [%]"
        GridViewTextBoxColumn4.MinWidth = 6
        GridViewTextBoxColumn4.Name = "colConvPr"
        GridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn4.Width = 82
        GridViewTextBoxColumn5.EnableExpressionEditor = False
        GridViewTextBoxColumn5.FieldName = "ReceiveWt"
        GridViewTextBoxColumn5.HeaderText = "Receive Wt."
        GridViewTextBoxColumn5.MinWidth = 6
        GridViewTextBoxColumn5.Name = "colReceiveWt"
        GridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn5.Width = 105
        GridViewTextBoxColumn6.EnableExpressionEditor = False
        GridViewTextBoxColumn6.FieldName = "RecFineWt"
        GridViewTextBoxColumn6.HeaderText = "Rec Fine Wt."
        GridViewTextBoxColumn6.MinWidth = 6
        GridViewTextBoxColumn6.Name = "colRecFineWt"
        GridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn6.Width = 82
        GridViewTextBoxColumn7.EnableExpressionEditor = False
        GridViewTextBoxColumn7.FieldName = "PercentAdd"
        GridViewTextBoxColumn7.HeaderText = "Add [%]"
        GridViewTextBoxColumn7.MinWidth = 6
        GridViewTextBoxColumn7.Name = "colPercentAdd"
        GridViewTextBoxColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn7.Width = 90
        GridViewTextBoxColumn8.EnableExpressionEditor = False
        GridViewTextBoxColumn8.FieldName = "ConFineWt"
        GridViewTextBoxColumn8.HeaderText = "Con Fine Wt."
        GridViewTextBoxColumn8.MinWidth = 6
        GridViewTextBoxColumn8.Name = "colConFineWt"
        GridViewTextBoxColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn8.Width = 90
        GridViewTextBoxColumn9.EnableExpressionEditor = False
        GridViewTextBoxColumn9.FieldName = "StockAddGross"
        GridViewTextBoxColumn9.HeaderText = "Stock Add Gross"
        GridViewTextBoxColumn9.MinWidth = 6
        GridViewTextBoxColumn9.Name = "colStockAddGross"
        GridViewTextBoxColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn9.Width = 115
        GridViewTextBoxColumn10.EnableExpressionEditor = False
        GridViewTextBoxColumn10.FieldName = "StockAddFine"
        GridViewTextBoxColumn10.HeaderText = "Stock Add Fine"
        GridViewTextBoxColumn10.MinWidth = 6
        GridViewTextBoxColumn10.Name = "colStockAddFine"
        GridViewTextBoxColumn10.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn10.Width = 105
        Me.dgvVStockRemv.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5, GridViewTextBoxColumn6, GridViewTextBoxColumn7, GridViewTextBoxColumn8, GridViewTextBoxColumn9, GridViewTextBoxColumn10})
        Me.dgvVStockRemv.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvVStockRemv.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgvVStockRemv.Name = "dgvVStockRemv"
        Me.dgvVStockRemv.ReadOnly = True
        Me.dgvVStockRemv.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvVStockRemv.ShowGroupPanel = False
        Me.dgvVStockRemv.Size = New System.Drawing.Size(924, 474)
        Me.dgvVStockRemv.TabIndex = 0
        '
        'BtnPrint
        '
        Me.BtnPrint.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.BtnPrint.Location = New System.Drawing.Point(401, 480)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(75, 25)
        Me.BtnPrint.TabIndex = 1
        Me.BtnPrint.Text = "&Print"
        '
        'BtnExit
        '
        Me.BtnExit.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.BtnExit.Location = New System.Drawing.Point(478, 480)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(75, 25)
        Me.BtnExit.TabIndex = 2
        Me.BtnExit.Text = "E&xit"
        '
        'frmFVStockRemoval
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(926, 508)
        Me.Controls.Add(Me.BtnExit)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.dgvVStockRemv)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.MaximizeBox = False
        Me.Name = "frmFVStockRemoval"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
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
