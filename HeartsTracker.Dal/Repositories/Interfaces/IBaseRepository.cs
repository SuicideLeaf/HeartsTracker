using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;

namespace HeartsTracker.Dal.Repositories.Interfaces
{
	public interface IBaseRepository<TEntity, in TKey>
		where TEntity : class
		where TKey : struct, IEquatable<TKey>
	{
		IMapper Mapper { get; set; }

		IQueryable<TEntity> GetAll( );
		IQueryable<TEntity> Get( Expression<Func<TEntity, bool>> filter );
		TEntity Get( TKey id );
		void Add( TEntity entity );
		void Delete( TEntity entity );
		void DeleteRange( IEnumerable<TEntity> entities );
		void SaveChanges( );
	}
}