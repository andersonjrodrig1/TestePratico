using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestePratico.Context;
using TestePratico.Models;

namespace TestePratico.Service
{
    public class VendedorService
    {
        public void CadastrarVendedor(Vendedor vendedor)
        {
            Modelo db = new Modelo();

            db.Vendedor.Add(vendedor);
            db.SaveChanges();
        }

        public List<Vendedor> BuscarVendedores()
        {
            Modelo db = new Modelo();
            var vendedores = db.Vendedor.ToList();

            return vendedores;
        }
    }
}