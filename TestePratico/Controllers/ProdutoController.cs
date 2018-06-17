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
        public Produto CadastrarProduto([FromBody]Produto produto)
        {
            try
            {
                return new ProdutoService().CadastrarProduto(produto);
            }
            catch(Exception ex)
            {
                throw ex;
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
            catch (Exception ex)
            {
                throw ex;
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
            catch(Exception ex)
            {
                throw ex;
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
            catch(Exception ex)
            {
                throw ex;
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region PUT
        [HttpPut]
        [Route("produto/{cdProduto:int}")]
        public Produto AtualizarProduto(int cdProduto, [FromBody]Produto produto)
        {
            try
            {
                return new ProdutoService().AtualizarProduto(cdProduto, produto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region DELETE
        [HttpDelete]
        [Route("produto")]
        public bool DeletarProdutos([FromBody] List<Produto> produtos)
        {
            try
            {
                new ProdutoService().DeletarProdutos(produtos);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        [Route("produto/{cdProduto:int}")]
        public bool DeletarProduto(int cdProduto)
        {
            try
            {
                new ProdutoService().DeletarProduto(new Produto() { cdProduto = cdProduto });
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
