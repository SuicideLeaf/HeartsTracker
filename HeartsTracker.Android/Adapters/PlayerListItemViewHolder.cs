using System;
using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using HeartsTracker.Core.Models.Players;

namespace HeartsTracker.Android.Adapters
{
	public class PlayerListItemViewHolder : RecyclerView.ViewHolder
	{
		private readonly TextView _playerName;
		private readonly View _colourView;

		public PlayerListItemViewHolder( View view, Action<object, int> onClick )
			: base( view )
		{
			view.Click += ( s, e ) => { onClick( s, AdapterPosition ); };

			_playerName = view.FindViewById<TextView>( Resource.Id.players_listitem_textview_name );
			_colourView = view.FindViewById<View>( Resource.Id.players_listitem_view_colour );
		}

		public void UpdateViews( PlayerListItemViewModel playerListItem )
		{
			_colourView.SetBackgroundColor( Color.ParseColor( playerListItem.Colour ) );
			_playerName.Text = playerListItem.PlayerName;
		}
	}
}