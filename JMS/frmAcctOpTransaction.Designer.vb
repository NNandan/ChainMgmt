<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAcctOpTransaction
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
        Dim GridViewTextBoxColumn13 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn14 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn15 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn16 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn17 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn18 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn19 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn20 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn21 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn22 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn23 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn24 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition2 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.dgvWipLotNo = New Telerik.WinControls.UI.RadGridView()
        Me.lblTotal = New System.Windows.Forms.Label()
        CType(Me.dgvWipLotNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvWipLotNo.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvWipLotNo
        '
        Me.dgvWipLotNo.BackColor = System.Drawing.SystemColors.Control
        Me.dgvWipLotNo.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvWipLotNo.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.dgvWipLotNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvWipLotNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvWipLotNo.Location = New System.Drawing.Point(2, 1)
        '
        '
        '
        Me.dgvWipLotNo.MasterTemplate.AllowAddNewRow = False
        Me.dgvWipLotNo.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn13.EnableExpressionEditor = False
        GridViewTextBoxColumn13.FieldName = "TransactionDt"
        GridViewTextBoxColumn13.HeaderText = "Trans. Dt"
        GridViewTextBoxColumn13.Name = "colTransDt"
        GridViewTextBoxColumn13.Width = 70
        GridViewTextBoxColumn14.EnableExpressionEditor = False
        GridViewTextBoxColumn14.FieldName = "LotNumber"
        GridViewTextBoxColumn14.HeaderText = "Lot Number"
        GridViewTextBoxColumn14.Name = "colLotNumber"
        GridViewTextBoxColumn14.Width = 105
        GridViewTextBoxColumn15.EnableExpressionEditor = False
        GridViewTextBoxColumn15.FieldName = "ItemName"
        GridViewTextBoxColumn15.HeaderText = "Item Name"
        GridViewTextBoxColumn15.Name = "colItemName"
        GridViewTextBoxColumn15.Width = 140
        GridViewTextBoxColumn16.EnableExpressionEditor = False
        GridViewTextBoxColumn16.FieldName = "OperationName"
        GridViewTextBoxColumn16.HeaderText = "Operation Name"
        GridViewTextBoxColumn16.Name = "colOperationName"
        GridViewTextBoxColumn16.Width = 140
        GridViewTextBoxColumn17.EnableExpressionEditor = False
        GridViewTextBoxColumn17.FieldName = "IssueWt"
        GridViewTextBoxColumn17.HeaderText = "Issue Wt."
        GridViewTextBoxColumn17.Name = "colIssueWt"
        GridViewTextBoxColumn17.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn17.Width = 90
        GridViewTextBoxColumn18.EnableExpressionEditor = False
        GridViewTextBoxColumn18.FieldName = "IssuePr"
        GridViewTextBoxColumn18.HeaderText = "Issue %"
        GridViewTextBoxColumn18.Name = "colIssuePr"
        GridViewTextBoxColumn18.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn18.Width = 80
        GridViewTextBoxColumn19.EnableExpressionEditor = False
        GridViewTextBoxColumn19.FieldName = "ReceiveWt"
        GridViewTextBoxColumn19.HeaderText = "Receive Wt."
        GridViewTextBoxColumn19.Name = "colReceiveWt"
        GridViewTextBoxColumn19.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn19.Width = 80
        GridViewTextBoxColumn20.EnableExpressionEditor = False
        GridViewTextBoxColumn20.FieldName = "ReceivePr"
        GridViewTextBoxColumn20.HeaderText = "Receive %"
        GridViewTextBoxColumn20.Name = "colReceivePr"
        GridViewTextBoxColumn20.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn20.Width = 80
        GridViewTextBoxColumn21.EnableExpressionEditor = False
        GridViewTextBoxColumn21.FieldName = "BhukaWt"
        GridViewTextBoxColumn21.HeaderText = "Bhuka Wt."
        GridViewTextBoxColumn21.Name = "colBhukaWt"
        GridViewTextBoxColumn21.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn21.Width = 80
        GridViewTextBoxColumn22.EnableExpressionEditor = False
        GridViewTextBoxColumn22.FieldName = "SampleWt"
        GridViewTextBoxColumn22.HeaderText = "Sample Wt."
        GridViewTextBoxColumn22.Name = "colSampleWt"
        GridViewTextBoxColumn22.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn22.Width = 80
        GridViewTextBoxColumn23.EnableExpressionEditor = False
        GridViewTextBoxColumn23.FieldName = "VacuumWt"
        GridViewTextBoxColumn23.HeaderText = "Vacuum Wt."
        GridViewTextBoxColumn23.Name = "colVacuumWt"
        GridViewTextBoxColumn23.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn23.Width = 80
        GridViewTextBoxColumn24.EnableExpressionEditor = False
        GridViewTextBoxColumn24.FieldName = "FineWt"
        GridViewTextBoxColumn24.HeaderText = "Fine Wt."
        GridViewTextBoxColumn24.Name = "colFineWt"
        GridViewTextBoxColumn24.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn24.Width = 80
        Me.dgvWipLotNo.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn13, GridViewTextBoxColumn14, GridViewTextBoxColumn15, GridViewTextBoxColumn16, GridViewTextBoxColumn17, GridViewTextBoxColumn18, GridViewTextBoxColumn19, GridViewTextBoxColumn20, GridViewTextBoxColumn21, GridViewTextBoxColumn22, GridViewTextBoxColumn23, GridViewTextBoxColumn24})
        Me.dgvWipLotNo.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvWipLotNo.MasterTemplate.ViewDefinition = TableViewDefinition2
        Me.dgvWipLotNo.Name = "dgvWipLotNo"
        Me.dgvWipLotNo.ReadOnly = True
        Me.dgvWipLotNo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvWipLotNo.Size = New System.Drawing.Size(1097, 387)
        Me.dgvWipLotNo.TabIndex = 8
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(587, 396)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(44, 13)
        Me.lblTotal.TabIndex = 25
        Me.lblTotal.Text = "Total :"
        '
        'frmAcctOpTransaction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1101, 417)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.dgvWipLotNo)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmAcctOpTransaction"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Op. Account Transaction"
        CType(Me.dgvWipLotNo.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvWipLotNo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvWipLotNo As Telerik.WinControls.UI.RadGridView
    Friend WithEvents lblTotal As Label
End Class
