using System.Threading.Tasks;
using HeartsTracker.Core.Views;

namespace HeartsTracker.Core.Presenters
{
	public abstract class BasePresenter : IBasePresenter
	{
		public IBaseView View { get; set; }
		public abstract Task Start( );

		protected internal BasePresenter( IBaseView view )
		{
			View = view;
		}
	}

	public abstract class BasePresenter<TView> : BasePresenter
		where TView : IBaseView
	{
		protected internal BasePresenter( TView view ) : base( view ) { }

		public new TView View
		{
			get
			{
				return ( TView )base.View;
			}
			set
			{
				base.View = value;
			}
		}
	}
}
