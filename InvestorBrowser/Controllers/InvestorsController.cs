using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using InvestorBrowser.Models;
using InvestorBrowser.Repo.EntityFramework;
using InvestorBrowser.Repo.Models;
using InvestorBrowser.Repo.Repositories;

namespace InvestorBrowser.Controllers
{
    public class InvestorsController : Controller
    {
        private readonly InvestorRepository _investorRepository;
        private readonly IMapper _mapper;

        public InvestorsController(InvestorRepository investorRepository, IMapper mapper)
        {
            _investorRepository = investorRepository;
            _mapper = mapper;
        }
        
        public ActionResult Index(InvestorsPageViewModel investorsPageViewModel)
        {
            bool hasDateFilter = (investorsPageViewModel.DateFrom.HasValue && investorsPageViewModel.DateTo.HasValue);

            List<Investor> investorList = new List<Investor>();

            if (hasDateFilter)
            {
                // get the full list of investors, filtered
                investorList =
                    _investorRepository.GetAllInvestorsBetweenDateCreatedRange(investorsPageViewModel.DateFrom.Value,
                        investorsPageViewModel.DateTo.Value);
            }
            else
            {   // get the full list of investors
                investorList = _investorRepository.GetAllInvestors();
            }
            
            // map the db list to the view model list
            var investorViewModelList = _mapper.Map<List<InvestorViewModel>>(investorList);

            //create our page view model and populate the list of investors
            InvestorsPageViewModel model = new InvestorsPageViewModel()
            {
                Investors = investorViewModelList
            };

            return View("Investors", model);
        }

        public PartialViewResult Detail(int id)
        {
            var investor = _investorRepository.GetInvestor(id);

            var investorViewModel = _mapper.Map<InvestorViewModel>(investor);

            ViewBag.InvestorName = $"{investor.Name} {investor.Surname}";
            ViewBag.SumOfAllAccounts = investor.Accounts.Select(x => x.AmountHeld).Sum(); //TODO: Alter VM to avoid using viewbag.

            return PartialView("_Detail", investorViewModel.Accounts);
        }

        [HttpPost]
        public ActionResult FilterDate(InvestorsPageViewModel investorsPageViewModel)
        {
            var from = investorsPageViewModel.DateFrom;
            var to = investorsPageViewModel.DateTo;

            return RedirectToAction("Index", investorsPageViewModel);
        }
    }
}