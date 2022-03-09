Imports System.Data.SqlClient

Public Class AccesodatosSQL
    Private Shared conexion As New SqlConnection
    Private Shared comando As New SqlCommand

    Public Shared Function conectar() As String
        Try
            conexion.ConnectionString = “Server=tcp:hads-2204.database.windows.net,1433;Initial Catalog=HADS2204;Persist Security Info=False;User ID=uroa002@ikasle.ehu.es@hads-2204;Password={Contraseña};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            conexion.Open()
        Catch ex As Exception
            Return "ERROR DE CONEXIÓN: " + ex.Message
        End Try
        Return "CONEXION OK"
    End Function

    Public Shared Sub cerrarconexion()
        conexion.Close()
    End Sub

    Public Shared Function insertar(ByVal email As String, ByVal nombre As String, ByVal apellidos As String, ByVal numconfir As Integer, ByVal confirmado As Boolean, ByVal tipo As String, ByVal pass As String, ByVal codpass As Integer) As String
        Dim st = "insert into Usuarios (email, nombre, apellidos, numconfir, confirmado, tipo, pass, codpass) values ( @email,@nombre, @apellidos, @numconfir, @confirmado, @tipo, @pass, @codpass)"
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

    Public Shared Function obtenerNumConfir(ByVal email As String) As String
        Dim st = "select numconfir from Usuarios where email = @email"

        comando = New SqlCommand(st, conexion)
        comando.Parameters.AddWithValue("@email", email)

        Dim reader As SqlDataReader = comando.ExecuteReader()
        reader.Read()
        Dim rdo As String = String.Format("{0}", reader(0))
        reader.Close()
        Return (rdo)
    End Function

    Public Shared Function actualizarConfir(ByVal email As String, ByVal numConf As String)
        Dim st = "select numconfir from Usuarios where email = @email"
        comando = New SqlCommand(st, conexion)
        comando.Parameters.AddWithValue("@email", email)

        Dim reader As SqlDataReader = comando.ExecuteReader()
        reader.Read()
        Dim rdo As String = String.Format("{0}", reader(0))
        reader.Close()

        If (numConf = rdo) Then
            Dim st2 = "update Usuarios set confirmado=@confirm where email=@email"
            comando = New SqlCommand(st2, conexion)
            comando.Parameters.AddWithValue("@confirm", "True")
            comando.Parameters.AddWithValue("@email", email)
            comando.ExecuteNonQuery()
            'MsgBox("Correo confirmado")
        Else
            'MsgBox("Número incorrecto")
        End If
    End Function

    Public Shared Function loginCorrecto(ByVal email As String, ByVal password As String) As Integer
        Dim st As String
        Try
            st = "select pass from Usuarios where email=@email"
            comando = New SqlCommand(st, conexion)
            comando.Parameters.AddWithValue("@email", email)
            Dim reader As SqlDataReader = comando.ExecuteReader()
            reader.Read()
            Dim rdo As String = String.Format("{0}", reader(0))
            reader.Close()

            If (password = rdo) Then
                Return 0
            Else
                Return 1
            End If
        Catch
            MsgBox("Correo no registrado")
            Return 2
        End Try

    End Function
End Class
