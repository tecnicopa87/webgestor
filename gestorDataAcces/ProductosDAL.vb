Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports GestorEntities.Producto

'Imports System.Data.OleDb
Public Class ProductosDAL
    Dim tabProds As String

    '      Para guardado Automatico de productos en BD Online *  
    'Public Function AsignaIDProducto(ByVal session As String) As String
    '    Dim IdProdAuto As String = String.Empty

    '    Dim reg As String 'ultm cod reg
    '    Dim sig As Long
    '    tabProds = "Productos" & Trim(session)

    '    Dim Scon As New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)
    '    Dim cmd As New SqlCommand("select codigo from " & tabProds & " order by codigo desc", Scon)
    '    Dim ord As SqlDataReader = cmd.ExecuteReader

    '    If ord.Read Then
    '        reg = ord(0)
    '        sig = CLng(reg) + 1
    '        IdProdAuto = Format(sig, "###0")
    '    Else
    '        IdProdAuto = "0001"
    '    End If

    '    Return IdProdAuto

    'End Function
    Public Function CargaCatProducts(ByVal session As String, ByVal filtro As String) As DataTable
        Dim dsp As New DataTable

        Dim con As New Conexion
        Dim cadenaConexion As String
        cadenaConexion = con.ConfiguracionEmpresa(session) 'determina si local o remota

        Dim ord As SqlDataAdapter
        Dim query As String
        If cadenaConexion <> "" Then 'Consulta remota servidorCliente

            Dim Scon As New SqlConnection(cadenaConexion)
            If filtro <> "" Then
                query = "select codigo,producto,precio,costo from productos where producto like '%" & filtro & "%' order by producto asc"
                ord = New SqlDataAdapter(query, Scon)

                'dsVF = New DataSet
                ord.Fill(dsp)

            Else
                query = "select codigo,producto,precio from  productos order by producto asc"
                ord = New SqlDataAdapter(query, Scon)

                'dsVF = New DataSet
                ord.Fill(dsp)
                ' reg = dsp.Tables(0).Rows(0)(0)
            End If

        Else 'Consulta local VentaOnline
            tabProds = "Productos" & Trim(session)
            Dim Scon As New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)
            If filtro <> "" Then
                query = "select codigo,producto,precio,costo from " & tabProds & " where producto like '%" & filtro & "%' order by producto asc"
                ord = New SqlDataAdapter(query, Scon) ' ** pendiente
            Else
                query = "select codigo,producto,precio,costo from " & tabProds & " order by producto asc"
                ord = New SqlDataAdapter(query, Scon) ' ** pendiente
            End If
            'dsVF = New DataSet
            ord.Fill(dsp)

        End If

        Return dsp

    End Function
    Public Function DetalleProduct(ByVal session As String, ByVal idprod As String) As DataSet
        Dim dsp As New DataSet

        Dim con As New Conexion
        Dim cadenaConexion As String
        cadenaConexion = con.ConfiguracionEmpresa(session) 'determina su CadenadeConexion del cliente

        Dim ord As SqlDataAdapter
        Dim query As String
        If cadenaConexion = "" Then

            tabProds = "Productos" & Trim(session)
            Dim Scon As New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)

            query = "select codigo,producto,precio from " & tabProds & " where codigo=@cod order by producto asc"
            ord = New SqlDataAdapter(query, Scon) ' ** pendiente

            ord.SelectCommand.Parameters.AddWithValue("@cod", idprod)

            'dsVF = New DataSet
            ord.Fill(dsp, "Products")

        Else 'uso conexion remota
            Dim Scon As New SqlConnection(cadenaConexion)

            query = "select codigo,producto,precio,precio2,precio3,a_granel,sugerida_inventario,Cve_pro,unidad_p2,unidad_p3,costo,iva,ganancia,catalogo, " & _
                "cost_caja,precCaja,util_caja,descripCaja from productos where codigo =@codbar"
            ord = New SqlDataAdapter(query, Scon)
            ord.SelectCommand.Parameters.AddWithValue("@codbar", idprod)

            ord.Fill(dsp, "DetailsProducts")

        End If

        Return dsp

    End Function
    Public Function InsertaProducto(ByVal session As String, ByVal modeloP As GestorEntities.Producto) As String
        Dim resultado As String = ""

        Dim con As New Conexion
        Dim cadenaConexion As String
        cadenaConexion = con.ConfiguracionEmpresa(session) 'determina su CadenadeConexion del cliente

        Dim query As String
        Dim ord As SqlCommand
        Dim tran As SqlTransaction
        If cadenaConexion = "" Then
            tabProds = "Productos" & Trim(session)
            Dim Scon As New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)
            Try
                Scon.Open()                
            tran = Scon.BeginTransaction
            query = "insert into " & tabProds & " (codigo,producto,precio,precio2,Cve_Pro,a_granel,costo,ganancia,iva,ieps,fechmov,marcamov,unidad) " & _
                "values (@cod,@desc,@prec,@prec2,@cveprov,@granel,@costo,@util,@iva,@ieps,@fechmov,@mov,@unid)"
                ord = New SqlCommand(query, Scon) ' en mi base web

            ord.Parameters.AddWithValue("@cod", modeloP.codigo)
            ord.Parameters.AddWithValue("@desc", modeloP.descripcion)
            ord.Parameters.AddWithValue("@prec", modeloP.precio)
            ord.Parameters.AddWithValue("@prec2", modeloP.precio2)
            ord.Parameters.AddWithValue("@cveprov", modeloP.cve_provedor)
            ord.Parameters.AddWithValue("@granel", modeloP.a_granel)
            ord.Parameters.AddWithValue("@costo", modeloP.costo)
            ord.Parameters.AddWithValue("@util", modeloP.utilidad)
            ord.Parameters.AddWithValue("@iva", modeloP.iva)
            ord.Parameters.AddWithValue("@ieps", modeloP.ieps)
            ord.Parameters.AddWithValue("@fechmov", modeloP.fechamov)
            ord.Parameters.AddWithValue("@mov", modeloP.marcamov)
            ord.Parameters.AddWithValue("@unid", modeloP.unidad)

            ord.ExecuteNonQuery()
            tran.Commit()
            resultado = "correcto"
            Scon.Close()
            Catch ex As Exception
                tran.Rollback()
                If Scon.State = ConnectionState.Open Then
                    Scon.Close()
                End If
                resultado = ex.Message
            End Try

        Else 'uso conexion remota
            Dim Scon As New SqlConnection(cadenaConexion)
            Try
                Scon.Open()
                tran = Scon.BeginTransaction
                query = "insert into productos (codigo,producto,precio,precio2,Cve_Pro,a_granel,costo,ganancia,iva,ieps,fechmov,marcamov,unidad) " & _
                    "values (@cod,@desc,@prec,@prec2,@cveprov,@granel,@costo,@util,@iva,@ieps,@fechmov,@mov,@unid)"
                ord = New SqlCommand(query, Scon) ' ** pendiente

                ord.Parameters.AddWithValue("@cod", modeloP.codigo)
                ord.Parameters.AddWithValue("@desc", modeloP.descripcion)
                ord.Parameters.AddWithValue("@prec", modeloP.precio)
                ord.Parameters.AddWithValue("@prec2", modeloP.precio2)
                ord.Parameters.AddWithValue("@cveprov", modeloP.cve_provedor)
                ord.Parameters.AddWithValue("@granel", modeloP.a_granel)
                ord.Parameters.AddWithValue("@costo", modeloP.costo)
                ord.Parameters.AddWithValue("@util", modeloP.utilidad)
                ord.Parameters.AddWithValue("@iva", modeloP.iva)
                ord.Parameters.AddWithValue("@ieps", modeloP.ieps)
                ord.Parameters.AddWithValue("@fechmov", modeloP.fechamov)
                ord.Parameters.AddWithValue("@mov", modeloP.marcamov)
                ord.Parameters.AddWithValue("@unid", modeloP.unidad)

                ord.ExecuteNonQuery()
                tran.Commit()
                resultado = "correcto"
                Scon.Close()
            Catch ex As Exception
                tran.Rollback()
                If Scon.State = ConnectionState.Open Then
                    Scon.Close()
                End If
                resultado = ex.Message
            End Try

        End If

        Return resultado
    End Function

    Public Function Actualiza(ByVal session As String, ByVal modeloP As GestorEntities.Producto) As String
        Dim resultado As String = ""

        Dim con As New Conexion
        Dim cadenaConexion As String
        cadenaConexion = con.ConfiguracionEmpresa(session) 'determina su CadenadeConexion del cliente

        Dim query As String
        Dim ord As SqlCommand
        Dim tran As SqlTransaction
        tabProds = "Productos" & Trim(session)
        Dim Scon As New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)
        Try            
            Scon.Open()
            tran = Scon.BeginTransaction
            query = "update " & tabProds & " set producto= @desc,precio=@prec,precio2=@prec2,Cve_Prov=@cveprov,a_granel=@granel,costo=@costo,ganancia=@util,iva=@iva,ieps=@ieps,fechmov=@fechmov,marcamov=@mov,unidad=@unid)"
            ord = New SqlCommand(query, Scon) ' en mi base web

            ord.Parameters.AddWithValue("@cod", modeloP.codigo)
            ord.Parameters.AddWithValue("@desc", modeloP.descripcion)
            ord.Parameters.AddWithValue("@prec", modeloP.precio)
            ord.Parameters.AddWithValue("@prec2", modeloP.precio2)
            ord.Parameters.AddWithValue("@cveprov", modeloP.cve_provedor)
            ord.Parameters.AddWithValue("@granel", modeloP.a_granel)
            ord.Parameters.AddWithValue("@costo", modeloP.costo)
            ord.Parameters.AddWithValue("@util", modeloP.utilidad)
            ord.Parameters.AddWithValue("@iva", modeloP.iva)
            ord.Parameters.AddWithValue("@ieps", modeloP.ieps)
            ord.Parameters.AddWithValue("@fechmov", modeloP.fechamov)
            ord.Parameters.AddWithValue("@mov", modeloP.marcamov)
            ord.Parameters.AddWithValue("@unid", modeloP.unidad)

            ord.ExecuteNonQuery()
            tran.Commit()
            resultado = "correcto"
            Scon.Close()
        Catch ex As Exception
            tran.Rollback()
            If Scon.State = ConnectionState.Open Then
                Scon.Close()
            End If
            resultado = ex.Message
        End Try
       
        Return resultado

    End Function
End Class
