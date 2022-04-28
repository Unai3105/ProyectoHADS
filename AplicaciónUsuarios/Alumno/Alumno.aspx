<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Alumno.aspx.vb" Inherits="AplicaciónUsuarios.WebForm9" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        ALUMNO<br />
        <br />
        <asp:LinkButton ID="LinkButtonVerTareas" runat="server">Ver Tareas</asp:LinkButton>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Button ID="Button1" runat="server" Text="Cerrar sesión" />
        <br />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
&nbsp;&nbsp;&nbsp;
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
                <asp:ListBox ID="ListBox2" runat="server"></asp:ListBox>
                <asp:Timer ID="Timer1" runat="server" Interval="5000" />
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="2000">
                    <progresstemplate>
                        <asp:Label ID="Label1" runat="server" Text="Buscando ..."></asp:Label>
                    </progresstemplate>
                </asp:UpdateProgress>
                <br />
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <br />
        <br />
    </form>
</body>
</html>
