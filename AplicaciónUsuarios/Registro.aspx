<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Registro.aspx.vb" Inherits="AplicaciónUsuarios.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="label" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="REGISTRO DE USUARIO:"></asp:Label>
        </div>
        <asp:Label ID="Label2" runat="server" Text="Correo:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="correo" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ValidadorCorreo" runat="server" ControlToValidate="correo" ErrorMessage="* Campo necesario" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="ValidarCorreoValido" runat="server" ControlToValidate="correo" ErrorMessage="* Correo no valido" ForeColor="Red" ValidationExpression="[a-zA-Z0-9]+@[a-z]+[.a-z]+"></asp:RegularExpressionValidator>
        <p>
            <asp:Label ID="Label3" runat="server" Text="Nombre:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="nombre" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ValidadorNombre" runat="server" ControlToValidate="nombre" ErrorMessage="* Campo necesario" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <asp:Label ID="Label4" runat="server" Text="Apellidos:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="apellidos" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ValidadorApellidos" runat="server" ControlToValidate="apellidos" ErrorMessage="* Campo necesario" ForeColor="Red"></asp:RequiredFieldValidator>
        <p>
            <asp:Label ID="Label5" runat="server" Text="Contraseña:"></asp:Label>
&nbsp;<asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ValidadorContraseña1" runat="server" ControlToValidate="password" ErrorMessage="* Campo necesario" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="password" ErrorMessage="* Minimo 6 caracteres" ForeColor="Red" ValidationExpression="\w{6}\w*"></asp:RegularExpressionValidator>
        </p>
        <asp:Label ID="Label6" runat="server" Text="Repetir contraseña:"></asp:Label>
&nbsp;<asp:TextBox ID="password2" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ValidadorPassword2" runat="server" ControlToValidate="password2" ErrorMessage="* Campo necesario" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="ComparadorPassword" runat="server" ControlToCompare="password" ControlToValidate="password2" ErrorMessage="* Las contraseñas tienen que ser iguales" ForeColor="Red"></asp:CompareValidator>
        <p>
            <asp:Label ID="Rol" runat="server" Text="Rol:"></asp:Label>
            <asp:DropDownList ID="Tipo" runat="server">
                <asp:ListItem Value="alumno">Alumno</asp:ListItem>
                <asp:ListItem Value="profesor">Profesor</asp:ListItem>
            </asp:DropDownList>
        </p>
        <asp:Button ID="Button1" runat="server" Text="Registrar" />
        <br />
        <br />
    </form>
</body>
</html>
