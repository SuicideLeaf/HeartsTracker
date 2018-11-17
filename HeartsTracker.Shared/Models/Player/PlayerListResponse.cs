using System.Collections.Generic;

namespace HeartsTracker.Shared.Models.Player.Requests
{
	public class PlayerListResponse
	{
		public List<PlayerListItemResponse> Players { get; set; }

		public PlayerListResponse( )
		{
			Players = new List<PlayerListItemResponse>( );
		}

		public PlayerListResponse( List<PlayerListItemResponse> players ) : this( )
		{
			Players = players;
		}
	}
}