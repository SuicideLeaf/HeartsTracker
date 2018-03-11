using System.Threading.Tasks;
using HeartsTracker.Core.Callbacks.Interfaces;
using HeartsTracker.Core.DataSources.Interfaces;
using HeartsTracker.Core.Presenters.Interfaces;
using HeartsTracker.Core.Views;

namespace HeartsTracker.Core.Presenters
{
	public class PlayerPresenter : BasePresenter<IPlayerView>, IPlayerPresenter
	{
		private readonly IPlayerDataSource _playerRepository;
		private readonly IGetPlayerCallback _playerViewCallback;

		public PlayerPresenter( IPlayerDataSource playerRepository, IPlayerView playerView, IGetPlayerCallback playerViewCallback )
			: base( playerView )
		{
			_playerRepository = playerRepository;
			_playerViewCallback = playerViewCallback;
		}

		public async Task LoadPlayer( )
		{
			await LoadPlayer( false );
		}

		public async Task LoadPlayer( bool isRefreshing )
		{
			if ( !isRefreshing )
			{
				View.ShowLoadingOverlay( );
			}

			await _playerRepository.GetPlayer( _playerViewCallback, View.QueryParameters );
		}

		public override async Task Start( )
		{
			await LoadPlayer( );
		}
	}
}
