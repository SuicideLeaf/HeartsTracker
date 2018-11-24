using System.Threading.Tasks;
using HeartsTracker.Core.Callbacks.Players;
using HeartsTracker.Core.Interfaces;
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

		public async Task GetPlayers( IGetPlayersCallback callback )
		{
			PlayersQueryParameters queryParams = new PlayersQueryParameters( true );

			ResponseWrapper<PlayerListResponse> response = await SafeCallApi( ( ) => _api.GetPlayers( queryParams ) );

			HandleResponse( response, ( ) =>
			{
				PlayerListViewModel playerListViewModel = new PlayerListViewModel( response.Content );
				playerListViewModel.SortByNameAsc( );
				callback.OnPlayersLoaded( playerListViewModel );
			}, callback );
		}

		public async Task GetPlayer( IGetPlayerCallback callback, int playerId )
		{
			QueryParameters queryParams = new QueryParameters( );

			ResponseWrapper<UpdatePlayerRequest> response = await SafeCallApi( ( ) => _api.GetPlayer( playerId, queryParams ) );

			HandleResponse( response, ( ) => { callback.OnPlayerLoaded( new PlayerViewModel( response.Content ) ); }, callback );
		}

		public async Task AddPlayer( CreatePlayerRequest player, IAddPlayerCallback callback )
		{
			QueryParameters queryParams = new QueryParameters( );

			ResponseWrapper<PlayerListItemResponse> response = await SafeCallApi( ( ) => _api.CreatePlayer( player, queryParams ) );

			HandleResponse( response, ( ) => { callback.OnPlayerAdded( new PlayerListItemViewModel( response.Content ) ); }, callback );
		}
	}
}