Public Class WebForm9
    Inherits System.Web.UI.Page

    Public listAlumnos = New List(Of String)
    Public listProfesores = New List(Of String)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        listAlumnos = Application("CorreoAlumnos")
        listProfesores = Application("CorreoProfesores")

        If Not Application("CorreoAlumnos").ToString = "" Then
            For Each item As String In listAlumnos
                ListBox1.Items.Add(item)
            Next
        End If
        If Not Application("CorreoProfesores").ToString = "" Then
            For Each item As String In listProfesores
                ListBox2.Items.Add(item)
            Next
        End If
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButtonVerTareas.Click
        Response.Redirect("Alumno/VerTareasEstudiante.aspx")
        'Response.Redirect("http://hads22-04.azurewebsites.net/Alumno/VerTareaEstudiante.aspx")
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim listAlumnos = New List(Of String)
        listAlumnos = Application("CorreoAlumnos")

        listAlumnos.Remove(Session("email"))
        Application("CorreoAlumnos") = listAlumnos

        Session.Clear()

        Response.Redirect("../Inicio.aspx")
        'FormsAuthentication.SignOut()
    End Sub

    Protected Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Protected Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        listAlumnos = Application("CorreoAlumnos")
        listProfesores = Application("CorreoProfesores")

        ListBox1.Items.Clear()
        If Not Application("CorreoAlumnos").ToString = "" Then
            For Each item As String In listAlumnos
                ListBox1.Items.Add(item)
            Next
        End If

        ListBox2.Items.Clear()
        If Not Application("CorreoProfesores").ToString = "" Then
            For Each item As String In listProfesores
                ListBox2.Items.Add(item)
            Next
        End If
    End Sub
End Class