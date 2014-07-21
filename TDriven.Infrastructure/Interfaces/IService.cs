
namespace TDriven.Infrastructure.Interfaces
{
	using System;
	using System.Collections.Generic;
	using System.Linq.Expressions;

	using TDriven.Infrastructure.Services;

	public interface IService<TEntity> where TEntity : class
	{
		TEntity Get(
			object key,
			params Expression<Func<TEntity, object>>[] includeProperties);

		List<TEntity> FindAll(
			int pageIndex = 0,
			int pageSize = 0,
			Expression<Func<TEntity, object>> orderingSelector = null,
			OrderBy orderBy = OrderBy.Ascending,
			Expression<Func<TEntity, bool>> criteria = null,
			params Expression<Func<TEntity, object>>[] includeProperties);

		void Insert(TEntity entity);

		void Delete(TEntity entity);

		void Delete(object key);

		void Update(TEntity entity);
	}
}
