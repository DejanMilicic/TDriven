
namespace TDriven.Infrastructure.Providers
{
	using System.Data.Entity;

	public interface IDbContextProvider
	{
		DbContext GetDbContext();
	}
}
