<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptReceiveDept
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
        Dim SortDescriptor1 As Telerik.WinControls.Data.SortDescriptor = New Telerik.WinControls.Data.SortDescriptor()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.dgvDeptReceive = New Telerik.WinControls.UI.RadGridView()
        Me.btnShow = New Telerik.WinControls.UI.RadButton()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblReceiveWt = New System.Windows.Forms.Label()
        Me.lblReceivePr = New System.Windows.Forms.Label()
        Me.lblFineWt = New System.Windows.Forms.Label()
        CType(Me.dgvDeptReceive, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDeptReceive.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnShow, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvDeptReceive
        '
        Me.dgvDeptReceive.BackColor = System.Drawing.SystemColors.Control
        Me.dgvDeptReceive.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvDeptReceive.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvDeptReceive.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvDeptReceive.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvDeptReceive.Location = New System.Drawing.Point(6, 4)
        '
        '
        '
        Me.dgvDeptReceive.MasterTemplate.AllowAddNewRow = False
        Me.dgvDeptReceive.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "ReceiptId"
        GridViewTextBoxColumn1.HeaderText = "Receipt Id"
        GridViewTextBoxColumn1.IsVisible = False
        GridViewTextBoxColumn1.Name = "colReceiptId"
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "ReceiptDt"
        GridViewTextBoxColumn2.HeaderText = "Receipt Dt"
        GridViewTextBoxColumn2.Name = "colReceiptDt"
        GridViewTextBoxColumn2.SortOrder = Telerik.WinControls.UI.RadSortOrder.Ascending
        GridViewTextBoxColumn2.Width = 85
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.FieldName = "VoucherNo"
        GridViewTextBoxColumn3.HeaderText = "Voucher No"
        GridViewTextBoxColumn3.Name = "colVoucherNo"
        GridViewTextBoxColumn3.Width = 100
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.FieldName = "ItemName"
        GridViewTextBoxColumn4.HeaderText = "Item Name"
        GridViewTextBoxColumn4.Name = "colItemName"
        GridViewTextBoxColumn4.Width = 295
        GridViewTextBoxColumn5.AllowFiltering = False
        GridViewTextBoxColumn5.AllowGroup = False
        GridViewTextBoxColumn5.EnableExpressionEditor = False
        GridViewTextBoxColumn5.FieldName = "BalanceWt"
        GridViewTextBoxColumn5.FormatString = "{0:F2}"
        GridViewTextBoxColumn5.HeaderText = "Receive Wt."
        GridViewTextBoxColumn5.Name = "colReceiveWt"
        GridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn5.Width = 85
        GridViewTextBoxColumn6.AllowFiltering = False
        GridViewTextBoxColumn6.AllowGroup = False
        GridViewTextBoxColumn6.EnableExpressionEditor = False
        GridViewTextBoxColumn6.FieldName = "ReceivePr"
        GridViewTextBoxColumn6.FormatString = "{0:F2}"
        GridViewTextBoxColumn6.HeaderText = "Receive %"
        GridViewTextBoxColumn6.Name = "colReceivePr"
        GridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn6.Width = 85
        GridViewTextBoxColumn7.AllowFiltering = False
        GridViewTextBoxColumn7.AllowGroup = False
        GridViewTextBoxColumn7.EnableExpressionEditor = False
        GridViewTextBoxColumn7.FieldName = "FineWt"
        GridViewTextBoxColumn7.FormatString = "{0:F2}"
        GridViewTextBoxColumn7.HeaderText = "Fine Wt."
        GridViewTextBoxColumn7.Name = "colFineWt"
        GridViewTextBoxColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn7.Width = 85
        Me.dgvDeptReceive.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5, GridViewTextBoxColumn6, GridViewTextBoxColumn7})
        Me.dgvDeptReceive.MasterTemplate.ShowRowHeaderColumn = False
        SortDescriptor1.PropertyName = "colReceiptDt"
        Me.dgvDeptReceive.MasterTemplate.SortDescriptors.AddRange(New Telerik.WinControls.Data.SortDescriptor() {SortDescriptor1})
        Me.dgvDeptReceive.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgvDeptReceive.Name = "dgvDeptReceive"
        Me.dgvDeptReceive.ReadOnly = True
        Me.dgvDeptReceive.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvDeptReceive.Size = New System.Drawing.Size(735, 472)
        Me.dgvDeptReceive.TabIndex = 0
        '
        'btnShow
        '
        Me.btnShow.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnShow.Location = New System.Drawing.Point(335, 481)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(75, 25)
        Me.btnShow.TabIndex = 3
        Me.btnShow.Text = "&Print"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblTotal.Location = New System.Drawing.Point(422, 486)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(43, 14)
        Me.lblTotal.TabIndex = 10
        Me.lblTotal.Text = "Total :"
        '
        'lblReceiveWt
        '
        Me.lblReceiveWt.AutoSize = True
        Me.lblReceiveWt.Location = New System.Drawing.Point(521, 481)
        Me.lblReceiveWt.Name = "lblReceiveWt"
        Me.lblReceiveWt.Size = New System.Drawing.Size(0, 13)
        Me.lblReceiveWt.TabIndex = 11
        '
        'lblReceivePr
        '
        Me.lblReceivePr.AutoSize = True
        Me.lblReceivePr.Location = New System.Drawing.Point(612, 481)
        Me.lblReceivePr.Name = "lblReceivePr"
        Me.lblReceivePr.Size = New System.Drawing.Size(0, 13)
        Me.lblReceivePr.TabIndex = 12
        '
        'lblFineWt
        '
        Me.lblFineWt.AutoSize = True
        Me.lblFineWt.Location = New System.Drawing.Point(703, 481)
        Me.lblFineWt.Name = "lblFineWt"
        Me.lblFineWt.Size = New System.Drawing.Size(0, 13)
        Me.lblFineWt.TabIndex = 13
        '
        'frmRptReceiveDept
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(747, 509)
        Me.Controls.Add(Me.lblFineWt)
        Me.Controls.Add(Me.lblReceivePr)
        Me.Controls.Add(Me.lblReceiveWt)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.btnShow)
        Me.Controls.Add(Me.dgvDeptReceive)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmRptReceiveDept"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Deptwise Receive Report"
        CType(Me.dgvDeptReceive.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDeptReceive, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnShow, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvDeptReceive As Telerik.WinControls.UI.RadGridView
    Friend WithEvents btnShow As Telerik.WinControls.UI.RadButton
    Friend WithEvents lblTotal As Label
    Friend WithEvents lblReceiveWt As Label
    Friend WithEvents lblReceivePr As Label
    Friend WithEvents lblFineWt As Label
End Class
