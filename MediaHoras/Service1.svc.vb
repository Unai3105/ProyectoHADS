' NOTA: puede usar el comando "Cambiar nombre" del menú contextual para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
' NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.vb en el Explorador de soluciones e inicie la depuración.
Imports System.Data.SqlClient
Imports System.Web.Services

Public Class Service1
    'Implements IService1
    Inherits System.Web.Services.WebService

    Public Sub New()
    End Sub

    <WebMethod()>
    Public Function HorasAsignatura(ByVal asignatura As String) As String 'Implements IService1.HorasAsignatura
        Dim conClsf As SqlConnection
        conClsf = New SqlConnection(“Server=tcp:hads2204.database.windows.net,1433;Initial Catalog=HADS22-04;Persist Security Info=False;User ID=mmorillo005@ikasle.ehu.eus@hads2204;Password=Hads2122;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")

        Dim dapMbrs As New SqlDataAdapter()
        Dim dstMbrs As New DataSet
        Dim tblMbrs As New DataTable

        'dapMbrs = New SqlDataAdapter("Select AVG(hReales) From TareaGenerica Join EstudianteTarea On TareaGenerica.codigo = EstudianteTarea.codTarea Where TareaGenerica.codAsig = '" & asignatura & "'", conClsf)

        'dapMbrs.Fill(dstMbrs, "hAsignaturas")
        'tblMbrs = dstMbrs.Tables("hAsignaturas")

        Dim conexion As New SqlConnection
        Dim comando As New SqlCommand

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
