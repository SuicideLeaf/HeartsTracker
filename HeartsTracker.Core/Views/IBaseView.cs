using HeartsTracker.Core.Interfaces;

namespace HeartsTracker.Core.Views
{
	public interface IBaseView
	{
		ILoadingView Loading { get; set; }
		IErrorView Error { get; set; }
	}
}
