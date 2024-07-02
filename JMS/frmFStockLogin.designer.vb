<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFStockLogin
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
        Me.lableHeading = New Telerik.WinControls.UI.RadLabel()
        Me.BtnStockUName = New Telerik.WinControls.UI.RadLabel()
        Me.BtnStockPass = New Telerik.WinControls.UI.RadLabel()
        Me.txtUsername = New Telerik.WinControls.UI.RadTextBox()
        Me.txtPassword = New Telerik.WinControls.UI.RadTextBox()
        Me.BtnStockLogin = New Telerik.WinControls.UI.RadButton()
        Me.BtnCancel = New Telerik.WinControls.UI.RadButton()
        CType(Me.lableHeading, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnStockUName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnStockPass, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUsername, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPassword, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnStockLogin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lableHeading
        '
        Me.lableHeading.Font = New System.Drawing.Font("Segoe UI", 9.25!, System.Drawing.FontStyle.Bold)
        Me.lableHeading.Location = New System.Drawing.Point(1, 12)
        Me.lableHeading.Name = "lableHeading"
        Me.lableHeading.Size = New System.Drawing.Size(285, 20)
        Me.lableHeading.TabIndex = 0
        Me.lableHeading.Text = "Please Enter User Name And Pass To Get Stock"
        '
        'BtnStockUName
        '
        Me.BtnStockUName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnStockUName.Location = New System.Drawing.Point(26, 51)
        Me.BtnStockUName.Name = "BtnStockUName"
        Me.BtnStockUName.Size = New System.Drawing.Size(72, 16)
        Me.BtnStockUName.TabIndex = 1
        Me.BtnStockUName.Text = "User Name :"
        '
        'BtnStockPass
        '
        Me.BtnStockPass.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnStockPass.Location = New System.Drawing.Point(26, 94)
        Me.BtnStockPass.Name = "BtnStockPass"
        Me.BtnStockPass.Size = New System.Drawing.Size(67, 16)
        Me.BtnStockPass.TabIndex = 2
        Me.BtnStockPass.Text = "Password :"
        '
        'txtUsername
        '
        Me.txtUsername.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtUsername.Location = New System.Drawing.Point(104, 51)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(150, 20)
        Me.txtUsername.TabIndex = 3
        '
        'txtPassword
        '
        Me.txtPassword.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtPassword.Location = New System.Drawing.Point(104, 94)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(150, 20)
        Me.txtPassword.TabIndex = 4
        '
        'BtnStockLogin
        '
        Me.BtnStockLogin.Location = New System.Drawing.Point(53, 134)
        Me.BtnStockLogin.Name = "BtnStockLogin"
        Me.BtnStockLogin.Size = New System.Drawing.Size(75, 25)
        Me.BtnStockLogin.TabIndex = 5
        Me.BtnStockLogin.Text = "&Login"
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(134, 134)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 25)
        Me.BtnCancel.TabIndex = 6
        Me.BtnCancel.Text = "&Cancel"
        '
        'frmStockLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(278, 214)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnStockLogin)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.BtnStockPass)
        Me.Controls.Add(Me.BtnStockUName)
        Me.Controls.Add(Me.lableHeading)
        Me.Name = "frmStockLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "StockLogin"
        CType(Me.lableHeading, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnStockUName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnStockPass, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUsername, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPassword, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnStockLogin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnCancel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lableHeading As Telerik.WinControls.UI.RadLabel
    Friend WithEvents BtnStockUName As Telerik.WinControls.UI.RadLabel
    Friend WithEvents BtnStockPass As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtUsername As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtPassword As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents BtnStockLogin As Telerik.WinControls.UI.RadButton
    Friend WithEvents BtnCancel As Telerik.WinControls.UI.RadButton
End Class
