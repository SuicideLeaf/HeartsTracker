using System.Threading.Tasks;
using HeartsTracker.Core.Classes;
using HeartsTracker.Core.Interfaces;
using HeartsTracker.Core.Models;
using HeartsTracker.Core.QueryParams;
using HeartsTracker.Core.QueryParams.Players;
using HeartsTracker.Shared.Models.Player;
using HeartsTracker.Shared.Models.Player.Requests;

namespace HeartsTracker.Core.DataSources.Players
{
	public class PlayerApiDataSource : BaseApiDataSource, IPlayerDataSource
	{
		private readonly IApi _api;

		public PlayerApiDataSource( IApi api )
		{
			_api = api;
		}

		public async Task<Either<PlayerListResponse, ErrorResponse>> GetPlayers( )
		{
			PlayersQueryParameters queryParams = new PlayersQueryParameters( true );

			return await RequestAsync( ( ) => _api.GetPlayers( queryParams ) );
		}

		public async Task<Either<PlayerResponse, ErrorResponse>> GetPlayer( int playerId )
		{
			QueryParameters queryParams = new QueryParameters( );

			return await RequestAsync( ( ) => _api.GetPlayer( playerId, queryParams ) );
		}

		public async Task<Either<int, ErrorResponse>> AddPlayer( CreatePlayerRequest player )
		{
			QueryParameters queryParams = new QueryParameters( );

			return await RequestAsync( ( ) => _api.CreatePlayer( player, queryParams ) );
		}
	}
}