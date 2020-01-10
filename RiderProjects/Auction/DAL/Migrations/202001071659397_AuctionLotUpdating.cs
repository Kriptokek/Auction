namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuctionLotUpdating : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AuctionLots", "Product_Id", "dbo.Products");
            DropIndex("dbo.AuctionLots", new[] { "Product_Id" });
            AddColumn("dbo.AuctionLots", "Info_QuantityOfBets", c => c.Int(nullable: false));
            AddColumn("dbo.AuctionLots", "Info_LeaderName", c => c.String());
            AddColumn("dbo.AuctionLots", "Info_DateOfClosing", c => c.DateTime(nullable: false));
            DropColumn("dbo.AuctionLots", "Product_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AuctionLots", "Product_Id", c => c.Int(nullable: false));
            DropColumn("dbo.AuctionLots", "Info_DateOfClosing");
            DropColumn("dbo.AuctionLots", "Info_LeaderName");
            DropColumn("dbo.AuctionLots", "Info_QuantityOfBets");
            CreateIndex("dbo.AuctionLots", "Product_Id");
            AddForeignKey("dbo.AuctionLots", "Product_Id", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
