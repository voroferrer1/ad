	+Crear tabla categoria{
	create table categoria(
		id serial primary key,
		nombre varchar(50) not null unique
	);}
	+insertar en categoria{
		insert into categoria (nombre) values ('categoria 1');
		insert into categoria (nombre) values ('categoria 2');
		insert into categoria (nombre) values ('categoria 3');
