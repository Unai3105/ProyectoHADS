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
        Label8.Text = AccesoDatos.AccesodatosSQL.insertar("uroa3105@gmail.com", "Unai", "Roa Cepeda", 123456, False, "Alumno", 123456, 123456)

    End Sub
End Class