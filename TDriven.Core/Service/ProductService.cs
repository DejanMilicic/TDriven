
namespace TDriven.Core.Service
{
	using TDriven.Core.Domain;
	using TDriven.Core.EntityFramework;
	using TDriven.Core.Repository;

	public class ProductService :
		Service<EntityFramework.Db, Product>,
		IProductService
	{
		public ProductService(Repository<Db, Product> repository)
			: base(repository)
		{ }
	}
}
