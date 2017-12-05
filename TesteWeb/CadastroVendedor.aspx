<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroVendedor.aspx.cs" Inherits="TesteWeb.CadastroVendedor" %>

<!DOCTYPE html>
<html lang="en" ng-app="CadastroVendedorController">
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
        var app = angular.module('CadastroVendedorController', []);

        app.controller('cadastroVendedor', ['$scope', '$http', function ($scope, $http) {
            $scope.title = 'Cadastro de Vendedores';
            $scope.nome = 'Nome Vendedor';
            $scope.telefone = 'Telefone';
            $http.get('http://localhost:8090/api/vendedor/buscar')
                .success(function (data, status, header, config) {
                    $scope.vendedores = data;
                }).
                error(function (data, status, header, config) {
                    alert('retorno: ' + data + ' status: ' + status);
                });
            $scope.cadastrarVendedor = function (vendedor) {
                data = JSON.stringify(vendedor);
                $http.post('http://localhost:8090/api/vendedor/cadastrar', data)
                    .success(function (data, status, header, config) {
                        delete $scope.vendedor;
                        alert('Cadastrado com sucesso!');
                        window.location.href = 'http://localhost:8091/CadastroVendedor.aspx';
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
        <div ng-controller="cadastroVendedor">
            <h2>{{title}}</h2>
            <form name="vendedorForm">
                <div class="row">
                    <div class="col-sm-4">
                        <label>{{nome}}</label>
                        <input class="form-control" type="text" ng-model="vendedor.nmVendedor" ng-required="true" placeholder="Digite nome vendedor" />
                    </div>
                    <div class="col-sm-4">
                        <label>{{telefone}}</label>
                        <input class="form-control" type="text" ng-model="vendedor.nrTelefone" ng-required="true" placeholder="Digite telefone vendedor" />
                    </div>
                    <div class="col-sm-3" style="top:25px;">
                        <input class="btn btn-success" type="button" value="Cadastrar" ng-click="cadastrarVendedor(vendedor);" ng-disabled="vendedorForm.$invalid" />
                    </div>
                </div>
            </form>
            <br class="clearfix" />
            <table class="table table-bordered table-striped">
                <thead>
                    <tr>
                        <th>
                            Código
                        </th>
                        <th>
                            Nome Vendedor
                        </th>
                        <th>
                            Contato
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr ng-repeat="vendedor in vendedores">
                        <td>{{vendedor.cdVendedor}}</td>
                        <td>{{vendedor.nmVendedor}}</td>
                        <td>{{vendedor.nrTelefone}}</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</body>
</html>
