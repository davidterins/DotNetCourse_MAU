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
    [Key]
    public virtual string AvatarName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public Avatar Avatar {get; set;}


  }

  public class Avatar
  {
    //public int AvatarId { get; set; }
    public int GameCurrency { get; set; }
  }
}
