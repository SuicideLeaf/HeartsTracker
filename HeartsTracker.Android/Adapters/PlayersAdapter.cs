using System;
using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using HeartsTracker.Core.Models.Player;

namespace HeartsTracker.Android.Adapters
{
	public class PlayersAdapter : RecyclerView.Adapter
	{
		private PlayerListViewModel _playerList;

		public EventHandler<int> PlayerClicked { get; set; }

		public PlayersAdapter( PlayerListViewModel playerList )
		{
			SetPlayers( playerList );
		}

		private Action<object, int> OnClick => ( obj, pos ) =>
		{
			PlayerClicked?.Invoke( obj, pos );
		};

		public override int ItemCount => _playerList.Players.Count;

		public override void OnBindViewHolder( RecyclerView.ViewHolder holder, int position )
		{
			PlayerListItemViewHolder vh = ( PlayerListItemViewHolder )holder;
			PlayerListItemViewModel playerListItem = _playerList.Players[ position ];

			vh.UpdateViews( playerListItem );
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder( ViewGroup parent, int viewType )
		{
			View view = LayoutInflater.From( parent.Context )
				.Inflate( Resource.Layout.players_listitem, parent, false );

			return new PlayerListItemViewHolder( view, OnClick );
		}

		public PlayerListItemViewModel GetPlayer( int position )
		{
			return _playerList.Players[ position ];
		}

		public void ReplaceData( PlayerListViewModel playerList )
		{
			SetPlayers( playerList );
			NotifyDataSetChanged( );
		}

		private void SetPlayers( PlayerListViewModel playerList )
		{
			_playerList = playerList;
		}
	}

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