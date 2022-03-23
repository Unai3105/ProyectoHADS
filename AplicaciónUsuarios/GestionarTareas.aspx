<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="GestionarTareas.aspx.vb" Inherits="AplicaciónUsuarios.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; PROFESOR&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton1" runat="server">Cerrar Sesión</asp:LinkButton>
            <br />
            GESTIÓN DE TAREAS GENÉRICAS<br />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Seleccionar Asignatura:"></asp:Label>
            <br />
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="codigoAsig" DataValueField="codigoAsig">
            </asp:DropDownList>
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="codigo" DataSourceID="SqlDataSource2" AllowSorting="True" AutoGenerateEditButton="True">
                <Columns>
                    <asp:BoundField DataField="codigo" HeaderText="codigo" ReadOnly="True" SortExpression="codigo"></asp:BoundField>
                    <asp:BoundField DataField="descripcion" HeaderText="descripcion" SortExpression="descripcion"></asp:BoundField>
                    <asp:BoundField DataField="hEstimadas" HeaderText="hEstimadas" SortExpression="hEstimadas"></asp:BoundField>
                    <asp:BoundField DataField="tipoTarea" HeaderText="tipoTarea" SortExpression="tipoTarea"></asp:BoundField>
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Insertar Nueva Tarea" />
            <br />
            <br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS2204ConnectionString %>" SelectCommand="Select codigoAsig
From GrupoClase Join ProfesorGrupo On GrupoClase.codigo = ProfesorGrupo.codigoGrupo
Where ProfesorGrupo.email = @email">
                <SelectParameters>
                    <asp:SessionParameter Name="email" SessionField="email" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:HADS2204ConnectionString %>" SelectCommand="Select codigo, descripcion, hEstimadas, tipoTarea
From TareaGenerica
Where codAsig = @codigo">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList1" Name="codigo" PropertyName="SelectedValue" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
