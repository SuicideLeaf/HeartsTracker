using System;
using Android.Support.V7.Widget;
using Android.Views;
using HeartsTracker.Core.Models.Players;

namespace HeartsTracker.Android.Adapters
{
	public class PlayersAdapter : RecyclerView.Adapter
	{
		private PlayerList _playerList;

		public EventHandler<int> PlayerClicked { get; set; }

		public PlayersAdapter( )
		{
			_playerList = new PlayerList( );
		}

		private Action<object, int> OnClick => ( obj, pos ) =>
		{
			PlayerClicked?.Invoke( obj, pos );
		};

		public override int ItemCount => _playerList.Players.Count;

		public override void OnBindViewHolder( RecyclerView.ViewHolder holder, int position )
		{
			PlayerListItemViewHolder vh = ( PlayerListItemViewHolder )holder;
			PlayerListItem playerListItem = _playerList.Players[ position ];

			vh.UpdateViews( playerListItem );
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder( ViewGroup parent, int viewType )
		{
			View view = LayoutInflater.From( parent.Context )
				.Inflate( Resource.Layout.players_listitem, parent, false );

			return new PlayerListItemViewHolder( view, OnClick );
		}

		public PlayerListItem GetPlayer( int position )
		{
			return _playerList.Players[ position ];
		}

		public void ReplaceData( PlayerList playerList )
		{
			SetPlayers( playerList );
			NotifyDataSetChanged( );
		}

		public void AddPlayerToList( PlayerListItem playerListItem )
		{
			_playerList.Players.Add( playerListItem );
			_playerList.SortPlayers( );
			NotifyDataSetChanged( );
		}

		private void SetPlayers( PlayerList playerList )
		{
			_playerList = playerList;
		}
	}
}