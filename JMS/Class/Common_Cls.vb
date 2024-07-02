
Imports System.Windows.Forms
Imports System.Management
Public Class Common_Cls

#Region "Declarations"


    'Declarations for Project variables
    Public Shared mProduct_Name As String
    Public Shared mTran_Date As Date
    Public Shared mSystem_Name As String

    'Declaration for Resource Value

    Public Shared mFile_Path As String

    'Common Datatable
    Public Shared mComm_Dtbl As DataTable
    Public Shared mComm_DSet As DataSet

    'Declaration for Company Profile Deatils
    Public Shared mCompany_Name As String
    Public Shared mCompany_Addr As String
    Public Shared mCompany_Phone1 As String
    Public Shared mCompany_Phone2 As String
    Public Shared mCompany_Fax As String
    Public Shared mCompany_Email As String
    Public Shared mCompany_Website As String

    'Declaration for User Details 
    Public Shared mUser_ID As String
    Public Shared mUser_Name As String
    Public Shared mUser_Designation As String
    Public Shared mUser_Password As String
    Public Shared mUser_Custname As String
    Public Shared mUser_CustAddr As String
    Public Shared mUser_ValidUpto As Date
    Public Shared mUser_Active As Boolean
    Public Shared mUser_Passing As Boolean
    Public Shared mUser_LastModified As Date

#End Region

#Region "Properties"
    Public Shared Property Product_Name() As String
        Get
            If Len(mProduct_Name) = 0 Then mProduct_Name = "Jewellery Management System"
            Return mProduct_Name
        End Get
        Set(ByVal value As String)
            mProduct_Name = value
        End Set
    End Property
    Public Shared Property Tran_Date() As Date
        Get
            If mTran_Date = Nothing Then mTran_Date = Now.Date
            Return mTran_Date
        End Get
        Set(ByVal value As Date)
            mTran_Date = value
        End Set
    End Property
    Public Shared Property System_Name() As String
        Get
            Return mSystem_Name
        End Get
        Set(ByVal value As String)
            mSystem_Name = value
        End Set
    End Property
    Public Shared Property File_Path() As String
        Get
            Return mFile_Path
        End Get
        Set(ByVal value As String)
            mFile_Path = value
        End Set
    End Property

#Region "Properties For Users"
    Public Shared Property User_Custname() As String
        Get
            Return mUser_Custname
        End Get
        Set(ByVal value As String)
            mUser_Custname = value
        End Set
    End Property
    Public Shared Property User_CustAddr() As String
        Get
            Return mUser_CustAddr
        End Get
        Set(ByVal value As String)
            mUser_CustAddr = value
        End Set
    End Property
    Public Shared Property User_ValidUpto() As Date
        Get
            Return mUser_ValidUpto
        End Get
        Set(ByVal value As Date)
            mUser_ValidUpto = value
        End Set
    End Property
    Public Shared Property User_Active() As Boolean
        Get
            Return mUser_Active
        End Get
        Set(ByVal value As Boolean)
            mUser_Active = value
        End Set
    End Property
    Public Shared Property User_Passing() As Boolean
        Get
            Return mUser_Passing
        End Get
        Set(ByVal value As Boolean)
            mUser_Passing = value
        End Set
    End Property
    Public Shared Property User_LastModified() As Date
        Get
            Return mUser_LastModified
        End Get
        Set(ByVal value As Date)
            mUser_LastModified = value
        End Set
    End Property
    Public Shared Property User_ID() As String
        Get
            Return mUser_ID
        End Get
        Set(ByVal value As String)
            mUser_ID = value
        End Set
    End Property
    Public Shared Property User_Name() As String
        Get
            Return mUser_Name
        End Get
        Set(ByVal value As String)
            mUser_Name = value
        End Set
    End Property
    Public Shared Property User_Designation() As String
        Get
            Return mUser_Designation
        End Get
        Set(ByVal value As String)
            mUser_Designation = value
        End Set
    End Property

    Public Shared Property User_Password() As String
        Get
            Return mUser_Password
        End Get
        Set(ByVal value As String)
            mUser_Password = value
        End Set
    End Property

    Private Shared mUEmp_ID As Integer = 1

    Public Shared Property UEmp_ID() As Integer
        Get
            Return mUEmp_ID
        End Get
        Set(ByVal value As Integer)
            mUEmp_ID = value
        End Set
    End Property

#End Region

#Region "Properties For Company Profile "

    Public Shared Property Company_Name() As String
        Get
            If Len(mCompany_Name) = 0 Then mCompany_Name = "Pulsar"
            Return mCompany_Name
        End Get
        Set(ByVal value As String)
            mCompany_Name = value
        End Set
    End Property

    Public Shared Property Company_Addr() As String
        Get
            Return mCompany_Addr
        End Get
        Set(ByVal value As String)
            mCompany_Addr = value
        End Set
    End Property
    Public Shared Property Company_Phone1() As String
        Get
            Return mCompany_Phone1
        End Get
        Set(ByVal value As String)
            mCompany_Phone1 = value
        End Set
    End Property
    Public Shared Property Company_Phone2() As String
        Get
            Return mCompany_Phone2
        End Get
        Set(ByVal value As String)
            mCompany_Phone2 = value
        End Set
    End Property
    Public Shared Property Company_Fax() As String
        Get
            Return mCompany_Fax
        End Get
        Set(ByVal value As String)
            mCompany_Fax = value
        End Set
    End Property

    Public Shared Property Company_Email() As String
        Get
            Return mCompany_Email
        End Get
        Set(ByVal value As String)
            mCompany_Email = value
        End Set
    End Property

    Public Shared Property Company_Website() As String
        Get
            Return mCompany_Website
        End Get
        Set(ByVal value As String)
            mCompany_Website = value
        End Set
    End Property
#End Region

#Region "Properties For Common variables "

    Public Shared Property Comm_Dtbl() As DataTable
        Get
            Return mComm_Dtbl
        End Get
        Set(ByVal value As DataTable)
            mComm_Dtbl = value
        End Set
    End Property

    Public Shared Property Comm_Dset() As DataSet
        Get
            Return mComm_DSet
        End Get
        Set(ByVal value As DataSet)
            mComm_DSet = value
        End Set
    End Property

    Public Shared mIs_SSnumberneeded As Boolean = True
    Public Shared Property Is_SSnumberneeded() As Boolean
        Get
            Return mIs_SSnumberneeded
        End Get
        Set(ByVal value As Boolean)
            mIs_SSnumberneeded = value
        End Set
    End Property

#End Region

#End Region

#Region "Methods"

    'Get Resource Value
#End Region
End Class
