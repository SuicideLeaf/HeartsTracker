using System.Collections.Generic;
using HeartsTracker.Dal.DataTransferObjects;
using HeartsTracker.Dal.Entities;

namespace HeartsTracker.Dal.Repositories.Interfaces
{
	public interface IPlayerRepository : IArchiveableRepository<Player, int>
	{
		new List<PlayerListItemDto> GetAll( );
		new PlayerDetailsDto Get( int id );
	}
}