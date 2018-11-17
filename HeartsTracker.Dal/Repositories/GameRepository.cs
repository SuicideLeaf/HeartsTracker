using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using HeartsTracker.Dal.Contexts;
using HeartsTracker.Dal.DataTransferObjects;
using HeartsTracker.Dal.Entities;
using HeartsTracker.Dal.Repositories.Interfaces;

namespace HeartsTracker.Dal.Repositories
{
	public class GameRepository : BaseRepository<Game, int>, IGameRepository
	{
		public GameRepository( HeartsTrackerContext context, IMapper mapper ) : base( context, mapper )
		{ }

		public List<GameListItemDto> GetAllGames( )
		{
			return GetAll( )
				.Select( g => Mapper.Map<GameListItemDto>( g ) )
				.ToList( );
		}

		public GameDetailsDto GetGameDetails( int id )
		{
			throw new System.NotImplementedException( );
		}
	}
}