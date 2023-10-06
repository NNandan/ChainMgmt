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
        Dim GridViewTextBoxColumn31 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn32 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn33 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn34 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn35 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn36 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn37 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn38 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn39 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn40 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition4 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.dgvWipLotNo = New Telerik.WinControls.UI.RadGridView()
        Me.lblIssueWt = New System.Windows.Forms.Label()
        Me.lblIssuePr = New System.Windows.Forms.Label()
        Me.lblIssueFw = New System.Windows.Forms.Label()
        Me.lblReceiveWt = New System.Windows.Forms.Label()
        Me.lblReceivePr = New System.Windows.Forms.Label()
        Me.lblReceiveFw = New System.Windows.Forms.Label()
        Me.btnExit = New Telerik.WinControls.UI.RadButton()
        Me.btnPrint = New Telerik.WinControls.UI.RadButton()
        CType(Me.dgvWipLotNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvWipLotNo.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).BeginInit()
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
        GridViewTextBoxColumn31.DataType = GetType(Date)
        GridViewTextBoxColumn31.EnableExpressionEditor = False
        GridViewTextBoxColumn31.FieldName = "TransDt"
        GridViewTextBoxColumn31.FormatString = "{0:dd/MM/yyyy}"
        GridViewTextBoxColumn31.HeaderText = "Trans. Dt."
        GridViewTextBoxColumn31.MinWidth = 8
        GridViewTextBoxColumn31.Name = "colTransDt"
        GridViewTextBoxColumn31.Width = 85
        GridViewTextBoxColumn32.EnableExpressionEditor = False
        GridViewTextBoxColumn32.FieldName = "LotNo"
        GridViewTextBoxColumn32.HeaderText = "Lot No"
        GridViewTextBoxColumn32.MinWidth = 8
        GridViewTextBoxColumn32.Name = "colLotNumber"
        GridViewTextBoxColumn32.Width = 90
        GridViewTextBoxColumn33.EnableExpressionEditor = False
        GridViewTextBoxColumn33.FieldName = "ItemName"
        GridViewTextBoxColumn33.HeaderText = "Item Name"
        GridViewTextBoxColumn33.MinWidth = 8
        GridViewTextBoxColumn33.Name = "ColItemName"
        GridViewTextBoxColumn33.Width = 100
        GridViewTextBoxColumn34.EnableExpressionEditor = False
        GridViewTextBoxColumn34.FieldName = "OperationName"
        GridViewTextBoxColumn34.HeaderText = "Operation Name"
        GridViewTextBoxColumn34.MinWidth = 8
        GridViewTextBoxColumn34.Name = "colOperationName"
        GridViewTextBoxColumn34.Width = 150
        GridViewTextBoxColumn35.EnableExpressionEditor = False
        GridViewTextBoxColumn35.FieldName = "IssueWt"
        GridViewTextBoxColumn35.HeaderText = "Issue Wt."
        GridViewTextBoxColumn35.MinWidth = 8
        GridViewTextBoxColumn35.Name = "colIssueWt"
        GridViewTextBoxColumn35.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn35.Width = 90
        GridViewTextBoxColumn36.EnableExpressionEditor = False
        GridViewTextBoxColumn36.FieldName = "IssuePr"
        GridViewTextBoxColumn36.HeaderText = "Issue %"
        GridViewTextBoxColumn36.MinWidth = 8
        GridViewTextBoxColumn36.Name = "colIssuePr"
        GridViewTextBoxColumn36.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn36.Width = 90
        GridViewTextBoxColumn37.EnableExpressionEditor = False
        GridViewTextBoxColumn37.FieldName = "IssueFine"
        GridViewTextBoxColumn37.HeaderText = "Issue Fine Wt."
        GridViewTextBoxColumn37.MinWidth = 8
        GridViewTextBoxColumn37.Name = "colIssueFine"
        GridViewTextBoxColumn37.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn37.Width = 90
        GridViewTextBoxColumn38.EnableExpressionEditor = False
        GridViewTextBoxColumn38.FieldName = "ReceiveWt"
        GridViewTextBoxColumn38.HeaderText = "Receive Wt."
        GridViewTextBoxColumn38.MinWidth = 8
        GridViewTextBoxColumn38.Name = "colReceiveWt"
        GridViewTextBoxColumn38.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn38.Width = 90
        GridViewTextBoxColumn39.EnableExpressionEditor = False
        GridViewTextBoxColumn39.FieldName = "ReceivePr"
        GridViewTextBoxColumn39.HeaderText = "Receive %"
        GridViewTextBoxColumn39.MinWidth = 8
        GridViewTextBoxColumn39.Name = "colReceivePr"
        GridViewTextBoxColumn39.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn39.Width = 90
        GridViewTextBoxColumn40.EnableExpressionEditor = False
        GridViewTextBoxColumn40.FieldName = "RecieveFine"
        GridViewTextBoxColumn40.HeaderText = "Recieve Fine Wt."
        GridViewTextBoxColumn40.MinWidth = 8
        GridViewTextBoxColumn40.Name = "colRecieveFine"
        GridViewTextBoxColumn40.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn40.Width = 110
        Me.dgvWipLotNo.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn31, GridViewTextBoxColumn32, GridViewTextBoxColumn33, GridViewTextBoxColumn34, GridViewTextBoxColumn35, GridViewTextBoxColumn36, GridViewTextBoxColumn37, GridViewTextBoxColumn38, GridViewTextBoxColumn39, GridViewTextBoxColumn40})
        Me.dgvWipLotNo.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvWipLotNo.MasterTemplate.ViewDefinition = TableViewDefinition4
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
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnExit.Location = New System.Drawing.Point(492, 476)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(5)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 25)
        Me.btnExit.TabIndex = 26
        Me.btnExit.Text = "E&xit"
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnPrint.Location = New System.Drawing.Point(415, 476)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(5)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 25)
        Me.btnPrint.TabIndex = 27
        Me.btnPrint.Text = "&Print"
        '
        'frmWIPLotNoWise
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(982, 506)
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
End Class
