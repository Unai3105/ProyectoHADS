Public Class WebForm9
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButtonVerTareas.Click
        Response.Redirect("VerTareasEstudiante.aspx")
    End Sub
End Class