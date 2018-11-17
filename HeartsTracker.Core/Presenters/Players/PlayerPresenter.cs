using System.Threading.Tasks;
using HeartsTracker.Core.Callbacks.Players;
using HeartsTracker.Core.DataSources.Players;
using HeartsTracker.Core.Views.Players;

namespace HeartsTracker.Core.Presenters.Players
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

			await _playerRepository.GetPlayer( _playerViewCallback, View.PlayerId );
		}

		public override async Task Start( )
		{
			await LoadPlayer( );
		}
	}
}
