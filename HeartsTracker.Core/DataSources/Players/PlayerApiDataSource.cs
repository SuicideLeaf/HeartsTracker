using System.Threading.Tasks;
using HeartsTracker.Core.Callbacks.Players;
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

		public async Task GetPlayers( IGetPlayersCallback callback )
		{
			PlayersQueryParameters queryParams = new PlayersQueryParameters( true );

			Response<PlayerListResponse> response = await RequestAsync( ( ) => _api.GetPlayers( queryParams ) );

			HandleResponse( callback, response, ( ) =>
			{
				PlayerListViewModel playerListViewModel = new PlayerListViewModel( response.Data );
				playerListViewModel.SortByNameAsc( );
				callback.OnPlayersLoaded( playerListViewModel );
			} );
		}

		public async Task GetPlayer( IGetPlayerCallback callback, int playerId )
		{
			QueryParameters queryParams = new QueryParameters( );

			Response<PlayerResponse> response = await RequestAsync( ( ) => _api.GetPlayer( playerId, queryParams ) );

			HandleResponse( callback, response, ( ) =>
			{
				callback.OnPlayerLoaded( new PlayerViewModel( response.Data ) );
			} );
		}

		public async Task AddPlayer( CreatePlayerRequest player, IAddPlayerCallback callback )
		{
			QueryParameters queryParams = new QueryParameters( );

			Response<int> response = await RequestAsync( ( ) => _api.CreatePlayer( player, queryParams ) );

			HandleResponse( callback, response, ( ) =>
			{
				callback.OnPlayerAdded( new PlayerListItemViewModel( response.Data, player.PlayerName, player.Colour ) );
			} );
		}
	}
}