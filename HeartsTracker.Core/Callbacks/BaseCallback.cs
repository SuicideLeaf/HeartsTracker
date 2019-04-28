using HeartsTracker.Core.Classes;
using HeartsTracker.Core.Views;

namespace HeartsTracker.Core.Callbacks
{
	public class BaseCallback<T> where T : IBaseView
	{
		protected T View { get; }

		public BaseCallback( T view )
		{
			View = view;
		}

		public virtual void OnDataError( Enums.DataError dataError, string content )
		{
			View.ShowDataError( dataError );
		}
	}
}