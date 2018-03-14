using Android.Support.V7.App;
using HeartsTracker.Android.Classes;
using HeartsTracker.Core.Presenters;
using HeartsTracker.Core.Views;
using Unity;

namespace HeartsTracker.Android.Activities
{
	public abstract class BaseActivity<TPresenter> : AppCompatActivity, IBaseView
		where TPresenter : BasePresenter
	{
		public TPresenter Presenter { get; set; }

		public abstract void RegisterView( );

		public abstract void FindViews( );

		public abstract void SetupViews( );

		public void SetPresenter( )
		{
			RegisterView( );

			Presenter = App.Container.Resolve<TPresenter>( );
		}
	}
}