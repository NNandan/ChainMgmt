Imports DataAccessHandler
Imports System.Data.SqlClient

Public Class frmShowSearchengine

#Region " D e c l a r a t i o n s "

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

    Dim dbManager As New SqlHelper()
    Dim Objcn As SqlConnection = New SqlConnection()

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
    Private Sub Populate_Grid(ByVal Comand_text As String)
        Try

            If Comand_text.Trim = "" Then Exit Sub

            'Executing and Get data
            Dim Sr_Dtbl As DataTable = Nothing
            Sr_Dtbl = fetchAllRecords(Comand_text)

            If Sr_Dtbl.Rows.Count > 0 Then
                With Dgrd_Search
                    .DataSource = Nothing
                    .DataSource = Sr_Dtbl
                    .Refresh()
                    Call SetGrid_Colwidth()
                End With
            End If

            Lbl_Searchstatus.Text = (Dgrd_Search.Rows.Count).ToString & " - Results found"

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                            .Columns(i_Ctr).Width = CInt(mCol_Width(i_Ctr).ToString.Trim)
                        End If
                    Next
                End With
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Function Query_Builder() As String
        Try
            Dim Rtn_Qry As String = mReq_Qry

            mDef_Topselquery = "Select Top " & IIf(mDef_Rowsdiplayed = 0, "100", mDef_Rowsdiplayed.ToString)

            If Not mSearch_Hapnd Then
                Rtn_Qry = Replace(UCase(Rtn_Qry), "SELECT ", mDef_Topselquery)
                mSearch_Hapnd = True
            Else
                Rtn_Qry = Replace(UCase(Rtn_Qry), mDef_Topselquery, "SELECT ")
            End If

            If mFilterfield.Trim <> "" Then
                If InStr(1, mFilterfield, "[") = 0 Then
                    mFilterfield = "[" & mFilterfield & "]"
                End If

                If InStr(1, UCase(Rtn_Qry), "WHERE") > 1 Then
                    Rtn_Qry = Rtn_Qry & " and " & mFilterfield & " like '" & Trim(mFilterwith) & "%'"
                Else
                    Rtn_Qry = Rtn_Qry & " where " & mFilterfield & " like '" & Trim(mFilterwith) & "%'"
                End If
            End If

            If mReq_Orderbyfield.Trim <> "" Then
                If InStr(1, mReq_Orderbyfield, "[") = 0 Then
                    mReq_Orderbyfield = "[" & mReq_Orderbyfield & "]"
                End If

                Rtn_Qry = Rtn_Qry & " Order by " & mReq_Orderbyfield
            ElseIf mFilterfield.Trim <> "" Then
                If InStr(1, mFilterfield, "[") = 0 Then
                    mFilterfield = "[" & mFilterfield & "]"
                End If
                Rtn_Qry = Rtn_Qry & " Order by " & mFilterfield
            End If

            Lbl_Searchon.Text = mFilterfield.Trim.ToUpper
            If Lbl_Searchwith.Text.Trim = "" Then Lbl_Searchon.Text = ""

            If Rtn_Qry Is Nothing Then Rtn_Qry = ""
            Return Rtn_Qry

        Catch ex As Exception
            Return ""
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function fetchAllRecords(ByVal strSQl As String) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))
            End With

            dtData = dbManager.GetDataTable(strSQl, CommandType.Text, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub Dgrd_Search_Click(sender As Object, e As EventArgs)
        'Call Select_Filterfield()
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
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'Search 
    Public Sub Search()
        Try
            Call Populate_Grid(Query_Builder)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Dgrd_Search_DoubleClick(sender As Object, e As EventArgs) Handles Dgrd_Search.DoubleClick

    End Sub
End Class