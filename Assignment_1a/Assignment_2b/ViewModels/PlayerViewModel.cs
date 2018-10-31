
using System.Windows.Input;
using GameCardLib;
using David_Mvvm_lib.ViewModels.Commands;
using System.Collections.ObjectModel;
using David_Mvvm_lib.ViewModels;
using Assignment_2b.Core.Agents;

namespace Assignment_2b.ViewModels
{
  public class PlayerViewModel : PlayingAgent
  {

    public string PlayerID { get; }
    bool _isInGame = true;
    public bool IsInGame { get { return _isInGame; } set { _isInGame = value; OnPropertyChanged(nameof(IsInGame)); } }


    public ICommand ShuffleCommand { get; }
    public ICommand StandCommand { get; }
    public ICommand HitCommand { get; }
    public ICommand SplitCommand { get; }
    public ICommand DoubleCommand { get; }

    public PlayerViewModel(string _playerID) : base()
    {
      PlayerID = _playerID;
      HitCommand = new ActionCommand(Hit);
      StandCommand = new ActionCommand(Stand);
      ShuffleCommand = new ActionCommand(RequestShuffle);
      SplitCommand = new ActionCommand(Split);
      DoubleCommand = new ActionCommand(Double);
    }

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

    public override void ResetScore()
    {
      base.ResetScore();
      IsInGame = true;
    }

    public void AgentWon()
    {
      IsInGame = false;
      _won = true;
    }
    public void AgentLost()
    {
      IsInGame = false;
      _won = false;
    }


  }
}
