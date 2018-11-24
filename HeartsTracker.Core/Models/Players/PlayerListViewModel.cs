using System.Collections.Generic;
using System.Linq;
using HeartsTracker.Shared.Models.Player;

namespace HeartsTracker.Core.Models.Players
{
	public class PlayerListViewModel
	{
		public List<PlayerListItemViewModel> Players { get; set; }

		public PlayerListViewModel( )
		{
			Players = new List<PlayerListItemViewModel>( );
		}

		public PlayerListViewModel( PlayerListResponse playerList )
		{
			Players = playerList.Players
				.Select( p => new PlayerListItemViewModel( p ) )
				.ToList( );
		}

		public void SortByNameAsc( )
		{
			Players = Players.OrderBy( p => p.PlayerName ).ToList( );
		}
	}
}