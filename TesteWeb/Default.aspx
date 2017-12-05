<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TesteWeb.Default" %>

<!DOCTYPE html>
<html lang="en" ng-app="DefaultController">
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
        var app = angular.module('DefaultController', []);
        
        app.controller('RelatorioVendas', ['$scope', '$http', function ($scope, $http) {
            $scope.title = 'Relatório de Vendas e Comissões';
            $scope.subTitleVend = 'Vendas';
            $scope.subTitleCom = 'Comissões';
            $scope.vendedor = 'Vendedor';
            $scope.produto = 'Produto';
            $scope.valorUnit = 'Valor Unitário';
            $scope.qtd = 'Quantidade';
            $scope.total = 'Total';
            $scope.ttlVenda = 'Total Venda'
            $scope.comissao = 'Comissão';
            $http.get('http://localhost:8090/api/vendaRealizada/buscar')
                .success(function (data, status, header, config) {
                    $scope.vendas = data;
                }).
                error(function (data, status, header, config) {
                    alert('retorno: ' + data + ' status: ' + status);
                });
            $http.get('http://localhost:8090/api/comissao/buscar')
                .success(function (data, status, header, config) {
                    $scope.comissoes = data;
                }).
                error(function (data, status, header, config) {
                    alert('retorno: ' + data + ' status: ' + status);
                });
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
        <div ng-controller="RelatorioVendas">
            <h2>{{title}}</h2>
            <h3>{{subTitleVend}}</h3>
            <table class="table table-striped">
                <thead>
                    <tr>
                        <th>{{vendedor}}</th>
                        <th>{{produto}}</th>
                        <th>{{valorUnit}}</th>
                        <th>{{qtd}}</th>
                        <th>{{total}}</th>
                    </tr>
                </thead>
                <tbody>
                    <tr ng-repeat="venda in vendas">
                        <td>{{venda.Vendedor.nmVendedor}}</td>
                        <td>{{venda.Produto.nmProduto}}</td>
                        <td>R$ {{venda.Produto.vrProduto | number:2}}</td>
                        <td>{{venda.qtdProduto}}</td>
                        <td>R$ {{venda.Produto.vrProduto * venda.qtdProduto | number:2}}</td>
                    </tr>
                </tbody>
            </table>
            <h3>{{subTitleCom}}</h3>
            <table class="table table-striped">
                <thead>
                    <tr>
                        <th>{{vendedor}}</th>
                        <th>{{ttlVenda}}</th>
                        <th>{{comissao}}</th>
                    </tr>
                </thead>
                <tbody>
                    <tr ng-repeat="comissao in comissoes">
                        <td>{{comissao.vendedor.nmVendedor}}</td>
                        <td>R$ {{comissao.vrTotalVenda | number:2}}</td>
                        <td>R$ {{comissao.vrComissao | number:2}}</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</body>
</html>
