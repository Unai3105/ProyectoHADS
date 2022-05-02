<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MediaHoras.aspx.vb" Inherits="AplicaciónUsuarios.MediaHoras" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            MEDIA HORAS ASIGNATURA<br />
            <br />
            Selecciona una asignatura:<br />
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="codigoAsig" DataValueField="codigoAsig">
            </asp:DropDownList>
            <br />
            <br />
            Media de horas asignatura:<asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <br />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Label ID="horasAsig" runat="server"></asp:Label>
                    <br />
                    <asp:Timer ID="Timer1" runat="server" Interval="2000">
                    </asp:Timer>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Profesor/Profesor.aspx">Volver</asp:LinkButton>
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:hads2204/HADS22-04.dbo %>" SelectCommand="SELECT [codigoAsig] FROM [GrupoClase]"></asp:SqlDataSource>
    </form>
</body>
</html>
