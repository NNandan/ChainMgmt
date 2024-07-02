<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRptLotAdditionOpStock
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
        Dim GridViewDecimalColumn1 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn4 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn5 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim SortDescriptor1 As Telerik.WinControls.Data.SortDescriptor = New Telerik.WinControls.Data.SortDescriptor()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.dgvLotAdditionStock = New Telerik.WinControls.UI.RadGridView()
        Me.btnPrint = New Telerik.WinControls.UI.RadButton()
        Me.btnExit = New Telerik.WinControls.UI.RadButton()
        CType(Me.dgvLotAdditionStock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvLotAdditionStock.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvLotAdditionStock
        '
        Me.dgvLotAdditionStock.BackColor = System.Drawing.SystemColors.Control
        Me.dgvLotAdditionStock.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvLotAdditionStock.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvLotAdditionStock.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvLotAdditionStock.GroupExpandAnimationType = Telerik.WinControls.UI.GridExpandAnimationType.GradientWipe
        Me.dgvLotAdditionStock.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvLotAdditionStock.Location = New System.Drawing.Point(5, 5)
        '
        '
        '
        Me.dgvLotAdditionStock.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "LotNo"
        GridViewTextBoxColumn1.HeaderText = "Lot No."
        GridViewTextBoxColumn1.Name = "colLotNumber"
        GridViewTextBoxColumn1.Width = 100
        GridViewDecimalColumn1.AllowFiltering = False
        GridViewDecimalColumn1.AllowGroup = False
        GridViewDecimalColumn1.EnableExpressionEditor = False
        GridViewDecimalColumn1.FieldName = "Operation"
        GridViewDecimalColumn1.HeaderText = "Opreation Name"
        GridViewDecimalColumn1.Name = "colOpreationName"
        GridViewDecimalColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        GridViewDecimalColumn1.Width = 160
        GridViewTextBoxColumn2.AllowFiltering = False
        GridViewTextBoxColumn2.AllowGroup = False
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "ItemName"
        GridViewTextBoxColumn2.HeaderText = "Item Name"
        GridViewTextBoxColumn2.Name = "colItemName"
        GridViewTextBoxColumn2.Width = 150
        GridViewTextBoxColumn3.AllowFiltering = False
        GridViewTextBoxColumn3.AllowGroup = False
        GridViewTextBoxColumn3.AllowReorder = False
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.FieldName = "GrossWt"
        GridViewTextBoxColumn3.HeaderText = "Gross Wt."
        GridViewTextBoxColumn3.Name = "colGrossWt"
        GridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn3.Width = 90
        GridViewTextBoxColumn4.AllowFiltering = False
        GridViewTextBoxColumn4.AllowGroup = False
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.FieldName = "GrossPr"
        GridViewTextBoxColumn4.HeaderText = "Gross %"
        GridViewTextBoxColumn4.Name = "colGrossPr"
        GridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn4.Width = 90
        GridViewTextBoxColumn5.AllowFiltering = False
        GridViewTextBoxColumn5.AllowGroup = False
        GridViewTextBoxColumn5.EnableExpressionEditor = False
        GridViewTextBoxColumn5.FieldName = "FineWt"
        GridViewTextBoxColumn5.HeaderText = "Fine Wt."
        GridViewTextBoxColumn5.Name = "colFineWt"
        GridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn5.Width = 90
        Me.dgvLotAdditionStock.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewDecimalColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5})
        Me.dgvLotAdditionStock.MasterTemplate.ShowRowHeaderColumn = False
        SortDescriptor1.PropertyName = "colLotFailBagNo"
        Me.dgvLotAdditionStock.MasterTemplate.SortDescriptors.AddRange(New Telerik.WinControls.Data.SortDescriptor() {SortDescriptor1})
        Me.dgvLotAdditionStock.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgvLotAdditionStock.Name = "dgvLotAdditionStock"
        Me.dgvLotAdditionStock.ReadOnly = True
        Me.dgvLotAdditionStock.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvLotAdditionStock.Size = New System.Drawing.Size(678, 467)
        Me.dgvLotAdditionStock.TabIndex = 5
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnPrint.Location = New System.Drawing.Point(264, 479)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 25)
        Me.btnPrint.TabIndex = 6
        Me.btnPrint.Text = "&Print"
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnExit.Location = New System.Drawing.Point(340, 479)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 25)
        Me.btnExit.TabIndex = 25
        Me.btnExit.Text = "E&xit"
        '
        'frmRptLotAdditionOpStock
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(689, 509)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.dgvLotAdditionStock)
        Me.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmRptLotAdditionOpStock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lot Addition Op. Stock"
        CType(Me.dgvLotAdditionStock.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvLotAdditionStock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvLotAdditionStock As Telerik.WinControls.UI.RadGridView
    Friend WithEvents btnPrint As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnExit As Telerik.WinControls.UI.RadButton
End Class
