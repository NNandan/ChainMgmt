<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMeltingRpt
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GBoxDetails = New System.Windows.Forms.GroupBox()
        Me.ObjGrdView = New Telerik.WinControls.UI.RadGridView()
        Me.btnExit = New Telerik.WinControls.UI.RadButton()
        Me.btnPrint = New Telerik.WinControls.UI.RadButton()
        Me.GBoxMain = New System.Windows.Forms.GroupBox()
        Me.txtItemName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRequired = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbLotNo = New System.Windows.Forms.ComboBox()
        Me.lblLotNo = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GBoxDetails.SuspendLayout()
        CType(Me.ObjGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ObjGrdView.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBoxMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.TabControl1.Location = New System.Drawing.Point(0, 5)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(741, 495)
        Me.TabControl1.TabIndex = 7
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GBoxDetails)
        Me.TabPage1.Controls.Add(Me.GBoxMain)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(733, 468)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Information"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GBoxDetails
        '
        Me.GBoxDetails.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GBoxDetails.Controls.Add(Me.ObjGrdView)
        Me.GBoxDetails.Controls.Add(Me.btnExit)
        Me.GBoxDetails.Controls.Add(Me.btnPrint)
        Me.GBoxDetails.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GBoxDetails.Location = New System.Drawing.Point(5, 74)
        Me.GBoxDetails.Margin = New System.Windows.Forms.Padding(5, 3, 3, 3)
        Me.GBoxDetails.Name = "GBoxDetails"
        Me.GBoxDetails.Size = New System.Drawing.Size(723, 311)
        Me.GBoxDetails.TabIndex = 22
        Me.GBoxDetails.TabStop = False
        Me.GBoxDetails.Text = "Lot History Details"
        '
        'ObjGrdView
        '
        Me.ObjGrdView.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ObjGrdView.Cursor = System.Windows.Forms.Cursors.Default
        Me.ObjGrdView.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.ObjGrdView.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ObjGrdView.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ObjGrdView.Location = New System.Drawing.Point(6, 22)
        '
        '
        '
        Me.ObjGrdView.MasterTemplate.AllowAddNewRow = False
        Me.ObjGrdView.MasterTemplate.AllowColumnReorder = False
        Me.ObjGrdView.MasterTemplate.AllowEditRow = False
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "MeltingId"
        GridViewTextBoxColumn1.HeaderText = "MeltingId"
        GridViewTextBoxColumn1.IsVisible = False
        GridViewTextBoxColumn1.Name = "colMeltingId"
        GridViewTextBoxColumn1.Width = 80
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "ItemType"
        GridViewTextBoxColumn2.HeaderText = "Item Type"
        GridViewTextBoxColumn2.Name = "colItemType"
        GridViewTextBoxColumn2.Width = 120
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.FieldName = "SlipBagNo"
        GridViewTextBoxColumn3.HeaderText = "Slip/Bag No"
        GridViewTextBoxColumn3.Name = "colSlipBagNo"
        GridViewTextBoxColumn3.Width = 100
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.HeaderText = "Item Id"
        GridViewTextBoxColumn4.IsVisible = False
        GridViewTextBoxColumn4.Name = "colItemId"
        GridViewTextBoxColumn5.EnableExpressionEditor = False
        GridViewTextBoxColumn5.HeaderText = "Item Name"
        GridViewTextBoxColumn5.Name = "colItemName"
        GridViewTextBoxColumn5.Width = 160
        GridViewTextBoxColumn6.EnableExpressionEditor = False
        GridViewTextBoxColumn6.FieldName = "GrossWt"
        GridViewTextBoxColumn6.HeaderText = "Gross Wt."
        GridViewTextBoxColumn6.Name = "colGrossWt"
        GridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn6.Width = 90
        GridViewTextBoxColumn7.EnableExpressionEditor = False
        GridViewTextBoxColumn7.FieldName = "GrossPr"
        GridViewTextBoxColumn7.HeaderText = "Gross %"
        GridViewTextBoxColumn7.Name = "colGrossPr"
        GridViewTextBoxColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn7.Width = 90
        GridViewTextBoxColumn8.EnableExpressionEditor = False
        GridViewTextBoxColumn8.FieldName = "FineWt"
        GridViewTextBoxColumn8.HeaderText = "Fine Wt."
        GridViewTextBoxColumn8.Name = "colFineWt"
        GridViewTextBoxColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn8.Width = 90
        Me.ObjGrdView.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5, GridViewTextBoxColumn6, GridViewTextBoxColumn7, GridViewTextBoxColumn8})
        Me.ObjGrdView.MasterTemplate.EnableGrouping = False
        Me.ObjGrdView.MasterTemplate.EnableSorting = False
        Me.ObjGrdView.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.ObjGrdView.Name = "ObjGrdView"
        Me.ObjGrdView.ReadOnly = True
        Me.ObjGrdView.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ObjGrdView.Size = New System.Drawing.Size(712, 285)
        Me.ObjGrdView.TabIndex = 27
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(596, 402)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 25)
        Me.btnExit.TabIndex = 26
        Me.btnExit.Text = "E&xit"
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(520, 402)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 25)
        Me.btnPrint.TabIndex = 21
        Me.btnPrint.Text = "&Print"
        '
        'GBoxMain
        '
        Me.GBoxMain.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GBoxMain.Controls.Add(Me.txtItemName)
        Me.GBoxMain.Controls.Add(Me.Label2)
        Me.GBoxMain.Controls.Add(Me.txtRequired)
        Me.GBoxMain.Controls.Add(Me.Label1)
        Me.GBoxMain.Controls.Add(Me.cmbLotNo)
        Me.GBoxMain.Controls.Add(Me.lblLotNo)
        Me.GBoxMain.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBoxMain.Location = New System.Drawing.Point(5, 5)
        Me.GBoxMain.Margin = New System.Windows.Forms.Padding(5, 3, 3, 3)
        Me.GBoxMain.Name = "GBoxMain"
        Me.GBoxMain.Size = New System.Drawing.Size(724, 64)
        Me.GBoxMain.TabIndex = 18
        Me.GBoxMain.TabStop = False
        Me.GBoxMain.Text = "Lot No."
        '
        'txtItemName
        '
        Me.txtItemName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemName.Location = New System.Drawing.Point(388, 26)
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.Size = New System.Drawing.Size(122, 22)
        Me.txtItemName.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(317, 31)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 14)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Item Name"
        '
        'txtRequired
        '
        Me.txtRequired.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRequired.Location = New System.Drawing.Point(259, 26)
        Me.txtRequired.Name = "txtRequired"
        Me.txtRequired.Size = New System.Drawing.Size(41, 22)
        Me.txtRequired.TabIndex = 12
        Me.txtRequired.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(185, 30)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 14)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Required %"
        '
        'cmbLotNo
        '
        Me.cmbLotNo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLotNo.FormattingEnabled = True
        Me.cmbLotNo.Location = New System.Drawing.Point(62, 25)
        Me.cmbLotNo.Name = "cmbLotNo"
        Me.cmbLotNo.Size = New System.Drawing.Size(100, 22)
        Me.cmbLotNo.TabIndex = 10
        '
        'lblLotNo
        '
        Me.lblLotNo.AutoSize = True
        Me.lblLotNo.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblLotNo.Location = New System.Drawing.Point(14, 29)
        Me.lblLotNo.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblLotNo.Name = "lblLotNo"
        Me.lblLotNo.Size = New System.Drawing.Size(44, 14)
        Me.lblLotNo.TabIndex = 8
        Me.lblLotNo.Text = "Lot No"
        '
        'frmMeltingRpt
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(740, 504)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmMeltingRpt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Melting Report"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GBoxDetails.ResumeLayout(False)
        CType(Me.ObjGrdView.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ObjGrdView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBoxMain.ResumeLayout(False)
        Me.GBoxMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents GBoxDetails As GroupBox
    Friend WithEvents btnExit As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnPrint As Telerik.WinControls.UI.RadButton
    Friend WithEvents GBoxMain As GroupBox
    Friend WithEvents lblLotNo As Label
    Friend WithEvents ObjGrdView As Telerik.WinControls.UI.RadGridView
    Friend WithEvents cmbLotNo As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtRequired As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtItemName As TextBox
End Class
