using System;
using Android.Content;
using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using HeartsTracker.Android.Extensions;
using HeartsTracker.Core.Models.Players;

namespace HeartsTracker.Android.Adapters
{
	public class PlayerListItemViewHolder : RecyclerView.ViewHolder
	{
		private readonly Context _context;
		private readonly TextView _playerName;
		private readonly View _colourCircle;

		public PlayerListItemViewHolder( Context context, View view, Action<object, int> onClick )
			: base( view )
		{
			_context = context;
			_playerName = view.FindViewById<TextView>( Resource.Id.players_listitem_textview_name );
			_colourCircle = view.FindViewById<View>( Resource.Id.players_listitem_view_colour );

			view.Click += ( s, e ) => { onClick( s, AdapterPosition ); };
		}

		public void UpdateViews( PlayerListItemViewModel playerListItem )
		{
			_colourCircle.ToCircle( Color.ParseColor( playerListItem.Colour ) );
			_playerName.Text = playerListItem.PlayerName;
		}
	}
}