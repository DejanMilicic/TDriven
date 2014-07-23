
namespace TDriven.Core.EntityFramework
{
	using System.Data.Entity;
	using System.Data.Entity.ModelConfiguration.Conventions;

	using TDriven.Core.Domain;
	using TDriven.Core.Migrations;

	public class Db : DbContext
	{
		public Db(): base("TDriven")
		{
			// Turn off lazy loading for performance increase, use eager loading - .Include()
			Configuration.LazyLoadingEnabled = false;
			Configuration.ProxyCreationEnabled = false;

			Database.SetInitializer(new MigrateDatabaseToLatestVersion<Db, Configuration>());
			Database.Initialize(false);
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Product> Products { get; set; }
		public DbSet<Company> Companies { get; set; }
	}
}
