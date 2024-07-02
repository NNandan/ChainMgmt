<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmVaccumBagByNumber
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
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.GCBoxMain = New System.Windows.Forms.GroupBox()
        Me.btnExit = New Telerik.WinControls.UI.RadButton()
        Me.btnPrint = New Telerik.WinControls.UI.RadButton()
        Me.dgvVacuumBag = New Telerik.WinControls.UI.RadGridView()
        Me.cmbVacuumBag = New Telerik.WinControls.UI.RadDropDownList()
        Me.lblKarigarName = New System.Windows.Forms.Label()
        Me.GCBoxMain.SuspendLayout()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvVacuumBag, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvVacuumBag.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbVacuumBag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCBoxMain
        '
        Me.GCBoxMain.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GCBoxMain.Controls.Add(Me.btnExit)
        Me.GCBoxMain.Controls.Add(Me.btnPrint)
        Me.GCBoxMain.Controls.Add(Me.dgvVacuumBag)
        Me.GCBoxMain.Controls.Add(Me.cmbVacuumBag)
        Me.GCBoxMain.Controls.Add(Me.lblKarigarName)
        Me.GCBoxMain.Location = New System.Drawing.Point(3, 4)
        Me.GCBoxMain.Margin = New System.Windows.Forms.Padding(5, 3, 3, 3)
        Me.GCBoxMain.Name = "GCBoxMain"
        Me.GCBoxMain.Size = New System.Drawing.Size(738, 518)
        Me.GCBoxMain.TabIndex = 19
        Me.GCBoxMain.TabStop = False
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnExit.Location = New System.Drawing.Point(375, 492)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 25)
        Me.btnExit.TabIndex = 27
        Me.btnExit.Text = "E&xit"
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnPrint.Location = New System.Drawing.Point(298, 492)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 25)
        Me.btnPrint.TabIndex = 26
        Me.btnPrint.Text = "&Print"
        '
        'dgvVacuumBag
        '
        Me.dgvVacuumBag.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvVacuumBag.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvVacuumBag.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvVacuumBag.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvVacuumBag.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvVacuumBag.Location = New System.Drawing.Point(3, 47)
        '
        '
        '
        Me.dgvVacuumBag.MasterTemplate.AllowAddNewRow = False
        Me.dgvVacuumBag.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "TransactionDt"
        GridViewTextBoxColumn1.HeaderText = "Trans. Dt"
        GridViewTextBoxColumn1.Name = "colTransDt"
        GridViewTextBoxColumn1.Width = 75
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "OperationName"
        GridViewTextBoxColumn2.HeaderText = "Operation Name"
        GridViewTextBoxColumn2.Name = "colOperationName"
        GridViewTextBoxColumn2.Width = 140
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.FieldName = "LotNo"
        GridViewTextBoxColumn3.HeaderText = "Lot No"
        GridViewTextBoxColumn3.Name = "colLotNumber"
        GridViewTextBoxColumn3.Width = 70
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.FieldName = "ReceivePr"
        GridViewTextBoxColumn4.HeaderText = "Receive %"
        GridViewTextBoxColumn4.Name = "colReceivePr"
        GridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn4.Width = 90
        GridViewTextBoxColumn5.EnableExpressionEditor = False
        GridViewTextBoxColumn5.FieldName = "IssueWt"
        GridViewTextBoxColumn5.HeaderText = "Issue Wt."
        GridViewTextBoxColumn5.Name = "colIssueWt"
        GridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn5.Width = 90
        GridViewTextBoxColumn6.EnableExpressionEditor = False
        GridViewTextBoxColumn6.FieldName = "ReceiveWt"
        GridViewTextBoxColumn6.HeaderText = "Receive Wt."
        GridViewTextBoxColumn6.Name = "colReceiveWt"
        GridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn6.Width = 90
        GridViewTextBoxColumn7.EnableExpressionEditor = False
        GridViewTextBoxColumn7.FieldName = "VacuumWt"
        GridViewTextBoxColumn7.HeaderText = "Vacuum Wt."
        GridViewTextBoxColumn7.Name = "colVacuumWt"
        GridViewTextBoxColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn7.Width = 90
        GridViewTextBoxColumn8.EnableExpressionEditor = False
        GridViewTextBoxColumn8.FieldName = "FineWt"
        GridViewTextBoxColumn8.HeaderText = "Fine Wt."
        GridViewTextBoxColumn8.Name = "colFineWt"
        GridViewTextBoxColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn8.Width = 90
        Me.dgvVacuumBag.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5, GridViewTextBoxColumn6, GridViewTextBoxColumn7, GridViewTextBoxColumn8})
        Me.dgvVacuumBag.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvVacuumBag.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgvVacuumBag.Name = "dgvVacuumBag"
        Me.dgvVacuumBag.ReadOnly = True
        Me.dgvVacuumBag.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvVacuumBag.Size = New System.Drawing.Size(732, 439)
        Me.dgvVacuumBag.TabIndex = 25
        '
        'cmbVacuumBag
        '
        Me.cmbVacuumBag.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cmbVacuumBag.Location = New System.Drawing.Point(125, 20)
        Me.cmbVacuumBag.Name = "cmbVacuumBag"
        Me.cmbVacuumBag.Size = New System.Drawing.Size(132, 20)
        Me.cmbVacuumBag.TabIndex = 24
        '
        'lblKarigarName
        '
        Me.lblKarigarName.AutoSize = True
        Me.lblKarigarName.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblKarigarName.Location = New System.Drawing.Point(8, 23)
        Me.lblKarigarName.Name = "lblKarigarName"
        Me.lblKarigarName.Size = New System.Drawing.Size(112, 14)
        Me.lblKarigarName.TabIndex = 1
        Me.lblKarigarName.Text = "Select Vaccum Bag"
        '
        'frmVaccumBagByNumber
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(744, 526)
        Me.Controls.Add(Me.GCBoxMain)
        Me.Font = New System.Drawing.Font("Tahoma", 14.25!)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmVaccumBagByNumber"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vaccum Bag By Number"
        Me.GCBoxMain.ResumeLayout(False)
        Me.GCBoxMain.PerformLayout()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvVacuumBag.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvVacuumBag, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbVacuumBag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCBoxMain As GroupBox
    Friend WithEvents cmbVacuumBag As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents lblKarigarName As Label
    Friend WithEvents dgvVacuumBag As Telerik.WinControls.UI.RadGridView
    Friend WithEvents btnPrint As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnExit As Telerik.WinControls.UI.RadButton
End Class
