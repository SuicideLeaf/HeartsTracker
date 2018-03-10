using System;
using AutoMapper;
using HeartsTracker.Dal.Contexts;
using HeartsTracker.Dal.Entities.Interfaces;
using HeartsTracker.Dal.Repositories.Interfaces;

namespace HeartsTracker.Dal.Repositories
{
	public class ArchiveableRepository<TEntity, TKey> : BaseRepository<TEntity, TKey>, IArchiveableRepository<TEntity, TKey>
		where TEntity : class, IArchiveable
		where TKey : struct, IEquatable<TKey>
	{
		public ArchiveableRepository( HeartsTrackerContext context, IMapper mapper ) : base( context, mapper )
		{ }

		public void Archive( TEntity entity )
		{
			entity.IsActive = false;
			SaveChanges( );
		}

		public void UnArchive( TEntity entity )
		{
			entity.IsActive = true;
			SaveChanges( );
		}
	}
}
