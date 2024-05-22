using Business.Exceptions;
using Business.Services.Abstracts;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AgencyProject.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PortfolioController : Controller
    {
        private readonly IPortfolioService _portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public IActionResult Index()
        {
            var portfolios = _portfolioService.GetAllPortfolios();
            return View(portfolios);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Portfolio portfolio)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                _portfolioService.AddPortfolio(portfolio);
            }
            catch (ImageFileRequiredException ex)
            {

                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch  (FileContentTypeException ex)
            {
                ModelState.AddModelError(ex.PropertyName,ex.Message);
                return View();
            }
            catch (FileSizeException ex)
            {

                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch(Exception ex)
            {
               return BadRequest(ex.Message);
            }
            return RedirectToAction("Index");

        }
        public IActionResult Update(int id)
        {
            var existPortfolios = _portfolioService.GetPortfolio(x=>x.Id==id);
            if (existPortfolios == null)
                return View("Error");
            return View(existPortfolios);
        }
        [HttpPost]
        public IActionResult Update(Portfolio portfolio)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                _portfolioService.UpdatePortfolio(portfolio);
            }
            catch (EntityNotFoundException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();

            }
            catch(EntityFileNotFoundException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (FileContentTypeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (FileSizeException ex)
            {

                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return RedirectToAction("Index");

        }
        public IActionResult Delete(int id)
        {
            var existPortfolios = _portfolioService.GetPortfolio(x => x.Id == id);
            if (existPortfolios == null)
                return View("Error");
            return View(existPortfolios);
        }
        [HttpPost]
        public IActionResult DeletePortfolio(int id)
        {
            var existPortfolios = _portfolioService.GetPortfolio(x => x.Id == id);
            if (existPortfolios == null)
                return View("Error");
            return View(existPortfolios);
            try
            {
                _portfolioService.DeletePortfolio(id);
            }
            catch (EntityNotFoundException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();

            }
            catch (EntityFileNotFoundException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return RedirectToAction("Index");

        }
    }
}
