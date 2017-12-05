namespace TestePratico.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Modelo : DbContext
    {
        public Modelo() : base("name=Modelo") { }

        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<VendaRealizada> VendaRealizada { get; set; }
        public virtual DbSet<Vendedor> Vendedor { get; set; }
    }
}
