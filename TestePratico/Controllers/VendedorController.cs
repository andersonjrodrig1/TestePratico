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
        public void CadastrarVendedor([FromBody]Vendedor vendedor)
        {
            try
            {
                new VendedorService().CadastrarVendedor(vendedor);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //GET
        [HttpGet]
        [Route("buscar")]
        public List<Vendedor> BuscarVendedores()
        {
            try
            {
                return new VendedorService().BuscarVendedores();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
