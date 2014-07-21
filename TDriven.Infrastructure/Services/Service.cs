
namespace TDriven.Infrastructure.Services
{
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Linq;
	using System.Linq.Expressions;

	using TDriven.Infrastructure.Entities;
	using TDriven.Infrastructure.Interfaces;
	using TDriven.Infrastructure.Providers;

	public class Service<TEntity> : IService<TEntity> where TEntity : BaseEntity
	{
		protected readonly IDbContextProvider DbContextProvider;

		public Service(IDbContextProvider dbContextProvider)
		{
			this.DbContextProvider = dbContextProvider;
		}

		public TEntity Get(object key,
			params Expression<Func<TEntity, object>>[] includeProperties)
		{
			using (var db = this.DbContextProvider.GetDbContext())
			{
				DbSet<TEntity> set = db.Set<TEntity>();

				foreach (var includeProperty in includeProperties)
				{
					set.Include(includeProperty).Load();
				}

				return set.Find(key);
			}
		}

		private IQueryable<TEntity> FindAllInternal(
			DbContext dbContext,
			Expression<Func<TEntity, bool>> criteria = null,
			params Expression<Func<TEntity, object>>[] includeProperties)
		{
			DbSet<TEntity> set = dbContext.Set<TEntity>();

			foreach (var includeProperty in includeProperties)
			{
				set.Include(includeProperty).Load();
			}

			if (criteria == null)
			{
				return set.AsNoTracking();
			}
			else
			{
				return set.AsNoTracking().Where(criteria);
			}			
		}

		/*
		public List<TEntity> FindAll(
			Expression<Func<TEntity, bool>> criteria = null,
			params Expression<Func<TEntity, object>>[] includeProperties)
		{
			using (var db = this.DbContextProvider.GetDbContext())
			{
				return this.FindAllInternal(db, criteria, includeProperties).ToList();
			}
		}

		public List<TEntity> FindAll(
			int pageIndex,
			int pageSize,
			Expression<Func<TEntity, bool>> criteria = null,
			params Expression<Func<TEntity, object>>[] includeProperties)
		{
			using (var db = this.DbContextProvider.GetDbContext())
			{
				return this.FindAllInternal(db, criteria, includeProperties)
					.Skip(pageIndex * pageSize).Take(pageSize)
					.ToList();
			}
		}
		*/

		public List<TEntity> FindAll(
			int pageIndex = 0,
			int pageSize = 0,
			Expression<Func<TEntity, object>> orderingSelector = null,
			OrderBy orderBy = OrderBy.Ascending,
			Expression<Func<TEntity, bool>> criteria = null,
			params Expression<Func<TEntity, object>>[] includeProperties)
		{
			using (var db = this.DbContextProvider.GetDbContext())
			{
				var query = this.FindAllInternal(db, criteria, includeProperties);

				if (orderingSelector != null)
				{
					if (orderBy == OrderBy.Ascending)
					{
						query = query.OrderBy(orderingSelector);
					}
					else
					{
						query = query.OrderByDescending(orderingSelector);
					}
				}

				if (pageSize > 0)
				{
					query = query.Skip(pageIndex * pageSize).Take(pageSize);
				}

				return query.ToList();
			}
		}

		public void Insert(TEntity entity)
		{
			using (var db = this.DbContextProvider.GetDbContext())
			{
				db.Set<TEntity>().Add(entity);
				db.SaveChanges();
			}
		}

		public void Delete(TEntity entity)
		{
			using (var db = this.DbContextProvider.GetDbContext())
			{
				if (db.Entry(entity).State == EntityState.Detached)
				{
					db.Set<TEntity>().Attach(entity);
				}

				db.Set<TEntity>().Remove(entity);
				db.SaveChanges();
			}
		}

		public void Delete(object key)
		{
			TEntity entity = this.Get(key);
			if (entity != null)
			{
				this.Delete(entity);
			}
		}

		public void Update(TEntity entity)
		{
			using (var db = this.DbContextProvider.GetDbContext())
			{
				entity.UpdateGraph(db);
				db.SaveChanges();
			}
		}
	}
}
