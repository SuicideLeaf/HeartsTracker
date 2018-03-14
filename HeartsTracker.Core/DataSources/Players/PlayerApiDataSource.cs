using System.Linq;
using System.Threading.Tasks;
using HeartsTracker.Core.Callbacks.Players;
using HeartsTracker.Core.Classes;
using HeartsTracker.Core.Interfaces;
using HeartsTracker.Core.Models.Players;
using HeartsTracker.Core.Models.Players.Requests;
using HeartsTracker.Core.QueryParams;
using HeartsTracker.Core.QueryParams.Players;
using Refit;

namespace HeartsTracker.Core.DataSources.Players
{
	public class PlayerApiDataSource : IPlayerDataSource
	{
		private readonly IApi _api;

		public PlayerApiDataSource( IApi api )
		{
			_api = api;
		}

		public async Task GetPlayers( IGetPlayersCallback callback, PlayersQueryParameters queryParams )
		{
			try
			{
				PlayerList playerList = await _api.GetPlayers( queryParams );

				playerList.SortPlayers( );

				callback.OnPlayersLoaded( playerList );
			}
			catch ( ApiException e )
			{
				callback.OnDataError( e.StatusCode.ToDataError( ) );
			}
		}

		public async Task GetPlayer( IGetPlayerCallback callback, PlayerQueryParameters queryParams )
		{
			try
			{
				Player player = await _api.GetPlayer( queryParams );

				callback.OnPlayerLoaded( player );
			}
			catch ( ApiException e )
			{
				callback.OnDataError( e.StatusCode.ToDataError( ) );
			}
		}

		public async Task AddPlayer( AddPlayerRequest player, IAddPlayerCallback callback, QueryParameters queryParams )
		{
			try
			{
				PlayerListItem playerListItem = await _api.CreatePlayer( player, queryParams );

				callback.OnPlayerAdded( playerListItem );
			}
			catch ( ApiException e )
			{
				callback.OnDataError( e.StatusCode.ToDataError( ) );
			}
		}
	}
}
