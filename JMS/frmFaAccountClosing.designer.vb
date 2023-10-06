<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFaAccountClosing
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
        Me.lblFancy = New System.Windows.Forms.Label()
        Me.lblPClosedBy = New System.Windows.Forms.Label()
        Me.txtClosedBy = New System.Windows.Forms.TextBox()
        Me.lblCreatedDt = New System.Windows.Forms.Label()
        Me.txtClosedDt = New System.Windows.Forms.TextBox()
        Me.lblFromDt = New System.Windows.Forms.Label()
        Me.txtFromDt = New System.Windows.Forms.TextBox()
        Me.lblClosedDt = New System.Windows.Forms.Label()
        Me.txtToDt = New System.Windows.Forms.TextBox()
        Me.lblPeriodNo = New System.Windows.Forms.Label()
        Me.txtPeriodNo = New System.Windows.Forms.TextBox()
        Me.lblRemark = New System.Windows.Forms.Label()
        Me.txtRemark = New System.Windows.Forms.TextBox()
        Me.btnClosedAcc = New Telerik.WinControls.UI.RadButton()
        Me.BtnCancel = New Telerik.WinControls.UI.RadButton()
        Me.BtnExit = New Telerik.WinControls.UI.RadButton()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        CType(Me.btnClosedAcc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblFancy
        '
        Me.lblFancy.AutoSize = True
        Me.lblFancy.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFancy.Location = New System.Drawing.Point(193, 9)
        Me.lblFancy.Name = "lblFancy"
        Me.lblFancy.Size = New System.Drawing.Size(0, 14)
        Me.lblFancy.TabIndex = 1
        '
        'lblPClosedBy
        '
        Me.lblPClosedBy.AutoSize = True
        Me.lblPClosedBy.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblPClosedBy.Location = New System.Drawing.Point(34, 53)
        Me.lblPClosedBy.Name = "lblPClosedBy"
        Me.lblPClosedBy.Size = New System.Drawing.Size(97, 14)
        Me.lblPClosedBy.TabIndex = 2
        Me.lblPClosedBy.Text = "Period Closed By"
        '
        'txtClosedBy
        '
        Me.txtClosedBy.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtClosedBy.Location = New System.Drawing.Point(135, 50)
        Me.txtClosedBy.Name = "txtClosedBy"
        Me.txtClosedBy.ReadOnly = True
        Me.txtClosedBy.Size = New System.Drawing.Size(163, 22)
        Me.txtClosedBy.TabIndex = 3
        '
        'lblCreatedDt
        '
        Me.lblCreatedDt.AutoSize = True
        Me.lblCreatedDt.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblCreatedDt.Location = New System.Drawing.Point(332, 53)
        Me.lblCreatedDt.Name = "lblCreatedDt"
        Me.lblCreatedDt.Size = New System.Drawing.Size(47, 14)
        Me.lblCreatedDt.TabIndex = 4
        Me.lblCreatedDt.Text = "Fr Date"
        '
        'txtClosedDt
        '
        Me.txtClosedDt.Location = New System.Drawing.Point(382, 50)
        Me.txtClosedDt.Name = "txtClosedDt"
        Me.txtClosedDt.ReadOnly = True
        Me.txtClosedDt.Size = New System.Drawing.Size(75, 20)
        Me.txtClosedDt.TabIndex = 5
        '
        'lblFromDt
        '
        Me.lblFromDt.AutoSize = True
        Me.lblFromDt.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblFromDt.Location = New System.Drawing.Point(7, 90)
        Me.lblFromDt.Name = "lblFromDt"
        Me.lblFromDt.Size = New System.Drawing.Size(124, 14)
        Me.lblFromDt.TabIndex = 6
        Me.lblFromDt.Text = "Closing Account Date"
        '
        'txtFromDt
        '
        Me.txtFromDt.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtFromDt.Location = New System.Drawing.Point(135, 87)
        Me.txtFromDt.Name = "txtFromDt"
        Me.txtFromDt.ReadOnly = True
        Me.txtFromDt.Size = New System.Drawing.Size(75, 22)
        Me.txtFromDt.TabIndex = 7
        '
        'lblClosedDt
        '
        Me.lblClosedDt.AutoSize = True
        Me.lblClosedDt.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblClosedDt.Location = New System.Drawing.Point(327, 90)
        Me.lblClosedDt.Name = "lblClosedDt"
        Me.lblClosedDt.Size = New System.Drawing.Size(52, 14)
        Me.lblClosedDt.TabIndex = 8
        Me.lblClosedDt.Text = "To Date"
        '
        'txtToDt
        '
        Me.txtToDt.Location = New System.Drawing.Point(382, 87)
        Me.txtToDt.Name = "txtToDt"
        Me.txtToDt.ReadOnly = True
        Me.txtToDt.Size = New System.Drawing.Size(75, 20)
        Me.txtToDt.TabIndex = 9
        '
        'lblPeriodNo
        '
        Me.lblPeriodNo.AutoSize = True
        Me.lblPeriodNo.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblPeriodNo.Location = New System.Drawing.Point(23, 128)
        Me.lblPeriodNo.Name = "lblPeriodNo"
        Me.lblPeriodNo.Size = New System.Drawing.Size(109, 14)
        Me.lblPeriodNo.TabIndex = 10
        Me.lblPeriodNo.Text = "Current Period No."
        '
        'txtPeriodNo
        '
        Me.txtPeriodNo.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtPeriodNo.Location = New System.Drawing.Point(135, 125)
        Me.txtPeriodNo.Name = "txtPeriodNo"
        Me.txtPeriodNo.ReadOnly = True
        Me.txtPeriodNo.Size = New System.Drawing.Size(75, 22)
        Me.txtPeriodNo.TabIndex = 11
        Me.txtPeriodNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblRemark
        '
        Me.lblRemark.AutoSize = True
        Me.lblRemark.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblRemark.Location = New System.Drawing.Point(84, 166)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(47, 14)
        Me.lblRemark.TabIndex = 12
        Me.lblRemark.Text = "Remark"
        '
        'txtRemark
        '
        Me.txtRemark.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtRemark.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtRemark.Location = New System.Drawing.Point(135, 163)
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(322, 22)
        Me.txtRemark.TabIndex = 13
        '
        'btnClosedAcc
        '
        Me.btnClosedAcc.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnClosedAcc.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnClosedAcc.Location = New System.Drawing.Point(89, 210)
        Me.btnClosedAcc.Name = "btnClosedAcc"
        '
        '
        '
        Me.btnClosedAcc.RootElement.ControlBounds = New System.Drawing.Rectangle(89, 201, 110, 24)
        Me.btnClosedAcc.Size = New System.Drawing.Size(131, 25)
        Me.btnClosedAcc.TabIndex = 14
        Me.btnClosedAcc.Text = "Closing &Account"
        '
        'BtnCancel
        '
        Me.BtnCancel.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnCancel.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.BtnCancel.Location = New System.Drawing.Point(226, 210)
        Me.BtnCancel.Name = "BtnCancel"
        '
        '
        '
        Me.BtnCancel.RootElement.ControlBounds = New System.Drawing.Rectangle(226, 201, 110, 24)
        Me.BtnCancel.Size = New System.Drawing.Size(70, 25)
        Me.BtnCancel.TabIndex = 15
        Me.BtnCancel.Text = "&Cancel"
        '
        'BtnExit
        '
        Me.BtnExit.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnExit.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.BtnExit.Location = New System.Drawing.Point(302, 210)
        Me.BtnExit.Name = "BtnExit"
        '
        '
        '
        Me.BtnExit.RootElement.ControlBounds = New System.Drawing.Rectangle(302, 201, 110, 24)
        Me.BtnExit.Size = New System.Drawing.Size(80, 25)
        Me.BtnExit.TabIndex = 16
        Me.BtnExit.Text = "E&xit"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "Open Text Files"
        '
        'frmFaAccountClosing
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(488, 243)
        Me.Controls.Add(Me.BtnExit)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.btnClosedAcc)
        Me.Controls.Add(Me.txtRemark)
        Me.Controls.Add(Me.lblRemark)
        Me.Controls.Add(Me.txtPeriodNo)
        Me.Controls.Add(Me.lblPeriodNo)
        Me.Controls.Add(Me.txtToDt)
        Me.Controls.Add(Me.lblClosedDt)
        Me.Controls.Add(Me.txtFromDt)
        Me.Controls.Add(Me.lblFromDt)
        Me.Controls.Add(Me.txtClosedDt)
        Me.Controls.Add(Me.lblCreatedDt)
        Me.Controls.Add(Me.txtClosedBy)
        Me.Controls.Add(Me.lblPClosedBy)
        Me.Controls.Add(Me.lblFancy)
        Me.MaximizeBox = False
        Me.Name = "frmFaAccountClosing"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fancy Account Closing"
        CType(Me.btnClosedAcc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnExit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblFancy As Label
    Friend WithEvents lblPClosedBy As Label
    Friend WithEvents txtClosedBy As TextBox
    Friend WithEvents lblCreatedDt As Label
    Friend WithEvents txtClosedDt As TextBox
    Friend WithEvents lblFromDt As Label
    Friend WithEvents txtFromDt As TextBox
    Friend WithEvents lblClosedDt As Label
    Friend WithEvents txtToDt As TextBox
    Friend WithEvents lblPeriodNo As Label
    Friend WithEvents txtPeriodNo As TextBox
    Friend WithEvents lblRemark As Label
    Friend WithEvents txtRemark As TextBox
    Private WithEvents btnClosedAcc As Telerik.WinControls.UI.RadButton
    Private WithEvents BtnCancel As Telerik.WinControls.UI.RadButton
    Private WithEvents BtnExit As Telerik.WinControls.UI.RadButton
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
End Class
