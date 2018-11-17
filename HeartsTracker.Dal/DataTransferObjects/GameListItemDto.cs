using System;

namespace HeartsTracker.Dal.DataTransferObjects
{
	public class GameListItemDto
	{
		public int Id { get; set; }
		public DateTime StartDateTime { get; set; }
		public string WinnerName { get; set; }
		public bool IsComplete { get; set; }
	}
}
