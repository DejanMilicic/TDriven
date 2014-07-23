namespace TDriven.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remove_Pluralization : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Products", newName: "Product");
            RenameTable(name: "dbo.Companies", newName: "Company");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Company", newName: "Companies");
            RenameTable(name: "dbo.Product", newName: "Products");
        }
    }
}
