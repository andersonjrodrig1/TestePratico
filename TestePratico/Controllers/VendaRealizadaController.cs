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
        [Route("venda_realizada")]
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
        [Route("venda_realizada")]
        public void RealizarVenda([FromBody]VendaRealizada vendaRealizada)
        {
            try
            {
                new VendaRealizadaService().RealizarVenda(vendaRealizada);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}