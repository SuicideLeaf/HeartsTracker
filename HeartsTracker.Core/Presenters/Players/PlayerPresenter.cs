using System.Threading.Tasks;
using HeartsTracker.Core.Classes;
using HeartsTracker.Core.DataSources.Players;
using HeartsTracker.Core.Extensions;
using HeartsTracker.Core.Models;
using HeartsTracker.Core.Models.Players;
using HeartsTracker.Core.Views.Players;
using HeartsTracker.Shared.Models.Player;

namespace HeartsTracker.Core.Presenters.Players
{
	public class PlayerPresenter : BasePresenter<IPlayerView>, IPlayerPresenter
	{
		private readonly IPlayerDataSource _playerRepository;

		public PlayerPresenter( IPlayerDataSource playerRepository, IPlayerView playerView )
			: base( playerView )
		{
			_playerRepository = playerRepository;
		}

		public async Task LoadPlayer( bool isRefreshing )
		{
			Either<PlayerResponse, ErrorResponse> response = await RequestAsync( !isRefreshing, ( ) => _playerRepository.GetPlayer( View.PlayerId ) );

			response
				.ConfigureNotFound( "Player not found" )
				.OnSuccess( data => View.ShowPlayer( new PlayerViewModel( data ) ) )
				.OnError( error => View.Error.Show( error ) );
		}
	}
}
