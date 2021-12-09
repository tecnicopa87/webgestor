use negocios
go
--Insert INICIAL 1ra vez usa EasyControl
declare @fechaInical date=getdate()
insert into ventas values(CAST(@fechaInical as date),0.0,0,0,null,null)
insert into acceso values ('aprovado','Administrador','sys2021',@fechaInical,'CHR 78','XXX','ASDWR34587GHJUYTU24356')
insert into acceso values ('aprovado','Empleado','us2021',@fechaInical,'CHR 78','XXX','ASDWR34587GHJUYTU24356')
insert into clientes values ('001',' ',null,null,null,null,null,null,null,null,null,null,null,null,null,null,null)
insert into Lineas values (1,'Abarrotes',0)
insert into secuencia values (1,1)
insert into DatosTicket values (1,'NOMBRE NEGOCIO','','','','','','','','')
insert into Provedores values('001','no asignado',null,null,null,0,null)
go


