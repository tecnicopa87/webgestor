create trigger montoventas_compatibleTPV
on Cortes002 for insert
as
begin
declare @folvnta as int=(select folVenta from inserted)
update Cortes002 set ventas=(select monto from inserted) where folVenta =@folvnta
end