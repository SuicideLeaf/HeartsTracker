using System;

namespace HeartsTracker.Api.DomainModels.Games
{
	public class GameListItem
	{
		public int Id { get; set; }
		public DateTime StartDateTime { get; set; }
		public string WinnerName { get; set; }
		public string LoserName { get; set; }
	}
}