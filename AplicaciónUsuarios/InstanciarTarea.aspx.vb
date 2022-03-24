Imports System.Data.SqlClient

Public Class WebForm7
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim conClsf As SqlConnection
        conClsf = New SqlConnection(Session("ruta"))

        Dim dapMbrs As New SqlDataAdapter()
        Dim dstMbrs As New DataSet
        Dim tblMbrs As New DataTable

        Dim email As String = Session("email")
        Dim codTarea As String = Session("codTAreaInstanciar")
        Dim hEstimadas As String = Session("hEstimadas")

        TextBox1.Text = email
        TextBox2.Text = codTarea
        TextBox3.Text = hEstimadas

        dapMbrs = New SqlDataAdapter("Select * From EstudianteTarea Where email = '" & email & "'", conClsf)

        dapMbrs.Fill(dstMbrs, "TareasEstudiante")
        tblMbrs = dstMbrs.Tables("TareasEstudiante")

        GridView1.DataSource = dstMbrs.Tables(0)
        GridView1.DataBind()

        Session("adaptador") = dapMbrs
        Session("datos") = dstMbrs

    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Response.Redirect(“VerTareasEstudiante.aspx")
    End Sub

    Protected Sub Button1_Click1(sender As Object, e As EventArgs) Handles Button1.Click

        Dim dapMbrs = Session("adaptador")
        Dim bldMbrs As New SqlCommandBuilder(dapMbrs)

        Dim dstMbrs = Session("datos")
        Dim tblMbrs = dstMbrs.Tables("TareasEstudiante")
        Dim rowMbrs As DataRow = tblMbrs.NewRow()
        rowMbrs("email") = Session("email")
        rowMbrs("codTarea") = Session("codTareaInstanciar")
        rowMbrs("hEstimadas") = Session("hEstimadas")
        rowMbrs("hReales") = TextBox4.Text
        tblMbrs.Rows.Add(rowMbrs)

        Dim encontrado = False
        Dim texto As String = Session("codTareaInstanciar")
        Dim i As Integer

        For i = 0 To GridView1.Rows.Count - 1
            If GridView1.Rows(i).Cells(1).Text = texto Then
                encontrado = True
                TareaInstanciada.Text = "ERROR: TAREA YA INSTANCIADA"
                Exit For
            End If
        Next

        If Not encontrado Then
            dapMbrs.Update(dstMbrs, "TareasEstudiante")
            dstMbrs.AcceptChanges()
            TareaInstanciada.Text = "TAREA INSTANCIADA CORRECTAMENTE"
            GridView1.DataSource = dstMbrs.Tables(0)
            GridView1.DataBind()
        End If

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub
End Class