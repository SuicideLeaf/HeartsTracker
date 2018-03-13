using System.Threading.Tasks;
using HeartsTracker.Core.Callbacks.Players;
using HeartsTracker.Core.DataSources.Players;
using HeartsTracker.Core.QueryParameters.Players;

namespace HeartsTracker.Core.Repositories.Players
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
