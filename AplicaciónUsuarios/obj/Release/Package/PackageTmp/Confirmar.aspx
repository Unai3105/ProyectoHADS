<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Confirmar.aspx.vb" Inherits="AplicaciónUsuarios.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Registro confirmado.</div>
        <p>
            <asp:LinkButton ID="registro" runat="server" CausesValidation="False" PostBackUrl="~/Inicio.aspx">Inicia sesión aquí</asp:LinkButton>
        </p>
    </form>
    </body>
</html>
