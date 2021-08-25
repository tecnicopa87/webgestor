use gestorFacturas
go
create procedure spCreaTablas @idClient varchar(5)
as
begin
DECLARE @sql NVARCHAR(MAX),@NombreTabla nvarchar(100);
set @NombreTabla='Ventas'+@idClient;
set @SQL= N' Create table '+QUOTENAME(@NombreTabla);
set  @SQL =@SQL+ '('+'
	[no_ticket] [int] NULL,
	[unidad] [nchar](10) NULL,
	[cantidad] [float] NULL,
	[descripcion] [varchar](50) NULL,
	[precio] [decimal](18, 2) NULL,
	[importe] [decimal](18, 2) NULL,
	[tot_may] [smallint] NULL,
	[fecha] [date] NULL,
	[maquina] [varchar](50) NULL,
	[cve_pro] [nchar](5) NULL,
	[descto] [decimal](18, 2) NULL,
	[iva_aplic] [decimal](18, 2) NULL,
	[ieps_aplic] [decimal](18, 2) NULL,
	[ahorro_client] [decimal](18, 2) NULL,
	[edo_fact] [nchar](10) NULL,
	[no_ventas] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [varchar](30) NULL,
	utilidad [decimal](18, 2) NULL
) ON [PRIMARY]'
 EXECUTE sp_executesql  @sql;
  set @NombreTabla='detalleVntas'+@idClient
set @SQL= N' Create table '+QUOTENAME(@NombreTabla)
SET @SQL=@SQL + '('+'
[no_venta] [int] IDENTITY(1,1) NOT NULL,
	[no_ticket] [int] NULL,
	[unidad] [nvarchar](10) NULL,
	[descripcion] [varchar](200) NULL,
	[monto] [real] NULL,
	[importe] [real] NULL,
	[cantidad] [real] NULL,
	[codigo] [nvarchar](255) NULL,
	[tot_may] [int] NULL,
	[fecha] [datetime] NULL,
	[edo_tiket] [nvarchar](25) NULL,
	[Maquina] [nvarchar](30) NULL,
	[Cve_pro] [nvarchar](10) NULL,
	[utilidad] [real] NULL,
	[descto] [char](30) NULL,
	[iva_aplic] [real] NULL,
	[ieps_aplic] [real] NULL,
	[ahorrocliente] [real] NULL,
	[codIndice] [int] NULL,
	[NoParte] [varchar](100) NULL
) ON [PRIMARY]'
EXECUTE sp_executesql  @sql;

 set @NombreTabla='Facturas'+@idClient
set @SQL= N' Create table '+QUOTENAME(@NombreTabla)
SET @SQL=@SQL + '('+'
[folio] [nchar](10) NULL,
	[serie] [nchar](10) NULL,
	[fechaEmision] [datetime] NULL,
	[monto] [decimal](18, 2) NULL,
	[condiciones] [nchar](10) NULL,
	[fol_Autoriz] [int] NULL,
	[TpoCmpvte] [varchar](12) NULL,
	[FolVenta] [int] NOT NULL
) ON [PRIMARY]'
EXECUTE sp_executesql  @sql;

 set @NombreTabla='Clientes'+@idClient;
 set @SQL= N' Create table '+QUOTENAME(@NombreTabla);
 set  @SQL =@SQL+ '('+'
	[CveCliente] [varchar](50) NULL,
	[Nombre] [varchar](70) NULL,
	[RFC] [char](13) NULL,
	[Regimen] [varchar](50) NULL,
	[Calle] [varchar](50) NULL,
	[noExt] [nchar](10) NULL,
	[noInt] [nchar](10) NULL,
	[Colonia] [varchar](50) NULL,
	[Municipio] [varchar](50) NULL,
	[Pais] [varchar](50) NULL,
	[Estado] [varchar](50) NULL,
	[CP] [char](10) NULL,
	[email] [varchar](60) NULL
) ON [PRIMARY]'
EXECUTE sp_executesql  @SQL;

set @NombreTabla='Cortes'+@idClient
set @SQL= N' Create table '+QUOTENAME(@NombreTabla)
SET @SQL=@SQL + '('+'
[no_corte] [smallint] NULL,
	[folVenta] [int] NULL,
	[monto] [decimal](18, 2) NULL,
	[concepto] [nchar](10) NULL,
	[usuario] [nchar](20) NULL,
	[fecha] [datetime] NULL,
	[entrada] [decimal](18, 0) NULL,
	[salida] [nchar](10) NULL,
	[totiva] [decimal](18, 2) NULL,
	[totieps] [decimal](18, 2) NULL,
	[folFactura] [varchar](50) NULL,
	[utilidad] [decimal](18, 2) NULL,
	[ventas] [real] NULL
) ON [PRIMARY]'
EXECUTE sp_executesql  @SQL;

set @NombreTabla='RepCortes'+@idClient
set @SQL=N' Create table '+ QUOTENAME(@NombreTabla)
SET @SQL=@SQL+ '('+'
[No_corte] [smallint] NULL,
	[vnta_tikets] [real] NULL,
	[vnta_facturas] [real] NULL,
	[tot_ganancias] [real] NULL,
	[fecha_corte] [datetime] NULL,
	[tot_entradas] [real] NULL,
	[tot_salidas] [real] NULL,
	[tot_caja] [real] NULL,
	[usuario_corte] [nvarchar](255) NULL,
	[gastos] [real] NULL,
	[vnta_tarjeta] [real] NULL,
	[tot_transferido] [real] NULL,
	[RepCortesID] [bigint] IDENTITY(1,1) NOT NULL,
	[Retiros] [real] NULL
	)'
EXECUTE sp_executesql  @SQL;

set @NombreTabla='Categorias'+@idClient
 set @SQL= N' Create table '+QUOTENAME(@NombreTabla);
 set  @SQL =@SQL+ '('+'
 [id] [int] NOT NULL,
 [nombreCatagoria] [varchar](50) NULL
 ) ON [PRIMARY]'
 EXECUTE sp_executesql  @SQL;

set @NombreTabla='Productos'+@idClient
set @SQL= N' Create table '+QUOTENAME(@NombreTabla)
SET @SQL=@SQL + '('+'
[codigo] [varchar](15) NOT NULL,
	[producto] [varchar](50) NULL,
	[precio] [real] NULL,
	[precio2] [real] NULL,
	[Cve_Pro] [nchar](10) NULL,
	[a_granel] [bit] NULL,
	[costo] [real] NULL,
	[ganancia] [real] NULL,
	[iva] [money] NULL,
	[ieps] [money] NULL,
	[fechmov] [datetime] NULL,
	[marcamov] [char](12) NULL,
	[unidad] [varchar](30) NULL
) ON [PRIMARY]'
 EXECUTE sp_executesql  @SQL;

set @NombreTabla='Domicilio'+@idClient
set @SQL= N' Create table '+QUOTENAME(@NombreTabla)
SET @SQL=@SQL + '('+'
[CP] [int] NOT NULL,
	[Colonia] [varchar](50) NULL,
	[Municipio] [varchar](50) NULL )'
 EXECUTE sp_executesql  @SQL;

  set @NombreTabla='Provedores'+@idClient
set @SQL= N' Create table '+QUOTENAME(@NombreTabla)
SET @SQL=@SQL + '('+'
[Cve_Provedor] [nvarchar](255) NOT NULL,
	[Nombre] [nvarchar](255) NULL,
	[Domicilio] [nvarchar](255) NULL,
	[RFC] [nvarchar](255) NULL,
	[Telefono] [nvarchar](255) NULL,
	[pagos_acumulados] [money] NULL,
	[Diavisita] [nvarchar](255) NULL
	) ON [PRIMARY]'
	EXECUTE sp_executesql  @SQL;

set @NombreTabla='Servicios'+@idClient
set @SQL= N' Create table '+QUOTENAME(@NombreTabla)
SET @SQL=@SQL + '('+'
[IDServicio] [int] IDENTITY(1,1) NOT NULL,
	[IDCategoria] [varchar](50) NULL,
	[ServicioDescripcion] [varchar](400) NULL,
	[ServicioCosto] [float] NULL,
	[CostoManoObra] [float] NULL,
	[ServicioPrecio] [float] NULL,
	[ServicioUtilidad] [float] NULL,
	[ServicioFolio] [varchar](30) NULL,
	[TiempoRealizar] [int] NULL,
	[FechaEntrega] [datetime] NULL,
	[FechaPropuesta] [datetime] NULL,
	[CveProdServCFDI] [varchar](20) NULL,
	[Codigo] [varchar](50) NULL,
	[Estatus] [varchar](50) NULL,
	[Aceptado] [bit] NULL,
	[Observaciones] [varchar](250) NULL,
	[Cambiocabezal] [varchar](250) NULL,
	[Equipo] [varchar](100) NULL,
	[Marca] [varchar](100) NULL,
	[Modelo] [varchar](100) NULL,
	[Cveclient] [varchar](10) NULL,
	[AnticipoMonto] [float] NULL,
	[IvaManoObra] [real] NULL,
	[FechaRevisada] [datetime] NULL,
	[FechaAutorizada] [datetime] NULL,
	[FechaReparada] [datetime] NULL,
	[FechaSolicitud] [datetime] NULL,
	[Cancelado] [bit] NULL
	) ON [PRIMARY]'
	EXECUTE sp_executesql  @SQL;
end
GO
grant exec on spCreaTablas to public
go
