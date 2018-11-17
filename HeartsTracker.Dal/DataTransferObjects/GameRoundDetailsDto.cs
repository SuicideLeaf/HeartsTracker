using System;
using System.Collections.Generic;

namespace HeartsTracker.Dal.DataTransferObjects
{
	public class GameRoundDetailsDto
	{
		public int Id { get; set; }
		public DateTime StartDateTime { get; set; }
		public DateTime EndDateTime { get; set; }
		public int RoundNumber { get; set; }
		public int DealerId { get; set; }
		public string DealerName { get; set; }
		public List<PlayerRoundScoreDetailsDto> PlayersScoreDetailsList { get; set; }
	}
}