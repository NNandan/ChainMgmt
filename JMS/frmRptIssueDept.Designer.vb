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
        Dim GridViewTextBoxColumn17 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn18 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn19 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn20 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn21 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn22 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn23 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn24 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition3 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
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
        GridViewTextBoxColumn17.EnableExpressionEditor = False
        GridViewTextBoxColumn17.FieldName = "IssueId"
        GridViewTextBoxColumn17.HeaderText = "Issue Id"
        GridViewTextBoxColumn17.IsVisible = False
        GridViewTextBoxColumn17.Name = "colIssueId"
        GridViewTextBoxColumn18.EnableExpressionEditor = False
        GridViewTextBoxColumn18.FieldName = "IssueDt"
        GridViewTextBoxColumn18.FormatString = "{0:dd/MM/yyyy}"
        GridViewTextBoxColumn18.HeaderText = "Issue Dt."
        GridViewTextBoxColumn18.Name = "colIssueDt"
        GridViewTextBoxColumn18.Width = 85
        GridViewTextBoxColumn19.EnableExpressionEditor = False
        GridViewTextBoxColumn19.FieldName = "VoucherNo"
        GridViewTextBoxColumn19.HeaderText = "Voucher No"
        GridViewTextBoxColumn19.Name = "colVoucherNo"
        GridViewTextBoxColumn19.Width = 105
        GridViewTextBoxColumn20.EnableExpressionEditor = False
        GridViewTextBoxColumn20.FieldName = "LotNo"
        GridViewTextBoxColumn20.HeaderText = "Lot No."
        GridViewTextBoxColumn20.Name = "colLotNo"
        GridViewTextBoxColumn20.Width = 85
        GridViewTextBoxColumn21.EnableExpressionEditor = False
        GridViewTextBoxColumn21.FieldName = "ItemName"
        GridViewTextBoxColumn21.HeaderText = "Item Name"
        GridViewTextBoxColumn21.Name = "colItemName"
        GridViewTextBoxColumn21.Width = 225
        GridViewTextBoxColumn22.AllowFiltering = False
        GridViewTextBoxColumn22.AllowGroup = False
        GridViewTextBoxColumn22.EnableExpressionEditor = False
        GridViewTextBoxColumn22.FieldName = "IssueWt"
        GridViewTextBoxColumn22.FormatString = "{0:F2}"
        GridViewTextBoxColumn22.HeaderText = "Issue Wt."
        GridViewTextBoxColumn22.Name = "colIssueWt"
        GridViewTextBoxColumn22.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn22.Width = 80
        GridViewTextBoxColumn23.AllowFiltering = False
        GridViewTextBoxColumn23.AllowGroup = False
        GridViewTextBoxColumn23.EnableExpressionEditor = False
        GridViewTextBoxColumn23.FieldName = "IssuePr"
        GridViewTextBoxColumn23.FormatString = "{0:F2}"
        GridViewTextBoxColumn23.HeaderText = "Issue %"
        GridViewTextBoxColumn23.Name = "colIssuePr"
        GridViewTextBoxColumn23.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn23.Width = 80
        GridViewTextBoxColumn24.AllowFiltering = False
        GridViewTextBoxColumn24.AllowGroup = False
        GridViewTextBoxColumn24.EnableExpressionEditor = False
        GridViewTextBoxColumn24.FieldName = "FineWt"
        GridViewTextBoxColumn24.FormatString = "{0:F2}"
        GridViewTextBoxColumn24.HeaderText = "Fine Wt."
        GridViewTextBoxColumn24.Name = "colFineWt"
        GridViewTextBoxColumn24.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn24.Width = 80
        Me.dgvDeptIssue.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn17, GridViewTextBoxColumn18, GridViewTextBoxColumn19, GridViewTextBoxColumn20, GridViewTextBoxColumn21, GridViewTextBoxColumn22, GridViewTextBoxColumn23, GridViewTextBoxColumn24})
        Me.dgvDeptIssue.MasterTemplate.EnableGrouping = False
        Me.dgvDeptIssue.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvDeptIssue.MasterTemplate.ViewDefinition = TableViewDefinition3
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
