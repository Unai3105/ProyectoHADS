<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="VerTareasEstudiante.aspx.vb" Inherits="AplicaciónUsuarios.WebForm6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ALUMNOS&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton1" runat="server">Cerrar Sesión</asp:LinkButton>
            <br />
            GESTIÓN DE TAREAS GENÉRICAS<br />
            <br />
            <br />
            Seleccionar Asignatura (solo se muestran aquellas en las que está matriculado):<br />
            <br />
            <asp:DropDownList ID="DropDownListAsig" runat="server" AutoPostBack="True">
            </asp:DropDownList>
            <br />
            <br />
        </div>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
