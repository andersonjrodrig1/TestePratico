using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestePratico.Models;
using TestePratico.Repository;

namespace TestePratico.Controllers
{
    [RoutePrefix("api/produto")]
    public class ProdutoController : ApiController
    {
        //POST
        [HttpPost]
        [Route("cadastrar")]
        public void cadastrarProduto([FromBody]Produto produto)
        {
            try
            {
                new ProdutoService().cadastrarProduto(produto);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // GET
        [HttpGet]
        [Route("listar")]
        public List<Produto> listarProdutos()
        {
            try
            {
                return new ProdutoService().buscarProdutos();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // GET
        [HttpGet]
        [Route("pesquisar/{nmProduto}")]
        public List<Produto> listarProdutos(string nmProduto)
        {
            try
            {
                return new ProdutoService().buscarProdutos(nmProduto);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //PUT
        [HttpPut]
        [Route("atualizar")]
        public void atualizarProduto([FromBody]Produto produto)
        {
            try
            {
                new ProdutoService().atualizarProduto(produto);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
