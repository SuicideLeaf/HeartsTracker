using System;

namespace HeartsTracker.Api.DomainModels.Games
{
	public class Game
	{
		public int Id { get; set; }
		public DateTime StartDateTime { get; set; }
		public DateTime? EndDateTime { get; set; }
		public bool IsComplete { get; set; }
		public bool IsActive { get; set; }

		public int? WinnerId { get; set; }

		public int? LoserId { get; set; }
	}
}