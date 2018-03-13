using System.Threading.Tasks;
using HeartsTracker.Core.Callbacks.Players;
using HeartsTracker.Core.Classes;
using HeartsTracker.Core.Interfaces;
using HeartsTracker.Core.Models.Players;
using HeartsTracker.Core.QueryParameters.Players;
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
				Player player = await _api.GetPlayer( queryParams );

				callback.OnPlayerLoaded( player );
			}
			catch ( ApiException e )
			{
				callback.OnDataNotAvailable( e.StatusCode.ToDataError( ) );
			}
		}
	}
}
