<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ExportarTareasXMLDocument.aspx.vb" Inherits="AplicaciónUsuarios.ExportarTareasXMLDocument" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; PROFESOR&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            EXPORTAR&nbsp; TAREAS GENÉRICAS<br />
            <br />
            <br />
    <form id="form1" runat="server">
            <asp:Label ID="Label1" runat="server" Text="Seleccionar Asignatura:"></asp:Label>
            <br />
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="codigoAsig" DataValueField="codigoAsig">
            </asp:DropDownList>
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="codigo" DataSourceID="SqlDataSource2" Width="323px">
                <Columns>
                    <asp:BoundField DataField="codigo" HeaderText="codigo" ReadOnly="True" SortExpression="codigo" />
                    <asp:BoundField DataField="descripcion" HeaderText="descripcion" SortExpression="descripcion" />
                    <asp:BoundField DataField="hEstimadas" HeaderText="hEstimadas" SortExpression="hEstimadas" />
                    <asp:BoundField DataField="tipoTarea" HeaderText="tipoTarea" SortExpression="tipoTarea" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Exportar" />
            <br />
            <br />
            <asp:Label ID="XMLExportado" runat="server" ForeColor="Lime"></asp:Label>
            <br />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Profesor.aspx">Volver</asp:HyperLink>
            <br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:hads2204/HADS22-04.dbo %>" SelectCommand="Select codigoAsig
From GrupoClase Join ProfesorGrupo On GrupoClase.codigo = ProfesorGrupo.codigoGrupo
Where ProfesorGrupo.email = @email">
                <SelectParameters>
                    <asp:SessionParameter Name="email" SessionField="email" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:hads2204/HADS22-04.dbo %>" SelectCommand="Select codigo, descripcion, hEstimadas, tipoTarea
From TareaGenerica
Where codAsig = @codigo">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList1" Name="codigo" PropertyName="SelectedValue" />
                </SelectParameters>
            </asp:SqlDataSource>
        <div>
        </div>
    </form>
</body>
</html>
