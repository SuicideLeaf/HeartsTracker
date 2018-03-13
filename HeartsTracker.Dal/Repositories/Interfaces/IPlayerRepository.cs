using System.Collections.Generic;
using HeartsTracker.Dal.DataTransferObjects;
using HeartsTracker.Dal.Entities;

namespace HeartsTracker.Dal.Repositories.Interfaces
{
	public interface IPlayerRepository : IArchiveableRepository<Player, int>
	{
		List<PlayerListItemDto> GetAllPlayers( );
		List<PlayerListItemDto> GetPlayersByActive( bool isActive );
		PlayerDetailsDto GetPlayerDetails( int id );
	}
}