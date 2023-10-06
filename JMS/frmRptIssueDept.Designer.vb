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
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn4 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn5 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn6 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn7 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn8 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
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
        Me.dgvDeptIssue.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvDeptIssue.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvDeptIssue.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvDeptIssue.Location = New System.Drawing.Point(4, 5)
        '
        '
        '
        Me.dgvDeptIssue.MasterTemplate.AllowAddNewRow = False
        Me.dgvDeptIssue.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "IssueId"
        GridViewTextBoxColumn1.HeaderText = "Issue Id"
        GridViewTextBoxColumn1.IsVisible = False
        GridViewTextBoxColumn1.Name = "colIssueId"
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "IssueDt"
        GridViewTextBoxColumn2.FormatString = "{0:dd/MM/yyyy}"
        GridViewTextBoxColumn2.HeaderText = "Issue Dt."
        GridViewTextBoxColumn2.Name = "colIssueDt"
        GridViewTextBoxColumn2.Width = 85
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.FieldName = "VoucherNo"
        GridViewTextBoxColumn3.HeaderText = "Voucher No"
        GridViewTextBoxColumn3.Name = "colVoucherNo"
        GridViewTextBoxColumn3.Width = 105
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.FieldName = "LotNo"
        GridViewTextBoxColumn4.HeaderText = "Lot No."
        GridViewTextBoxColumn4.Name = "colLotNo"
        GridViewTextBoxColumn4.Width = 85
        GridViewTextBoxColumn5.EnableExpressionEditor = False
        GridViewTextBoxColumn5.FieldName = "ItemName"
        GridViewTextBoxColumn5.HeaderText = "Item Name"
        GridViewTextBoxColumn5.Name = "colItemName"
        GridViewTextBoxColumn5.Width = 225
        GridViewTextBoxColumn6.AllowFiltering = False
        GridViewTextBoxColumn6.AllowGroup = False
        GridViewTextBoxColumn6.EnableExpressionEditor = False
        GridViewTextBoxColumn6.FieldName = "IssueWt"
        GridViewTextBoxColumn6.FormatString = "{0:F2}"
        GridViewTextBoxColumn6.HeaderText = "Issue Wt."
        GridViewTextBoxColumn6.Name = "colIssueWt"
        GridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn6.Width = 80
        GridViewTextBoxColumn7.AllowFiltering = False
        GridViewTextBoxColumn7.AllowGroup = False
        GridViewTextBoxColumn7.EnableExpressionEditor = False
        GridViewTextBoxColumn7.FieldName = "IssuePr"
        GridViewTextBoxColumn7.FormatString = "{0:F2}"
        GridViewTextBoxColumn7.HeaderText = "Issue %"
        GridViewTextBoxColumn7.Name = "colIssuePr"
        GridViewTextBoxColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn7.Width = 80
        GridViewTextBoxColumn8.AllowFiltering = False
        GridViewTextBoxColumn8.AllowGroup = False
        GridViewTextBoxColumn8.EnableExpressionEditor = False
        GridViewTextBoxColumn8.FieldName = "FineWt"
        GridViewTextBoxColumn8.FormatString = "{0:F2}"
        GridViewTextBoxColumn8.HeaderText = "Fine Wt."
        GridViewTextBoxColumn8.Name = "colFineWt"
        GridViewTextBoxColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn8.Width = 80
        Me.dgvDeptIssue.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5, GridViewTextBoxColumn6, GridViewTextBoxColumn7, GridViewTextBoxColumn8})
        Me.dgvDeptIssue.MasterTemplate.EnableGrouping = False
        Me.dgvDeptIssue.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvDeptIssue.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgvDeptIssue.Name = "dgvDeptIssue"
        Me.dgvDeptIssue.ReadOnly = True
        Me.dgvDeptIssue.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvDeptIssue.Size = New System.Drawing.Size(740, 469)
        Me.dgvDeptIssue.TabIndex = 0
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 9.0!)
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
        Me.lblTotal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(430, 485)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(38, 14)
        Me.lblTotal.TabIndex = 9
        Me.lblTotal.Text = "Total"
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
