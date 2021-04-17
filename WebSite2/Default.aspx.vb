Imports System.Data.SqlClient
Partial Class _Default
    Inherits System.Web.UI.Page
    Public strCon As String = "Data Source=.\sqlexpress;Integrated Security=true;Initial Catalog=vgDB"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindGridviewData()
        End If

    End Sub
    Private Sub BindGridviewData()
        Using con As New SqlConnection(strCon)
            Using cmd As New SqlCommand()
                cmd.CommandText = "select pid,pimg from pimages"
                cmd.Connection = con
                con.Open()
                gvImages.DataSource = cmd.ExecuteReader()
                gvImages.DataBind()
                con.Close()
            End Using
        End Using
    End Sub
End Class
