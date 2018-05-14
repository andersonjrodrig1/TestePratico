using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TestePratico.Models;
using TestePratico.Service;

namespace TestePratico.Controllers
{
    [RoutePrefix("api")]
    public class VendaRealizadaController : ApiController
    {
        //GET
        [HttpGet]
        [Route("venda")]
        public List<Venda> BuscarVendasRealizadas()
        {
            try
            {
                return new VendaRealizadaService().BuscarVendasRealizadas();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //POST
        [HttpPost]
        [Route("venda")]
        public void RealizarVenda([FromBody]Venda venda)
        {
            try
            {
                new VendaRealizadaService().RealizarVenda(venda);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}