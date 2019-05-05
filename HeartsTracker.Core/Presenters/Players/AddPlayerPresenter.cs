using HeartsTracker.Core.DataSources.Players;
using HeartsTracker.Core.Views.Players;
using HeartsTracker.Shared.Models.Player.Requests;
using System.Threading.Tasks;
using HeartsTracker.Core.Classes;
using HeartsTracker.Core.Extensions;
using HeartsTracker.Core.Models;

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
			CreatePlayerRequest playerToAdd = new CreatePlayerRequest( View.PlayerName, View.FirstName, View.LastName, View.Colour );

			Either<int, ErrorResponse> response = await RequestAsync( true, ( ) => _playerRepository.AddPlayer( playerToAdd ) );

			response.OnError( error => View.Error.Show( error.GetErrorMessage( ) ) );
		}
	}
}