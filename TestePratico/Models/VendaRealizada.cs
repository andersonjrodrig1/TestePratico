namespace TestePratico.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VENDA_REALIZADA")]
    public partial class VendaRealizada
    {
        [Key]
        [Column(name: "CD_VENDA", TypeName = "int")]
        public int cdVenda { get; set; }

        #region Produto
        [Column(name: "CD_PRODUTO", TypeName = "int")]
        public int cdProduto { get; set; }

        public virtual Produto Produto { get; set; }
        #endregion

        #region Vendedor
        [Column(name: "CD_VENDEDOR", TypeName = "int")]
        public int cdVendedor { get; set; }

        public virtual Vendedor Vendedor { get; set; }
        #endregion

        [Column(name: "QTD_PRODUTO", TypeName = "int")]
        public int qtdProduto { get; set; }

        [Column(name: "TTL_VENDA", TypeName = "int")]
        public decimal ttlVenda { get; set; }

        [Column(name: "DT_VENDA", TypeName = "date")]
        public DateTime dtVenda { get; set; }        
    }
}
