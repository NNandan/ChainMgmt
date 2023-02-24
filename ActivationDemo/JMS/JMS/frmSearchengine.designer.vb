<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearchengine
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Pnl_Header = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Lbl_Searchwith = New System.Windows.Forms.Label
        Me.Lbl_Searchon = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Dgrd_Search = New System.Windows.Forms.DataGridView
        Me.Lbl_Searchstatus = New System.Windows.Forms.Label
        Me.Pnl_Header.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.Dgrd_Search, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Lbl_Searchwith)
        Me.Panel1.Controls.Add(Me.Lbl_Searchon)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 22)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(672, 25)
        Me.Panel1.TabIndex = 23
        '
        'Lbl_Searchwith
        '
        Me.Lbl_Searchwith.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.Lbl_Searchwith.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Searchwith.ForeColor = System.Drawing.Color.Maroon
        Me.Lbl_Searchwith.Location = New System.Drawing.Point(193, 1)
        Me.Lbl_Searchwith.Name = "Lbl_Searchwith"
        Me.Lbl_Searchwith.Size = New System.Drawing.Size(479, 24)
        Me.Lbl_Searchwith.TabIndex = 2
        Me.Lbl_Searchwith.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lbl_Searchon
        '
        Me.Lbl_Searchon.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Lbl_Searchon.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Searchon.ForeColor = System.Drawing.Color.Maroon
        Me.Lbl_Searchon.Location = New System.Drawing.Point(79, 1)
        Me.Lbl_Searchon.Name = "Lbl_Searchon"
        Me.Lbl_Searchon.Size = New System.Drawing.Size(114, 24)
        Me.Lbl_Searchon.TabIndex = 1
        Me.Lbl_Searchon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label2.Location = New System.Drawing.Point(1, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 24)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Search by :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Dgrd_Search
        '
        Me.Dgrd_Search.AllowUserToAddRows = False
        Me.Dgrd_Search.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Maroon
        Me.Dgrd_Search.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgrd_Search.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Dgrd_Search.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(230, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgrd_Search.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Dgrd_Search.ColumnHeadersHeight = 20
        Me.Dgrd_Search.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgrd_Search.Location = New System.Drawing.Point(0, 47)
        Me.Dgrd_Search.MultiSelect = False
        Me.Dgrd_Search.Name = "Dgrd_Search"
        Me.Dgrd_Search.ReadOnly = True
        Me.Dgrd_Search.RowHeadersVisible = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Maroon
        Me.Dgrd_Search.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.Dgrd_Search.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Dgrd_Search.Size = New System.Drawing.Size(672, 246)
        Me.Dgrd_Search.TabIndex = 24
        '
        'Lbl_Searchstatus
        '
        Me.Lbl_Searchstatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.Lbl_Searchstatus.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Lbl_Searchstatus.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Searchstatus.ForeColor = System.Drawing.Color.White
        Me.Lbl_Searchstatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Lbl_Searchstatus.Location = New System.Drawing.Point(0, 293)
        Me.Lbl_Searchstatus.Name = "Lbl_Searchstatus"
        Me.Lbl_Searchstatus.Size = New System.Drawing.Size(672, 22)
        Me.Lbl_Searchstatus.TabIndex = 25
        '
        'Searchengine_Frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(672, 315)
        Me.Controls.Add(Me.Dgrd_Search)
        Me.Controls.Add(Me.Lbl_Searchstatus)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Pnl_Header)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Searchengine_Frm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Pnl_Header.ResumeLayout(False)
        Me.Pnl_Header.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.Dgrd_Search, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Header As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Lbl_Searchwith As System.Windows.Forms.Label
    Friend WithEvents Lbl_Searchon As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Dgrd_Search As System.Windows.Forms.DataGridView
    Friend WithEvents Lbl_Searchstatus As System.Windows.Forms.Label
End Class
