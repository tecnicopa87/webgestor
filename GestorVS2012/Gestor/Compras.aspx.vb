Imports GestorEntities
Imports gestorDataAcces
Imports System.Data
Public Class WebForm7
    Inherits System.Web.UI.Page
    Dim ls1 As New List(Of Clientes) 'p/seleccion campos d catClientes
    Dim ck As HttpCookie 'p/condicion d ocultar/visualizar CatClientes
    Dim foo As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Request.Cookies("SESSION-GESTOR") Is Nothing Then
            Response.Redirect("../Default.aspx")
        End If
        If Session("tabGeneradas") Is Nothing Then
            Response.Redirect("Servicio.aspx")
        End If
        'ImageButton1.Attributes.Add("onClick", "javascript:return DespliegaClient();")
        ' - - -
        'VentanaReceptor.Visible = False '
        CatProductos.Visible = False
        Try
            Dim Emisor As New DatosEmpDAL
            Dim DatEmisor As New DatosEmpresa
            DatEmisor = Emisor.GetONE(Session("idClient"))
            LblNombEmp.Text = DatEmisor.Titulo
            Label7.Text = DatEmisor.Dircalle & " " & DatEmisor.noExt & ", " & DatEmisor.Colonia
        Catch ex As Exception
            'quedan valores por defecto en los labels

        End Try

        Dim Catalog As New ClientsDAL
        If Page.IsPostBack = False Then

            If Not Request.Cookies("ajax-ck") Is Nothing Then
                ' If Request.Cookies("ajax-ck").Value = "1" Then
                ObtenClientesPorClave(Request.Cookies("ajax-ck").Value)
                'End If
            End If

            ls1 = Catalog.GetALL(Trim(Session("idClient")))
            'DropDownList4.DataSource = ls1 ' el lista.Item(1)<- indice No se refiere a Columnas d datos
            DropDownList3.DataSource = ls1
            DropDownList3.DataTextField = "RFC"
            DropDownList3.DataValueField = "RFC"
            DropDownList3.DataBind()
            'If ls1.Count = 0 Then
            '    DropDownList4.Items.Add(" ") 'p producir selectedIndexchaged
            'End If
            ck = New HttpCookie("cat", "activo") '<- esto solo debe ocurrir la 1er LoadPage
            Response.Cookies.Add(ck)

            Dim consec As New VentasDAL
            Dim folmostrar As String
            folmostrar = consec.CheckConsecVnta(Session("idClient"))
            DropDownList2.Items.Add(folmostrar) ' (segun el # d facts emitidas online,registrado en tabCortes online)

            'GridView2.DataSource = SqlDataSource1
            'GridView2.DataBind() 'visualiz cat prods
            'GridView2.Visible = True

        ElseIf Page.IsPostBack = True Then
            'MsgBox("Solicitud de usuario,quedarìa cat=activo") 1er ejecutado d compilador
            'ck = New HttpCookie("cat") -*
            'ck.Value = "activo"        -* SUSPENDIDO
            'Response.SetCookie(ck)     -*
            If Request.Cookies("cat").Value = "activo" Then
                ' VentanaReceptor.Visible = True

            End If
        End If

        ' % Debo consultar tabla Facturas-idclient para mostrar folsiguiente automaticamente
        Dim conn As New Conexion
        Dim correcto As Boolean
        'correcto = conn.GenerarTablatmp '<- % Provicional xq debo eliminar contenido al terminar su factura

        If correcto = False Then
            ' Label6.Text = "No se pudo generar la tabla"
        End If
        btnIngresar.Attributes.Add("onClick", "javascript:return Validar();") ' Ojo q al cargar así un javascript, lo pedirá p cualquier nuevo asp:Button !
        btnCatProductos.Attributes.Add("onClick", "javascript:return true;") '  por eso tube que agregar ésta instrucción(no llamaba a code servidor)
        'Button3.Attributes.Add("onClick", "javascript:return ValidaFact();") ' X CAPRICHO DEL COMPILADOR NO LEE ÈSTA(<JSCRIPT EN <HEAD>)
        txtPrecio.Attributes.Add("onblur", "javascript:return CalculaImporteArticulo();")
        DropDownList3.Attributes.Add("OnSelectedIndexChanged", "javascript:return cargaClientRFC();")
    End Sub 'sender As Object, e As EventArgs
    'Protected Function 
    Protected Function ObtenClientesPorClave(ByVal cveRFC As String) As Array  '(sender As Object, e As EventArgs) <- Events son requeridos si se invoka desde control servidor

        Dim Catalog As New ClientsDAL
        Dim selectvalues As New List(Of Clientes)
        ls1 = Catalog.GetALL(Trim(Session("idClient"))) ' 

        If cveRFC <> "T" Then
            Try
                selectvalues = ls1.FindAll(Function(p) p.RFC = cveRFC)
                TextBox1.Text = selectvalues.Item(0).Nombre
                TextBox3.Text = selectvalues.Item(0).Calle
                TextBox4.Text = selectvalues.Item(0).NoExt
                TextBox11.Text = selectvalues.Item(0).Colonia
                TextBox12.Text = selectvalues.Item(0).Municipio
                ' DropDownList1.SelectedValue = selectvalues.Item(0).Estado
                TextBox14.Text = selectvalues.Item(0).CP
            Catch ex As Exception
                TextBox1.Text = " "
                TextBox3.Text = " "
                TextBox4.Text = " "
                TextBox11.Text = " "
                TextBox12.Text = " "
                TextBox14.Text = " "
                'DropDownList1.SelectedIndex = 0
            End Try
        Else 'Carga todos
            selectvalues = ls1
            DropDownList3.DataSource = ls1
            DropDownList3.DataTextField = "RFC"
            DropDownList3.DataValueField = "RFC"
            DropDownList3.DataBind()
        End If
        Return selectvalues.ToArray

    End Function
    Protected Sub DropDowm_RFC()

    End Sub

    Protected Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        Dim VntaM As New VentasDAL
        Dim iva, ieps As Decimal
        iva = Val(txtPrecio.Text) * 0.16
        ieps = 0
        Dim fmanual As Boolean
        Dim codbar As String = LblCodProd.Text
        If Len(codbar) < 2 Then
            codbar = "0001f"
        End If
        fmanual = VntaM.PreventaFactura(Session("idClient"), "001", codbar, DropDownList1.SelectedValue, txtCantidad.Text, TextBox2.Text, txtPrecio.Text, txtImporte.Text, "000", "0.0", iva, ieps) 'lista (ejemplo funciona list) (b)
        If fmanual = True Then

            Dim PreVnta As Preventa = VntaM.VisualizPrevnta(Session("idClient"), "001") 'Invoko al metodo

            'Dim ds As New DataSet
            'ds = PreVnta.Dset 'Leo su propiedad Dataset 
            GridView1.DataSource = PreVnta.Dset.Tables(0)  'ds.Tables(0)
            GridView1.DataBind()
            '
            Label8.Text = PreVnta.Importe 'leo su propiedad Importe

        End If

        'limpiar controles
        txtCantidad.Text = ""
        TextBox2.Text = ""
        txtPrecio.Text = ""
        txtImporte.Text = ""
        txtCantidad.Focus()

    End Sub

    Private Sub GridView1_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles GridView1.RowCancelingEdit
        GridView1.EditIndex = -1

    End Sub

    Private Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Edit" Then
            'MsgBox("Evento Rowcomand :Edit")
        ElseIf e.CommandName = "Select" Then
            Response.Redirect("AltaProductos.aspx")
        End If
    End Sub

    Private Sub GridView1_RowCreated(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowCreated
        e.Row.Cells(8).Visible = False
        Try
            GridView1.Columns(7).Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        Dim drv As System.Data.DataRowView
        drv = CType(e.Row.DataItem, System.Data.DataRowView)
        If e.Row.RowType = DataControlRowType.DataRow Then
            If drv IsNot Nothing Then

                For Each cell As TableCell In e.Row.Cells

                    cell.Wrap = False
                    ' e.Row.Cells(6).Visible = False

                Next
                '
            End If

        End If
    End Sub

    'Private Sub DropDownList4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList4.SelectedIndexChanged
    ' Dim Catalog As New ClientsDAL
    'Dim selectvalues As List(Of Clientes)
    ' ls1 = Catalog.GetALL(Trim(Session("idClient"))) ' <- necesario volver a llenar xq cada postback se pierde

    'If DropDownList4.SelectedItem.Value = "Nuevo RFC" Then
    '    DropDownList4.Visible = False
    '    TextBox10.Visible = True
    '    'DropDownList4.AppendDataBoundItems = True
    '    ' DropDownList4.Text = "L"
    'End If
    'Try
    '    selectvalues = ls1.FindAll(Function(p) p.RFC = DropDownList4.SelectedValue)
    '    TextBox5.Text = selectvalues.Item(0).Nombre
    '    TextBox6.Text = selectvalues.Item(0).Calle
    '    TextBox7.Text = selectvalues.Item(0).NoExt
    '    TextBox8.Text = selectvalues.Item(0).Colonia
    '    TextBox9.Text = selectvalues.Item(0).Municipio
    '    DropDownList1.SelectedValue = selectvalues.Item(0).Estado
    '    TextBox10.Text = selectvalues.Item(0).CP
    'Catch ex As Exception
    '    TextBox5.Text = " "
    '    TextBox6.Text = " "
    '    TextBox7.Text = " "
    '    TextBox8.Text = " "
    '    TextBox9.Text = " "
    '    TextBox10.Text = " "
    '    DropDownList1.SelectedIndex = 0
    'End Try
    'VentanaReceptor.Visible = True
    'End Sub

    'Private Sub GridView2_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView2.PageIndexChanging  --Antes lo detectaba bien
    '    'GridView2.PageIndex = e.NewPageIndex  --Antes lo detectaba bien
    'End Sub
    Private Sub TextBox13_TextChanged(sender As Object, e As EventArgs) Handles TextBox13.TextChanged

        BusquedaArticulo(TextBox13.Text)

    End Sub
    Private Sub BusquedaArticulo(ByVal cadenabuscar As String)

        Dim Prods As New ProductosDAL
        Dim dsP As New DataTable
        Dim existen As Integer
        dsP = Prods.CargaCatProducts(Session("idClient"), cadenabuscar)
        existen = dsP.Rows.Count
        If existen = 0 Then
            LblCargProds.Text = " No se encontrò el producto en el catalogo"
            LblCargProds.Visible = True
        Else
            CatProductos.Visible = True
            GridView2.DataSource = dsP
            GridView2.DataBind()

        End If
    End Sub

    Private Sub GridView1_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles GridView1.RowEditing
        Dim row As GridViewRow = GridView1.SelectedRow

    End Sub

    Protected Sub GridView2_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim row As GridViewRow = GridView2.SelectedRow

        Dim cod As String = Convert.ToString(GridView2.DataKeys(row.RowIndex).Value)

        txtCantidad.Text = "1"
        LblCodProd.Text = Convert.ToString(row.Cells(1).Text)
        TextBox2.Text = Convert.ToString(row.Cells(2).Text)
        txtPrecio.Text = Convert.ToDecimal(row.Cells(3).Text)
        txtImporte.Text = Convert.ToDecimal(row.Cells(3).Text) 'importe por default
    End Sub

    Protected Sub GridView1_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        If foo = True Then
            Exit Sub
        End If
        Dim ind As Integer = GridView1.EditIndex
        Dim row As GridViewRow = GridView1.Rows(ind)
        '                                (row.Cells(0)  <- contiene Actuliazr
        Dim cant As Decimal = Convert.ToDecimal(row.Cells(1).Text) 'CType((row.Cells(1).Controls(0)), TextBox).Text 'Convert.ToDecimal(row.Cells(1).Text)
        Dim und As String = CType((row.Cells(2).Controls(0)), TextBox).Text 'Convert.ToString(row.Cells(2).Text)
        Dim desc As String = CType((row.Cells(3).Controls(0)), TextBox).Text 'Convert.ToString(row.Cells(3).Text)
        Dim prec As Decimal = CType((row.Cells(4).Controls(0)), TextBox).Text 'Convert.ToDecimal(row.Cells(4).Text)
        Dim imp As Decimal = CType((row.Cells(5).Controls(0)), TextBox).Text 'Convert.ToDecimal(row.Cells(5).Text)
        Dim iva As Decimal = CType((row.Cells(6).Controls(0)), TextBox).Text 'Convert.ToDecimal(row.Cells(6).Text)
        Dim idline As Integer ' = Convert.ToInt32(row.Cells(7).Text)

        ' * Dim row1 As GridViewRow = GridView1.Rows(ind) 'GridView1.SelectedRow <-aqui devuelve nothing
        'desc = Convert.ToString(GridView1.DataKeys(row1.RowIndex).Values("descripcion"))
        idline = Convert.ToInt32(GridView1.DataKeys(row.RowIndex).Values("id"))
        'MsgBox("DataKeys:" & idline & " ,descrip:" & desc)

        Dim VntaM As New VentasDAL
        'iva = Val(TextBox3.Text) * 0.16
        Dim ieps As Decimal = 0
        Dim upd As Boolean
        upd = VntaM.UpdatePreventaFact(Session("idClient"), idline, und, cant, desc, prec, imp, iva, ieps)
        If upd = False Then
            Label6.Text = " No se pudo actualizar"
        End If
        Dim PreVnta As Preventa = VntaM.VisualizPrevnta(Session("idClient"), "01") 'Invoko al metodo

        'Dim ds As New DataSet
        'ds = PreVnta.Dset 'Leo su propiedad Dataset 
        foo = True
        GridView1.EditIndex = -1
        GridView1.DataSource = PreVnta.Dset.Tables(0)  'ds.Tables(0)
        GridView1.DataBind()
        Label8.Text = PreVnta.Importe 'leo su propiedad Importe
    End Sub


    Protected Sub GridView2_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView2.PageIndex = e.NewPageIndex
        Session("IndexPage") = e.NewPageIndex 'Necesario almacenar en session por el PostBack q realiza

    End Sub

    Protected Sub btnBuscaArticulo_Click(sender As Object, e As EventArgs) Handles btnBuscaArticulo.Click
        BusquedaArticulo(TextBox13.Text.Trim)

    End Sub

    Private Sub GridView2_DataBound(sender As Object, e As EventArgs) Handles GridView2.DataBound

    End Sub

    Private Sub GridView2_PageIndexChanged(sender As Object, e As EventArgs) Handles GridView2.PageIndexChanged
        Dim Prods As New ProductosDAL
        Dim dsP As New Data.DataTable
        'Dim existen As Integer
        dsP = Prods.CargaCatProducts(Session("idClient"), TextBox13.Text.Trim)

        GridView2.DataSource = dsP
        GridView2.DataBind()
        GridView2.PageIndex = Session("IndexPage")

    End Sub

    Private Sub GridView2_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView2.RowCommand
        If e.CommandName = "Select" Then
            Dim indice As Integer
            Try
                indice = Convert.ToInt32(e.CommandArgument)
                Dim idCol As String
                idCol = Convert.ToString(GridView2.DataKeys(indice).Value)

            Catch ex As Exception

            End Try

        End If
    End Sub


    Private Sub GridView2_SelectedIndexChanged1(sender As Object, e As EventArgs) Handles GridView2.SelectedIndexChanged
        Dim Prods As New ProductosDAL
        Dim dsP As New Data.DataTable
        Dim existen As Integer
        dsP = Prods.CargaCatProducts(Session("idClient"), TextBox13.Text.Trim)

        GridView2.DataSource = dsP
        GridView2.DataBind()
        If dsP.Rows.Count > 0 Then
            'MsgBox("obtiene datos por selected indexchaged")
        End If
        GridView2.PageIndex = Session("IndexPage")
    End Sub

    Private Sub ButtonM_Click(sender As Object, e As EventArgs) Handles ButtonM.Click

    End Sub

    'Private Sub btnCatproductos_Click(sender As Object, e As EventArgs) Handles btnCatproductos.Click

    '    Dim Prods As New ProductosDAL
    '    Dim dsP As New DataTable
    '    Dim existen As Integer
    '    dsP = Prods.CargaCatProducts(Session("idClient"), String.Empty)
    '    Try
    '        existen = dsP.Rows.Count
    '    Catch ex As Exception
    '        GridView2.DataBind()
    '        Exit Sub
    '    End Try

    '    LblCompraExitosa.Visible = False
    '    If existen = 0 Then
    '        LblCargProds.Text = "Aun no existen productos registrados"
    '        LblCargProds.ViewStateMode = True
    '    Else
    '        CatProductos.Visible = True
    '        GridView2.DataSource = dsP
    '        GridView2.DataBind()

    '    End If
    'End Sub

    Protected Sub btnCatProductos_Click(sender As Object, e As EventArgs) Handles btnCatProductos.Click

        Dim Prods As New ProductosDAL
        Dim dsP As New DataTable
        Dim existen As Integer
        dsP = Prods.CargaCatProducts(Session("idClient"), String.Empty)
        Try
            existen = dsP.Rows.Count
        Catch ex As Exception
            GridView2.DataBind()
            Exit Sub
        End Try

        LblCompraExitosa.Visible = False
        If existen = 0 Then
            LblCargProds.Text = "Aun no existen productos registrados"
            LblCargProds.ViewStateMode = True
        Else
            CatProductos.Visible = True
            GridView2.DataSource = dsP
            GridView2.DataBind()

        End If
    End Sub

End Class