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
    [RoutePrefix("api/comissao")]
    public class ComissaoController : ApiController
    {
        //GET
        [HttpGet]
        [Route("buscar")]
        public List<Comissao> buscarComissaoVendedor()
        {
            return new ComissaoService().buscarComissoes();
        }
    }
}
