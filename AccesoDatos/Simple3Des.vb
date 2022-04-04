Imports System.Security.Cryptography
Public NotInheritable Class Simple3Des
    Private Shared TripleDes As New TripleDESCryptoServiceProvider
    Private Function TruncateHash(ByVal key As String, ByVal length As Integer) As Byte()
        Dim sha1 As New SHA1CryptoServiceProvider

        Dim keyBytes() As Byte = System.Text.Encoding.Unicode.GetBytes(key)
        Dim hash() As Byte = sha1.ComputeHash(keyBytes)

        ReDim Preserve hash(length - 1)
        Return hash
    End Function
    Sub New(ByVal key As String)
        TripleDes.Key = TruncateHash(key, TripleDes.KeySize \ 8)
        TripleDes.IV = TruncateHash("", TripleDes.BlockSize \ 8)
    End Sub
    Public Shared Function encryptData(ByVal texto As String) As String
        Dim textoBytes() As Byte = System.Text.Encoding.Unicode.GetBytes(texto)
        Dim ms As New System.IO.MemoryStream
        Dim encStream As New CryptoStream(ms, TripleDes.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write)

        encStream.Write(textoBytes, 0, textoBytes.Length)
        encStream.FlushFinalBlock()

        Return Convert.ToBase64String(ms.ToArray)
    End Function
    Public Shared Function decryptData(ByVal hash As String) As String
        Dim hashBytes() As Byte = Convert.FromBase64String(hash)
        Dim ms As New System.IO.MemoryStream
        Dim decStream As New CryptoStream(ms, TripleDes.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Write)

        decStream.Write(hashBytes, 0, hashBytes.Length)
        decStream.FlushFinalBlock()

        Return System.Text.Encoding.Unicode.GetString(ms.ToArray)
    End Function
End Class
