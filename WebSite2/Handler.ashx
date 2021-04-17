<%@ WebHandler Language="VB" Class="Handler" %>

Imports System
Imports System.Web
Imports System.Data.SqlClient
Public Class Handler : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        context.Response.ContentType = "text/plain"
        context.Response.Write("Hello World")
        Dim imageid As String = context.Request.QueryString("ImID")
        Dim con As New SqlConnection("Data Source=.\sqlexpress;Integrated Security=true;Initial Catalog=vgDB")
        con.Open()
        Dim cmd As New SqlCommand(Convert.ToString("select pimg from pimages where pid=") & imageid, con)
        Dim dr As SqlDataReader = cmd.ExecuteReader()
        dr.Read()
        context.Response.BinaryWrite(DirectCast(dr(0), Byte()))
        con.Close()
        context.Response.[End]()
    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class