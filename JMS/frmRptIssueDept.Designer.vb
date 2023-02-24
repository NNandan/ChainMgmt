<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptIssueDept
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
        Me.dgvDeptIssue = New Telerik.WinControls.UI.RadGridView()
        Me.btnPrint = New Telerik.WinControls.UI.RadButton()
        Me.lblFineWt = New System.Windows.Forms.Label()
        Me.lblIssuePr = New System.Windows.Forms.Label()
        Me.lblIssueWt = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        CType(Me.dgvDeptIssue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDeptIssue.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvDeptIssue
        '
        Me.dgvDeptIssue.BackColor = System.Drawing.SystemColors.Control
        Me.dgvDeptIssue.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvDeptIssue.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.dgvDeptIssue.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvDeptIssue.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvDeptIssue.Location = New System.Drawing.Point(4, 5)
        '
        '
        '
        Me.dgvDeptIssue.MasterTemplate.AllowAddNewRow = False
        Me.dgvDeptIssue.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn9.EnableExpressionEditor = False
        GridViewTextBoxColumn9.FieldName = "IssueId"
        GridViewTextBoxColumn9.HeaderText = "Issue Id"
        GridViewTextBoxColumn9.IsVisible = False
        GridViewTextBoxColumn9.Name = "colIssueId"
        GridViewTextBoxColumn10.EnableExpressionEditor = False
        GridViewTextBoxColumn10.FieldName = "IssueDt"
        GridViewTextBoxColumn10.FormatString = "{0:dd/MM/yyyy}"
        GridViewTextBoxColumn10.HeaderText = "Issue Dt."
        GridViewTextBoxColumn10.Name = "colIssueDt"
        GridViewTextBoxColumn10.Width = 85
        GridViewTextBoxColumn11.EnableExpressionEditor = False
        GridViewTextBoxColumn11.FieldName = "VoucherNo"
        GridViewTextBoxColumn11.HeaderText = "Voucher No"
        GridViewTextBoxColumn11.Name = "colVoucherNo"
        GridViewTextBoxColumn11.Width = 105
        GridViewTextBoxColumn12.EnableExpressionEditor = False
        GridViewTextBoxColumn12.FieldName = "LotNo"
        GridViewTextBoxColumn12.HeaderText = "Lot No."
        GridViewTextBoxColumn12.Name = "colLotNo"
        GridViewTextBoxColumn12.Width = 85
        GridViewTextBoxColumn13.EnableExpressionEditor = False
        GridViewTextBoxColumn13.FieldName = "ItemName"
        GridViewTextBoxColumn13.HeaderText = "Item Name"
        GridViewTextBoxColumn13.Name = "colItemName"
        GridViewTextBoxColumn13.Width = 225
        GridViewTextBoxColumn14.AllowFiltering = False
        GridViewTextBoxColumn14.AllowGroup = False
        GridViewTextBoxColumn14.EnableExpressionEditor = False
        GridViewTextBoxColumn14.FieldName = "IssueWt"
        GridViewTextBoxColumn14.FormatString = "{0:F2}"
        GridViewTextBoxColumn14.HeaderText = "Issue Wt."
        GridViewTextBoxColumn14.Name = "colIssueWt"
        GridViewTextBoxColumn14.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn14.Width = 80
        GridViewTextBoxColumn15.AllowFiltering = False
        GridViewTextBoxColumn15.AllowGroup = False
        GridViewTextBoxColumn15.EnableExpressionEditor = False
        GridViewTextBoxColumn15.FieldName = "IssuePr"
        GridViewTextBoxColumn15.FormatString = "{0:F2}"
        GridViewTextBoxColumn15.HeaderText = "Issue %"
        GridViewTextBoxColumn15.Name = "colIssuePr"
        GridViewTextBoxColumn15.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn15.Width = 80
        GridViewTextBoxColumn16.AllowFiltering = False
        GridViewTextBoxColumn16.AllowGroup = False
        GridViewTextBoxColumn16.EnableExpressionEditor = False
        GridViewTextBoxColumn16.FieldName = "FineWt"
        GridViewTextBoxColumn16.FormatString = "{0:F2}"
        GridViewTextBoxColumn16.HeaderText = "Fine Wt."
        GridViewTextBoxColumn16.Name = "colFineWt"
        GridViewTextBoxColumn16.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn16.Width = 80
        Me.dgvDeptIssue.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn9, GridViewTextBoxColumn10, GridViewTextBoxColumn11, GridViewTextBoxColumn12, GridViewTextBoxColumn13, GridViewTextBoxColumn14, GridViewTextBoxColumn15, GridViewTextBoxColumn16})
        Me.dgvDeptIssue.MasterTemplate.EnableGrouping = False
        Me.dgvDeptIssue.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvDeptIssue.MasterTemplate.ViewDefinition = TableViewDefinition2
        Me.dgvDeptIssue.Name = "dgvDeptIssue"
        Me.dgvDeptIssue.ReadOnly = True
        Me.dgvDeptIssue.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvDeptIssue.Size = New System.Drawing.Size(740, 469)
        Me.dgvDeptIssue.TabIndex = 0
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(334, 479)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 25)
        Me.btnPrint.TabIndex = 2
        Me.btnPrint.Text = "&Print"
        '
        'lblFineWt
        '
        Me.lblFineWt.AutoSize = True
        Me.lblFineWt.Location = New System.Drawing.Point(696, 483)
        Me.lblFineWt.Name = "lblFineWt"
        Me.lblFineWt.Size = New System.Drawing.Size(0, 13)
        Me.lblFineWt.TabIndex = 6
        '
        'lblIssuePr
        '
        Me.lblIssuePr.AutoSize = True
        Me.lblIssuePr.Location = New System.Drawing.Point(625, 483)
        Me.lblIssuePr.Name = "lblIssuePr"
        Me.lblIssuePr.Size = New System.Drawing.Size(0, 13)
        Me.lblIssuePr.TabIndex = 7
        '
        'lblIssueWt
        '
        Me.lblIssueWt.AutoSize = True
        Me.lblIssueWt.Location = New System.Drawing.Point(554, 483)
        Me.lblIssueWt.Name = "lblIssueWt"
        Me.lblIssueWt.Size = New System.Drawing.Size(0, 13)
        Me.lblIssueWt.TabIndex = 8
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(430, 485)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(44, 13)
        Me.lblTotal.TabIndex = 9
        Me.lblTotal.Text = "Total :"
        '
        'frmRptIssueDept
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(747, 509)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.lblIssueWt)
        Me.Controls.Add(Me.lblIssuePr)
        Me.Controls.Add(Me.lblFineWt)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.dgvDeptIssue)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmRptIssueDept"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Deptwise Issue Report"
        CType(Me.dgvDeptIssue.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDeptIssue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvDeptIssue As Telerik.WinControls.UI.RadGridView
    Friend WithEvents btnPrint As Telerik.WinControls.UI.RadButton
    Friend WithEvents lblFineWt As Label
    Friend WithEvents lblIssuePr As Label
    Friend WithEvents lblIssueWt As Label
    Friend WithEvents lblTotal As Label
End Class
