<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCoreAdditionIssue
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
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnExit = New Telerik.WinControls.UI.RadButton()
        Me.btnCancel = New Telerik.WinControls.UI.RadButton()
        Me.btnSave = New Telerik.WinControls.UI.RadButton()
        Me.btnDelete = New Telerik.WinControls.UI.RadButton()
        Me.GBoxMain = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTotalFw = New System.Windows.Forms.TextBox()
        Me.txtCoreFw = New System.Windows.Forms.TextBox()
        Me.txtIssueFw = New System.Windows.Forms.TextBox()
        Me.txtTotalPr = New System.Windows.Forms.TextBox()
        Me.txtCorePr = New System.Windows.Forms.TextBox()
        Me.cmbTLabour = New Telerik.WinControls.UI.RadDropDownList()
        Me.cmbLotNo = New Telerik.WinControls.UI.RadDropDownList()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTotalIssue = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.txtCoreWt = New System.Windows.Forms.TextBox()
        Me.txtIssuePr = New System.Windows.Forms.TextBox()
        Me.txtIssueWt = New System.Windows.Forms.TextBox()
        Me.lblPercent = New System.Windows.Forms.Label()
        Me.lblWeight = New System.Windows.Forms.Label()
        Me.txtFrKarigar = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TransDt = New System.Windows.Forms.DateTimePicker()
        Me.txtTransNo = New System.Windows.Forms.TextBox()
        Me.LblLotADate = New System.Windows.Forms.Label()
        Me.lblLotNo = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.RadGridView1 = New Telerik.WinControls.UI.RadGridView()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBoxMain.SuspendLayout()
        CType(Me.cmbTLabour, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbLotNo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.RadGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGridView1.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(5)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(609, 317)
        Me.TabControl1.TabIndex = 6
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.Controls.Add(Me.btnExit)
        Me.TabPage1.Controls.Add(Me.btnCancel)
        Me.TabPage1.Controls.Add(Me.btnSave)
        Me.TabPage1.Controls.Add(Me.btnDelete)
        Me.TabPage1.Controls.Add(Me.GBoxMain)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(5)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(5)
        Me.TabPage1.Size = New System.Drawing.Size(601, 290)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Information"
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnExit.Location = New System.Drawing.Point(368, 257)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 25)
        Me.btnExit.TabIndex = 931
        Me.btnExit.Text = "E&xit"
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnCancel.Location = New System.Drawing.Point(291, 257)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "&Cancel"
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnSave.Location = New System.Drawing.Point(137, 257)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 25)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "&Save"
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnDelete.Location = New System.Drawing.Point(214, 257)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 25)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "&Delete"
        '
        'GBoxMain
        '
        Me.GBoxMain.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GBoxMain.Controls.Add(Me.Label5)
        Me.GBoxMain.Controls.Add(Me.txtTotalFw)
        Me.GBoxMain.Controls.Add(Me.txtCoreFw)
        Me.GBoxMain.Controls.Add(Me.txtIssueFw)
        Me.GBoxMain.Controls.Add(Me.txtTotalPr)
        Me.GBoxMain.Controls.Add(Me.txtCorePr)
        Me.GBoxMain.Controls.Add(Me.cmbTLabour)
        Me.GBoxMain.Controls.Add(Me.cmbLotNo)
        Me.GBoxMain.Controls.Add(Me.Label4)
        Me.GBoxMain.Controls.Add(Me.Label3)
        Me.GBoxMain.Controls.Add(Me.lblTotalIssue)
        Me.GBoxMain.Controls.Add(Me.txtTotal)
        Me.GBoxMain.Controls.Add(Me.txtCoreWt)
        Me.GBoxMain.Controls.Add(Me.txtIssuePr)
        Me.GBoxMain.Controls.Add(Me.txtIssueWt)
        Me.GBoxMain.Controls.Add(Me.lblPercent)
        Me.GBoxMain.Controls.Add(Me.lblWeight)
        Me.GBoxMain.Controls.Add(Me.txtFrKarigar)
        Me.GBoxMain.Controls.Add(Me.Label1)
        Me.GBoxMain.Controls.Add(Me.Label2)
        Me.GBoxMain.Controls.Add(Me.TransDt)
        Me.GBoxMain.Controls.Add(Me.txtTransNo)
        Me.GBoxMain.Controls.Add(Me.LblLotADate)
        Me.GBoxMain.Controls.Add(Me.lblLotNo)
        Me.GBoxMain.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBoxMain.Location = New System.Drawing.Point(5, 8)
        Me.GBoxMain.Margin = New System.Windows.Forms.Padding(5)
        Me.GBoxMain.Name = "GBoxMain"
        Me.GBoxMain.Padding = New System.Windows.Forms.Padding(5)
        Me.GBoxMain.Size = New System.Drawing.Size(591, 242)
        Me.GBoxMain.TabIndex = 18
        Me.GBoxMain.TabStop = False
        Me.GBoxMain.Text = "Core Addition Information"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.Label5.Location = New System.Drawing.Point(192, 93)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 15)
        Me.Label5.TabIndex = 810
        Me.Label5.Text = "Fine Wt."
        '
        'txtTotalFw
        '
        Me.txtTotalFw.BackColor = System.Drawing.Color.White
        Me.txtTotalFw.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtTotalFw.Location = New System.Drawing.Point(190, 166)
        Me.txtTotalFw.Name = "txtTotalFw"
        Me.txtTotalFw.ReadOnly = True
        Me.txtTotalFw.Size = New System.Drawing.Size(55, 22)
        Me.txtTotalFw.TabIndex = 809
        Me.txtTotalFw.TabStop = False
        Me.txtTotalFw.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCoreFw
        '
        Me.txtCoreFw.BackColor = System.Drawing.Color.White
        Me.txtCoreFw.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtCoreFw.Location = New System.Drawing.Point(190, 140)
        Me.txtCoreFw.Name = "txtCoreFw"
        Me.txtCoreFw.ReadOnly = True
        Me.txtCoreFw.Size = New System.Drawing.Size(55, 22)
        Me.txtCoreFw.TabIndex = 808
        Me.txtCoreFw.TabStop = False
        Me.txtCoreFw.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIssueFw
        '
        Me.txtIssueFw.BackColor = System.Drawing.Color.White
        Me.txtIssueFw.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtIssueFw.Location = New System.Drawing.Point(190, 114)
        Me.txtIssueFw.Name = "txtIssueFw"
        Me.txtIssueFw.ReadOnly = True
        Me.txtIssueFw.Size = New System.Drawing.Size(55, 22)
        Me.txtIssueFw.TabIndex = 807
        Me.txtIssueFw.TabStop = False
        Me.txtIssueFw.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalPr
        '
        Me.txtTotalPr.BackColor = System.Drawing.Color.White
        Me.txtTotalPr.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtTotalPr.Location = New System.Drawing.Point(133, 166)
        Me.txtTotalPr.Name = "txtTotalPr"
        Me.txtTotalPr.ReadOnly = True
        Me.txtTotalPr.Size = New System.Drawing.Size(55, 22)
        Me.txtTotalPr.TabIndex = 806
        Me.txtTotalPr.TabStop = False
        Me.txtTotalPr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCorePr
        '
        Me.txtCorePr.BackColor = System.Drawing.Color.White
        Me.txtCorePr.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtCorePr.Location = New System.Drawing.Point(133, 140)
        Me.txtCorePr.Name = "txtCorePr"
        Me.txtCorePr.ReadOnly = True
        Me.txtCorePr.Size = New System.Drawing.Size(55, 22)
        Me.txtCorePr.TabIndex = 805
        Me.txtCorePr.TabStop = False
        Me.txtCorePr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbTLabour
        '
        Me.cmbTLabour.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbTLabour.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmbTLabour.Location = New System.Drawing.Point(456, 43)
        Me.cmbTLabour.Name = "cmbTLabour"
        Me.cmbTLabour.Size = New System.Drawing.Size(128, 20)
        Me.cmbTLabour.TabIndex = 3
        '
        'cmbLotNo
        '
        Me.cmbLotNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbLotNo.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cmbLotNo.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmbLotNo.Location = New System.Drawing.Point(80, 49)
        Me.cmbLotNo.Name = "cmbLotNo"
        Me.cmbLotNo.Size = New System.Drawing.Size(88, 20)
        Me.cmbLotNo.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.Label4.Location = New System.Drawing.Point(15, 170)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 15)
        Me.Label4.TabIndex = 804
        Me.Label4.Text = "Total Wt."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.Label3.Location = New System.Drawing.Point(18, 144)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 15)
        Me.Label3.TabIndex = 803
        Me.Label3.Text = "Core Wt."
        '
        'lblTotalIssue
        '
        Me.lblTotalIssue.AutoSize = True
        Me.lblTotalIssue.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.lblTotalIssue.Location = New System.Drawing.Point(17, 117)
        Me.lblTotalIssue.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblTotalIssue.Name = "lblTotalIssue"
        Me.lblTotalIssue.Size = New System.Drawing.Size(55, 15)
        Me.lblTotalIssue.TabIndex = 802
        Me.lblTotalIssue.Text = "Gold Wt."
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.White
        Me.txtTotal.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtTotal.Location = New System.Drawing.Point(76, 166)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(55, 22)
        Me.txtTotal.TabIndex = 7
        Me.txtTotal.TabStop = False
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCoreWt
        '
        Me.txtCoreWt.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCoreWt.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtCoreWt.Location = New System.Drawing.Point(76, 140)
        Me.txtCoreWt.Name = "txtCoreWt"
        Me.txtCoreWt.Size = New System.Drawing.Size(55, 22)
        Me.txtCoreWt.TabIndex = 6
        Me.txtCoreWt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIssuePr
        '
        Me.txtIssuePr.BackColor = System.Drawing.Color.White
        Me.txtIssuePr.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtIssuePr.Location = New System.Drawing.Point(133, 114)
        Me.txtIssuePr.Name = "txtIssuePr"
        Me.txtIssuePr.ReadOnly = True
        Me.txtIssuePr.Size = New System.Drawing.Size(55, 22)
        Me.txtIssuePr.TabIndex = 5
        Me.txtIssuePr.TabStop = False
        Me.txtIssuePr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIssueWt
        '
        Me.txtIssueWt.BackColor = System.Drawing.Color.White
        Me.txtIssueWt.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIssueWt.Location = New System.Drawing.Point(76, 114)
        Me.txtIssueWt.Name = "txtIssueWt"
        Me.txtIssueWt.ReadOnly = True
        Me.txtIssueWt.Size = New System.Drawing.Size(55, 22)
        Me.txtIssueWt.TabIndex = 4
        Me.txtIssueWt.TabStop = False
        Me.txtIssueWt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPercent
        '
        Me.lblPercent.AutoSize = True
        Me.lblPercent.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.lblPercent.Location = New System.Drawing.Point(140, 93)
        Me.lblPercent.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblPercent.Name = "lblPercent"
        Me.lblPercent.Size = New System.Drawing.Size(50, 15)
        Me.lblPercent.TabIndex = 796
        Me.lblPercent.Text = "Issue %"
        '
        'lblWeight
        '
        Me.lblWeight.AutoSize = True
        Me.lblWeight.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.lblWeight.Location = New System.Drawing.Point(79, 93)
        Me.lblWeight.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblWeight.Name = "lblWeight"
        Me.lblWeight.Size = New System.Drawing.Size(59, 15)
        Me.lblWeight.TabIndex = 795
        Me.lblWeight.Text = "Issue Wt."
        '
        'txtFrKarigar
        '
        Me.txtFrKarigar.BackColor = System.Drawing.Color.White
        Me.txtFrKarigar.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtFrKarigar.Location = New System.Drawing.Point(456, 16)
        Me.txtFrKarigar.Margin = New System.Windows.Forms.Padding(5)
        Me.txtFrKarigar.Name = "txtFrKarigar"
        Me.txtFrKarigar.ReadOnly = True
        Me.txtFrKarigar.Size = New System.Drawing.Size(128, 22)
        Me.txtFrKarigar.TabIndex = 2
        Me.txtFrKarigar.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.Label1.Location = New System.Drawing.Point(379, 19)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 15)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Fr Employee"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.Label2.Location = New System.Drawing.Point(377, 45)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 15)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "To Employee"
        '
        'TransDt
        '
        Me.TransDt.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TransDt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.TransDt.Location = New System.Drawing.Point(80, 23)
        Me.TransDt.Name = "TransDt"
        Me.TransDt.Size = New System.Drawing.Size(88, 22)
        Me.TransDt.TabIndex = 0
        Me.TransDt.TabStop = False
        '
        'txtTransNo
        '
        Me.txtTransNo.BackColor = System.Drawing.Color.White
        Me.txtTransNo.Location = New System.Drawing.Point(172, 23)
        Me.txtTransNo.Margin = New System.Windows.Forms.Padding(5)
        Me.txtTransNo.Name = "txtTransNo"
        Me.txtTransNo.ReadOnly = True
        Me.txtTransNo.Size = New System.Drawing.Size(10, 22)
        Me.txtTransNo.TabIndex = 0
        Me.txtTransNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTransNo.Visible = False
        '
        'LblLotADate
        '
        Me.LblLotADate.AutoSize = True
        Me.LblLotADate.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLotADate.Location = New System.Drawing.Point(22, 26)
        Me.LblLotADate.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.LblLotADate.Name = "LblLotADate"
        Me.LblLotADate.Size = New System.Drawing.Size(54, 15)
        Me.LblLotADate.TabIndex = 1
        Me.LblLotADate.Text = "Trans Dt"
        '
        'lblLotNo
        '
        Me.lblLotNo.AutoSize = True
        Me.lblLotNo.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.lblLotNo.Location = New System.Drawing.Point(25, 51)
        Me.lblLotNo.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblLotNo.Name = "lblLotNo"
        Me.lblLotNo.Size = New System.Drawing.Size(50, 15)
        Me.lblLotNo.TabIndex = 1
        Me.lblLotNo.Text = "Lot  No."
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.RadGridView1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(601, 290)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Edit Data"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'RadGridView1
        '
        Me.RadGridView1.Location = New System.Drawing.Point(3, 4)
        '
        '
        '
        Me.RadGridView1.MasterTemplate.AllowAddNewRow = False
        Me.RadGridView1.MasterTemplate.AllowColumnReorder = False
        Me.RadGridView1.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.RadGridView1.Name = "RadGridView1"
        Me.RadGridView1.ReadOnly = True
        Me.RadGridView1.Size = New System.Drawing.Size(596, 283)
        Me.RadGridView1.TabIndex = 0
        '
        'frmCoreAdditionIssue
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(609, 317)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmCoreAdditionIssue"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Core Addition Issue"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBoxMain.ResumeLayout(False)
        Me.GBoxMain.PerformLayout()
        CType(Me.cmbTLabour, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbLotNo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.RadGridView1.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents GBoxMain As GroupBox
    Friend WithEvents lblLotNo As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents txtTransNo As TextBox
    Friend WithEvents LblLotADate As Label
    Friend WithEvents TransDt As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents txtFrKarigar As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtIssuePr As TextBox
    Friend WithEvents txtIssueWt As TextBox
    Friend WithEvents lblPercent As Label
    Friend WithEvents lblWeight As Label
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents txtCoreWt As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblTotalIssue As Label
    Friend WithEvents btnCancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnSave As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnDelete As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmbLotNo As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents cmbTLabour As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents txtTotalPr As TextBox
    Friend WithEvents txtCorePr As TextBox
    Friend WithEvents txtIssueFw As TextBox
    Friend WithEvents txtTotalFw As TextBox
    Friend WithEvents txtCoreFw As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnExit As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadGridView1 As Telerik.WinControls.UI.RadGridView
End Class
