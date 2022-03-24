Public Class WebForm10
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        'Response.Redirect("GestionarTareas.aspx")
        Response.Redirect("http://hads22-04.azurewebsites.net/GestionarTareas.aspx")
    End Sub

    Protected Sub LinkButton2_Click(sender As Object, e As EventArgs) Handles LinkButton2.Click
        'Response.Redirect("ImportarTareasXMLDocument.aspx")
        Response.Redirect("http://hads22-04.azurewebsites.net/ImportarTareasXMLDocument.aspx")
    End Sub

    Protected Sub LinkButton3_Click(sender As Object, e As EventArgs) Handles LinkButton3.Click
        Response.Redirect("http://hads22-04.azurewebsites.net/ExportarTareasXMLDocument.aspx")
    End Sub

    Protected Sub LinkButton4_Click(sender As Object, e As EventArgs) Handles LinkButton4.Click
        Session.Clear()
        Response.Redirect("http://hads22-04.azurewebsites.net/Inicio.aspx")
    End Sub
End Class