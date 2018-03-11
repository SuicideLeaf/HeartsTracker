using System.Threading.Tasks;

namespace HeartsTracker.Core.Presenters.Interfaces
{
	public interface IPlayersPresenter : IBasePresenter
	{
		Task LoadPlayers( );
		Task LoadPlayers( bool isRefreshing );
	}
}
