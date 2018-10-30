using David_Mvvm_lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DataModels;
using DataAccessLayer.Repositories;
using DataAccessLayer;
using System.Windows.Input;
using David_Mvvm_lib.ViewModels.Commands;

namespace Assignment_2b.ViewModels
{
    public class LobbyViewModel : ViewModelBase
    {
        User _user;

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }

        public LobbyViewModel()
        {
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
                unitOfWork.Users.UserExist(UserName, Password);
            }
        }


    }
}
