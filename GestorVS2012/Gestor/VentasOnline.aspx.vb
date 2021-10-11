Imports gestorDataAcces
Imports GestorEntities
Imports System.Data
Imports System.Web.Services 'Manjo metodos de ajax
Imports System.Web.Script.Serialization 'serializar el envío ajax

Public Class VentasOnline
    Inherits System.Web.UI.Page
    Dim ls1 As New List(Of Clientes) 'p/seleccion campos d catClientes
    Dim ck As HttpCookie 'p/condicion d ocultar/visualizar CatClientes
    Dim foo As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Request.Cookies("SESSION-GESTOR") Is Nothing Or Session("idClient") Is Nothing Then
            Response.Redirect("~/Account/Login.aspx")
        End If
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

            'Session("idClient") = "001" '<-   %% SOLO TESTTING    %  ? 
            If Session("tabGeneradas") Is Nothing Then
                Response.Redirect("Servicio.aspx")
            End If
            dpdwnListClient.Attributes.Add("onchange", "javascript:return cargaClient();")

            ls1 = Catalog.GetALL(Trim(Session("idClient")))
            dpdwnListClient.DataSource = ls1 ' el lista.Item(1)<- indice No se refiere a Columnas d datos
            dpdwnListClient.DataTextField = "RFC"
            dpdwnListClient.DataValueField = "RFC"
            dpdwnListClient.DataBind()            
            'dpdwnListClient.SelectedValue = -1
            Session("dpdwnCliente") = ""

            ck = New HttpCookie("cat", "activo") '<- esto solo debe ocurrir la 1er LoadPage
            Response.Cookies.Add(ck)
            ck = New HttpCookie("sessid", Session("idClient")) '<- xq webmethod no puede acceder directo a session
            Response.Cookies.Add(ck)
            Dim negocioV As New VentasDAL
            Dim folmostrar As Single
            folmostrar = negocioV.CheckConsecVnta(Session("idClient"))
            LblFolVenta.Text = CStr(folmostrar) ' (segun el # d ventas emitidas online,registrado en tabCortes online)

            Try
                drpdwnListCveUnd.DataSource = negocioV.CatalogoClaveUnid
                drpdwnListCveUnd.DataValueField = "c_ClaveUnidad"
                drpdwnListCveUnd.DataTextField = "Descripcion"
            Catch ex As Exception
                drpdwnListCveUnd.DataSource = Nothing
            End Try
            drpdwnListCveUnd.DataBind()
            'GridView2.DataSource = SqlDataSource1
            'GridView2.DataBind() 'visualiz cat prods
            'GridView2.Visible = True

        ElseIf Page.IsPostBack = True Then
            'MsgBox("Solicitud de usuario,quedarìa cat=activo") 1er ejecutado d compilador
            'ck = New HttpCookie("cat") -*
            'ck.Value = "activo"        -* SUSPENDIDO
            'Response.SetCookie(ck)     -*            
            'If Request.Cookies("catProducts").Value = "activo" Then
            '    CatProductos.Visible = True

            'End If

            Session("dpdwnCliente") = dpdwnListClient.SelectedValue
        End If

        ' % Debo consultar tabla Facturas-idclient para mostrar folsiguiente automaticamente
        Dim conn As New Conexion
        Dim correcto As Boolean
        'correcto = conn.GenerarTablatmp '<- % Provicional xq debo eliminar contenido al terminar su factura

        If correcto = False Then
            ' Label6.Text = "No se pudo generar la tabla"
        End If
        ls1 = Catalog.GetALL(Trim(Session("idClient")))
        'If Not Request.Cookies("ajax-ck") Is Nothing Then
        ' If Request.Cookies("ajax-ck").Value = "1" Then
        dpdwnListClient.DataSource = ls1 ' el lista.Item(1)<- indice No se refiere a Columnas d datos
        dpdwnListClient.DataTextField = "RFC"
        dpdwnListClient.DataValueField = "RFC"
        dpdwnListClient.DataBind()
        If Session("dpdwnCliente") <> "" Then
            dpdwnListClient.SelectedValue = Session("dpdwnCliente")
        Else
            dpdwnListClient.Items.Add("Nuevo RFC")
        End If
        If ls1.Count > 0 Then
            'ObtenClientesPorClave(Request.Cookies("ajax-ck").Value)                   
            Dim clie As New Clientes
            Try
                TextBox1.Text = " "
                TextBox3.Text = " "
                TextBox4.Text = " "
                TextBox11.Text = " "
                TextBox12.Text = " "
                TextBox14.Text = " "
                clie = ls1.Find(AddressOf FindRFC) '
                TextBox1.Text = clie.Nombre
                TextBox3.Text = clie.Calle
                TextBox4.Text = clie.NoExt
                TextBox11.Text = clie.Colonia
                TextBox12.Text = clie.Municipio
                TextBox14.Text = clie.CP
                TextCliente.Text = TextBox1.Text 'llena campo NombreClie
            Catch ex As Exception
                TextBox1.Text = " "
                TextBox3.Text = " "
                TextBox4.Text = " "
                TextBox11.Text = " "
                TextBox12.Text = " "
                TextBox14.Text = " "
            End Try       

        End If

        'End If
        ' -* - -* -* -

        Dim Prods As New ProductosDAL ' este xq webmethod no se invokó
        Dim dsP As New DataTable ' este xq webmethod no se invokó
        Dim existen As Integer
        dsP = Prods.CargaCatProducts(Session("idClient"), LTrim(TextBox13.Text))
        Try
            existen = dsP.Rows.Count
            If Not Request.Cookies("catProducts") Is Nothing Then
                If Request.Cookies("catProducts").Value = "activo" Then CatProductos.Visible = True
                lblEncontrados.InnerText = " " & existen
            End If
        Catch ex As Exception
            existen = 0
        End Try
        LblVentaExitosa.Visible = False
        lblEncontrados.InnerText = " " & existen
        If existen = 0 And Not Request.Cookies("catProducts") Is Nothing Then
            If Request.Cookies("catProducts").Value = "activo" Then
                LblCargProds.Text = "Aun no existen productos registrados"

            End If
            'LblCargProds.ViewStateMode = True  <-  porque  ??                                                 
        End If
        GridView2.DataSource = dsP
        GridView2.DataBind() '  este xq webmethod           
        'GridView2.ViewStateMode = UI.ViewStateMode.Enabled
        'End If
        ' End If

        '  -* -* - *- -* -*
        btnIngresar.Attributes.Add("onClick", "javascript:return Validar();") 'Ojo q al cargar d esta forma javascript, lo pedirá en cualquier asp:Button !
        BttnConfirmar.Attributes.Add("onClick", "javascript:return true;") '  por eso tube que agregar ésta instrucción(no llamaba a code servidor)
        btnCatProducts.Attributes.Add("onClick", "javascript:return true;")
        'Button3.Attributes.Add("onClick", "javascript:return ValidaFact();") ' X CAPRICHO DEL COMPILADOR NO LEE ÈSTA(<JSCRIPT EN <HEAD>)
        txtPrecio.Attributes.Add("onblur", "javascript:return CalculaImporteArticulo();")

    End Sub

    Protected Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        Dim VntaM As New VentasDAL
        Dim iva, ieps, utilid As Decimal
        iva = Val(txtPrecio.Text) * 0.16
        ieps = 0
        utilid = 0 '#Calculo utilid es realizado en metodo GuardaVentaOnline
        Dim fmanual As Boolean
        Dim codbar As String = LblCodProd.Text
        If Len(codbar) < 2 Then
            codbar = "0001f"
            'utilid = Val(txtPrecio.Text) / 1.3
        End If
        fmanual = VntaM.PreventaFactura(Session("idClient"), LblFolVenta.Text, codbar, DropDownList1.SelectedValue, txtCantidad.Text, TextBox2.Text, txtPrecio.Text, txtImporte.Text, "000", "0.0", iva, ieps) 'lista (ejemplo funciona list) (b)
        If fmanual = True Then

            Dim PreVnta As Preventa = VntaM.VisualizPrevnta(Session("idClient"), LblFolVenta.Text) 'Invoko al metodo

            'Dim ds As New DataSet
            'ds = PreVnta.Dset 'Leo su propiedad Dataset 
            ''GridView1.DataSource = PreVnta.Dset.Tables(0)  'ds.Tables(0)  -era el correspondiente
            ''GridView1.DataBind()   -  - -  
            GridViewTmp.DataSource = PreVnta.Dset.Tables(0)
            GridViewTmp.DataBind()

            LblTotal.Text = PreVnta.Importe 'leo su propiedad Importe

        End If

        'limpiar controles
        txtCantidad.Text = ""
        TextBox2.Text = ""
        txtPrecio.Text = ""
        txtImporte.Text = ""
        txtCantidad.Focus()
    End Sub
    'Protected Sub btnCatProducts_Click(sender As Object, e As EventArgs)
    ' 
    'End Sub
    

    'Private Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
    '    Dim row As GridViewRow = GridView2.SelectedRow

    '    Dim cod As String = Convert.ToString(GridView2.DataKeys(row.RowIndex).Value)

    '    txtCantidad.Text = "1"
    '    LblCodProd.Text = Convert.ToString(row.Cells(1).Text)
    '    TextBox2.Text = Convert.ToString(row.Cells(2).Text)
    '    txtPrecio.Text = Convert.ToDecimal(row.Cells(3).Text)
    '    txtImporte.Text = Convert.ToDecimal(row.Cells(3).Text) 'importe por default
    'End Sub

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
            ' CatProductos.Visible = True
            GridView2.DataSource = dsP
            GridView2.DataBind()

        End If
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
    Protected Sub GridView2_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView2.PageIndex = e.NewPageIndex
        Session("IndexPage") = e.NewPageIndex 'Necesario almacenar en session por el PostBack q realiza

    End Sub

    Private Sub GridViewTmp_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles GridViewTmp.RowCancelingEdit
        GridViewTmp.EditIndex = -1
    End Sub

    Private Sub GridViewTmp_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridViewTmp.RowCommand
        '1) Ejecucion compilador
        If e.CommandName = "Edit" Then
            MsgBox("Entra rowcommand Editar")
        ElseIf e.CommandName = "Delete" Then
            '.OnClientClick = "if (!window.confirm('Are you sure you want to delete this item?')) return false;"
        End If
    End Sub

    Private Sub GridViewTmp_RowCreated(sender As Object, e As GridViewRowEventArgs) Handles GridViewTmp.RowCreated
        Try
            GridViewTmp.Columns(8).Visible = False
            GridViewTmp.Columns(9).Visible = False

        Catch ex As Exception
            e.Row.Cells(8).Visible = False ' Previamente definidas DataKeys
            e.Row.Cells(9).Visible = False
        End Try
       
    End Sub
   
    Private Sub GridViewTmp_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridViewTmp.RowDataBound

        If Not (e.Row.RowType = DataControlRowType.DataRow) Then Return

        Dim dvr As System.Data.DataRowView
        dvr = CType(e.Row.DataItem, System.Data.DataRowView)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            If dvr IsNot Nothing Then
                'Dim lastCellIndex As Int32
                'lastCellIndex = -1 'e.Row.Cells.Count - 1
                'ImageButton deleteButton = (ImageButton) e.Row.Cells[lastCellIndex].Controls[0];
                'deleteButton.OnClientClick =
                'CType((row.Cells(2).Controls(0)), TextBox).Text
                For Each cell As TableCell In e.Row.Cells
                    'lastCellIndex += 1
                    'Dim CellText As TextBox
                    Dim cmdDelete As LinkButton = e.Row.Cells(0).Controls(0)
                    cmdDelete.OnClientClick = "if (!window.confirm('Esta seguro de quitar este actículo ?')) return false;"
                    'Dim c As String
                    ' c = cmdDelete.Text
                    'Try
                    '    c = CType(e.Row.Cells(lastCellIndex).Controls(0), LinkButton).Text
                    '    c = CType(e.Row.Cells(lastCellIndex).Controls(1), LinkButton).Text <- Jamás toma Control(1)
                    'Catch ex As Exception
                    '    Try
                    '        c = CType(e.Row.Cells(lastCellIndex).Controls(1), TextBox).Text
                    '    Catch ex2 As Exception
                    '        c = e.Row.Cells(lastCellIndex).Text '<- Extrañamente cells(0) siempre es vacío
                    '    End Try
                    'End Try
                    e.Row.Cells(8).Visible = False
                    e.Row.Cells(9).Visible = False
                    'cell.Wrap = False
                    e.Row.Cells(1).ControlStyle.CssClass = ".center"
                    e.Row.Cells(2).ControlStyle.CssClass = ".center"
                Next
            End If
        End If

    End Sub

    Private Sub GridViewTmp_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles GridViewTmp.RowDeleting
        'Pendiente venta modal
        'If foo = True Then
        '    Dim VntaEliminaR As New VentasDAL
        '    Dim PreVntaN As Preventa = VntaEliminaR.VisualizPrevnta(Session("idClient"), "1") 'Invoko al metodo
        '    GridViewTmp.EditIndex = -1
        '    GridViewTmp.DataSource = PreVntaN.Dset.Tables(0)  'ds.Tables(0)
        '    GridViewTmp.DataBind()
        '    Label8.Text = PreVntaN.Importe 'actualizo total leyendo propiedad Importe
        '    Exit Sub
        'End If
        'Dim row As GridViewRow = GridViewTmp.SelectedRow
        Dim Idline As String = Convert.ToString(GridViewTmp.DataKeys(e.RowIndex).Values("id"))
        '( Idline es distinto a codigo del producto así está definido en capa datos)
        Dim VntaElimina As New VentasDAL

        If VntaElimina.DeletePreventaFact(Session("idClient"), Idline) Then

            Dim PreVnta As Preventa = VntaElimina.VisualizPrevnta(Session("idClient"), LblFolVenta.Text) 'Invoko al metodo(idUsuario, Folticket)
            GridViewTmp.EditIndex = -1
            GridViewTmp.DataSource = PreVnta.Dset.Tables(0)  'ds.Tables(0)
            GridViewTmp.DataBind()
            LblTotal.Text = PreVnta.Importe 'actualizo total leyendo propiedad Importe
            foo = True
        Else
            MsgBox("No se puedo eliminar la fila, indique folio y codigo al Administrador")

        End If
    End Sub

    Private Sub GridViewTmp_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles GridViewTmp.RowEditing
        '2) Ejecucion compilador (lo pide obligatorio)
        'Dim row As GridViewRow = GridViewTmp.SelectedRow
        GridViewTmp.EditIndex = e.NewEditIndex
    End Sub

    Private Sub GridViewTmp_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles GridViewTmp.RowUpdating
        If foo = True Then
            Exit Sub
        End If
        Dim ind As Integer = GridViewTmp.EditIndex
        Dim row As GridViewRow = GridViewTmp.Rows(ind)
        '                                (row.Cells(0)  <- contiene Actuliazr
        Dim cant As Decimal = Convert.ToDecimal(row.Cells(1).Text) 'CType((row.Cells(1).Controls(0)), TextBox).Text 'Convert.ToDecimal(row.Cells(1).Text)
        Dim und As String = CType((row.Cells(2).Controls(0)), TextBox).Text 'Convert.ToString(row.Cells(2).Text)
        Dim desc As String = CType((row.Cells(3).Controls(0)), TextBox).Text 'Convert.ToString(row.Cells(3).Text)
        Dim prec As Decimal = CType((row.Cells(4).Controls(0)), TextBox).Text 'Convert.ToDecimal(row.Cells(4).Text)
        Dim imp As Decimal = CType((row.Cells(5).Controls(0)), TextBox).Text 'Convert.ToDecimal(row.Cells(5).Text)
        Dim iva As Decimal = CType((row.Cells(6).Controls(0)), TextBox).Text 'Convert.ToDecimal(row.Cells(6).Text)
        Dim idline As Integer ' = Convert.ToInt32(row.Cells(7).Text)


        idline = Convert.ToInt32(GridViewTmp.DataKeys(row.RowIndex).Values("id"))

        Dim VntaM As New VentasDAL
        'iva = Val(TextBox3.Text) * 0.16
        Dim ieps As Decimal = 0
        Dim upd As Boolean
        upd = VntaM.UpdatePreventaFact(Session("idClient"), idline, und, cant, desc, prec, imp, iva, ieps)
        If upd = False Then
            Label6.Text = " No se pudo actualizar"
        End If
        Dim PreVnta As Preventa = VntaM.VisualizPrevnta(Session("idClient"), LblFolVenta.Text) 'Invoko al metodo

        'ds = PreVnta.Dset 'Leo su propiedad Dataset 
        foo = True
        GridViewTmp.EditIndex = -1
        GridViewTmp.DataSource = PreVnta.Dset.Tables(0)  'ds.Tables(0)
        GridViewTmp.DataBind()
        LblTotal.Text = PreVnta.Importe 'leo su propiedad Importe
    End Sub
    <WebMethod()>
    Public Shared Function ObtenClientesPorClave(ByVal cveRFC As String, ByVal sessionid As String) As String   '(sender As Object, e As EventArgs) <- Events son requeridos si se invoka desde control servidor

        Dim Catalog As New ClientsDAL
        Dim selectvalues As New List(Of Clientes) 'p/seleccion campos d catClientes 
        Dim lst As New List(Of Clientes)
        lst = Catalog.GetALL(Trim(sessionid)) '         

        If cveRFC <> "Clients" Then
            Try

                selectvalues = lst.FindAll(Function(p) p.RFC.Trim = cveRFC.Trim)
                'clie = ls1.Find(AddressOf FindRFC) 'ls1.Where(Function(c) c.RFC = cveRFC)

            Catch ex As Exception
                MsgBox("error en webmethod " & ex.Message)
            End Try
        Else 'Carga todos
            selectvalues = lst

        End If
        Dim serializer As New JavaScriptSerializer()
        Dim arrayJson As String = serializer.Serialize(selectvalues.ToArray)
        Return arrayJson

    End Function
    Private Function FindRFC(ByVal cli As Clientes) As Boolean
        If cli.RFC.Trim = Request.Cookies("ajax-ck").Value Then
            Return True
        Else
            Return False
        End If
    End Function
    '[System].Web.Services.WebMethod]
    <WebMethod()>
    Public Function btnCatProducts_Click() As Array

        Dim Prods As New ProductosDAL
        Dim dsP As New DataTable
        Dim existen As Integer
        dsP = Prods.CargaCatProducts(Session("idClient"), String.Empty)
        Try
            existen = dsP.Rows.Count
        Catch ex As Exception
            existen = 0
        End Try

        LblVentaExitosa.Visible = False
        If existen = 0 Then
            LblCargProds.Text = "Aun no existen productos registrados"
            'LblCargProds.ViewStateMode = True  <-  porque  ??
        Else
            'CatProductos.Visible = True
            'GridView2.DataSource = dsP   <- descomentar en caso d n vincular call ajax
            'GridView2.DataBind() <- descomentar en caso  ...........no ajax

        End If
        Dim fila As Integer = 0
        Dim i As Int64 = dsP.Rows.Count
        Dim MiArray(i) As String
        For Each row In dsP.Rows
            ' ReDim Preserve MiArray("codigo:" & row("codigo").ToString & ",producto:" & row("producto").ToString & ",precio:" & row("precio").ToString)
            MiArray(fila) = ("codigo:" & row("codigo").ToString & ",producto:" & row("producto").ToString & ",precio:" & row("precio").ToString)
            fila += 1
        Next

        Return MiArray
    End Function
    '<WebMethod()>
    'Public Shared Sub BbtServidor_ServerClick(sender As Object, e As EventArgs)
    '    MsgBox("codigo admin servidor")
    'End Sub

    Private Sub dpdwnListClient_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dpdwnListClient.SelectedIndexChanged
        'Dim clieItms() As String
        'Dim client As New Clientes
        'Dim clieItms As Array 
        ' clieItms = ObtenClientesPorClave(dpdwnListClient.SelectedValue, Session("idClient")) ' <- Devuelve un tipo Array

        'For Each itm As Clientes In clieItms '<- Se debe recorrer con tipo de clase Clientes
        '    ' client.Nombre = itm.Nombre           
        '    TextBox1.Text = itm.Nombre
        '    TextBox3.Text = itm.Calle
        '    TextBox4.Text = itm.NoExt
        '    TextBox11.Text = itm.Colonia
        '    TextBox12.Text = itm.Municipio
        '    TextBox14.Text = itm.CP
        '    TextCliente.Text = itm.Nombre  'llena campo NombreClie
        'Next      
        'catClients.Visible = True

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        TextCliente.Text = TextBox1.Text 'Fué asignado en ventana modal
        If Not Request.Cookies("catProducts") Is Nothing Then
            Request.Cookies.Remove("catProducts")
        End If
    End Sub

    Private Sub TextBox13_TextChanged(sender As Object, e As EventArgs) Handles TextBox13.TextChanged
        'CatProductos.Visible = True
        'Try
        '    Response.Write("<script language=javascript>function Triger(){ var objbtn = document.getElementById('btnCatProducts'); objbtn.click(); }</script>")
        'Catch ex As Exception
        '    Response.Write("<script language=javascript>var objbtn = document.getElementById('btnCatProducts'); objbtn.click();</script>")
        'End Try
        ' Response.Write("<script language=javascript>function Triger(){ ClickAuto(); }</script>")
        '
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Function GetCurrentTime(ByVal name As String) As String
        Return "Hola " & name & Environment.NewLine & "The Current Time is: " & _
                 DateTime.Now.ToString()
    End Function

    Protected Sub BttnConfirmar_Click(sender As Object, e As EventArgs) Handles BttnConfirmar.Click

        Dim modelCabezal As New GestorEntities.CabezalVenta
        Dim modelDetalle As New List(Of GestorEntities.LineasDetalleVenta)
        Dim negocioEmp As New DatosEmpDAL 'Para datos de usuario
        Dim modelEmp As New GestorEntities.DatosEmpresa
        modelEmp = negocioEmp.GetONE(Session("idClient"))

        modelCabezal.FolVenta = CInt(LblFolVenta.Text)
        modelCabezal.Monto = CDec(LblTotal.Text)
        modelCabezal.FechaRealizacion = Date.Now
        modelCabezal.Usuario = modelEmp.seudonimo '*
        Dim Totiva, Totieps As Decimal
        For Each gvVenta As GridViewRow In GridViewTmp.Rows
            Dim model As New GestorEntities.LineasDetalleVenta
            model.no_ticket = CInt(LblFolVenta.Text)
            model.unidad = gvVenta.Cells(2).Text
            model.cantidad = Convert.ToDecimal(gvVenta.Cells(1).Text)
            model.descripcion = gvVenta.Cells(3).Text
            model.precio = Convert.ToDecimal(gvVenta.Cells(4).Text)
            model.importe = Convert.ToDecimal(gvVenta.Cells(5).Text)
            model.maquina = Request.ServerVariables("REMOTE_ADDR")
            model.cve_pro = "000" ' agregar  !!!!!!!!!!!!!
            model.descto = 0
            model.iva_aplic = Convert.ToDecimal(gvVenta.Cells(6).Text)
            model.ieps_aplic = Convert.ToDecimal(gvVenta.Cells(7).Text)
            model.codigo = gvVenta.Cells(9).Text

            Totiva += model.iva_aplic
            Totieps += model.ieps_aplic
            modelDetalle.Add(model)
        Next
        modelCabezal.Totiva = Totiva
        modelCabezal.Totieps = Totieps

        Dim negocioVentas As New VentasDAL
        Dim Guardado As String
        'Try
        Guardado = negocioVentas.GuardaVentaOnline(Session("idClient"), modelCabezal, modelDetalle)
        If Guardado = "correcto" Then
            LblVentaExitosa.Visible = True
            GridViewTmp.DataSource = Nothing
            GridViewTmp.DataBind()
            LblTotal.Text = "0.00"
            Dim negocioV As New VentasDAL
            Dim folmostrar As Single
            folmostrar = negocioV.CheckConsecVnta(Session("idClient"))
            LblFolVenta.Text = CStr(folmostrar) ' (muestro consecutivo de venta
        Else
            MsgBox("Error al guardar, " & Guardado)
            LblCargProds.Text = "Ocurrió un error ."
            LblCargProds.Visible = True
        End If
        'Catch ex As Exception
        
        ' End Try

    End Sub

    Private Sub btnCatProducts_Click1(sender As Object, e As EventArgs) Handles btnCatProducts.Click
        CatProductos.Visible = True
        ck = New HttpCookie("catProducts", "activo")
        Response.Cookies.Add(ck)
    End Sub

    Private Sub GridView2_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView2.RowCommand
        If e.CommandName = "Select" Then
            Dim nck As HttpCookie
            nck = Request.Cookies("catProducts")
            nck.Values.Set("catProducts", "inactivo")
            Response.Cookies.Set(nck)
            CatProductos.Visible = False
        End If
    End Sub

End Class