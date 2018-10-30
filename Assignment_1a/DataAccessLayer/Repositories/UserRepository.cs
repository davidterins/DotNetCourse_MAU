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
        User GetUserNames();
        bool UserExist(string emailOrName, string password);
    }

    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(CasinoContext context) : base(context)
        {

        }

        public User GetUserNames()
        {

            var s = CasinoContext.Users.Where(o => o.UserId == 1).ToList();

            return s[0];
        }

        public bool UserExist(string emailOrName, string password)
        {
            var s = CasinoContext.Users.Where(o => o.AvatarName == emailOrName && o.Password == password);
            return s.ToList().Any();
        }
        //public IEnumerable<User> GetUserNames()
        //{
        //    return CasinoContext.Users.Include(o => o.FirstName != string.Empty).ToList();
        //}

        public CasinoContext CasinoContext { get { return Context as CasinoContext; } }


    }
}
