using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using HeartsTracker.Android.Classes;
using HeartsTracker.Core.Classes;
using HeartsTracker.Core.Models.Players;
using HeartsTracker.Core.Presenters.Players;
using HeartsTracker.Core.Views.Players;
using Newtonsoft.Json;
using Unity;

namespace HeartsTracker.Android.Activities.Players
{
	[Activity( Label = "Add Player" )]
	public class AddPlayerActivity : BaseApiActivity<AddPlayerPresenter>, IAddPlayerView
	{
		private EditText _playerNameEditText;
		private EditText _firstNameEditText;
		private EditText _lastNameEditText;
		private Button _addButton;

		public override void RegisterView( )
		{
			App.Container.RegisterInstance<IAddPlayerView>( this );
		}

		protected override void OnCreate( Bundle savedInstanceState )
		{
			base.OnCreate( savedInstanceState );

			SetContentView( Resource.Layout.addplayer_activity );

			FindViews( );
			SetupViews( );

			SetPresenter( );
		}

		public void FindViews( )
		{
			_playerNameEditText = FindViewById<EditText>( Resource.Id.addplayer_edittext_playername );
			_firstNameEditText = FindViewById<EditText>( Resource.Id.addplayer_edittext_firstname );
			_lastNameEditText = FindViewById<EditText>( Resource.Id.addplayer_edittext_lastname );
			_addButton = FindViewById<Button>( Resource.Id.addplayer_button_add );
		}

		public void SetupViews( )
		{
			_addButton.Click += async ( s, e ) => { await AddButtonOnClick( ); };
		}

		private async Task AddButtonOnClick( )
		{
			await Presenter.AddPlayer( );
		}

		public override void ShowError( string error )
		{
			throw new NotImplementedException( );
		}

		public string PlayerName => _playerNameEditText.Text;
		public string LastName => _lastNameEditText.Text;
		public string FirstName => _firstNameEditText.Text;
		public string Colour => "#4ac06b";

		public void DisableSubmitButton( )
		{
			_addButton.Enabled = false;
		}

		public void EnableSubmitButton( )
		{
			_addButton.Enabled = true;
		}

		public void FinishActivity( PlayerListItemViewModel playerListItem )
		{
			Intent intent = new Intent( );
			intent.PutExtra( "PlayerListItem", JsonConvert.SerializeObject( playerListItem ) );
			SetResult( Result.Ok, intent );
			Finish( );
		}
	}
}