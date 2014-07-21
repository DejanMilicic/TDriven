namespace TDriven.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Manufacturer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "Manufacturer_Id", c => c.Int());
            CreateIndex("dbo.Products", "Manufacturer_Id");
            AddForeignKey("dbo.Products", "Manufacturer_Id", "dbo.Companies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Manufacturer_Id", "dbo.Companies");
            DropIndex("dbo.Products", new[] { "Manufacturer_Id" });
            DropColumn("dbo.Products", "Manufacturer_Id");
            DropTable("dbo.Companies");
        }
    }
}
