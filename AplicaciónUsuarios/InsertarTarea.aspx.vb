Imports System.Data.SqlClient

Public Class WebForm8
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub DropDownList2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListTipoTarea.SelectedIndexChanged

    End Sub

    Protected Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles codigoBox.TextChanged

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim conClsf As SqlConnection
        conClsf = New SqlConnection(Session("ruta"))

        Dim dapMbrs As New SqlDataAdapter()
        Dim dstMbrs As New DataSet
        Dim tblMbrs As New DataTable

        dapMbrs = New SqlDataAdapter("Select * From TareaGenerica", conClsf)
        Dim bldMbrs As New SqlCommandBuilder(dapMbrs)

        dapMbrs.Fill(dstMbrs, "Tarea")
        tblMbrs = dstMbrs.Tables("Tarea")

        Dim rowMbrs As DataRow = tblMbrs.NewRow()
        rowMbrs("codigo") = codigoBox.Text
        rowMbrs("descripcion") = descripcionBox.Text
        rowMbrs("codAsig") = DropDownListAsign.Text
        rowMbrs("explotacion") = False
        rowMbrs("hEstimadas") = hEstimadasBox.Text
        rowMbrs("tipoTarea") = DropDownListTipoTarea.SelectedValue
        tblMbrs.Rows.Add(rowMbrs)

        Session("adaptador") = dapMbrs
        Session("datos") = dstMbrs
        dapMbrs.Update(dstMbrs, "Tarea")
        dstMbrs.AcceptChanges()
        CambiosGuardados.Text = "Cambios guardados en la BD"

    End Sub

    Protected Sub DropDownListAsign_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListAsign.SelectedIndexChanged

    End Sub

    Protected Sub LinkButton2_Click(sender As Object, e As EventArgs) Handles LinkButton2.Click
        Response.Redirect("GestionarTareas.aspx")
    End Sub

    Protected Sub descripcionBox_TextChanged(sender As Object, e As EventArgs) Handles descripcionBox.TextChanged

    End Sub
End Class