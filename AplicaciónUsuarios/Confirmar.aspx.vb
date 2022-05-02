Public Class WebForm3
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim result As String
        result = AccesoDatos.AccesodatosSQL.conectar()
        'Dim numBD As String = AccesoDatos.AccesodatosSQL.obtenerNumConfir(TextBox1.Text)
        Dim correo As String = Session("correo")
        Dim numConf As String = Session("numConf")

        AccesoDatos.AccesodatosSQL.actualizarConfir(correo, numConf)

        'Response.Redirect("https://hads2224.azurewebsites.net/Inicio.aspx", True)
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        AccesoDatos.AccesodatosSQL.cerrarconexion()
    End Sub

    Protected Sub registro_Click(sender As Object, e As EventArgs) Handles registro.Click

    End Sub
End Class