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

		public PlayerDetails GetPlayerDetails( int id )
			=> Mapper.Map<PlayerDetails>( Get( id ) );

		public List<PlayerListItem> GetPlayers( )
			=> GetAll( )
				.Select( p => Mapper.Map<PlayerListItem>( p ) )
				.ToList( );

		public List<PlayerListItem> GetPlayers( bool isActive )
			=> GetAll( )
				.Where( p => p.IsActive == isActive )
				.Select( p => Mapper.Map<PlayerListItem>( p ) )
				.ToList( );
	}
}