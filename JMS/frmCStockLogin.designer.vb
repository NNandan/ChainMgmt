<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCStockLogin
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
        Me.BtnCancel = New Telerik.WinControls.UI.RadButton()
        Me.BtnStockLogin = New Telerik.WinControls.UI.RadButton()
        Me.txtPassword = New Telerik.WinControls.UI.RadTextBox()
        Me.txtUsername = New Telerik.WinControls.UI.RadTextBox()
        Me.BtnStockPass = New Telerik.WinControls.UI.RadLabel()
        Me.BtnStockUName = New Telerik.WinControls.UI.RadLabel()
        Me.lableHeading = New Telerik.WinControls.UI.RadLabel()
        CType(Me.BtnCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnStockLogin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPassword, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUsername, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnStockPass, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnStockUName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lableHeading, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(133, 179)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 25)
        Me.BtnCancel.TabIndex = 13
        Me.BtnCancel.Text = "&Cancel"
        '
        'BtnStockLogin
        '
        Me.BtnStockLogin.Location = New System.Drawing.Point(52, 179)
        Me.BtnStockLogin.Name = "BtnStockLogin"
        Me.BtnStockLogin.Size = New System.Drawing.Size(75, 25)
        Me.BtnStockLogin.TabIndex = 12
        Me.BtnStockLogin.Text = "&Login"
        '
        'txtPassword
        '
        Me.txtPassword.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtPassword.Location = New System.Drawing.Point(103, 139)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(150, 20)
        Me.txtPassword.TabIndex = 11
        '
        'txtUsername
        '
        Me.txtUsername.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtUsername.Location = New System.Drawing.Point(103, 96)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(150, 20)
        Me.txtUsername.TabIndex = 10
        '
        'BtnStockPass
        '
        Me.BtnStockPass.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnStockPass.Location = New System.Drawing.Point(25, 139)
        Me.BtnStockPass.Name = "BtnStockPass"
        Me.BtnStockPass.Size = New System.Drawing.Size(67, 16)
        Me.BtnStockPass.TabIndex = 9
        Me.BtnStockPass.Text = "Password :"
        '
        'BtnStockUName
        '
        Me.BtnStockUName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnStockUName.Location = New System.Drawing.Point(25, 96)
        Me.BtnStockUName.Name = "BtnStockUName"
        Me.BtnStockUName.Size = New System.Drawing.Size(72, 16)
        Me.BtnStockUName.TabIndex = 8
        Me.BtnStockUName.Text = "User Name :"
        '
        'lableHeading
        '
        Me.lableHeading.Font = New System.Drawing.Font("Segoe UI", 9.25!, System.Drawing.FontStyle.Bold)
        Me.lableHeading.Location = New System.Drawing.Point(0, 57)
        Me.lableHeading.Name = "lableHeading"
        Me.lableHeading.Size = New System.Drawing.Size(285, 20)
        Me.lableHeading.TabIndex = 7
        Me.lableHeading.Text = "Please Enter User Name And Pass To Get Stock"
        '
        'frmCStockLogin
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnStockLogin)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.BtnStockPass)
        Me.Controls.Add(Me.BtnStockUName)
        Me.Controls.Add(Me.lableHeading)
        Me.MaximizeBox = False
        Me.Name = "frmCStockLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmCStockLogin"
        CType(Me.BtnCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnStockLogin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPassword, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUsername, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnStockPass, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnStockUName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lableHeading, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnCancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents BtnStockLogin As Telerik.WinControls.UI.RadButton
    Friend WithEvents txtPassword As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtUsername As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents BtnStockPass As Telerik.WinControls.UI.RadLabel
    Friend WithEvents BtnStockUName As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lableHeading As Telerik.WinControls.UI.RadLabel
End Class
