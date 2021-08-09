Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.ComponentModel

Imports GestorEntities
Public Class FacturasDAL    
    Private tbfact, tabProds As String 'tbfact =depende  de Empresa cada una tiene un sufijo

    Public Function AsignaFolioSerieFact(ByVal idclient As String, ByVal tipoAcces As Char) As String
        Dim Arreglostr As String = String.Empty

        Dim con As New Conexion
        Dim cadenaConexion As String
        cadenaConexion = con.ConfiguracionEmpresa(idclient)

        Dim FolFact As String 'contener folio formato(003)
        Dim Serie As String

        If tipoAcces = "L" Then 'Servidor Local
            tbfact = "Facturas" & Trim(idclient)

            Using conn As New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)

                Dim folio_factura As String
                folio_factura = "select folio,serie from " & tbfact & " order by folio desc"
                Dim rep = New SqlDataAdapter(folio_factura, conn)

                Dim dsf = New DataSet
                rep.Fill(dsf, tbfact)

                'EXTRAIGO ULTIMO FolioUtilizado
                Try
                    Dim fols As String '
                    fols = dsf.Tables(tbfact).Rows(0)(0)
                    FolFact = Format(fols + 1, "000")
                    Serie = dsf.Tables(tbfact).Rows(0)(1)
                    Arreglostr = FolFact & "|" & Serie
                    'ProcesFacturacion = True *<- debo declarar en un ModuleFactura ambito Global
                Catch ex As Exception
                    'response.("No se han registrado folios de factura,Debe configurarlos en el módulo Facturacion")
                    Arreglostr = Nothing
                End Try
            End Using
        ElseIf tipoAcces = "R" Then 'Servidor remoto
            tbfact = "Facturas"

            Using conn As New SqlConnection(cadenaConexion)

                Dim folio_factura As String
                folio_factura = "select foliofact,serie from " & tbfact & " order by foliofact desc"
                Dim rep = New SqlDataAdapter(folio_factura, conn)

                Dim dsf = New DataSet
                rep.Fill(dsf, tbfact)

                'EXTRAIGO ULTIMO FolioUtilizado
                Try
                    Dim fols As String '
                    fols = dsf.Tables(tbfact).Rows(0)(0)
                    FolFact = Format(fols + 1, "000")
                    Serie = dsf.Tables(tbfact).Rows(0)(1)
                    Arreglostr = FolFact & "|" & Serie
                    'ProcesFacturacion = True *<- debo declarar en un ModuleFactura ambito Global
                Catch ex As Exception
                    'response.("No se han registrado folios de factura,Debe configurarlos en el módulo Facturacion")
                    Arreglostr = Nothing
                End Try
            End Using
        End If

        Return Arreglostr  '(FolFact | serie)

    End Function
    '' * * * Guardado General Encabezado Factura  * * *
    Function GuardCabezalFactura(ByVal idclient As String, ByVal Encabezado As Facturas) As Boolean
        Dim proc As Boolean = False
        'Dim scope As Integer
        Dim TabFacts As String '<-
        TabFacts = "Facturas" & idclient

        Using conn As New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)
            Try
                Dim sqlEncabezadoFactura As String = "INSERT INTO " & TabFacts & " (folio,serie,fechaEmision,monto,condiciones,fol_Autoriz,TpoCmpvte,folvnta) " & _
                                                               "VALUES (@factid,@serie,@fecha,@montofactura,@condicion,@FAutoriz,@TCmpvte,@folvnta) " & _
                                                             "SELECT SCOPE_IDENTITY()" ' <-
                Dim cmd As New SqlCommand(sqlEncabezadoFactura, conn)
                cmd.Parameters.AddWithValue("@factid", Encabezado.folio)
                cmd.Parameters.AddWithValue("@serie", Encabezado.serie)
                cmd.Parameters.AddWithValue("@fecha", Encabezado.fecha)
                cmd.Parameters.AddWithValue("@montofactura", Encabezado.monto)
                cmd.Parameters.AddWithValue("@condicion", Encabezado.condicion)
                cmd.Parameters.AddWithValue("@FAutoriz", Encabezado.fol_Autoriz)
                cmd.Parameters.AddWithValue("@TCmpvte", Encabezado.TpoCmpvte)
                cmd.Parameters.AddWithValue("@folvnta", Encabezado.folvnta)
                conn.Open()
                cmd.ExecuteNonQuery()

                '
                proc = True '  Guardó exitoso

            Catch ex As Exception
                proc = False
            End Try

        End Using

        Return proc

    End Function
    Function GuardLineasFactura(ByVal idclient As String, ByVal lineasfacturadas As Facturas) As Boolean
        Dim proc As Boolean = False
        'Dim scope As Integer
        Dim tbdetalleFacts As String '<- provisional aqui(debe ser global ..)
        tbdetalleFacts = "Ventas" & idclient ' * * * Esto aplicarìa exclusivo a facturas Online * * *
       
        Using conn As New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)
            Try
                Dim sqlLineaFactura As String = "INSERT INTO " & tbdetalleFacts & " (no_ticket,unidad, descripcion,precio,importe,cantidad,maquina,cve_pro,iva_aplic,ieps_aplic,edo_fact) " & _
                                                               "VALUES (@factid, @unid, @descrip,@prec,@import,@cant,@maquina,@cvepro,@iva,@ieps,@edo) " & _
                                                             "SELECT SCOPE_IDENTITY()" ' <-
                'Dim cmd As New SqlCommand(sqlLineaFactura, conn)
                conn.Open()

                Dim markfact As String = "facturado"
                Dim maq As String = "webserv"
                'Dim IVenta As New List(Of LineasFactura)   '-Factura.Lineasdefactura-
                For Each detalleLine As LineasFactura In lineasfacturadas.Lineasfact    'IVenta
                    '                as   Clasefija   in   coleccion
                    Dim cmd As New SqlCommand(sqlLineaFactura, conn)

                    cmd.Parameters.AddWithValue("@factid", detalleLine.no_ticket)
                    cmd.Parameters.AddWithValue("@unid", detalleLine.unidad)
                    cmd.Parameters.AddWithValue("@descrip", detalleLine.descripcion)
                    cmd.Parameters.AddWithValue("@prec", detalleLine.precio)
                    cmd.Parameters.AddWithValue("@import", detalleLine.importe)
                    cmd.Parameters.AddWithValue("@cant", detalleLine.cantidad)
                    cmd.Parameters.AddWithValue("@maquina", maq) 'detalleLine.maquina)
                    cmd.Parameters.AddWithValue("@cvepro", detalleLine.cve_pro)
                    cmd.Parameters.AddWithValue("@iva", detalleLine.iva_aplic)
                    cmd.Parameters.AddWithValue("@ieps", detalleLine.ieps_aplic)
                    cmd.Parameters.AddWithValue("@edo", markfact)

                    ' Si bien obtenermos el id de linea de factura, este no es usado
                    ' en la aplicacion
                    'invoiceLine.InvoiceLineId = Convert.ToInt32(cmd.ExecuteScalar())                

                    'scope = cmd.ExecuteScalar()
                    'detalleLine.no_ventas = 'Convert.ToInt32(cmd.ExecuteScalar) '<-Ejecuta y devuelve primera fila
                    cmd.ExecuteNonQuery()   '  <-Ejecuta y no devuelve filas            

                Next
                proc = True '  Guardó exitoso

            Catch ex As Exception
                proc = False
            End Try
           
        End Using

        Return proc

    End Function
    Function ActualizaLineasFacturaRemota(ByVal idclient As String, ByVal idFact As String, ByVal linsfacturadas As Facturas) As String  ' linsfacturadas *w
        Dim updateRemot As String = String.Empty

        Dim tbdetalleVntas As String
        tbdetalleVntas = "detalleVntas" '* * * Esto aplicarìa exclusivo a facturas remotas(TPV) * * *

        Dim cn As New Conexion
        Dim CadenaConectRemot As String
        CadenaConectRemot = cn.ConfiguracionEmpresa(idclient)

        Dim str, corect As String
        corect = " "
        Try
            Using conn As New SqlConnection(CadenaConectRemot)
                conn.Open()
                'Unicamente marcar detalle como facturado                                    *en realidad es folventa
                Dim sqlLineaFactura As String = "update " & tbdetalleVntas & " set edo_tiket=@correcto where no_ticket=@fact_id "

                Dim cmd As New SqlCommand(sqlLineaFactura, conn)

                cmd.Parameters.AddWithValue("@correcto", corect)
                cmd.Parameters.AddWithValue("@fact_id", idFact)

                'Dim IVenta As IEnumerable(Of LineasFactura) -*w el sig Bucle funciona, pero ya no es necesario -*
                '*w For Each detalleLine As LineasFactura In linsfacturadas.Lineasfact 'IVenta

                '  detalleLine.no_ticket
                'detalleLine.importe
                'detalleLine .ieps_aplic 
                ' Si bien obtenermos el id de linea de factura, este no es usado
                ' en la aplicacion
                'invoiceLine.InvoiceLineId = Convert.ToInt32(cmd.ExecuteScalar())
                '*w str = str & "|" & detalleLine.cantidad & "|" & detalleLine.unidad & "|" & detalleLine.descripcion & "|" & detalleLine.precio
                '*w detalleLine.no_ventas = Convert.ToInt32(cmd.ExecuteScalar) '<-Ejecuta y devuelve primera fila
                '           podrìa ser :        cmd.ExecuteNonQuery()     <-Ejecuta y no devuelve filas            

                '*w Next

                '*w Return str
                cmd.ExecuteNonQuery()

            End Using
        Catch ex As Exception
            updateRemot = "No se actualizaron lineasfact remotas"
        End Try

        ' - Respaldo operacion en servidor Online
        Dim tbdetalleFacts As String
        tbdetalleFacts = "Ventas" & idclient
        Try
            Using conn As New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)
                conn.Open()
                Dim sqlLineaFactura As String = "INSERT INTO " & tbdetalleFacts & " (folfact,unidad, cantidad, descripcion,precio,importe,cvepro) " & _
                                                    "VALUES (@fact_id, @unid, @cant, @descrip) " & _
                                                    "SELECT SCOPE_IDENTITY()"

                '* * * Esto aplicarìa exclusivo a facturas remotas(TPV) * * *

                For Each detalleLine As LineasFactura In linsfacturadas.Lineasfact
                    Dim cmd As New SqlCommand(sqlLineaFactura, conn)

                    cmd.Parameters.AddWithValue("@fact_id", detalleLine.no_ticket)
                    cmd.Parameters.AddWithValue("@unid", detalleLine.unidad)
                    cmd.Parameters.AddWithValue("@cant", detalleLine.cantidad)
                    cmd.Parameters.AddWithValue("@descrip", detalleLine.descripcion)

                    cmd.ExecuteNonQuery()

                Next

                'Return str
            End Using
        Catch ex As Exception
            updateRemot = updateRemot & ",No se respaldo lineasfact online"
        End Try

        Return updateRemot
    End Function
    ' *- Este solo para usuarios online,les guardo su catalogo de productos automaticamente -*
    Public Function GuardaProdsFacturados(ByVal idClient As String, ByVal idprod As String, ByVal und As String, ByVal ct As Decimal, ByVal desc As String, ByVal prec As Decimal, ByVal prec2 As Decimal, ByVal cvePro As String, ByVal granel As Boolean, ByVal cost As Decimal, ByVal gan As Decimal, ByVal iva As Decimal, ByVal ieps As Decimal) As Boolean
        Dim exito As Boolean

        Dim Scon As New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)
        tabProds = "Productos" & Trim(idClient)
        Try
            '1) Verifico si ya existìa el producto
            Dim comand As SqlCommand = New SqlCommand("select codigo from " & tabProds & " where codigo=@idprod", Scon)
            comand.Parameters.AddWithValue("@idprod", idprod)

            Scon.Open()
            Dim reader As SqlDataReader = comand.ExecuteReader()
            If reader.Read() Then 'a)producto ya registrado


            Else 'b)Inserto el producto en tabla

                Dim cmd As SqlCommand
                Dim query As String
                query = "insert into " & tabProds & "(codigo,producto,precio,precio2,Cve_pro,a_granel,costo,ganancia,iva,ieps,unidad,existencia)" &
                "values (@idprod,@descrip,@prec,@prec2,@cve_pro,@granel,@cost,@util,@iva,@ieps,@unid,@exis) "

                cmd = New SqlCommand(query, Scon)

                cmd.Parameters.AddWithValue("@idprod", idprod)
                cmd.Parameters.AddWithValue("@descrip", desc)
                cmd.Parameters.AddWithValue("@prec", prec)
                cmd.Parameters.AddWithValue("@prec2", prec2)
                cmd.Parameters.AddWithValue("@cve_pro", cvePro)
                cmd.Parameters.AddWithValue("@granel", granel)
                cmd.Parameters.AddWithValue("@cost", cost)
                cmd.Parameters.AddWithValue("@util", gan)
                cmd.Parameters.AddWithValue("@iva", iva)
                cmd.Parameters.AddWithValue("@ieps", ieps)
                cmd.Parameters.AddWithValue("@unid", und)
                cmd.Parameters.AddWithValue("@exis", ct)

                cmd.Connection.Open()
                cmd.ExecuteNonQuery()
                cmd.Connection.Close()

            End If
            exito = True

        Catch ex As Exception
            exito = False
        End Try

        Return exito
    End Function
    Public Function BuscaCbzlFact(ByVal idclient As String, ByVal tipoBus As Char, ByVal idfol As String, Optional fechaIni As Date = Nothing, Optional fechaFin As Date = Nothing) As DataSet
        Dim dsB As DataSet = Nothing

        Dim cn As New Conexion
        Dim CadenaConectRemot As String
        CadenaConectRemot = cn.ConfiguracionEmpresa(idclient)
        Dim Scon As New SqlConnection
        If CadenaConectRemot <> "" Then
            tbfact = "Facturas"
            Scon = New SqlConnection(CadenaConectRemot)
        Else
            tbfact = "Facturas" & Trim(idclient)
            Scon = New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)
            ' *-Si PTV NO MANEJA Folventa; forzozo 2 consulta ... ? 1ª\

        End If

        ' *-VALIDO QUE TIPO CONSULTA
        If tipoBus = "F" Then
            Using Scon 'conn As New SqlConnection(cadenaConexion)

                Dim folio_facturacion As String
                folio_facturacion = "select serie,fechaEmision,monto,folvnta from " & tbfact & " where folio=@fol"
                Dim rep = New SqlDataAdapter(folio_facturacion, Scon)

                rep.SelectCommand.Parameters.AddWithValue("@fol", idfol)

                dsB = New DataSet
                rep.Fill(dsB, tbfact)

            End Using
        ElseIf tipoBus = "P" Then

            ' Sept-2016 agregar busqueda para online
            '  ........................
            ' ........................

            Using Scon 'conn As New SqlConnection(cadenaConexion)

                Dim period_facturacion As String '         monto,folvnta
                period_facturacion = "select foliofact,serie,fechaEmision,MontoTotal from " & tbfact & " where fechaEmision >=@inicial and fechaEmision <=@final"
                Dim rep = New SqlDataAdapter(period_facturacion, Scon)

                rep.SelectCommand.Parameters.AddWithValue("@inicial", fechaIni)
                rep.SelectCommand.Parameters.AddWithValue("@final", fechaFin)

                dsB = New DataSet
                rep.Fill(dsB, tbfact)

            End Using

        End If

        Return dsB

    End Function
    Public Function HabilitaProcFact(ByVal idclient As String, ByVal tipoAcces As Char) As String
        Dim ProcesHabilitado As String

        Dim con As New Conexion
        Dim cadenaConexion As String
        cadenaConexion = con.ConfiguracionEmpresa(idclient)

        If tipoAcces = "L" Then 'Servidor Local *Provionalmente solo para clients Online
            tbfact = "Facturas" & Trim(idclient)

            Using conn As New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)

                'Preparo almacenamiento de Facturas
                Try
                    Dim Prefolio_fac As String
                    Dim folDefault As Integer = 0
                    Prefolio_fac = "insert into " & tbfact & "(folio,serie,fecha,TpoCmpvte,FolVenta)values(@fol,@serie,@fech,@tipo,@folv)"
                    Dim rep = New SqlCommand(Prefolio_fac, conn)

                    rep.Parameters.AddWithValue("@fol", "000")
                    rep.Parameters.AddWithValue("@serie", "A") '<- dar opcion a Usuario eliga serie*(21-marz-2016)P*
                    rep.Parameters.AddWithValue("@fech", Date.Now)
                    rep.Parameters.AddWithValue("@tipo", "previo")
                    rep.Parameters.AddWithValue("@folv", folDefault)

                    rep.Connection.Open()
                    rep.ExecuteNonQuery()
                    rep.Connection.Close()

                    ProcesHabilitado = "exitoso"
                    'ProcesFacturacion = True *<- debo declarar en un ModuleFactura ambito Global
                Catch ex As Exception
                    'response.("No se han registrado folios de factura,Debe configurarlos en el módulo Facturacion")
                    ProcesHabilitado = ex.Message
                End Try
            End Using
        End If
        Return ProcesHabilitado

    End Function
End Class
