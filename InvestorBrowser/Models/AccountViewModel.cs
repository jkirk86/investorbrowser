using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InvestorBrowser.Models
{
    public class AccountViewModel
    {
        public int AccountId { get; set; }
        public int InvestorId { get; set; }
        [DataType(DataType.Currency)]
        public Decimal AmountHeld { get; set; }
        public string Type { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
       ApplyFormatInEditMode = true)]
        public DateTime DateCreated { get; set; }
        public virtual InvestorViewModel Investor { get; set; }
    }
}