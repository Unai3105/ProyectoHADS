Imports System.Data.SqlClient
Imports System.Xml

Public Class ImportarTareasXMLDocuments
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
            dapMbrs = New SqlDataAdapter("Select codigoAsig From GrupoClase Join ProfesorGrupo On GrupoClase.codigo = ProfesorGrupo.codigoGrupo Where ProfesorGrupo.email = '" & email & "'", conClsf)

            dapMbrs.Fill(dstMbrs, "Asignaturas")
            tblMbrs = dstMbrs.Tables("Asignaturas")
            DropDownList1.DataSource = dstMbrs.Tables(0)
            DropDownList1.DataTextField = "codigoAsig"
            DropDownList1.DataBind()

            Session("datos") = dstMbrs
            Session("adaptador") = dapMbrs

        Else

            dstMbrs = Session("datos")
            dapMbrs = Session("adaptador")

        End If

        Dim asignatura As String = DropDownList1.SelectedValue
        dapMbrs2 = New SqlDataAdapter("Select codigo, descripcion, hEstimadas, tipoTarea From TareaGenerica Where codAsig = '" & asignatura & "'", conClsf)
        dapMbrs2.Fill(dstMbrs2, "Tareas")
        tblMbrs2 = dstMbrs2.Tables("Tareas")

        GridView1.DataSource = dstMbrs2.Tables(0)
        GridView1.DataBind()

        Session("datos") = dstMbrs2
        Session("adaptador") = dapMbrs2

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim conClsf As SqlConnection
        conClsf = New SqlConnection(Session("ruta"))

        Dim dapMbrs As New SqlDataAdapter()
        Dim dstMbrs As New DataSet
        Dim tblMbrs As New DataTable

        Dim asignatura As String = DropDownList1.SelectedValue
        dapMbrs = New SqlDataAdapter("Select codigo, descripcion, codAsig, hEstimadas, tipoTarea, explotacion From TareaGenerica Where codAsig = '" & asignatura & "'", conClsf)
        Dim bldMbrs As New SqlCommandBuilder(dapMbrs)
        dapMbrs.Fill(dstMbrs, "Tarea")
        tblMbrs = dstMbrs.Tables("Tarea")

        Dim documentoXML As XmlDocument
        Dim nodeList As XmlNodeList
        Dim nodo As XmlNode

        documentoXML = New XmlDocument
        Try
            documentoXML.Load(Server.MapPath("/App_Data/" & DropDownList1.Text & ".xml"))
            nodeList = documentoXML.SelectNodes("/tareas/tarea")

        Catch ex As Exception
            XMLImportado.Text = "Documento no encontrado"
        End Try

        If Not XMLImportado.Text = "Documento no encontrado" Then
            Dim encontrado = False
            Dim i As Integer
            Dim primerCodigo = nodeList.Item(0).Attributes.GetNamedItem("codigo").Value
            For i = 0 To GridView1.Rows.Count - 1
                If GridView1.Rows(i).Cells(0).Text = primerCodigo Then
                    encontrado = True
                    XMLImportado.Text = "ERROR: XML ya importado"
                    Exit For
                End If
            Next

            If Not encontrado Then
                For Each nodo In nodeList
                    Dim codigo = nodo.Attributes.GetNamedItem("codigo").Value
                    Dim descripcion = nodo.ChildNodes(0).InnerText
                    Dim hEstimadas = nodo.ChildNodes(1).InnerText
                    Dim tipoTarea = nodo.ChildNodes(2).InnerText
                    Dim explotacion = nodo.ChildNodes(3).InnerText

                    Dim rowMbrs As DataRow = tblMbrs.NewRow()
                    rowMbrs("codigo") = codigo
                    rowMbrs("descripcion") = descripcion
                    rowMbrs("codAsig") = DropDownList1.SelectedValue
                    rowMbrs("hEstimadas") = hEstimadas
                    rowMbrs("tipoTarea") = tipoTarea
                    rowMbrs("explotacion") = explotacion
                    tblMbrs.Rows.Add(rowMbrs)
                Next
                dapMbrs.Update(dstMbrs, "Tarea")
                dstMbrs.AcceptChanges()
                XMLImportado.Text = "XML importado correctamente"


                Dim dapMbrs3 As New SqlDataAdapter()
                Dim dstMbrs3 As New DataSet
                Dim tblMbrs3 As New DataTable

                dapMbrs3 = New SqlDataAdapter("Select codigo, descripcion, hEstimadas, tipoTarea From TareaGenerica Where codAsig = '" & asignatura & "'", conClsf)
                dapMbrs3.Fill(dstMbrs3, "Tarea")

                GridView1.DataSource = dstMbrs3.Tables(0)
                GridView1.DataBind()
            End If
        End If

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        XMLImportado.Text = ""
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Response.Redirect("Profesor/Profesor.aspx")
        'Response.Redirect("http://hads22-04.azurewebsites.net/Profesor/Profesor.aspx")
    End Sub
End Class