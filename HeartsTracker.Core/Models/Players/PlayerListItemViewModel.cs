using HeartsTracker.Shared.Models.Player;

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

		public PlayerListItemViewModel( int id, string playerName, string colour )
		{
			Id = id;
			PlayerName = playerName;
			Colour = colour;
		}
	}
}