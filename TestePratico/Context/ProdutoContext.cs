using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TestePratico.Models;

namespace TestePratico.Context
{
    public class ProdutoContext : EntityTypeConfiguration<Produto>
    {
        public ProdutoContext() { }
    }
}