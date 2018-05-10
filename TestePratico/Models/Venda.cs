using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestePratico.Models
{
    public class Venda
    {
        public int cdVenda { get; set; }

        public int cdProduto { get; set; }

        public int cdVendedor { get; set; }

        public int qtdProduto { get; set; }

        public decimal ttlVenda { get; set; }

        public DateTime dtVenda { get; set; }
    }
}