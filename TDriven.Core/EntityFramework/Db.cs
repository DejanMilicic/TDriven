
namespace TDriven.Core.EntityFramework
{
	using System.Data.Entity;

	using TDriven.Core.Domain;
	using TDriven.Core.Migrations;

	public class Db : DbContext
	{
		public Db(): base("TDriven")
		{
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<Db, Configuration>());
			Database.Initialize(false);
		}

		public IDbSet<Product> Products { get; set; }


	}
}
