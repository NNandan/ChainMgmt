<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFaMStockAddition
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
        Me.BtnPrint = New Telerik.WinControls.UI.RadButton()
        Me.BtnExit = New Telerik.WinControls.UI.RadButton()
        Me.dgvMStockAdd = New Telerik.WinControls.UI.RadGridView()
        CType(Me.BtnPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvMStockAdd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvMStockAdd.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnPrint
        '
        Me.BtnPrint.Location = New System.Drawing.Point(338, 511)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(75, 25)
        Me.BtnPrint.TabIndex = 0
        Me.BtnPrint.Text = "&Print"
        '
        'BtnExit
        '
        Me.BtnExit.Location = New System.Drawing.Point(419, 511)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(75, 25)
        Me.BtnExit.TabIndex = 1
        Me.BtnExit.Text = "E&xit"
        '
        'dgvMStockAdd
        '
        Me.dgvMStockAdd.BackColor = System.Drawing.SystemColors.Control
        Me.dgvMStockAdd.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvMStockAdd.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.dgvMStockAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvMStockAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvMStockAdd.Location = New System.Drawing.Point(0, 0)
        '
        '
        '
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "MeltingDt"
        GridViewTextBoxColumn1.HeaderText = "MeltingDt"
        GridViewTextBoxColumn1.Name = "colMeltingDt"
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "LotNo"
        GridViewTextBoxColumn2.HeaderText = "LotNo"
        GridViewTextBoxColumn2.Name = "colLotNo"
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.FieldName = "RequirePr"
        GridViewTextBoxColumn3.HeaderText = "RequirePr"
        GridViewTextBoxColumn3.Name = "colRequirePr"
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.FieldName = "ConvertToMelting"
        GridViewTextBoxColumn4.HeaderText = "ConvertToMelting"
        GridViewTextBoxColumn4.Name = "colConvertToMelting"
        GridViewTextBoxColumn5.EnableExpressionEditor = False
        GridViewTextBoxColumn5.FieldName = "ConvertedPr"
        GridViewTextBoxColumn5.HeaderText = "ConvertedPr"
        GridViewTextBoxColumn5.Name = "colConvertedPr"
        GridViewTextBoxColumn6.EnableExpressionEditor = False
        GridViewTextBoxColumn6.FieldName = "GrossWt"
        GridViewTextBoxColumn6.HeaderText = "GrossWt"
        GridViewTextBoxColumn6.Name = "colGrossWt"
        GridViewTextBoxColumn7.EnableExpressionEditor = False
        GridViewTextBoxColumn7.FieldName = "FineWt"
        GridViewTextBoxColumn7.HeaderText = "FineWt"
        GridViewTextBoxColumn7.Name = "colFineWt"
        GridViewTextBoxColumn8.EnableExpressionEditor = False
        GridViewTextBoxColumn8.FieldName = "StockAddGross"
        GridViewTextBoxColumn8.HeaderText = "StockAddGross"
        GridViewTextBoxColumn8.Name = "colStockAddGross"
        GridViewTextBoxColumn9.EnableExpressionEditor = False
        GridViewTextBoxColumn9.FieldName = "StockAddFine"
        GridViewTextBoxColumn9.HeaderText = "StockAddFine"
        GridViewTextBoxColumn9.Name = "colStockAddFine"
        Me.dgvMStockAdd.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5, GridViewTextBoxColumn6, GridViewTextBoxColumn7, GridViewTextBoxColumn8, GridViewTextBoxColumn9})
        Me.dgvMStockAdd.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgvMStockAdd.Name = "dgvMStockAdd"
        Me.dgvMStockAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvMStockAdd.Size = New System.Drawing.Size(784, 354)
        Me.dgvMStockAdd.TabIndex = 0
        '
        'frmMStockAddition
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(789, 547)
        Me.Controls.Add(Me.dgvMStockAdd)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.BtnExit)
        Me.Name = "frmMStockAddition"
        Me.Text = "frmMStockAddition"
        CType(Me.BtnPrint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvMStockAdd.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvMStockAdd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnPrint As Telerik.WinControls.UI.RadButton
    Friend WithEvents BtnExit As Telerik.WinControls.UI.RadButton
    Friend WithEvents dgvMStockAdd As Telerik.WinControls.UI.RadGridView
End Class
