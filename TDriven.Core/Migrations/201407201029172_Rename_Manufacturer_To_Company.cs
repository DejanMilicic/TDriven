namespace TDriven.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rename_Manufacturer_To_Company : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Products", name: "Manufacturer_Id", newName: "Company_Id");
            RenameIndex(table: "dbo.Products", name: "IX_Manufacturer_Id", newName: "IX_Company_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Products", name: "IX_Company_Id", newName: "IX_Manufacturer_Id");
            RenameColumn(table: "dbo.Products", name: "Company_Id", newName: "Manufacturer_Id");
        }
    }
}
