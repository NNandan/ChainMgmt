<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRptLotTransfer
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
        Dim GridViewTextBoxColumn4 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn5 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn6 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn7 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn8 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn9 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.dgvLotTransfer = New Telerik.WinControls.UI.RadGridView()
        Me.btnPrint = New Telerik.WinControls.UI.RadButton()
        Me.lblIssuePr = New System.Windows.Forms.Label()
        Me.lblTransferWt = New System.Windows.Forms.Label()
        Me.btnExit = New Telerik.WinControls.UI.RadButton()
        CType(Me.dgvLotTransfer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvLotTransfer.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvLotTransfer
        '
        Me.dgvLotTransfer.BackColor = System.Drawing.SystemColors.Control
        Me.dgvLotTransfer.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvLotTransfer.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvLotTransfer.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvLotTransfer.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvLotTransfer.Location = New System.Drawing.Point(3, 3)
        '
        '
        '
        Me.dgvLotTransfer.MasterTemplate.AllowAddNewRow = False
        Me.dgvLotTransfer.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "LotTransferDt"
        GridViewTextBoxColumn1.HeaderText = "LotTransfer Dt"
        GridViewTextBoxColumn1.Name = "colLotTransferDt"
        GridViewTextBoxColumn1.Width = 90
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "FrLotNo"
        GridViewTextBoxColumn2.HeaderText = "Fr Lot No"
        GridViewTextBoxColumn2.Name = "colFrLotNumber"
        GridViewTextBoxColumn2.Width = 85
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.FieldName = "ToLotNo"
        GridViewTextBoxColumn3.HeaderText = "To Lot No"
        GridViewTextBoxColumn3.Name = "colToLotNumber"
        GridViewTextBoxColumn3.Width = 85
        GridViewDecimalColumn1.AllowFiltering = False
        GridViewDecimalColumn1.AllowGroup = False
        GridViewDecimalColumn1.EnableExpressionEditor = False
        GridViewDecimalColumn1.FieldName = "OperationName"
        GridViewDecimalColumn1.FormatString = "{0:F2}"
        GridViewDecimalColumn1.HeaderText = "Operation"
        GridViewDecimalColumn1.Name = "colOperationName"
        GridViewDecimalColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        GridViewDecimalColumn1.Width = 115
        GridViewTextBoxColumn4.AllowFiltering = False
        GridViewTextBoxColumn4.AllowGroup = False
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.FieldName = "TotalWt"
        GridViewTextBoxColumn4.HeaderText = "Total Wt"
        GridViewTextBoxColumn4.Name = "colTotalWt"
        GridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn4.Width = 80
        GridViewTextBoxColumn5.EnableExpressionEditor = False
        GridViewTextBoxColumn5.FieldName = "TransferWt"
        GridViewTextBoxColumn5.HeaderText = "Transfer Wt."
        GridViewTextBoxColumn5.Name = "colTransferWt"
        GridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn5.Width = 90
        GridViewTextBoxColumn6.EnableExpressionEditor = False
        GridViewTextBoxColumn6.FieldName = "BalanceWt"
        GridViewTextBoxColumn6.HeaderText = "Balance Wt."
        GridViewTextBoxColumn6.Name = "colBalanceWt"
        GridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn6.Width = 90
        GridViewTextBoxColumn7.EnableExpressionEditor = False
        GridViewTextBoxColumn7.FieldName = "IssuePr"
        GridViewTextBoxColumn7.HeaderText = "Issue %"
        GridViewTextBoxColumn7.Name = "colIssuePr"
        GridViewTextBoxColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn7.Width = 80
        GridViewTextBoxColumn8.EnableExpressionEditor = False
        GridViewTextBoxColumn8.FieldName = "FineWt"
        GridViewTextBoxColumn8.HeaderText = "Fine Wt."
        GridViewTextBoxColumn8.Name = "colFineWt"
        GridViewTextBoxColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn8.Width = 80
        GridViewTextBoxColumn9.EnableExpressionEditor = False
        GridViewTextBoxColumn9.FieldName = "MainLotNo"
        GridViewTextBoxColumn9.HeaderText = "Main Lot No"
        GridViewTextBoxColumn9.Name = "colMainLotNumber"
        GridViewTextBoxColumn9.Width = 90
        Me.dgvLotTransfer.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewDecimalColumn1, GridViewTextBoxColumn4, GridViewTextBoxColumn5, GridViewTextBoxColumn6, GridViewTextBoxColumn7, GridViewTextBoxColumn8, GridViewTextBoxColumn9})
        Me.dgvLotTransfer.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvLotTransfer.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgvLotTransfer.Name = "dgvLotTransfer"
        Me.dgvLotTransfer.ReadOnly = True
        Me.dgvLotTransfer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvLotTransfer.ShowGroupPanel = False
        Me.dgvLotTransfer.Size = New System.Drawing.Size(878, 306)
        Me.dgvLotTransfer.TabIndex = 0
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnPrint.Location = New System.Drawing.Point(366, 314)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 25)
        Me.btnPrint.TabIndex = 19
        Me.btnPrint.Text = "&Print"
        '
        'lblIssuePr
        '
        Me.lblIssuePr.AutoSize = True
        Me.lblIssuePr.Location = New System.Drawing.Point(610, 316)
        Me.lblIssuePr.Name = "lblIssuePr"
        Me.lblIssuePr.Size = New System.Drawing.Size(0, 23)
        Me.lblIssuePr.TabIndex = 21
        '
        'lblTransferWt
        '
        Me.lblTransferWt.AutoSize = True
        Me.lblTransferWt.Location = New System.Drawing.Point(529, 316)
        Me.lblTransferWt.Name = "lblTransferWt"
        Me.lblTransferWt.Size = New System.Drawing.Size(0, 23)
        Me.lblTransferWt.TabIndex = 22
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnExit.Location = New System.Drawing.Point(443, 314)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 25)
        Me.btnExit.TabIndex = 25
        Me.btnExit.Text = "E&xit"
        '
        'frmRptLotTransfer
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(883, 341)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.lblTransferWt)
        Me.Controls.Add(Me.lblIssuePr)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.dgvLotTransfer)
        Me.Font = New System.Drawing.Font("Tahoma", 14.25!)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmRptLotTransfer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lot Transfer Report"
        CType(Me.dgvLotTransfer.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvLotTransfer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvLotTransfer As Telerik.WinControls.UI.RadGridView
    Friend WithEvents btnPrint As Telerik.WinControls.UI.RadButton
    Friend WithEvents lblIssuePr As Label
    Friend WithEvents lblTransferWt As Label
    Friend WithEvents btnExit As Telerik.WinControls.UI.RadButton
End Class
