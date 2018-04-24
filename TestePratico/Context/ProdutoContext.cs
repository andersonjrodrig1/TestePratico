using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TestePratico.Models;

namespace TestePratico.Context
{
    public class ProdutoContext : EntityTypeConfiguration<Produto>
    {
        public ProdutoContext()
        {
            ToTable("PRODUTO");
            HasKey(b => b.cdProduto);
            Property(b => b.cdProduto).HasColumnName("CD_PRODUTO").HasColumnType("int");
            Property(b => b.nmProduto).HasColumnName("NM_PRODUTO").HasColumnType("varchar").HasMaxLength(50).IsRequired();
            Property(b => b.vrProduto).HasColumnName("VR_PRODUTO").HasColumnType("decimal").IsRequired();
        }
    }
}