namespace HeartsTracker.Api.DomainModels.PlayerScores
{
	public class PlayerScore
	{
		public int Score { get; set; }
		public bool ShotTheMoon { get; set; }
		public bool BlackBitched { get; set; }

		public int PlayerId { get; set; }

		public int RoundId { get; set; }
	}
}