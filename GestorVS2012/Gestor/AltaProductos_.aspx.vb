Imports gestorDataAcces
Imports GestorEntities

Public Class WebForm11
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.Cookies("SESSION-GESTOR") Is Nothing Or Session("idClient") Is Nothing Then
            Response.Redirect("~/Account/Login.aspx")
        End If
        If Page.IsPostBack Then

            Dim modeloP As New GestorEntities.Producto
            modeloP.codigo = txtcodigo.Text
            modeloP.descripcion = txtproducto.Text
            modeloP.precio = txtprecio.Text
            modeloP.precio2 = txtprecio2.Text
            modeloP.costo = txtcosto.Text
            modeloP.utilidad = txtUtilidad.Text
            modeloP.iva = txtIVA.Text
            modeloP.ieps = txtIEPS.Text
            modeloP.cve_provedor = drpCveProv.SelectedValue
            modeloP.unidad = drpUnidad.SelectedValue
            modeloP.fechamov = Date.Today
            modeloP.marcamov = "Alta"
            Dim negocioP As New gestorDataAcces.ProductosDAL
            Dim result As String = ""
            result = negocioP.InsertaProducto(Session("idClient"), modeloP)
            If result <> "correcto" Then
                Response.Write("Hubo un error,verifique los datos o intente mas tarde")
            ElseIf result = "correcto" Then
                Response.Redirect("ListaProductos.aspx")
            End If
        End If
    End Sub
    Private Sub LimpiarControles() 'Pendiente, porque provocaría disparar los ValidatorFiels como obligatorios
        txtcodigo.Text = ""
        txtproducto.Text = ""

    End Sub
End Class