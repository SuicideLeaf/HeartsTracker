using System;
using Android.App;
using Android.Runtime;
using HeartsTracker.Core.Callbacks.Players;
using HeartsTracker.Core.DataSources.Players;
using HeartsTracker.Core.Interfaces;
using HeartsTracker.Core.Repositories.Players;
using Refit;
using Unity;
using Unity.Injection;

namespace HeartsTracker.Android.Classes
{
	[Application]
	public class App : Application
	{
		public static UnityContainer Container { get; set; }

		public App( IntPtr javaRef, JniHandleOwnership transfer ) : base( javaRef, transfer ) { }

		public override void OnCreate( )
		{
			base.OnCreate( );

			Container = new UnityContainer( );

			Container.RegisterInstance( RestService.For<IApi>( "http://192.168.1.72:54430" ) );
			Container.RegisterType<IPlayerDataSource, PlayerApiDataSource>("PlayerApiDataSource");
			Container.RegisterType<IGetPlayersCallback, PlayersViewCallback>( );
			Container.RegisterType<IGetPlayerCallback, PlayerViewCallback>( );
			Container.RegisterType<IAddPlayerCallback, AddPlayerViewCallback>( );
			Container.RegisterType<IPlayerDataSource, PlayerRepository>( new InjectionConstructor( new ResolvedParameter<PlayerApiDataSource>( "PlayerApiDataSource" ) ) );
		}
	}
}