namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class qwerty : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Product_Id", "dbo.Products");
            DropIndex("dbo.Users", new[] { "Product_Id" });
            AddColumn("dbo.AuctionLots", "Owner_Id", c => c.Int());
            AddColumn("dbo.Users", "Role", c => c.String());
            CreateIndex("dbo.AuctionLots", "Owner_Id");
            AddForeignKey("dbo.AuctionLots", "Owner_Id", "dbo.Users", "Id");
            DropColumn("dbo.Users", "Product_Id");
            DropTable("dbo.Roles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "Product_Id", c => c.Int());
            DropForeignKey("dbo.AuctionLots", "Owner_Id", "dbo.Users");
            DropIndex("dbo.AuctionLots", new[] { "Owner_Id" });
            DropColumn("dbo.Users", "Role");
            DropColumn("dbo.AuctionLots", "Owner_Id");
            CreateIndex("dbo.Users", "Product_Id");
            AddForeignKey("dbo.Users", "Product_Id", "dbo.Products", "Id");
        }
    }
}
