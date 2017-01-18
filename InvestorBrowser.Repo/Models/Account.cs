using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestorBrowser.Repo.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public int InvestorId { get; set; }
        public Decimal AmountHeld { get; set; }
        public string Type { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual Investor Investor { get; set; }
    }
}
