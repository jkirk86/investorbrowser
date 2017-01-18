using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestorBrowser.Repo.EntityFramework;
using InvestorBrowser.Repo.Models;

namespace InvestorBrowser.Repo.Repositories
{
    public class InvestorRepository
    {
        private readonly InvestorBrowserContext _investorBrowserContext;

        public InvestorRepository(InvestorBrowserContext investorBrowserContext)
        {
            _investorBrowserContext = investorBrowserContext;
        }

        public List<Investor> GetAllInvestors()
        {
            return _investorBrowserContext.Investor.OrderByDescending(x => x.DateCreated).ToList();
        }

        public Investor GetInvestor(int investorId)
        {
            return _investorBrowserContext.Investor.Find(investorId);
        }

        public List<Investor> GetAllInvestorsBetweenDateCreatedRange(DateTime from, DateTime to)
        {
            return _investorBrowserContext.Investor.Where(x => x.DateCreated >= from && x.DateCreated <= to).OrderByDescending(x => x.DateCreated).ToList();
        }
    }
}
