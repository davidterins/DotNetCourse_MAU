using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DataModels;
using DataAccessLayer.Configurations;

namespace DataAccessLayer
{
    public class CasinoContext : DbContext
    {
        public CasinoContext() : base(/*"name=CasinoContext"*/)
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        //Will create the database automaticaly.
        public virtual DbSet<User> Users { get; set; }

        //Sets up all confiqs for the tables.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            //base.OnModelCreating(modelBuilder);
        }
    }
}
