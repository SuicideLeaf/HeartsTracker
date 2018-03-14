using HeartsTracker.Core.Classes;

namespace HeartsTracker.Core.Views
{
	public interface IApiView<TParams> : IBaseView
	{
		TParams QueryParameters { get; set; }
		void ShowDataError( Enums.DataError error );
	}
}
