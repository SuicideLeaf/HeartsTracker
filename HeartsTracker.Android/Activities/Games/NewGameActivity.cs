﻿using System;
using Android.App;
using HeartsTracker.Android.Classes;
using HeartsTracker.Core.Presenters.Games;
using HeartsTracker.Core.Views.Games;
using Unity;

namespace HeartsTracker.Android.Activities.Games
{
	[Activity( Label = "New Game" )]
	public class NewGameActivity : DataSourceActivity<NewGamePresenter>, INewGameView
	{
		public override void RegisterView( )
		{
			App.Container.RegisterInstance<INewGameView>( this );
		}

		public void FindViews( )
		{
			throw new NotImplementedException( );
		}

		public void SetupViews( )
		{
			throw new NotImplementedException( );
		}
	}
}