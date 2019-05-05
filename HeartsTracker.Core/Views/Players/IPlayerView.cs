using HeartsTracker.Core.Models.Players;

namespace HeartsTracker.Core.Views.Players
{
	public interface IPlayerView : IBaseView
	{
		int PlayerId { get; set; }
		void ShowPlayer( PlayerViewModel player );
	}
}
