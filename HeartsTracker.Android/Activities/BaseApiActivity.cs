using Android.Support.V7.App;
using HeartsTracker.Android.Classes;
using HeartsTracker.Core.Classes;
using HeartsTracker.Core.Presenters;
using HeartsTracker.Core.Views;
using Unity;

namespace HeartsTracker.Android.Activities
{
	public abstract class BaseApiActivity<TPresenter> : AppCompatActivity, IBaseView
		where TPresenter : BasePresenter
	{
		public TPresenter Presenter { get; set; }

		public abstract void RegisterView( );

		public abstract void ShowDataError( Enums.DataError error );

		public void SetPresenter( )
		{
			RegisterView( );

			Presenter = App.Container.Resolve<TPresenter>( );
		}
	}
}