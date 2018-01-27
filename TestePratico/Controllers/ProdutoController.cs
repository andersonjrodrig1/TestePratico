using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestePratico.Models;
using TestePratico.Repository;
using TestePratico.Service;

namespace TestePratico.Controllers
{
    [RoutePrefix("api/produto")]
    public class ProdutoController : ApiController
    {
        #region POST
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

        [HttpPost]
        [Route("export")]
        public MemoryStream exportExcel(List<Produto> produtos)
        {
            try
            {
                return new ExcelService().ExportExcel<Produto>(produtos);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        #endregion

        #region GET
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

        #endregion

        #region PUT
        [HttpPut]
        [Route("atualizar/{cdProduto:int}")]
        public void atualizarProduto(int cdProduto, [FromBody]Produto produto)
        {
            try
            {
                new ProdutoService().atualizarProduto(cdProduto, produto);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        #endregion

        #region DELETE
        [HttpDelete]
        [Route("deletar")]
        public bool deletarProduto([FromBody] List<Produto> produtos)
        {
            try
            {
                new ProdutoService().deletarProduto(produtos);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        #endregion
    }
}
