using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestePratico.Models;
using TestePratico.Service;

namespace TestePratico.Repository
{
    public class ProdutoService
    {
        private Modelo db = null;

        public void cadastrarProduto(Produto produto)
        {
            if (db == null)
                db = new Modelo();

            db.Produto.Add(produto);
            db.SaveChanges();
        }

        public List<Produto> buscarProdutos(Produto produto)
        {
            if (db == null)
                db = new Modelo();

            List<Produto> produtos = null;

            if (produto != null) {
                if (produto.vrProduto > 0 && !string.IsNullOrEmpty(produto.nmProduto))
                    produtos = db.Produto.Where(p => p.vrProduto == produto.vrProduto && p.nmProduto.ToUpper().Contains(p.nmProduto.ToUpper())).ToList();
                else
                    produtos = this.buscarProdutoPorFiltro(produto);
            }
            else
                produtos = this.listarProdutos();

            return produtos;
        }

        public void atualizarProduto(int cdProduto, Produto produto)
        {
            if (cdProduto != produto.cdProduto)
                throw new Exception("Dados incosistentes!");

            if (db == null)
                db = new Modelo();

            var produtos = this.listarProdutos();
            var prod = produtos.Where(p => p.cdProduto == produto.cdProduto).FirstOrDefault();

            if (prod == null)
                throw new Exception("Produto não encontrado!");

            db.Produto.Add(produto);
            db.Entry(produto).State = EntityState.Modified;
            db.SaveChanges();                
        }

        public List<Produto> listarProdutos()
        {
            if (db == null)
                db = new Modelo();

            var produtos = db.Produto.ToList();

            return produtos;
        }

        public void deletarProduto(List<Produto> produtos)
        {
            new VendaRealizadaService().deletarVendaRealizada(produtos);

            if (db == null)
                db = new Modelo();

            produtos.ForEach(p => {
                db.Produto.Attach(p);
                db.Entry(p).State = EntityState.Deleted;
            });

            db.SaveChanges();
        }

        private List<Produto> buscarProdutoPorFiltro(Produto produto)
        {
            var listProdutos = this.listarProdutos();
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