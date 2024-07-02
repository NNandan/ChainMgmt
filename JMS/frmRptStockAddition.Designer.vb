<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStockAdditionRpt
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
        Dim GridViewTextBoxColumn11 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
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
        GridViewTextBoxColumn1.FieldName = "IssueDt"
        GridViewTextBoxColumn1.HeaderText = "Issue Dt."
        GridViewTextBoxColumn1.Name = "colIssueDt"
        GridViewTextBoxColumn1.SortOrder = Telerik.WinControls.UI.RadSortOrder.Ascending
        GridViewTextBoxColumn1.Width = 80
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "VoucherNo"
        GridViewTextBoxColumn2.HeaderText = "VoucherNo"
        GridViewTextBoxColumn2.Name = "colVoucherNo"
        GridViewTextBoxColumn2.Width = 80
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.FieldName = "ItemType"
        GridViewTextBoxColumn3.HeaderText = "Item Type"
        GridViewTextBoxColumn3.Name = "colItemType"
        GridViewTextBoxColumn3.Width = 80
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.FieldName = "SlipBagNo"
        GridViewTextBoxColumn4.HeaderText = "Slip/Bag No"
        GridViewTextBoxColumn4.Name = "colSlipBagNo"
        GridViewTextBoxColumn4.Width = 100
        GridViewTextBoxColumn5.EnableExpressionEditor = False
        GridViewTextBoxColumn5.FieldName = "ItemName"
        GridViewTextBoxColumn5.HeaderText = "Item Name"
        GridViewTextBoxColumn5.Name = "colItemName"
        GridViewTextBoxColumn5.Width = 150
        GridViewTextBoxColumn6.EnableExpressionEditor = False
        GridViewTextBoxColumn6.FieldName = "IssueWt"
        GridViewTextBoxColumn6.HeaderText = "Issue Wt."
        GridViewTextBoxColumn6.Name = "colIssueWt"
        GridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn6.Width = 80
        GridViewTextBoxColumn7.EnableExpressionEditor = False
        GridViewTextBoxColumn7.FieldName = "IssuePr"
        GridViewTextBoxColumn7.HeaderText = "Issue %"
        GridViewTextBoxColumn7.Name = "colIssuePr"
        GridViewTextBoxColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn7.Width = 80
        GridViewTextBoxColumn8.EnableExpressionEditor = False
        GridViewTextBoxColumn8.FieldName = "ConvPr"
        GridViewTextBoxColumn8.HeaderText = "Conv %"
        GridViewTextBoxColumn8.Name = "colConvPr"
        GridViewTextBoxColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn8.Width = 80
        GridViewTextBoxColumn9.EnableExpressionEditor = False
        GridViewTextBoxColumn9.FieldName = "CFineWt"
        GridViewTextBoxColumn9.HeaderText = "Fine Wt."
        GridViewTextBoxColumn9.Name = "colCFineWt"
        GridViewTextBoxColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn9.Width = 80
        GridViewTextBoxColumn10.EnableExpressionEditor = False
        GridViewTextBoxColumn10.FieldName = "NFineWt"
        GridViewTextBoxColumn10.HeaderText = "Fine Wt."
        GridViewTextBoxColumn10.IsVisible = False
        GridViewTextBoxColumn10.Name = "colNFineWt"
        GridViewTextBoxColumn10.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn10.Width = 80
        GridViewTextBoxColumn11.EnableExpressionEditor = False
        GridViewTextBoxColumn11.Expression = "CDBL(colCFineWt) - CDBL(colNFineWt) "
        GridViewTextBoxColumn11.HeaderText = "Stock Add"
        GridViewTextBoxColumn11.Name = "colStockAdd"
        GridViewTextBoxColumn11.ReadOnly = True
        GridViewTextBoxColumn11.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn11.Width = 80
        Me.dgvStockAddition.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5, GridViewTextBoxColumn6, GridViewTextBoxColumn7, GridViewTextBoxColumn8, GridViewTextBoxColumn9, GridViewTextBoxColumn10, GridViewTextBoxColumn11})
        SortDescriptor1.PropertyName = "colIssueDt"
        Me.dgvStockAddition.MasterTemplate.SortDescriptors.AddRange(New Telerik.WinControls.Data.SortDescriptor() {SortDescriptor1})
        Me.dgvStockAddition.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgvStockAddition.Name = "dgvStockAddition"
        Me.dgvStockAddition.ReadOnly = True
        Me.dgvStockAddition.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvStockAddition.Size = New System.Drawing.Size(904, 347)
        Me.dgvStockAddition.TabIndex = 0
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnExit.Location = New System.Drawing.Point(466, 355)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 25)
        Me.btnExit.TabIndex = 27
        Me.btnExit.Text = "E&xit"
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnPrint.Location = New System.Drawing.Point(389, 355)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 25)
        Me.btnPrint.TabIndex = 26
        Me.btnPrint.Text = "&Print"
        '
        'frmStockAdditionRpt
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(913, 384)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.dgvStockAddition)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmStockAdditionRpt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock Addition Report"
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
