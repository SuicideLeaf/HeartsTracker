using System.Collections.Generic;

namespace HeartsTracker.Api.Models
{
	public class PlayerList
	{
		public List<PlayerListItem> Players { get; set; }

		public PlayerList( List<PlayerListItem> players )
		{
			Players = players;
		}
	}
}