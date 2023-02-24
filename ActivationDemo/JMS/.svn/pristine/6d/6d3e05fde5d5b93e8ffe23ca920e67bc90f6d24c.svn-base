Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
Imports System.Windows.Forms
Public Class ClsDbConnection
    ''Public Shared con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("MyConnection").ConnectionString)

    Public Shared ReadOnly Property ConnectionString As String
        Get
            Return ConfigurationManager.ConnectionStrings("ConString").ConnectionString
        End Get
    End Property
End Class



