<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFaMetalUsedReport
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
        Dim GridViewDecimalColumn1 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewTextBoxColumn4 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewDecimalColumn2 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewTextBoxColumn5 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.dgvMeltingBagList = New Telerik.WinControls.UI.RadGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnExit = New Telerik.WinControls.UI.RadButton()
        Me.btnPrint = New Telerik.WinControls.UI.RadButton()
        CType(Me.dgvMeltingBagList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvMeltingBagList.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvMeltingBagList
        '
        Me.dgvMeltingBagList.BackColor = System.Drawing.SystemColors.Control
        Me.dgvMeltingBagList.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvMeltingBagList.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvMeltingBagList.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvMeltingBagList.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvMeltingBagList.Location = New System.Drawing.Point(6, 35)
        '
        '
        '
        Me.dgvMeltingBagList.MasterTemplate.AllowAddNewRow = False
        Me.dgvMeltingBagList.MasterTemplate.AllowColumnReorder = False
        Me.dgvMeltingBagList.MasterTemplate.AllowDeleteRow = False
        Me.dgvMeltingBagList.MasterTemplate.AllowEditRow = False
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "SlipBagNo"
        GridViewTextBoxColumn1.HeaderText = "Voucher No."
        GridViewTextBoxColumn1.Name = "colVoucherNo"
        GridViewTextBoxColumn1.Width = 118
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "ItemName"
        GridViewTextBoxColumn2.HeaderText = "Item Name"
        GridViewTextBoxColumn2.Name = "colItemName"
        GridViewTextBoxColumn2.Width = 142
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.FieldName = "Used In"
        GridViewTextBoxColumn3.HeaderText = "Used In"
        GridViewTextBoxColumn3.Name = "colUsedIn"
        GridViewTextBoxColumn3.Width = 89
        GridViewDecimalColumn1.AllowFiltering = False
        GridViewDecimalColumn1.AllowGroup = False
        GridViewDecimalColumn1.EnableExpressionEditor = False
        GridViewDecimalColumn1.FieldName = "LotNo"
        GridViewDecimalColumn1.FormatString = "{0:F2}"
        GridViewDecimalColumn1.HeaderText = "Lot No."
        GridViewDecimalColumn1.Name = "colUsedInLotNo"
        GridViewDecimalColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        GridViewDecimalColumn1.Width = 100
        GridViewTextBoxColumn4.AllowFiltering = False
        GridViewTextBoxColumn4.AllowGroup = False
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.FieldName = "IssueWt"
        GridViewTextBoxColumn4.FormatString = "{0:F2}"
        GridViewTextBoxColumn4.HeaderText = "Issue Wt."
        GridViewTextBoxColumn4.Name = "colIssueWt"
        GridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn4.Width = 87
        GridViewDecimalColumn2.AllowFiltering = False
        GridViewDecimalColumn2.AllowGroup = False
        GridViewDecimalColumn2.EnableExpressionEditor = False
        GridViewDecimalColumn2.FieldName = "IssuePr"
        GridViewDecimalColumn2.FormatString = "{0:F2}"
        GridViewDecimalColumn2.HeaderText = "Issue [%]"
        GridViewDecimalColumn2.Name = "colIssuePr"
        GridViewDecimalColumn2.Width = 80
        GridViewTextBoxColumn5.EnableExpressionEditor = False
        GridViewTextBoxColumn5.FieldName = "FineWt"
        GridViewTextBoxColumn5.HeaderText = "Fine Wt."
        GridViewTextBoxColumn5.Name = "colFineWt"
        GridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn5.Width = 100
        Me.dgvMeltingBagList.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewDecimalColumn1, GridViewTextBoxColumn4, GridViewDecimalColumn2, GridViewTextBoxColumn5})
        Me.dgvMeltingBagList.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvMeltingBagList.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgvMeltingBagList.Name = "dgvMeltingBagList"
        Me.dgvMeltingBagList.ReadOnly = True
        Me.dgvMeltingBagList.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvMeltingBagList.Size = New System.Drawing.Size(712, 371)
        Me.dgvMeltingBagList.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(244, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(236, 20)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Metal Used By Voucher Number"
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnExit.Location = New System.Drawing.Point(370, 412)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 25)
        Me.btnExit.TabIndex = 27
        Me.btnExit.Text = "E&xit"
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnPrint.Location = New System.Drawing.Point(292, 412)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 25)
        Me.btnPrint.TabIndex = 26
        Me.btnPrint.Text = "&Print"
        '
        'frmFaMetalUsedReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(724, 441)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvMeltingBagList)
        Me.MaximizeBox = False
        Me.Name = "frmFaMetalUsedReport"
        Me.Text = "Metal Used By Voucher Number"
        CType(Me.dgvMeltingBagList.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvMeltingBagList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvMeltingBagList As Telerik.WinControls.UI.RadGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents btnExit As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnPrint As Telerik.WinControls.UI.RadButton
End Class
