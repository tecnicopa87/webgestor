use gestorFacturas
go
create procedure spProductos_insert
as
begin
declare @sql nvarchar(MAX),@NombreTabla nvarchar(150);
declare @idclient varchar(3),@codigo varchar(15), @producto varchar(50), @precio real, @precio2 real, @Cve_Pro nchar(10), @a_granel bit, @costo real, @ganancia real, @iva money, @ieps money, @fechmov datetime, @marcamov char(12), @unidad varchar(30)
set @NombreTabla='Productos'+@idclient;
set @sql=N' INSERT INTO '+QUOTENAME(@NombreTabla);
set @sql=@sql+ '('+'[codigo], [producto], [precio], [precio2], [Cve_Pro], [a_granel], [costo], [ganancia], [iva], [ieps], [fechmov], [marcamov], [unidad]) VALUES (@codigo, @producto, @precio, @precio2, @Cve_Pro, @a_granel, @costo, @ganancia, @iva, @ieps, @fechmov, @marcamov, @unidad)'
execute sp_executesql @sql;
end
go
grant exec on spProductos_insert to public
go