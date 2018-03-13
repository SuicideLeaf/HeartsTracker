using HeartsTracker.Core.Classes;

namespace HeartsTracker.Core.Callbacks
{
	public interface IBaseCallback
	{
		void OnDataNotAvailable( Enums.DataError dataError );
	}
}
