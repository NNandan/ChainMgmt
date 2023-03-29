<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTouchConversionRpt
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
        Dim GridViewDecimalColumn1 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn2 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn3 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewTextBoxColumn4 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn5 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn6 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn7 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.dgvTouchConversion = New Telerik.WinControls.UI.RadGridView()
        Me.btnExit = New Telerik.WinControls.UI.RadButton()
        Me.btnPrint = New Telerik.WinControls.UI.RadButton()
        CType(Me.dgvTouchConversion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTouchConversion.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvTouchConversion
        '
        Me.dgvTouchConversion.BackColor = System.Drawing.SystemColors.Control
        Me.dgvTouchConversion.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvTouchConversion.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvTouchConversion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvTouchConversion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvTouchConversion.Location = New System.Drawing.Point(5, 2)
        Me.dgvTouchConversion.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        '
        '
        '
        Me.dgvTouchConversion.MasterTemplate.AllowAddNewRow = False
        Me.dgvTouchConversion.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "IssueDt"
        GridViewTextBoxColumn1.FormatString = "{0:dd/MM/yyyy}"
        GridViewTextBoxColumn1.HeaderText = "Trans Dt."
        GridViewTextBoxColumn1.Name = "colIssueDt"
        GridViewTextBoxColumn1.Width = 90
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "VoucherNo"
        GridViewTextBoxColumn2.HeaderText = "Voucher No"
        GridViewTextBoxColumn2.Name = "colVoucherNo"
        GridViewTextBoxColumn2.Width = 90
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.FieldName = "ItemType"
        GridViewTextBoxColumn3.HeaderText = "Item Type"
        GridViewTextBoxColumn3.Name = "colItemType"
        GridViewTextBoxColumn3.Width = 120
        GridViewDecimalColumn1.AllowFiltering = False
        GridViewDecimalColumn1.AllowGroup = False
        GridViewDecimalColumn1.EnableExpressionEditor = False
        GridViewDecimalColumn1.FieldName = "SlipBagNo"
        GridViewDecimalColumn1.FormatString = "{0:F2}"
        GridViewDecimalColumn1.HeaderText = "SlipBag No"
        GridViewDecimalColumn1.Name = "colSlipBagNo"
        GridViewDecimalColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        GridViewDecimalColumn1.Width = 90
        GridViewDecimalColumn2.AllowFiltering = False
        GridViewDecimalColumn2.AllowGroup = False
        GridViewDecimalColumn2.EnableExpressionEditor = False
        GridViewDecimalColumn2.FieldName = "ItemName"
        GridViewDecimalColumn2.FormatString = "{0:F2}"
        GridViewDecimalColumn2.HeaderText = "Item Name"
        GridViewDecimalColumn2.Name = "colItemName"
        GridViewDecimalColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        GridViewDecimalColumn2.Width = 175
        GridViewDecimalColumn3.AllowFiltering = False
        GridViewDecimalColumn3.AllowGroup = False
        GridViewDecimalColumn3.EnableExpressionEditor = False
        GridViewDecimalColumn3.FieldName = "IssueWt"
        GridViewDecimalColumn3.FormatString = "{0:F2}"
        GridViewDecimalColumn3.HeaderText = "Issue Wt"
        GridViewDecimalColumn3.Name = "colIssueWt"
        GridViewDecimalColumn3.Width = 90
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.FieldName = "IssuePr"
        GridViewTextBoxColumn4.HeaderText = "Issue %"
        GridViewTextBoxColumn4.Name = "colIssuePr"
        GridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn4.Width = 90
        GridViewTextBoxColumn5.EnableExpressionEditor = False
        GridViewTextBoxColumn5.FieldName = "ConvPr"
        GridViewTextBoxColumn5.HeaderText = "Con. %"
        GridViewTextBoxColumn5.Name = "colConvPr"
        GridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn5.Width = 90
        GridViewTextBoxColumn6.EnableExpressionEditor = False
        GridViewTextBoxColumn6.FieldName = "FineWt"
        GridViewTextBoxColumn6.HeaderText = "Fine Wt."
        GridViewTextBoxColumn6.Name = "colFineWt"
        GridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn6.Width = 90
        GridViewTextBoxColumn7.EnableExpressionEditor = False
        GridViewTextBoxColumn7.FieldName = "StockAdd"
        GridViewTextBoxColumn7.HeaderText = "Stock Add."
        GridViewTextBoxColumn7.Name = "colStockAdd"
        GridViewTextBoxColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn7.Width = 90
        Me.dgvTouchConversion.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewDecimalColumn1, GridViewDecimalColumn2, GridViewDecimalColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5, GridViewTextBoxColumn6, GridViewTextBoxColumn7})
        Me.dgvTouchConversion.MasterTemplate.EnableGrouping = False
        Me.dgvTouchConversion.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvTouchConversion.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgvTouchConversion.Name = "dgvTouchConversion"
        Me.dgvTouchConversion.ReadOnly = True
        Me.dgvTouchConversion.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvTouchConversion.Size = New System.Drawing.Size(1007, 699)
        Me.dgvTouchConversion.TabIndex = 5
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnExit.Location = New System.Drawing.Point(512, 708)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 25)
        Me.btnExit.TabIndex = 30
        Me.btnExit.Text = "E&xit"
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnPrint.Location = New System.Drawing.Point(436, 708)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 25)
        Me.btnPrint.TabIndex = 29
        Me.btnPrint.Text = "&Print"
        '
        'frmTouchConversionRpt
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1014, 738)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.dgvTouchConversion)
        Me.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.Name = "frmTouchConversionRpt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Touch Conversion Report"
        CType(Me.dgvTouchConversion.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTouchConversion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvTouchConversion As Telerik.WinControls.UI.RadGridView
    Friend WithEvents btnExit As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnPrint As Telerik.WinControls.UI.RadButton
End Class
