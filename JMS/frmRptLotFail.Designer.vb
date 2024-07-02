<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRptLotFail
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
        Dim GridViewTextBoxColumn6 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim SortDescriptor1 As Telerik.WinControls.Data.SortDescriptor = New Telerik.WinControls.Data.SortDescriptor()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.dgvLotFailList = New Telerik.WinControls.UI.RadGridView()
        Me.btnPrint = New Telerik.WinControls.UI.RadButton()
        Me.btnExit = New Telerik.WinControls.UI.RadButton()
        CType(Me.dgvLotFailList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvLotFailList.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvLotFailList
        '
        Me.dgvLotFailList.BackColor = System.Drawing.SystemColors.Control
        Me.dgvLotFailList.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvLotFailList.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvLotFailList.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvLotFailList.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvLotFailList.Location = New System.Drawing.Point(3, 2)
        '
        '
        '
        Me.dgvLotFailList.MasterTemplate.AllowAddNewRow = False
        Me.dgvLotFailList.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "LotNo"
        GridViewTextBoxColumn1.HeaderText = "Lot No."
        GridViewTextBoxColumn1.Name = "colLotNumber"
        GridViewTextBoxColumn1.Width = 78
        GridViewDecimalColumn1.AllowFiltering = False
        GridViewDecimalColumn1.AllowGroup = False
        GridViewDecimalColumn1.EnableExpressionEditor = False
        GridViewDecimalColumn1.FieldName = "LotFailWt"
        GridViewDecimalColumn1.HeaderText = "LotFail Wt."
        GridViewDecimalColumn1.Name = "colLotFailWt"
        GridViewDecimalColumn1.Width = 90
        GridViewTextBoxColumn2.AllowFiltering = False
        GridViewTextBoxColumn2.AllowGroup = False
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "LotFailPr"
        GridViewTextBoxColumn2.HeaderText = "LotFail %"
        GridViewTextBoxColumn2.Name = "colLotFailPr"
        GridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn2.Width = 90
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.FieldName = "Remark"
        GridViewTextBoxColumn3.HeaderText = "Remark"
        GridViewTextBoxColumn3.Name = "colRemark"
        GridViewTextBoxColumn3.Width = 140
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.FieldName = "LotFailBagNo"
        GridViewTextBoxColumn4.HeaderText = "LotFail Bag No"
        GridViewTextBoxColumn4.Name = "colLotFailBagNo"
        GridViewTextBoxColumn4.SortOrder = Telerik.WinControls.UI.RadSortOrder.Ascending
        GridViewTextBoxColumn4.Width = 93
        GridViewTextBoxColumn5.EnableExpressionEditor = False
        GridViewTextBoxColumn5.FieldName = "OperationName"
        GridViewTextBoxColumn5.HeaderText = "Operation Name"
        GridViewTextBoxColumn5.Name = "colOperationName"
        GridViewTextBoxColumn5.Width = 120
        GridViewTextBoxColumn6.EnableExpressionEditor = False
        GridViewTextBoxColumn6.FieldName = "LabourName"
        GridViewTextBoxColumn6.HeaderText = "Labour Name"
        GridViewTextBoxColumn6.Name = "colLabourName"
        GridViewTextBoxColumn6.Width = 130
        Me.dgvLotFailList.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewDecimalColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5, GridViewTextBoxColumn6})
        Me.dgvLotFailList.MasterTemplate.ShowRowHeaderColumn = False
        SortDescriptor1.PropertyName = "colLotFailBagNo"
        Me.dgvLotFailList.MasterTemplate.SortDescriptors.AddRange(New Telerik.WinControls.Data.SortDescriptor() {SortDescriptor1})
        Me.dgvLotFailList.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgvLotFailList.Name = "dgvLotFailList"
        Me.dgvLotFailList.ReadOnly = True
        Me.dgvLotFailList.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvLotFailList.Size = New System.Drawing.Size(736, 392)
        Me.dgvLotFailList.TabIndex = 0
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnPrint.Location = New System.Drawing.Point(301, 400)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 25)
        Me.btnPrint.TabIndex = 1
        Me.btnPrint.Text = "&Print"
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnExit.Location = New System.Drawing.Point(378, 400)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 25)
        Me.btnExit.TabIndex = 26
        Me.btnExit.Text = "E&xit"
        '
        'frmRptLotFail
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(744, 430)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.dgvLotFailList)
        Me.Font = New System.Drawing.Font("Tahoma", 14.25!)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmRptLotFail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LotFail Report"
        CType(Me.dgvLotFailList.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvLotFailList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvLotFailList As Telerik.WinControls.UI.RadGridView
    Friend WithEvents btnPrint As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnExit As Telerik.WinControls.UI.RadButton
End Class
