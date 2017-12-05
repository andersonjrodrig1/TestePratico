namespace TestePratico.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Produto")]
    public partial class Produto
    {
        [Key]
        public int cdProduto { get; set; }

        [Required]
        [StringLength(50)]
        public string nmProduto { get; set; }

        public decimal vrProduto { get; set; }
    }
}
