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
        private Modelo db = null;

        public List<VendaRealizada> buscarVendasDia()
        {
            if (db == null)
                db = new Modelo();

            List<Produto> produtos = null;
            List<Vendedor> vendedores = null;

            var agora = DateTime.Now.Date;
            var vendas = db.VendaRealizada.Where(v => DbFunctions.TruncateTime(v.dtVenda) == agora).ToList();

            if (vendas != null && vendas.Count > 0)
            {
                produtos = new ProdutoService().listarProdutos();
                vendedores = new VendedorService().buscarVendedores();
            }

            foreach(var venda in vendas)
            {
                venda.Produto = produtos.Where(p => p.cdProduto == venda.cdProduto).FirstOrDefault();
                venda.Vendedor = vendedores.Where(v => v.cdVendedor == venda.cdVendedor).FirstOrDefault();
            }

            return vendas;
        }

        public List<VendaRealizada> buscarVendas()
        {
            if (db == null)
                db = new Modelo();

            var vendas = db.VendaRealizada.ToList();

            return vendas;
        }

        public void deletarVendaRealizada(VendaRealizada venda)
        {
            if (db == null)
                db = new Modelo();

            db.VendaRealizada.Attach(venda);
            db.Entry(venda).State = EntityState.Deleted;

            db.SaveChanges();
        }

        public void deletarVendaRealizada(List<Produto> produtos)
        {
            if (db == null)
                db = new Modelo();

            var vendas = this.buscarVendas();
            var listVendas = new List<VendaRealizada>();

            produtos.ForEach(produto => {
                var vds = vendas.Where(v => v.cdProduto == produto.cdProduto).ToList();

                if (vds != null)
                    listVendas.AddRange(vds);
            });

            if (listVendas != null && listVendas.Count > 0)
            {
                listVendas.ForEach(v =>
                {
                    db.VendaRealizada.Add(v);
                    db.Entry(v).State = EntityState.Deleted;
                    db.VendaRealizada.Remove(v);
                });
            }

            db.SaveChanges();
        }
    }
}