using System;
using GameCardLib;
using System.Windows.Input;
using David_Mvvm_lib.ViewModels.Commands;
using DataAccessLayer;
using DataAccessLayer.DataModels;
using System.Collections.ObjectModel;
using David_Mvvm_lib.ViewModels;
using Assignment_2b.Core.Agents;

namespace Assignment_2b.ViewModels
{
  public class BlackJackGameViewModel : ViewModelBase
  {
    int currentPlayerIndex;

    BlackJackDealer _dealer;
    public BlackJackDealer Dealer { get { return _dealer; } set { _dealer = value; OnPropertyChanged(nameof(Dealer)); } }

    PlayerViewModel _playerWithTurn;
    public PlayerViewModel PlayerWithTurn { get { return _playerWithTurn; } set { _playerWithTurn = value; OnPropertyChanged(nameof(PlayerWithTurn)); } }

    ObservableCollection<PlayerViewModel> _players;
    public ObservableCollection<PlayerViewModel> Players { get { return _players; } set { _players = value; } }

    CardGameStatusLogger _statusLogger;
    public CardGameStatusLogger StatusLogger { get { return _statusLogger; } }

    int _currencyAmount;
    public int CurrentCurencyAmount { get { return _currencyAmount; } set { _currencyAmount = value; OnPropertyChanged(nameof(CurrentCurencyAmount)); } }

    string _currentPlayerName;
    public string CurrentPlayerName { get { return _currentPlayerName; } set { _currentPlayerName = value; OnPropertyChanged(nameof(CurrentPlayerName)); } }

    bool _canMoveOn;
    public bool CanMoveOn { get { return _canMoveOn; } set { _canMoveOn = value; OnPropertyChanged(nameof(CanMoveOn)); } }

    public ICommand NextPlayerCommand { get; }

    public BlackJackGameViewModel()
    {
      NextPlayerCommand = new ActionCommand(NextTurn);
      _players = new ObservableCollection<PlayerViewModel>();
      _statusLogger = new CardGameStatusLogger();
    }

    public BlackJackGameViewModel(string userName)
    {
      CurrentPlayerName = userName;
      using (var unitOfWork = new CasinoUnitOfWork(new CasinoContext()))
      {
        CurrentCurencyAmount = unitOfWork.Users.Get(userName).Avatar.GameCurrency;
        unitOfWork.Complete();
      }


      NextPlayerCommand = new ActionCommand(NextTurn);
      _players = new ObservableCollection<PlayerViewModel>();
      _statusLogger = new CardGameStatusLogger();
    }

    private void Dealer_AskNextPlayer(object sender, DealerAnswerArgs e)
    {
      if (e.Answer == DealerAnswer.Next)
      {
        CanMoveOn = true;
      }
      else if (e.Answer == DealerAnswer.RemoveLoserAndNext)
      {
        StatusLogger.NewStatus(PlayerWithTurn.PlayerID + " Lost!", LogColor.Red);
        CanMoveOn = true;
      }
      else if (e.Answer == DealerAnswer.RemoveWinnerAndNext)
      {
        StatusLogger.NewStatus(PlayerWithTurn.PlayerID + " Won!", LogColor.Green);
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
        var loggedInPlayer = Players[0];
        if (loggedInPlayer.Won)
        {
          using (var unitOfWork = new CasinoUnitOfWork(new CasinoContext()))
          {
            unitOfWork.Users.AddCurrency(loggedInPlayer.PlayerID, 10);
            unitOfWork.Complete();

            CurrentCurencyAmount = unitOfWork.Users.Get(loggedInPlayer.PlayerID).Avatar.GameCurrency;
            unitOfWork.Complete();
          }
        }

        foreach (PlayerViewModel player in Players)
        {
          if (player.Won)
            StatusLogger.NewStatus(player.PlayerID + " Won with score: " + player.Score + "!", LogColor.Green);
          else
            StatusLogger.NewStatus(player.PlayerID + " Lost with score: " + player.Score + "!", LogColor.Red);
        }
        CanMoveOn = false;
      }
      else
      {
        PlayerWithTurn = Players[currentPlayerIndex];
        StatusLogger.NewStatus("Player with turn: " + PlayerWithTurn.PlayerID + " at seat: " + currentPlayerIndex, LogColor.Gray);
        Console.WriteLine("Current player index " + currentPlayerIndex);
      }
    }

    public void StartGame(int numberOfPlayers, int numberOfDecks, PlayerViewModel loggedInPlayer)
    {
      Dealer = new BlackJackDealer(numberOfDecks);
      _dealer.AskNextPlayerEvent += Dealer_AskNextPlayer;

      Players = new ObservableCollection<PlayerViewModel>();

      foreach (PlayerViewModel player in Players)
      {//Clearing up delegates.
        RemovePlayingAgent(player);
      }

      AddPlayingAgent(loggedInPlayer);
      for (int i = 0; i < numberOfPlayers - 1; i++)
      {
        AddPlayingAgent(new PlayerViewModel("RandomBlackJackPlayer " + (i + 1).ToString()));
      }

      CurrentPlayerName = loggedInPlayer.PlayerID;

      NewRound();
    }

    public void NewRound()
    {
      StatusLogger.NewStatus("Started a new round with " + Players.Count + " players!", LogColor.Yellow);
      currentPlayerIndex = 0;
      PlayerWithTurn = Players[currentPlayerIndex];
      foreach (PlayerViewModel player in Players)
      {
        player.ResetScore();
        Dealer.DealPlayer(player, 2);
      }
      Dealer.NewRound();
    }

    private void PlayerMadeAChoice(object sender, FinishTurnEventArgs e)
    {
      _playerWithTurn = (PlayerViewModel)sender;
      StatusLogger.NewStatus(_playerWithTurn.PlayerID + " made move: " + e.AgentAction.ToString(), LogColor.Gray);
      _dealer.AnswerPlayer(_playerWithTurn, e.AgentAction);
    }

    protected void AddPlayingAgent(PlayerViewModel agent)
    {
      _players.Add(agent);
      agent.FinishTurnEvent += PlayerMadeAChoice;
      Console.WriteLine("Player joined game " + agent.PlayerID);
    }

    protected void RemovePlayingAgent(PlayerViewModel agent)
    {
      agent.FinishTurnEvent -= PlayerMadeAChoice;
      Players.Remove(agent);
    }
  }
}





