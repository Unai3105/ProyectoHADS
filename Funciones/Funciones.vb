Imports System.Net.Mail

Public Class Funciones

    Public Shared Function randomNumConf() As Integer
        Randomize()
        Return CLng(Rnd() * 9000000) + 1000000
    End Function

    Public Shared Function enviarCorreoConfirm(ByVal correoDestino As String, ByVal numConfirm As Integer)
        Dim message As New MailMessage
        Dim smtp As New SmtpClient

        With message
            .From = New System.Net.Mail.MailAddress("HADS202204@gmail.com")
            .To.Add(correoDestino)
            .Body = "Link de confirmación: http://hads2224.azurewebsites.net/Confirmar.aspx"
            .Subject = "Confirmación HADS"
            .IsBodyHtml = False
            .Priority = System.Net.Mail.MailPriority.Normal
        End With

        With smtp
            .EnableSsl = True
            .Port = "587"
            .Host = "smtp.gmail.com"
            .UseDefaultCredentials = False
            .Credentials = New System.Net.NetworkCredential("HADS202204@gmail.com", "hads2204")
        End With

        Try
            smtp.Send(message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

End Class
