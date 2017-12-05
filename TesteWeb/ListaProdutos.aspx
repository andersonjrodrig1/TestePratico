<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaProdutos.aspx.cs" Inherits="TesteWeb.ListaProdutos" %>

<!DOCTYPE html>
<html lang="en" ng-app="ListaProdutosController">
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
        var app = angular.module('ListaProdutosController', []);

        app.controller('listaProdutos', ['$scope', '$http', function ($scope, $http) {
            $scope.title = 'Lista de Produtos Cadastrados';
            $scope.nome = 'Nome Produto';
            $http.get('http://localhost:8090/api/produto/listar')
                .success(function (data, status, header, config) {
                    $scope.produtos = data;
                })
                .error(function (data, status, header, config) {
                    alert('retorno: ' + data + ' status: ' + status);
                });
            $scope.pesquisarProduto = function (nmProduto) {
                $http.get('http://localhost:8090/api/produto/pesquisar/' + nmProduto)
                    .success(function (data, status, header, config) {
                        $scope.produtos = data;
                    })
                    .error(function (data, status, header, config) {
                        alert('retorno: ' + data + ' status: ' + status);
                    });
            };
            $scope.atualizarProduto = function (produto) {
                data = JSON.stringify(produto)
                $http.put('http://localhost:8090/api/produto/atualizar/', data)
                    .success(function (data, status, header, config) {
                        alert('Produto atualizado!');
                        window.location.reload();
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
        <div ng-controller="listaProdutos">
            <h2>{{title}}</h2>
            <form name="produtoForm">
                <div class="row">
                    <div class="col-sm-6">
                        <label>{{nome}}</label>
                        <input class="form-control" type="text" ng-model="nmProduto" ng-required="true" placeholder="Digite nome produto" />
                    </div>
                    <div class="col-sm-3" style="top:25px;">
                        <input class="btn btn-primary" type="button" value="Pesquisar" ng-click="pesquisarProduto(nmProduto);" ng-disabled="produtoForm.$invalid" />
                    </div>
                </div>
            </form>
            <br class="clearfix" />
            <table class="table">
                <thead>
                    <tr>
                        <th colspan="4">
                            <div class="col-sm-1">
                                Código
                            </div>
                            <div class="col-sm-4">
                                Nome
                            </div>
                            <div class="col-sm-2">
                                Valor R$
                            </div>
                            <div class="col-sm-2">
                                Ações
                            </div>
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr ng-repeat="prod in produtos track by $index">
                        <form name="listaForm_{{$index}}">
                            <td colspan="4">
                                <div class="col-sm-1">
                                    <input class="form-control" type="text" ng-model="prod.cdProduto" ng-disabled="true" />
                                </div>
                                <div class="col-sm-4">
                                    <input class="form-control" type="text" ng-model="prod.nmProduto" ng-required="true" />
                                </div>
                                <div class="col-sm-2">
                                    <input class="form-control" type="text" ng-model="prod.vrProduto" ng-required="true" />
                                </div>
                                <div class="col-sm-2">
                                    <input class="btn btn-success" type="button" value="Atualizar" ng-click="atualizarProduto(prod);" ng-disabled="listaForm_{{$index}}.$invalid"/>
                                </div>
                            </td>
                        </form>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</body>
</html>