<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmScrapReceive
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
        Me.TbScrapBags = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnExit = New Telerik.WinControls.UI.RadButton()
        Me.btnDelete = New Telerik.WinControls.UI.RadButton()
        Me.btnCancel = New Telerik.WinControls.UI.RadButton()
        Me.btnSave = New Telerik.WinControls.UI.RadButton()
        Me.GBoxMain = New System.Windows.Forms.GroupBox()
        Me.txtPercent = New Telerik.WinControls.UI.RadTextBox()
        Me.txtWeight = New Telerik.WinControls.UI.RadTextBox()
        Me.cmbLotNo = New Telerik.WinControls.UI.RadDropDownList()
        Me.cmbOperation = New Telerik.WinControls.UI.RadDropDownList()
        Me.txtReceiveBy = New Telerik.WinControls.UI.RadTextBox()
        Me.cmbLabour = New Telerik.WinControls.UI.RadDropDownList()
        Me.TransDt = New System.Windows.Forms.DateTimePicker()
        Me.lblPercent = New System.Windows.Forms.Label()
        Me.lblWeight = New System.Windows.Forms.Label()
        Me.lblLotNo = New System.Windows.Forms.Label()
        Me.lblOperation = New System.Windows.Forms.Label()
        Me.lblReceive = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblTransDt = New System.Windows.Forms.Label()
        Me.txtTransId = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RbMultipleOperations = New System.Windows.Forms.RadioButton()
        Me.RbMultipleLots = New System.Windows.Forms.RadioButton()
        Me.RbSpecificLots = New System.Windows.Forms.RadioButton()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lvwScrap = New System.Windows.Forms.ListView()
        Me.TbScrapBags.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBoxMain.SuspendLayout()
        CType(Me.txtPercent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbLotNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbOperation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtReceiveBy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbLabour, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TbScrapBags
        '
        Me.TbScrapBags.Controls.Add(Me.TabPage1)
        Me.TbScrapBags.Controls.Add(Me.TabPage2)
        Me.TbScrapBags.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TbScrapBags.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.TbScrapBags.Location = New System.Drawing.Point(0, 0)
        Me.TbScrapBags.Margin = New System.Windows.Forms.Padding(4)
        Me.TbScrapBags.Name = "TbScrapBags"
        Me.TbScrapBags.SelectedIndex = 0
        Me.TbScrapBags.Size = New System.Drawing.Size(716, 373)
        Me.TbScrapBags.TabIndex = 4
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnExit)
        Me.TabPage1.Controls.Add(Me.btnDelete)
        Me.TabPage1.Controls.Add(Me.btnCancel)
        Me.TabPage1.Controls.Add(Me.btnSave)
        Me.TabPage1.Controls.Add(Me.GBoxMain)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Size = New System.Drawing.Size(708, 346)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Information"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnExit.Location = New System.Drawing.Point(452, 312)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 25)
        Me.btnExit.TabIndex = 799
        Me.btnExit.Text = "E&xit"
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnDelete.Location = New System.Drawing.Point(296, 312)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 25)
        Me.btnDelete.TabIndex = 68
        Me.btnDelete.Text = "&Delete"
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnCancel.Location = New System.Drawing.Point(374, 312)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.TabIndex = 67
        Me.btnCancel.Text = "&Cancel"
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnSave.Location = New System.Drawing.Point(218, 312)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 25)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "&Save"
        '
        'GBoxMain
        '
        Me.GBoxMain.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GBoxMain.Controls.Add(Me.txtPercent)
        Me.GBoxMain.Controls.Add(Me.txtWeight)
        Me.GBoxMain.Controls.Add(Me.cmbLotNo)
        Me.GBoxMain.Controls.Add(Me.cmbOperation)
        Me.GBoxMain.Controls.Add(Me.txtReceiveBy)
        Me.GBoxMain.Controls.Add(Me.cmbLabour)
        Me.GBoxMain.Controls.Add(Me.TransDt)
        Me.GBoxMain.Controls.Add(Me.lblPercent)
        Me.GBoxMain.Controls.Add(Me.lblWeight)
        Me.GBoxMain.Controls.Add(Me.lblLotNo)
        Me.GBoxMain.Controls.Add(Me.lblOperation)
        Me.GBoxMain.Controls.Add(Me.lblReceive)
        Me.GBoxMain.Controls.Add(Me.Label2)
        Me.GBoxMain.Controls.Add(Me.lblTransDt)
        Me.GBoxMain.Controls.Add(Me.txtTransId)
        Me.GBoxMain.Controls.Add(Me.Label1)
        Me.GBoxMain.Controls.Add(Me.RbMultipleOperations)
        Me.GBoxMain.Controls.Add(Me.RbMultipleLots)
        Me.GBoxMain.Controls.Add(Me.RbSpecificLots)
        Me.GBoxMain.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GBoxMain.Location = New System.Drawing.Point(5, 9)
        Me.GBoxMain.Margin = New System.Windows.Forms.Padding(5, 3, 3, 3)
        Me.GBoxMain.Name = "GBoxMain"
        Me.GBoxMain.Padding = New System.Windows.Forms.Padding(4)
        Me.GBoxMain.Size = New System.Drawing.Size(698, 295)
        Me.GBoxMain.TabIndex = 1
        Me.GBoxMain.TabStop = False
        Me.GBoxMain.Text = "Scrap Receive Information"
        '
        'txtPercent
        '
        Me.txtPercent.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtPercent.Location = New System.Drawing.Point(156, 244)
        Me.txtPercent.Name = "txtPercent"
        Me.txtPercent.Size = New System.Drawing.Size(50, 20)
        Me.txtPercent.TabIndex = 6
        Me.txtPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtWeight
        '
        Me.txtWeight.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtWeight.Location = New System.Drawing.Point(156, 217)
        Me.txtWeight.Name = "txtWeight"
        Me.txtWeight.Size = New System.Drawing.Size(50, 20)
        Me.txtWeight.TabIndex = 5
        Me.txtWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbLotNo
        '
        Me.cmbLotNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbLotNo.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cmbLotNo.Location = New System.Drawing.Point(156, 190)
        Me.cmbLotNo.Name = "cmbLotNo"
        Me.cmbLotNo.Size = New System.Drawing.Size(130, 20)
        Me.cmbLotNo.TabIndex = 4
        '
        'cmbOperation
        '
        Me.cmbOperation.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbOperation.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cmbOperation.Location = New System.Drawing.Point(156, 163)
        Me.cmbOperation.Name = "cmbOperation"
        Me.cmbOperation.Size = New System.Drawing.Size(130, 20)
        Me.cmbOperation.TabIndex = 3
        '
        'txtReceiveBy
        '
        Me.txtReceiveBy.Location = New System.Drawing.Point(156, 136)
        Me.txtReceiveBy.Name = "txtReceiveBy"
        Me.txtReceiveBy.ReadOnly = True
        Me.txtReceiveBy.Size = New System.Drawing.Size(130, 20)
        Me.txtReceiveBy.TabIndex = 2
        '
        'cmbLabour
        '
        Me.cmbLabour.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbLabour.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cmbLabour.Location = New System.Drawing.Point(156, 109)
        Me.cmbLabour.Name = "cmbLabour"
        Me.cmbLabour.Size = New System.Drawing.Size(130, 20)
        Me.cmbLabour.TabIndex = 1
        '
        'TransDt
        '
        Me.TransDt.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.TransDt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.TransDt.Location = New System.Drawing.Point(156, 80)
        Me.TransDt.Name = "TransDt"
        Me.TransDt.Size = New System.Drawing.Size(85, 22)
        Me.TransDt.TabIndex = 0
        '
        'lblPercent
        '
        Me.lblPercent.AutoSize = True
        Me.lblPercent.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblPercent.Location = New System.Drawing.Point(102, 247)
        Me.lblPercent.Name = "lblPercent"
        Me.lblPercent.Size = New System.Drawing.Size(50, 14)
        Me.lblPercent.TabIndex = 11
        Me.lblPercent.Text = "Percent"
        '
        'lblWeight
        '
        Me.lblWeight.AutoSize = True
        Me.lblWeight.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblWeight.Location = New System.Drawing.Point(105, 220)
        Me.lblWeight.Name = "lblWeight"
        Me.lblWeight.Size = New System.Drawing.Size(47, 14)
        Me.lblWeight.TabIndex = 10
        Me.lblWeight.Text = "Weight"
        '
        'lblLotNo
        '
        Me.lblLotNo.AutoSize = True
        Me.lblLotNo.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblLotNo.Location = New System.Drawing.Point(108, 193)
        Me.lblLotNo.Name = "lblLotNo"
        Me.lblLotNo.Size = New System.Drawing.Size(44, 14)
        Me.lblLotNo.TabIndex = 9
        Me.lblLotNo.Text = "Lot No"
        '
        'lblOperation
        '
        Me.lblOperation.AutoSize = True
        Me.lblOperation.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblOperation.Location = New System.Drawing.Point(91, 166)
        Me.lblOperation.Name = "lblOperation"
        Me.lblOperation.Size = New System.Drawing.Size(61, 14)
        Me.lblOperation.TabIndex = 8
        Me.lblOperation.Text = "Operation"
        '
        'lblReceive
        '
        Me.lblReceive.AutoSize = True
        Me.lblReceive.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblReceive.Location = New System.Drawing.Point(79, 139)
        Me.lblReceive.Name = "lblReceive"
        Me.lblReceive.Size = New System.Drawing.Size(73, 14)
        Me.lblReceive.TabIndex = 7
        Me.lblReceive.Text = "Received By"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(109, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 14)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Karigar"
        '
        'lblTransDt
        '
        Me.lblTransDt.AutoSize = True
        Me.lblTransDt.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblTransDt.Location = New System.Drawing.Point(94, 83)
        Me.lblTransDt.Name = "lblTransDt"
        Me.lblTransDt.Size = New System.Drawing.Size(58, 14)
        Me.lblTransDt.TabIndex = 5
        Me.lblTransDt.Text = "Trans Dt."
        '
        'txtTransId
        '
        Me.txtTransId.Location = New System.Drawing.Point(76, 29)
        Me.txtTransId.Name = "txtTransId"
        Me.txtTransId.Size = New System.Drawing.Size(11, 22)
        Me.txtTransId.TabIndex = 4
        Me.txtTransId.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(12, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 14)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Trans Id."
        Me.Label1.Visible = False
        '
        'RbMultipleOperations
        '
        Me.RbMultipleOperations.AutoSize = True
        Me.RbMultipleOperations.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.RbMultipleOperations.Location = New System.Drawing.Point(515, 29)
        Me.RbMultipleOperations.Name = "RbMultipleOperations"
        Me.RbMultipleOperations.Size = New System.Drawing.Size(173, 18)
        Me.RbMultipleOperations.TabIndex = 2
        Me.RbMultipleOperations.TabStop = True
        Me.RbMultipleOperations.Text = "Against Multiple Operations" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.RbMultipleOperations.UseVisualStyleBackColor = True
        '
        'RbMultipleLots
        '
        Me.RbMultipleLots.AutoSize = True
        Me.RbMultipleLots.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.RbMultipleLots.Location = New System.Drawing.Point(268, 29)
        Me.RbMultipleLots.Name = "RbMultipleLots"
        Me.RbMultipleLots.Size = New System.Drawing.Size(240, 18)
        Me.RbMultipleLots.TabIndex = 1
        Me.RbMultipleLots.TabStop = True
        Me.RbMultipleLots.Text = "Against Specific Operation Multiple Lots"
        Me.RbMultipleLots.UseVisualStyleBackColor = True
        '
        'RbSpecificLots
        '
        Me.RbSpecificLots.AutoSize = True
        Me.RbSpecificLots.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.RbSpecificLots.Location = New System.Drawing.Point(128, 29)
        Me.RbSpecificLots.Name = "RbSpecificLots"
        Me.RbSpecificLots.Size = New System.Drawing.Size(132, 18)
        Me.RbSpecificLots.TabIndex = 0
        Me.RbSpecificLots.TabStop = True
        Me.RbSpecificLots.Text = "Against Specific Lot"
        Me.RbSpecificLots.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lvwScrap)
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(708, 346)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Edit Data"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'lvwScrap
        '
        Me.lvwScrap.FullRowSelect = True
        Me.lvwScrap.GridLines = True
        Me.lvwScrap.Location = New System.Drawing.Point(4, 4)
        Me.lvwScrap.Name = "lvwScrap"
        Me.lvwScrap.Size = New System.Drawing.Size(701, 336)
        Me.lvwScrap.TabIndex = 0
        Me.lvwScrap.UseCompatibleStateImageBehavior = False
        Me.lvwScrap.View = System.Windows.Forms.View.Details
        '
        'frmScrapReceive
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(716, 373)
        Me.Controls.Add(Me.TbScrapBags)
        Me.Font = New System.Drawing.Font("Tahoma", 14.25!)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmScrapReceive"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Scrap Receive"
        Me.TbScrapBags.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBoxMain.ResumeLayout(False)
        Me.GBoxMain.PerformLayout()
        CType(Me.txtPercent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbLotNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbOperation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtReceiveBy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbLabour, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TbScrapBags As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents GBoxMain As GroupBox
    Friend WithEvents txtTransId As TextBox
    Friend WithEvents RbMultipleOperations As RadioButton
    Friend WithEvents RbMultipleLots As RadioButton
    Friend WithEvents RbSpecificLots As RadioButton
    Friend WithEvents lblTransDt As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblReceive As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblPercent As Label
    Friend WithEvents lblWeight As Label
    Friend WithEvents lblLotNo As Label
    Friend WithEvents lblOperation As Label
    Friend WithEvents TransDt As DateTimePicker
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents lvwScrap As ListView
    Friend WithEvents cmbLabour As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents txtReceiveBy As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents cmbOperation As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents cmbLotNo As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents txtWeight As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtPercent As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents btnSave As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnCancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnDelete As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnExit As Telerik.WinControls.UI.RadButton
End Class
