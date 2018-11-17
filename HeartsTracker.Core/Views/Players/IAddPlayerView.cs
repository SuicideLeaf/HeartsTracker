using HeartsTracker.Core.Models.Players;

namespace HeartsTracker.Core.Views.Players
{
	public interface IAddPlayerView : IBaseView
	{
		string PlayerName { get; }
		string LastName { get; }
		string FirstName { get; }
		string Colour { get; }
		void DisableSubmitButton( );
		void EnableSubmitButton( );
		void FinishActivity( PlayerListItemViewModel playerListItem );
	}
}
