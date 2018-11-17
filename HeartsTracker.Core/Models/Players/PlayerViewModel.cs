using HeartsTracker.Shared.Models.Player.Requests;

namespace HeartsTracker.Core.Models.Players
{
	public class PlayerViewModel
	{
		public int Id { get; set; }
		public string PlayerName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Colour { get; set; }

		public PlayerViewModel( )
		{ }

		public PlayerViewModel( UpdatePlayerRequest player )
		{
			Id = player.Id;
			PlayerName = player.PlayerName;
			FirstName = player.FirstName;
			LastName = player.LastName;
			Colour = player.Colour;
		}
	}
}