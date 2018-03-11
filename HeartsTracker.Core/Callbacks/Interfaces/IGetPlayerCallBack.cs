using HeartsTracker.Core.Models.Player;

namespace HeartsTracker.Core.Callbacks.Interfaces
{
	public interface IGetPlayerCallback : IBaseCallback
	{
		void OnPlayerLoaded( PlayerViewModel player );
	}
}