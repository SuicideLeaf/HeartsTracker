using Android.App;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Widget;
using HeartsTracker.Core.Presenters.Players;

namespace HeartsTracker.Android.Activities.Players
{
	[Activity( Label = "Player Details" )]
	public partial class PlayerActivity : DataSourceActivity<PlayerPresenter>
	{
		public int PlayerId { get; set; }

		private TextView _playerNameTextView;
		private TextView _firstNameTextView;
		private TextView _lastNameTextView;
		private SwipeRefreshLayout _swipeRefreshLayout;

		protected override void OnCreate( Bundle savedInstanceState )
		{
			PlayerId = Intent.GetIntExtra( "PlayerId", 0 );

			base.OnCreate( savedInstanceState );

			SetContentView( Resource.Layout.player_activity );

			FindViews( );

			ConfigureRefresh( );
		}

		protected override async void OnResume( )
		{
			base.OnResume( );

			await Presenter.LoadPlayer( false );
		}

		public void FindViews( )
		{
			_playerNameTextView = FindViewById<TextView>( Resource.Id.player_details_textview_playername );
			_firstNameTextView = FindViewById<TextView>( Resource.Id.player_details_textview_firstname );
			_lastNameTextView = FindViewById<TextView>( Resource.Id.player_details_textview_lastname );
			_swipeRefreshLayout = FindViewById<SwipeRefreshLayout>( Resource.Id.refresh_layout );
		}

		public void ConfigureRefresh( )
		{
			_swipeRefreshLayout.Refresh += async ( sender, e ) =>
			{
				await Presenter.LoadPlayer( true );
			};
		}
	}
}