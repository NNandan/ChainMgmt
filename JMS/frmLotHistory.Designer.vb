<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLotHistory
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
        Dim GridViewTextBoxColumn9 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn10 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn11 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn12 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn13 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn14 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GBoxDetails = New System.Windows.Forms.GroupBox()
        Me.btnExit = New Telerik.WinControls.UI.RadButton()
        Me.btnPrint = New Telerik.WinControls.UI.RadButton()
        Me.dgwTransaction = New Telerik.WinControls.UI.RadGridView()
        Me.GBoxMain = New System.Windows.Forms.GroupBox()
        Me.cmbLotNo = New Telerik.WinControls.UI.RadDropDownList()
        Me.lblLotNo = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GBoxDetails.SuspendLayout()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgwTransaction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgwTransaction.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBoxMain.SuspendLayout()
        CType(Me.cmbLotNo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1262, 555)
        Me.TabControl1.TabIndex = 6
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GBoxDetails)
        Me.TabPage1.Controls.Add(Me.GBoxMain)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1254, 528)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Information"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GBoxDetails
        '
        Me.GBoxDetails.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GBoxDetails.Controls.Add(Me.btnExit)
        Me.GBoxDetails.Controls.Add(Me.btnPrint)
        Me.GBoxDetails.Controls.Add(Me.dgwTransaction)
        Me.GBoxDetails.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GBoxDetails.Location = New System.Drawing.Point(5, 82)
        Me.GBoxDetails.Margin = New System.Windows.Forms.Padding(5, 3, 3, 3)
        Me.GBoxDetails.Name = "GBoxDetails"
        Me.GBoxDetails.Size = New System.Drawing.Size(1243, 436)
        Me.GBoxDetails.TabIndex = 22
        Me.GBoxDetails.TabStop = False
        Me.GBoxDetails.Text = "Lot History Details"
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnExit.Location = New System.Drawing.Point(611, 403)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 25)
        Me.btnExit.TabIndex = 26
        Me.btnExit.Text = "E&xit"
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnPrint.Location = New System.Drawing.Point(535, 403)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 25)
        Me.btnPrint.TabIndex = 21
        Me.btnPrint.Text = "&Print"
        '
        'dgwTransaction
        '
        Me.dgwTransaction.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgwTransaction.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgwTransaction.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgwTransaction.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgwTransaction.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgwTransaction.Location = New System.Drawing.Point(6, 25)
        '
        '
        '
        Me.dgwTransaction.MasterTemplate.AllowAddNewRow = False
        Me.dgwTransaction.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "TransactionDt"
        GridViewTextBoxColumn1.HeaderText = "Trans. Dt."
        GridViewTextBoxColumn1.Name = "colTransactionDt"
        GridViewTextBoxColumn1.Width = 75
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "LotNo"
        GridViewTextBoxColumn2.HeaderText = "Lot No."
        GridViewTextBoxColumn2.Name = "colLotNumber"
        GridViewTextBoxColumn2.Width = 75
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.FieldName = "OperationName"
        GridViewTextBoxColumn3.HeaderText = "Operation"
        GridViewTextBoxColumn3.Name = "colOperationName"
        GridViewTextBoxColumn3.Width = 110
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.FieldName = "ItemName"
        GridViewTextBoxColumn4.HeaderText = "Item Name"
        GridViewTextBoxColumn4.Name = "colItemName"
        GridViewTextBoxColumn4.Width = 130
        GridViewTextBoxColumn5.EnableExpressionEditor = False
        GridViewTextBoxColumn5.FieldName = "IssueWt"
        GridViewTextBoxColumn5.HeaderText = "Issue Wt."
        GridViewTextBoxColumn5.Name = "colIssueWt"
        GridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn5.Width = 70
        GridViewTextBoxColumn6.EnableExpressionEditor = False
        GridViewTextBoxColumn6.FieldName = "IssuePr"
        GridViewTextBoxColumn6.HeaderText = "Issue %"
        GridViewTextBoxColumn6.Name = "colIssuePr"
        GridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn6.Width = 70
        GridViewTextBoxColumn7.EnableExpressionEditor = False
        GridViewTextBoxColumn7.FieldName = "ReceiveWt"
        GridViewTextBoxColumn7.HeaderText = "Receive Wt."
        GridViewTextBoxColumn7.Name = "colReceiveWt"
        GridViewTextBoxColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn7.Width = 80
        GridViewTextBoxColumn8.EnableExpressionEditor = False
        GridViewTextBoxColumn8.FieldName = "ReceivePr"
        GridViewTextBoxColumn8.HeaderText = "Receive %"
        GridViewTextBoxColumn8.Name = "colReceivePr"
        GridViewTextBoxColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn8.Width = 80
        GridViewTextBoxColumn9.EnableExpressionEditor = False
        GridViewTextBoxColumn9.FieldName = "BhukaWt"
        GridViewTextBoxColumn9.HeaderText = "Scrap Wt."
        GridViewTextBoxColumn9.Name = "ColScrapWt"
        GridViewTextBoxColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn9.Width = 80
        GridViewTextBoxColumn10.EnableExpressionEditor = False
        GridViewTextBoxColumn10.FieldName = "SampleWt"
        GridViewTextBoxColumn10.HeaderText = "Sample Wt."
        GridViewTextBoxColumn10.Name = "colSampleWt"
        GridViewTextBoxColumn10.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn10.Width = 80
        GridViewTextBoxColumn11.EnableExpressionEditor = False
        GridViewTextBoxColumn11.FieldName = "VacuumWt"
        GridViewTextBoxColumn11.HeaderText = "Vacuum Wt."
        GridViewTextBoxColumn11.Name = "colVacuumWt"
        GridViewTextBoxColumn11.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn11.Width = 80
        GridViewTextBoxColumn12.EnableExpressionEditor = False
        GridViewTextBoxColumn12.FieldName = "LossWt"
        GridViewTextBoxColumn12.HeaderText = "Loss Wt."
        GridViewTextBoxColumn12.Name = "colLossWt"
        GridViewTextBoxColumn12.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn12.Width = 80
        GridViewTextBoxColumn13.EnableExpressionEditor = False
        GridViewTextBoxColumn13.FieldName = "FrLabour"
        GridViewTextBoxColumn13.HeaderText = "Fr. Labour"
        GridViewTextBoxColumn13.Name = "colFrLabour"
        GridViewTextBoxColumn13.Width = 115
        GridViewTextBoxColumn14.EnableExpressionEditor = False
        GridViewTextBoxColumn14.FieldName = "ToLabour"
        GridViewTextBoxColumn14.HeaderText = "To. Labour"
        GridViewTextBoxColumn14.Name = "colToLabour"
        GridViewTextBoxColumn14.Width = 115
        Me.dgwTransaction.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5, GridViewTextBoxColumn6, GridViewTextBoxColumn7, GridViewTextBoxColumn8, GridViewTextBoxColumn9, GridViewTextBoxColumn10, GridViewTextBoxColumn11, GridViewTextBoxColumn12, GridViewTextBoxColumn13, GridViewTextBoxColumn14})
        Me.dgwTransaction.MasterTemplate.EnableGrouping = False
        Me.dgwTransaction.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgwTransaction.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgwTransaction.Name = "dgwTransaction"
        Me.dgwTransaction.ReadOnly = True
        Me.dgwTransaction.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgwTransaction.Size = New System.Drawing.Size(1231, 368)
        Me.dgwTransaction.TabIndex = 0
        '
        'GBoxMain
        '
        Me.GBoxMain.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GBoxMain.Controls.Add(Me.cmbLotNo)
        Me.GBoxMain.Controls.Add(Me.lblLotNo)
        Me.GBoxMain.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBoxMain.Location = New System.Drawing.Point(5, 10)
        Me.GBoxMain.Margin = New System.Windows.Forms.Padding(5, 3, 3, 3)
        Me.GBoxMain.Name = "GBoxMain"
        Me.GBoxMain.Size = New System.Drawing.Size(1243, 62)
        Me.GBoxMain.TabIndex = 18
        Me.GBoxMain.TabStop = False
        Me.GBoxMain.Text = "Lot No."
        '
        'cmbLotNo
        '
        Me.cmbLotNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbLotNo.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cmbLotNo.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmbLotNo.Location = New System.Drawing.Point(70, 25)
        Me.cmbLotNo.Name = "cmbLotNo"
        Me.cmbLotNo.Size = New System.Drawing.Size(85, 20)
        Me.cmbLotNo.TabIndex = 9
        '
        'lblLotNo
        '
        Me.lblLotNo.AutoSize = True
        Me.lblLotNo.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblLotNo.Location = New System.Drawing.Point(22, 28)
        Me.lblLotNo.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblLotNo.Name = "lblLotNo"
        Me.lblLotNo.Size = New System.Drawing.Size(44, 14)
        Me.lblLotNo.TabIndex = 8
        Me.lblLotNo.Text = "Lot No"
        '
        'frmLotHistory
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1262, 555)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmLotHistory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lot History"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GBoxDetails.ResumeLayout(False)
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgwTransaction.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgwTransaction, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBoxMain.ResumeLayout(False)
        Me.GBoxMain.PerformLayout()
        CType(Me.cmbLotNo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents GBoxDetails As GroupBox
    Friend WithEvents GBoxMain As GroupBox
    Friend WithEvents dgwTransaction As Telerik.WinControls.UI.RadGridView
    Friend WithEvents lblLotNo As Label
    Friend WithEvents cmbLotNo As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents btnPrint As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnExit As Telerik.WinControls.UI.RadButton
End Class
