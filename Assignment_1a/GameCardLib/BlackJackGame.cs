using GameCardLib.Agents;
using System;
using System.Collections.ObjectModel;
using David_Mvvm_lib.ViewModels;

namespace GameCardLib
{
  public class BlackJackGame : ViewModelBase
  {
    int currentPlayerIndex;

    BlackJackDealer _dealer;
    public BlackJackDealer Dealer { get { return _dealer; } }

    BlackJackPlayer _playerWithTurn;
    public BlackJackPlayer PlayerWithTurn { get { return _playerWithTurn; } set { _playerWithTurn = value; OnPropertyChanged(nameof(PlayerWithTurn)); } }

    ObservableCollection<BlackJackPlayer> _players;
    public ObservableCollection<BlackJackPlayer> Players { get { return _players; } set { _players = value; } }

    public BlackJackGame()
    {
      _players = new ObservableCollection<BlackJackPlayer>();
      _dealer = new BlackJackDealer();
      _dealer.AskNextPlayerEvent += Dealer_AskNextPlayer;
    }

    private void Dealer_AskNextPlayer(object sender, EventArgs e)
    {
      currentPlayerIndex++;

      if (currentPlayerIndex > Players.Count)
      {//dealer should compare all scores here.
        NewRound();
      }
      else
      {
        PlayerWithTurn = Players[currentPlayerIndex];
        Console.WriteLine("Current player index " + currentPlayerIndex);
      }
    }

    public void StartGame()
    {
      Console.WriteLine("StartedGame");
      NewRound();
    }

    public void NewRound()
    {
      Console.WriteLine("New Round");
      currentPlayerIndex = 0;
      PlayerWithTurn = Players[currentPlayerIndex];
      foreach (BlackJackPlayer player in Players)
      {
        player.Hand = Dealer.DealNewHand(5, 2);
      }
    }

    private void PlayerMadeAChoice(object sender, FinishTurnEventArgs e)
    {
      _playerWithTurn = (BlackJackPlayer)sender;
      _dealer.AnswerPlayer(_playerWithTurn, e.AgentAction);
    }

    protected void AddPlayingAgent(BlackJackPlayer agent)
    {
      _players.Add(agent);
      agent.FinishTurnEvent += PlayerMadeAChoice;
      Console.WriteLine("Player joined game " + agent.PlayerID);
    }

    protected void RemovePlayingAgent(BlackJackPlayer agent)
    {
      agent.FinishTurnEvent -= PlayerMadeAChoice;
    }
  }


}

