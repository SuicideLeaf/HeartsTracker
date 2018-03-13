using System.Collections.Generic;

namespace HeartsTracker.Core.Models.Players
{
	public class PlayerList
	{
		public List<PlayerListItem> Players { get; set; }

		public PlayerList( )
		{
			Players = new List<PlayerListItem>( );
		}
	}
}
