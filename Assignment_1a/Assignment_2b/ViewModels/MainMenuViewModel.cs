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

    public BlackJackGameViewModel BlackJackViewModel { get; private set; }
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
      StartGameCommand = BlackJackViewModel.NewGameCommand;

    }

    private void HandleLoggedIn(object sender, PlayerLoggedInEventArgs e)
    {
      LoggedIn = true;
      LoggedOut = false;
    }

    public ICommand StartGameCommand { get; }

    public ICommand LogoutCommand { get; }

    void Logout()
    {//Change view to logIn
      LoggedOut = true;
      LoggedIn = false;
      Console.WriteLine("Logout");
    }



  }


}
