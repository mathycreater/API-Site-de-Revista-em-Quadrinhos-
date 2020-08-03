--1) Criar e ir para database
create database CeusDespedacados;
use CeusDespedacados;

--Criando tabelas
create table Imagens(
    Id int IDENTITY(1,1) PRIMARY KEY not null,
    Nome varchar(250) not null,
    Descricao VARCHAR(1000) NULL,
    Link VARCHAR(255) not null,
    DtInicioPub smalldatetime not null 

)


create table Autor(
    Nome varchar (100) not Null,
    Imglinkautor varchar (400) not Null,
    Sobre Varchar(1000) Null,
    FacebooklinkNot varchar (400) Null,
    InstagramLink varchar (400) Null,
    TwitterLink varchar (400) Null, 

)

create table Categorias(
    Id int IDENTITY(1,1) PRIMARY KEY not null,
    Nome varchar (250) Not null,
    Descricao varchar (1000) null,
)

create table CategoriaImagem(
    CategoriaId int not null,
    ImagemId int not null,
    CONSTRAINT FK_CategoriaImagem_Imagens FOREIGN key (ImagemId) references Imagens(Id),
    CONSTRAINT FK_CategoriaImagem_Categorias FOREIGN KEY (CategoriaID) references Categorias(Id),
)

create table Backgroundimage(
    imageid int not null,
    hrainicioimage smalldatetime not null ,
    hrafimimage smalldatetime not null,
    CONSTRAINT FK_Backgroundimage_imagens FOREIGN Key (Imageid) references Imagens(id),

)


--Inserindo tabela de autor


insert into Autor(Nome, Imglinkautor)
VALUES('Matheus Correa', 'https://mathybucket.s3.us-east-2.amazonaws.com/nature-3082832_1920.jpg')


insert into Categorias(Nome)
VALUES ( 'Personagens' ), ( 'Cenário'), ( 'Atualizações'), ( 'Páginas')

--Get
SELECT * from Categorias


--GetbyId
SELECT * from Categorias
where Id <> 1


--GetbyNome
SELECT * from Categorias
where Nome like '%a%'



select * from Imagens


insert into Imagens(Nome, Link, DtInicioPub) VALUES
('Poke Messenger', 'https://mathybucket.s3.us-east-2.amazonaws.com/images/WhatsApp+Image+2019-09-12+at+22.21.49.jpeg', GETDATE()),
('Aurora', 'https://mathybucket.s3.us-east-2.amazonaws.com/images/aurora-1185464_1920.jpg', GETDATE()),
('Mountain', 'https://mathybucket.s3.us-east-2.amazonaws.com/images/mountain-4424657_1920.jpg', GETDATE())


select * from Imagens


select * from Imagens

select * from Categorias

select * from CategoriaImagem

insert into CategoriaImagem values(1, 1)


insert into CategoriaImagem values(3, 1)
insert into CategoriaImagem values(3, 3)
insert into CategoriaImagem values(3, 2)

select --* 
i.Id, i.Nome, i.Descricao, i.Link, DATEADD(HOUR, -3, DtInicioPub) DtInicioPub
from Imagens i
inner join CategoriaImagem ci on ci.ImagemId = i.Id
inner join Categorias c on c.Id = ci.CategoriaId
where c.id = 3

select * from Imagens
where DtInicioPub <= GETDATE();

select c.* 
from Categorias c
inner join CategoriaImagem ci on ci.CategoriaId = c.Id
inner join Imagens i on i.Id = ci.ImagemId
where i.id = 1


select 
i.Id, i.Nome, i.Descricao, i.Link, DATEADD(HOUR, -3, DtInicioPub) DtInicioPub
from Imagens i
inner join Backgroundimage bi on bi.imageid = i.Id
where FORMAT(GETDATE(), 'HH:mm') BETWEEN FORMAT(bi.hrainicioimage, 'HH:mm') and FORMAT(bi.hrafimimage, 'HH:mm')

select GETDATE()

INSERT into Backgroundimage values(4, '2019-09-28 23:32', '2019-09-28 23:55')
UPDATE Backgroundimage set
hrafimimage = '2019-09-28 23:33'


--select  
--Id, Nome, Descricao, Link, DATEADD(HOUR, -3, DtInicioPub) DtInicioPub
--from Imagens


insert into Imagens
values('Natureza', null,'https://mathybucket.s3.us-east-2.amazonaws.com/nature-3082832_1920.jpg', '2019-09-29 21:56:53.530')



select * from Backgroundimage


delete from Backgroundimage



--Alterar estrutura da tabela background image

alter TABLE Backgroundimage
drop COLUMN hrainicioimage

alter TABLE Backgroundimage
drop COLUMN hrafimimage
--Booleado é bit
ALTER TABLE Backgroundimage
add isDia  bit not null

GetBackground



