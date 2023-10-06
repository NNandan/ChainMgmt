<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMetalUsedReport
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
        Dim GridViewTextBoxColumn13 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn14 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn15 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewDecimalColumn5 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewTextBoxColumn16 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewDecimalColumn6 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewTextBoxColumn17 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn18 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition3 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.dgvMeltingBagList = New Telerik.WinControls.UI.RadGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnPrint = New Telerik.WinControls.UI.RadButton()
        Me.btnExit = New Telerik.WinControls.UI.RadButton()
        CType(Me.dgvMeltingBagList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvMeltingBagList.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvMeltingBagList
        '
        Me.dgvMeltingBagList.BackColor = System.Drawing.SystemColors.Control
        Me.dgvMeltingBagList.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvMeltingBagList.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvMeltingBagList.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvMeltingBagList.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvMeltingBagList.Location = New System.Drawing.Point(6, 35)
        '
        '
        '
        Me.dgvMeltingBagList.MasterTemplate.AllowAddNewRow = False
        Me.dgvMeltingBagList.MasterTemplate.AllowColumnReorder = False
        Me.dgvMeltingBagList.MasterTemplate.AllowDeleteRow = False
        Me.dgvMeltingBagList.MasterTemplate.AllowEditRow = False
        GridViewTextBoxColumn13.EnableExpressionEditor = False
        GridViewTextBoxColumn13.FieldName = "SlipBagNo"
        GridViewTextBoxColumn13.HeaderText = "Voucher No."
        GridViewTextBoxColumn13.Name = "colVoucherNo"
        GridViewTextBoxColumn13.Width = 100
        GridViewTextBoxColumn14.EnableExpressionEditor = False
        GridViewTextBoxColumn14.FieldName = "ItemName"
        GridViewTextBoxColumn14.HeaderText = "Item Name"
        GridViewTextBoxColumn14.Name = "colItemName"
        GridViewTextBoxColumn14.Width = 130
        GridViewTextBoxColumn15.EnableExpressionEditor = False
        GridViewTextBoxColumn15.FieldName = "Used In"
        GridViewTextBoxColumn15.HeaderText = "Used In"
        GridViewTextBoxColumn15.Name = "colUsedIn"
        GridViewTextBoxColumn15.Width = 89
        GridViewDecimalColumn5.AllowFiltering = False
        GridViewDecimalColumn5.AllowGroup = False
        GridViewDecimalColumn5.EnableExpressionEditor = False
        GridViewDecimalColumn5.FieldName = "LotNo"
        GridViewDecimalColumn5.FormatString = "{0:F2}"
        GridViewDecimalColumn5.HeaderText = "Lot No."
        GridViewDecimalColumn5.Name = "colUsedInLotNo"
        GridViewDecimalColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        GridViewDecimalColumn5.Width = 100
        GridViewTextBoxColumn16.AllowFiltering = False
        GridViewTextBoxColumn16.AllowGroup = False
        GridViewTextBoxColumn16.EnableExpressionEditor = False
        GridViewTextBoxColumn16.FieldName = "IssueWt"
        GridViewTextBoxColumn16.FormatString = "{0:F2}"
        GridViewTextBoxColumn16.HeaderText = "Issue Wt."
        GridViewTextBoxColumn16.Name = "colIssueWt"
        GridViewTextBoxColumn16.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn16.Width = 90
        GridViewDecimalColumn6.AllowFiltering = False
        GridViewDecimalColumn6.AllowGroup = False
        GridViewDecimalColumn6.EnableExpressionEditor = False
        GridViewDecimalColumn6.FieldName = "IssuePr"
        GridViewDecimalColumn6.FormatString = "{0:F2}"
        GridViewDecimalColumn6.HeaderText = "Issue [%]"
        GridViewDecimalColumn6.Name = "colIssuePr"
        GridViewDecimalColumn6.Width = 90
        GridViewTextBoxColumn17.EnableExpressionEditor = False
        GridViewTextBoxColumn17.FieldName = "FineWt"
        GridViewTextBoxColumn17.HeaderText = "Fine Wt."
        GridViewTextBoxColumn17.Name = "colFineWt"
        GridViewTextBoxColumn17.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn17.Width = 90
        GridViewTextBoxColumn18.EnableExpressionEditor = False
        GridViewTextBoxColumn18.FieldName = "PartyName"
        GridViewTextBoxColumn18.HeaderText = "Party Name"
        GridViewTextBoxColumn18.Name = "colPartyName"
        GridViewTextBoxColumn18.Width = 120
        Me.dgvMeltingBagList.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn13, GridViewTextBoxColumn14, GridViewTextBoxColumn15, GridViewDecimalColumn5, GridViewTextBoxColumn16, GridViewDecimalColumn6, GridViewTextBoxColumn17, GridViewTextBoxColumn18})
        Me.dgvMeltingBagList.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvMeltingBagList.MasterTemplate.ViewDefinition = TableViewDefinition3
        Me.dgvMeltingBagList.Name = "dgvMeltingBagList"
        Me.dgvMeltingBagList.ReadOnly = True
        Me.dgvMeltingBagList.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvMeltingBagList.Size = New System.Drawing.Size(712, 371)
        Me.dgvMeltingBagList.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(253, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(236, 20)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Metal Used By Voucher Number"
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnPrint.Location = New System.Drawing.Point(294, 412)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 25)
        Me.btnPrint.TabIndex = 18
        Me.btnPrint.Text = "&Print"
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnExit.Location = New System.Drawing.Point(372, 412)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 25)
        Me.btnExit.TabIndex = 25
        Me.btnExit.Text = "E&xit"
        '
        'frmMetalUsedReport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(724, 440)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvMeltingBagList)
        Me.Font = New System.Drawing.Font("Tahoma", 14.25!)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmMetalUsedReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Metal Used By Voucher Number"
        CType(Me.dgvMeltingBagList.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvMeltingBagList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvMeltingBagList As Telerik.WinControls.UI.RadGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents btnPrint As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnExit As Telerik.WinControls.UI.RadButton
End Class
