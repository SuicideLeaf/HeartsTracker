using System.Collections.Generic;
using HeartsTracker.Dal.DataTransferObjects;
using HeartsTracker.Dal.Entities;

namespace HeartsTracker.Dal.Repositories.Interfaces
{
	public interface IGameRepository : IBaseRepository<Game, int>
	{
		List<GameListItemDto> GetAllGames( );
		GameDetailsDto GetGameDetails( int id );
	}
}