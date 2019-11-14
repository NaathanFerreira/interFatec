create database OrcamentoDigital
go

use OrcamentoDigital
go

create table Produtos
(
	Id int not null primary key identity,
	nome varchar(50) not null,
	preco money not null,
	descricao varchar(500) not null,
	quantidade_estoque int not null
)
go

insert into Produtos values ('Câmera', 100, 'Sensor noturno', 500)
insert into Produtos values ('Sensor Laser', 250, 'Sensor de movimento', 1200)

select * from Produtos

-----------------------------------------------------------------

create table Pessoas
(
	id int primary key identity,
	nome varchar(50) not null,
	email varchar(50) not null,
	cpf varchar(50) not null,
)
go

create table Clientes
(
	id_Pessoa int primary key references Pessoas,
	endereco varchar(200) not null
)
go

create table Funcionarios
(
	id_Pessoas int primary key references Pessoas,
	anosExperiencia int not null
)
go
