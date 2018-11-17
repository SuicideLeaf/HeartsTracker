using System.Threading.Tasks;
using HeartsTracker.Core.Callbacks.Players;
using HeartsTracker.Core.DataSources.Players;
using HeartsTracker.Core.Views.Players;

namespace HeartsTracker.Core.Presenters.Players
{
	public class PlayersPresenter : BasePresenter<IPlayersView>, IPlayersPresenter
	{
		private readonly IPlayerDataSource _playerRepository;
		private readonly IGetPlayersCallback _playersViewCallback;

		public PlayersPresenter( IPlayerDataSource playerRepository, IPlayersView playersView, IGetPlayersCallback playersViewCallback )
			: base( playersView )
		{
			_playerRepository = playerRepository;
			_playersViewCallback = playersViewCallback;
		}

		public async Task LoadPlayers( )
		{
			await LoadPlayers( false );
		}

		public async Task LoadPlayers( bool isRefreshing )
		{
			if ( !isRefreshing )
			{
				View.ShowLoadingOverlay( );
			}

			await _playerRepository.GetPlayers( _playersViewCallback );
		}

		public override async Task Start( )
		{
			await LoadPlayers( );
		}
	}
}
