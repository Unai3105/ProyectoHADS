<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Alumno.aspx.vb" Inherits="AplicaciónUsuarios.WebForm9" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

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
&nbsp;&nbsp;&nbsp;
        <br />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
                &nbsp;<asp:ListBox ID="ListBox2" runat="server"></asp:ListBox>
                <asp:Timer ID="Timer1" runat="server" Interval="5000">
                </asp:Timer>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Cerrar sesión" />
        <br />
    </form>
</body>
</html>
