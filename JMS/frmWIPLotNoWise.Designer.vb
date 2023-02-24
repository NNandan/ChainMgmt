<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmWIPLotNoWise
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
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.dgvWipLotNo = New Telerik.WinControls.UI.RadGridView()
        Me.lblIssueWt = New System.Windows.Forms.Label()
        Me.lblIssuePr = New System.Windows.Forms.Label()
        Me.lblIssueFw = New System.Windows.Forms.Label()
        Me.lblReceiveWt = New System.Windows.Forms.Label()
        Me.lblReceivePr = New System.Windows.Forms.Label()
        Me.lblReceiveFw = New System.Windows.Forms.Label()
        Me.btnExit = New Telerik.WinControls.UI.RadButton()
        Me.btnPrint = New Telerik.WinControls.UI.RadButton()
        Me.RadButton1 = New Telerik.WinControls.UI.RadButton()
        Me.RadButton2 = New Telerik.WinControls.UI.RadButton()
        CType(Me.dgvWipLotNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvWipLotNo.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvWipLotNo
        '
        Me.dgvWipLotNo.BackColor = System.Drawing.SystemColors.Control
        Me.dgvWipLotNo.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvWipLotNo.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvWipLotNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvWipLotNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvWipLotNo.Location = New System.Drawing.Point(0, 0)
        Me.dgvWipLotNo.Margin = New System.Windows.Forms.Padding(5)
        '
        '
        '
        Me.dgvWipLotNo.MasterTemplate.AllowAddNewRow = False
        Me.dgvWipLotNo.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn1.DataType = GetType(Date)
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "TransDt"
        GridViewTextBoxColumn1.FormatString = "{0:dd/MM/yyyy}"
        GridViewTextBoxColumn1.HeaderText = "Trans. Dt."
        GridViewTextBoxColumn1.MinWidth = 8
        GridViewTextBoxColumn1.Name = "colTransDt"
        GridViewTextBoxColumn1.Width = 85
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "LotNo"
        GridViewTextBoxColumn2.HeaderText = "Lot No"
        GridViewTextBoxColumn2.MinWidth = 8
        GridViewTextBoxColumn2.Name = "colLotNumber"
        GridViewTextBoxColumn2.Width = 90
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.FieldName = "ItemName"
        GridViewTextBoxColumn3.HeaderText = "Item Name"
        GridViewTextBoxColumn3.MinWidth = 8
        GridViewTextBoxColumn3.Name = "ColItemName"
        GridViewTextBoxColumn3.Width = 100
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.FieldName = "OperationName"
        GridViewTextBoxColumn4.HeaderText = "Operation Name"
        GridViewTextBoxColumn4.MinWidth = 8
        GridViewTextBoxColumn4.Name = "colOperationName"
        GridViewTextBoxColumn4.Width = 150
        GridViewTextBoxColumn5.EnableExpressionEditor = False
        GridViewTextBoxColumn5.FieldName = "IssueWt"
        GridViewTextBoxColumn5.HeaderText = "Issue Wt."
        GridViewTextBoxColumn5.MinWidth = 8
        GridViewTextBoxColumn5.Name = "colIssueWt"
        GridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn5.Width = 90
        GridViewTextBoxColumn6.EnableExpressionEditor = False
        GridViewTextBoxColumn6.FieldName = "IssuePr"
        GridViewTextBoxColumn6.HeaderText = "Issue %"
        GridViewTextBoxColumn6.MinWidth = 8
        GridViewTextBoxColumn6.Name = "colIssuePr"
        GridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn6.Width = 90
        GridViewTextBoxColumn7.EnableExpressionEditor = False
        GridViewTextBoxColumn7.FieldName = "IssueFine"
        GridViewTextBoxColumn7.HeaderText = "Issue Fine Wt."
        GridViewTextBoxColumn7.MinWidth = 8
        GridViewTextBoxColumn7.Name = "colIssueFine"
        GridViewTextBoxColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn7.Width = 90
        GridViewTextBoxColumn8.EnableExpressionEditor = False
        GridViewTextBoxColumn8.FieldName = "ReceiveWt"
        GridViewTextBoxColumn8.HeaderText = "Receive Wt."
        GridViewTextBoxColumn8.MinWidth = 8
        GridViewTextBoxColumn8.Name = "colReceiveWt"
        GridViewTextBoxColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn8.Width = 90
        GridViewTextBoxColumn9.EnableExpressionEditor = False
        GridViewTextBoxColumn9.FieldName = "ReceivePr"
        GridViewTextBoxColumn9.HeaderText = "Receive %"
        GridViewTextBoxColumn9.MinWidth = 8
        GridViewTextBoxColumn9.Name = "colReceivePr"
        GridViewTextBoxColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn9.Width = 90
        GridViewTextBoxColumn10.EnableExpressionEditor = False
        GridViewTextBoxColumn10.FieldName = "RecieveFine"
        GridViewTextBoxColumn10.HeaderText = "Recieve Fine Wt."
        GridViewTextBoxColumn10.MinWidth = 8
        GridViewTextBoxColumn10.Name = "colRecieveFine"
        GridViewTextBoxColumn10.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn10.Width = 110
        Me.dgvWipLotNo.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5, GridViewTextBoxColumn6, GridViewTextBoxColumn7, GridViewTextBoxColumn8, GridViewTextBoxColumn9, GridViewTextBoxColumn10})
        Me.dgvWipLotNo.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvWipLotNo.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgvWipLotNo.Name = "dgvWipLotNo"
        Me.dgvWipLotNo.ReadOnly = True
        Me.dgvWipLotNo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvWipLotNo.Size = New System.Drawing.Size(982, 469)
        Me.dgvWipLotNo.TabIndex = 0
        '
        'lblIssueWt
        '
        Me.lblIssueWt.AutoSize = True
        Me.lblIssueWt.Location = New System.Drawing.Point(667, 858)
        Me.lblIssueWt.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblIssueWt.Name = "lblIssueWt"
        Me.lblIssueWt.Size = New System.Drawing.Size(0, 23)
        Me.lblIssueWt.TabIndex = 1
        '
        'lblIssuePr
        '
        Me.lblIssuePr.AutoSize = True
        Me.lblIssuePr.Location = New System.Drawing.Point(807, 858)
        Me.lblIssuePr.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblIssuePr.Name = "lblIssuePr"
        Me.lblIssuePr.Size = New System.Drawing.Size(0, 23)
        Me.lblIssuePr.TabIndex = 2
        '
        'lblIssueFw
        '
        Me.lblIssueFw.AutoSize = True
        Me.lblIssueFw.Location = New System.Drawing.Point(933, 858)
        Me.lblIssueFw.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblIssueFw.Name = "lblIssueFw"
        Me.lblIssueFw.Size = New System.Drawing.Size(0, 23)
        Me.lblIssueFw.TabIndex = 3
        '
        'lblReceiveWt
        '
        Me.lblReceiveWt.AutoSize = True
        Me.lblReceiveWt.Location = New System.Drawing.Point(1057, 858)
        Me.lblReceiveWt.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblReceiveWt.Name = "lblReceiveWt"
        Me.lblReceiveWt.Size = New System.Drawing.Size(0, 23)
        Me.lblReceiveWt.TabIndex = 4
        '
        'lblReceivePr
        '
        Me.lblReceivePr.AutoSize = True
        Me.lblReceivePr.Location = New System.Drawing.Point(1185, 858)
        Me.lblReceivePr.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblReceivePr.Name = "lblReceivePr"
        Me.lblReceivePr.Size = New System.Drawing.Size(0, 23)
        Me.lblReceivePr.TabIndex = 5
        '
        'lblReceiveFw
        '
        Me.lblReceiveFw.AutoSize = True
        Me.lblReceiveFw.Location = New System.Drawing.Point(1322, 858)
        Me.lblReceiveFw.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblReceiveFw.Name = "lblReceiveFw"
        Me.lblReceiveFw.Size = New System.Drawing.Size(0, 23)
        Me.lblReceiveFw.TabIndex = 6
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(860, 849)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(5)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(125, 44)
        Me.btnExit.TabIndex = 26
        Me.btnExit.Text = "E&xit"
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(730, 849)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(5)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(125, 44)
        Me.btnPrint.TabIndex = 27
        Me.btnPrint.Text = "&Print"
        '
        'RadButton1
        '
        Me.RadButton1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.RadButton1.Location = New System.Drawing.Point(492, 477)
        Me.RadButton1.Name = "RadButton1"
        Me.RadButton1.Size = New System.Drawing.Size(75, 25)
        Me.RadButton1.TabIndex = 29
        Me.RadButton1.Text = "E&xit"
        '
        'RadButton2
        '
        Me.RadButton2.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.RadButton2.Location = New System.Drawing.Point(415, 477)
        Me.RadButton2.Name = "RadButton2"
        Me.RadButton2.Size = New System.Drawing.Size(75, 25)
        Me.RadButton2.TabIndex = 28
        Me.RadButton2.Text = "&Print"
        '
        'frmWIPLotNoWise
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(982, 507)
        Me.Controls.Add(Me.RadButton1)
        Me.Controls.Add(Me.RadButton2)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.lblReceiveFw)
        Me.Controls.Add(Me.lblReceivePr)
        Me.Controls.Add(Me.lblReceiveWt)
        Me.Controls.Add(Me.lblIssueFw)
        Me.Controls.Add(Me.lblIssuePr)
        Me.Controls.Add(Me.lblIssueWt)
        Me.Controls.Add(Me.dgvWipLotNo)
        Me.Font = New System.Drawing.Font("Tahoma", 14.25!)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.MaximizeBox = False
        Me.Name = "frmWIPLotNoWise"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "All Lots WIP"
        CType(Me.dgvWipLotNo.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvWipLotNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvWipLotNo As Telerik.WinControls.UI.RadGridView
    Friend WithEvents lblIssueWt As Label
    Friend WithEvents lblIssuePr As Label
    Friend WithEvents lblIssueFw As Label
    Friend WithEvents lblReceiveWt As Label
    Friend WithEvents lblReceivePr As Label
    Friend WithEvents lblReceiveFw As Label
    Friend WithEvents btnExit As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnPrint As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadButton1 As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadButton2 As Telerik.WinControls.UI.RadButton
End Class
