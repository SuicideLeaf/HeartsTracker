namespace HeartsTracker.Dal.DataTransferObjects
{
	public class PlayerRoundScoreDetailsDto
	{
		public int Id { get; set; }
		public string PlayerName { get; set; }
		public int Score { get; set; }
		public bool ShotTheMoon { get; set; }
		public bool BlackBitched { get; set; }
	}
}