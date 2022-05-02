Public Class WebForm10
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

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        'Response.Redirect("Profesor/GestionarTareas.aspx")
        Response.Redirect("http://hads22-04.azurewebsites.net/Profesor/GestionarTareas.aspx")
    End Sub

    Protected Sub LinkButton2_Click(sender As Object, e As EventArgs) Handles LinkButton2.Click
        'Response.Redirect("Coordinador/ImportarTareasXMLDocument.aspx")
        Response.Redirect("http://hads22-04.azurewebsites.net/Coordinador/ImportarTareasXMLDocument.aspx")
    End Sub

    Protected Sub LinkButton3_Click(sender As Object, e As EventArgs) Handles LinkButton3.Click
        'Response.Redirect("Coordinador/ExportarTareasXMLDocument.aspx")
        Response.Redirect("http://hads22-04.azurewebsites.net/Coordinador/ExportarTareasXMLDocument.aspx")
    End Sub

    Protected Sub LinkButton4_Click(sender As Object, e As EventArgs) Handles LinkButton4.Click
        Dim listProfesores = New List(Of String)
        listProfesores = Application("CorreoProfesores")

        listProfesores.Remove(Session("email"))
        Application("CorreoProfesores") = listProfesores

        Session.Clear()

        'FormsAuthentication.SignOut()
        'Response.Redirect("../Inicio.aspx")
        Response.Redirect("http://hads22-04.azurewebsites.net/Inicio.aspx")
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

    Protected Sub LinkButton5_Click(sender As Object, e As EventArgs) Handles LinkButton5.Click
        'Response.Redirect("../Coordinador/MediaHoras.aspx")
        Response.Redirect("http://hads22-04.azurewebsites.net/Coordinador/MediaHoras.aspx")
    End Sub
End Class