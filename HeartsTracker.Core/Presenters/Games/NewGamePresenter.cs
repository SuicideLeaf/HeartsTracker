using HeartsTracker.Core.DataSources.Players;
using HeartsTracker.Core.Views.Games;

namespace HeartsTracker.Core.Presenters.Games
{
	public class NewGamePresenter : BasePresenter<INewGameView>, INewGamePresenter
	{
		public NewGamePresenter( IPlayerDataSource playerRepository, INewGameView view ) : base( view )
		{
		}
	}
}