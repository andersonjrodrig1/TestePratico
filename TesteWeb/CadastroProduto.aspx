<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroProduto.aspx.cs" Inherits="TesteWeb.CadastroProduto" %>

<!DOCTYPE html>
<html lang="en" ng-app="CadastroProdutoController">
<head runat="server">
    <title>Loja de Vendas</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.2.25/angular.min.js"></script>
    <!-- <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.6.6/angular.min.js"></script> -->
    <script type="text/javascript" src="../Scripts/angular.js"></script>
    <script type="text/javascript" src="../Scripts/angular.min.js"></script>
    <script>
        var app = angular.module('CadastroProdutoController', []);

        app.controller('cadastroProdutos', ['$scope', '$http', function ($scope, $http) {
            $scope.title = 'Cadastro de Produtos';
            $scope.nome = 'Nome Produto';
            $scope.valor = 'Valor Produto';
            $scope.adicionarProduto = function (produto) {
                data = JSON.stringify(produto)
                $http.post('http://localhost:8090/api/produto/cadastrar', data)
                    .success(function (data, status, header, config) {
                        delete $scope.produto;
                        alert('Adicionado com sucesso!');
                        window.location.href = 'http://localhost:8091/ListaProdutos.aspx';
                    })
                    .error(function (data, status, header, config) {
                        alert('retorno: ' + data + ' status: ' + status);
                    });
            };
        }]);
    </script>
</head>
<body>
    <div class="container">
        <nav class="navbar navbar-default">
          <div class="container-fluid">
            <div class="navbar-header">
              <a class="navbar-brand" href="http://localhost:8091/Default.aspx">Principal</a>
            </div>
            <ul class="nav navbar-nav">
              <li><a href="http://localhost:8091/ListaProdutos.aspx">Lista de Produtos</a></li>
              <li><a href="http://localhost:8091/CadastroProduto.aspx">Cadastro de Produtos</a></li>
              <li><a href="http://localhost:8091/CadastroVendedor.aspx">Cadastro de Vendedor</a></li>
            </ul>
          </div>
        </nav>
        <div ng-controller="cadastroProdutos">
            <h2>{{title}}</h2>
            <form name="produtoForm">
                <div class="row">
                    <div class="col-sm-4">
                        <label>{{nome}}</label>
                        <input class="form-control" type="text" ng-model="produto.nmProduto" ng-required="true" placeholder="Digite nome produto" />
                    </div>
                    <div class="col-sm-4">
                        <label>{{valor}}</label>
                        <input class="form-control" type="text" ng-model="produto.vrProduto" ng-required="true" placeholder="Digite valor produto" />
                    </div>
                    <div class="col-sm-3" style="top:25px;">
                        <input class="btn btn-success" type="button" value="Adicionar" ng-click="adicionarProduto(produto);" ng-disabled="produtoForm.$invalid" />
                    </div>
                </div>
            </form>
        </div>
    </div>
</body>
</html>