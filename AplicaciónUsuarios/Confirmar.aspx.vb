Public Class WebForm3
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim result As String
        result = AccesoDatos.AccesodatosSQL.conectar()
        Label1.Text = result
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        AccesoDatos.AccesodatosSQL.cerrarconexion()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim numBD As String = AccesoDatos.AccesodatosSQL.obtenerNumConfir(TextBox1.Text)
        AccesoDatos.AccesodatosSQL.actualizarConfir(TextBox1.Text, numBD, TextBox2.Text)
        Response.Redirect("Inicio.aspx", True)
    End Sub
End Class