<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRLotTransfer
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnExit = New Telerik.WinControls.UI.RadButton()
        Me.btnDelete = New Telerik.WinControls.UI.RadButton()
        Me.cmbOperation = New Telerik.WinControls.UI.RadDropDownList()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblItemName = New System.Windows.Forms.Label()
        Me.lblOpreationType = New System.Windows.Forms.Label()
        Me.btnCancel = New Telerik.WinControls.UI.RadButton()
        Me.btnSave = New Telerik.WinControls.UI.RadButton()
        Me.txtReceiveWt = New Telerik.WinControls.UI.RadTextBox()
        Me.txtReceivePr = New Telerik.WinControls.UI.RadTextBox()
        Me.txtIssueWt = New Telerik.WinControls.UI.RadTextBox()
        Me.txtIssuePr = New Telerik.WinControls.UI.RadTextBox()
        Me.GBoxMain = New System.Windows.Forms.GroupBox()
        Me.cmbTLabour = New Telerik.WinControls.UI.RadDropDownList()
        Me.txtFrKarigar = New Telerik.WinControls.UI.RadTextBox()
        Me.cmbItem = New Telerik.WinControls.UI.RadDropDownList()
        Me.txtTransNo = New Telerik.WinControls.UI.RadTextBox()
        Me.cmbLotNo = New Telerik.WinControls.UI.RadDropDownList()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LotTransDt = New System.Windows.Forms.DateTimePicker()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lstLotTransfer = New System.Windows.Forms.ListView()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbOperation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtReceiveWt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtReceivePr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIssueWt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIssuePr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBoxMain.SuspendLayout()
        CType(Me.cmbTLabour, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFrKarigar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTransNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbLotNo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(5)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(692, 364)
        Me.TabControl1.TabIndex = 5
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.GBoxMain)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(5)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(5)
        Me.TabPage1.Size = New System.Drawing.Size(684, 337)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Information"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnExit)
        Me.GroupBox1.Controls.Add(Me.btnDelete)
        Me.GroupBox1.Controls.Add(Me.cmbOperation)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.lblItemName)
        Me.GroupBox1.Controls.Add(Me.lblOpreationType)
        Me.GroupBox1.Controls.Add(Me.btnCancel)
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Controls.Add(Me.txtReceiveWt)
        Me.GroupBox1.Controls.Add(Me.txtReceivePr)
        Me.GroupBox1.Controls.Add(Me.txtIssueWt)
        Me.GroupBox1.Controls.Add(Me.txtIssuePr)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 110)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(671, 220)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Details"
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnExit.Location = New System.Drawing.Point(417, 188)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 25)
        Me.btnExit.TabIndex = 798
        Me.btnExit.Text = "E&xit"
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnDelete.Location = New System.Drawing.Point(265, 188)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 25)
        Me.btnDelete.TabIndex = 6
        Me.btnDelete.Text = "&Delete"
        '
        'cmbOperation
        '
        Me.cmbOperation.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmbOperation.Location = New System.Drawing.Point(110, 30)
        Me.cmbOperation.Name = "cmbOperation"
        Me.cmbOperation.Size = New System.Drawing.Size(184, 20)
        Me.cmbOperation.TabIndex = 0
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label21.Location = New System.Drawing.Point(32, 149)
        Me.Label21.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(74, 14)
        Me.Label21.TabIndex = 15
        Me.Label21.Text = "Receive Wt."
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label18.Location = New System.Drawing.Point(41, 120)
        Me.Label18.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(65, 14)
        Me.Label18.TabIndex = 14
        Me.Label18.Text = "Receive %"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label15.Location = New System.Drawing.Point(46, 91)
        Me.Label15.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(60, 14)
        Me.Label15.TabIndex = 13
        Me.Label15.Text = "Issue Wt."
        '
        'lblItemName
        '
        Me.lblItemName.AutoSize = True
        Me.lblItemName.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblItemName.Location = New System.Drawing.Point(55, 62)
        Me.lblItemName.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblItemName.Name = "lblItemName"
        Me.lblItemName.Size = New System.Drawing.Size(51, 14)
        Me.lblItemName.TabIndex = 12
        Me.lblItemName.Text = "Issue %"
        '
        'lblOpreationType
        '
        Me.lblOpreationType.AutoSize = True
        Me.lblOpreationType.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblOpreationType.Location = New System.Drawing.Point(45, 33)
        Me.lblOpreationType.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblOpreationType.Name = "lblOpreationType"
        Me.lblOpreationType.Size = New System.Drawing.Size(61, 14)
        Me.lblOpreationType.TabIndex = 11
        Me.lblOpreationType.Text = "Opreation"
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnCancel.Location = New System.Drawing.Point(341, 188)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "&Cancel"
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnSave.Location = New System.Drawing.Point(189, 188)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 25)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "&Save"
        '
        'txtReceiveWt
        '
        Me.txtReceiveWt.BackColor = System.Drawing.Color.White
        Me.txtReceiveWt.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtReceiveWt.Location = New System.Drawing.Point(110, 146)
        Me.txtReceiveWt.Name = "txtReceiveWt"
        Me.txtReceiveWt.ReadOnly = True
        Me.txtReceiveWt.Size = New System.Drawing.Size(70, 20)
        Me.txtReceiveWt.TabIndex = 4
        Me.txtReceiveWt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtReceivePr
        '
        Me.txtReceivePr.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtReceivePr.Location = New System.Drawing.Point(110, 117)
        Me.txtReceivePr.Name = "txtReceivePr"
        Me.txtReceivePr.ReadOnly = True
        Me.txtReceivePr.Size = New System.Drawing.Size(70, 20)
        Me.txtReceivePr.TabIndex = 3
        Me.txtReceivePr.TabStop = False
        Me.txtReceivePr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIssueWt
        '
        Me.txtIssueWt.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtIssueWt.Location = New System.Drawing.Point(110, 88)
        Me.txtIssueWt.Name = "txtIssueWt"
        Me.txtIssueWt.ReadOnly = True
        Me.txtIssueWt.Size = New System.Drawing.Size(70, 20)
        Me.txtIssueWt.TabIndex = 2
        Me.txtIssueWt.TabStop = False
        Me.txtIssueWt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIssuePr
        '
        Me.txtIssuePr.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtIssuePr.Location = New System.Drawing.Point(110, 59)
        Me.txtIssuePr.Name = "txtIssuePr"
        Me.txtIssuePr.ReadOnly = True
        Me.txtIssuePr.Size = New System.Drawing.Size(70, 20)
        Me.txtIssuePr.TabIndex = 1
        Me.txtIssuePr.TabStop = False
        Me.txtIssuePr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GBoxMain
        '
        Me.GBoxMain.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GBoxMain.Controls.Add(Me.cmbTLabour)
        Me.GBoxMain.Controls.Add(Me.txtFrKarigar)
        Me.GBoxMain.Controls.Add(Me.cmbItem)
        Me.GBoxMain.Controls.Add(Me.txtTransNo)
        Me.GBoxMain.Controls.Add(Me.cmbLotNo)
        Me.GBoxMain.Controls.Add(Me.Label9)
        Me.GBoxMain.Controls.Add(Me.Label2)
        Me.GBoxMain.Controls.Add(Me.Label7)
        Me.GBoxMain.Controls.Add(Me.LotTransDt)
        Me.GBoxMain.Controls.Add(Me.Label26)
        Me.GBoxMain.Controls.Add(Me.Label28)
        Me.GBoxMain.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBoxMain.Location = New System.Drawing.Point(7, 10)
        Me.GBoxMain.Name = "GBoxMain"
        Me.GBoxMain.Padding = New System.Windows.Forms.Padding(5)
        Me.GBoxMain.Size = New System.Drawing.Size(668, 92)
        Me.GBoxMain.TabIndex = 18
        Me.GBoxMain.TabStop = False
        Me.GBoxMain.Text = "Use Lot Transfered"
        '
        'cmbTLabour
        '
        Me.cmbTLabour.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbTLabour.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cmbTLabour.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmbTLabour.Location = New System.Drawing.Point(531, 50)
        Me.cmbTLabour.Name = "cmbTLabour"
        Me.cmbTLabour.Size = New System.Drawing.Size(125, 20)
        Me.cmbTLabour.TabIndex = 1
        '
        'txtFrKarigar
        '
        Me.txtFrKarigar.Location = New System.Drawing.Point(531, 23)
        Me.txtFrKarigar.Name = "txtFrKarigar"
        Me.txtFrKarigar.Size = New System.Drawing.Size(125, 20)
        Me.txtFrKarigar.TabIndex = 3
        '
        'cmbItem
        '
        Me.cmbItem.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cmbItem.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmbItem.Location = New System.Drawing.Point(314, 25)
        Me.cmbItem.Name = "cmbItem"
        Me.cmbItem.Size = New System.Drawing.Size(120, 20)
        Me.cmbItem.TabIndex = 2
        '
        'txtTransNo
        '
        Me.txtTransNo.Location = New System.Drawing.Point(196, 50)
        Me.txtTransNo.Name = "txtTransNo"
        Me.txtTransNo.Size = New System.Drawing.Size(10, 20)
        Me.txtTransNo.TabIndex = 812
        Me.txtTransNo.Visible = False
        '
        'cmbLotNo
        '
        Me.cmbLotNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbLotNo.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmbLotNo.Location = New System.Drawing.Point(110, 50)
        Me.cmbLotNo.Name = "cmbLotNo"
        Me.cmbLotNo.Size = New System.Drawing.Size(85, 20)
        Me.cmbLotNo.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label9.Location = New System.Drawing.Point(454, 26)
        Me.Label9.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 14)
        Me.Label9.TabIndex = 83
        Me.Label9.Text = "Fr Employee"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(449, 53)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 14)
        Me.Label2.TabIndex = 80
        Me.Label2.Text = "To Employee"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(243, 28)
        Me.Label7.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 14)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Item Name"
        '
        'LotTransDt
        '
        Me.LotTransDt.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LotTransDt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.LotTransDt.Location = New System.Drawing.Point(110, 25)
        Me.LotTransDt.Name = "LotTransDt"
        Me.LotTransDt.Size = New System.Drawing.Size(85, 22)
        Me.LotTransDt.TabIndex = 0
        Me.LotTransDt.TabStop = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label26.Location = New System.Drawing.Point(48, 28)
        Me.Label26.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(58, 14)
        Me.Label26.TabIndex = 1
        Me.Label26.Text = "Trans Dt."
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label28.Location = New System.Drawing.Point(58, 53)
        Me.Label28.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(48, 14)
        Me.Label28.TabIndex = 1
        Me.Label28.Text = "Lot No."
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lstLotTransfer)
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(684, 337)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Edit Data"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'lstLotTransfer
        '
        Me.lstLotTransfer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstLotTransfer.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstLotTransfer.FullRowSelect = True
        Me.lstLotTransfer.GridLines = True
        Me.lstLotTransfer.Location = New System.Drawing.Point(0, 0)
        Me.lstLotTransfer.Name = "lstLotTransfer"
        Me.lstLotTransfer.Size = New System.Drawing.Size(684, 337)
        Me.lstLotTransfer.TabIndex = 0
        Me.lstLotTransfer.UseCompatibleStateImageBehavior = False
        Me.lstLotTransfer.View = System.Windows.Forms.View.Details
        '
        'frmRLotTransfer
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(692, 364)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Tahoma", 14.25!)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmRLotTransfer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Receive Transfered Lot"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbOperation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtReceiveWt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtReceivePr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIssueWt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIssuePr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBoxMain.ResumeLayout(False)
        Me.GBoxMain.PerformLayout()
        CType(Me.cmbTLabour, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFrKarigar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTransNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbLotNo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents GBoxMain As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents LotTransDt As DateTimePicker
    Friend WithEvents Label26 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents lstLotTransfer As ListView
    Friend WithEvents Label9 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbLotNo As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents txtTransNo As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents cmbItem As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents txtFrKarigar As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents cmbTLabour As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label21 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents lblItemName As Label
    Friend WithEvents lblOpreationType As Label
    Friend WithEvents btnCancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnSave As Telerik.WinControls.UI.RadButton
    Friend WithEvents txtReceiveWt As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtReceivePr As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtIssueWt As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtIssuePr As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents cmbOperation As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents btnDelete As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnExit As Telerik.WinControls.UI.RadButton
End Class
