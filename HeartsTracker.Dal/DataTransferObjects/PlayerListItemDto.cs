namespace HeartsTracker.Dal.DataTransferObjects
{
	public class PlayerListItemDto
	{
		public int Id { get; set; }
		public string PlayerName { get; set; }
		public string Colour { get; set; }
		public bool IsActive { get; set; }
	}
}
