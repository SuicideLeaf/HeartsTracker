using HeartsTracker.Core.Callbacks.Players;
using HeartsTracker.Core.DataSources.Players;
using HeartsTracker.Core.Views.Players;
using HeartsTracker.Shared.Models.Player.Requests;
using System.Threading.Tasks;

namespace HeartsTracker.Core.Presenters.Players
{
	public class AddPlayerPresenter : BasePresenter<IAddPlayerView>, IAddPlayerPresenter
	{
		private readonly IAddPlayerCallback _addPlayerViewCallback;
		private readonly IPlayerDataSource _playerRepository;

		public AddPlayerPresenter( IPlayerDataSource playerRepository, IAddPlayerView playerView, IAddPlayerCallback addPlayerViewCallback )
			: base( playerView )
		{
			_playerRepository = playerRepository;
			_addPlayerViewCallback = addPlayerViewCallback;
		}

		public async Task AddPlayer( )
		{
			AddPlayerRequest playerToAdd = CreateAddPlayerRequestModel( );
			await _playerRepository.AddPlayer( playerToAdd, _addPlayerViewCallback );
		}

		public AddPlayerRequest CreateAddPlayerRequestModel( )
		{
			AddPlayerRequest player = new AddPlayerRequest( View.PlayerName, View.FirstName, View.LastName, View.Colour );

			return player;
		}

		public override Task Start( )
		{
			return Task.CompletedTask;
		}
	}
}