using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TestePratico.Models;

namespace TestePratico.Context
{
    public class VendedorContext : EntityTypeConfiguration<Vendedor>
    {
        public VendedorContext()
        {
            ToTable("VENDEDOR");
            HasKey(b => b.cdVendedor);
            Property(b => b.cdVendedor).HasColumnName("CD_VENDEDOR").HasColumnType("int");
            Property(b => b.nmVendedor).HasColumnName("NM_VENDEDOR").HasColumnType("varchar").HasMaxLength(50).IsRequired();
            Property(b => b.nrTelefone).HasColumnName("NR_TELEFONE").HasColumnType("varchar").HasMaxLength(15).IsRequired();
        }
    }
}