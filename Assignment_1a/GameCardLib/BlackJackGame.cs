using GameCardLib.Agents;
using System;
using System.Collections.Generic;
using System.Text;
using David_Mvvm_lib;

namespace GameCardLib
{
  public class BlackJackGame
  {
    public Player _playerWithTurn { get; private set; }

    Dealer _dealer;
    public Dealer Dealer { get { return _dealer; } }

    List<Player> _players;
    public List<Player> Players { get { return _players; } set { _players = value; } }

    public BlackJackGame()
    {
      _dealer = new Dealer();
      _players = new List<Player>();

      _dealer.AskNextPlayerEvent += Dealer_AskNextPlayer;
    }


    int currentPlayerIndex;

    private void Dealer_AskNextPlayer(object sender, EventArgs e)
    {
      currentPlayerIndex++;
     
    }

    public void StartGame()
    {

      Console.WriteLine("StartedGame");
    }

    private void PlayerMadeAChoice(object sender, FinishTurnEventArgs e)
    {
      _playerWithTurn = (Player)sender;
      _dealer.AnswerPlayer(_playerWithTurn, e.AgentAction);

    }

    public void AddPlayingAgent(Player agent)
    {
      _players.Add(agent);
      agent.FinishTurnEvent += PlayerMadeAChoice;
      Console.WriteLine("Player joined game " + agent.PlayerID);
    }

    public void RemovePlayingAgent(Player agent)
    {
      agent.FinishTurnEvent -= PlayerMadeAChoice;
    }
  }


}

