using System;
using System.Collections.Generic;

namespace HeartsTracker.Dal.DataTransferObjects
{
	public class GameDetailsDto
	{
		public int Id { get; set; }
		public DateTime StartDateTime { get; set; }
		public DateTime EndDateTime { get; set; }
		public string WinnerName { get; set; }
		public string LoserName { get; set; }
		public bool IsComplete { get; set; }
		public List<GameRoundDetailsDto> RoundDetailsList { get; set; }
	}
}
