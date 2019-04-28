using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Constraints;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using HeartsTracker.Android.Adapters;
using HeartsTracker.Android.Classes;
using HeartsTracker.Core.Models.Players;
using HeartsTracker.Core.Presenters.Players;
using HeartsTracker.Core.Views.Players;
using Newtonsoft.Json;
using Unity;

namespace HeartsTracker.Android.Activities.Players
{
	[Activity( Label = "Players", MainLauncher = true )]
	public class PlayersActivity : BaseApiActivity<PlayersPresenter>, IPlayersView
	{
		private const int AddPlayerRequestCode = 1;

		private PlayersAdapter _playersAdapter;
		private RecyclerView _recyclerView;
		private ConstraintLayout _playersView;
		private FloatingActionButton _fabAddPlayer;
		private SwipeRefreshLayout _swipeRefreshLayout;

		public override void RegisterView( )
		{
			App.Container.RegisterInstance<IPlayersView>( this );
		}

		protected override async void OnCreate( Bundle savedInstanceState )
		{
			base.OnCreate( savedInstanceState );

			SetContentView( Resource.Layout.players_activity );

			FindViews( );

			SetupViews( );

			await Presenter.LoadPlayers( false );
		}

		protected override void OnActivityResult( int requestCode, Result resultCode, Intent data )
		{
			if ( requestCode == AddPlayerRequestCode && resultCode == Result.Ok )
			{
				string jsonPlayerListItemData = data.GetStringExtra( "PlayerListItem" );
				PlayerListItemViewModel playerListItem = JsonConvert.DeserializeObject<PlayerListItemViewModel>( jsonPlayerListItemData );
				_playersAdapter.AddPlayerToList( playerListItem );
			}
		}

		private void FindViews( )
		{
			_recyclerView = FindViewById<RecyclerView>( Resource.Id.players_recyclerview );
			_playersView = FindViewById<ConstraintLayout>( Resource.Id.players_exist_rootlayout );
			_fabAddPlayer = FindViewById<FloatingActionButton>( Resource.Id.players_fab_addplayer );
			_swipeRefreshLayout = FindViewById<SwipeRefreshLayout>( Resource.Id.refresh_layout );
		}

		private void SetupViews( )
		{
			_playersAdapter = new PlayersAdapter( this );
			_playersAdapter.PlayerClicked += ( sender, pos ) =>
			{
				PlayerListItemViewModel playerListItem = _playersAdapter.GetPlayer( pos );
				LoadPlayerDetailsScreen( playerListItem.Id );
			};

			_recyclerView.SetLayoutManager( new LinearLayoutManager( this ) );
			_recyclerView.SetAdapter( _playersAdapter );
			_recyclerView.AddItemDecoration( new DividerItemDecoration( this, DividerItemDecoration.Vertical ) );

			_swipeRefreshLayout.Refresh += async ( sender, e ) =>
			{
				await Presenter.LoadPlayers( true );
			};

			_fabAddPlayer.Click += FabAddPlayerOnClick;

			SetPresenter( );
		}

		private void FabAddPlayerOnClick( object sender, EventArgs eventArgs )
		{
			Intent intent = new Intent( this, typeof( AddPlayerActivity ) );
			StartActivityForResult( intent, AddPlayerRequestCode );
		}

		public override void ShowError( string error )
		{
			ToggleRetryOverlay( true, error );
		}

		public void ShowPlayers( PlayerListViewModel playerList )
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
		}

		public void ToggleRetryOverlay( bool active, string message = "" )
		{
			_playersView.Visibility = active ? ViewStates.Gone : ViewStates.Visible;
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
	}
}