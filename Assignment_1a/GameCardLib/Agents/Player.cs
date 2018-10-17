using System;
using System.Collections.Generic;
using System.Text;
using David_Mvvm_lib.ViewModels;

namespace GameCardLib.Agents
{

  public class Player : PlayingAgent
  {
    public string PlayerID { get; }
    public Player(string playerID) : base()
    {
      PlayerID = playerID;
    }

    public override void OnTurn()
    {
      HasTurn = true;
    }
  }

  public abstract class PlayingAgent : ViewModelBase, IPlayingAgent
  {
    int _score;
    public int Score { get { return _score; } set { _score = value; OnPropertyChanged(nameof(Score)); } }
    public bool HasTurn;

    public Hand Hand { get; }

    public PlayingAgent()
    {
      Hand = new Hand(5);
    }

    public event EventHandler<FinishTurnEventArgs> FinishTurnEvent;

    public void FinishTurn(AgentAction agentAction, bool isDealer)
    {
      if (!isDealer)
      {
        FinishTurnEvent.Invoke(this, new FinishTurnEventArgs(agentAction, isDealer));
        HasTurn = false;
      }
    }

    public void RecieveCard(Card newCard)
    {
      newCard.Visible = true;
      Score += newCard.Value;
      Hand.Add(newCard);
    }

    public virtual void OnTurn()
    {
      HasTurn = true;
    }
  }

  public interface IPlayingAgent
  {
    event EventHandler<FinishTurnEventArgs> FinishTurnEvent;
    void FinishTurn(AgentAction agentAction, bool isDealer);
    void OnTurn();
  }

  public enum DealerAction { DealOne, DealAll };

  public enum AgentAction { Stand, Hit, Split, Shuffle }

  public class FinishTurnEventArgs : EventArgs
  {
    public AgentAction AgentAction { get; }

    public FinishTurnEventArgs(AgentAction agentAction, bool dealer)
    {
      this.AgentAction = agentAction;
    }
  }

}
