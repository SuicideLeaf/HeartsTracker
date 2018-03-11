namespace HeartsTracker.Core.Models.Player
{
	public class PlayerListItemViewModel
	{
		public int Id { get; set; }
		public string PlayerName { get; set; }
		public string Colour { get; set; }

		public PlayerListItemViewModel( PlayerListItem playerListItem )
		{
			Id = playerListItem.Id;
			PlayerName = playerListItem.PlayerName;
			Colour = playerListItem.Colour;
		}
	}
}