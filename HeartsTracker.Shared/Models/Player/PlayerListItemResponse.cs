namespace HeartsTracker.Shared.Models.Player.Requests
{
	public class PlayerListItemResponse
	{
		public int Id { get; set; }
		public string PlayerName { get; set; }
		public string Colour { get; set; }
		public bool IsActive { get; set; }
	}
}