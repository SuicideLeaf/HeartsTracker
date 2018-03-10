using System.Collections.Generic;
using System.Linq;
using HeartsTracker.Dal.Repositories.Interfaces;

namespace HeartsTracker.Api.Models
{
	public class PlayerList
	{
		public List<PlayerListItem> Players { get; set; }

		public PlayerList( IPlayerRepository playerRepository )
		{
			Players = playerRepository
				.GetAll( )
				.Select( p => playerRepository.Mapper.Map<PlayerListItem>( p ) )
				.ToList( );
		}
	}
}