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
