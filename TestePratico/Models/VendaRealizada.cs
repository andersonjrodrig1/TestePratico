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
        [Column(name: "cdVenda", TypeName = "int")]
        public int cdVenda { get; set; }

        #region Produto
        [Column(name: "cdProduto", TypeName = "int")]
        public int cdProduto { get; set; }

        public virtual Produto Produto { get; set; }
        #endregion

        #region Vendedor
        [Column(name: "cdVendedor", TypeName = "int")]
        public int cdVendedor { get; set; }

        public virtual Vendedor Vendedor { get; set; }
        #endregion

        [Column(name: "qtdProduto", TypeName = "int")]
        public int qtdProduto { get; set; }

        [Column(name: "ttlVenda", TypeName = "int")]
        public decimal ttlVenda { get; set; }

        [Column(name: "dtVenda", TypeName = "date")]
        public DateTime dtVenda { get; set; }        
    }
}
