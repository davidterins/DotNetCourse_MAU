using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DataModels;
using System.Data.Entity.ModelConfiguration;

namespace DataAccessLayer.Configurations
{
    class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            Property(u => u.UserId).IsRequired();

            Property(u => u.FirstName).HasMaxLength(50);

            Property(u => u.LastName).HasMaxLength(50);

            Property(u => u.Password).HasMaxLength(50);

            Property(u => u.AvatarName).HasMaxLength(50);
        }
    }
}
