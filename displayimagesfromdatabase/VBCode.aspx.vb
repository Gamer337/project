
Imports System.Data.SqlClient
Imports System.IO
Imports System.Web.UI.WebControls
Imports System.Web
Partial Class VBCode
    Inherits System.Web.UI.Page
    Private strCon As String = "Data Source=Suresh;Integrated Security=true;Initial Catalog=MySampleDB"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindGridviewData()
        End If
    End Sub
    ' Bind Gridview Data
    Private Sub BindGridviewData()
        Using con As New SqlConnection(strCon)
            Using cmd As New SqlCommand()
                cmd.CommandText = "select imageid,imagename from imagedetails"
                cmd.Connection = con
                con.Open()
                gvImages.DataSource = cmd.ExecuteReader()
                gvImages.DataBind()
                con.Close()
            End Using
        End Using
    End Sub
    ' Save files to Folder and files path in database
    Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Condition to check if the file uploaded or not
        If fileUpload1.HasFile Then
            Dim length As Integer = fileUpload1.PostedFile.ContentLength
            Dim imgbyte As Byte() = New Byte(length - 1) {}
            Dim img As HttpPostedFile = fileUpload1.PostedFile
            'set the binary data
            img.InputStream.Read(imgbyte, 0, length)

            Dim filename As String = Path.GetFileName(fileUpload1.PostedFile.FileName)

            Using con As New SqlConnection(strCon)
                Using cmd As New SqlCommand()
                    cmd.CommandText = "insert into imagedetails(imagename,imagedata) values(@Name,@Data)"
                    cmd.Parameters.AddWithValue("@Name", filename)
                    cmd.Parameters.AddWithValue("@Data", imgbyte)
                    cmd.Connection = con
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    BindGridviewData()
                End Using
            End Using
        End If
    End Sub

    Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpload.Click

    End Sub
End Class