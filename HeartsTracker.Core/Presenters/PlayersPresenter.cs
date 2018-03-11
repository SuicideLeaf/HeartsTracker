using System.Threading.Tasks;
using HeartsTracker.Core.Callbacks.Interfaces;
using HeartsTracker.Core.DataSources.Interfaces;
using HeartsTracker.Core.Presenters.Interfaces;
using HeartsTracker.Core.Views;

namespace HeartsTracker.Core.Presenters
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

			await _playerRepository.GetPlayers( _playersViewCallback, View.QueryParameters );
		}

		public override async Task Start( )
		{
			await LoadPlayers( );
		}
	}
}
