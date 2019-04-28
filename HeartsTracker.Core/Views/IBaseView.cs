using HeartsTracker.Core.Classes;

namespace HeartsTracker.Core.Views
{
	public interface IBaseView
	{
		void ShowError( string errorMessage );
		void SetPresenter( );
	}
}
