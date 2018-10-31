using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repositories;

namespace DataAccessLayer
{
    /// <summary>
    /// Is specific per application
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }

        //Save
        int Complete();
    }

    /// <summary>
    /// Is specific per application
    /// </summary>
    public class CasinoUnitOfWork : IUnitOfWork
    {
        private readonly CasinoContext _casinoContext;

        public CasinoUnitOfWork(CasinoContext casinoContext)
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
}
