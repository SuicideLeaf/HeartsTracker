using System;
using System.Collections.Generic;

namespace HeartsTracker.Shared.Models.Game.Requests
{
	public class UpdatePlayersScoresRequest
	{
		public int? RoundId { get; set; }
		public List<PlayerScoreRequest> PlayerScores { get; set; }

		public class PlayerScoreRequest
		{
			public int PlayerId { get; set; }
			public int Score { get; set; }
			public bool BlackBitched { get; set; }
			public bool ShotTheMoon { get; set; }
		}
	}

	public class CreateGameRequest
	{
		public DateTime StartDateTime { get; set; }

		public List<int> Players { get; set; }
	}
}