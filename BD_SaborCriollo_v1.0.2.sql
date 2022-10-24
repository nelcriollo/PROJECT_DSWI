/*Eliminar BD*/
drop database  SABORCRIOLLO
go
/*Crear BD*/
create database SABORCRIOLLO
go
/*Usar BD*/
use SABORCRIOLLO
go

create table tb_Ubigeo(
cod_Ubigeo char(8) primary key not null,
departamento varchar (45) not null,
provincia varchar (45) not null,
distrito varchar (45)not null
)
go

create table tb_TipoDocumento (
idTipoDocumento int primary key,
descripcion varchar (20) not null
)
go



create table tb_Cliente(
idCliente int primary key identity (1,1),
nombre varchar (45) not null,
apellido varchar (60) not null,
correo varchar (45) not null,
telefono varchar (9) not null,
idTipoDocumento int not null,
documento char (8) not null,
cod_Ubigeo char(8) not null,
direccion varchar (85) not null

)
go

ALTER TABLE tb_Cliente ADD CONSTRAINT FK01 FOREIGN KEY (idTipoDocumento) REFERENCES tb_TipoDocumento (idTipoDocumento)
ALTER TABLE tb_Cliente ADD CONSTRAINT FK02 FOREIGN KEY (cod_Ubigeo) REFERENCES tb_Ubigeo (cod_Ubigeo)




create table tb_Categoria (
idCategoria int primary key identity (1,1),
nombre varchar (30)not null
)
go


create table tb_Producto (
idProducto int primary key identity(1,1),
descripcion varchar (100) not null,
idCategoria int not null,
stock int not null
)
go

ALTER TABLE tb_Producto ADD CONSTRAINT FK03 FOREIGN KEY (idCategoria) REFERENCES tb_Categoria (idCategoria) 


create table tb_Precio (
idPrecio int primary key not null,
idProducto int not null,
idCategoria int not null,
precioUnitario decimal not null
)
go

ALTER TABLE tb_Precio ADD CONSTRAINT FK04 FOREIGN KEY (idProducto) REFERENCES tb_Producto (idProducto) 
ALTER TABLE tb_Precio ADD CONSTRAINT FK05 FOREIGN KEY (idCategoria) REFERENCES tb_Categoria (idCategoria) 



create table tb_MetodoPago(
idMetodoPago int primary key,
descripcion varchar (20) not null
)
go


create table tb_PrecioDelivery(
idDelivery int primary key,
cod_Ubigeo char(8) not null,
Costo decimal not null
)
go
ALTER TABLE tb_PrecioDelivery ADD CONSTRAINT FK28 FOREIGN KEY (cod_Ubigeo) REFERENCES tb_Ubigeo (cod_Ubigeo) 


create table tb_TipoPedido(
idTipoPedido int primary key,
descripcion varchar (75) not null,
idDelivery int not null
)
go


ALTER TABLE tb_TipoPedido ADD CONSTRAINT FK06 FOREIGN KEY (idDelivery) REFERENCES tb_PrecioDelivery (idDelivery) 



create table tb_Pedido (
idPedido int primary key identity (1,1),
idCliente int not null, 
idTipoPedido int not null,
fechaHoraPedido datetime not null,
totalPedido decimal not null,
idMetodoPago int not null,
cod_Ubigeo char(8) not null,
direccionPedido varchar (70),
estado int not null
)
go

ALTER TABLE tb_Pedido ADD CONSTRAINT FK07 FOREIGN KEY (idCliente) REFERENCES tb_Cliente (idCliente) 
ALTER TABLE tb_Pedido ADD CONSTRAINT FK08 FOREIGN KEY (idTipoPedido) REFERENCES tb_TipoPedido (idTipoPedido) 
ALTER TABLE tb_Pedido ADD CONSTRAINT FK09 FOREIGN KEY (idMetodoPago) REFERENCES tb_MetodoPago (idMetodoPago) 
ALTER TABLE tb_Pedido ADD CONSTRAINT FK10 FOREIGN KEY (cod_Ubigeo) REFERENCES tb_Ubigeo (cod_Ubigeo) 



create table tb_DetallePedido (
idDetallePedido int primary key identity (1,1),
idPedido int not null,
idProducto int not null,
cantidad int not null,
idPrecio int not null,
)
go


ALTER TABLE tb_DetallePedido ADD CONSTRAINT FK11 FOREIGN KEY (idPedido) REFERENCES tb_Pedido (idPedido) 
ALTER TABLE tb_DetallePedido ADD CONSTRAINT FK12 FOREIGN KEY (idProducto) REFERENCES tb_Producto (idProducto) 
ALTER TABLE tb_DetallePedido ADD CONSTRAINT FK13 FOREIGN KEY (idPrecio) REFERENCES tb_Precio (idPrecio) 


create table tb_Local (
idLocal int primary key,
nombre varchar (50) not null,
cod_Ubigeo char(8) not null,
direccion varchar (70) not null,
telefono char (15) not null,
horarioAtencion datetime
)
go

ALTER TABLE tb_Local ADD CONSTRAINT FK14 FOREIGN KEY (cod_Ubigeo) REFERENCES tb_Ubigeo (cod_Ubigeo) 


create table tb_Reserva (
idReserva int primary key identity (1,1),
idLocal int not null,
nombreCliente varchar (45) not null,
apellidoCliente varchar (55) not null,
documento char (8) not null,
correoCliente varchar (75) not null,
telefono char (15) not null,
fechaReserva date not null,
horaReserva time not null,
cantidadPersonas int not null,
observacion varchar (100) null,
estado int not null
)
go

ALTER TABLE tb_Reserva ADD CONSTRAINT FK15 FOREIGN KEY (idLocal) REFERENCES tb_Local (idLocal) 



create table tb_TipoComprobante (
TipoComprobante char(5) primary key,
descripcion varchar(35) not null
)
go


create table tb_ComprobantePago (
TipoComprobante char(5) not null,
NumComprobante int unique not null,
idPedido int not null,
idTipoPedido int not null,
subtotal decimal not null,
igv decimal not null,
ImporteTotal decimal not null,
primary key (TipoComprobante,NumComprobante)
)
go

ALTER TABLE tb_ComprobantePago ADD CONSTRAINT FK18 FOREIGN KEY (TipoComprobante) REFERENCES tb_TipoComprobante (TipoComprobante) 
ALTER TABLE tb_ComprobantePago ADD CONSTRAINT FK19 FOREIGN KEY (idPedido) REFERENCES tb_Pedido (idPedido) 
ALTER TABLE tb_ComprobantePago ADD CONSTRAINT FK20 FOREIGN KEY (idTipoPedido) REFERENCES tb_TipoPedido (idTipoPedido) 



create  table tb_Usuario(
idUsuario int primary key identity (1,1),
nombre varchar (30) not null,
apellido varchar (30) not null,
telefono char (15) not null,
idTipoDocumento int not null,
documento char (8) not null,
correo varchar (55) not null,
clave varchar (100) not null)
go

ALTER TABLE tb_Usuario ADD CONSTRAINT FK21 FOREIGN KEY (idTipoDocumento) REFERENCES tb_TipoDocumento (idTipoDocumento) 


create table tb_Cargo (
idCargo int primary key identity (1,1),
descripcion varchar(20) not null
)
go


create table tb_Empleado (
idEmpleado int primary key ,
nombre varchar (30)not null,
apellido varchar (45) not null,
correo varchar (60) not null,
telefono char (15) null,
idTipoDocumento int not null,
documento char (8) not null,
idCargo int not null,
cod_Ubigeo char(8) not null,
direccion varchar (75) null,
idLocal int not null
) 
go


ALTER TABLE tb_Empleado ADD CONSTRAINT FK22 FOREIGN KEY (idTipoDocumento) REFERENCES tb_TipoDocumento (idTipoDocumento) 
ALTER TABLE tb_Empleado ADD CONSTRAINT FK23 FOREIGN KEY (idCargo) REFERENCES tb_Cargo (idCargo) 
ALTER TABLE tb_Empleado ADD CONSTRAINT FK24 FOREIGN KEY (cod_Ubigeo) REFERENCES tb_Ubigeo (cod_Ubigeo) 
ALTER TABLE tb_Empleado ADD CONSTRAINT FK25 FOREIGN KEY (idLocal) REFERENCES tb_Local (idLocal) 



create table tb_TomaPedido (
idPedido int not null,
idEmpleado int not null,
primary key (idPedido,idEmpleado)
)
go

ALTER TABLE tb_TomaPedido ADD CONSTRAINT FK26 FOREIGN KEY (idPedido) REFERENCES tb_Pedido (idPedido) 
ALTER TABLE tb_TomaPedido ADD CONSTRAINT FK27 FOREIGN KEY (idEmpleado) REFERENCES tb_Empleado (idEmpleado)