
namespace TDriven.Core.Repository
{
	using System;
	using System.Data.Entity;
	using System.Linq;
	using System.Linq.Expressions;

	public interface IRepository<in TDbContext, TEntity>
		where TDbContext : DbContext
		where TEntity : class
	{
		TEntity Get(TDbContext dbContext, object key, params Expression<Func<TEntity, object>>[] includeProperties);
		IQueryable<TEntity> FindAll(TDbContext dbContext, Expression<Func<TEntity, bool>> criteria, params Expression<Func<TEntity, object>>[] includeProperties);
		void Insert(TDbContext dbContext, TEntity entity);
		void Delete(TDbContext dbContext, TEntity entity);
		void Delete(TDbContext dbContext, object key);
		void Update(TDbContext dbContext, TEntity entity);
	}
}
