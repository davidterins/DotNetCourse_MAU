using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.DataModels
{
   public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public virtual string AvatarName { get; set; }
    }

    public class Avatar
    {
        public int AvatarId { get; set; }

        public string AvatarName { get; set; }
        public int GameCurrency { get; set; }
    }

    //public class CasinoContext : DbContext
    //{
    //    public DbSet<User> Users { get; set; }
    //    public DbSet<Avatar> Avatars { get; set; }

    //}


}
