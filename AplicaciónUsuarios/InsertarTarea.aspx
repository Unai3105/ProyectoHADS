<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InsertarTarea.aspx.vb" Inherits="AplicaciónUsuarios.WebForm8" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; PROFESOR&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton2" runat="server">Ver Tareas</asp:LinkButton>
            <br />
            GESTIÓN DE TAREAS GENÉRICAS<br />
        </div>
        <p>
            Código:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="codigoBox" runat="server"></asp:TextBox>
        </p>
        <p>
            Descripción:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="descripcionBox" runat="server" Height="44px" Width="320px"></asp:TextBox>
        </p>
        <p>
            Asignatura:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownListAsign" runat="server" DataSourceID="SqlDataSource1" DataTextField="codigoAsig" DataValueField="codigoAsig">
            </asp:DropDownList>
        </p>
        <p>
            Horas estimadas:&nbsp;&nbsp; <asp:TextBox ID="hEstimadasBox" runat="server"></asp:TextBox>
        </p>
        <p>
            Tipo tarea:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownListTipoTarea" runat="server">
                <asp:ListItem>Laboratorio</asp:ListItem>
                <asp:ListItem>Trabajo</asp:ListItem>
                <asp:ListItem>Ejercicio</asp:ListItem>
                <asp:ListItem>Examen</asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Añadir Tarea" style="height: 26px" />
        </p>
        <p>
            <asp:Label ID="CambiosGuardados" runat="server" ForeColor="Lime"></asp:Label>
        </p>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS2204ConnectionString %>" SelectCommand="Select codigoAsig
From GrupoClase Join ProfesorGrupo On GrupoClase.codigo = ProfesorGrupo.codigoGrupo
Where ProfesorGrupo.email = @email">
                <SelectParameters>
                    <asp:SessionParameter Name="email" SessionField="email" />
                </SelectParameters>
            </asp:SqlDataSource>
    </form>
</body>
</html>
