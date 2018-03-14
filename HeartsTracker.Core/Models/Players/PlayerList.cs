using System.Collections.Generic;
using System.Linq;
using Microsoft.Net.Http.Headers;

namespace HeartsTracker.Core.Models.Players
{
	public class PlayerList
	{
		public List<PlayerListItem> Players { get; set; }

		public PlayerList( )
		{
			Players = new List<PlayerListItem>( );
		}

		public void SortPlayers( )
		{
			Players = Players.OrderBy( p => p.PlayerName ).ToList( );
		}
	}
}
