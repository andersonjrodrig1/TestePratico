using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestePratico.Models;
using TestePratico.Repository;

namespace TestePratico.Service
{
    public class VendaRealizadaService
    {
        public List<VendaRealizada> buscarVendasDia()
        {
            Modelo db = new Modelo();

            List<Produto> produtos = null;
            List<Vendedor> vendedores = null;

            var agora = DateTime.Now.Date;
            var vendas = db.VendaRealizada.Where(v => DbFunctions.TruncateTime(v.dtVenda) == agora).ToList();

            if (vendas != null && vendas.Count > 0)
            {
                produtos = new ProdutoService().buscarProdutos();
                vendedores = new VendedorService().buscarVendedores();
            }

            foreach(var venda in vendas)
            {
                venda.Produto = produtos.Where(p => p.cdProduto == venda.cdProduto).FirstOrDefault();
                venda.Vendedor = vendedores.Where(v => v.cdVendedor == venda.cdVendedor).FirstOrDefault();
            }

            return vendas;
        }
    }
}