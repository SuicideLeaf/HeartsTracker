using System.Threading.Tasks;

namespace HeartsTracker.Core.Presenters.Players
{
	public interface IPlayerPresenter : IBasePresenter
	{
		Task LoadPlayer( );
		Task LoadPlayer( bool isRefreshing );
	}
}
