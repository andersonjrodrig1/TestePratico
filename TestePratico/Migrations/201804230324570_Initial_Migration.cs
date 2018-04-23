namespace TestePratico.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        cdProduto = c.Int(nullable: false, identity: true),
                        nmProduto = c.String(nullable: false, maxLength: 50),
                        vrProduto = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.cdProduto);
            
            CreateTable(
                "dbo.VENDA_REALIZADA",
                c => new
                    {
                        cdVenda = c.Int(nullable: false, identity: true),
                        CD_PRODUTO = c.Int(nullable: false),
                        CD_VENDEDOR = c.Int(nullable: false),
                        QTD_PRODUTO = c.Int(nullable: false),
                        TTL_VENDA = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DT_VENDA = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.cdVenda)
                .ForeignKey("dbo.Produto", t => t.CD_PRODUTO, cascadeDelete: true)
                .ForeignKey("dbo.Vendedor", t => t.CD_VENDEDOR, cascadeDelete: true)
                .Index(t => t.CD_PRODUTO)
                .Index(t => t.CD_VENDEDOR);
            
            CreateTable(
                "dbo.Vendedor",
                c => new
                    {
                        cdVendedor = c.Int(nullable: false, identity: true),
                        nmVendedor = c.String(nullable: false, maxLength: 30),
                        nrTelefone = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.cdVendedor);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VENDA_REALIZADA", "CD_VENDEDOR", "dbo.Vendedor");
            DropForeignKey("dbo.VENDA_REALIZADA", "CD_PRODUTO", "dbo.Produto");
            DropIndex("dbo.VENDA_REALIZADA", new[] { "CD_VENDEDOR" });
            DropIndex("dbo.VENDA_REALIZADA", new[] { "CD_PRODUTO" });
            DropTable("dbo.Vendedor");
            DropTable("dbo.VENDA_REALIZADA");
            DropTable("dbo.Produto");
        }
    }
}
