using System;
using System.Collections.Generic;
using InvestorBrowser.Repo.Models;

namespace InvestorBrowser.Repo.Repositories
{
    public interface IInvestorRepository
    {
        List<Investor> GetAllInvestors();
        Investor GetInvestor(int investorId);
        List<Investor> GetAllInvestorsBetweenDateCreatedRange(DateTime from, DateTime to);
    }
}