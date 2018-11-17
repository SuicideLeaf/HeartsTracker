using HeartsTracker.Shared.Models.Player.Requests;

namespace HeartsTracker.Core.Models.Players
{
	public class PlayerListItemViewModel
	{
		public int Id { get; set; }
		public string PlayerName { get; set; }
		public string Colour { get; set; }

		public PlayerListItemViewModel( )
		{
		}

		public PlayerListItemViewModel( PlayerListItemResponse playerListItem )
		{
			Id = playerListItem.Id;
			PlayerName = playerListItem.PlayerName;
			Colour = playerListItem.Colour;
		}
	}
}