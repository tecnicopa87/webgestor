Imports System.Collections.Generic '<- podría quitarlo solo pa ReportViewer
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports GestorEntities.LineasDetalleVenta
Imports GestorEntities.CabezalVenta
Imports System.Transactions ' se importa manual para transact paralela

Public Class VentasDAL
    Private tabVentas, tabCortes As String
    Public Function VentasAFacturar(ByVal session As String) As DataSet
        'Dim dsVF As DataSet = Nothing
        Dim dsVF = New DataSet '

        Dim con As New Conexion
        Dim cadenaConexion As String
        cadenaConexion = con.ConfiguracionEmpresa(session) 'determina si local o remota

        Dim ord As SqlDataAdapter
        Dim query, pend As String
        pend = "Fpendiente"

        If cadenaConexion = "" Then
            tabVentas = "Ventas" & Trim(session)

            'uso conexion por default
            Dim Scon As New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)
            '                                     posiblemente no requiera campos:      "tot may",descto,cve pro,iva en conect local                   
            query = "select distinct(no_ticket)as folios  from " & tabVentas & " where edo_fact=@porFacturar order by no_ticket asc "
            ord = New SqlDataAdapter(query, Scon)

            ord.SelectCommand.Parameters.AddWithValue("@porFacturar", pend)

            'dsVF = New DataSet
            ord.Fill(dsVF, tabVentas)            

        Else 'uso conexion remota
            tabVentas = "detalleVntas"

            Dim Scon As New SqlConnection(cadenaConexion) ' www.dominio.sql,00
            query = "select distinct(no_ticket) as folios from " & tabVentas & " where edo_tiket=@porFaturar order by no_ticket asc"
            ord = New SqlDataAdapter(query, Scon)

            ord.SelectCommand.Parameters.AddWithValue("@porFaturar", pend)

            'dsVF = New DataSet
            ord.Fill(dsVF, tabVentas)

        End If

        Return dsVF

    End Function

    Public Function VentaporFacturar(ByVal session As String, ByVal folio As Integer) As DataSet
        'Dim dsVF As DataSet = Nothing
        Dim dsVF = New DataSet 'no debo instanciar dentro de eventos private(if else xq aqui Datset es ambito funcion

        Dim con As New Conexion
        Dim cadenaConexion As String
        cadenaConexion = con.ConfiguracionEmpresa(session) 'determina si local o remota

        Dim ord As SqlDataAdapter
        Dim query, pend As String
        pend = "Fpendiente"

        If cadenaConexion = "" Then
            tabVentas = "Ventas" & Trim(session)

            'uso conexion por default
            Dim Scon As New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)
            '                                     posiblemente no requiera campos:      "tot may",descto,cve pro,iva en conect local                               
            query = "select cantidad,unidad,descripcion,precio,importe,tot_may as t,descto as d,cve_pro as p,iva_aplic as i,ieps_aplic as e,ahorro_client as a from " & tabVentas & " where edo_fact=@porFaturar and no_ticket=@fol "
            ord = New SqlDataAdapter(query, Scon)

            ord.SelectCommand.Parameters.AddWithValue("@porFaturar", pend)
            ord.SelectCommand.Parameters.AddWithValue("@fol", folio)

            'dsVF = New DataSet
            ord.Fill(dsVF, tabVentas)


        Else 'uso conexion remota
            tabVentas = "detalleVntas"

            Dim Scon As New SqlConnection(cadenaConexion) ' www.dominio.sql,00
            query = "select cantidad,unidad,descripcion,monto,importe,tot_may as t,descto as d,cve_pro as p,iva_aplic as i,ieps_aplic as e from " & tabVentas & " where edo_tiket=@porFaturar and no_ticket=@fol"
            ord = New SqlDataAdapter(query, Scon)

            ord.SelectCommand.Parameters.AddWithValue("@porFaturar", pend)
            ord.SelectCommand.Parameters.AddWithValue("@fol", folio)

            'dsVF = New DataSet
            ord.Fill(dsVF, tabVentas)

        End If

        Return dsVF

    End Function
    Public Function ExtraeCabezalVnta(ByVal session As String, ByVal folio As Integer) As DataSet 'De una factura pendiente
        Dim dsCV = New DataSet '

        Dim con As New Conexion
        Dim cadenaConexion As String
        cadenaConexion = con.ConfiguracionEmpresa(session) 'determina si local o remota

        Dim ord As SqlDataAdapter
        Dim reg As String 'solo p test *
        Dim query, concep As String
        concep = " venta"
        If cadenaConexion = "" Then
            tabCortes = "Cortes" & Trim(session)

            Dim Scon As New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)
            query = "select monto ,usuario,fecha from " & tabCortes & " where folVenta=@Venta_aFact"
            ord = New SqlDataAdapter(query, Scon)

            ord.SelectCommand.Parameters.AddWithValue("@Venta_aFact", folio)

            'dsVF = New DataSet
            ord.Fill(dsCV, "Ventas")
            reg = dsCV.Tables(0).Rows(0)(0)

        Else 'uso conexion remota
            tabCortes = "Cortes"

            Dim Scon As New SqlConnection(cadenaConexion)
            'Dim F_Hoy As Date = Date.Today
            Dim period As Double
            period = (Date.Today.ToOADate) - 20
            Dim Reciente As Date
            Reciente = Date.FromOADate(period)
            query = "select ventas as monto ,usuario,fecha from " & tabCortes & " where folVenta=@Venta_aFact and concepto=@unaventa and fecha>@fechRecent"
            ord = New SqlDataAdapter(query, Scon)

            ord.SelectCommand.Parameters.AddWithValue("@Venta_aFact", folio)
            ord.SelectCommand.Parameters.AddWithValue("@unaventa", " venta")
            ord.SelectCommand.Parameters.AddWithValue("@fechRecent", Reciente)
            'dsVF = New DataSet
            ord.Fill(dsCV, "Ventas")
        End If

        Return dsCV

    End Function

    Public Function PreventaFactura(ByVal IDuser As String, ByVal foltik As Integer, ByVal idprod As String, ByVal und As String, ByVal ct As Decimal, ByVal desc As String, ByVal prec As Decimal, ByVal imp As Decimal, ByVal cvePro As String, ByVal dcto As Decimal, ByVal iva As Decimal, ByVal ieps As Decimal, Optional ByVal equipo As String = "web") As Boolean
        Dim exito As Boolean

        Try
            Dim Scon As New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)
            Dim cmd As SqlCommand
            Dim query As String
            query = "insert into VntaTMP(no_ticket,codigo,unidad,cantidad,descripcion,precio,importe,fecha,maquina,cve_pro,descto,iva_aplic,ieps_aplic,idUsuario)" &
            "values (@notik,@idprod,@unid,@cant,@descrip,@prec,@import,@cve_pro,@descto,@iva,@ieps,@ID) "

            cmd = New SqlCommand(query, Scon)
            cmd.Parameters.AddWithValue("@notik", foltik)
            cmd.Parameters.AddWithValue("@idprod", idprod)
            cmd.Parameters.AddWithValue("@unid", und)
            cmd.Parameters.AddWithValue("@cant", ct)
            cmd.Parameters.AddWithValue("@descrip", desc)
            cmd.Parameters.AddWithValue("@prec", prec)
            cmd.Parameters.AddWithValue("@import", imp)
            cmd.Parameters.AddWithValue("@fecha", Date.Today)
            cmd.Parameters.AddWithValue("@maquina", equipo)
            cmd.Parameters.AddWithValue("@cve_pro", cvePro)
            cmd.Parameters.AddWithValue("@descto", dcto)
            cmd.Parameters.AddWithValue("@iva", iva)
            cmd.Parameters.AddWithValue("@ieps", ieps) '
            'cmd.Parameters.AddWithValue("@util", utilidad)
            cmd.Parameters.AddWithValue("@ID", IDuser)

            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
            cmd.Connection.Close()
            exito = True

        Catch ex As Exception
            exito = False
        End Try

        Return exito
    End Function
    Public Function UpdatePreventaFact(ByVal idUsuario As String, ByVal foltik As Integer, ByVal und As String, ByVal ct As Decimal, ByVal desc As String, ByVal prec As Decimal, ByVal imp As Decimal, ByVal iva As Decimal, ByVal ieps As Decimal) As Boolean
        Dim exito As Boolean

        Try
            Dim Scon As New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)
            Dim cmd As SqlCommand
            Dim query As String
            query = "update VntaTMP set unidad=@unid,cantidad=@cant,descripcion=@descrip,precio=@prec,importe=@import,iva_aplic=@iva where no_ventas=@fol and idUsuario=@IDUsuario "

            cmd = New SqlCommand(query, Scon)

            cmd.Parameters.AddWithValue("@unid", und)
            cmd.Parameters.AddWithValue("@cant", ct)
            cmd.Parameters.AddWithValue("@descrip", desc)
            cmd.Parameters.AddWithValue("@prec", prec)
            cmd.Parameters.AddWithValue("@import", imp)
            'cmd.Parameters.AddWithValue("@cve_pro", cvePro)
            'cmd.Parameters.AddWithValue("@descto", dcto)
            cmd.Parameters.AddWithValue("@iva", iva)
            cmd.Parameters.AddWithValue("@ieps", ieps)
            cmd.Parameters.AddWithValue("@fol", foltik)
            cmd.Parameters.AddWithValue("@IDUsuario", idUsuario)

            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
            cmd.Connection.Close()
            exito = True

        Catch ex As Exception
            exito = False
        End Try

        Return exito
    End Function
    Public Function GuardaVentaOnline(ByVal idUsuario As String, ByVal CabezalVenta As GestorEntities.CabezalVenta, ByVal lstproductos As List(Of GestorEntities.LineasDetalleVenta)) As String
        Dim Resultado As String
        Dim retorna As Integer '

        Dim modelCbzVenta As New GestorEntities.CabezalVenta
        modelCbzVenta = CabezalVenta
        Dim modelListDetalle As New List(Of GestorEntities.LineasDetalleVenta)
        modelListDetalle = lstproductos

        Dim Scon As New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)

        Try
            Using scope As New TransactionScope() ' En estos casos dnd se agrupan 2 o mas transactions,que ejecutan command independiente

                tabCortes = "Cortes" & Trim(idUsuario)
                Dim cmd As SqlCommand
                Scon.Open()

                tabVentas = "Ventas" & Trim(idUsuario)
                Dim cmdD As SqlCommand

                Dim strdetalle As String
                Dim totUtilid As Single
                For Each itm As GestorEntities.LineasDetalleVenta In modelListDetalle

                    itm.Utilidad = CalculaUtilidadProducto(itm.codigo, itm.cantidad, idUsuario)
                    totUtilid = totUtilid + itm.Utilidad '#Calulo utilidad
                    strdetalle = "insert into " & tabVentas & "(no_ticket,unidad,cantidad,descripcion,precio,importe,fecha,maquina,cve_pro,descto,iva_aplic,ieps_aplic,edo_fact,codigo,utilidad)" &
                        "values (@folvnta,@unid,@cant,@descrip,@prec,@import,@fecha,@maquina,@cve_pro,@descto,@iva,@ieps,@edofact,@codigo,@utilidad)"
                    cmdD = New SqlCommand(strdetalle, Scon)

                    cmdD.Parameters.AddWithValue("@folvnta", modelCbzVenta.FolVenta)
                    cmdD.Parameters.AddWithValue("@unid", itm.unidad)
                    cmdD.Parameters.AddWithValue("@cant", itm.cantidad)
                    cmdD.Parameters.AddWithValue("@descrip", itm.descripcion)
                    cmdD.Parameters.AddWithValue("@prec", itm.precio)
                    cmdD.Parameters.AddWithValue("@import", itm.importe)
                    cmdD.Parameters.AddWithValue("@fecha", Date.Now)
                    cmdD.Parameters.AddWithValue("@maquina", itm.maquina)
                    cmdD.Parameters.AddWithValue("@cve_pro", itm.cve_pro)
                    cmdD.Parameters.AddWithValue("@descto", itm.descto)
                    cmdD.Parameters.AddWithValue("@iva", itm.iva_aplic)
                    cmdD.Parameters.AddWithValue("@ieps", itm.ieps_aplic)
                    cmdD.Parameters.AddWithValue("@edofact", "")
                    cmdD.Parameters.AddWithValue("@codigo", itm.codigo)
                    cmdD.Parameters.AddWithValue("@utilidad", itm.Utilidad)

                    retorna = cmdD.ExecuteNonQuery()
                Next
                'Calculo de utilidad Total
                modelCbzVenta.Utilidad = totUtilid '#u
                Dim query As String
                query = "insert into " & tabCortes & "(folVenta,monto,concepto,usuario,fecha,entradas,salidas,totiva,totieps,folfactura,ventas,utilidad) " &
                    " values (@folvnta,@montovnta,@concepto,@usuario,@fecha,@entrad,@salid,@iva,@ieps,@folfact,@venta,@util) "

                cmd = New SqlCommand(query, Scon)

                cmd.Parameters.AddWithValue("@folvnta", modelCbzVenta.FolVenta)
                cmd.Parameters.AddWithValue("@montovnta", modelCbzVenta.Monto)
                cmd.Parameters.AddWithValue("@concepto", " venta") '#compatibilidad con TPV,se guardaba con espacio
                cmd.Parameters.AddWithValue("@usuario", modelCbzVenta.Usuario)
                cmd.Parameters.AddWithValue("@fecha", modelCbzVenta.FechaRealizacion)
                cmd.Parameters.AddWithValue("@entrad", DBNull.Value)
                cmd.Parameters.AddWithValue("@salid", DBNull.Value)
                cmd.Parameters.AddWithValue("@iva", modelCbzVenta.Totiva)
                cmd.Parameters.AddWithValue("@ieps", modelCbzVenta.Totieps)
                cmd.Parameters.AddWithValue("@folfact", IIf(modelCbzVenta.FolFactura Is Nothing, DBNull.Value, modelCbzVenta.FolFactura))
                cmd.Parameters.AddWithValue("@venta", modelCbzVenta.Ventas)
                cmd.Parameters.AddWithValue("@util", totUtilid) '#u Capricho de compilador no asigna al modelo

                retorna = cmd.ExecuteNonQuery()
                Resultado = "correcto"
                ' The Complete method commits the transaction. If an exception has been thrown,
                ' Complete is called and the transaction is rolled back.
                scope.Complete()
            End Using

        Catch ex As TransactionAbortedException

            Resultado = "error " & ex.Message
        End Try

        Return Resultado
    End Function
    Public Function DeletePreventaFact(ByVal idUsuario As String, ByVal foltik As Integer) As Boolean
        Dim deleted As Boolean = False

        Try
            Dim Scon As New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)
            Dim cmd As SqlCommand
            Dim query As String
            query = "delete from VntaTMP where no_ventas=@fol and idUsuario=@IDUsuario "

            cmd = New SqlCommand(query, Scon)
            cmd.Parameters.AddWithValue("@fol", foltik)
            cmd.Parameters.AddWithValue("@IDUsuario", idUsuario)

            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
            cmd.Connection.Close()
            deleted = True
        Catch
            deleted = False
        End Try
        Return deleted
    End Function
    Public Function VisualizPrevnta(ByVal idUsuario As String, ByVal folio As Integer) As Preventa 'Aplicando Polimorfismo a clase 'Preventa'
        Dim clasPreVnta As New Preventa

        Dim dsVP As New DataSet

        Dim ord As SqlDataAdapter
        Dim query As String
        Dim Scon As New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)
        query = "select cantidad,unidad,descripcion,precio ,importe ,iva_aplic as iva,ieps_aplic as ieps,no_ventas as id,codigo from VntaTMP where no_ticket=@fol and idUsuario=@ID order by no_ventas asc"
        ord = New SqlDataAdapter(query, Scon)
        ord.SelectCommand.Parameters.AddWithValue("@fol", folio)
        ord.SelectCommand.Parameters.AddWithValue("@ID", idUsuario)
        ord.Fill(dsVP, "VntaTMP")

        Scon.Open()
        query = "select sum(importe)as Totimport,sum(iva_aplic) as totiva from VntaTMP where no_ticket=@fol and idUsuario=@ID"
        Dim cmd = New SqlCommand(query, Scon)
        cmd.Parameters.AddWithValue("@fol", folio)
        cmd.Parameters.AddWithValue("@ID", idUsuario)
        Dim reader As SqlDataReader = cmd.ExecuteReader
        If reader.Read Then
            If Not IsDBNull(reader(0)) Then
                clasPreVnta.Importe = reader(0).ToString
                clasPreVnta.Iva = reader(1).ToString
            Else
                clasPreVnta.Importe = 0
                clasPreVnta.Iva = 0
            End If

        End If
        reader.Close() 'siempre cerrarlo
        Scon.Close()

        clasPreVnta.Dset = dsVP


        Return clasPreVnta
    End Function
    Public Function CatalogoClaveUnid() As DataTable
        Dim dtCveUnd As New DataTable
        Dim cmd As SqlCommand
        Dim Scon As New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)
        Scon.Open()
        Dim query As String
        query = "select c_ClaveUnidad,Descripcion from ClaveUnidadCFDI order by Descripcion"
        cmd = New SqlCommand(query, Scon)
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            If dr IsNot Nothing Then
                dtCveUnd.Load(dr)
            End If
        End If
        dr.Close()
        Scon.Close()
        Return dtCveUnd
    End Function
    Public Function CheckConsecVnta(ByVal idclient As String) As Single  'Solo p Usuarios Online
        Dim folvnta As Single

        tabCortes = "Cortes" & Trim(idclient)
        Dim Scon As New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)
        Dim query As String
        query = "select top 1 folVenta from " & tabCortes & " order by folVenta desc"
        Scon.Open()
        Dim ord As New SqlCommand(query, Scon)
        Dim dr As SqlDataReader
        dr = ord.ExecuteReader
        Try
            If dr.Read Then
                folvnta = CSng(dr(0)) + 1
            End If
        Catch ex As Exception
            folvnta = 1
            dr.Close()
        End Try
        Scon.Close()

        Return folvnta
    End Function
    Public Function CheckConsecCompra(idclient As String) As Integer ' Solo p usuarios remotos
        Dim folComp As Integer
        Dim instance As New Conexion
        Dim sqlstring As String = instance.ConfiguracionEmpresa(Trim(idclient))
        Dim Scon As New SqlConnection(sqlstring)
        Scon.Open()
        Dim comand As SqlCommand = New SqlCommand("select fol_compra from ControlCompras order by fol_compra desc", Scon)
        Dim reader As SqlDataReader = comand.ExecuteReader
        If reader.Read Then
            folComp = reader(0)
        Else
            folComp = 1 'primer folio de compra
        End If
        reader.Close()

        Return folComp
    End Function
    Public Function ConsultRemotVntas(ByVal session As String, ByVal tipo As Char, Optional fechaIni As Date = Nothing, Optional fechaFin As Date = Nothing) As DataSet
        Dim dsR As New DataSet
        Dim con As New Conexion
        Dim cadenaConexion As String
        cadenaConexion = con.ConfiguracionEmpresa(Trim(session))

        Dim Scon As SqlConnection ' www.dominio.sql,00
        If cadenaConexion = "" Then
            Scon = New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)
        End If
        Dim ord As SqlDataAdapter
        If tipo = "A" Then
            Dim query As String
            query = "select fecha,sum(ventas)as Monto,sum(utilidad)as Utilidad,sum(isnull(entradas,0))as Entradas,sum(isnull(salidas,0))as Salidas from " & IIf(cadenaConexion = "", "Cortes" + Trim(session), "Cortes") & " where concepto=@concept and cast(fecha as date)=cast(@dia as date) group by fecha "
            ord = New SqlDataAdapter(query, Scon)

            ord.SelectCommand.Parameters.AddWithValue("@concept", " venta")
            ord.SelectCommand.Parameters.AddWithValue("@dia", Date.Today)

            'dsVF = New DataSet
            ord.Fill(dsR, "CortesVnta")

        ElseIf tipo = "P" Then
            SQLRemot = cadenaConexion ' <- SOLO TEST Conect remota marz-2016
            Scon.Open()
            'Dim t, f As Int32
            'Dim p1, p2 As String
            'f = period.Length
            't = InStr(period, "|") '(00/00/00 | 00/00/)
            'p1 = Mid(period, 1, t - 1)
            'p2 = Mid(period, t + 1, f - t)
            Dim query As String
            query = "select fecha,sum(ventas)as Monto,sum(utilidad)as Utilidad,sum(entradas)as Entradas,sum(salidas)as Salidas from " & IIf(cadenaConexion = "", "Cortes" + Trim(session), "Cortes") & " where concepto=@concept and fecha between @ini and @fin group by fecha "
            ord = New SqlDataAdapter(query, Scon)

            ord.SelectCommand.Parameters.AddWithValue("@concept", " venta")
            ord.SelectCommand.Parameters.AddWithValue("@ini", fechaIni)
            ord.SelectCommand.Parameters.AddWithValue("@fin", fechaFin)

            'dsVF = New DataSet
            ord.Fill(dsR, "CortesVnta")
            Scon.Close()
        End If

        Return dsR

    End Function
    Private Function CalculaUtilidadProducto(ByVal codigo As String, ByVal cantidad As Single, ByVal idsession As String) As Single
        Dim utilcalc As Single

        Dim tabname As String
        tabname = "Productos" & Trim(idsession)

        Dim Scon As New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)

        Dim query As String
        Dim ord As SqlDataAdapter
        Dim ds As New DataTable
        query = "select ganancia from " & tabname & " where codigo=@codigo"
        ord = New SqlDataAdapter(query, Scon)
        ord.SelectCommand.Parameters.AddWithValue("@codigo", codigo)
        ord.Fill(ds)
        If ds.Rows.Count > 0 Then
            utilcalc = FormatNumber(ds.Rows(0)(0) * cantidad, 2)
        End If

        Return utilcalc

    End Function
    Public Shared Function DatosGraficar(ByVal session As String, ByVal fechIni As Date, ByVal fechFin As Date) As DataSet
        Dim tabname As String
        tabname = "Cortes" & Trim(session)

        Dim Scon As New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)

        Dim query As String
        Dim ord As SqlDataAdapter
        Dim drC As New DataSet
        query = "select sum(monto)as Monto,sum(utilidad)as Utilidad,fecha from " & tabname & " where concepto=@unaventa and fecha between @ini and @fin group by fecha "
        ord = New SqlDataAdapter(query, Scon)

        ord.SelectCommand.Parameters.AddWithValue("@ini", fechIni)
        ord.SelectCommand.Parameters.AddWithValue("@unaventa", "venta")
        ord.SelectCommand.Parameters.AddWithValue("@fin", fechFin)

        ord.Fill(drC, tabname)

        Return drC
    End Function

    Private SQLRemot As String
    Public Property verificSQL As String
        Get
            Return SQLRemot
        End Get
        Set(value As String)
            SQLRemot = value
        End Set
    End Property
End Class
