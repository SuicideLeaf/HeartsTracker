namespace HeartsTracker.Core.Interfaces
{
	public interface IErrorView
	{
		void Show( string errorMessage );
		void Hide( );
	}
}