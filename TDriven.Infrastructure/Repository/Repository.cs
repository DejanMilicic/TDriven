
namespace TDriven.Core.Repository
{
	using System;
	using System.Data.Entity;
	using System.Linq;
	using System.Linq.Expressions;

	public class Repository<TDbContext, TEntity> : IRepository<TDbContext, TEntity>
		where TDbContext : DbContext
		where TEntity : class
	{
		public TEntity Get(TDbContext dbContext, object key, params Expression<Func<TEntity, object>>[] includeProperties)
		{
			DbSet<TEntity> set = dbContext.Set<TEntity>();

			foreach (var includeProperty in includeProperties)
			{
				set.Include(includeProperty).Load();
			}

			return set.Find(key);
		}

		public IQueryable<TEntity> FindAll(TDbContext dbContext, Expression<Func<TEntity, bool>> criteria = null, params Expression<Func<TEntity, object>>[] includeProperties)
		{
			DbSet<TEntity> set = dbContext.Set<TEntity>();

			foreach (var includeProperty in includeProperties)
			{
				set.Include(includeProperty).Load();
			}

			if (criteria == null)
			{
				return set;
			}
			else
			{
				return set.Where(criteria);
			}
		}

		public void Insert(TDbContext dbContext, TEntity entity)
		{
			dbContext.Set<TEntity>().Add(entity);
		}

		public void Delete(TDbContext dbContext, TEntity entity)
		{
			if (dbContext.Entry(entity).State == EntityState.Detached)
			{
				dbContext.Set<TEntity>().Attach(entity);
			}

			dbContext.Set<TEntity>().Remove(entity);
		}

		public void Delete(TDbContext dbContext, object key)
		{
			TEntity entity = this.Get(dbContext, key);
			if (entity != null)
			{
				this.Delete(dbContext, entity);
			}
		}

		public void Update(TDbContext dbContext, TEntity entity)
		{
			dbContext.Set<TEntity>().Attach(entity);
			dbContext.Entry(entity).State = EntityState.Modified;
		}
	}
}
