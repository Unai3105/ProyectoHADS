<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Inicio.aspx.vb" Inherits="AplicaciónUsuarios.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="LOGIN:"></asp:Label>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Usuario:"></asp:Label>
        </div>
        <asp:TextBox ID="user" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="userValidator" runat="server" ControlToValidate="user" ErrorMessage="* Usuario necesario" ForeColor="Red"></asp:RequiredFieldValidator>
        <p>
            <asp:Label ID="Label3" runat="server" Text="Contraseña:"></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="password" ErrorMessage="* Contraseña necesaria" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Button ID="login" runat="server" Text="Login" />
        </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Label ID="Label4" runat="server" Text="¿No tienes cuenta?"></asp:Label>
        </p>
        <p>
            <asp:LinkButton ID="registro" runat="server" CausesValidation="False" PostBackUrl="~/Registro.aspx">Registrate aquí</asp:LinkButton>
        </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            <asp:LinkButton ID="chpass" runat="server">Cambiar contraseña</asp:LinkButton>
        </p>
    </form>
</body>
</html>
