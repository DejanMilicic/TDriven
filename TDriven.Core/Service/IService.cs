
namespace TDriven.Core.Service
{
	using System;
	using System.Collections.Generic;
	using System.Linq.Expressions;

	public interface IService<TEntity> where TEntity : class
	{
		TEntity Get(
			object key,
			params Expression<Func<TEntity, object>>[] includeProperties);

		List<TEntity> FindAll(
			Expression<Func<TEntity, bool>> criteria = null,
			params Expression<Func<TEntity, object>>[] includeProperties);
	}
}
