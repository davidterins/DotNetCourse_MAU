using David_Mvvm_lib.ViewModels;
using GameCardLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2b.Core.Agents
{
  public abstract class PlayingAgent : ViewModelBase, IPlayingAgent
  {
    int _score;
    public int Score { get { return _score; } set { _score = value; OnPropertyChanged(nameof(Score)); } }

    bool _hasTurn;
    public bool HasTurn { get { return _hasTurn; } set { _hasTurn = value; OnPropertyChanged(nameof(HasTurn)); } }

    Hand _hand;
    public Hand Hand { get { return _hand; } set { _hand = value; OnPropertyChanged(nameof(Hand)); } }

    protected bool _won;
    public bool Won { get { return _won; } private set { _won = value; } }

    public PlayingAgent()
    {
      Hand = new Hand(5);
    }

    public virtual void ResetScore()
    {
      Hand.Cards.Clear();
      Score = 0;
    }


    public event EventHandler<FinishTurnEventArgs> FinishTurnEvent;

    public void DoAction(PlayerAction agentAction)
    {
      FinishTurnEvent.Invoke(this, new FinishTurnEventArgs(agentAction));
      HasTurn = false;
    }

    public virtual void RecieveCard(BlackJackCard newCard)
    {
      newCard.Visible = true;
      Hand.Add(newCard);
      Score += newCard.Value;
    }

    public virtual void OnTurn()
    {
      HasTurn = true;
    }
  }

  public interface IPlayingAgent
  {
    event EventHandler<FinishTurnEventArgs> FinishTurnEvent;
    void DoAction(PlayerAction agentAction);
    void OnTurn();
  }

  public enum PlayerAction { Stand, Hit, Split, Double, Shuffle }

  public class FinishTurnEventArgs : EventArgs
  {
    public PlayerAction AgentAction { get; }

    public FinishTurnEventArgs(PlayerAction agentAction)
    {
      this.AgentAction = agentAction;
    }
  }
}
