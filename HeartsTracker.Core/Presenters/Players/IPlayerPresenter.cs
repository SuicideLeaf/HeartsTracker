using System.Threading.Tasks;

namespace HeartsTracker.Core.Presenters.Players
{
	public interface IPlayerPresenter
	{
		Task LoadPlayer( bool isRefreshing );
	}
}
