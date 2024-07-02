<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStockDeptReceive
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
        Dim GridViewTextBoxColumn7 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn8 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn9 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn10 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn11 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn12 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition2 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.dgvWipLotNo = New Telerik.WinControls.UI.RadGridView()
        Me.lblCBhukaTotal = New System.Windows.Forms.Label()
        Me.lblReceiveFw = New System.Windows.Forms.Label()
        Me.lblReceivePr = New System.Windows.Forms.Label()
        Me.lblReceiveWt = New System.Windows.Forms.Label()
        CType(Me.dgvWipLotNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvWipLotNo.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvWipLotNo
        '
        Me.dgvWipLotNo.BackColor = System.Drawing.SystemColors.Control
        Me.dgvWipLotNo.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvWipLotNo.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvWipLotNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvWipLotNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvWipLotNo.Location = New System.Drawing.Point(2, 2)
        '
        '
        '
        Me.dgvWipLotNo.MasterTemplate.AllowAddNewRow = False
        Me.dgvWipLotNo.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn7.EnableExpressionEditor = False
        GridViewTextBoxColumn7.FieldName = "TransactionDt"
        GridViewTextBoxColumn7.HeaderText = "Trans. Dt"
        GridViewTextBoxColumn7.Name = "colTransDt"
        GridViewTextBoxColumn7.Width = 82
        GridViewTextBoxColumn8.EnableExpressionEditor = False
        GridViewTextBoxColumn8.FieldName = "VoucherNo"
        GridViewTextBoxColumn8.HeaderText = "Voucher No"
        GridViewTextBoxColumn8.Name = "colVoucherNo"
        GridViewTextBoxColumn8.Width = 122
        GridViewTextBoxColumn9.EnableExpressionEditor = False
        GridViewTextBoxColumn9.FieldName = "ItemName"
        GridViewTextBoxColumn9.HeaderText = "Item Name"
        GridViewTextBoxColumn9.Name = "colItemName"
        GridViewTextBoxColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn9.Width = 280
        GridViewTextBoxColumn10.EnableExpressionEditor = False
        GridViewTextBoxColumn10.FieldName = "ReceiveWt"
        GridViewTextBoxColumn10.HeaderText = "Receive Wt."
        GridViewTextBoxColumn10.Name = "colReceiveWt"
        GridViewTextBoxColumn10.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn10.Width = 93
        GridViewTextBoxColumn11.EnableExpressionEditor = False
        GridViewTextBoxColumn11.FieldName = "ReceivePr"
        GridViewTextBoxColumn11.HeaderText = "Receive %"
        GridViewTextBoxColumn11.Name = "colReceivePr"
        GridViewTextBoxColumn11.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn11.Width = 105
        GridViewTextBoxColumn12.EnableExpressionEditor = False
        GridViewTextBoxColumn12.FieldName = "FineWt"
        GridViewTextBoxColumn12.HeaderText = "Fine Wt."
        GridViewTextBoxColumn12.Name = "colFineWt"
        GridViewTextBoxColumn12.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn12.Width = 93
        Me.dgvWipLotNo.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn7, GridViewTextBoxColumn8, GridViewTextBoxColumn9, GridViewTextBoxColumn10, GridViewTextBoxColumn11, GridViewTextBoxColumn12})
        Me.dgvWipLotNo.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvWipLotNo.MasterTemplate.ViewDefinition = TableViewDefinition2
        Me.dgvWipLotNo.Name = "dgvWipLotNo"
        Me.dgvWipLotNo.ReadOnly = True
        Me.dgvWipLotNo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvWipLotNo.Size = New System.Drawing.Size(775, 416)
        Me.dgvWipLotNo.TabIndex = 8
        '
        'lblCBhukaTotal
        '
        Me.lblCBhukaTotal.AutoSize = True
        Me.lblCBhukaTotal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCBhukaTotal.Location = New System.Drawing.Point(454, 426)
        Me.lblCBhukaTotal.Name = "lblCBhukaTotal"
        Me.lblCBhukaTotal.Size = New System.Drawing.Size(38, 14)
        Me.lblCBhukaTotal.TabIndex = 47
        Me.lblCBhukaTotal.Text = "Total"
        '
        'lblReceiveFw
        '
        Me.lblReceiveFw.AutoSize = True
        Me.lblReceiveFw.Location = New System.Drawing.Point(735, 426)
        Me.lblReceiveFw.Name = "lblReceiveFw"
        Me.lblReceiveFw.Size = New System.Drawing.Size(14, 14)
        Me.lblReceiveFw.TabIndex = 46
        Me.lblReceiveFw.Text = "0"
        '
        'lblReceivePr
        '
        Me.lblReceivePr.AutoSize = True
        Me.lblReceivePr.Location = New System.Drawing.Point(635, 426)
        Me.lblReceivePr.Name = "lblReceivePr"
        Me.lblReceivePr.Size = New System.Drawing.Size(14, 14)
        Me.lblReceivePr.TabIndex = 45
        Me.lblReceivePr.Text = "0"
        Me.lblReceivePr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblReceiveWt
        '
        Me.lblReceiveWt.AutoSize = True
        Me.lblReceiveWt.Location = New System.Drawing.Point(534, 426)
        Me.lblReceiveWt.Name = "lblReceiveWt"
        Me.lblReceiveWt.Size = New System.Drawing.Size(14, 14)
        Me.lblReceiveWt.TabIndex = 44
        Me.lblReceiveWt.Text = "0"
        '
        'frmStockDeptReceive
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(780, 449)
        Me.Controls.Add(Me.lblCBhukaTotal)
        Me.Controls.Add(Me.lblReceiveFw)
        Me.Controls.Add(Me.lblReceivePr)
        Me.Controls.Add(Me.lblReceiveWt)
        Me.Controls.Add(Me.dgvWipLotNo)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.MaximizeBox = False
        Me.Name = "frmStockDeptReceive"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Dept Receive"
        CType(Me.dgvWipLotNo.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvWipLotNo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvWipLotNo As Telerik.WinControls.UI.RadGridView
    Friend WithEvents lblCBhukaTotal As Label
    Friend WithEvents lblReceiveFw As Label
    Friend WithEvents lblReceivePr As Label
    Friend WithEvents lblReceiveWt As Label
End Class
