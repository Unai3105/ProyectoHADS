Imports AccesoDatos
'Imports System.Security.Cryptography
Public Class WebForm2
    Inherits System.Web.UI.Page

    Shared emailActual As String
    Private servicio As New matriculado.Matriculas

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim servicio As New matriculado.Matriculas

        Dim result As String
        result = AccesoDatos.AccesodatosSQL.conectar()
        'MsgBox(result) 'para ver si se ha concetado correctamente
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        AccesoDatos.AccesodatosSQL.cerrarconexion()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim numConf As Integer = Funciones.Funciones.randomNumConf()
        Dim wrapper As New Simple3Des(password.Text)
        Dim hash As String = wrapper.encryptData(password.Text)
        Dim servicio As New matriculado.Matriculas
        Dim matriculado As String = servicio.comprobar(correo.Text)
        If matriculado = "SI" Then
            Dim msg As String = AccesoDatos.AccesodatosSQL.insertar(correo.Text, nombre.Text, apellidos.Text, numConf, False, Tipo.Text, hash, 123456)
            'MsgBox(msg) 'para mostrar si se ha insertado correctamente
            Funciones.Funciones.enviarCorreoConfirm(correo.Text, numConf)
            Session("correo") = correo.Text
            Session("numConf") = numConf
            'MsgBox("Registro completado correctamente")
        End If

    End Sub

    Protected Sub password_TextChanged(sender As Object, e As EventArgs) Handles password.TextChanged

    End Sub

    Protected Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If correo.Text <> "" Then
            'Dim servicio As New matriculado.Matriculas
            Dim matriculado As String = servicio.comprobar(correo.Text)
            If matriculado = "NO" Then
                usuarioExistente.Text = ""
                matri.Text = "Usuario NO matriculado"
            Else
                usuarioExistente.Text = "Este usuario SI está matriculado"
                matri.Text = ""
            End If
        Else
            matri.Text = ""
            usuarioExistente.Text = ""
        End If
    End Sub
End Class