using Android.App;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Widget;
using HeartsTracker.Android.Classes;
using HeartsTracker.Core.Classes;
using HeartsTracker.Core.Models.Player;
using HeartsTracker.Core.Presenters;
using HeartsTracker.Core.QueryParameters;
using HeartsTracker.Core.Views;
using Unity;

namespace HeartsTracker.Android.Activities
{
	[Activity( Label = "Player Details" )]
	public class PlayerActivity : BaseApiActivity<PlayerPresenter, PlayerQueryParameters>, IPlayerView
	{
		private int _playerId;

		private TextView _playerNameTextView;
		private TextView _firstNameTextView;
		private TextView _lastNameTextView;
		private SwipeRefreshLayout _swipeRefreshLayout;

		public override void RegisterView( )
		{
			App.Container.RegisterInstance<IPlayerView>( this );
		}

		protected override void OnCreate( Bundle savedInstanceState )
		{
			_playerId = Intent.GetIntExtra( "PlayerId", 0 );

			QueryParameters = new PlayerQueryParameters( _playerId );

			base.OnCreate( savedInstanceState );

			SetContentView( Resource.Layout.player_activity );

			FindViews( );

			SetupViews( );
		}

		protected override async void OnResume( )
		{
			base.OnResume( );
			await Presenter.Start( );
		}

		private void FindViews( )
		{
			_playerNameTextView = FindViewById<TextView>( Resource.Id.player_details_textview_playername );
			_firstNameTextView = FindViewById<TextView>( Resource.Id.player_details_textview_firstname );
			_lastNameTextView = FindViewById<TextView>( Resource.Id.player_details_textview_lastname );
			_swipeRefreshLayout = FindViewById<SwipeRefreshLayout>( Resource.Id.refresh_layout );
		}

		private void SetupViews( )
		{
			_swipeRefreshLayout.Refresh += async ( sender, e ) =>
			{
				await Presenter.LoadPlayer( true );
			};

			SetPresenter( );
		}

		public bool IsActive => true;

		public void ToggleRefreshing( bool active )
		{
			_swipeRefreshLayout.Refreshing = active;
		}

		public void ToggleLoadingOverlay( bool active )
		{
			//
		}

		public void ToggleRetryOverlay( bool active, string message = "" )
		{
			//
		}

		public void ShowLoadingOverlay( )
		{
			//
		}

		public void ShowPlayer( PlayerViewModel player )
		{
			_playerNameTextView.Text = player.PlayerName;
			_firstNameTextView.Text = player.FirstName;
			_lastNameTextView.Text = player.LastName;

			ToggleRefreshing( false );
			ToggleRetryOverlay( false );
			ToggleLoadingOverlay( false );
		}

		public override void ShowLoadingError( Enums.DataError error )
		{
			ToggleRefreshing( false );
			ToggleLoadingOverlay( false );
			switch ( error )
			{
				case Enums.DataError.NotFound:
					ToggleRetryOverlay( true, "This player could not be found... Tap to retry" );
					break;
				default:
					ToggleRetryOverlay( true, "Something went wrong... Tap to retry" );
					break;
			}
		}
	}
}