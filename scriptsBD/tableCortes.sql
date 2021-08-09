create table Cortes(
id bigint identity(1,1) not null,
Foliocorte int not null,
fecha date,
ventas real,
entradas real,
salidas real,
concepto varchar(100),
usuario varchar(100),
hora datetime,
FolVenta bigint,
utilidad real,
FolFactura varchar(50),
Foltiket int
)