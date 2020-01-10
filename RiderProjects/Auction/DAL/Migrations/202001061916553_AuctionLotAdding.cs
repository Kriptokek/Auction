namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuctionLotAdding : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuctionLots",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AuctionLots", "Product_Id", "dbo.Products");
            DropIndex("dbo.AuctionLots", new[] { "Product_Id" });
            DropTable("dbo.AuctionLots");
        }
    }
}
