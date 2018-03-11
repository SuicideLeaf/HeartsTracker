using HeartsTracker.Core.Classes;

namespace HeartsTracker.Core.Callbacks.Interfaces
{
	public interface IBaseCallback
	{
		void OnDataNotAvailable( Enums.DataError dataError );
	}
}
