
namespace TDriven.Infrastructure.Entities
{
	using System.Data.Entity;

	public abstract class BaseEntity
	{
		public int Id { get; set; }

		public abstract void UpdateGraph(DbContext dbContext);
	}
}
