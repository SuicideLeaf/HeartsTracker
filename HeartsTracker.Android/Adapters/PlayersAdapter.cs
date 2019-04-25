using System;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using HeartsTracker.Core.Models.Players;

namespace HeartsTracker.Android.Adapters
{
	public class PlayersAdapter : RecyclerView.Adapter
	{
		private readonly Context _context;
		private PlayerListViewModel _playerList;

		public EventHandler<int> PlayerClicked { get; set; }

		public PlayersAdapter( Context context )
		{
			_context = context;
			_playerList = new PlayerListViewModel( );
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

			return new PlayerListItemViewHolder( _context, view, OnClick );
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

		public void AddPlayerToList( PlayerListItemViewModel playerListItem )
		{
			_playerList.Players.Add( playerListItem );
			_playerList.SortByNameAsc( );

			NotifyDataSetChanged( );
		}

		private void SetPlayers( PlayerListViewModel playerList )
		{
			_playerList = playerList;
		}
	}
}