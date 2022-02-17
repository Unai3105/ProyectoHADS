Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim result As String
        result = AccesoDatos.AccesodatosSQL.conectar()
        Label1.Text = result
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        AccesoDatos.AccesodatosSQL.cerrarconexion()
    End Sub

    Protected Sub login_Click(sender As Object, e As EventArgs) Handles login.Click
        Dim rdo As Integer = AccesoDatos.AccesodatosSQL.loginCorrecto(user.Text, password.Text)
        If (rdo = 0) Then
            Response.Redirect("Aplicación.aspx", True)
        ElseIf (rdo = 1) Then
            MsgBox("Contraseña incorrecta")
        End If
    End Sub

    Protected Sub password_TextChanged(sender As Object, e As EventArgs) Handles password.TextChanged

    End Sub

    Protected Sub chpass_Click(sender As Object, e As EventArgs) Handles chpass.Click

    End Sub
End Class