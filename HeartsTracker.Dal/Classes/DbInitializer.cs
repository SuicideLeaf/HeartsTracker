using System.Linq;
using HeartsTracker.Dal.Contexts;
using HeartsTracker.Dal.Entities;

namespace HeartsTracker.Dal.Classes
{
	public static class DbInitializer
	{
		public static void Initialize( HeartsTrackerContext context, bool wipeData = false )
		{
			context.Database.EnsureCreated( );

			if ( wipeData )
			{
				context.Player.RemoveRange( context.Player );
				context.SaveChanges( );
			}

			if ( context.Player.Any( ) )
			{
				// DB has been seeded.
				return;
			}

			Player[ ] players = {
				new Player
				{
					IsActive = true,
					FirstName = "Lee",
					LastName = "Matulich",
					PlayerName = "Leeness",
					Colour = "#000000"
				}
			};

			context.Player.AddRange( players );

			context.SaveChanges( );
		}
	}
}