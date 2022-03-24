Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim result As String
        result = AccesoDatos.AccesodatosSQL.conectar()
        msgConnection.Text = result
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        AccesoDatos.AccesodatosSQL.cerrarconexion()
    End Sub

    Protected Sub login_Click(sender As Object, e As EventArgs) Handles login.Click
        Dim rdo As Integer = AccesoDatos.AccesodatosSQL.loginCorrecto(user.Text, password.Text)
        If (rdo = 0) Then
            Session("email") = user.Text
            Session("tipo") = AccesoDatos.AccesodatosSQL.obtenerTipo(user.Text)
            Session("ruta") = AccesoDatos.AccesodatosSQL.obtenerRuta()
            If Session("tipo") = "Alumno" Then
                'Response.Redirect("Alumno.aspx")
                Response.Redirect("http://hads22-04.azurewebsites.net/Alumno.aspx")
            ElseIf Session("tipo") = "Profesor" Then
                'Response.Redirect("Profesor.aspx")
                Response.Redirect("http://hads22-04.azurewebsites.net/Profesor.aspx")
            End If
        ElseIf (rdo = 1) Then
            'MsgBox("Contraseña incorrecta")
            msgErr.Text = "Contraseña incorrecta"
        End If
    End Sub

    Protected Sub password_TextChanged(sender As Object, e As EventArgs) Handles password.TextChanged

    End Sub

    Protected Sub chpass_Click(sender As Object, e As EventArgs) Handles chpass.Click

    End Sub

    Protected Sub registro_Click(sender As Object, e As EventArgs) Handles registro.Click

    End Sub
End Class