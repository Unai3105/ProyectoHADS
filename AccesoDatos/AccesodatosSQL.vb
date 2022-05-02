Imports System.Data.SqlClient
Imports System.Security.Cryptography

Public Class AccesodatosSQL
    Private Shared conexion As New SqlConnection
    Private Shared comando As New SqlCommand
    'Private Shared ruta As String = “Server=tcp:hads-2204.database.windows.net,1433;Initial Catalog=HADS2204;Persist Security Info=False;User ID=uroa002@ikasle.ehu.es@hads-2204;Password="";MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
    Private Shared ruta As String = “Server=tcp:hads2204.database.windows.net,1433;Initial Catalog=HADS22-04;Persist Security Info=False;User ID=mmorillo005@ikasle.ehu.eus@hads2204;Password=Hads2122;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
    'Private Shared tripleDes As New TripleDESCryptoServiceProvider
    Public Shared Function conectar() As String
        Try
            conexion.ConnectionString = ruta
            conexion.Open()
        Catch ex As Exception
            Return "ERROR DE CONEXIÓN: " + ex.Message
        End Try
        Return "CONEXION OK"
    End Function

    Public Shared Function obtenerRuta() As String
        Return (ruta)
    End Function

    Public Shared Sub cerrarconexion()
        conexion.Close()
    End Sub

    Public Shared Function insertar(ByVal email As String, ByVal nombre As String, ByVal apellidos As String, ByVal numconfir As Integer, ByVal confirmado As Boolean, ByVal tipo As String, ByVal pass As String, ByVal codpass As Integer) As String
        Dim st = "insert into Usuario (email, nombre, apellidos, numconfir, confirmado, tipo, pass, codpass) values ( @email,@nombre, @apellidos, @numconfir, @confirmado, @tipo, @pass, @codpass)"
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
        Dim st = "select numconfir from Usuario where email = @email"

        comando = New SqlCommand(st, conexion)
        comando.Parameters.AddWithValue("@email", email)
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

    Public Shared Function obtenerTipo(ByVal email) As String
        Dim st As String = "select tipo from Usuario where email=@email"

        comando = New SqlCommand(st, conexion)
        comando.Parameters.AddWithValue("@email", email)

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

    Public Shared Function actualizarConfir(ByVal email As String, ByVal numConf As String)
        Dim st As String = "select numconfir from Usuario where email = @email"

        comando = New SqlCommand(st, conexion)
        comando.Parameters.AddWithValue("@email", email)

        Dim reader As SqlDataReader = comando.ExecuteReader()
        reader.Read()
        Dim rdo As String = String.Format("{0}", reader(0))
        reader.Close()

        If (numConf = rdo) Then
            Dim st2 = "update Usuario set confirmado=@confirm where email=@email"
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
            st = "select pass from Usuario where email=@email"
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

    Public Shared Function obtenerAsigAlumno(ByVal ruta As String, ByVal email As String) As SqlDataAdapter

        Dim conClsf As SqlConnection
        conClsf = New SqlConnection(ruta)

        Dim dapMbrs As New SqlDataAdapter()
        Dim dstMbrs As New DataSet
        Dim tblMbrs As New DataTable

        dapMbrs = New SqlDataAdapter("Select grupo From EstudianteGrupo Where email = " & email, conClsf)
        Dim bldMbrs As New SqlCommandBuilder(dapMbrs)

        dapMbrs.Fill(dstMbrs, "Tarea")
        tblMbrs = dstMbrs.Tables("Tarea")

        Dim rowMbrs As DataRow = tblMbrs.NewRow()
        tblMbrs.Rows.Add(rowMbrs)

    End Function

    Public Shared Function obtenerPass(ByVal email) As String
        Dim st As String = "select pass from Usuario where email=@email"

        comando = New SqlCommand(st, conexion)
        comando.Parameters.AddWithValue("@email", email)

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

    'Public Shared Function encryptData(ByVal texto As String) As String
    '    Dim textoBytes() As Byte = System.Text.Encoding.Unicode.GetBytes(texto)
    '    Dim ms As New System.IO.MemoryStream
    '    Dim encStream As New CryptoStream(ms, tripleDes.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write)

    '    encStream.Write(textoBytes, 0, textoBytes.Length)
    '    encStream.FlushFinalBlock()

    '    Return Convert.ToBase64String(ms.ToArray)
    'End Function

    'Public Shared Function decryptData(ByVal hash As String) As String
    '    Dim hashBytes() As Byte = Convert.FromBase64String(hash)
    '    Dim ms As New System.IO.MemoryStream
    '    Dim decStream As New CryptoStream(ms, tripleDes.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Write)

    '    decStream.Write(hashBytes, 0, hashBytes.Length)
    '    decStream.FlushFinalBlock()

    '    Return System.Text.Encoding.Unicode.GetString(ms.ToArray)
    'End Function

    'Private Function TruncateHash(ByVal key As String, ByVal length As Integer) As Byte()
    '    Dim sha1 As New SHA1CryptoServiceProvider

    '    Dim keyBytes() As Byte = System.Text.Encoding.Unicode.GetBytes(key)
    '    Dim hash() As Byte = sha1.ComputeHash(keyBytes)

    '    ReDim Preserve hash(length - 1)
    '    Return hash
    'End Function

    'Sub New(ByVal key As String)
    '    tripleDes.Key = TruncateHash(key, tripleDes.KeySize \ 8)
    '    tripleDes.IV = TruncateHash("", tripleDes.BlockSize \ 8)
    'End Sub











    'https://docs.microsoft.com/es-es/dotnet/visual-basic/programming-guide/language-features/strings/walkthrough-encrypting-and-decrypting-strings
End Class
