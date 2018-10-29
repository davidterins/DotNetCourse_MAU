using GameCardLib.Agents;
using System;
using System.Collections.ObjectModel;
using David_Mvvm_lib.ViewModels;
using DataAccessLayer;



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

    CardGameStatusLogger _statusLogger;
    public CardGameStatusLogger StatusLogger { get { return _statusLogger; } } 

    bool _canMoveOn;
    public bool CanMoveOn { get { return _canMoveOn; } set { _canMoveOn = value; OnPropertyChanged(nameof(CanMoveOn)); } }

    public BlackJackGame()
    {
      _players = new ObservableCollection<BlackJackPlayer>();
      _dealer = new BlackJackDealer(5);
      _statusLogger = new CardGameStatusLogger();
      _dealer.AskNextPlayerEvent += Dealer_AskNextPlayer;

      //using (var unitOfWork = new DbUnitOfWork(new CasinoContext()))
      //{
        
      //}
    }

    private void Dealer_AskNextPlayer(object sender, DealerAnswerArgs e)
    {
      if(e.Answer == DealerAnswer.Next)
      {
        CanMoveOn = true;
      }
      else if (e.Answer == DealerAnswer.RemoveLoserAndNext)
      {
        StatusLogger.NewStatus(PlayerWithTurn.PlayerID + " Lost!", LogColor.Red);
        CanMoveOn = true;
      }
      else if(e.Answer == DealerAnswer.RemoveWinnerAndNext)
      {
        StatusLogger.NewStatus(PlayerWithTurn.PlayerID + " Won!" , LogColor.Green);
        CanMoveOn = true;
      }
      else if (e.Answer == DealerAnswer.Stay)
      {
        CanMoveOn = false;
      }
    }

    protected void NextTurn()
    {
      currentPlayerIndex++;
      if (currentPlayerIndex >= Players.Count)
      {//dealer should compare all scores here.
        StatusLogger.NewStatus("Every player has made their move", LogColor.Gray);
        _dealer.CompareScores(Players);
        foreach (BlackJackPlayer player in Players)
        {
          if (player.Won)
            StatusLogger.NewStatus(player.PlayerID + " Won with score: " + player.Score + "!", LogColor.Green);
          else
            StatusLogger.NewStatus(player.PlayerID + " Lost with score: " + player.Score + "!", LogColor.Red);

          
        }
       // NewRound();
      }
      else
      {
        PlayerWithTurn = Players[currentPlayerIndex];
        StatusLogger.NewStatus("Player with turn: " + PlayerWithTurn.PlayerID + " at seat: " + currentPlayerIndex, LogColor.Gray);
        Console.WriteLine("Current player index " + currentPlayerIndex);
      }
    }

    public void StartGame()
    {
      NewRound();
    }

    public void NewRound()
    {
      StatusLogger.NewStatus("Started a new round with " + Players.Count + " players!", LogColor.Yellow);
      currentPlayerIndex = 0;
      PlayerWithTurn = Players[currentPlayerIndex];
      foreach (BlackJackPlayer player in Players)
      {
        player.ResetScore();
        Dealer.DealPlayer(player, 2);
      }
      Dealer.NewRound();
    }

    private void PlayerMadeAChoice(object sender, FinishTurnEventArgs e)
    {
      _playerWithTurn = (BlackJackPlayer)sender;
      StatusLogger.NewStatus(_playerWithTurn.PlayerID + " made move: " + e.AgentAction.ToString(), LogColor.Gray);
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

