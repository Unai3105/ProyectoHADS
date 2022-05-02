Public Class MediaHoras
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim result As String
        result = AccesoDatos.AccesodatosSQL.conectar()
    End Sub

    Protected Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim servicio As New horasasignatura.MediaHoras
        Dim horas As String = servicio.HorasAsignatura(DropDownList1.Text)
        horasAsig.Text = horas
        If horasAsig.Text = "" Then
            horasAsig.Text = "No hay horas para hacer la media"
        End If
    End Sub
End Class