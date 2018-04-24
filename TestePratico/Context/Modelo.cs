namespace TestePratico.Context
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using TestePratico.Models;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public partial class Modelo : DbContext
    {
        public Modelo() : base("name=Modelo") { }

        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<VendaRealizada> VendaRealizada { get; set; }
        public virtual DbSet<Vendedor> Vendedor { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new VendaRealizadaContext());
            modelBuilder.Configurations.Add(new ProdutoContext());
            modelBuilder.Configurations.Add(new VendedorContext());

            // modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}
