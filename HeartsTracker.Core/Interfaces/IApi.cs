using System.Threading.Tasks;
using HeartsTracker.Core.QueryParams;
using HeartsTracker.Core.QueryParams.Players;
using HeartsTracker.Shared.Models.Player.Requests;
using Refit;

namespace HeartsTracker.Core.Interfaces
{
	public interface IApi
	{
		#region Player End Points

		[Get( "/api/players" )]
		Task<PlayerListResponse> GetPlayers( PlayersQueryParameters queryParams );

		[Get( "/api/players/{playerId}" )]
		Task<UpdatePlayerRequest> GetPlayer( int playerId, QueryParameters queryParams );

		[Post( "/api/players/create" )]
		Task<PlayerListItemResponse> CreatePlayer( [Body]AddPlayerRequest player, QueryParameters queryParams );

		[Put( "/api/players/update/{playerId}" )]
		Task<UpdatePlayerRequest> UpdatePlayer( int playerId, QueryParameters queryParams );

		[Put( "/api/players/archive/{playerId}" )]
		Task<UpdatePlayerRequest> ArchivePlayer( int playerId, QueryParameters queryParams );

		[Put( "/api/players/unarchive/{playerId}" )]
		Task<UpdatePlayerRequest> UnArchivePlayer( int playerId, QueryParameters queryParams );

		#endregion Player End Points
	}
}