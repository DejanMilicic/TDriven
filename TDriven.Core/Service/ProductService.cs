
namespace TDriven.Core.Service
{
	using TDriven.Core.Domain;
	using TDriven.Infrastructure.Providers;
	using TDriven.Infrastructure.Services;

	public class ProductService : Service<Product>, IProductService
	{
		public ProductService(IDbContextProvider dbContextProvider) : base(dbContextProvider)
		{
			
		}
	}
}
