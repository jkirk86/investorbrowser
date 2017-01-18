using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestorBrowser.Repo.Models;

namespace InvestorBrowser.Repo.EntityFramework
{
    class InvestorConfiguration : EntityTypeConfiguration<Investor>
    {
        public InvestorConfiguration()
        {
            HasKey(x => x.InvestorId).HasMany(x => x.Accounts);
        }
    }
}
