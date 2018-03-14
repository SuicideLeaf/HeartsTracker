using HeartsTracker.Core.Models.Players;
using HeartsTracker.Core.QueryParams;

namespace HeartsTracker.Core.Views.Players
{
	public interface IAddPlayerView : IApiView<QueryParameters>
	{
		string PlayerName { get; }
		string LastName { get; }
		string FirstName { get; }
		string Colour { get; }
		void DisableSubmitButton( );
		void EnableSubmitButton( );
		void FinishActivity( PlayerListItem playerListItem );
	}
}
