using HeartsTracker.Core.DataSources.Players;
using HeartsTracker.Core.Views.Players;
using HeartsTracker.Shared.Models.Player.Requests;
using System.Threading.Tasks;

namespace HeartsTracker.Core.Presenters.Players
{
	public class AddPlayerPresenter : BasePresenter<IAddPlayerView>, IAddPlayerPresenter
	{
		private readonly IPlayerDataSource _playerRepository;

		public AddPlayerPresenter( IPlayerDataSource playerRepository, IAddPlayerView playerView )
			: base( playerView )
		{
			_playerRepository = playerRepository;
		}

		public async Task AddPlayer( )
		{
			CreatePlayerRequest playerToAdd = CreateAddPlayerRequestModel( );
			await _playerRepository.AddPlayer( playerToAdd );
		}

		public CreatePlayerRequest CreateAddPlayerRequestModel( )
		{
			CreatePlayerRequest player = new CreatePlayerRequest( View.PlayerName, View.FirstName, View.LastName, View.Colour );

			return player;
		}
	}
}