<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InstanciarTarea.aspx.vb" Inherits="AplicaciónUsuarios.WebForm7" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Email estudiante:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server" Enabled="False"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton1" runat="server">Ver Tareas</asp:LinkButton>
            <br />
            Código de la tarea:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox2" runat="server" Enabled="False"></asp:TextBox>
            <br />
            Horas estimadas:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox3" runat="server" Enabled="False"></asp:TextBox>
            <br />
            Horas Reales:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox4" ErrorMessage="* Campo necesario" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Instanciar Tarea" />
            <br />
            <br />
            <asp:Label ID="TareaInstanciada" runat="server"></asp:Label>
            <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
