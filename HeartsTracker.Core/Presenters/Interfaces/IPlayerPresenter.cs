using System.Threading.Tasks;

namespace HeartsTracker.Core.Presenters.Interfaces
{
	public interface IPlayerPresenter : IBasePresenter
	{
		Task LoadPlayer( );
		Task LoadPlayer( bool isRefreshing );
	}
}
