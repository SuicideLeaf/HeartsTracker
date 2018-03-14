using System.Threading.Tasks;
using HeartsTracker.Core.Callbacks.Players;
using HeartsTracker.Core.DataSources.Players;
using HeartsTracker.Core.Models.Players.Requests;
using HeartsTracker.Core.QueryParams;
using HeartsTracker.Core.QueryParams.Players;

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

		public async Task AddPlayer( AddPlayerRequest player, IAddPlayerCallback callback, QueryParameters queryParams )
		{
			await _playersApiDataSource.AddPlayer( player, callback, queryParams );
		}
	}
}
