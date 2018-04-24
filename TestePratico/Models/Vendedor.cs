namespace TestePratico.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VENDEDOR")]
    public partial class Vendedor
    {
        [Key]
        [Column(name: "CD_VENDEDOR", TypeName = "int")]
        public int cdVendedor { get; set; }

        [Required]
        [StringLength(50)]
        [Column(name: "NM_VENDEDOR", TypeName = "varchar")]
        public string nmVendedor { get; set; }

        [Required]
        [StringLength(15)]
        [Column(name: "NR_VENDEDOR", TypeName = "varchar")]
        public string nrTelefone { get; set; }
    }
}
