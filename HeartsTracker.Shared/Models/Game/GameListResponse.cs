using System.Collections.Generic;

namespace HeartsTracker.Shared.Models.Game
{
	public class GameListResponse
	{
		public List<GameListItemResponse> Games { get; set; }

		public GameListResponse( )
		{
			Games = new List<GameListItemResponse>( );
		}

		public GameListResponse( List<GameListItemResponse> games ) : this( )
		{
			Games = games;
		}
	}
}