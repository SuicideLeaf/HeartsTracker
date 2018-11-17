using HeartsTracker.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace HeartsTracker.Dal.Contexts
{
	public class HeartsTrackerContext : DbContext
	{
		public HeartsTrackerContext( DbContextOptions options ) : base( options ) { }

		public DbSet<Player> Player { get; set; }
		public DbSet<Game> Game { get; set; }
		public DbSet<GameRound> GameRound { get; set; }
		public DbSet<GamePlayer> GamePlayer { get; set; }
		public DbSet<PlayerScore> PlayerScore { get; set; }

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
