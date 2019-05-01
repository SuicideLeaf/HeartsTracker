using Android.OS;
using Android.Support.V7.App;
using HeartsTracker.Android.Classes;
using HeartsTracker.Core.Interfaces;
using HeartsTracker.Core.Presenters;
using HeartsTracker.Core.Views;
using Unity;

namespace HeartsTracker.Android.Activities
{
	public abstract class DataSourceActivity<TPresenter> : AppCompatActivity, IBaseView
		where TPresenter : BasePresenter
	{
		public TPresenter Presenter { get; set; }
		public ILoadingView Loading { get; set; }
		public IErrorView Error { get; set; }
		public abstract void RegisterView( );

		protected override void OnCreate( Bundle savedInstanceState )
		{
			base.OnCreate( savedInstanceState );

			// Register the view instance through dependency injection
			RegisterView( );

			// Resolve the presenter now that all dependencies have been configured.
			Presenter = App.Container.Resolve<TPresenter>( );
		}
	}
}