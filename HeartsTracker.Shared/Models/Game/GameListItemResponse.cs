namespace HeartsTracker.Shared.Models.Game
{
	public class GameListItemResponse
	{
		public int Id { get; set; }
		public string PlayerName { get; set; }
		public string Colour { get; set; }
		public bool IsActive { get; set; }
	}
}