namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingRoleandUpdatingUserMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserHasProducts", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserHasProducts", "Product_Id", "dbo.Products");
            DropIndex("dbo.UserHasProducts", new[] { "User_Id" });
            DropIndex("dbo.UserHasProducts", new[] { "Product_Id" });
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "Login", c => c.String());
            AddColumn("dbo.Users", "Password", c => c.String());
            AddColumn("dbo.Users", "Email", c => c.String());
            AddColumn("dbo.Users", "Product_Id", c => c.Int());
            CreateIndex("dbo.Users", "Product_Id");
            AddForeignKey("dbo.Users", "Product_Id", "dbo.Products", "Id");
            DropTable("dbo.UserHasProducts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserHasProducts",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Product_Id });
            
            DropForeignKey("dbo.Users", "Product_Id", "dbo.Products");
            DropIndex("dbo.Users", new[] { "Product_Id" });
            DropColumn("dbo.Users", "Product_Id");
            DropColumn("dbo.Users", "Email");
            DropColumn("dbo.Users", "Password");
            DropColumn("dbo.Users", "Login");
            DropTable("dbo.Roles");
            CreateIndex("dbo.UserHasProducts", "Product_Id");
            CreateIndex("dbo.UserHasProducts", "User_Id");
            AddForeignKey("dbo.UserHasProducts", "Product_Id", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserHasProducts", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
