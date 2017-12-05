﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TestePratico.Models;
using TestePratico.Service;

namespace TestePratico.Controllers
{
    [RoutePrefix("api/vendaRealizada")]
    public class VendaRealizadaController : ApiController
    {
        //GET
        [HttpGet]
        [Route("buscar")]
        public List<VendaRealizada> buscarVendasDia()
        {
            try
            {
                return new VendaRealizadaService().buscarVendasDia();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}