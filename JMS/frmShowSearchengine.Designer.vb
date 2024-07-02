<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmShowSearchengine
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
        Me.Pnl_Header = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Lbl_Searchon = New System.Windows.Forms.Label()
        Me.Lbl_Searchwith = New System.Windows.Forms.Label()
        Me.Lbl_Searchstatus = New System.Windows.Forms.Label()
        Me.Dgrd_Search = New System.Windows.Forms.DataGridView()
        Me.Pnl_Header.SuspendLayout()
        CType(Me.Dgrd_Search, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pnl_Header
        '
        Me.Pnl_Header.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.Pnl_Header.Controls.Add(Me.Label1)
        Me.Pnl_Header.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pnl_Header.Location = New System.Drawing.Point(0, 0)
        Me.Pnl_Header.Name = "Pnl_Header"
        Me.Pnl_Header.Size = New System.Drawing.Size(674, 22)
        Me.Pnl_Header.TabIndex = 23
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(270, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Search Engine"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label2.Location = New System.Drawing.Point(1, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 24)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Search by :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Lbl_Searchon
        '
        Me.Lbl_Searchon.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Lbl_Searchon.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Searchon.ForeColor = System.Drawing.Color.Maroon
        Me.Lbl_Searchon.Location = New System.Drawing.Point(78, 24)
        Me.Lbl_Searchon.Name = "Lbl_Searchon"
        Me.Lbl_Searchon.Size = New System.Drawing.Size(114, 24)
        Me.Lbl_Searchon.TabIndex = 25
        Me.Lbl_Searchon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Lbl_Searchwith
        '
        Me.Lbl_Searchwith.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.Lbl_Searchwith.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Searchwith.ForeColor = System.Drawing.Color.Maroon
        Me.Lbl_Searchwith.Location = New System.Drawing.Point(194, 24)
        Me.Lbl_Searchwith.Name = "Lbl_Searchwith"
        Me.Lbl_Searchwith.Size = New System.Drawing.Size(479, 24)
        Me.Lbl_Searchwith.TabIndex = 26
        Me.Lbl_Searchwith.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lbl_Searchstatus
        '
        Me.Lbl_Searchstatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.Lbl_Searchstatus.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Lbl_Searchstatus.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Searchstatus.ForeColor = System.Drawing.Color.White
        Me.Lbl_Searchstatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Lbl_Searchstatus.Location = New System.Drawing.Point(0, 294)
        Me.Lbl_Searchstatus.Name = "Lbl_Searchstatus"
        Me.Lbl_Searchstatus.Size = New System.Drawing.Size(674, 22)
        Me.Lbl_Searchstatus.TabIndex = 28
        '
        'Dgrd_Search
        '
        Me.Dgrd_Search.AllowUserToAddRows = False
        Me.Dgrd_Search.AllowUserToDeleteRows = False
        Me.Dgrd_Search.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgrd_Search.Location = New System.Drawing.Point(1, 52)
        Me.Dgrd_Search.Name = "Dgrd_Search"
        Me.Dgrd_Search.ReadOnly = True
        Me.Dgrd_Search.Size = New System.Drawing.Size(674, 240)
        Me.Dgrd_Search.TabIndex = 29
        '
        'frmShowSearchengine
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(674, 316)
        Me.Controls.Add(Me.Dgrd_Search)
        Me.Controls.Add(Me.Lbl_Searchstatus)
        Me.Controls.Add(Me.Lbl_Searchwith)
        Me.Controls.Add(Me.Lbl_Searchon)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Pnl_Header)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmShowSearchengine"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Pnl_Header.ResumeLayout(False)
        Me.Pnl_Header.PerformLayout()
        CType(Me.Dgrd_Search, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Pnl_Header As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Lbl_Searchon As Label
    Friend WithEvents Lbl_Searchwith As Label
    Friend WithEvents Lbl_Searchstatus As Label
    Friend WithEvents Dgrd_Search As DataGridView
End Class
