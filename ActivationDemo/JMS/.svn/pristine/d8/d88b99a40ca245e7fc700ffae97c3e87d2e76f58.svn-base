Imports System.Data.SqlClient

Module Functions
    Declare Function SetParent Lib "user32" (ByVal hWndChild As Integer, ByVal hWndNewParent As Integer) As Integer
    Declare Sub keybd_event Lib "user32" (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Long, ByVal dwExtraInfo As Long)

    Public Const LOCALE_SSHORTDATE = &H1F
    Public Declare Function GetSystemDefaultLCID Lib "kernel32" () As Long
    Public Declare Function SetLocaleInfo Lib "kernel32" Alias "SetLocaleInfoA" (ByVal Locale As Long, ByVal LCType As Long, ByVal lpLCData As String) As Boolean
    Public Enum FormState
        AStateMode = 0
        EStateMode = 1
        VStateMode = 2
    End Enum
    '---LOGIN---
    Public UserId As Integer                'Used for Userid while login
    Public UserName As String               'User for UserName while Login
    Public UserType As String               'User for USERTYPE while Login (SUPER, ADMIN, USER)
    Public KarigarName As String
    Public DeptId As Int16                  'User for

    '---VARIABLE---
    Public dtUserRights As DataTable          'USED FOR USER RIGHTS THROUGHOUT THE APPLICATION 

    '---SEARCH---
    Public StrSearchSql As String
    Public StrSearchField As String
    Public StrSearchField1 As String
    Public StrSearchField2 As String
    Public StrSearchReturn As String
    Public StrSearchWhere As String
    Public StrSearchRetTab As String
    Public StrGroup As String
    Public StrSearchTitle1 As String
    Public StrSearchTitle2 As String
    Public StrSearchTitle3 As String

    Public OpGrossWt As Double = 0
    Public OpGrossPr As Double = 0
    Public OpGrossFw As Double = 0


#Region "KEYPRESS"
    Sub numkeypress(ByVal han As KeyPressEventArgs, ByVal sen As Control, ByVal frm As System.Windows.Forms.Form)
        'If AscW(han.KeyChar) = 13 Then
        '    SendKeys.Send("{Tab}")
        '    han.KeyChar = ""
        'End If

        If AscW(han.KeyChar) >= 48 And AscW(han.KeyChar) <= 57 Or AscW(han.KeyChar) = 8 Then
            han.KeyChar = han.KeyChar
        Else
            han.KeyChar = ""
        End If

        If AscW(han.KeyChar) = Keys.Escape Then
            frm.Close()
        End If
    End Sub
    Sub numdot(ByVal han As KeyPressEventArgs, ByVal txt As System.Windows.Forms.TextBox, ByVal frm As System.Windows.Forms.Form)
        Dim mypos As Integer

        mypos = InStr(1, txt.Text, ".")

        'If AscW(han.KeyChar) = 13 Then
        '    SendKeys.Send("{Tab}")
        '    han.KeyChar = ""
        'End If

        If AscW(han.KeyChar) > 47 And AscW(han.KeyChar) < 58 Or AscW(han.KeyChar) = 8 Or AscW(han.KeyChar) = 46 Then
            han.KeyChar = han.KeyChar
        Else
            han.KeyChar = ""
        End If


        If AscW(han.KeyChar) > 47 And AscW(han.KeyChar) < 58 And mypos <> "0" Then
            If txt.SelectionStart = mypos + 2 Then
                han.KeyChar = ""
            End If
        End If

        If txt.SelectionStart >= mypos Then
            txt.SelectionLength = 1
            han.KeyChar = han.KeyChar
        End If

        If AscW(han.KeyChar) = 46 Then

            'test = True
            mypos = InStr(1, txt.Text, ".")
            If mypos <> "0" Then txt.SelectionStart = mypos
            If mypos = 0 Then
                han.KeyChar = han.KeyChar
            Else
                han.KeyChar = ""
            End If

        End If

        If AscW(han.KeyChar) = Keys.Escape Then
            frm.Close()
        End If
    End Sub
    Sub numdotkeypress(ByVal han As KeyPressEventArgs, ByVal sen As Object, ByVal frm As System.Windows.Forms.Form)
        Dim mypos As Integer

        'If AscW(han.KeyChar) = 13 Then
        '    SendKeys.Send("{Tab}")
        '    han.KeyChar = ""
        'End If
        If AscW(han.KeyChar) >= 48 And AscW(han.KeyChar) <= 57 Or AscW(han.KeyChar) = 8 Then
            han.KeyChar = han.KeyChar
        ElseIf AscW(han.KeyChar) = 46 Then
            mypos = InStr(1, sen.Text, ".")
            If mypos = 0 Then
                han.KeyChar = han.KeyChar
            Else
                han.KeyChar = ""
            End If
        Else
            han.KeyChar = ""
        End If

        If AscW(han.KeyChar) = Keys.Escape Then
            frm.Close()
        End If
    End Sub
    Sub enterkeypress(ByVal han As KeyPressEventArgs, ByVal frm As System.Windows.Forms.Form)
        If AscW(han.KeyChar) = 13 Then
            SendKeys.Send("{Tab}")
            han.KeyChar = ""
        End If
    End Sub
    Public Function OnlyAllowPostiveNumbers(sender As Object, e As System.Windows.Forms.KeyPressEventArgs, Optional ByRef iDeimalPlaces As Integer = 0) As System.Windows.Forms.KeyPressEventArgs
        'Only allow numeric values with the exception of spaces ie '07969 860053' and backspace
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        'Backspace
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 46) And InStr(sender.text, ".") < 1 Then
            e.Handled = False
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) > 48) And (Microsoft.VisualBasic.Asc(e.KeyChar) < 57) Then
            If InStr(sender.text, ".") > 0 Then
                Dim n As Integer = InStr(sender.text, ".")
                If n <= (sender.text.length - iDeimalPlaces) Then
                    e.Handled = True
                End If
            End If
        End If
        Return e
    End Function
    Public Function CheckDuplicate(ByVal strFieldName As String, ByRef dgv As DataGridView, ByVal strColName As String) As Boolean
        Dim blnChk As Boolean = False

        For Each row As DataGridViewRow In dgv.Rows
            ''For i As Integer = 0 To dgvBagList.Columns.Count - 1
            If row.Cells(strColName).Value.ToString.ToLower() = CStr(strFieldName.Trim().ToLower()) Then
                blnChk = True
                Exit For
            End If
            ''Next
        Next
        'If (blnChk) Then
        '    MessageBox.Show("Error .. Value already exist in DataGridView1")
        'End If
        Return blnChk
    End Function

#End Region

#Region "SAFE"
    Public Function sqlSafe(ByRef p_string As String) As String
        sqlSafe = Replace(Trim(p_string), "'", "''")
    End Function

#End Region
    Public Function ReplaceDBNull(ByVal pobjDBField As Object, Optional ByVal pstrReturnValue As String = "") As String
        If IsDBNull(pobjDBField) OrElse Trim(pobjDBField.ToString) = "" Then
            Return pstrReturnValue
        Else
            Return pobjDBField.ToString
        End If
    End Function
    Public Function ToProper(ByVal Str As String) As String

        ' Storage String For Output
        Dim OutStr As String = String.Empty

        ' Used For Holding Each Word Separated By A Space
        Dim Words() As String = Split(Str, " ")

        ' Loop Through All The Words In The String
        For A = 0 To Words.GetUpperBound(0)

            ' Retrieve The Word In The Words Array For Processing
            Dim TempWord As String = Words(A)

            ' Loop Through All The Characters In The String
            For B = 0 To TempWord.Length - 1

                If B = 0 Then
                    ' Make The First Character Uppercase
                    OutStr += Char.ToUpper(TempWord(B))
                Else
                    ' Make The Other Characters Lowercase
                    OutStr += Char.ToLower(TempWord(B))
                End If

                ' Add Spaces If Any Are Necessary
                If A <> Words.GetUpperBound(0) And B = TempWord.Length - 1 Then
                    OutStr += " "
                End If

            Next
        Next

        ' Return Formatted String
        Return OutStr

    End Function
    Public Function IsDoubleNaN(ByVal text As String) As Boolean
        If String.IsNullOrEmpty(text) Then
            Return False
        End If

        Dim num As Double = 0

        Dim isDouble As Boolean = Double.TryParse(text, num)

        Return True

    End Function
    Public Sub SendKeyTab(Optional ByRef KeyAscii As Integer = 0)
        Try

            If KeyAscii = Keys.Enter Then
                KeyAscii = 0 ' suppress the "beep"
                keybd_event(Keys.Tab, 0, 0, 0) ' press Tab key
                keybd_event(Keys.Tab, 0, 2, 0) ' release Tab key
                If KeyAscii = 39 Then KeyAscii = 96
            ElseIf KeyAscii = 0 Then
                keybd_event(Keys.Tab, 0, 0, 0) ' press Tab key
                keybd_event(Keys.Tab, 0, 2, 0) ' release Tab key
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Testing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Sub ShowSearchengine(ByRef Req_Ctrl As Object,
                                ByVal Req_Qry As String,
                                ByVal Req_Fieldno As Short,
                                ByVal Def_Filterfield As String,
                                Optional ByVal Req_Colwidth As String = "",
                                Optional ByVal Req_Orderbyfield As String = "",
                                Optional ByVal Def_Rowsdiplayed As Short = 0
                                )
        Try
            With frmSearchengine
                .Clear_Values()
                .Req_Ctrl = Req_Ctrl
                .Req_Qry = Req_Qry
                .Req_Fieldno = Req_Fieldno
                .Def_Filterfield = Def_Filterfield
                .Req_Colwidth = Req_Colwidth
                .Req_Orderbyfield = Req_Orderbyfield
                .Def_Rowsdiplayed = Def_Rowsdiplayed
                .Search()

                .ShowDialog()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Testing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub Show_ChildForm(ByVal Showform As String, ByRef Masterform As Form, ByVal Menuid As Int32, Optional ByVal TvwSelect As Boolean = False)
        Try
            If Showform.Trim = "" Then Exit Sub

            Dim objForm As Form
            Dim FullTypeName As String
            Dim FormInstanceType As Type
            ' Assume that form classes' namespace is the same as ProductName
            FullTypeName = "JMS" & "." & Showform.Trim
            ' Now, get the actual type
            FormInstanceType = Type.GetType(FullTypeName, True, True)
            ' Create an instance of this form type
            objForm = CType(Activator.CreateInstance(FormInstanceType), Form)

            AddHandler objForm.Load, AddressOf frmMain.Childfrm_Load

            'If Already open or Shown then Bring to Front
            For Each ChildForm As Form In Masterform.MdiChildren
                If ChildForm.Name = objForm.Name Then
                    ChildForm.BringToFront()
                    Exit Sub
                End If
            Next

            ' Show the form instance
            objForm.MdiParent = Masterform

            objForm.Tag = Menuid
            objForm.Show()
            objForm.BringToFront()
            objForm.Focus()

            'If TvwSelect Then
            '    Call SendKeyTab()
            '    Call SendKeyTab()
            'End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Module
