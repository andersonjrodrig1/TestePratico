namespace TestePratico.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Config_Table_Venda : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VENDA_REALIZADA", "CD_PRODUTO", "dbo.Produto");
            DropForeignKey("dbo.VENDA_REALIZADA", "CD_VENDEDOR", "dbo.Vendedor");
            RenameColumn(table: "dbo.VENDA_REALIZADA", name: "cdVenda", newName: "CD_VENDA");
            AddForeignKey("dbo.VENDA_REALIZADA", "CD_PRODUTO", "dbo.Produto", "cdProduto");
            AddForeignKey("dbo.VENDA_REALIZADA", "CD_VENDEDOR", "dbo.Vendedor", "cdVendedor");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VENDA_REALIZADA", "CD_VENDEDOR", "dbo.Vendedor");
            DropForeignKey("dbo.VENDA_REALIZADA", "CD_PRODUTO", "dbo.Produto");
            RenameColumn(table: "dbo.VENDA_REALIZADA", name: "CD_VENDA", newName: "cdVenda");
            AddForeignKey("dbo.VENDA_REALIZADA", "CD_VENDEDOR", "dbo.Vendedor", "cdVendedor", cascadeDelete: true);
            AddForeignKey("dbo.VENDA_REALIZADA", "CD_PRODUTO", "dbo.Produto", "cdProduto", cascadeDelete: true);
        }
    }
}
