using HeartsTracker.Core.Callbacks.Players;
using HeartsTracker.Core.DataSources.Players;
using HeartsTracker.Core.Views.Games;
using System.Threading.Tasks;

namespace HeartsTracker.Core.Presenters.Games
{
	public class NewGamePresenter : BasePresenter<INewGameView>, INewGamePresenter
	{
		public NewGamePresenter( IPlayerDataSource playerRepository, INewGameView view, IGetPlayersCallback getPlayersCallback ) : base( view )
		{
		}

		public override async Task Start( )
		{
		}
	}
}