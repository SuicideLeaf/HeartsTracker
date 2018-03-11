using System.Collections.Generic;
using System.Linq;

namespace HeartsTracker.Core.Models.Player
{
	public class PlayerListViewModel
	{
		public List<PlayerListItemViewModel> Players { get; set; }

		public PlayerListViewModel( )
		{
			Players = new List<PlayerListItemViewModel>( );
		}

		public PlayerListViewModel( PlayerList playerList )
		{
			Players = playerList.Players
				.Select( p => new PlayerListItemViewModel( p ) )
				.ToList( );
		}
	}
}
