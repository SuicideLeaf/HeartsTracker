using System;
using HeartsTracker.Dal.Entities.Interfaces;

namespace HeartsTracker.Dal.Repositories.Interfaces
{
	public interface IArchiveableRepository<TEntity, in TKey> : IBaseRepository<TEntity, TKey>
		where TEntity : class, IArchiveable
		where TKey : struct, IEquatable<TKey>
	{
		void Archive( TEntity entity );
		void UnArchive( TEntity entity );
	}
}