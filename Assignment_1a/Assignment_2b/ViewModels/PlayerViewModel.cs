using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCardLib.Agents;
using System.Windows.Input;
using GameCardLib;
using David_Mvvm_lib.ViewModels.Commands;
using System.Collections.ObjectModel;
using David_Mvvm_lib.ViewModels;

namespace Assignment_2b.ViewModels
{
	public class PlayerViewModel : ViewModelBase
	{
		Player _player;
		
		bool _isDealer;

		int _topCard;

		public PlayerViewModel(Player player)
		{
			_player = player;

			HitCommand = new ActionCommand(Hit);
		}

		public ICommand HitCommand { get; }

		public Hand PlayerHand { get { return _player.Hand; } }

		public string PlayerID { get { return _player.PlayerID; } }

		//public bool TopCard { get { return _topCard; } set { _topCard = value; } }

		void RecieveCard(Card newCard)
		{
			newCard.Visible = true;
			PlayerHand.Add(newCard);
		}

		void Hit()
		{
			_player.FinishTurn(AgentAction.Hit, _isDealer);
			Console.WriteLine("Player Hit");
		}
	}
}
