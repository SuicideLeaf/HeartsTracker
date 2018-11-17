namespace HeartsTracker.Dal.Entities
{
	public class PlayerScore
	{
		public int Score { get; set; }
		public bool ShotTheMoon { get; set; }
		public bool BlackBitched { get; set; }

		public int PlayerId { get; set; }
		public Player Player { get; set; }

		public int RoundId { get; set; }
		public GameRound GameRound { get; set; }
	}
}
