using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Constraints;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using HeartsTracker.Android.Adapters;
using HeartsTracker.Android.Classes;
using HeartsTracker.Core.Classes;
using HeartsTracker.Core.Models.Players;
using HeartsTracker.Core.Presenters.Players;
using HeartsTracker.Core.QueryParameters.Players;
using HeartsTracker.Core.Views.Players;
using Unity;

namespace HeartsTracker.Android.Activities
{
	[Activity( Label = "Players", MainLauncher = true )]
	public class PlayersActivity : BaseApiActivity<PlayersPresenter, PlayersQueryParameters>, IPlayersView
	{
		private PlayersAdapter _playersAdapter;
		private RecyclerView _recyclerView;
		private ConstraintLayout _playersView;
		private ConstraintLayout _noPlayersView;
		private TextView _noPlayersTextView;
		private SwipeRefreshLayout _swipeRefreshLayout;

		public override void RegisterView( )
		{
			App.Container.RegisterInstance<IPlayersView>( this );
		}

		protected override void OnCreate( Bundle savedInstanceState )
		{
			QueryParameters = new PlayersQueryParameters( );

			base.OnCreate( savedInstanceState );

			SetContentView( Resource.Layout.players_activity );

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
			_recyclerView = FindViewById<RecyclerView>( Resource.Id.players_recyclerview );
			_playersView = FindViewById<ConstraintLayout>( Resource.Id.players_exist_rootlayout );
			_noPlayersView = FindViewById<ConstraintLayout>( Resource.Id.players_none_rootlayout );
			_noPlayersTextView = FindViewById<TextView>( Resource.Id.players_none_textview );
			_swipeRefreshLayout = FindViewById<SwipeRefreshLayout>( Resource.Id.refresh_layout );
		}

		private void SetupViews( )
		{
			_playersAdapter = new PlayersAdapter( );
			_playersAdapter.PlayerClicked += ( sender, pos ) =>
			{
				PlayerListItem playerListItem = _playersAdapter.GetPlayer( pos );
				LoadPlayerDetailsScreen( playerListItem.Id );
			};
			_recyclerView.SetLayoutManager( new LinearLayoutManager( this ) );
			_recyclerView.SetAdapter( _playersAdapter );

			_swipeRefreshLayout.Refresh += async ( sender, e ) =>
			{
				await Presenter.LoadPlayers( true );
			};

			SetPresenter( );
		}

		public bool IsActive => true;

		public void ShowPlayers( PlayerList playerList )
		{
			_playersAdapter.ReplaceData( playerList );
			ToggleRefreshing( false );
			ToggleRetryOverlay( false );
			ToggleLoadingOverlay( false );
		}

		public void ToggleRefreshing( bool active )
		{
			_swipeRefreshLayout.Refreshing = active;
		}

		public void ToggleLoadingOverlay( bool active )
		{
			_playersView.Visibility = active ? ViewStates.Gone : ViewStates.Visible;
			_noPlayersView.Visibility = active ? ViewStates.Visible : ViewStates.Gone;
			_noPlayersTextView.Text = "Loading...";
		}

		public void ToggleRetryOverlay( bool active, string message = "" )
		{
			_playersView.Visibility = active ? ViewStates.Gone : ViewStates.Visible;
			_noPlayersView.Visibility = active ? ViewStates.Visible : ViewStates.Gone;
			_noPlayersTextView.Text = message;
		}

		public void ShowLoadingOverlay( )
		{
			ToggleRefreshing( false );
			ToggleLoadingOverlay( true );
			ToggleRetryOverlay( false );
		}

		public void LoadPlayerDetailsScreen( int playerId )
		{
			Intent intent = new Intent( this, typeof( PlayerActivity ) );
			intent.PutExtra( "PlayerId", playerId );
			StartActivity( intent );
		}

		public override void ShowLoadingError( Enums.DataError error )
		{
			ToggleRefreshing( false );
			ToggleLoadingOverlay( false );
			switch ( error )
			{
				case Enums.DataError.NotFound:
					ToggleRetryOverlay( true, "No players found... Tap to retry" );
					break;
				default:
					ToggleRetryOverlay( true, "Something went wrong... Tap to retry" );
					break;
			}
		}
	}
}