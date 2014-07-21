
namespace TDriven.Core.Domain
{
	using System.Data.Entity;

	using RefactorThis.GraphDiff;

	using TDriven.Infrastructure.Entities;

	public class Product : BaseEntity
	{
		public string Name { get; set; }
		public Company Company { get; set; }

		public override void UpdateGraph(DbContext dbContext)
		{
			dbContext.UpdateGraph(this, map => map
				.AssociatedEntity(x => x.Company)
			);
		}
	}
}
