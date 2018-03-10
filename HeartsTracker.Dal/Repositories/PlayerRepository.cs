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

		public new PlayerDetailsDto Get( int id )
			=> Mapper.Map<PlayerDetailsDto>( base.Get( id ) );

		public new List<PlayerListItemDto> GetAll( )
			=> base.GetAll( )
				.Select( p => Mapper.Map<PlayerListItemDto>( p ) )
				.ToList( );
	}

}
