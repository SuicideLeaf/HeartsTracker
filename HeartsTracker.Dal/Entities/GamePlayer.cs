using System.Collections.Generic;

namespace HeartsTracker.Dal.Entities
{
    public class GamePlayer
	{
		public int GameId { get; set; }
		public Game Game { get; set; }

		public int PlayerId { get; set; }
		public Player Player { get; set; }
	}
}
