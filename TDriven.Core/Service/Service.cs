
namespace TDriven.Core.Service
{
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Linq;
	using System.Linq.Expressions;

	using TDriven.Core.Repository;

	public class Service<TDbContext, TEntity> : IService<TEntity>
		where TEntity : class
		where TDbContext : DbContext, new()
	{
		private readonly IRepository<TDbContext, TEntity> repository;

		public Service(IRepository<TDbContext, TEntity> repository)
		{
			this.repository = repository;
		}

		public TEntity Get(object key, params Expression<Func<TEntity, object>>[] includeProperties)
		{
			using (TDbContext db = new TDbContext())
			{
				return this.repository
					.Get(db, key, includeProperties);
			}
		}

		public List<TEntity> FindAll(
			Expression<Func<TEntity, bool>> criteria = null,
			params Expression<Func<TEntity, object>>[] includeProperties)
		{
			using (TDbContext db = new TDbContext())
			{
				return this.repository
					.FindAll(db, criteria, includeProperties)
					.AsNoTracking()
					.ToList();
			}
		}
	}
}
