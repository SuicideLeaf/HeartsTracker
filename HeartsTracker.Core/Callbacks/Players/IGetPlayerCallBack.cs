using HeartsTracker.Core.Models.Players;

namespace HeartsTracker.Core.Callbacks.Players
{
	public interface IGetPlayerCallback : IBaseCallback
	{
		void OnPlayerLoaded( Player player );
	}
}