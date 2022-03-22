﻿Imports System.Data.SqlClient

Public Class WebForm6
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim conClsf As SqlConnection
        conClsf = New SqlConnection(Session("ruta"))

        Dim dapMbrs As New SqlDataAdapter()
        Dim dstMbrs As New DataSet
        Dim tblMbrs As New DataTable

        Dim dapMbrs2 As New SqlDataAdapter()
        Dim dstMbrs2 As New DataSet
        Dim tblMbrs2 As New DataTable

        If Not Page.IsPostBack Then
            Dim email As String = Session("email")
            dapMbrs = New SqlDataAdapter("Select codigoAsig From EstudianteGrupo Join GrupoClase On EstudianteGrupo.grupo = GrupoClase.codigo Where EstudianteGrupo.email = '" & email & "'", conClsf)

            dapMbrs.Fill(dstMbrs, "Asignaturas")
            tblMbrs = dstMbrs.Tables("Asignaturas")

            DropDownListAsig.DataSource = dstMbrs.Tables(0)
            DropDownListAsig.DataTextField = "codigoAsig"
            DropDownListAsig.DataBind()

            Session("datos") = dstMbrs
            Session("adaptador") = dapMbrs

        Else

            dstMbrs = Session("datos")
            dapMbrs = Session("adaptador")

        End If

        Dim expl As Boolean = False
        Dim asignatura As String = DropDownListAsig.SelectedValue
        dapMbrs2 = New SqlDataAdapter("Select codigo, descripcion, hEstimadas, tipoTarea From TareaGenerica Where explotacion = '" & expl & "' and codAsig = '" & asignatura & "'", conClsf)
        dapMbrs2.Fill(dstMbrs2, "Asignaturas")
        tblMbrs2 = dstMbrs2.Tables("Asignaturas")

        GridView1.DataSource = dstMbrs2.Tables(0)
        GridView1.DataBind()
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Session.Clear()
        Response.Redirect("Inicio.aspx")
    End Sub

    Protected Sub DropDownListAsig_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListAsig.SelectedIndexChanged

    End Sub
End Class