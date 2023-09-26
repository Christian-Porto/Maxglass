drop database if exists ecommerce;
create database ecommerce;
use ecommerce;

create table cliente (
    id int primary key auto_increment,
    tipo int,
    cnpj varchar(14),
    razaosocial varchar(70),
    ie varchar(14),
    nomefantasia varchar(100),
    nome varchar(100),
    sobrenome varchar(100),
    telefone varchar(11),
    cep varchar(8),
    cpf varchar(11),
    email varchar (100),
    passwordhash varchar(255)
);

create table produto (
    id int primary key auto_increment,
    tipo numeric(3),
    nome varchar(100),
    altura decimal(5, 2),
    largura decimal(5, 2),
    profundidade decimal(5, 2),
    valor decimal(10, 2),
    situacao numeric(1), 
    faixa varchar(50),
    posicao varchar(50),
    aro varchar(50),
    borda varchar(50),
    carcaca varchar(50),
    friso numeric(1),
    lente varchar(50),
    aberturafriso numeric(1),
    moldura varchar(50),
    furoescapamento numeric(1),
    aberturaspoiler numeric(1),
    capa varchar(50),
    piscaalerta numeric(1),
    sensorpontocego numeric(1),
    materialpalheta varchar(50),
    materialborracha varchar(50),
    idmarca int,
    idcategoria int,
    idequivalencia int
);

create table estoque (
    id int primary key auto_increment,
    cep varchar(8),
    descricao varchar(100)
);

create table marca (
    id int primary key auto_increment,
    nome varchar(100)
);

create table pagamento (
    id int primary key auto_increment,
    valor decimal(10, 2),
    idpedido int
);

create table pedido (
    id int primary key auto_increment,
    cep varchar(8),
    datapedido date,
    dataprevistaentrega date,
    valor decimal(10, 2),
    situacao numeric(2),
    dataprazo date,
    numeroendereco varchar(20),
    complementoendereco varchar(100),
    idcliente int,
    idfreteregiao int
);

create table categoria (
    id int primary key auto_increment,
    descricao varchar(100)
);

create table anocompatibilidade (
    id int primary key auto_increment,
    ano varchar(4)
);

create table veiculomodelo (
    id int primary key auto_increment,
    descricao varchar(100),
    idequivalencia int
);

create table imagem (
    id int primary key auto_increment, 
    url varchar(255)
);

create table equivalencia (
    id int primary key auto_increment,
    chave varchar(5)
);

create table freteregiao (
    id int primary key auto_increment,
    regiao varchar(50),
    valor decimal(10, 2)
);

create table tipopagamento (
    parcela int,
    valor decimal(10, 2),
    id int primary key auto_increment,
    tipo int,
    idpagamento int
);

create table estoqueproduto (
	id int primary key auto_increment,
    idestoque int,
    idproduto int,
    quantidade numeric(10)
);

create table itempedido (
	id int primary key auto_increment,
    idproduto int,
    idpedido int,
    quantidade numeric(10)
);

create table favoritaproduto (
    idproduto int,
    idcliente int
);

create table anoveiculo (
    idanocompatibilidade int,
    idveiculomodelo int
);

create table imagemproduto (
    idimagem int,
    idproduto int
);

CREATE TABLE estado (
	id int primary key auto_increment,
	nome varchar(75),
	uf varchar(2)
);

CREATE TABLE cidade (
	id int primary key,
	nome varchar(120),
    idestado int,
    foreign key (idestado) references estado (id) 
);

CREATE TABLE endereco (
	id int primary key,
	rua varchar(120),
    numero int,
    complemento varchar(120),
    idcliente int,
    foreign key (idcliente) references cliente (id) 
);

alter table produto add constraint fkproduto2
    foreign key (idmarca)
    references marca (id)
    on delete cascade;
 
alter table produto add constraint fkproduto3
    foreign key (idcategoria)
    references categoria (id)
    on delete cascade;
 
alter table produto add constraint fkproduto4
    foreign key (idequivalencia)
    references equivalencia (id)
    on delete cascade;
 
alter table pagamento add constraint fkpagamento2
    foreign key (idpedido)
    references pedido (id)
    on delete cascade;
 
alter table pedido add constraint fkpedido2
    foreign key (idcliente)
    references cliente (id)
    on delete cascade;
 
alter table pedido add constraint fkpedido3
    foreign key (idfreteregiao)
    references freteregiao (id)
    on delete cascade;


alter table veiculomodelo add constraint fkveiculomodelo2
    foreign key (idequivalencia)
    references equivalencia (id)
    on delete cascade;
    
alter table tipopagamento add constraint fktipopagamento2
    foreign key (idpagamento)
    references pagamento (id)
    on delete restrict;
 
alter table estoqueproduto add constraint fkestoqueproduto1
    foreign key (idestoque)
    references estoque (id)
    on delete restrict;
 
alter table estoqueproduto add constraint fkestoqueproduto2
    foreign key (idproduto)
    references produto (id)
    on delete set null;
 
alter table itempedido add constraint fkpedidoproduto1
    foreign key (idproduto)
    references produto (id)
    on delete restrict;
 
alter table itempedido add constraint fkpedidoproduto2
    foreign key (idpedido)
    references pedido (id)
    on delete set null;
 
alter table favoritaproduto add constraint fkfavoritaproduto1
    foreign key (idproduto)
    references produto (id)
    on delete set null;
 
alter table favoritaproduto add constraint fkfavoritaproduto2
    foreign key (idcliente)
    references cliente (id)
    on delete set null;
 
alter table anoveiculo add constraint fkanoveiculo1
    foreign key (idanocompatibilidade)
    references anocompatibilidade (id)
    on delete restrict;
 
alter table anoveiculo add constraint fkanoveiculo2
    foreign key (idveiculomodelo)
    references veiculomodelo (id)
    on delete set null;
 
alter table imagemproduto add constraint fkimagemproduto1
    foreign key (idimagem)
    references imagem (id)
    on delete restrict;
 
alter table imagemproduto add constraint fkimagemproduto2
    foreign key (idproduto)
    references produto (id)
    on delete set null;