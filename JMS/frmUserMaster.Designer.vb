﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmUserMaster
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
        Dim GridViewCheckBoxColumn1 As Telerik.WinControls.UI.GridViewCheckBoxColumn = New Telerik.WinControls.UI.GridViewCheckBoxColumn()
        Dim GridViewCheckBoxColumn2 As Telerik.WinControls.UI.GridViewCheckBoxColumn = New Telerik.WinControls.UI.GridViewCheckBoxColumn()
        Dim GridViewCheckBoxColumn3 As Telerik.WinControls.UI.GridViewCheckBoxColumn = New Telerik.WinControls.UI.GridViewCheckBoxColumn()
        Dim GridViewCheckBoxColumn4 As Telerik.WinControls.UI.GridViewCheckBoxColumn = New Telerik.WinControls.UI.GridViewCheckBoxColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUserMaster))
        Dim RadListDataItem1 As Telerik.WinControls.UI.RadListDataItem = New Telerik.WinControls.UI.RadListDataItem()
        Dim RadListDataItem2 As Telerik.WinControls.UI.RadListDataItem = New Telerik.WinControls.UI.RadListDataItem()
        Dim RadListDataItem3 As Telerik.WinControls.UI.RadListDataItem = New Telerik.WinControls.UI.RadListDataItem()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.chkAll = New Telerik.WinControls.UI.RadCheckBox()
        Me.GBoxDetails = New System.Windows.Forms.GroupBox()
        Me.btnExit = New Telerik.WinControls.UI.RadButton()
        Me.btnCancel = New Telerik.WinControls.UI.RadButton()
        Me.btnSave = New Telerik.WinControls.UI.RadButton()
        Me.btnDelete = New Telerik.WinControls.UI.RadButton()
        Me.dgvUserDetails = New Telerik.WinControls.UI.RadGridView()
        Me.GBoxMain = New System.Windows.Forms.GroupBox()
        Me.Txt_Emp_ID = New System.Windows.Forms.TextBox()
        Me.Btn_Find = New System.Windows.Forms.Button()
        Me.txtUserName = New Telerik.WinControls.UI.RadTextBox()
        Me.cmbDept = New Telerik.WinControls.UI.RadDropDownList()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbUType = New Telerik.WinControls.UI.RadDropDownList()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtConfirmPass = New Telerik.WinControls.UI.RadTextBox()
        Me.txtPassword = New Telerik.WinControls.UI.RadTextBox()
        Me.cmbLabour = New Telerik.WinControls.UI.RadDropDownList()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lvUserList = New System.Windows.Forms.ListView()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.chkAll, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBoxDetails.SuspendLayout()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvUserDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvUserDetails.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBoxMain.SuspendLayout()
        CType(Me.txtUserName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbDept, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbUType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtConfirmPass, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPassword, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbLabour, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(694, 502)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.chkAll)
        Me.TabPage1.Controls.Add(Me.GBoxDetails)
        Me.TabPage1.Controls.Add(Me.GBoxMain)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(686, 475)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Information"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'chkAll
        '
        Me.chkAll.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.chkAll.Location = New System.Drawing.Point(604, 158)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(70, 18)
        Me.chkAll.TabIndex = 2
        Me.chkAll.Text = "Select All"
        '
        'GBoxDetails
        '
        Me.GBoxDetails.Controls.Add(Me.btnExit)
        Me.GBoxDetails.Controls.Add(Me.btnCancel)
        Me.GBoxDetails.Controls.Add(Me.btnSave)
        Me.GBoxDetails.Controls.Add(Me.btnDelete)
        Me.GBoxDetails.Controls.Add(Me.dgvUserDetails)
        Me.GBoxDetails.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GBoxDetails.Location = New System.Drawing.Point(8, 176)
        Me.GBoxDetails.Name = "GBoxDetails"
        Me.GBoxDetails.Size = New System.Drawing.Size(670, 290)
        Me.GBoxDetails.TabIndex = 1
        Me.GBoxDetails.TabStop = False
        Me.GBoxDetails.Text = "User Details"
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnExit.Location = New System.Drawing.Point(411, 259)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 25)
        Me.btnExit.TabIndex = 799
        Me.btnExit.Text = "E&xit"
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnCancel.Location = New System.Drawing.Point(334, 259)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "&Cancel"
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnSave.Location = New System.Drawing.Point(180, 259)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 25)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "&Save"
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnDelete.Location = New System.Drawing.Point(257, 259)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 25)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "&Delete"
        '
        'dgvUserDetails
        '
        Me.dgvUserDetails.BackColor = System.Drawing.Color.Transparent
        Me.dgvUserDetails.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvUserDetails.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvUserDetails.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvUserDetails.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvUserDetails.Location = New System.Drawing.Point(6, 22)
        '
        '
        '
        Me.dgvUserDetails.MasterTemplate.AllowAddNewRow = False
        Me.dgvUserDetails.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn1.AllowGroup = False
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "FormName"
        GridViewTextBoxColumn1.HeaderText = "Form Name"
        GridViewTextBoxColumn1.Name = "ColFormName"
        GridViewTextBoxColumn1.ReadOnly = True
        GridViewTextBoxColumn1.Width = 304
        GridViewCheckBoxColumn1.AllowFiltering = False
        GridViewCheckBoxColumn1.AllowGroup = False
        GridViewCheckBoxColumn1.AllowSearching = False
        GridViewCheckBoxColumn1.EnableExpressionEditor = False
        GridViewCheckBoxColumn1.EnableHeaderCheckBox = True
        GridViewCheckBoxColumn1.FieldName = "ADD"
        GridViewCheckBoxColumn1.HeaderText = "Add"
        GridViewCheckBoxColumn1.MinWidth = 20
        GridViewCheckBoxColumn1.Name = "ChkAdd"
        GridViewCheckBoxColumn1.Width = 60
        GridViewCheckBoxColumn2.AllowFiltering = False
        GridViewCheckBoxColumn2.EnableExpressionEditor = False
        GridViewCheckBoxColumn2.EnableHeaderCheckBox = True
        GridViewCheckBoxColumn2.FieldName = "EDIT"
        GridViewCheckBoxColumn2.HeaderText = "Edit"
        GridViewCheckBoxColumn2.MinWidth = 20
        GridViewCheckBoxColumn2.Name = "ChkEdit"
        GridViewCheckBoxColumn2.Width = 60
        GridViewCheckBoxColumn3.AllowFiltering = False
        GridViewCheckBoxColumn3.EnableExpressionEditor = False
        GridViewCheckBoxColumn3.EnableHeaderCheckBox = True
        GridViewCheckBoxColumn3.FieldName = "VIEW"
        GridViewCheckBoxColumn3.HeaderText = "View"
        GridViewCheckBoxColumn3.MinWidth = 20
        GridViewCheckBoxColumn3.Name = "ChkView"
        GridViewCheckBoxColumn3.Width = 60
        GridViewCheckBoxColumn4.AllowFiltering = False
        GridViewCheckBoxColumn4.EnableExpressionEditor = False
        GridViewCheckBoxColumn4.EnableHeaderCheckBox = True
        GridViewCheckBoxColumn4.FieldName = "DELETE"
        GridViewCheckBoxColumn4.HeaderText = "Delete"
        GridViewCheckBoxColumn4.MinWidth = 20
        GridViewCheckBoxColumn4.Name = "ChkDelete"
        GridViewCheckBoxColumn4.Width = 60
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "UserId"
        GridViewTextBoxColumn2.HeaderText = "User Id"
        GridViewTextBoxColumn2.IsVisible = False
        GridViewTextBoxColumn2.Name = "colUserId"
        Me.dgvUserDetails.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewCheckBoxColumn1, GridViewCheckBoxColumn2, GridViewCheckBoxColumn3, GridViewCheckBoxColumn4, GridViewTextBoxColumn2})
        Me.dgvUserDetails.MasterTemplate.EnableGrouping = False
        Me.dgvUserDetails.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvUserDetails.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgvUserDetails.Name = "dgvUserDetails"
        Me.dgvUserDetails.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvUserDetails.Size = New System.Drawing.Size(659, 230)
        Me.dgvUserDetails.TabIndex = 0
        '
        'GBoxMain
        '
        Me.GBoxMain.Controls.Add(Me.Txt_Emp_ID)
        Me.GBoxMain.Controls.Add(Me.Btn_Find)
        Me.GBoxMain.Controls.Add(Me.txtUserName)
        Me.GBoxMain.Controls.Add(Me.cmbDept)
        Me.GBoxMain.Controls.Add(Me.Label6)
        Me.GBoxMain.Controls.Add(Me.cmbUType)
        Me.GBoxMain.Controls.Add(Me.Label5)
        Me.GBoxMain.Controls.Add(Me.txtConfirmPass)
        Me.GBoxMain.Controls.Add(Me.txtPassword)
        Me.GBoxMain.Controls.Add(Me.cmbLabour)
        Me.GBoxMain.Controls.Add(Me.Label4)
        Me.GBoxMain.Controls.Add(Me.Label3)
        Me.GBoxMain.Controls.Add(Me.Label2)
        Me.GBoxMain.Controls.Add(Me.Label1)
        Me.GBoxMain.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBoxMain.Location = New System.Drawing.Point(8, 10)
        Me.GBoxMain.Name = "GBoxMain"
        Me.GBoxMain.Size = New System.Drawing.Size(670, 143)
        Me.GBoxMain.TabIndex = 0
        Me.GBoxMain.TabStop = False
        Me.GBoxMain.Text = "User Information"
        '
        'Txt_Emp_ID
        '
        Me.Txt_Emp_ID.Location = New System.Drawing.Point(557, 22)
        Me.Txt_Emp_ID.Name = "Txt_Emp_ID"
        Me.Txt_Emp_ID.Size = New System.Drawing.Size(67, 22)
        Me.Txt_Emp_ID.TabIndex = 156
        '
        'Btn_Find
        '
        Me.Btn_Find.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Btn_Find.BackgroundImage = CType(resources.GetObject("Btn_Find.BackgroundImage"), System.Drawing.Image)
        Me.Btn_Find.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btn_Find.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btn_Find.ForeColor = System.Drawing.Color.White
        Me.Btn_Find.Location = New System.Drawing.Point(625, 23)
        Me.Btn_Find.Name = "Btn_Find"
        Me.Btn_Find.Size = New System.Drawing.Size(33, 21)
        Me.Btn_Find.TabIndex = 155
        Me.Btn_Find.TabStop = False
        Me.Btn_Find.Text = "F1"
        Me.Btn_Find.UseVisualStyleBackColor = False
        '
        'txtUserName
        '
        Me.txtUserName.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtUserName.Location = New System.Drawing.Point(126, 53)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(100, 20)
        Me.txtUserName.TabIndex = 1
        '
        'cmbDept
        '
        Me.cmbDept.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbDept.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cmbDept.Location = New System.Drawing.Point(375, 53)
        Me.cmbDept.Name = "cmbDept"
        Me.cmbDept.Size = New System.Drawing.Size(100, 20)
        Me.cmbDept.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(320, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 14)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Fr. Dept"
        '
        'cmbUType
        '
        Me.cmbUType.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbUType.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        RadListDataItem1.Text = "Super"
        RadListDataItem2.Text = "Admin"
        RadListDataItem3.Text = "User"
        Me.cmbUType.Items.Add(RadListDataItem1)
        Me.cmbUType.Items.Add(RadListDataItem2)
        Me.cmbUType.Items.Add(RadListDataItem3)
        Me.cmbUType.Location = New System.Drawing.Point(375, 23)
        Me.cmbUType.Name = "cmbUType"
        Me.cmbUType.Size = New System.Drawing.Size(100, 20)
        Me.cmbUType.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(336, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 14)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Type"
        '
        'txtConfirmPass
        '
        Me.txtConfirmPass.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtConfirmPass.Location = New System.Drawing.Point(126, 111)
        Me.txtConfirmPass.Name = "txtConfirmPass"
        Me.txtConfirmPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirmPass.Size = New System.Drawing.Size(100, 20)
        Me.txtConfirmPass.TabIndex = 3
        '
        'txtPassword
        '
        Me.txtPassword.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtPassword.Location = New System.Drawing.Point(126, 82)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(100, 20)
        Me.txtPassword.TabIndex = 2
        '
        'cmbLabour
        '
        Me.cmbLabour.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbLabour.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cmbLabour.Location = New System.Drawing.Point(126, 24)
        Me.cmbLabour.Name = "cmbLabour"
        Me.cmbLabour.Size = New System.Drawing.Size(150, 20)
        Me.cmbLabour.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(19, 114)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 14)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Confirm Password"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(64, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 14)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Password"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(56, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 14)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "User Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(53, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Select User"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lvUserList)
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(686, 475)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Edit"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'lvUserList
        '
        Me.lvUserList.GridLines = True
        Me.lvUserList.LabelEdit = True
        Me.lvUserList.Location = New System.Drawing.Point(5, 35)
        Me.lvUserList.MultiSelect = False
        Me.lvUserList.Name = "lvUserList"
        Me.lvUserList.Size = New System.Drawing.Size(680, 425)
        Me.lvUserList.TabIndex = 0
        Me.lvUserList.UseCompatibleStateImageBehavior = False
        Me.lvUserList.View = System.Windows.Forms.View.Details
        '
        'frmUserMaster
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(694, 507)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(7, 22)
        Me.MaximizeBox = False
        Me.Name = "frmUserMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User Master"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.chkAll, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBoxDetails.ResumeLayout(False)
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvUserDetails.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvUserDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBoxMain.ResumeLayout(False)
        Me.GBoxMain.PerformLayout()
        CType(Me.txtUserName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbDept, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbUType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtConfirmPass, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPassword, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbLabour, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents GBoxMain As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents txtConfirmPass As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtPassword As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents cmbLabour As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents GBoxDetails As GroupBox
    Friend WithEvents dgvUserDetails As Telerik.WinControls.UI.RadGridView
    Friend WithEvents btnCancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnSave As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnDelete As Telerik.WinControls.UI.RadButton
    Friend WithEvents chkAll As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents lvUserList As ListView
    Friend WithEvents cmbUType As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents Label5 As Label
    Friend WithEvents txtUserName As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents cmbDept As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents Label6 As Label
    Friend WithEvents btnExit As Telerik.WinControls.UI.RadButton
    Friend WithEvents Btn_Find As Button
    Friend WithEvents Txt_Emp_ID As TextBox
End Class
