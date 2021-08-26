create table ControlCompras(
idCompra int identity(1,1) not null,
fol_compra int not null,
fecha datetime,
responsable varchar(100),
tot_compra real,
monto_pagado real,
idUsuario nchar(5) not null
)
