using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
  public interface IUnitOfWork : IDisposable
  {
    IUserRepository Users { get; }

    //Save
    int Complete();
  }


  /// <summary>
  /// Is specific per application
  /// </summary>
  public class DbUnitOfWork : IUnitOfWork
  {
    private readonly CasinoContext _casinoContext;

    public DbUnitOfWork(CasinoContext casinoContext)
    {
      _casinoContext = casinoContext;
      Users = new UserRepository(_casinoContext);
    }

    public IUserRepository Users { get; }

    public int Complete()
    {
      return _casinoContext.SaveChanges();
    }

    public void Dispose()
    {
      _casinoContext.Dispose();
    }

  }

  public class CasinoContext : DbContext
  {
     public IUserRepository Users { get; }
  }

  public class User
  {
    public string FirstName { get; }

    public string LastName { get; }

    public string AvatarName { get; }

    public int Money { get; }

  }
}
