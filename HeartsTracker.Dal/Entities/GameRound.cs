using System;
using System.Collections.Generic;

namespace HeartsTracker.Dal.Entities
{
    public class GameRound
    {
		public int Id { get; set; }
		public DateTime StartDateTime { get; set; }
		public DateTime EndDateTime { get; set; }
		public int RoundNumber { get; set; }
		
		public int GameId { get; set; }
		public Game Game { get; set; }

		public int DealerId { get; set; }
		public Player Dealer { get; set; }

		public ICollection<PlayerScore> Scores { get; set; }
	}
}
