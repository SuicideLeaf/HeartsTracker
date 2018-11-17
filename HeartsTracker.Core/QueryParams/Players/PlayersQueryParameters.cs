namespace HeartsTracker.Core.QueryParams.Players
{
	public class PlayersQueryParameters : QueryParameters
	{
		public bool IsActive { get; set; }

		public PlayersQueryParameters( bool isActive )
		{
			IsActive = isActive;
		}
	}
}
