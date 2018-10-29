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
  public class PlayerViewModel : BlackJackPlayer
  {

    public PlayerViewModel(string _playerID) : base(_playerID)
    {
      HitCommand = new ActionCommand(Hit);
      StandCommand = new ActionCommand(Stand);
      ShuffleCommand = new ActionCommand(RequestShuffle);
      SplitCommand = new ActionCommand(Split);
      DoubleCommand = new ActionCommand(Double);
    }

    public ICommand ShuffleCommand { get; }
    public ICommand StandCommand { get; }
    public ICommand HitCommand { get; }
    public ICommand SplitCommand { get; }
    public ICommand DoubleCommand { get; }

    void Hit()
    {
      DoAction(PlayerAction.Hit);
    }

    void RequestShuffle()
    {
      DoAction(PlayerAction.Shuffle);
    }

    void Stand()
    {
      IsInGame = false;
      DoAction(PlayerAction.Stand);
    }

    void Split()
    {
      DoAction(PlayerAction.Split);
    }

    void Double()
    {
      DoAction(PlayerAction.Double);
    }
  }
}
