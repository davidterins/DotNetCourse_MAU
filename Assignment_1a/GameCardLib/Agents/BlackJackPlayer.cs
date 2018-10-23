using System;
using System.Collections.Generic;
using System.Text;
using David_Mvvm_lib.ViewModels;

namespace GameCardLib.Agents
{

  public class BlackJackPlayer : PlayingAgent
  {

    public string PlayerID { get; }
    bool _isInGame = true;
    public bool IsInGame { get { return _isInGame; } set { _isInGame = value; OnPropertyChanged(nameof(IsInGame)); } }

    public BlackJackPlayer(string playerID) : base()
    {
      PlayerID = playerID;
    }

    public override void ResetScore()
    {
      base.ResetScore();
      IsInGame = true;
    }

    public void Won()
    {
      IsInGame = false;
    }
    public void Lost()
    {
      IsInGame = false;
    }
   
  }

  public abstract class PlayingAgent : ViewModelBase, IPlayingAgent
  {
    int _score;
    public int Score { get { return _score; } set { _score = value; OnPropertyChanged(nameof(Score)); } }

    bool _hasTurn;
    public bool HasTurn { get { return _hasTurn; } set { _hasTurn = value; OnPropertyChanged(nameof(HasTurn)); } }

    Hand _hand;
    public Hand Hand { get { return _hand; } set { _hand = value; OnPropertyChanged(nameof(Hand)); } }

   
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

    public virtual void RecieveCard(Card newCard)
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
