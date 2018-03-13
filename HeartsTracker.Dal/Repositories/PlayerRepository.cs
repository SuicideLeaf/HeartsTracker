using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using HeartsTracker.Dal.Contexts;
using HeartsTracker.Dal.DataTransferObjects;
using HeartsTracker.Dal.Entities;
using HeartsTracker.Dal.Repositories.Interfaces;

namespace HeartsTracker.Dal.Repositories
{
	public class PlayerRepository : ArchiveableRepository<Player, int>, IPlayerRepository
	{
		public PlayerRepository( HeartsTrackerContext context, IMapper mapper ) : base( context, mapper )
		{ }

		public PlayerDetailsDto GetPlayerDetails( int id )
			=> Mapper.Map<PlayerDetailsDto>( Get( id ) );

		public List<PlayerListItemDto> GetAllPlayers( )
			=> GetAll( )
				.Select( p => Mapper.Map<PlayerListItemDto>( p ) )
				.ToList( );

		public List<PlayerListItemDto> GetPlayersByActive( bool isActive )
			=> GetAll( )
				.Where( p => p.IsActive == isActive )
				.Select( p => Mapper.Map<PlayerListItemDto>( p ) )
				.ToList( );
	}

}
