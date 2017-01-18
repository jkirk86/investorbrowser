using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using InvestorBrowser.Models;
using InvestorBrowser.Repo.Models;

namespace InvestorBrowser.App_Start
{
    public class AutoMapperConfig
    {
        public static void Configure(IMapperConfiguration cfg)
        {
            cfg.CreateMap<Investor, InvestorViewModel>().ReverseMap();
            cfg.CreateMap<Account, AccountViewModel>().ReverseMap();
        }
    }
}