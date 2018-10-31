using DataAccessLayer.DataModels;
using David_Mvvm_lib.ViewModels;
using David_Mvvm_lib.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Assignment_2b.ViewModels
{
  public class MainMenuViewModel : ViewModelBase
  {
    User _loggedInUser;
    public User LoggedInUser { get { return _loggedInUser; } set { _loggedInUser = value; OnPropertyChanged(nameof(LoggedInUser)); } }

    BlackJackGameViewModel _blackJackViewModel;
    public BlackJackGameViewModel BlackJackViewModel { get { return _blackJackViewModel; } set { _blackJackViewModel = value; OnPropertyChanged(nameof(BlackJackViewModel)); } }
    public LogInViewModel LogInViewModel { get; private set; }

    public int Players { get; set; }
    public int Decks { get; set; }

    bool _loggedIn;
    public bool LoggedIn { get { return _loggedIn; } set { _loggedIn = value; OnPropertyChanged(nameof(LoggedIn)); } }

    bool _loggedOut;
    public bool LoggedOut { get { return _loggedOut; } set { _loggedOut = value; OnPropertyChanged(nameof(LoggedOut)); } }

    public MainMenuViewModel()
    {
      LoggedIn = false;
      LoggedOut = true;

      BlackJackViewModel = new BlackJackGameViewModel();
      LogInViewModel = new LogInViewModel();

      LogInViewModel.LoggedInEvent += HandleLoggedIn;

      LogoutCommand = new ActionCommand(Logout);
      StartGameCommand = new ActionCommand(StartNewGame);
    }

    private void HandleLoggedIn(object sender, PlayerLoggedInEventArgs e)
    {
      BlackJackViewModel = new BlackJackGameViewModel(e.User.AvatarName);
      LoggedIn = true;
      LoggedOut = false;
      LoggedInUser = e.User;
    }

    public ICommand StartGameCommand { get; }

    public ICommand LogoutCommand { get; }

    void StartNewGame()
    {
      BlackJackViewModel.StartGame(Players, Decks, new PlayerViewModel(LoggedInUser.AvatarName));
    }

    void Logout()
    {//Change view to logIn
      LoggedOut = true;
      LoggedIn = false;
      Console.WriteLine("Logout");
    }



  }


}
