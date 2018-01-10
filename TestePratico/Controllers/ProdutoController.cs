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
        public List<Produto> listarProdutos([FromUri]Produto produto)
        {
            try
            {
                return new ProdutoService().buscarProdutos(produto);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // GET
        [HttpGet]
        [Route("listar/{nmProduto}")]
        public List<Produto> listarProdutosNome(string nmProduto)
        {
            try
            {
                return new ProdutoService().buscarProdutos(new Produto() { nmProduto = nmProduto });
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // GET
        [HttpGet]
        [Route("listar/{vrProduto:decimal}")]
        public List<Produto> listarProdutosCodigo(decimal vrProduto)
        {
            try
            {
                return new ProdutoService().buscarProdutos(new Produto() { vrProduto = vrProduto });
            }
            catch (Exception e)
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

        //DELETE
        [HttpDelete]
        [Route("deletar/{cdProduto:int}")]
        public bool deletarProduto(int cdProduto)
        {
            try
            {
                new ProdutoService().deletarProduto(new Produto() { cdProduto = cdProduto });
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
