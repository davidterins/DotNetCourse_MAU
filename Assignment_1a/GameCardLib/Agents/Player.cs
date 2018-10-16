using System;
using System.Collections.Generic;
using System.Text;

namespace GameCardLib.Agents
{
    
    public class Player : PlayingAgent
    {
        public override void OnTurn()
        {
            HasTurn = true;
        }
    }

    public abstract class PlayingAgent : IPlayingAgent
    {
        public int Score;
        public bool HasTurn;

        public event EventHandler<FinishTurnEventArgs> FinishTurnEvent;

        public void FinishTurn(AgentAction agentAction, bool isDealer)
        {
            FinishTurnEvent.Invoke(this, new FinishTurnEventArgs(agentAction, isDealer));
            HasTurn = false;
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

    public enum AgentAction { Stand, Hit, Deal}

    public class FinishTurnEventArgs : EventArgs
    {
        AgentAction agentAction;

        public FinishTurnEventArgs(AgentAction agentAction, bool dealer)
        {
            this.agentAction = agentAction;
        }
    }

}
