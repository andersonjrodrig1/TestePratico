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

        public List<Produto> buscarProdutos()
        {
            Modelo db = new Modelo();
            var produtos = db.Produto.ToList();

            return produtos;
        }
        
        public List<Produto> buscarProdutos(string nmProduto)
        {
            List<Produto> listProdutos = this.buscarProdutos();
            var produtos = listProdutos.Where(p => p.nmProduto.Contains(nmProduto)).ToList();

            return produtos;
        }

        public List<Produto> buscarProdutos(Produto produto)
        {
            Modelo db = new Modelo();
            List<Produto> produtos = null;

            if (produto != null && (!string.IsNullOrEmpty(produto.nmProduto) || produto.vrProduto > 0))
                produtos = db.Produto.Where(p => p.cdProduto == produto.cdProduto || p.vrProduto == produto.vrProduto).ToList();
            else
                produtos = this.buscarProdutos();

            return produtos;
        }

        public void atualizarProduto(Produto produto)
        {
            Modelo db = new Modelo();

            var produtos = this.buscarProdutos();
            var prod = produtos.Where(p => p.cdProduto == produto.cdProduto).FirstOrDefault();

            if(prod == null)
                throw new Exception("Produto não encontrado!");

            db.Produto.Add(produto);
            db.Entry(produto).State = EntityState.Modified;
            db.SaveChanges();                
        }
    }
}