'Date           : 21-06-2010
'Purpose        : Managing Lock and Unlock software for user
Option Explicit On

Public Class Lock_Frm

    Private Sub Txt_Pwd_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Pwd.Enter
        Txt_Pwd.Text = ""
        Txt_Pwd.Font = New Font("Wingdings", 9.7, FontStyle.Bold)


        Txt_Pwd.PasswordChar = "l"
        Txt_Pwd.ForeColor = Color.Black
    End Sub

    Private Sub Txt_Pwd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_Pwd.KeyDown
        If e.KeyCode = Keys.Enter Then Btn_Unlock_Click(sender, e)
    End Sub

    Private Sub Txt_Pwd_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Pwd.Leave
        If Txt_Pwd.Text.Trim = "" Then
            Txt_Pwd.PasswordChar = ""
            Txt_Pwd.Font = New Font("Tahoma", 9.7, FontStyle.Bold)
            Txt_Pwd.ForeColor = Color.Silver
            Txt_Pwd.Text = "Password"
        End If
    End Sub

    Private Sub Btn_Unlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Unlock.Click
        'Try
        '    If Txt_Pwd.Text.Trim = "" Then MessageBox.Show("Incorrect Password,Please Check", Product_Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Txt_Pwd.Focus() : Exit Sub

        '    If Txt_Pwd.Text.Trim <> User_Password Then MessageBox.Show("Incorrect Password,Please Check", Product_Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Txt_Pwd.Focus() : Exit Sub

        '    Me.Close()

        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub Lock_Frm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Call SendKeyTab()
    End Sub

    Private Sub Lock_Frm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Call Load_Values(User_ID)
            Call SendKeyTab()

        Catch ex As Exception

        End Try
    End Sub

    'Loading Prelimanary Data
    Private Sub Load_Values(ByVal Emp_ID As Integer)
        Try
            'Lbl_Lockusername.Text = User_Custname

            'Txt_Pwd.Text = ""

            'Dim Com_Bl As New HMS_BL.HMS_Common_BL_Cls

            'Call Com_Bl.Fill_CustPhoto(PBox_Lockuser, User_ID, Customer_Type.Employee, Image_Type.Photo1)
            'Com_Bl = Nothing

        Catch ex As Exception

        End Try
    End Sub

    
End Class