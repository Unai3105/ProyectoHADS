Imports System.Data.SqlClient

Public Class AccesodatosSQL
    Private Shared conexion As New SqlConnection
    Private Shared comando As New SqlCommand

    Public Shared Function conectar() As String
        Try
            conexion.ConnectionString = “Server=tcp:hads-2204.database.windows.net,1433;Initial Catalog=HADS2204;Persist Security Info=False;User ID=uroa002@ikasle.ehu.es@hads-2204;Password=Ekaitzaelurra_221018;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            conexion.Open()
        Catch ex As Exception
            Return "ERROR DE CONEXIÓN: " + ex.Message
        End Try
        Return "CONEXION OK"
    End Function

    Public Shared Sub cerrarconexion()
        conexion.Close()
    End Sub

    Public Shared Function insertar(ByVal email As String, ByVal nombre As String, ByVal apellidos As String, ByVal numconfir As Integer, ByVal confirmado As Boolean, ByVal tipo As String, ByVal pass As Integer, ByVal codpass As Integer) As String
        Dim st = "insert into Usuarios (email, nombre, apellidos, numconfir, confirmado, tipo, pass, codpass) values (@email,@nombre, @apellidos, @numconfir, @confirmado, @tipo, @pass, @codpass)"
        Dim numregs As Integer
        comando = New SqlCommand(st, conexion)
        comando.Parameters.AddWithValue("@email", email)
        comando.Parameters.AddWithValue("@nombre", nombre)
        comando.Parameters.AddWithValue("@apellidos", apellidos)
        comando.Parameters.AddWithValue("@numconfir", numconfir)
        comando.Parameters.AddWithValue("@confirmado", confirmado)
        comando.Parameters.AddWithValue("@tipo", tipo)
        comando.Parameters.AddWithValue("@pass", pass)
        comando.Parameters.AddWithValue("@codpass", codpass)


        Try
            numregs = comando.ExecuteNonQuery()
        Catch ex As Exception
            Return ex.Message
        End Try
        Return (numregs & " registro(s) insertado(s) en la BD ")
    End Function

End Class
