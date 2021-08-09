Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports GestorEntities 'para manejo de inventario en proceso Remoto
Public Class ComprasDAL
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
    Public Function GuardCbzCompra(idclient As String, folVntaremot As Integer, compra As Compras) As String  ' Solo p usuarios remotos
        Dim ProcComp As String

        Dim instance As New Conexion
        Dim sqlstring As String = instance.ConfiguracionEmpresa(Trim(idclient))
        Dim Scon As New SqlConnection(sqlstring)
        Try
            Scon.Open()
            Dim comand As SqlCommand = New SqlCommand("insert into ControlCompras (fol_compra,fecha,responsable,tot_compra,monto_pagado)" & _
                                                      "values(@folcmp,@fech,@persona,@totimp,@totpag)", Scon)

            comand.Parameters.AddWithValue("@folcmp", compra.FolComp)
            comand.Parameters.AddWithValue("@fech", Date.Now)
            comand.Parameters.AddWithValue("@persona", "movil")
            comand.Parameters.AddWithValue("@totimp", compra.Monto)
            comand.Parameters.AddWithValue("@totpag", compra.Monto) ' provisional paga completo

            comand.ExecuteNonQuery()
            'AL Grabar una compra se debe reflejar en el corte del negocio
            comand = New SqlCommand("insert into Cortes(Foliocorte,fecha,ventas,entradas,salidas,concepto,usuario,hora,FolVenta,utilidad,FolFactura,Foltiket)" & _
                                    "values (@Foliocero,@fecha,@ventas,@entradas,@salidas,@concepto,@usuario,@hora,@FolVenta,@utilidad,@folnull,@folnulo)", Scon)

            comand.Parameters.AddWithValue("@Foliocero", 0) '0 hasta realizar corte
            comand.Parameters.AddWithValue("@fecha", Date.Today)
            comand.Parameters.AddWithValue("@ventas", 0)
            comand.Parameters.AddWithValue("@entradas", 0)
            comand.Parameters.AddWithValue("@salidas", compra.Monto)
            comand.Parameters.AddWithValue("@concepto", "Compra")
            comand.Parameters.AddWithValue("@usuario", "movil")
            comand.Parameters.AddWithValue("@hora", DateTime.Now.ToString("hh:mm")) '*COMPATIBLE en SQL
            comand.Parameters.AddWithValue("@FolVenta", folVntaremot) 'obtenido de servidor en Tienda
            comand.Parameters.AddWithValue("@utilidad", 0)
            comand.Parameters.AddWithValue("@folnull", " ") 'evitar excepcion al realizar cortes
            comand.Parameters.AddWithValue("@folnulo", 0) '*w foltiket integer

            comand.ExecuteNonQuery()
            Scon.Close()
            ProcComp = "correcto"
        Catch ex As Exception

            ProcComp = "Ocurrio un error al guardar compras"
        End Try

        Return ProcComp
    End Function
    Public Function GuardlineasCompra(idclient As String, linprods As Compras) As String  ' Solo p usuarios remotos
        Dim ProcComp As String

        Dim instance As New Conexion
        Dim sqlstring As String = instance.ConfiguracionEmpresa(Trim(idclient))
        Dim Scon As New SqlConnection(sqlstring)
        Try
            Scon.Open()
            For Each producto As LineasFactura In linprods.Lineasfact
                Dim stock As Single
                'stock = producto.exis + producto.cantidad
                Dim comand As SqlCommand = New SqlCommand("update productos set existencia_pzas=@nuevostock,remesa=@reingreso,fechmov=@fech,marcamov=@movimiento " & _
                                                      "where codigo=@codbar", Scon)

                comand.Parameters.AddWithValue("@nuevostock", stock)
                comand.Parameters.AddWithValue("@reingreso", producto.cantidad)
                comand.Parameters.AddWithValue("@codbar", producto.codigo)
                comand.Parameters.AddWithValue("@fech", Date.Now)

                comand.ExecuteNonQuery()
                ProcComp = "correcto"

            Next
            
        Catch ex As Exception

            ProcComp = "Ocurrio un error al actualizar inventario"
        End Try

        Return ProcComp
    End Function
    Public Function PreventaCompra(idclient As String, ByVal foltik As Integer, ByVal idprod As String, ByVal und As String, ByVal ct As Decimal, ByVal desc As String, ByVal prec As Decimal, ByVal imp As Decimal, ByVal cvePro As String, ByVal dcto As Decimal, ByVal iva As Decimal, ByVal ieps As Decimal) As Boolean
        Dim exito As Boolean

        Dim tabTMP As String = "Ventas" & Trim(idclient) 'En caso cliente remoto "Ventas00#" es pasajera
        Try
            Dim Scon As New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)

            Dim cmd As SqlCommand
            Dim query As String
            query = "insert into " & tabTMP & "(no_ticket,unidad,cantidad,descripcion,precio,importe,cve_pro,descto,iva_aplic,ieps_aplic,codigo)" &
            "values (@notik,@unid,@cant,@descrip,@prec,@import,@cve_pro,@descto,@iva,@ieps,@idprod) "

            cmd = New SqlCommand(query, Scon)
            cmd.Parameters.AddWithValue("@notik", foltik)
            cmd.Parameters.AddWithValue("@unid", und)
            cmd.Parameters.AddWithValue("@cant", ct)
            cmd.Parameters.AddWithValue("@descrip", desc)
            cmd.Parameters.AddWithValue("@prec", prec)
            cmd.Parameters.AddWithValue("@import", imp)
            cmd.Parameters.AddWithValue("@cve_pro", cvePro)
            cmd.Parameters.AddWithValue("@descto", dcto)
            cmd.Parameters.AddWithValue("@iva", iva)
            cmd.Parameters.AddWithValue("@ieps", ieps)
            cmd.Parameters.AddWithValue("@idprod", idprod)

            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
            cmd.Connection.Close()
            exito = True

        Catch ex As Exception
            exito = False
        End Try

        Return exito
    End Function
    Public Function VisualizPreCompra(ByVal folio As Integer, idclie As String) As Preventa ' esta clase devuelve diferentes tipos de datos
        Dim clasPreCmp As New Preventa

        Dim dsVP As New DataSet
        Dim tabCmp As String = "Ventas" & Trim(idclie)
        Dim ord As SqlDataAdapter
        Dim query As String
        Dim Scon As New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)
        query = "select cantidad,unidad,descripcion,precio,importe,iva_aplic as iva,no_ventas as id,codigo as cod from " & tabCmp & " where no_ticket=@fol order by no_ventas asc"
        ord = New SqlDataAdapter(query, Scon)
        ord.SelectCommand.Parameters.AddWithValue("@fol", folio)
        ord.Fill(dsVP, "VntaTMP")

        Scon.Open()
        query = "select sum(importe)as Totimport,sum(iva_aplic) as totiva from " & tabCmp & " where no_ticket=@fol"
        Dim cmd = New SqlCommand(query, Scon)
        cmd.Parameters.AddWithValue("@fol", folio)
        Dim reader As SqlDataReader = cmd.ExecuteReader
        If reader.Read Then
            clasPreCmp.Importe = reader(0).ToString
            clasPreCmp.Iva = reader(1).ToString
        End If
        reader.Close() 'siempre cerrarlo
        Scon.Close()

        clasPreCmp.Dset = dsVP

        Return clasPreCmp

    End Function
    Public Function UpdatePreCompra(idclie As String, ByVal foltik As Integer, ByVal und As String, ByVal ct As Decimal, ByVal desc As String, ByVal prec As Decimal, ByVal imp As Decimal, ByVal iva As Decimal, ByVal ieps As Decimal) As Boolean
        Dim exito As Boolean

        Dim tabCmp As String = "Ventas" & Trim(idclie)
        Try
            Dim Scon As New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)
            Dim cmd As SqlCommand
            Dim query As String
            query = "update " & tabCmp & " set unidad=@unid,cantidad=@cant,descripcion=@descrip,precio=@prec,importe=@import,iva_aplic=@iva where no_ventas=@fol"

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

            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
            cmd.Connection.Close()
            exito = True

        Catch ex As Exception
            exito = False
        End Try

        Return exito
    End Function
    Public Function DeletePreCompra(idclie As String, ByVal nolin As Integer) As Boolean
        Dim exito As Boolean

        Dim tabCmp As String = "Ventas" & Trim(idclie)
        Try
            Dim Scon As New SqlConnection(ConfigurationManager.ConnectionStrings("gestorFacturasConnectionString").ToString)
            Dim cmd As SqlCommand
            Dim query As String
            query = "delete from " & tabCmp & " where no_ventas=@fila"

            cmd = New SqlCommand(query, Scon)

            cmd.Parameters.AddWithValue("@fila", nolin)

            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
            cmd.Connection.Close()
            exito = True

        Catch ex As Exception
            exito = False
        End Try

        Return exito
    End Function
End Class
