namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeProperiesOfLotToRequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AuctionLots", "Product_Id", "dbo.Products");
            DropIndex("dbo.AuctionLots", new[] { "Product_Id" });
            AlterColumn("dbo.AuctionLots", "Title", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.AuctionLots", "Product_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.AuctionLots", "Product_Id");
            AddForeignKey("dbo.AuctionLots", "Product_Id", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AuctionLots", "Product_Id", "dbo.Products");
            DropIndex("dbo.AuctionLots", new[] { "Product_Id" });
            AlterColumn("dbo.AuctionLots", "Product_Id", c => c.Int());
            AlterColumn("dbo.AuctionLots", "Title", c => c.String());
            CreateIndex("dbo.AuctionLots", "Product_Id");
            AddForeignKey("dbo.AuctionLots", "Product_Id", "dbo.Products", "Id");
        }
    }
}
