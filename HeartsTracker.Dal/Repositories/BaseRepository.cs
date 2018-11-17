using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using HeartsTracker.Dal.Contexts;
using HeartsTracker.Dal.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HeartsTracker.Dal.Repositories
{
	public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
		where TEntity : class
		where TKey : struct, IEquatable<TKey>
	{
		public IMapper Mapper { get; set; }

		protected HeartsTrackerContext Context { get; set; }
		protected DbSet<TEntity> DbSet { get; set; }

		protected BaseRepository( HeartsTrackerContext context, IMapper mapper )
		{
			Mapper = mapper;
			DbSet = context.Set<TEntity>( );
			Context = context;
		}

		public IQueryable<TEntity> GetAll( )
		{
			return DbSet.AsQueryable( );
		}

		public IQueryable<TEntity> Get( Expression<Func<TEntity, bool>> filter )
		{
			return DbSet.Where( filter );
		}

		public TEntity Get( TKey id )
		{
			return DbSet.Find( id );
		}

		public void Add( TEntity entity )
		{
			DbSet.Add( entity );
		}

		public void Delete( TEntity entity )
		{
			DbSet.Remove( entity );
		}

		public void DeleteRange( IEnumerable<TEntity> entities )
		{
			DbSet.RemoveRange( entities );
		}

		public void SaveChanges( )
		{
			Context.SaveChanges( );
		}
	}
}