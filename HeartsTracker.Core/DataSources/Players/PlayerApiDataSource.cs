using System.Threading.Tasks;
using HeartsTracker.Core.Classes;
using HeartsTracker.Core.Interfaces;
using HeartsTracker.Core.Models;
using HeartsTracker.Core.Models.Players;
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

		public async Task GetPlayer(  int playerId )
		{
			//QueryParameters queryParams = new QueryParameters( );

			//Response<PlayerResponse> response = await RequestAsyncOld( ( ) => _api.GetPlayer( playerId, queryParams ) );

			//HandleResponse( callback, response, ( ) =>
			//{
			//	callback.OnPlayerLoaded( new PlayerViewModel( response.Data ) );
			//} );
		}

		public async Task AddPlayer( CreatePlayerRequest player )
		{
			//QueryParameters queryParams = new QueryParameters( );

			//Response<int> response = await RequestAsyncOld( ( ) => _api.CreatePlayer( player, queryParams ) );

			//HandleResponse( callback, response, ( ) =>
			//{
			//	callback.OnPlayerAdded( new PlayerListItemViewModel( response.Data, player.PlayerName, player.Colour ) );
			//} );
		}
	}
}