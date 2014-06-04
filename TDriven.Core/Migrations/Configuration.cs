namespace TDriven.Core.Migrations
{
	using System.Data.Entity.Migrations;

	using TDriven.Core.Domain;

	internal sealed class Configuration : DbMigrationsConfiguration<TDriven.Core.EntityFramework.Db>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(TDriven.Core.EntityFramework.Db context)
		{
			context.Products.AddOrUpdate(
			  p => p.Name,
			  new Product{ Name = "Nike Air Max" },
			  new Product{ Name = "Adidas Magento" },
			  new Product{ Name = "Kappa Primo" }
			);
		}
	}
}
