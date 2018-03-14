using HeartsTracker.Core.Classes;

namespace HeartsTracker.Core.Callbacks
{
	public interface IBaseCallback
	{
		void OnDataError( Enums.DataError dataError );
	}
}
