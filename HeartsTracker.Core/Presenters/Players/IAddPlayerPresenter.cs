using System.Threading.Tasks;
using HeartsTracker.Core.Models.Players.Requests;

namespace HeartsTracker.Core.Presenters.Players
{
	public interface IAddPlayerPresenter
	{
		Task AddPlayer( );
		AddPlayerRequest CreateAddPlayerRequestModel( );
	}
}