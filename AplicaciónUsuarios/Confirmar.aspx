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
            Correo a confirmar<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Número de confirmación:"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
        </div>
        <asp:Button ID="Button1" runat="server" Text="Confirmar" />
        <br />
    </form>
    <p>
        &nbsp;</p>
</body>
</html>
