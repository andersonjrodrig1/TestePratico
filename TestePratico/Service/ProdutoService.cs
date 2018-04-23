using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestePratico.Context;
using TestePratico.Models;
using TestePratico.Service;

namespace TestePratico.Repository
{
    public class ProdutoService
    {
        private Modelo db = null;

        public void CadastrarProduto(Produto produto)
        {
            if (db == null)
                db = new Modelo();

            db.Produto.Add(produto);
            db.SaveChanges();
        }

        public List<Produto> BuscarProdutos(Produto produto)
        {
            if (db == null)
                db = new Modelo();

            List<Produto> produtos = null;

            if (produto != null) {
                if (produto.vrProduto > 0 && !string.IsNullOrEmpty(produto.nmProduto))
                    produtos = db.Produto.Where(p => p.vrProduto == produto.vrProduto && p.nmProduto.ToUpper().Contains(p.nmProduto.ToUpper())).ToList();
                else
                    produtos = this.BuscarProdutoPorFiltro(produto);
            }
            else
                produtos = this.ListarProdutos();

            return produtos;
        }

        public void AtualizarProduto(int cdProduto, Produto produto)
        {
            if (cdProduto != produto.cdProduto)
                throw new Exception("Dados incosistentes!");

            if (db == null)
                db = new Modelo();

            var produtos = this.ListarProdutos();
            var prod = produtos.Where(p => p.cdProduto == produto.cdProduto).FirstOrDefault();

            if (prod == null)
                throw new Exception("Produto não encontrado!");

            db.Produto.Add(produto);
            db.Entry(produto).State = EntityState.Modified;
            db.SaveChanges();                
        }

        public List<Produto> ListarProdutos()
        {
            if (db == null)
                db = new Modelo();

            var produtos = db.Produto.ToList();

            return produtos;
        }

        public void DeletarProduto(List<Produto> produtos)
        {
            new VendaRealizadaService().DeletarVendaRealizada(produtos);

            if (db == null)
                db = new Modelo();

            produtos.ForEach(p => {
                db.Produto.Attach(p);
                db.Entry(p).State = EntityState.Deleted;
            });

            db.SaveChanges();
        }

        private List<Produto> BuscarProdutoPorFiltro(Produto produto)
        {
            var listProdutos = this.ListarProdutos();
            List<Produto> produtos = null;

            if (produto.vrProduto > 0)
            {
                var vrProduto = produto.vrProduto + decimal.Parse("0,99");
                produtos = listProdutos.Where(l => l.vrProduto >= produto.vrProduto && l.vrProduto <= vrProduto).ToList();
            }
            else if (!string.IsNullOrEmpty(produto.nmProduto))
                produtos = listProdutos.Where(l => l.nmProduto.ToLower().Contains(produto.nmProduto.ToLower())).ToList();

            return produtos;
        }
    }
}