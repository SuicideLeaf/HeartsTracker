using System.Threading.Tasks;

namespace HeartsTracker.Core.Presenters.Players
{
	public interface IPlayersPresenter
	{
		Task LoadPlayers( bool isRefreshing );
	}
}
