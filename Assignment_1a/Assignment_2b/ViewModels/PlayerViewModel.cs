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
    int _score;
    int _topCard;

    public Player Player { get { return _player; } }

		public PlayerViewModel(Player player)
		{
			_player = player;

			HitCommand = new ActionCommand(Hit);
      StandCommand = new ActionCommand(Stand);
      ShuffleCommand = new ActionCommand(RequestShuffle);
		}

    public ICommand ShuffleCommand { get; }
    public ICommand StandCommand { get; }
    public ICommand HitCommand { get; }

		public Hand PlayerHand { get { return _player.Hand; } }

		public string PlayerID { get { return _player.PlayerID; } }

    public int Score { get { return _player.Score; } }


		void Hit()
		{
			_player.FinishTurn(AgentAction.Hit, _isDealer);
		}

    void RequestShuffle()
    {
      _player.FinishTurn(AgentAction.Shuffle, _isDealer);
    }

    void Stand()
    {
      _player.FinishTurn(AgentAction.Stand, _isDealer);
    }
  }
}
