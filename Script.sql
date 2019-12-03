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

---------------------------------------------------
create View v_funcionarios
AS
select id, nome, email, cpf, anosExperiencia
from Pessoas p, Funcionarios f
where p.id = f.id_Pessoas
go


create View v_clientes
AS
select id, nome, email, cpf, endereco
from Pessoas p, Clientes c
where p.id = c.id_Pessoa
go
-----------------------------------------------------
create procedure cadastroCliente
(
	@nome varchar(50),
	@email varchar(50),
	@cpf varchar(50),
	@endereco varchar(200)
)
as
begin
	begin try
		begin tran
			insert into Pessoas values  (@nome, @email, @cpf)
			insert into clientes values (@@IDENTITY, @endereco)
		commit
		return 0 -- sem problemas
	end try
	begin catch
		rollback
		return 1 --problemas
	end catch
end -- fim da procedure
go


create procedure cadastroFuncionario
(
	@nome varchar(50),
	@email varchar(50),
	@cpf varchar(50),
	@anosExperiencia varchar(200)
)
as
begin
	begin try
		begin tran
			insert into Pessoas values  (@nome, @email, @cpf)
			insert into clientes values (@@IDENTITY, @anosExperiencia)
		commit
		return 0 -- sem problemas
	end try
	begin catch
		rollback
		return 1 --problemas
	end catch
end -- fim da procedure
go
