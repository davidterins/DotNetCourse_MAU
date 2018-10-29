using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
  public interface IUserRepository : IRepository<User>
  {
    IEnumerable<User> GetUsersWithMoney();
  }

  public class UserRepository : Repository<User>, IUserRepository
  {
    public UserRepository(CasinoContext context) : base(context)
    {
      
    }

    public IEnumerable<User> GetUsersWithMoney()
    {
      return CasinoContext.Users.Find(o => o.Money > 0);
    }

    public CasinoContext CasinoContext { get { return Context as CasinoContext; } }
  }
}
