using HeartsTracker.Core.Classes;

namespace HeartsTracker.Core.Views
{
	public interface IBaseView
	{
		void ShowDataError( Enums.DataError error );
		void SetPresenter( );
	}
}
