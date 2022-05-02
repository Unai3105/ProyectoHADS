Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Web.Services
Imports System.Web.Services.Protocols

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class MediaHoras
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function HorasAsignatura(ByVal asignatura As String) As String
        Dim conexion As New SqlConnection
        Dim comando As New SqlCommand
        Dim ruta As String = "Server=tcp:hads2204.database.windows.net,1433;Initial Catalog=HADS22-04;Persist Security Info=False;User ID=mmorillo005@ikasle.ehu.eus@hads2204;Password=Hads2122;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"

        Try
            conexion.ConnectionString = ruta
            conexion.Open()
        Catch ex As Exception
            Return "ERROR DE CONEXIÓN: " + ex.Message
        End Try

        Dim st As String = "Select AVG(hReales) From TareaGenerica Join EstudianteTarea On TareaGenerica.codigo = EstudianteTarea.codTarea Where TareaGenerica.codAsig = @asignatura"

        comando = New SqlCommand(st, conexion)
        comando.Parameters.AddWithValue("@asignatura", asignatura)

        Try
            Dim reader As SqlDataReader = comando.ExecuteReader()
            reader.Read()
            Dim rdo As String = String.Format("{0}", reader(0))
            reader.Close()
            Return (rdo)
        Catch ex As Exception
            Return ("ERROR: " + ex.Message)
        End Try
    End Function

End Class