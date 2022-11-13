/*Eliminar BD*/
drop database  SABORCRIOLLO
go
/*Crear BD*/
create database SABORCRIOLLO
go
/*Usar BD*/
use SABORCRIOLLO
go
/*Formato de fecha*/
Set dateFormat dmy
go
----------------------------------------
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
nomPrducto varchar(50),
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


-------------PROCEDURE USUARIO------------------

create or alter procedure usp_Usuario_Registrar(
@correo varchar (100),
@clave varchar (20),
@Registro bit output,
@Mensaje varchar (50) output
)
as
begin
if (not exists(select * from tb_Usuario where correo = @correo))
begin
		insert into tb_Usuario (correo,clave) values (@correo,@clave)
		set @Registro =1
		set @Mensaje = 'Usuario Registrado con Exito'
	end
	else
	begin 
			set @Registro = 0
			set @Mensaje = 'Correo ya existe'
	end
end
go

------------------------------------------------
create or alter procedure usp_Usuario_Validar(
@correo varchar (100),
@clave varchar (50)
)
as 
begin
	if (exists (select *from tb_Usuario where correo = @correo and clave = @clave))
		select idUsuario from tb_Usuario where correo = @correo and clave = @clave
		else
		select  '0'
end
go
----------------------------------------------------------------

create or alter procedure usp_Usuario_Actualizar(
@idUsuario int,
@nombre varchar (30),
@apellido varchar (30),
@telefono char (15),
@correo varchar (55),
@clave varchar (100)
)
as

 
begin
	UPDATE tb_Usuario 
		set nombre = @nombre,
		apellido = @apellido,
		telefono = @telefono,
		correo = @correo,
		clave = @clave
		where idUsuario = @idUsuario
end
go
-----------------------------------------------------
create or alter procedure usp_Usuario_Eliminar
@idUsuario int
as
	delete from tb_Usuario where idUsuario = @idUsuario;
go


-----////////////////////--------
----PROCEDURE EMPLEADO----
----/////////////////////--------

create or alter procedure usp_Empleado_Listar
as
begin
		select * from tb_Empleado
end;
go

------------------------------
create or alter PROCEDURE usp_Empleado_Registrar
(
	@nombre varchar(30),
	@apellido varchar(45),
	@correo varchar (60),
	@telefono char(15),
	@idTipoDocumento int,
	@documento char(8),
	@idCargo INT,
	@cod_Ubigeo char(8),
	@direccion varchar (75),
	@idLocal int
)
AS
BEGIN

	DECLARE @NuevoId INT;
	SET @NuevoId = (SELECT ISNULL(MAX(idEmpleado), 0) FROM tb_Empleado) + 1
	
	INSERT tb_Empleado
	(
	    nombre ,
		apellido ,
		correo ,
		telefono ,
		idTipoDocumento ,
		documento ,
		idCargo ,
		cod_Ubigeo ,
		direccion ,
		idLocal 
	)
	VALUES
	(   @nombre ,
		@apellido ,
		@correo ,
		@telefono ,
		@idTipoDocumento ,
		@documento ,
		@idCargo ,
		@cod_Ubigeo ,
		@direccion ,
		@idLocal   
	    )

	SELECT @NuevoId
END
go
---------------------------------
create or ALTER PROCEDURE usp_Empleado_Actualizar
(
	@idEmpleado int ,
	@nombre varchar(30),
	@apellido varchar(45),
	@correo varchar (60),
	@telefono char(15),
	@idTipoDocumento int,
	@documento char(8),
	@idCargo INT,
	@cod_Ubigeo char(8),
	@direccion varchar (75),
	@idLocal int
)
AS
BEGIN

UPDATE tb_Empleado
SET     nombre =@nombre ,
		apellido=@apellido ,
		correo=@correo ,
		telefono=@telefono ,
		idTipoDocumento=@idTipoDocumento ,
		documento=@documento ,
		idCargo=@idCargo ,
		cod_Ubigeo=@cod_Ubigeo ,
		direccion=@direccion ,
		idLocal=@idLocal
WHERE idEmpleado = @idEmpleado

END
go
------------------------------------------------
create or ALTER PROCEDURE usp_Empleado_Eliminar
(
	@idEmpleado INT
)
AS
BEGIN

	DELETE FROM tb_Empleado
	WHERE idEmpleado = @idEmpleado

END

go

-----//////////////////////////////--------
----PROCEDURE COMPROBANTE DE PAGO----
----//////////////////////////////--------

create or alter procedure usp_ComprobantePago_Listar
as
begin
		select * from tb_ComprobantePago
end;
go

-------------------------------------------
create or ALTER PROCEDURE usp_ComprobantePago_Eliminar
(
	@NumComprobante INT
)
AS
BEGIN

	DELETE FROM tb_ComprobantePago
	WHERE NumComprobante = @NumComprobante

END
go

--------------------------------------------------------

-----//////////////////////////////--------
----PROCEDURE TOMA PEDIDO----
----//////////////////////////////--------

create or alter procedure usp_TomaPedido_Listar
as
begin
		select * from tb_TomaPedido
end;
go

--------------------------------------------

create or ALTER PROCEDURE usp_TomaPedido_Eliminar
(
	@idPedido INT
)
AS
BEGIN

	DELETE FROM tb_TomaPedido
	WHERE idPedido = @idPedido

END
go


-----//////////////////////////////--------
----PROCEDURE LOCAL----
----//////////////////////////////--------

create or alter procedure usp_Local_Listar
as
begin
		select * from tb_Local
end;
go

-----//////////////////////////////--------
----PROCEDURE UBIGEO----
----//////////////////////////////--------

create or alter procedure usp_Ubigeo_Listar
as
begin
		select * from tb_Ubigeo
end;
go

-----//////////////////////////////--------
----PROCEDURE PRECIO DELIVERY----
----//////////////////////////////--------

create or alter procedure usp_PrecioDelivery_Listar
as
begin
		select * from tb_PrecioDelivery
end;
go

-----//////////////////////////////--------
----PROCEDURE TIPO COMPROBANTE----
----//////////////////////////////--------

create or alter procedure usp_TipoComprobante_Listar
as
begin
		select * from tb_TipoComprobante
end;
go

-----//////////////////////////////--------
----PROCEDURE TIPO PEDIDO----
----//////////////////////////////--------

create or alter procedure usp_TipoPedido_Listar
as
begin
		select * from tb_TipoPedido
end;
go

-- PROCEDIMIENTO ALMACENADO

/*TABLA PEDIDO*/
-- Listar Pedido
create procedure usp_Pedido_Listar
as
select * from tb_Pedido
go
-- Registrar Pedido
create or alter procedure usp_Pedido_Registrar
@idCliente int,
@idTipoPedido int,
@fechaHoraPedido datetime,
@totalPedido decimal,
@idMetodoPago int,
@cod_Ubigeo char(8),
@direccionPedido varchar (70),
@estado int
as
insert into tb_Pedido values(	@idCliente,
								@idTipoPedido,
								@fechaHoraPedido,
								@totalPedido,
								@idMetodoPago,
								@cod_Ubigeo,
								@direccionPedido,
								@estado)
go
-- Actualizar Pedido
create or alter procedure usp_Pedido_Actualizar
@idCliente int,
@idTipoPedido int,
@fechaHoraPedido datetime,
@totalPedido decimal,
@idMetodoPago int,
@cod_Ubigeo char(8),
@direccionPedido varchar (70),
@estado int
as
update tb_Pedido set	idCliente=@idCliente,
						idTipoPedido=@idTipoPedido,
						fechaHoraPedido=@fechaHoraPedido,
						totalPedido=@totalPedido,
						idMetodoPago=@idMetodoPago,
						cod_Ubigeo=@cod_Ubigeo,
						direccionPedido=@direccionPedido,
						estado=@estado
go
-- Eliminar Pedido
create procedure usp_Pedido_Eliminar
@idPedido int
as
begin
	delete from tb_Pedido
	where idPedido = @idPedido
end
go

/*TABLA PRODUCTO*/
-- Listar Producto
create procedure usp_Producto_Listartb_Pedido
as
select * from tb_Producto
go
-- Registrar Producto
create procedure usp_Producto_Registrar
@nomPrducto varchar(50),
@descripcion varchar (100),
@idCategoria int,
@stock int
as
insert into tb_Producto values(	@nomPrducto,
								@descripcion,
								@idCategoria,
								@stock)
go
-- Actualizar Producto
create procedure usp_Producto_Actualizar
@nomPrducto varchar(50),
@descripcion varchar (100),
@idCategoria int,
@stock int
as
update tb_Producto set	nomPrducto=@nomPrducto,
						descripcion=@descripcion,
						idCategoria=@idCategoria,
						stock=@stock
go
-- Eliminar Producto
create procedure usp_Producto_Eliminar
@idProducto int
as
begin
	delete from tb_Producto
	where idProducto = @idProducto
end
go

/*TABLA DETALLE PEDIDO*/
-- Listar Detalle Pedido
create procedure usp_DetallePedido_Listar
as
select * from tb_DetallePedido
go
-- Registrar Detalle Pedido
create procedure usp_DetallePedido_Registrar
@idPedido int,
@idProducto int,
@cantidad int,
@idPrecio int
as
insert into tb_DetallePedido values(	@idPedido,
										@idProducto,
										@cantidad,
										@idPrecio)
go
-- Actualizar Detalle Pedido
create procedure usp_DetallePedido_Actualizar
@idPedido int,
@idProducto int,
@cantidad int,
@idPrecio int
as
update tb_DetallePedido set	idPedido=@idPedido,
							idProducto=@idProducto,
							cantidad=@cantidad,
							idPrecio=@idPrecio
go
-- Eliminar Detalle Pedido
create procedure usp_DetallePedido_Eliminar
@idDetallePedido int
as
begin
	delete from tb_DetallePedido
	where idDetallePedido = @idDetallePedido
end
go
/*TABLA RESERVA*/
-- Listar Reserva
create procedure usp_Reserva_Listar
as
select * from tb_Reserva
go
-- Registrar Reserva
create procedure usp_Reserva_Registrar
@idLocal int,
@nombreCliente varchar (45),
@apellidoCliente varchar (55),
@documento char (8),
@correoCliente varchar (75),
@telefono char (15),
@fechaReserva datetime,
@horaReserva time,
@cantidadPersonas int,
@observacion varchar (100),
@estado int
as
insert into tb_Reserva values(	@idLocal,
								@nombreCliente,
								@apellidoCliente,
								@documento,
								@correoCliente,
								@telefono,
								@fechaReserva,
								@horaReserva,
								@cantidadPersonas,
								@observacion,
								@estado)
go
-- Eliminar Reserva
create procedure usp_Reserva_Eliminar
@idReserva int
as
begin
	delete from tb_Reserva
	where idReserva = @idReserva
end
go

/*TABLA METODO PAGO*/
-- Listar Metodo Pago
create procedure usp_MetodoPago_Listar
as
select * from tb_MetodoPago
go

/*TABLA TIPO DOCUMENTO*/
-- Listar Tipo Documento
create procedure usp_TipoDocumento_Listar
as
select * from tb_TipoDocumento
go

/*TABLA CARGO*/
-- Listar Cargo
create procedure usp_Cargo_Listar
as
select * from tb_Cargo
go

/*TABLA CATEGORIA*/
-- Listar Categoria
create procedure usp_Categoria_Listar
as
select * from tb_Categoria
go

/*TABLA PRECIO*/
-- Listar Precio
create procedure usp_Precio_Listar
as
select * from tb_Precio
go
------------------------------------------------------------------------------------------
-- inserts
insert tb_Cargo values ('gerente');
insert tb_Cargo values ('sub-gerente');
insert tb_Cargo values ('cajero');
insert tb_Cargo values ('cocinero');
insert tb_Cargo values ('mozo');
select * from tb_Cargo
----------------------------------------------------------
insert tb_Categoria values('Pollos Brasa')
insert tb_Categoria values('Promociones')
insert tb_Categoria values('Bebidas')
insert tb_Categoria values('Entradas')
insert tb_Categoria values('Piqueos')
insert tb_Categoria values('Big Box')
insert tb_Categoria values('Combos')
select * from tb_Categoria
-------------------------------------------------------------
insert tb_Ubigeo values ('001','Lima', 'Lima', 'El Agustino');
insert tb_Ubigeo values ('002','Lima', 'Lima', 'Ate');
insert tb_Ubigeo values ('003','Lima', 'Lima', 'Santa Anita');
insert tb_Ubigeo values ('004','Lima', 'Lima', 'Rimac');
insert tb_Ubigeo values ('005','Lima', 'Lima', 'La Molina');
select * from tb_Ubigeo
-------------------------------------------------------------
insert tb_TipoDocumento values (1,'dni');
select * from tb_TipoDocumento
-------------------------------------------------------------
insert tb_Cliente values ('Ricardo', 'Soto', 'risotono@gmail.com', '943585576', 1, '43756782', '001', 'Calle Los Alhelies 341');
insert tb_Cliente values ('Rosa', 'Nolazco', 'roosmery12@gmail.com', '966394654', 1, '02453678', '002', 'Calle Los Geranios 221');
insert tb_Cliente values ('Mario', 'Gonzales', 'profesormariog@gmail.com', '996155597', 1, '46745638', '003', 'Calle Los Docentes 671');
insert tb_Cliente values ('Enrique', 'Segoviano', 'kikesegoviano@gmail.com', '957889631', 1, '37846324', '004', 'Calle Las Dalias 941');
insert tb_Cliente values ('Jaime', 'Lertora', 'jaimeler@gmail.com', '966595676', 1, '73289364', '005', 'Calle Las Azucenas 891');
select * from tb_Cliente
--------------------------------------------------------------
insert tb_Producto values('Pollo Brasa Sabor Criollo','1 Pollo Brasa Sabor Criollo + Salsas',1,150)
insert tb_Producto values('Pollo Brasa SB con Papas y Ensalada','1 Pollo Brasa Sabor Criollo, 1 Papa Crocantita Familiar, 1 Ensalada Fresca Familiar, Salsas',1,150)
insert tb_Producto values('Pollo Brasa SB con Acomp Familiar y Ensalada','1 Pollo Brasa Sabor Criollo, 1 Acompañamiento Familiar, 1 Ensalada Fresca Familiar, Salsas',1,150)
insert tb_Producto values('1/2 Brasa SB con Papas y Ensalada','1/2 Pollo Brasa Sabor Criollo, 1 Papa Crocantita Mediana, 1 Ensalada Fresca Mediana, Salsas',1,150)
insert tb_Producto values('1/2 Brasa SB con Papas','1/2 Pollo Brasa Sabor Criollo, 1 Papa Crocantita Mediana, Salsas',1,150)
insert tb_Producto values('1/2 Brasa SB con 2 Acomp y Ensalada','1/2 Pollo Brasa Sabor Criollo, 2 Acompañamientos Personal, 1 Ensalada Fresca Mediana, Salsas',1,150)
insert tb_Producto values('1/4 Brasa SB con Papas y Ensalada','1/4 Brasa Brasa Sabor Criollo, 1 Papa Crocantita Personal, 1 Ensalada Fresca Personal, Salsas',1,150)
insert tb_Producto values('1/4 Brasa SB con Papas','1/4 Brasa Brasa Sabor Criollo, 1 Papa Crocantita Personal, Salsas',1,150)
insert tb_Producto values('1/4 Brasa SB con Acomp y Ensalada','1/4 Brasa Brasa Sabor Criollo, 1 Acompañamiento Personal, 1 Ensalada Fresca Personal, Salsas',1,150)
insert tb_Producto values('Pollo Brasa SB con 4 Acomp Personal y Ensalada','1 Pollo Brasa Brasa Sabor Criollo, 4 Acompañamientos Personal, 1 Ensalada Fresca Familiar, Salsas',1,150)
insert tb_Producto values('Pechuga Parrillera','Filete de pechuga marinada con salsa parrillera  + acompañamiento personal ',1,150)
insert tb_Producto values('Pollo Brasa SB con Papas','1 Pollo Brasa Brasa Sabor Criollo, 1 Papa Crocantita Familiar, Salsas',1,150)
select * from tb_Producto
-------------------------------------------------------------------------------------------------------------------------
insert tb_Usuario values ('Alfredo', 'Soto', '977324854', 1, '43594317', 'alfredosotonolazco@gmail.com','cibertec2020');
insert tb_Usuario values ('Nelson', 'Criollo', '966405630', 1, '45678902', 'nelzoncriollo@gmail.com','cibertec2021');
insert tb_Usuario values ('Eduardo', 'Rojas', '975410519', 1, '45389210', 'ebrp@gmail.com','cibertec2022');
select * from tb_Usuario
-------------------------------------------------------------------------------------------------------------------------------
insert tb_Local values (1,'Ancash', '001', 'Jiron Ancash 674', '013334567', '2022-11-01 09:00:00');
insert tb_Local values (2,'Puruchuco', '002', 'Avenida Javier Prado Este 17654', '014565788', '2022-11-02 08:00:00');
insert tb_Local values (3,'Universal', '003', 'Avenida Los Frutales 335', '013215566', '2022-11-03 08:30:00');
insert tb_Local values (4,'Tarapaca', '004', 'Avenida Amancaes 874', '015678342', '2022-11-04 09:30:00');
insert tb_Local values (5,'Rotonda', '005', 'Avenida La Fontana 762', '013567890', '2022-11-05 08:45:00');
select * from tb_Local
------------------------------------------------------------------------------------------------------------
insert tb_Empleado values (100,'Franco', 'Chavez', 'francochavezg@gmail.com', '991108950', 1, '48956782', 1, '001', 'Calle Los Tuetanos 234', 1);
insert tb_Empleado values (201,'William', 'Chavez', 'jorgeelgrone@gmail.com', '999888777', 1, '42134565', 1, '002', 'Jiron Los Manzanos 564', 2);
insert tb_Empleado values (302,'Rita', 'Flores', 'lachicafresa@gmail.com', '987666555', 1, '49573290', 1, '003', 'Las Lagunas 567', 3);
insert tb_Empleado values (403,'Juan', 'Puchuri', 'elsabiondo@gmail.com', '976544433', 1, '46464788', 1, '004', 'Los Ingenieros 678', 4);
insert tb_Empleado values (504,'Giampiere', 'Leon', 'elagilao@gmail.com', '965333222', 1, '47636345', 1, '005', 'Los Aniñaos 456', 5);
select * from tb_Empleado
-------------------------------------------------------------------------
insert tb_MetodoPago values (1,'tarjeta');
insert tb_MetodoPago values (2,'efectivo');
insert tb_MetodoPago values (3,'transferencia');
insert tb_MetodoPago values (4,'qr');
insert tb_MetodoPago values (5,'pagoefectivo');
select * from tb_MetodoPago
------------------------------------------------------------------------
insert tb_Precio values (1, 1, 1, 49.90);
insert tb_Precio values (2, 4, 1, 24.90);
insert tb_Precio values (3, 7, 1, 12.90);
insert tb_Precio values (4, 10, 1, 15.90);
insert tb_Precio values (5, 11, 1, 59.90);
select * from tb_Precio
------------------------------------------------------------------------------------
insert tb_TipoComprobante values (1,'boleta');
insert tb_TipoComprobante values (2,'factura');
select * from tb_TipoComprobante
-------------------------------------------------------------------
insert tb_PrecioDelivery values (1,'001', 10.90);
insert tb_PrecioDelivery values (2,'002', 12.90);
insert tb_PrecioDelivery values (3,'003', 14.90);
insert tb_PrecioDelivery values (4,'004', 15.90);
insert tb_PrecioDelivery values (5,'005', 20.90);
select * from tb_PrecioDelivery
--------------------------------------------------------------------
insert tb_TipoPedido values (1,'Entrega máximo en 60 minutos', 1);
insert tb_TipoPedido values (2,'Entrega máximo en 45 minutos', 2);
insert tb_TipoPedido values (3,'Entrega máximo en 40 minutos', 3);
insert tb_TipoPedido values (4,'Entrega máximo en 35 minutos', 4);
insert tb_TipoPedido values (5,'Entrega máximo en 30 minutos', 5);
select * from tb_TipoPedido
------------------------------------------------------------------
insert tb_Pedido values (1, 1, '2022-09-05 12:30:00', 60.80, 1, '001', 'Calle Los Alhelies 341', 1);
insert tb_Pedido values (2, 2, '2022-08-04 11:35:00', 37.80, 2, '002', 'Calle Los Geranios 221', 2);
insert tb_Pedido values (3, 3, '2022-03-03 14:36:00', 27.80, 3, '003', 'Calle Los Docentes 671', 3);
insert tb_Pedido values (4, 4, '2022-07-02 15:37:00', 31.80, 4, '004', 'Calle Las Dalias 941', 1);
insert tb_Pedido values (5, 5, '2022-06-01 16:39:00', 80.80, 5, '005', 'Calle Las Azucenas 891', 2);
select * from tb_Pedido
------------------------------------------------------------------------------------------------------------
insert tb_DetallePedido values (1, 1, 1, 1);
insert tb_DetallePedido values (2, 4, 1, 2);
insert tb_DetallePedido values (3, 7, 1, 3);
insert tb_DetallePedido values (4, 10, 1, 4);
insert tb_DetallePedido values (5, 11, 1, 5);
select * from tb_DetallePedido
----------------------------------------------------------------------------------------
insert tb_TomaPedido values (1, 302);
insert tb_TomaPedido values (2, 504);
insert tb_TomaPedido values (3, 302);
insert tb_TomaPedido values (4, 504);
insert tb_TomaPedido values (5, 302);
select * from tb_TomaPedido
----------------------------------------------------------------------------------
insert tb_Reserva values (1, 'Ricardo', 'Soto', '43756782', 'risotono@gmail.com', '943585576', '2022-09-05', '12:30:00', 5,  'Incluye 2 cajitas para niños', 1);
insert tb_Reserva values (2, 'Rosa', 'Nolazco', '02453678','roosmery12@gmail.com', '966394654', '2022-08-04', '11:35:00', 7,  'Incluye botella de vino de cortesia', 2);
insert tb_Reserva values (3, 'Mario', 'Gonzales', '46745638', 'profesormariog@gmail.com', '996155597', '2022-03-03', '14:36:00', 9,  'Ronda de Alitas BBQ de cortesia', 3);
insert tb_Reserva values (4, 'Enrique', 'Segoviano', '37846324', 'kikesegoviano@gmail.com', '957889631', '2022-07-02', '15:37:00', 10,  'Torta de cumpleaños para el cliente', 1);
insert tb_Reserva values (5, 'Jaime', 'Lertora', '73289364', 'jaimeler@gmail.com', '966595676', '2022-06-01', '16:39:00', 15,  'Giftcard de S/.50 regalo para el socio', 2);
select * from tb_Reserva
-----------------------------------------------------------------------------------------------------------
insert tb_ComprobantePago values (1, 1, 1, 1, 49.90, 10.94, 60.80);
insert tb_ComprobantePago values (2, 2, 2, 2, 31.00, 6.80, 37.80);
select * from tb_ComprobantePago
-----------------------------------------------------------------------------------------------------------------------------------------------------
