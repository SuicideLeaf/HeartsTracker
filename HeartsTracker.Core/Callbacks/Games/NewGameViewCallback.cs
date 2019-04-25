using System;
using HeartsTracker.Core.Classes;
using HeartsTracker.Core.Views.Games;

namespace HeartsTracker.Core.Callbacks.Games
{
	public class NewGameViewCallback : INewGameCallback
	{
		private readonly INewGameView _newGameView;

		public NewGameViewCallback( INewGameView newGameView )
		{
			_newGameView = newGameView;
		}

		public void OnDataError( Enums.DataError dataError, string content )
		{
			throw new NotImplementedException( );
		}
	}
}