using HeartsTracker.Api.Classes;
using HeartsTracker.Dal.Entities.Interfaces;
using System.Linq;

namespace HeartsTracker.Api.Extensions
{
	public static class IQueryableExtensions
	{
		public static IQueryable<TEntity> ByActiveStatus<TEntity>( this IQueryable<TEntity> set, Enums.ActiveStatus activeStatus )
			where TEntity : class, IArchivable
		{
			bool isActive = activeStatus.ToBool( );

			return set.Where( e => activeStatus == Enums.ActiveStatus.Both || e.IsActive == isActive );
		}
	}
}