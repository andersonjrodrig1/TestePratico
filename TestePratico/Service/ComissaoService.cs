﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestePratico.Models;

namespace TestePratico.Service
{
    public class ComissaoService
    {
        public List<Comissao> BuscarComissoes()
        {
            /*
            var comissoes = new List<Comissao>();
            var vendasDia = new VendaRealizadaService().BuscarVendasRealizadas();

            if (vendasDia != null && vendasDia.Count > 0)
            {
                comissoes = new List<Comissao>();

                var vendasPorVendedor = vendasDia.GroupBy(
                    v => v.Vendedor, 
                    v => v.Produto, 
                    (key, g) => new { Vendedor = key, Produtos = g.ToList() });

                foreach (var vendas in vendasPorVendedor)
                {
                    Comissao comissao = new Comissao();
                    comissao.vendedor = vendas.Vendedor;
                    comissao.vrTotalVenda = 0;

                    foreach (var produto in vendas.Produtos)
                    {
                        comissao.vrTotalVenda += produto.vrProduto;
                    }

                    comissao.vrComissao = comissao.vrTotalVenda * 0.05m;

                    comissoes.Add(comissao);
                }
            }

            return comissoes;
            */

            return null;
        }
    }
}