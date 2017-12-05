using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestePratico.Models;
using TestePratico.Service;

namespace TestePratico.Controllers
{
    [RoutePrefix("api/vendedor")]
    public class VendedorController : ApiController
    {
        //POST
        [HttpPost]
        [Route("cadastrar")]
        public void cadastrarVendedor([FromBody]Vendedor vendedor)
        {
            try
            {
                new VendedorService().cadastrarVendedor(vendedor);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //GET
        [HttpGet]
        [Route("buscar")]
        public List<Vendedor> buscarVendedores()
        {
            try
            {
                return new VendedorService().buscarVendedores();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
