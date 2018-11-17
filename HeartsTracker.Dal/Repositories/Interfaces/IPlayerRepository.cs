using System.Collections.Generic;
using HeartsTracker.Dal.DataTransferObjects;
using HeartsTracker.Dal.Entities;

namespace HeartsTracker.Dal.Repositories.Interfaces
{
	public interface IPlayerRepository : IArchiveableRepository<Player, int>
	{
		List<PlayerListItem> GetPlayers( );
		List<PlayerListItem> GetPlayers( bool isActive );
		PlayerDetails GetPlayerDetails( int id );
	}
}