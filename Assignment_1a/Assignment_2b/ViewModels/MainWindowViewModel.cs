using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCardLib;
using System.Windows.Input;
using David_Mvvm_lib.ViewModels.Commands;
using GameCardLib.Agents;
using System.Collections.ObjectModel;

namespace Assignment_2b.ViewModels
{
  public class MainWindowViewModel : David_Mvvm_lib.ViewModels.ViewModelBase
  {
    BlackJackGame _blackJackgame;
    public BlackJackGame BlackJackGame { get { return _blackJackgame; } }

    int _playerWithTurnIndex;

    PlayerViewModel _playerWithTurn;
    public PlayerViewModel PlayerWithTurn { get { return  _playerWithTurn; } set { _playerWithTurn = value; OnPropertyChanged(nameof(PlayerWithTurn)); } }

    ObservableCollection<PlayerViewModel> _playerVMCollection;
    public ObservableCollection<PlayerViewModel> PlayerVMCollection { get { return _playerVMCollection; } set { _playerVMCollection = value; } }

    public DealerViewModel DealerVM { get; }

    public MainWindowViewModel()
    {
      _playerVMCollection = new ObservableCollection<PlayerViewModel>();
      _blackJackgame = new BlackJackGame();

      Player p1 = new Player("Pedro");
      Player p2 = new Player("Lasse");
      Player p3 = new Player("Sharqeisha");
      Player p4 = new Player("Latifa");



      _blackJackgame.AddPlayingAgent(p1);
      _blackJackgame.AddPlayingAgent(p2);
      _blackJackgame.AddPlayingAgent(p3);
      _blackJackgame.AddPlayingAgent(p4);

      _blackJackgame.Dealer.AskNextPlayerEvent += Dealer_AskNextPlayerEvent;

      DealerVM = new DealerViewModel(_blackJackgame.Dealer);

      NewGameCommand = new ActionCommand(StartNewGame);
    }

    private void Dealer_AskNextPlayerEvent(object sender, EventArgs e)
    {
      //if (_playerWithTurnIndex == player)
        PlayerWithTurn = PlayerVMCollection[_playerWithTurnIndex++];
    }

    public ICommand NewGameCommand { get; }


    void StartNewGame()
    {
      if (_blackJackgame.Players.Count > 0)
      {
        //Add All players to the table
        foreach (Player p in _blackJackgame.Players)
        {
          PlayerVMCollection.Add(new PlayerViewModel(p));
        }

        PlayerWithTurn = PlayerVMCollection[_playerWithTurnIndex];
       
        DealerVM.Deal(PlayerVMCollection.ToList(), 2);
 
        _blackJackgame.StartGame();
      }


    }

  }
}
