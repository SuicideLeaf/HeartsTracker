using Android.OS;
using HeartsTracker.Core.Classes;
using HeartsTracker.Core.Presenters;
using HeartsTracker.Core.QueryParams;
using HeartsTracker.Core.Views;

namespace HeartsTracker.Android.Activities
{
	public abstract class BaseApiActivity<TPresenter, TParams> : BaseActivity<TPresenter>, IApiView<TParams>
		where TPresenter : BasePresenter
		where TParams : QueryParameters
	{
		public TParams QueryParameters { get; set; }

		public override void RegisterView( )
		{
			// Not needed, this will be registered further up the chain.
		}

		protected override void OnCreate( Bundle savedInstanceState )
		{
			base.OnCreate( savedInstanceState );

			SetupQueryParameters( );
		}

		public abstract void ShowDataError( Enums.DataError error );

		private void SetupQueryParameters( )
		{
			// Todo authentication params
		}
	}
}