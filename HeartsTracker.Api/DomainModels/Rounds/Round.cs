namespace HeartsTracker.Api.DomainModels.Rounds
{
	public class Round
	{
		public int Id { get; set; }
		public int RoundNumber { get; set; }
		public bool IsKeepRound { get; set; }
		public bool IsComplete { get; set; }

		public int GameId { get; set; }

		public int DealerId { get; set; }
	}
}