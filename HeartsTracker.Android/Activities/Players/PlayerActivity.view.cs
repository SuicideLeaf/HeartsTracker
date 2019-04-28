using HeartsTracker.Android.Classes;
using HeartsTracker.Core.Models.Players;
using HeartsTracker.Core.Views.Players;
using Unity;

namespace HeartsTracker.Android.Activities.Players
{
	public partial class PlayerActivity : IPlayerView
	{
		public override void RegisterView( )
		{
			App.Container.RegisterInstance<IPlayerView>( this );
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

		public void ToggleRefreshing( bool active )
		{
			_swipeRefreshLayout.Refreshing = active;
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
	}


}