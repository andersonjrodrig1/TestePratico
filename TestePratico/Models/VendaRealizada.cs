namespace TestePratico.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VendaRealizada")]
    public partial class VendaRealizada
    {
        [Key]
        public int cdVenda { get; set; }

        public int cdProduto { get; set; }

        public int cdVendedor { get; set; }

        public int qtdProduto { get; set; }

        [Column(TypeName = "date")]
        public DateTime dtVenda { get; set; }

        public virtual Produto Produto { get; set; }

        public virtual Vendedor Vendedor { get; set; }
    }
}
