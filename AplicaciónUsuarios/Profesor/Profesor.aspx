<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Profesor.aspx.vb" Inherits="AplicaciónUsuarios.WebForm10" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        PROFESOR<br />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server">Gestionar Tareas</asp:LinkButton>
        <p>
            <asp:LinkButton ID="LinkButton2" runat="server"> Importar XML Document</asp:LinkButton>
        </p>
        <p>
            <asp:LinkButton ID="LinkButton3" runat="server">Exportar</asp:LinkButton>
        </p>
        <p>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </p>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
                <asp:ListBox ID="ListBox2" runat="server"></asp:ListBox>
                <asp:Timer ID="Timer1" runat="server" Interval="5000" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <p>
            Buscando ...</p>
        <p>
            <asp:LinkButton ID="LinkButton4" runat="server">Cerrar sesión</asp:LinkButton>
        </p>
    </form>
</body>
</html>
