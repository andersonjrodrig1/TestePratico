namespace TestePratico.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PRODUTO",
                c => new
                    {
                        CD_PRODUTO = c.Int(nullable: false, identity: true),
                        NM_PRODUTO = c.String(nullable: false, maxLength: 50, unicode: false),
                        VR_PRODUTO = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CD_PRODUTO);
            
            CreateTable(
                "dbo.VENDA",
                 c => new
                    {
                        CD_VENDA = c.Int(nullable: false, identity: true),
                        CD_PRODUTO = c.Int(nullable: false),
                        CD_VENDEDOR = c.Int(nullable: false),
                        QTD_PRODUTO = c.Int(nullable: false),
                        TTL_VENDA = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DT_VENDA = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.CD_VENDA);
            
            CreateTable(
                "dbo.VENDEDOR",
                c => new
                    {
                        CD_VENDEDOR = c.Int(nullable: false, identity: true),
                        NM_VENDEDOR = c.String(nullable: false, maxLength: 50, unicode: false),
                        NR_TELEFONE = c.String(nullable: false, maxLength: 15, unicode: false),
                    })
                .PrimaryKey(t => t.CD_VENDEDOR);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VENDEDOR");
            DropTable("dbo.VENDA");
            DropTable("dbo.PRODUTO");
        }
    }
}
