using System.Threading.Tasks;
using HeartsTracker.Core.Models.Players;
using HeartsTracker.Core.QueryParameters;
using HeartsTracker.Core.QueryParameters.Players;
using Refit;

namespace HeartsTracker.Core.Interfaces
{
	public interface IApi
	{
		#region Player End Points
		
		[Get( "/api/players/all" )]
		Task<PlayerList> GetPlayers( PlayersQueryParameters queryParams );

		[Get( "/api/players/get" )]
		Task<Player> GetPlayer( PlayerQueryParameters queryParams );

		[Post( "/api/players/create" )]
		Task<Player> CreatePlayer( PlayerQueryParameters queryParams );

		[Put( "/api/players/update" )]
		Task<Player> UpdatePlayer( PlayerQueryParameters queryParams );

		[Put( "/api/players/archive" )]
		Task<Player> ArchivePlayer( PlayerQueryParameters queryParams );

		[Put( "/api/players/unarchive" )]
		Task<Player> UnArchivePlayer( PlayerQueryParameters queryParams );
		
		#endregion
	}
}
