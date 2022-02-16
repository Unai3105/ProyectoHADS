Imports AccesoDatos
Public Class WebForm2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim result As String
        result = AccesoDatos.AccesodatosSQL.conectar()
        Label1.Text = result
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        AccesoDatos.AccesodatosSQL.cerrarconexion()
    End Sub

    Protected Sub correo_TextChanged(sender As Object, e As EventArgs) Handles correo.TextChanged

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim numConf As Integer = Funciones.Funciones.randomNumConf()
        Label8.Text = AccesoDatos.AccesodatosSQL.insertar(correo.Text, nombre.Text, apellidos.Text, numConf, False, Tipo.Text, password.Text, 123456)
        Funciones.Funciones.enviarCorreoConfirm(correo.Text, numConf)
    End Sub
End Class