Imports System.Data.SqlClient

Public Class ExportarTareasXMLDocument
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim conClsf As SqlConnection
        conClsf = New SqlConnection(Session("ruta"))
        Dim dapMbrs As New SqlDataAdapter()
        Dim dstMbrs As New DataSet
        Dim tblMbrs As New DataTable

        If Page.IsPostBack Then
            dstMbrs = Session("datos")
        Else
            dapMbrs = New SqlDataAdapter("Select * From TareaGenerica", conClsf)
            Dim bldMbrs As New SqlCommandBuilder(dapMbrs)
            dapMbrs.Fill(dstMbrs, "Tarea")
            tblMbrs = dstMbrs.Tables("Tarea")
            Session("datos") = dstMbrs
            Session("adaptador") = dapMbrs
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim tbl As New DataTable
        Dim row As DataRow
        Dim dst As New DataSet
        Dim dap As New SqlDataAdapter()
        Dim conClsf As SqlConnection
        conClsf = New SqlConnection(Session("ruta"))

        dap = New SqlDataAdapter("Select codigo, descripcion, hEstimadas, tipoTarea From TareaGenerica Where codAsig = '" & DropDownList1.Text & "'", conClsf)
        dap.Fill(dst, "Tarea")
        tbl = dst.Tables("Tarea")

        tbl.WriteXml(Server.MapPath("/App_Data/" & DropDownList1.Text & ".xml"))

        XMLExportado.Text = "XML exportado con exito"
    End Sub
End Class