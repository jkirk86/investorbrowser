using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestorBrowser.Repo.Models
{
    public class Investor
    {
        public int InvestorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual List<Account> Accounts { get; set; } 
    }
}
