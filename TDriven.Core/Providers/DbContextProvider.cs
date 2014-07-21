
namespace TDriven.Core.Providers
{
	using System.Data.Entity;

	using TDriven.Core.EntityFramework;
	using TDriven.Infrastructure.Providers;

	public class DbContextProvider : IDbContextProvider
	{
		public DbContext GetDbContext()
		{
			return new Db();
		}
	}
}
