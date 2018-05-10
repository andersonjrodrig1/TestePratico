using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestePratico.Models
{
    public partial class VendaRealizada
    {
        public Venda Venda { get; set; }

        public Produto Produto { get; set; }

        public Vendedor Vendedor { get; set; }
    }
}
