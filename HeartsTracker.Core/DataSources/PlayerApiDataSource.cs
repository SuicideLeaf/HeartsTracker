using System.Net;
using System.Threading.Tasks;
using HeartsTracker.Core.Callbacks.Interfaces;
using HeartsTracker.Core.Classes;
using HeartsTracker.Core.DataSources.Interfaces;
using HeartsTracker.Core.Interfaces;
using HeartsTracker.Core.Models.Player;
using HeartsTracker.Core.QueryParameters;
using Refit;

namespace HeartsTracker.Core.DataSources
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
				PlayerList response = await _api.GetPlayers( queryParams );

				PlayerListViewModel playerList = new PlayerListViewModel( response );

				callback.OnPlayersLoaded( playerList );
			}
			catch ( ApiException e )
			{
				callback.OnDataNotAvailable( e.StatusCode.ToDataError( ) );
			}
		}

		public async Task GetPlayer( IGetPlayerCallback callback, PlayerQueryParameters queryParams )
		{
			try
			{
				Player response = await _api.GetPlayer( queryParams );

				PlayerViewModel player = new PlayerViewModel( response );

				callback.OnPlayerLoaded( player );
			}
			catch ( ApiException e )
			{
				callback.OnDataNotAvailable( e.StatusCode.ToDataError( ) );
			}
		}
	}
}
