namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateLot : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AuctionLots", "LastBet", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AuctionLots", "LastBet");
        }
    }
}
