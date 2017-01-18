using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InvestorBrowser.Models
{
    public class InvestorViewModel
    {
        public int InvestorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
               ApplyFormatInEditMode = true)]
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }
        public virtual List<AccountViewModel> Accounts { get; set; }

        //View Related Properties
        [Display(Name = "Investor Name")]
        public string FullName => Name + " " + Surname;
        [Display(Name = "Accounts Held")]
        public int NumberOfAccounts => Accounts.Count();
        [DisplayFormat(DataFormatString = "{0:C0}")]
        [Display(Name = "Accounts Total")]
        public Decimal AccountsTotal => Accounts.Sum(x => x.AmountHeld);
    }
}