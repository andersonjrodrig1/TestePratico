using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestePratico.Models;

namespace TestePratico.Repository
{
    public class ProdutoService
    {
        public void cadastrarProduto(Produto produto)
        {
            Modelo db = new Modelo();

            db.Produto.Add(produto);
            db.SaveChanges();
        }

        public List<Produto> buscarProdutos(Produto produto)
        {
            Modelo db = new Modelo();
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

            Modelo db = new Modelo();

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
            Modelo db = new Modelo();
            var produtos = db.Produto.ToList();

            return produtos;
        }

        public void deletarProduto(Produto produto)
        {
            Modelo db = new Modelo();

            var produtos = this.listarProdutos();
            var prod = produtos.Where(p => p.cdProduto == produto.cdProduto).FirstOrDefault();

            if (prod == null)
                throw new Exception("Produto não encontrado!");

            db.Produto.Attach(produto);
            db.Entry(produto).State = EntityState.Deleted;

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