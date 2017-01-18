using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestorBrowser.Repo.Models;

namespace InvestorBrowser.Repo.EntityFramework
{
    public class InvestorBrowserContext : DbContext
    {
        public DbSet<Account> Account { get; set; }

        public DbSet<Investor> Investor { get; set; }

        public InvestorBrowserContext() : base("Name=CleverConnectionString")
        {
            Database.SetInitializer<EntityFramework.InvestorBrowserContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new InvestorConfiguration());
            modelBuilder.Configurations.Add(new AccountConfiguration());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
