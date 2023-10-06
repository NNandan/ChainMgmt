<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFaPendingVoucherRpt
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
        Dim GridViewTextBoxColumn4 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn5 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn6 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn7 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn8 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn9 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn10 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn11 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.rdgvPendingRpt = New Telerik.WinControls.UI.RadGridView()
        Me.btnPrint = New Telerik.WinControls.UI.RadButton()
        Me.btnExit = New Telerik.WinControls.UI.RadButton()
        CType(Me.rdgvPendingRpt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rdgvPendingRpt.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rdgvPendingRpt
        '
        Me.rdgvPendingRpt.BackColor = System.Drawing.SystemColors.Control
        Me.rdgvPendingRpt.Cursor = System.Windows.Forms.Cursors.Default
        Me.rdgvPendingRpt.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.rdgvPendingRpt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rdgvPendingRpt.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.rdgvPendingRpt.Location = New System.Drawing.Point(3, 1)
        '
        '
        '
        Me.rdgvPendingRpt.MasterTemplate.AllowAddNewRow = False
        Me.rdgvPendingRpt.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "ReceiptId"
        GridViewTextBoxColumn1.HeaderText = "ReceiptId"
        GridViewTextBoxColumn1.IsVisible = False
        GridViewTextBoxColumn1.Name = "colReceiptId"
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "ReceiptDetailsId"
        GridViewTextBoxColumn2.HeaderText = "ReceiptDetails Id"
        GridViewTextBoxColumn2.IsVisible = False
        GridViewTextBoxColumn2.Name = "colReceiptDetailsId"
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.FieldName = "ReceiptDt"
        GridViewTextBoxColumn3.HeaderText = "Receipt Dt"
        GridViewTextBoxColumn3.Name = "colReceiptDt"
        GridViewTextBoxColumn3.Width = 89
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.FieldName = "VoucherNo"
        GridViewTextBoxColumn4.HeaderText = "Voucher No"
        GridViewTextBoxColumn4.Name = "colVoucherNo"
        GridViewTextBoxColumn4.Width = 100
        GridViewTextBoxColumn5.EnableExpressionEditor = False
        GridViewTextBoxColumn5.FieldName = "ItemName"
        GridViewTextBoxColumn5.HeaderText = "Item Name"
        GridViewTextBoxColumn5.Name = "colItemName"
        GridViewTextBoxColumn5.Width = 110
        GridViewTextBoxColumn6.EnableExpressionEditor = False
        GridViewTextBoxColumn6.FieldName = "ReceiveWt"
        GridViewTextBoxColumn6.HeaderText = "Receive Wt"
        GridViewTextBoxColumn6.Name = "colReceiveWt"
        GridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn6.Width = 90
        GridViewTextBoxColumn7.EnableExpressionEditor = False
        GridViewTextBoxColumn7.FieldName = "ReceivePr"
        GridViewTextBoxColumn7.HeaderText = "%"
        GridViewTextBoxColumn7.Name = "colReceivePr"
        GridViewTextBoxColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn7.Width = 90
        GridViewTextBoxColumn8.EnableExpressionEditor = False
        GridViewTextBoxColumn8.FieldName = "FineWt"
        GridViewTextBoxColumn8.HeaderText = "Fine Wt."
        GridViewTextBoxColumn8.Name = "colFineWt"
        GridViewTextBoxColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn8.Width = 90
        GridViewTextBoxColumn9.EnableExpressionEditor = False
        GridViewTextBoxColumn9.FieldName = "UsedWt"
        GridViewTextBoxColumn9.HeaderText = "Used Wt"
        GridViewTextBoxColumn9.Name = "colUsedWt"
        GridViewTextBoxColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn9.Width = 90
        GridViewTextBoxColumn10.EnableExpressionEditor = False
        GridViewTextBoxColumn10.FieldName = "BalanceWt"
        GridViewTextBoxColumn10.HeaderText = "Balance Wt."
        GridViewTextBoxColumn10.Name = "colBalanceWt"
        GridViewTextBoxColumn10.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn10.Width = 90
        GridViewTextBoxColumn11.EnableExpressionEditor = False
        GridViewTextBoxColumn11.FieldName = "BalanceFineWt"
        GridViewTextBoxColumn11.HeaderText = "Balance Fine Wt"
        GridViewTextBoxColumn11.Name = "colBalanceFineWt"
        GridViewTextBoxColumn11.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn11.Width = 100
        Me.rdgvPendingRpt.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5, GridViewTextBoxColumn6, GridViewTextBoxColumn7, GridViewTextBoxColumn8, GridViewTextBoxColumn9, GridViewTextBoxColumn10, GridViewTextBoxColumn11})
        Me.rdgvPendingRpt.MasterTemplate.ShowRowHeaderColumn = False
        Me.rdgvPendingRpt.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.rdgvPendingRpt.Name = "rdgvPendingRpt"
        Me.rdgvPendingRpt.ReadOnly = True
        Me.rdgvPendingRpt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.rdgvPendingRpt.Size = New System.Drawing.Size(854, 466)
        Me.rdgvPendingRpt.TabIndex = 0
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnPrint.Location = New System.Drawing.Point(365, 473)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 25)
        Me.btnPrint.TabIndex = 7
        Me.btnPrint.Text = "&Print"
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnExit.Location = New System.Drawing.Point(442, 473)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 25)
        Me.btnExit.TabIndex = 8
        Me.btnExit.Text = "E&xit"
        '
        'frmPendingVoucherRpt
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(859, 503)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.rdgvPendingRpt)
        Me.MaximizeBox = False
        Me.Name = "frmPendingVoucherRpt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Balance Pending in Voucher"
        CType(Me.rdgvPendingRpt.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rdgvPendingRpt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents rdgvPendingRpt As Telerik.WinControls.UI.RadGridView
    Friend WithEvents btnPrint As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnExit As Telerik.WinControls.UI.RadButton
End Class
