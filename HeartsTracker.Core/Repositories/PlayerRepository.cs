using System.Threading.Tasks;
using HeartsTracker.Core.Callbacks.Interfaces;
using HeartsTracker.Core.DataSources.Interfaces;
using HeartsTracker.Core.QueryParameters;

namespace HeartsTracker.Core.Repositories
{
	public class PlayerRepository : IPlayerDataSource
	{
		private readonly IPlayerDataSource _playersApiDataSource;

		public PlayerRepository( IPlayerDataSource playersApiDataSource )
		{
			_playersApiDataSource = playersApiDataSource;
		}

		public async Task GetPlayer( IGetPlayerCallback callback, PlayerQueryParameters queryParams )
		{
			await _playersApiDataSource.GetPlayer( callback, queryParams );
		}

		public async Task GetPlayers( IGetPlayersCallback callback, PlayersQueryParameters queryParams )
		{
			await _playersApiDataSource.GetPlayers( callback, queryParams );
		}
	}
}
