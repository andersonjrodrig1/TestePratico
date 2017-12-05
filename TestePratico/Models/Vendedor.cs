namespace TestePratico.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vendedor")]
    public partial class Vendedor
    {
        [Key]
        public int cdVendedor { get; set; }

        [Required]
        [StringLength(30)]
        public string nmVendedor { get; set; }

        [Required]
        [StringLength(15)]
        public string nrTelefone { get; set; }
    }
}
