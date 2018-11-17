using Android.Content;
using Android.Runtime;
using Android.Support.Constraints;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace HeartsTracker.Android.Views
{
	[Register( "com.hopelessleaf.heartstracker.GamePlayerView" )]
	public class GamePlayerView : ConstraintLayout
	{
		private TextView _playerNameTextView;
		private TextView _playerTotalTextView;
		private ImageView _playerStatusImageView;
		private EditText _playerRoundScoreEditText;

		public GamePlayerView( Context context, IAttributeSet attrs ) :
			base( context, attrs )
		{
			Initialize( context );
		}

		public GamePlayerView( Context context, IAttributeSet attrs, int defStyle ) :
			base( context, attrs, defStyle )
		{
			Initialize( context );
		}

		private void Initialize( Context context )
		{
			LayoutInflater inflater = LayoutInflater.From( context );
			inflater.Inflate( Resource.Layout.layout_game_player, this, true );

			FindViews( );
		}

		private void FindViews( )
		{
			_playerNameTextView = FindViewById<TextView>( Resource.Id.gameplayer_textview_name );
			_playerTotalTextView = FindViewById<TextView>( Resource.Id.gameplayer_textview_total );
			_playerStatusImageView = FindViewById<ImageView>( Resource.Id.gameplayer_imageview_status );
			_playerRoundScoreEditText = FindViewById<EditText>( Resource.Id.gameplayer_edittext_roundscore );
		}
	}
}