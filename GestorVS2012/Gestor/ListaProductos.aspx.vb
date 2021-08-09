Imports gestorDataAcces
Imports GestorEntities

Public Class WebForm2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.Cookies("SESSION-GESTOR") Is Nothing Then
            Response.Redirect("../Default.aspx") ' 
        End If
        If Session("tabGeneradas") Is Nothing Then
            Response.Redirect("Servicio.aspx")
        End If
        LblResult.Visible = False
        Dim Emisor As New DatosEmpDAL
        Dim DatEmisor As New DatosEmpresa
        DatEmisor = Emisor.GetONE(Session("idClient"))
        LblNombEmp.Text = DatEmisor.Titulo
        If Page.IsPostBack = False Then

            Dim Prods As New ProductosDAL
            Dim dsP As New Data.DataTable
            Dim existen As Integer
            dsP = Prods.CargaCatProducts(Session("idClient"), String.Empty)
            existen = dsP.Rows.Count
            If existen = 0 Then
                LblResult.Text = "Aun no existen productos registrados"
                LblResult.Visible = True
            Else

                GridView1.DataSource = dsP
                GridView1.DataBind()

            End If
        End If

    End Sub

    Protected Sub GridView1_PageIndexChanged(sender As Object, e As EventArgs) Handles GridView1.PageIndexChanged
        'GridView1.PageIndex = e.NewPageIndex<-- Propiedad no disponible !
        Dim Prods As New ProductosDAL
        Dim dsP As New Data.DataTable
        'Dim existen As Integer
        dsP = Prods.CargaCatProducts(Session("idClient"), TextBox1.Text)

        GridView1.DataSource = dsP
        GridView1.DataBind()
        GridView1.PageIndex = Session("IndexPage")

    End Sub
    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Dim row As GridViewRow = GridView1.SelectedRow
        Dim codbar As String = Convert.ToString(GridView1.DataKeys(row.RowIndex).Value)
        'Dim ind As Integer = GridView1.EditIndex + 1
        'Dim row As GridViewRow = GridView1.Rows(ind)
        GridView1.SelectedIndex = row.RowIndex
        'Dim codbar As String = Convert.ToString(GridView1.DataKeys(row.RowIndex).Value)
        Dim detalle As New ProductosDAL
        Dim dsp As New Data.DataSet

        Try
            dsp = detalle.DetalleProduct(Session("idClient"), codbar)
            DetailsView1.DataSource = dsp.Tables(0).DefaultView
            DetailsView1.DataBind()
            DetailsView1.DataBind()

        Catch ex As Exception
            LblResult.Text = "No se pudieron cargar datos, verifique su conexion a internet"
            LblResult.Visible = True
        End Try
    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        Session("IndexPage") = e.NewPageIndex
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim Prods As New ProductosDAL
        Dim dsP As New Data.DataTable
        Dim existen As Integer
        dsP = Prods.CargaCatProducts(Session("idClient"), TextBox1.Text)
        existen = dsP.Rows.Count
        If existen = 0 Then
            LblResult.Text = "No se encontraron productos con esta descripcion"
            LblResult.Visible = True
        Else
            GridView1.DataSource = dsP
            GridView1.DataBind()
            GridView1.PageIndex = Session("IndexPage")
            DetailsView1.DataBind()

        End If
    End Sub
    Protected Sub DetailsView1_ItemUpdated(sender As Object, e As DetailsViewUpdatedEventArgs) Handles DetailsView1.ItemUpdated

    End Sub

   
End Class