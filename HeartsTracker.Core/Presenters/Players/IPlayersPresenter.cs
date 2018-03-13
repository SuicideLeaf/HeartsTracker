using System.Threading.Tasks;

namespace HeartsTracker.Core.Presenters.Players
{
	public interface IPlayersPresenter : IBasePresenter
	{
		Task LoadPlayers( );
		Task LoadPlayers( bool isRefreshing );
	}
}
