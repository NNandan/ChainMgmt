<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStockLotAddition
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
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
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
        Me.dgvWipLotNo.Location = New System.Drawing.Point(5, 2)
        Me.dgvWipLotNo.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        '
        '
        '
        Me.dgvWipLotNo.MasterTemplate.AllowAddNewRow = False
        Me.dgvWipLotNo.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "TransactionDt"
        GridViewTextBoxColumn1.HeaderText = "Trans. Dt"
        GridViewTextBoxColumn1.Name = "colTransDt"
        GridViewTextBoxColumn1.Width = 117
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "LotNo"
        GridViewTextBoxColumn2.HeaderText = "Lot No"
        GridViewTextBoxColumn2.Name = "colLotNumber"
        GridViewTextBoxColumn2.Width = 167
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.FieldName = "OperationName"
        GridViewTextBoxColumn3.HeaderText = "Operation Name"
        GridViewTextBoxColumn3.Name = "colOperationName"
        GridViewTextBoxColumn3.Width = 242
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.FieldName = "ItemName"
        GridViewTextBoxColumn4.HeaderText = "Item Name"
        GridViewTextBoxColumn4.Name = "colItemName"
        GridViewTextBoxColumn4.Width = 183
        GridViewTextBoxColumn5.EnableExpressionEditor = False
        GridViewTextBoxColumn5.FieldName = "ReceiveWt"
        GridViewTextBoxColumn5.HeaderText = "Receive Wt."
        GridViewTextBoxColumn5.Name = "colReceiveWt"
        GridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn5.Width = 133
        GridViewTextBoxColumn6.EnableExpressionEditor = False
        GridViewTextBoxColumn6.FieldName = "ReceivePr"
        GridViewTextBoxColumn6.HeaderText = "Receive %"
        GridViewTextBoxColumn6.Name = "colReceivePr"
        GridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn6.Width = 133
        GridViewTextBoxColumn7.EnableExpressionEditor = False
        GridViewTextBoxColumn7.FieldName = "FineWt"
        GridViewTextBoxColumn7.HeaderText = "Fine Wt."
        GridViewTextBoxColumn7.Name = "colFineWt"
        GridViewTextBoxColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn7.Width = 133
        Me.dgvWipLotNo.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5, GridViewTextBoxColumn6, GridViewTextBoxColumn7})
        Me.dgvWipLotNo.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvWipLotNo.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgvWipLotNo.Name = "dgvWipLotNo"
        Me.dgvWipLotNo.ReadOnly = True
        Me.dgvWipLotNo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvWipLotNo.Size = New System.Drawing.Size(1105, 686)
        Me.dgvWipLotNo.TabIndex = 9
        '
        'lblCBhukaTotal
        '
        Me.lblCBhukaTotal.AutoSize = True
        Me.lblCBhukaTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCBhukaTotal.Location = New System.Drawing.Point(583, 697)
        Me.lblCBhukaTotal.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblCBhukaTotal.Name = "lblCBhukaTotal"
        Me.lblCBhukaTotal.Size = New System.Drawing.Size(44, 16)
        Me.lblCBhukaTotal.TabIndex = 43
        Me.lblCBhukaTotal.Text = "Total"
        '
        'lblReceiveFw
        '
        Me.lblReceiveFw.AutoSize = True
        Me.lblReceiveFw.Location = New System.Drawing.Point(1035, 697)
        Me.lblReceiveFw.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblReceiveFw.Name = "lblReceiveFw"
        Me.lblReceiveFw.Size = New System.Drawing.Size(20, 23)
        Me.lblReceiveFw.TabIndex = 42
        Me.lblReceiveFw.Text = "0"
        '
        'lblReceivePr
        '
        Me.lblReceivePr.AutoSize = True
        Me.lblReceivePr.Location = New System.Drawing.Point(895, 697)
        Me.lblReceivePr.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblReceivePr.Name = "lblReceivePr"
        Me.lblReceivePr.Size = New System.Drawing.Size(20, 23)
        Me.lblReceivePr.TabIndex = 41
        Me.lblReceivePr.Text = "0"
        Me.lblReceivePr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblReceiveWt
        '
        Me.lblReceiveWt.AutoSize = True
        Me.lblReceiveWt.Location = New System.Drawing.Point(755, 697)
        Me.lblReceiveWt.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblReceiveWt.Name = "lblReceiveWt"
        Me.lblReceiveWt.Size = New System.Drawing.Size(20, 23)
        Me.lblReceiveWt.TabIndex = 40
        Me.lblReceiveWt.Text = "0"
        '
        'frmStockLotAddition
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1115, 738)
        Me.Controls.Add(Me.lblCBhukaTotal)
        Me.Controls.Add(Me.lblReceiveFw)
        Me.Controls.Add(Me.lblReceivePr)
        Me.Controls.Add(Me.lblReceiveWt)
        Me.Controls.Add(Me.dgvWipLotNo)
        Me.Font = New System.Drawing.Font("Tahoma", 14.25!)
        Me.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.MaximizeBox = False
        Me.Name = "frmStockLotAddition"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Lot Addition Stock"
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
