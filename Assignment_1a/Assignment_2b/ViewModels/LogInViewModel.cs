using David_Mvvm_lib.ViewModels;
using DataAccessLayer.DataModels;
using DataAccessLayer.Repositories;
using DataAccessLayer;
using System.Windows.Input;
using David_Mvvm_lib.ViewModels.Commands;
using System.Threading.Tasks;
using System;

namespace Assignment_2b.ViewModels
{
  public class LogInViewModel : ViewModelBase
  {
    public event EventHandler<PlayerLoggedInEventArgs> LoggedInEvent;

    User _user;

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Password { get; set; }

    string _userName;
    public string UserName { get { return _userName; } set { _userName = value; OnPropertyChanged(nameof(UserName)); } }

    public string NewPassword { get; set; }

    string _newUserName;
    public string NewUserName { get { return _newUserName; } set { _newUserName = value; OnPropertyChanged(nameof(NewUserName)); } }

    public LogInViewModel()
    {
      
      LoginCommand = new ActionCommand(LogIn);
      SignUpCommand = new ActionCommand(SignUp);
      DeleteDBCommand = new ActionCommand(DeleteDB);
    }

    private void SignUp()
    {
      _user = new User()
      {
        FirstName = this.FirstName,
        LastName = this.LastName,
        Password = NewPassword,
        AvatarName = _newUserName,
        Avatar = new Avatar()
      };

      using (var unitOfWork = new CasinoUnitOfWork(new CasinoContext()))
      {
        unitOfWork.Users.Add(_user);
        unitOfWork.Complete();
      }

    }

    public ICommand DeleteDBCommand { get; }

    public ICommand SignUpCommand { get; }

    public ICommand LoginCommand { get; }

    private void DeleteDB()
    {
      using (var unitOfWork = new CasinoUnitOfWork(new CasinoContext()))
      {
        unitOfWork.Users.Delete();
        unitOfWork.Complete(); 
      }
    }

    private async void LogIn()
    {

      Console.WriteLine("Attempt to log in");

      using (var unitOfWork = new CasinoUnitOfWork(new CasinoContext()))
      {
        string userName = UserName;

        var logInSuccessFull = await Task.Run(() => unitOfWork.Users.ValidLogInCredentials(userName, Password));

        unitOfWork.Complete();

        if (logInSuccessFull)
        {
          var user = unitOfWork.Users.Get(userName);
          unitOfWork.Complete();
          LoggedInEvent.Invoke(this, new PlayerLoggedInEventArgs(user));
        }


      }
    }
  }

  public class PlayerLoggedInEventArgs : EventArgs
  {
    public User User { get; }

    public PlayerLoggedInEventArgs(User user)
    {
      User = user;
    }
  }

}
