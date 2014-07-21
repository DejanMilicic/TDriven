
namespace TDriven.Core.Domain
{
	using System.Collections.Generic;
	using System.Data.Entity;

	using RefactorThis.GraphDiff;

	using TDriven.Infrastructure.Entities;

	public class Company : BaseEntity
	{
		public List<Product> Products { get; set; }

		public override void UpdateGraph(DbContext dbContext)
		{
			dbContext.UpdateGraph(this, map => map
				.AssociatedCollection(x => x.Products)
			);
		}
	}
}
