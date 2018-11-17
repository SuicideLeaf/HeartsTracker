using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using HeartsTracker.Dal.Entities.Interfaces;

namespace HeartsTracker.Dal.Entities
{
	public class Player : IArchiveable
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PlayerName { get; set; }
		public string Colour { get; set; }
		public bool IsActive { get; set; }

		public ICollection<GamePlayer> GamePlayers { get; set; }

		public ICollection<PlayerScore> Scores { get; set; }

		[InverseProperty( "Winner" )]
		public ICollection<Game> GamesWon { get; set; }

		[InverseProperty( "Loser" )]
		public ICollection<Game> GamesLost { get; set; }
		
		[InverseProperty("Dealer")]
		public ICollection<GameRound> GameRoundsDealt { get; set; }
	}
}
