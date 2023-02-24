<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAcctOpLabIssue
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
        Dim GridViewTextBoxColumn9 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn10 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn11 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn12 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn13 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn14 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn15 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn16 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
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
        Me.dgvWipLotNo.Location = New System.Drawing.Point(2, 3)
        '
        '
        '
        Me.dgvWipLotNo.MasterTemplate.AllowAddNewRow = False
        Me.dgvWipLotNo.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn9.EnableExpressionEditor = False
        GridViewTextBoxColumn9.FieldName = "LabIssueDt"
        GridViewTextBoxColumn9.HeaderText = "Trans. Dt"
        GridViewTextBoxColumn9.Name = "colTransDt"
        GridViewTextBoxColumn9.Width = 70
        GridViewTextBoxColumn10.EnableExpressionEditor = False
        GridViewTextBoxColumn10.FieldName = "LabName"
        GridViewTextBoxColumn10.HeaderText = "Lab Name"
        GridViewTextBoxColumn10.Name = "colLabName"
        GridViewTextBoxColumn10.Width = 105
        GridViewTextBoxColumn11.EnableExpressionEditor = False
        GridViewTextBoxColumn11.FieldName = "LotNumber"
        GridViewTextBoxColumn11.HeaderText = "Lot Number"
        GridViewTextBoxColumn11.Name = "colLotNumber"
        GridViewTextBoxColumn11.Width = 80
        GridViewTextBoxColumn12.EnableExpressionEditor = False
        GridViewTextBoxColumn12.FieldName = "OperationName"
        GridViewTextBoxColumn12.HeaderText = "Operation"
        GridViewTextBoxColumn12.Name = "colOperationName"
        GridViewTextBoxColumn12.Width = 80
        GridViewTextBoxColumn13.EnableExpressionEditor = False
        GridViewTextBoxColumn13.FieldName = "TransType"
        GridViewTextBoxColumn13.HeaderText = "Type"
        GridViewTextBoxColumn13.Name = "colTransType"
        GridViewTextBoxColumn13.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn13.Width = 90
        GridViewTextBoxColumn14.EnableExpressionEditor = False
        GridViewTextBoxColumn14.FieldName = "ReceiveWt"
        GridViewTextBoxColumn14.HeaderText = "Receive Wt."
        GridViewTextBoxColumn14.Name = "colReceiveWt"
        GridViewTextBoxColumn14.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn14.Width = 80
        GridViewTextBoxColumn15.EnableExpressionEditor = False
        GridViewTextBoxColumn15.FieldName = "ReceivePr"
        GridViewTextBoxColumn15.HeaderText = "Receive %"
        GridViewTextBoxColumn15.Name = "colReceivePr"
        GridViewTextBoxColumn15.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn15.Width = 80
        GridViewTextBoxColumn16.EnableExpressionEditor = False
        GridViewTextBoxColumn16.FieldName = "FineWt"
        GridViewTextBoxColumn16.HeaderText = "Fine Wt"
        GridViewTextBoxColumn16.Name = "colFineWt"
        GridViewTextBoxColumn16.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn16.Width = 80
        Me.dgvWipLotNo.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn9, GridViewTextBoxColumn10, GridViewTextBoxColumn11, GridViewTextBoxColumn12, GridViewTextBoxColumn13, GridViewTextBoxColumn14, GridViewTextBoxColumn15, GridViewTextBoxColumn16})
        Me.dgvWipLotNo.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvWipLotNo.MasterTemplate.ViewDefinition = TableViewDefinition2
        Me.dgvWipLotNo.Name = "dgvWipLotNo"
        Me.dgvWipLotNo.ReadOnly = True
        Me.dgvWipLotNo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvWipLotNo.Size = New System.Drawing.Size(663, 387)
        Me.dgvWipLotNo.TabIndex = 8
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(380, 397)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(44, 13)
        Me.lblTotal.TabIndex = 25
        Me.lblTotal.Text = "Total :"
        '
        'frmAcctOpLabIssue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(669, 416)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.dgvWipLotNo)
        Me.KeyPreview = True
        Me.Name = "frmAcctOpLabIssue"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Op. Account Lab Issue"
        CType(Me.dgvWipLotNo.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvWipLotNo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvWipLotNo As Telerik.WinControls.UI.RadGridView
    Friend WithEvents lblTotal As Label
End Class
