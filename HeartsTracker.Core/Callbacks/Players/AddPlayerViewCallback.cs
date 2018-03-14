using HeartsTracker.Core.Classes;
using HeartsTracker.Core.Models.Players;
using HeartsTracker.Core.Views.Players;

namespace HeartsTracker.Core.Callbacks.Players
{
	public class AddPlayerViewCallback : IAddPlayerCallback
	{
		private readonly IAddPlayerView _addPlayerView;

		public AddPlayerViewCallback( IAddPlayerView addPlayerView )
		{
			_addPlayerView = addPlayerView;
		}

		public void OnPlayerAdded( PlayerListItem playerListItem )
		{
			_addPlayerView.FinishActivity( playerListItem );
		}

		public void OnDataError( Enums.DataError dataError )
		{
			_addPlayerView.ShowDataError( dataError );
		}
	}
}
