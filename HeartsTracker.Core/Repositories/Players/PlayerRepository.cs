using HeartsTracker.Core.Callbacks.Players;
using HeartsTracker.Core.DataSources.Players;
using HeartsTracker.Shared.Models.Player.Requests;
using System.Threading.Tasks;

namespace HeartsTracker.Core.Repositories.Players
{
	public class PlayerRepository : IPlayerDataSource
	{
		private readonly IPlayerDataSource _playersApiDataSource;

		public PlayerRepository( IPlayerDataSource playersApiDataSource )
		{
			_playersApiDataSource = playersApiDataSource;
		}

		public async Task AddPlayer( AddPlayerRequest player, IAddPlayerCallback callback )
		{
			await _playersApiDataSource.AddPlayer( player, callback );
		}

		public async Task GetPlayer( IGetPlayerCallback callback, int playerId )
		{
			await _playersApiDataSource.GetPlayer( callback, playerId );
		}

		public async Task GetPlayers( IGetPlayersCallback callback )
		{
			await _playersApiDataSource.GetPlayers( callback );
		}
	}
}