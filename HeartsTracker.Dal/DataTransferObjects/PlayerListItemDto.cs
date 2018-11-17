namespace HeartsTracker.Dal.DataTransferObjects
{
	public class PlayerListItem
	{
		public int Id { get; set; }
		public string PlayerName { get; set; }
		public string Colour { get; set; }
		public bool IsActive { get; set; }
	}
}
