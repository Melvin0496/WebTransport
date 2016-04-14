
create database WebTransportDb

use WebTransportDb

create table Usuarios(
UsuarioId int identity(1,1) primary key,
Nombres varchar(40),
Apellidos varchar(40),
Email varchar(100),
Contrasena varchar(30),
TipoUsuario int,
Fecha datetime
)

select *from Paradas
select *from Usuarios
select *from Reservaciones

create table Pasajeros(
PasajeroId int identity(1,1) primary key,
Nombres varchar(40)
)

create table TipoEnvios(
TipoEnvioId int identity(1,1) primary key,
Descripcion varchar(100)
)

select *from TipoEnvios

select *from Pasajeros

drop table Pasajeros

select *from Usuarios
select *from Envios
drop table Usuarios
select * from Ventas
Update Usuarios set TipoUsuario = 0 where UsuarioId = 1

create table Reservaciones(
ResevacionId int identity(1,1) primary key,
UsuarioId int references Usuarios(UsuarioId),
Lugar varchar(100),
CantidadAsiento int,
Fecha datetime,
esActiva bit
)

Select *from Reservaciones
drop table Reservaciones 
drop table Envios
drop table Paradas
drop table Usuarios
drop table VentasTickets
drop table VentasDetalle

create table Paradas(
ParadaId int identity(1,1) primary key,
Lugar varchar(100),
Telefono varchar(12)
)

Select *from paradas

create table Autobuses(
AutobusId int identity(1,1) primary key,
Ficha varchar(6),
Marca varchar(50),
Modelo varchar(50),
Ano int,
CantidadPasajeros int,
Aire bit
)

Select *from Autobuses

create table Choferes(
ChoferId int identity(1,1) primary key,
AutobusId int references Autobuses(AutobusId),
Nombres Varchar(40),
Apellidos varchar(40),
Cedula varchar(14),
AnosServicios int,
Telefono varchar(12),
)

Select * from Choferes
delete from Choferes

Create table Envios(
EnvioId int identity(1,1) primary key,
ChoferId int references Choferes(ChoferId),
UsuarioId int references Usuarios(UsuarioId),
Descripcion varchar(100),
TipoEnvio int,
Precio float,
Emisor varchar(40),
Receptor varchar(40),
Fecha datetime
)

Drop table Envios
select *from Envios
Delete from Envios where EnvioId = 3
select *from Choferes

select *from Usuarios

Select *from Envios

insert into Envios(Descripcion) values('Melvin la para')

create table Ventas(
VentaId int identity(1,1) primary key,
ChoferId int references Choferes(ChoferId),
Fecha date,
UsuarioId int references Usuarios(UsuarioId),
AutobusId int references Autobuses(AutobusId),
Total Float
)

drop table Ventas

Select *from Ventas


create table EnviosDetalle(
Id int identity(1,1) primary key,
VentaId int references Ventas(VentaId),
Descripcion varchar(100),
TipoEnvio int,
Precio float,
Emisor varchar(40),
Receptor varchar(40),
)

drop table EnviosDetalle

create table PasajerosDetalle(
Id int identity(1,1) primary key,
VentaId int references Ventas(VentaId),
PasajeroId int references Pasajeros(PasajeroId)
)

drop table PasajerosDetalle




delete from VentasDetalle

select e.EnvioId,e.Descripcion from VentasDetalle v inner join Envios e on v.EnvioId = e.EnvioId where v.VentaId = 3