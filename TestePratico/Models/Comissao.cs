using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestePratico.Models
{
    public class Comissao
    {
        public Vendedor vendedor { get; set; }
        public decimal vrTotalVenda { get; set; }
        public decimal vrComissao { get; set; }
    }
}