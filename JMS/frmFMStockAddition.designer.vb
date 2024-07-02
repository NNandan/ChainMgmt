<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFMStockAddition
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
        Me.BtnPrint.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.BtnPrint.Location = New System.Drawing.Point(351, 406)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(75, 25)
        Me.BtnPrint.TabIndex = 0
        Me.BtnPrint.Text = "&Print"
        '
        'BtnExit
        '
        Me.BtnExit.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.BtnExit.Location = New System.Drawing.Point(428, 406)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(75, 25)
        Me.BtnExit.TabIndex = 1
        Me.BtnExit.Text = "E&xit"
        '
        'dgvMStockAdd
        '
        Me.dgvMStockAdd.BackColor = System.Drawing.SystemColors.Control
        Me.dgvMStockAdd.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvMStockAdd.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvMStockAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvMStockAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvMStockAdd.Location = New System.Drawing.Point(2, 0)
        '
        '
        '
        Me.dgvMStockAdd.MasterTemplate.AllowAddNewRow = False
        Me.dgvMStockAdd.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "MeltingDt"
        GridViewTextBoxColumn1.HeaderText = "Melting Dt."
        GridViewTextBoxColumn1.Name = "colMeltingDt"
        GridViewTextBoxColumn1.Width = 90
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "LotNo"
        GridViewTextBoxColumn2.HeaderText = "Lot No."
        GridViewTextBoxColumn2.Name = "colLotNo"
        GridViewTextBoxColumn2.Width = 90
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.FieldName = "RequirePr"
        GridViewTextBoxColumn3.HeaderText = "Required [%]"
        GridViewTextBoxColumn3.Name = "colRequirePr"
        GridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn3.Width = 90
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.FieldName = "ConvertToMelting"
        GridViewTextBoxColumn4.HeaderText = "Convert To Melting"
        GridViewTextBoxColumn4.Name = "colConvertToMelting"
        GridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn4.Width = 110
        GridViewTextBoxColumn5.EnableExpressionEditor = False
        GridViewTextBoxColumn5.FieldName = "ConvertedPr"
        GridViewTextBoxColumn5.HeaderText = "Converted [%]"
        GridViewTextBoxColumn5.Name = "colConvertedPr"
        GridViewTextBoxColumn5.Width = 90
        GridViewTextBoxColumn6.EnableExpressionEditor = False
        GridViewTextBoxColumn6.FieldName = "GrossWt"
        GridViewTextBoxColumn6.HeaderText = "Gross Wt."
        GridViewTextBoxColumn6.Name = "colGrossWt"
        GridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn6.Width = 80
        GridViewTextBoxColumn7.EnableExpressionEditor = False
        GridViewTextBoxColumn7.FieldName = "FineWt"
        GridViewTextBoxColumn7.HeaderText = "FineWt"
        GridViewTextBoxColumn7.Name = "colFineWt"
        GridViewTextBoxColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn7.Width = 80
        GridViewTextBoxColumn8.EnableExpressionEditor = False
        GridViewTextBoxColumn8.FieldName = "StockAddGross"
        GridViewTextBoxColumn8.HeaderText = "StockAddGross"
        GridViewTextBoxColumn8.Name = "colStockAddGross"
        GridViewTextBoxColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn8.Width = 90
        GridViewTextBoxColumn9.EnableExpressionEditor = False
        GridViewTextBoxColumn9.FieldName = "StockAddFine"
        GridViewTextBoxColumn9.HeaderText = "StockAddFine"
        GridViewTextBoxColumn9.Name = "colStockAddFine"
        GridViewTextBoxColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn9.Width = 90
        Me.dgvMStockAdd.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5, GridViewTextBoxColumn6, GridViewTextBoxColumn7, GridViewTextBoxColumn8, GridViewTextBoxColumn9})
        Me.dgvMStockAdd.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvMStockAdd.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgvMStockAdd.Name = "dgvMStockAdd"
        Me.dgvMStockAdd.ReadOnly = True
        Me.dgvMStockAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvMStockAdd.Size = New System.Drawing.Size(804, 402)
        Me.dgvMStockAdd.TabIndex = 0
        '
        'frmFMStockAddition
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(807, 435)
        Me.Controls.Add(Me.dgvMStockAdd)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.BtnExit)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Name = "frmFMStockAddition"
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
