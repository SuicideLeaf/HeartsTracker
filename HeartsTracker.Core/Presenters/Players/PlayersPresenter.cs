using System.Linq;
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
	public class PlayersPresenter : BasePresenter<IPlayersView>, IPlayersPresenter
	{
		private readonly IPlayerDataSource _playerRepository;

		public PlayersPresenter( IPlayerDataSource playerRepository, IPlayersView playersView )
			: base( playersView )
		{
			_playerRepository = playerRepository;
		}

		public async Task LoadPlayers( bool isRefreshing )
		{
			if ( !isRefreshing )
			{
				View.ShowLoadingOverlay( );
			}

			Either<PlayerListResponse, ErrorResponse> response = await _playerRepository.GetPlayers( );
			
			response
				.ConfigureNotFound( data => data.Players.Any( ), "No players found" )
				.OnSuccess( data => View.ShowPlayers( new PlayerListViewModel( data ) ) )
				.OnError( error => View.ShowError( error ) );

			View.ToggleLoadingOverlay( false );
		}
	}
}
