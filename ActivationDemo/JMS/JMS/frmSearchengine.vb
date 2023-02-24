'Developed by   : Nandan Navale
'Purpose        : Managing Search Activities

Imports JMS.Common_Cls
Imports System.Windows.Forms
Imports System.Configuration
Imports DataAccessHandler
Imports System.Data.SqlClient

Public Class frmSearchengine

    Dim dbManager As New SqlHelper(ConfigurationManager.ConnectionStrings("ConString").ToString())

#Region " D e c l a r a t i o n s "

    Private Com_BL As Common_Cls

    Private mReq_Qry As String = ""
    Private mReq_Ctrl As Object = Nothing
    Private mReq_Fieldno As Short = 0
    Private mDef_Filterfield As String = ""
    Private mDef_Rowsdiplayed As Short = 0
    Private mReq_Orderbyfield As String = ""
    Private mReq_Colwidth As String = ""

    Private mSearch_Hapnd As Boolean = False
    Private mFilterfield As String = ""
    Private mFilterwith As String = ""
    Private mReturnvalue As String = ""
    Private mDef_Topselquery As String = ""
    Private mCol_Width() As String

#End Region

#Region " P r o p e r t i e s "

    Public WriteOnly Property Req_Qry() As String
        Set(ByVal Value As String)
            mReq_Qry = Value
        End Set
    End Property

    Public WriteOnly Property Req_Ctrl() As Object
        Set(ByVal Value As Object)
            mReq_Ctrl = Value
        End Set
    End Property

    Public WriteOnly Property Req_Fieldno() As Short
        Set(ByVal value As Short)
            mReq_Fieldno = value
        End Set
    End Property

    Public WriteOnly Property Def_Rowsdiplayed() As Short
        Set(ByVal value As Short)
            mDef_Rowsdiplayed = value
        End Set
    End Property

    Public WriteOnly Property Req_Orderbyfield() As String
        Set(ByVal value As String)
            mReq_Orderbyfield = value
        End Set
    End Property

    Public WriteOnly Property Def_Filterfield() As String
        Set(ByVal value As String)
            mDef_Filterfield = value
        End Set
    End Property

    Public WriteOnly Property Req_Colwidth() As String
        Set(ByVal value As String)
            mReq_Colwidth = value
        End Set
    End Property

#End Region

#Region " M e t h o d s "

    'Private Function Query_Builder() As String
    '    Try
    '        Dim Rtn_Qry As String = mReq_Qry

    '        mDef_Topselquery = "Select Top " & IIf(mDef_Rowsdiplayed = 0, "100", mDef_Rowsdiplayed.ToString)

    '        If Not mSearch_Hapnd Then
    '            Rtn_Qry = Replace(UCase(Rtn_Qry), "SELECT ", mDef_Topselquery)
    '            mSearch_Hapnd = True
    '        Else
    '            Rtn_Qry = Replace(UCase(Rtn_Qry), mDef_Topselquery, "SELECT ")
    '        End If

    '        If mFilterfield.Trim <> "" Then
    '            If InStr(1, mFilterfield, "[") = 0 Then
    '                mFilterfield = "[" & mFilterfield & "]"
    '            End If

    '            If InStr(1, UCase(Rtn_Qry), "WHERE") > 1 Then
    '                Rtn_Qry = Rtn_Qry & " and " & mFilterfield & " like '" & Trim(mFilterwith) & "%'"
    '            Else
    '                Rtn_Qry = Rtn_Qry & " where " & mFilterfield & " like '" & Trim(mFilterwith) & "%'"
    '            End If
    '        End If

    '        If mReq_Orderbyfield.Trim <> "" Then
    '            If InStr(1, mReq_Orderbyfield, "[") = 0 Then
    '                mReq_Orderbyfield = "[" & mReq_Orderbyfield & "]"
    '            End If

    '            Rtn_Qry = Rtn_Qry & " Order by " & mReq_Orderbyfield
    '        ElseIf mFilterfield.Trim <> "" Then
    '            If InStr(1, mFilterfield, "[") = 0 Then
    '                mFilterfield = "[" & mFilterfield & "]"
    '            End If
    '            Rtn_Qry = Rtn_Qry & " Order by " & mFilterfield
    '        End If

    '        Lbl_Searchon.Text = mFilterfield.Trim.ToUpper
    '        If Lbl_Searchwith.Text.Trim = "" Then Lbl_Searchon.Text = ""

    '        If Rtn_Qry Is Nothing Then Rtn_Qry = ""
    '        Return Rtn_Qry

    '    Catch ex As Exception
    '        Return ""
    '        MessageBox.Show(ex.Message, Product_Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Function

    'Populating Grid 
    Private Sub Populate_Grid()
        Try
            Dim test As New Common_Cls
            ''If Comand_text.Trim = "" Then Exit Sub

            'Executing and Get data
            Com_BL = New Common_Cls
            Dim Sr_Dtbl As DataTable = Nothing

            ''If Com_BL.Get_Data(Comand_text, Sr_Dtbl) Then


            Sr_Dtbl = dbManager.GetDataTable("SP_AccountMaster_View", CommandType.StoredProcedure)

            With Dgrd_Search
                .DataSource = Nothing
                .DataSource = Sr_Dtbl
                .Refresh()
                Call SetGrid_Colwidth()
            End With
            ''End If

            Lbl_Searchstatus.Text = (Dgrd_Search.Rows.Count).ToString & " - Results found"

        Catch ex As Exception
            MessageBox.Show(ex.Message, Product_Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Search 
    Public Sub Search()
        Try
            Call Populate_Grid()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Product_Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

    Private Sub Searchengine_Frm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Product_Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Searchengine_Frm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Try

            If Asc(e.KeyChar) = 39 Then e.KeyChar = Chr(96)

        Catch ex As Exception
            MessageBox.Show(ex.Message, Product_Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Dgrd_Search_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgrd_Search.Click
        Call Select_Filterfield()
    End Sub

    Private Sub Dgrd_Search_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgrd_Search.DoubleClick
        Try
            With Dgrd_Search
                If .Rows.Count <= 0 Then Exit Sub
                If .CurrentRow Is Nothing Then Exit Sub
                Call Return_Withvalue(.CurrentCell.RowIndex)
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, Product_Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Dgrd_Search_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgrd_Search.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                With Dgrd_Search
                    If .Rows.Count <= 0 Then Exit Sub
                    If .CurrentRow Is Nothing Then Exit Sub
                    Call Return_Withvalue(.CurrentCell.RowIndex)
                End With
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Product_Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Dgrd_Search_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Dgrd_Search.KeyPress
        Try

            If Asc(e.KeyChar) = System.Windows.Forms.Keys.Back Then
                If Len(Lbl_Searchwith.Text) > 0 Then
                    Lbl_Searchwith.Text = Strings.Left(Lbl_Searchwith.Text, Len(Lbl_Searchwith.Text) - 1)
                End If
            ElseIf Asc(e.KeyChar) = System.Windows.Forms.Keys.Tab Then
                Lbl_Searchwith.Text = Lbl_Searchwith.Text.ToUpper
            ElseIf Asc(e.KeyChar) = System.Windows.Forms.Keys.Enter Then

            Else
                Lbl_Searchwith.Text = Lbl_Searchwith.Text & e.KeyChar
                Lbl_Searchwith.Text = Lbl_Searchwith.Text.ToUpper
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Product_Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Lbl_Searchwith_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lbl_Searchwith.TextChanged
        Try

            If mFilterfield.Trim = "" Then mFilterfield = mDef_Filterfield

            mFilterwith = Lbl_Searchwith.Text.Trim

            Call Me.Search()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Product_Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub Clear_Values()
        Try
            mReq_Qry = ""
            mReq_Ctrl = Nothing
            mReq_Fieldno = 0
            mDef_Filterfield = ""
            mDef_Rowsdiplayed = 0
            mReq_Orderbyfield = ""

            mSearch_Hapnd = False
            mFilterfield = ""
            mFilterwith = ""
            mReturnvalue = ""
            Lbl_Searchwith.Text = ""

        Catch ex As Exception
            MessageBox.Show(ex.Message, Product_Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Dgrd_Search_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgrd_Search.KeyUp
        Try
            If e.KeyCode = Keys.Down Or e.KeyCode = Keys.End Or e.KeyCode = Keys.Home Or e.KeyCode = Keys.Left Or e.KeyCode = Keys.Next Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Up Then
                Call Select_Filterfield()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Product_Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Select_Filterfield()
        Try
            With Dgrd_Search
                If .Rows.Count = 0 Then Exit Sub
                If .CurrentRow Is Nothing Then Exit Sub
                If mFilterfield <> .Columns.Item(.CurrentCell.ColumnIndex).DataPropertyName.ToString.Trim Then
                    mFilterfield = .Columns.Item(.CurrentCell.ColumnIndex).DataPropertyName.ToString.Trim
                End If
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, Product_Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Return_Withvalue(ByVal rowindex As Integer)
        Try
            With Dgrd_Search
                If .Rows.Count <= 0 Then Exit Sub
                If .CurrentRow Is Nothing Then Exit Sub
                mReturnvalue = .Item(mReq_Fieldno, rowindex).Value.ToString.Trim
            End With

            If TypeOf mReq_Ctrl Is TextBox Or TypeOf mReq_Ctrl Is ComboBox Then
                mReq_Ctrl.text = mReturnvalue

                If mReq_Ctrl.Visible Then mReq_Ctrl.focus()
                Me.Close()
                Exit Sub
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Product_Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SetGrid_Colwidth()
        Try
            mCol_Width = Split(mReq_Colwidth, "|")
            If mCol_Width.Length > 0 Then
                Dim i_Ctr As Short = 0
                With Dgrd_Search
                    For i_Ctr = 0 To mCol_Width.Length - 1
                        If .Columns.Count >= i_Ctr And mCol_Width(i_Ctr).ToString.Trim <> "" Then
                            .Columns(i_Ctr).MinimumWidth = CInt(mCol_Width(i_Ctr).ToString.Trim)
                        End If
                    Next
                End With
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Product_Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class