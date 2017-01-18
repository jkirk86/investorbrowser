using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestorBrowser.Repo.Models;

namespace InvestorBrowser.Repo.EntityFramework
{
    class AccountConfiguration : EntityTypeConfiguration<Account>
    {
        public AccountConfiguration()
        {
            HasKey(x => x.AccountId).HasRequired(x => x.Investor);
        }
    }
}
