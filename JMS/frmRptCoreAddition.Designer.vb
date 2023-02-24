<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCoreAdditionRpt
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
        Dim SortDescriptor1 As Telerik.WinControls.Data.SortDescriptor = New Telerik.WinControls.Data.SortDescriptor()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.dgvStockAddition = New Telerik.WinControls.UI.RadGridView()
        Me.btnExit = New Telerik.WinControls.UI.RadButton()
        Me.btnPrint = New Telerik.WinControls.UI.RadButton()
        CType(Me.dgvStockAddition, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvStockAddition.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvStockAddition
        '
        Me.dgvStockAddition.BackColor = System.Drawing.SystemColors.Control
        Me.dgvStockAddition.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvStockAddition.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvStockAddition.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvStockAddition.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvStockAddition.Location = New System.Drawing.Point(5, 3)
        '
        '
        '
        Me.dgvStockAddition.MasterTemplate.AllowAddNewRow = False
        Me.dgvStockAddition.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "CoreRemovalDt"
        GridViewTextBoxColumn1.HeaderText = "Core Removal Dt"
        GridViewTextBoxColumn1.Name = "colRemovalDt"
        GridViewTextBoxColumn1.Width = 117
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "LotNo"
        GridViewTextBoxColumn2.HeaderText = "Lot No."
        GridViewTextBoxColumn2.Name = "colLotNo"
        GridViewTextBoxColumn2.Width = 93
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.FieldName = "MeltingPr"
        GridViewTextBoxColumn3.HeaderText = "Melting %"
        GridViewTextBoxColumn3.Name = "colMeltingPr"
        GridViewTextBoxColumn3.Width = 93
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.HeaderText = "Issue %"
        GridViewTextBoxColumn4.Name = "colIssuePr"
        GridViewTextBoxColumn4.Width = 93
        GridViewTextBoxColumn5.EnableExpressionEditor = False
        GridViewTextBoxColumn5.HeaderText = "Target Gold Wt."
        GridViewTextBoxColumn5.Name = "colTargetGoldWt"
        GridViewTextBoxColumn5.Width = 117
        GridViewTextBoxColumn6.EnableExpressionEditor = False
        GridViewTextBoxColumn6.HeaderText = "Total Rec."
        GridViewTextBoxColumn6.Name = "colTotalRec"
        GridViewTextBoxColumn6.Width = 93
        GridViewTextBoxColumn7.EnableExpressionEditor = False
        GridViewTextBoxColumn7.HeaderText = "Receive %"
        GridViewTextBoxColumn7.Name = "colTotalReceivePr"
        GridViewTextBoxColumn7.Width = 93
        GridViewTextBoxColumn8.EnableExpressionEditor = False
        GridViewTextBoxColumn8.HeaderText = "Loss Wt."
        GridViewTextBoxColumn8.Name = "colLossWt"
        GridViewTextBoxColumn8.Width = 93
        GridViewTextBoxColumn9.EnableExpressionEditor = False
        GridViewTextBoxColumn9.HeaderText = "Core Remains"
        GridViewTextBoxColumn9.Name = "colAdditionRemains"
        GridViewTextBoxColumn9.Width = 93
        GridViewTextBoxColumn10.EnableExpressionEditor = False
        GridViewTextBoxColumn10.HeaderText = "Core Add Fine"
        GridViewTextBoxColumn10.Name = "colCoreAddFine"
        GridViewTextBoxColumn10.Width = 93
        Me.dgvStockAddition.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5, GridViewTextBoxColumn6, GridViewTextBoxColumn7, GridViewTextBoxColumn8, GridViewTextBoxColumn9, GridViewTextBoxColumn10})
        Me.dgvStockAddition.MasterTemplate.ShowRowHeaderColumn = False
        SortDescriptor1.PropertyName = "colIssueDt"
        Me.dgvStockAddition.MasterTemplate.SortDescriptors.AddRange(New Telerik.WinControls.Data.SortDescriptor() {SortDescriptor1})
        Me.dgvStockAddition.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgvStockAddition.Name = "dgvStockAddition"
        Me.dgvStockAddition.ReadOnly = True
        Me.dgvStockAddition.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvStockAddition.Size = New System.Drawing.Size(971, 375)
        Me.dgvStockAddition.TabIndex = 1
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnExit.Location = New System.Drawing.Point(563, 383)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(87, 27)
        Me.btnExit.TabIndex = 29
        Me.btnExit.Text = "E&xit"
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnPrint.Location = New System.Drawing.Point(473, 383)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(87, 27)
        Me.btnPrint.TabIndex = 28
        Me.btnPrint.Text = "&Print"
        '
        'frmCoreAdditionRpt
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(978, 414)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.dgvStockAddition)
        Me.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmCoreAdditionRpt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Core Addition Report"
        CType(Me.dgvStockAddition.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvStockAddition, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvStockAddition As Telerik.WinControls.UI.RadGridView
    Friend WithEvents btnExit As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnPrint As Telerik.WinControls.UI.RadButton
End Class
