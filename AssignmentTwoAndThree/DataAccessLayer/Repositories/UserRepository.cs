using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DataModels;
using DataAccessLayer.Core;

namespace DataAccessLayer.Repositories
{
  public interface IUserRepository : IRepository<User>
  {

    bool UserExist(string emailOrName, string password);
    bool ValidLogInCredentials(string userName, string password);
    User Get(string userName);
    void AddCurrency(string userName, int amount);

    void Delete();
  }

  public class UserRepository : Repository<User>, IUserRepository
  {
    public UserRepository(CasinoContext context) : base(context)
    {

    }

    public User Get(string userName)
    {
      return CasinoContext.Users.Where(o => o.AvatarName == userName).SingleOrDefault();
    }

    public bool UserExist(string emailOrName, string password)
    {
      var s = CasinoContext.Users.Where(o => o.AvatarName == emailOrName && o.Password == password);

      return s.ToList().Any();
    }

    public bool ValidLogInCredentials(string userName, string password)
    {
      return CasinoContext.Users.Where(o => o.AvatarName == userName && o.Password == password).ToList().Any();
    }

    public void Delete()
    {
      CasinoContext.Database.Delete();
    }

    public void AddCurrency(string userName, int amount)
    {
      var s = (from usr in CasinoContext.Users
               where usr.AvatarName == userName
               select usr).FirstOrDefault();
      s.Avatar.GameCurrency += amount;
    }

    //public IEnumerable<User> GetUserNames()
    //{
    //    return CasinoContext.Users.Include(o => o.FirstName != string.Empty).ToList();
    //}

    public CasinoContext CasinoContext { get { return Context as CasinoContext; } }


  }
}
