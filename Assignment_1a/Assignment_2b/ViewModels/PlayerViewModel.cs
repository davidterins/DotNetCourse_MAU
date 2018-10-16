using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCardLib.Agents;
using System.Windows.Input;
using GameCardLib;
using David_Mvvm_lib.ViewModels.Commands;

namespace Assignment_2b.ViewModels
{
	public class PlayerViewModel : David_Mvvm_lib.ViewModels.ViewModelBase
	{
		Player _player;
		
		bool _isDealer;



		public PlayerViewModel(Player _player)
		{
			this._player = _player;
			HitCommand = new ActionCommand(Hit);
		}

		public ICommand HitCommand { get; }

		public Hand PlayerHand { get { return _player.Hand; } }


		void Hit()
		{
			_player.FinishTurn(AgentAction.Hit, _isDealer);
			Console.WriteLine("Player Hit");
		}
	}
}
