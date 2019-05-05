using HeartsTracker.Shared.Models.Player.Requests;
using System.Threading.Tasks;

namespace HeartsTracker.Core.Presenters.Players
{
	public interface IAddPlayerPresenter
	{
		Task AddPlayer( );
	}
}