using System;
using System.Collections.Generic;

namespace HeartsTracker.Dal.Entities
{
	public class Game
	{
		public int Id { get; set; }
		public DateTime StartDateTime { get; set; }
		public DateTime EndDateTime { get; set; }
		public bool IsComplete { get; set; }
		public bool IsActive { get; set; }

		public int? WinnerId { get; set; }
		public Player Winner { get; set; }

		public int? LoserId { get; set; }
		public Player Loser { get; set; }

		public ICollection<GameRound> GameRounds { get; set; }

		public ICollection<GamePlayer> GamePlayers { get; set; }
	}
}