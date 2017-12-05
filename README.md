# TestePratico
Teste pratico pra fins de avalização

#Aplicacao
Criação de uma solução com 2 projetos: 
* TestePratico -> 
	aplicação WebAPI Rest com seguintes recursos:
		- retorno de valores JSON 
		- persitencia com EntityFramework v6.2.0
		- AspNet.Cors para inibir a falha da comunicação http
		- Paradigma POO (Programação Orientada à Objetos)
		- Uso do IIS Local na porta 8090
		- String de conexão utilizada no Web.config
			<connectionStrings>
				<add name="Modelo" connectionString="data source=Anderson;initial catalog=TestePratico;persist security info=True;user id=sa;password=master;MultipleActiveResultSets=True;App=EntityFramework" providerName="System.Data.SqlClient" />
			</connectionStrings>
		- Url's da aplicação:
			http://localhost:8090/api/vendaRealizada/buscar - get
			http://localhost:8090/api/comissao/buscar - get
			http://localhost:8090/api/produto/listar - get
			http://localhost:8090/api/produto/pesquisar/nmProduto - get
			http://localhost:8090/api/produto/atualizar - put
			http://localhost:8090/api/produto/cadastrar - post
			http://localhost:8090/api/vendedor/buscar - get
			http://localhost:8090/api/vendedor/cadastrar - post

* TesteWeb -> 
	aplicação WebForm com os seguintes recursos:
		- consome a WebApi 
		- AngularJS para requisição e exibição de informações. (Obs.: Recursos do Angular foram implementados inline)
		- Bootstrap para melhorar a apresentação da interface
		- Uso do IIS Local na porta 8091
		- Url's da aplicação:
			http://localhost:8091/Default.aspx
			http://localhost:8091/ListaProdutos.aspx
			http://localhost:8091/CadastroProduto.aspx
			http://localhost:8091/CadastroVendedor.aspx

# Scripts
Abaixo segue scripts usados durante a criação da aplicação

/* Criação do Banco de Dados */
create database TestePratico

use TestePratico
/* Produto */
create table Produto(
	cdProduto int not null identity,
	nmProduto varchar(50) not null,
	vrProduto decimal(5,2) not null,
	primary key(cdProduto)
)

/* Vendedor */
create table Vendedor(
	cdVendedor int not null identity,
	nmVendedor varchar(30) not null,
	nrTelefone varchar(15) not null,
	primary key(cdVendedor)
)

/* Venda Realizada */
create table VendaRealizada(
	cdVenda int not null identity,
	cdProduto int not null,
	cdVendedor int not null,
	qtdProduto int not null,
	dtVenda date not null,
	primary key(cdVenda),
	constraint fk_venda_produto foreign key (cdProduto) references Produto(cdProduto),
	constraint fk_venda_vendedor foreign key (cdVendedor) references Vendedor(cdVendedor)
)

/* inserir produtos */
insert into Produto values('Camisa Regata', 29.90)
insert into Produto values('Camisa Polo', 39.90)
insert into Produto values('Camisa Social', 59.99)
insert into Produto values('Bermuda', 40.00)
insert into Produto values('Bermuda Jeans', 50.00)
insert into Produto values('Calça Jeans', 90.00)
insert into Produto values('Meias', 10.00)
insert into Produto values('Blusas', 109.90)

/* inserir vendedores */
insert into Vendedor values('João','34 99977-0909')
insert into Vendedor values('Maria','34 99232-3232')
insert into Vendedor values('Jose','34 99119-0990')

/* inserir vendas realizadas */
insert into VendaRealizada values(7,1,4,GETDATE())
insert into VendaRealizada values(1,1,3,GETDATE())
insert into VendaRealizada values(2,1,5,GETDATE())
insert into VendaRealizada values(1,2,6,GETDATE())
insert into VendaRealizada values(2,2,7,GETDATE())
insert into VendaRealizada values(5,2,3,GETDATE())
insert into VendaRealizada values(8,2,7,GETDATE())
insert into VendaRealizada values(5,3,3,GETDATE())
insert into VendaRealizada values(8,3,7,GETDATE())