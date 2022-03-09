Imports AccesoDatos
Public Class WebForm2
    Inherits System.Web.UI.Page

    Shared emailActual As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim result As String
        result = AccesoDatos.AccesodatosSQL.conectar()
        'MsgBox(result) 'para ver si se ha concetado correctamente
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        AccesoDatos.AccesodatosSQL.cerrarconexion()
    End Sub

    Protected Sub correo_TextChanged(sender As Object, e As EventArgs) Handles correo.TextChanged

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim numConf As Integer = Funciones.Funciones.randomNumConf()
        Dim msg As String = AccesoDatos.AccesodatosSQL.insertar(correo.Text, nombre.Text, apellidos.Text, numConf, False, Tipo.Text, password.Text, 123456)
        'MsgBox(msg) 'para mostrar si se ha insertado correctamente
        Funciones.Funciones.enviarCorreoConfirm(correo.Text, numConf)
        Session("correo") = correo.Text
        Session("numConf") = numConf
        'MsgBox("Registro completado correctamente")
        Label7.Text = "Registro completado correctamente, confirme el correo"

    End Sub
End Class