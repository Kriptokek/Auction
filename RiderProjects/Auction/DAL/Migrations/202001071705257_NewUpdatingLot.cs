namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewUpdatingLot : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AuctionLots", "QuantityOfBets", c => c.Int(nullable: false));
            AddColumn("dbo.AuctionLots", "LeaderName", c => c.String());
            AddColumn("dbo.AuctionLots", "DateOfClosing", c => c.DateTime(nullable: false));
            DropColumn("dbo.AuctionLots", "Info_QuantityOfBets");
            DropColumn("dbo.AuctionLots", "Info_LeaderName");
            DropColumn("dbo.AuctionLots", "Info_DateOfClosing");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AuctionLots", "Info_DateOfClosing", c => c.DateTime(nullable: false));
            AddColumn("dbo.AuctionLots", "Info_LeaderName", c => c.String());
            AddColumn("dbo.AuctionLots", "Info_QuantityOfBets", c => c.Int(nullable: false));
            DropColumn("dbo.AuctionLots", "DateOfClosing");
            DropColumn("dbo.AuctionLots", "LeaderName");
            DropColumn("dbo.AuctionLots", "QuantityOfBets");
        }
    }
}
