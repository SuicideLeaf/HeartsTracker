using System.Threading.Tasks;
using HeartsTracker.Core.Callbacks.Players;
using HeartsTracker.Core.DataSources.Players;
using HeartsTracker.Core.Models.Players;
using HeartsTracker.Core.Models.Players.Requests;
using HeartsTracker.Core.Views.Players;

namespace HeartsTracker.Core.Presenters.Players
{
	public class AddPlayerPresenter : BasePresenter<IAddPlayerView>, IAddPlayerPresenter
	{
		private readonly IPlayerDataSource _playerRepository;
		private readonly IAddPlayerCallback _addPlayerViewCallback;

		public AddPlayerPresenter( IPlayerDataSource playerRepository, IAddPlayerView playerView, IAddPlayerCallback addPlayerViewCallback )
			: base( playerView )
		{
			_playerRepository = playerRepository;
			_addPlayerViewCallback = addPlayerViewCallback;
		}

		public async Task AddPlayer( )
		{
			AddPlayerRequest playerToAdd = CreateAddPlayerRequestModel( );
			await _playerRepository.AddPlayer( playerToAdd, _addPlayerViewCallback, View.QueryParameters );
		}

		public override Task Start( )
		{
			return Task.CompletedTask;
		}

		public AddPlayerRequest CreateAddPlayerRequestModel( )
		{
			AddPlayerRequest player = new AddPlayerRequest( View.PlayerName, View.FirstName, View.LastName, View.Colour );

			return player;
		}
	}
}
