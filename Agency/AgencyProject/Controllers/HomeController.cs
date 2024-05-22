using AgencyProject.Models;
using Business.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AgencyProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPortfolioService _portfolioService;

        public HomeController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public IActionResult Index()
        {
            var portfolios=_portfolioService.GetAllPortfolios();
            return View(portfolios);
        }

        
    }
}