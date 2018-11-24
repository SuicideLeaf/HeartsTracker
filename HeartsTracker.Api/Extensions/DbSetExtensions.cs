using Microsoft.EntityFrameworkCore;
using System;

namespace HeartsTracker.Api.Extensions
{
	public static class DbSetExtensions
	{
		/// <summary>
		/// Tries to find an entity with a primary key equal to the given <paramref name="id"/>.
		/// </summary>
		/// <returns>Returns the entity if found, otherwise returns null</returns>
		public static TEntity TryGet<TEntity, TKey>( this DbSet<TEntity> set, TKey id )
			where TEntity : class
			where TKey : struct, IEquatable<TKey>
		{
			return set.Find( id );
		}
	}
}