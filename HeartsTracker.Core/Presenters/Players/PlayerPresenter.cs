using System.Threading.Tasks;
using HeartsTracker.Core.DataSources.Players;
using HeartsTracker.Core.Views.Players;

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
			if ( !isRefreshing )
			{
				View.ShowLoadingOverlay( );
			}

			await _playerRepository.GetPlayer( View.PlayerId );
		}
	}
}
