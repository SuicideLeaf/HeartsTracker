namespace HeartsTracker.Api.Models.Players
{
	public class PlayerDetails
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PlayerName { get; set; }
		public string Colour { get; set; }
		public bool IsActive { get; set; }
	}
}