using Refit;

namespace HeartsTracker.Core.QueryParameters.Players
{
	public class PlayerQueryParameters : QueryParameters
	{
		[AliasAs( "id" )]
		public int Id { get; set; }

		public PlayerQueryParameters( int playerId )
		{
			Id = playerId;
		}
	}
}