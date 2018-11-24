using HeartsTracker.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace HeartsTracker.Dal.Contexts
{
	public class HeartsTrackerContext : DbContext
	{
		public HeartsTrackerContext( DbContextOptions options ) : base( options )
		{
		}

		public DbSet<Player> Players { get; set; }
		public DbSet<Game> Games { get; set; }
		public DbSet<GameRound> GameRounds { get; set; }
		public DbSet<GamePlayer> GamePlayers { get; set; }
		public DbSet<PlayerScore> PlayerScores { get; set; }

		protected override void OnModelCreating( ModelBuilder modelBuilder )
		{
			// Composite key consisting of Player & Round
			modelBuilder.Entity<PlayerScore>( ).HasKey( ps => new { ps.PlayerId, ps.RoundId } );

			// Composite key consisting of Game & Player
			modelBuilder.Entity<GamePlayer>( ).HasKey( gp => new { gp.GameId, gp.PlayerId } );

			modelBuilder.Entity<GamePlayer>( )
				.HasOne( gp => gp.Player )
				.WithMany( p => p.GamePlayers )
				.HasForeignKey( gp => gp.PlayerId );

			modelBuilder.Entity<GamePlayer>( )
				.HasOne( gp => gp.Game )
				.WithMany( p => p.GamePlayers )
				.HasForeignKey( gp => gp.GameId );
		}
	}
}