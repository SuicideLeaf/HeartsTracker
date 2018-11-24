namespace HeartsTracker.Shared.Models.Player.Requests
{
	public class CreatePlayerRequest
	{
		public string PlayerName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Colour { get; set; }

		public CreatePlayerRequest( string playerName, string firstName, string lastName, string colour )
		{
			PlayerName = playerName;
			FirstName = firstName;
			LastName = lastName;
			Colour = colour;
		}
	}
}