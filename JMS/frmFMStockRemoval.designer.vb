<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFMStockRemoval
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
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.dgvMStockRemv = New Telerik.WinControls.UI.RadGridView()
        Me.BtnPrint = New Telerik.WinControls.UI.RadButton()
        Me.BtnExit = New Telerik.WinControls.UI.RadButton()
        CType(Me.dgvMStockRemv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvMStockRemv.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvMStockRemv
        '
        Me.dgvMStockRemv.BackColor = System.Drawing.SystemColors.Control
        Me.dgvMStockRemv.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvMStockRemv.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvMStockRemv.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvMStockRemv.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvMStockRemv.Location = New System.Drawing.Point(0, 0)
        '
        '
        '
        Me.dgvMStockRemv.MasterTemplate.AllowAddNewRow = False
        Me.dgvMStockRemv.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "MeltingDt"
        GridViewTextBoxColumn1.HeaderText = "Melting Dt."
        GridViewTextBoxColumn1.Name = "colMeltingDt"
        GridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn1.Width = 90
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "LotNo"
        GridViewTextBoxColumn2.HeaderText = "Lot No."
        GridViewTextBoxColumn2.Name = "colLotNo"
        GridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn2.Width = 90
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.FieldName = "RequirePr"
        GridViewTextBoxColumn3.HeaderText = "Require [%]"
        GridViewTextBoxColumn3.Name = "colRequirePr"
        GridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn3.Width = 80
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.FieldName = "ConvertToMelting"
        GridViewTextBoxColumn4.HeaderText = "Convert To Melting"
        GridViewTextBoxColumn4.Name = "colConvertToMelting"
        GridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn4.Width = 100
        GridViewTextBoxColumn5.EnableExpressionEditor = False
        GridViewTextBoxColumn5.FieldName = "GrossWt"
        GridViewTextBoxColumn5.HeaderText = "Gross Wt."
        GridViewTextBoxColumn5.Name = "colGrossWt"
        GridViewTextBoxColumn5.Width = 90
        GridViewTextBoxColumn6.EnableExpressionEditor = False
        GridViewTextBoxColumn6.FieldName = "FineWt"
        GridViewTextBoxColumn6.HeaderText = "Fine Wt."
        GridViewTextBoxColumn6.Name = "colFineWt"
        GridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn6.Width = 90
        GridViewTextBoxColumn7.EnableExpressionEditor = False
        GridViewTextBoxColumn7.FieldName = "StockAddGross"
        GridViewTextBoxColumn7.HeaderText = "Stock Add Gross"
        GridViewTextBoxColumn7.Name = "colStockAddGross"
        GridViewTextBoxColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn7.Width = 100
        GridViewTextBoxColumn8.EnableExpressionEditor = False
        GridViewTextBoxColumn8.FieldName = "ConvertedPr"
        GridViewTextBoxColumn8.HeaderText = "Converted [%]"
        GridViewTextBoxColumn8.Name = "colConvertedPr"
        GridViewTextBoxColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn8.Width = 100
        GridViewTextBoxColumn9.EnableExpressionEditor = False
        GridViewTextBoxColumn9.FieldName = "StockAddFine"
        GridViewTextBoxColumn9.HeaderText = "Stock Add Fine"
        GridViewTextBoxColumn9.Name = "colStockAddFine"
        GridViewTextBoxColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn9.Width = 100
        Me.dgvMStockRemv.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5, GridViewTextBoxColumn6, GridViewTextBoxColumn7, GridViewTextBoxColumn8, GridViewTextBoxColumn9})
        Me.dgvMStockRemv.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvMStockRemv.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgvMStockRemv.Name = "dgvMStockRemv"
        Me.dgvMStockRemv.ReadOnly = True
        Me.dgvMStockRemv.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvMStockRemv.ShowGroupPanel = False
        Me.dgvMStockRemv.Size = New System.Drawing.Size(826, 475)
        Me.dgvMStockRemv.TabIndex = 0
        '
        'BtnPrint
        '
        Me.BtnPrint.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.BtnPrint.Location = New System.Drawing.Point(348, 482)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(75, 25)
        Me.BtnPrint.TabIndex = 1
        Me.BtnPrint.Text = "&Print"
        '
        'BtnExit
        '
        Me.BtnExit.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.BtnExit.Location = New System.Drawing.Point(424, 482)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(75, 25)
        Me.BtnExit.TabIndex = 2
        Me.BtnExit.Text = "E&xit"
        '
        'frmFMStockRemoval
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(824, 511)
        Me.Controls.Add(Me.BtnExit)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.dgvMStockRemv)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.MaximizeBox = False
        Me.Name = "frmFMStockRemoval"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmMStockRemoval"
        CType(Me.dgvMStockRemv.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvMStockRemv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnPrint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnExit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvMStockRemv As Telerik.WinControls.UI.RadGridView
    Friend WithEvents BtnPrint As Telerik.WinControls.UI.RadButton
    Friend WithEvents BtnExit As Telerik.WinControls.UI.RadButton
End Class
