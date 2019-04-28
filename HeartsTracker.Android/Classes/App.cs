using System;
using Android.App;
using Android.Runtime;
using HeartsTracker.Core.DataSources.Players;
using HeartsTracker.Core.Interfaces;
using Refit;
using Unity;

namespace HeartsTracker.Android.Classes
{
	[Application]
	public class App : Application
	{
		public static UnityContainer Container { get; set; }

		public App( IntPtr javaRef, JniHandleOwnership transfer ) : base( javaRef, transfer )
		{
		}

		public override void OnCreate( )
		{
			base.OnCreate( );

			Container = new UnityContainer( );

			Container.RegisterInstance( RestService.For<IApi>( "http://192.168.20.9:54430/" ) );
			Container.RegisterType<IPlayerDataSource, PlayerApiDataSource>( );
		}
	}
}