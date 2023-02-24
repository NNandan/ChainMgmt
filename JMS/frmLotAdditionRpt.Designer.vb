<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLotAdditionRpt
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
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim GridViewTextBoxColumn7 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn8 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn9 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn10 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn11 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn12 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition2 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim RadListDataItem1 As Telerik.WinControls.UI.RadListDataItem = New Telerik.WinControls.UI.RadListDataItem()
        Dim RadListDataItem2 As Telerik.WinControls.UI.RadListDataItem = New Telerik.WinControls.UI.RadListDataItem()
        Me.GBoxRDetails = New System.Windows.Forms.GroupBox()
        Me.dgvReceive = New Telerik.WinControls.UI.RadGridView()
        Me.GBoxIDetails = New System.Windows.Forms.GroupBox()
        Me.dgvIssue = New Telerik.WinControls.UI.RadGridView()
        Me.GBoxMain = New System.Windows.Forms.GroupBox()
        Me.cmbLotNo = New Telerik.WinControls.UI.RadDropDownList()
        Me.lblGridIWt = New System.Windows.Forms.Label()
        Me.lblGridIPr = New System.Windows.Forms.Label()
        Me.lblGridIFine = New System.Windows.Forms.Label()
        Me.lbIlTotal = New System.Windows.Forms.Label()
        Me.lbRTotal = New System.Windows.Forms.Label()
        Me.lblGridRWt = New System.Windows.Forms.Label()
        Me.lblGridRPr = New System.Windows.Forms.Label()
        Me.lblGridRFine = New System.Windows.Forms.Label()
        Me.GBoxRDetails.SuspendLayout()
        CType(Me.dgvReceive, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvReceive.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBoxIDetails.SuspendLayout()
        CType(Me.dgvIssue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvIssue.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBoxMain.SuspendLayout()
        CType(Me.cmbLotNo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GBoxRDetails
        '
        Me.GBoxRDetails.BackColor = System.Drawing.SystemColors.Control
        Me.GBoxRDetails.Controls.Add(Me.dgvReceive)
        Me.GBoxRDetails.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBoxRDetails.Location = New System.Drawing.Point(1, 64)
        Me.GBoxRDetails.Margin = New System.Windows.Forms.Padding(5)
        Me.GBoxRDetails.Name = "GBoxRDetails"
        Me.GBoxRDetails.Padding = New System.Windows.Forms.Padding(5)
        Me.GBoxRDetails.Size = New System.Drawing.Size(450, 310)
        Me.GBoxRDetails.TabIndex = 26
        Me.GBoxRDetails.TabStop = False
        Me.GBoxRDetails.Text = "Receive Details"
        '
        'dgvReceive
        '
        Me.dgvReceive.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgvReceive.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvReceive.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvReceive.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvReceive.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvReceive.Location = New System.Drawing.Point(4, 16)
        '
        '
        '
        Me.dgvReceive.MasterTemplate.AllowAddNewRow = False
        Me.dgvReceive.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "SrNo"
        GridViewTextBoxColumn1.HeaderText = "Sr."
        GridViewTextBoxColumn1.Name = "colGRSrNo"
        GridViewTextBoxColumn1.Width = 40
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "LotAdditionDt"
        GridViewTextBoxColumn2.HeaderText = "Date"
        GridViewTextBoxColumn2.Name = "colGRDate"
        GridViewTextBoxColumn2.Width = 70
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.FieldName = "ItemName"
        GridViewTextBoxColumn3.HeaderText = "Item Name"
        GridViewTextBoxColumn3.Name = "colGRItemName"
        GridViewTextBoxColumn3.Width = 140
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.FieldName = "ReceiveWt"
        GridViewTextBoxColumn4.HeaderText = "Receive Wt."
        GridViewTextBoxColumn4.Name = "colGRReceiveWt"
        GridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn4.Width = 70
        GridViewTextBoxColumn5.EnableExpressionEditor = False
        GridViewTextBoxColumn5.FieldName = "ReceivePr"
        GridViewTextBoxColumn5.HeaderText = "Receive %"
        GridViewTextBoxColumn5.Name = "colGRReceivePr"
        GridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn5.Width = 65
        GridViewTextBoxColumn6.EnableExpressionEditor = False
        GridViewTextBoxColumn6.FieldName = "FineWt"
        GridViewTextBoxColumn6.HeaderText = "Fine Wt."
        GridViewTextBoxColumn6.Name = "colGRReceiveFine"
        GridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn6.Width = 65
        Me.dgvReceive.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5, GridViewTextBoxColumn6})
        Me.dgvReceive.MasterTemplate.EnableGrouping = False
        Me.dgvReceive.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvReceive.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgvReceive.Name = "dgvReceive"
        Me.dgvReceive.ReadOnly = True
        Me.dgvReceive.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvReceive.ShowGroupPanel = False
        Me.dgvReceive.Size = New System.Drawing.Size(446, 288)
        Me.dgvReceive.TabIndex = 868
        '
        'GBoxIDetails
        '
        Me.GBoxIDetails.Controls.Add(Me.dgvIssue)
        Me.GBoxIDetails.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBoxIDetails.Location = New System.Drawing.Point(451, 64)
        Me.GBoxIDetails.Name = "GBoxIDetails"
        Me.GBoxIDetails.Size = New System.Drawing.Size(450, 310)
        Me.GBoxIDetails.TabIndex = 27
        Me.GBoxIDetails.TabStop = False
        Me.GBoxIDetails.Text = "Issue Details"
        '
        'dgvIssue
        '
        Me.dgvIssue.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgvIssue.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvIssue.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvIssue.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvIssue.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvIssue.Location = New System.Drawing.Point(6, 16)
        '
        '
        '
        Me.dgvIssue.MasterTemplate.AllowAddNewRow = False
        Me.dgvIssue.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn7.EnableExpressionEditor = False
        GridViewTextBoxColumn7.FieldName = "SrNo"
        GridViewTextBoxColumn7.HeaderText = "Sr."
        GridViewTextBoxColumn7.Name = "colGISrNo"
        GridViewTextBoxColumn7.Width = 40
        GridViewTextBoxColumn8.EnableExpressionEditor = False
        GridViewTextBoxColumn8.FieldName = "LotAdditionDt"
        GridViewTextBoxColumn8.HeaderText = "Date"
        GridViewTextBoxColumn8.Name = "colGIDate"
        GridViewTextBoxColumn8.Width = 70
        GridViewTextBoxColumn9.EnableExpressionEditor = False
        GridViewTextBoxColumn9.FieldName = "ItemName"
        GridViewTextBoxColumn9.HeaderText = "Item Name"
        GridViewTextBoxColumn9.Name = "colGIItemName"
        GridViewTextBoxColumn9.Width = 140
        GridViewTextBoxColumn10.EnableExpressionEditor = False
        GridViewTextBoxColumn10.FieldName = "IssueWt"
        GridViewTextBoxColumn10.HeaderText = "Issue Wt"
        GridViewTextBoxColumn10.Name = "colGIIssueWt"
        GridViewTextBoxColumn10.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn10.Width = 65
        GridViewTextBoxColumn11.EnableExpressionEditor = False
        GridViewTextBoxColumn11.FieldName = "IssuePr"
        GridViewTextBoxColumn11.HeaderText = "Issue %"
        GridViewTextBoxColumn11.Name = "colGIIssuePr"
        GridViewTextBoxColumn11.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn11.Width = 65
        GridViewTextBoxColumn12.EnableExpressionEditor = False
        GridViewTextBoxColumn12.FieldName = "FineWt"
        GridViewTextBoxColumn12.HeaderText = "Fine Wt."
        GridViewTextBoxColumn12.Name = "colGIIssueFine"
        GridViewTextBoxColumn12.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn12.Width = 67
        Me.dgvIssue.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn7, GridViewTextBoxColumn8, GridViewTextBoxColumn9, GridViewTextBoxColumn10, GridViewTextBoxColumn11, GridViewTextBoxColumn12})
        Me.dgvIssue.MasterTemplate.EnableGrouping = False
        Me.dgvIssue.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvIssue.MasterTemplate.ViewDefinition = TableViewDefinition2
        Me.dgvIssue.Name = "dgvIssue"
        Me.dgvIssue.ReadOnly = True
        Me.dgvIssue.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvIssue.Size = New System.Drawing.Size(446, 288)
        Me.dgvIssue.TabIndex = 870
        '
        'GBoxMain
        '
        Me.GBoxMain.Controls.Add(Me.cmbLotNo)
        Me.GBoxMain.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBoxMain.Location = New System.Drawing.Point(5, 4)
        Me.GBoxMain.Name = "GBoxMain"
        Me.GBoxMain.Size = New System.Drawing.Size(899, 54)
        Me.GBoxMain.TabIndex = 28
        Me.GBoxMain.TabStop = False
        Me.GBoxMain.Text = "Select Lot No."
        '
        'cmbLotNo
        '
        Me.cmbLotNo.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cmbLotNo.Font = New System.Drawing.Font("Tahoma", 9.0!)
        RadListDataItem1.Text = "Admin"
        RadListDataItem2.Text = "User"
        Me.cmbLotNo.Items.Add(RadListDataItem1)
        Me.cmbLotNo.Items.Add(RadListDataItem2)
        Me.cmbLotNo.Location = New System.Drawing.Point(7, 21)
        Me.cmbLotNo.Name = "cmbLotNo"
        Me.cmbLotNo.Size = New System.Drawing.Size(101, 20)
        Me.cmbLotNo.TabIndex = 808
        '
        'lblGridIWt
        '
        Me.lblGridIWt.AutoSize = True
        Me.lblGridIWt.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblGridIWt.Location = New System.Drawing.Point(751, 384)
        Me.lblGridIWt.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblGridIWt.Name = "lblGridIWt"
        Me.lblGridIWt.Size = New System.Drawing.Size(14, 14)
        Me.lblGridIWt.TabIndex = 924
        Me.lblGridIWt.Text = "0"
        '
        'lblGridIPr
        '
        Me.lblGridIPr.AutoSize = True
        Me.lblGridIPr.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblGridIPr.Location = New System.Drawing.Point(808, 384)
        Me.lblGridIPr.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblGridIPr.Name = "lblGridIPr"
        Me.lblGridIPr.Size = New System.Drawing.Size(14, 14)
        Me.lblGridIPr.TabIndex = 925
        Me.lblGridIPr.Text = "0"
        '
        'lblGridIFine
        '
        Me.lblGridIFine.AutoSize = True
        Me.lblGridIFine.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblGridIFine.Location = New System.Drawing.Point(865, 384)
        Me.lblGridIFine.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblGridIFine.Name = "lblGridIFine"
        Me.lblGridIFine.Size = New System.Drawing.Size(14, 14)
        Me.lblGridIFine.TabIndex = 926
        Me.lblGridIFine.Text = "0"
        '
        'lbIlTotal
        '
        Me.lbIlTotal.AutoSize = True
        Me.lbIlTotal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbIlTotal.Location = New System.Drawing.Point(677, 384)
        Me.lbIlTotal.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lbIlTotal.Name = "lbIlTotal"
        Me.lbIlTotal.Size = New System.Drawing.Size(38, 14)
        Me.lbIlTotal.TabIndex = 927
        Me.lbIlTotal.Text = "Total"
        '
        'lbRTotal
        '
        Me.lbRTotal.AutoSize = True
        Me.lbRTotal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbRTotal.Location = New System.Drawing.Point(210, 384)
        Me.lbRTotal.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lbRTotal.Name = "lbRTotal"
        Me.lbRTotal.Size = New System.Drawing.Size(38, 14)
        Me.lbRTotal.TabIndex = 928
        Me.lbRTotal.Text = "Total"
        '
        'lblGridRWt
        '
        Me.lblGridRWt.AutoSize = True
        Me.lblGridRWt.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblGridRWt.Location = New System.Drawing.Point(288, 384)
        Me.lblGridRWt.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblGridRWt.Name = "lblGridRWt"
        Me.lblGridRWt.Size = New System.Drawing.Size(14, 14)
        Me.lblGridRWt.TabIndex = 929
        Me.lblGridRWt.Text = "0"
        '
        'lblGridRPr
        '
        Me.lblGridRPr.AutoSize = True
        Me.lblGridRPr.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblGridRPr.Location = New System.Drawing.Point(348, 384)
        Me.lblGridRPr.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblGridRPr.Name = "lblGridRPr"
        Me.lblGridRPr.Size = New System.Drawing.Size(14, 14)
        Me.lblGridRPr.TabIndex = 930
        Me.lblGridRPr.Text = "0"
        '
        'lblGridRFine
        '
        Me.lblGridRFine.AutoSize = True
        Me.lblGridRFine.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblGridRFine.Location = New System.Drawing.Point(408, 384)
        Me.lblGridRFine.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblGridRFine.Name = "lblGridRFine"
        Me.lblGridRFine.Size = New System.Drawing.Size(14, 14)
        Me.lblGridRFine.TabIndex = 931
        Me.lblGridRFine.Text = "0"
        '
        'frmLotAdditionRpt
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(909, 424)
        Me.Controls.Add(Me.lblGridRFine)
        Me.Controls.Add(Me.lblGridRPr)
        Me.Controls.Add(Me.lblGridRWt)
        Me.Controls.Add(Me.lbRTotal)
        Me.Controls.Add(Me.lbIlTotal)
        Me.Controls.Add(Me.lblGridIFine)
        Me.Controls.Add(Me.lblGridIPr)
        Me.Controls.Add(Me.lblGridIWt)
        Me.Controls.Add(Me.GBoxMain)
        Me.Controls.Add(Me.GBoxIDetails)
        Me.Controls.Add(Me.GBoxRDetails)
        Me.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmLotAdditionRpt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lot Addition Report"
        Me.GBoxRDetails.ResumeLayout(False)
        CType(Me.dgvReceive.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvReceive, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBoxIDetails.ResumeLayout(False)
        CType(Me.dgvIssue.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvIssue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBoxMain.ResumeLayout(False)
        Me.GBoxMain.PerformLayout()
        CType(Me.cmbLotNo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GBoxRDetails As GroupBox
    Friend WithEvents dgvReceive As Telerik.WinControls.UI.RadGridView
    Friend WithEvents GBoxIDetails As GroupBox
    Friend WithEvents dgvIssue As Telerik.WinControls.UI.RadGridView
    Friend WithEvents GBoxMain As GroupBox
    Friend WithEvents cmbLotNo As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents lblGridIWt As Label
    Friend WithEvents lblGridIPr As Label
    Friend WithEvents lblGridIFine As Label
    Friend WithEvents lbIlTotal As Label
    Friend WithEvents lbRTotal As Label
    Friend WithEvents lblGridRWt As Label
    Friend WithEvents lblGridRPr As Label
    Friend WithEvents lblGridRFine As Label
End Class
