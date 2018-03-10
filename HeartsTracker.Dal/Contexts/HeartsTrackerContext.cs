using HeartsTracker.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace HeartsTracker.Dal.Contexts
{
	public class HeartsTrackerContext : DbContext
	{
		public HeartsTrackerContext( DbContextOptions options ) : base( options ) { }

		public DbSet<Player> Player { get; set; }
	}
}
