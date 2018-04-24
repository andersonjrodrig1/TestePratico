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
    [RoutePrefix("api")]
    public class ProdutoController : ApiController
    {
        #region POST
        [HttpPost]
        [Route("produto")]
        public void CadastrarProduto([FromBody]Produto produto)
        {
            try
            {
                new ProdutoService().CadastrarProduto(produto);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        [Route("produto/export")]
        public MemoryStream ExportExcel(List<Produto> produtos)
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
        [Route("produto")]
        public List<Produto> ListarProdutos([FromUri]Produto produto)
        {
            try
            {
                return new ProdutoService().BuscarProdutos(produto);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet]
        [Route("produto/{nmProduto}")]
        public List<Produto> ListarProdutosNome(string nmProduto)
        {
            try
            {
                return new ProdutoService().BuscarProdutos(new Produto() { nmProduto = nmProduto });
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet]
        [Route("produto/{vrProduto:decimal}")]
        public List<Produto> ListarProdutosCodigo(decimal vrProduto)
        {
            try
            {
                return new ProdutoService().BuscarProdutos(new Produto() { vrProduto = vrProduto });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        #endregion

        #region PUT
        [HttpPut]
        [Route("produto/{cdProduto:int}")]
        public void AtualizarProduto(int cdProduto, [FromBody]Produto produto)
        {
            try
            {
                new ProdutoService().AtualizarProduto(cdProduto, produto);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        #endregion

        #region DELETE
        [HttpDelete]
        [Route("produto")]
        public bool DeletarProduto([FromBody] List<Produto> produtos)
        {
            try
            {
                new ProdutoService().DeletarProduto(produtos);
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
