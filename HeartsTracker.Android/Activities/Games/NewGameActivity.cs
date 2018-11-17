using System;
using Android.App;
using HeartsTracker.Android.Classes;
using HeartsTracker.Core.Classes;
using HeartsTracker.Core.Presenters.Games;
using HeartsTracker.Core.Views.Games;
using Unity;

namespace HeartsTracker.Android.Activities.Games
{
	[Activity( Label = "New Game" )]
	public class NewGameActivity : BaseApiActivity<NewGamePresenter>, INewGameView
	{
		public override void RegisterView()
		{
			App.Container.RegisterInstance<INewGameView>( this );
		}

		public override void FindViews()
		{
			throw new NotImplementedException();
		}

		public override void SetupViews()
		{
			throw new NotImplementedException();
		}

		public override void ShowDataError(Enums.DataError error)
		{
			throw new NotImplementedException();
		}
	}
}