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

    public LogInViewModel()
    {
      UserName = "DTee";
      
      LoginCommand = new ActionCommand(LogIn);
    }

    private void SignUp()
    {
      _user = new User()
      {
        FirstName = this.FirstName,
        LastName = this.LastName,
        Password = this.Password,
        AvatarName = this.UserName
      };
    }

    public ICommand LoginCommand { get; }

    private void LogIn()
    {
      
      using (var unitOfWork = new CasinoUnitOfWork(new CasinoContext()))
      {
        if(unitOfWork.Users.UserExist(UserName, Password));
        {
          var user = unitOfWork.Users.Get(1);
          LoggedInEvent.Invoke(this,  new PlayerLoggedInEventArgs(user));
        }
        unitOfWork.Complete();
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
