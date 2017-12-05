using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestePratico.Models;

namespace TestePratico.Service
{
    public class VendedorService
    {
        public void cadastrarVendedor(Vendedor vendedor)
        {
            Modelo db = new Modelo();

            db.Vendedor.Add(vendedor);
            db.SaveChanges();
        }

        public List<Vendedor> buscarVendedores()
        {
            Modelo db = new Modelo();
            var vendedores = db.Vendedor.ToList();

            return vendedores;
        }
    }
}