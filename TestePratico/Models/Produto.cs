namespace TestePratico.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PRODUTO")]
    public partial class Produto
    {
        [Key]
        [Column(name: "CD_PRODUTO", TypeName = "int")]
        public int cdProduto { get; set; }

        [Required]
        [StringLength(50)]
        [Column(name: "NM_PRODUTO", TypeName = "varchar")]
        public string nmProduto { get; set; }

        [Required]
        [Column(name: "VR_PRODUTO", TypeName = "decimal")]
        public decimal vrProduto { get; set; }
    }
}
