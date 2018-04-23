using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TestePratico.Models;

namespace TestePratico.Context
{
    public class VendaRealizadaContext : EntityTypeConfiguration<VendaRealizada>
    {
        public VendaRealizadaContext()
        {
            ToTable("VENDA_REALIZADA");
            HasKey(b => b.cdVenda);
            Property(b => b.cdVenda).HasColumnName("CD_VENDA").HasColumnType("int");
            Property(b => b.cdProduto).HasColumnName("CD_PRODUTO").HasColumnType("int").IsRequired();
            Property(b => b.cdVendedor).HasColumnName("CD_VENDEDOR").HasColumnType("int").IsRequired();
            Property(b => b.qtdProduto).HasColumnName("QTD_PRODUTO").HasColumnType("int").IsRequired();
            Property(b => b.ttlVenda).HasColumnName("TTL_VENDA").HasColumnType("decimal").IsRequired();
            Property(b => b.dtVenda).HasColumnName("DT_VENDA").HasColumnType("date").IsRequired();
        }
    }
}