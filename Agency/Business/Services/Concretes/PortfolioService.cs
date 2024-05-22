using Business.Exceptions;
using Business.Extensions;
using Business.Services.Abstracts;
using Core.Models;
using Data.RepositoryConcretes;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concretes
{
    public class PortfolioService : IPortfolioService
    {
        private readonly PortfolioRepository _portfolioRepository;
        private readonly IWebHostEnvironment _env;
        public PortfolioService(PortfolioRepository portfolioRepository,IWebHostEnvironment env)
        {
            _portfolioRepository = portfolioRepository;
            _env = env;

        }

        public void AddPortfolio(Portfolio portfolio)
        {
            if (portfolio.ImgFile == null)
                throw new ImageFileRequiredException(nameof(portfolio.ImgFile), "Image file is required!");
            portfolio.ImgUrl=Helper.SaveFile(_env.WebRootPath,@"uploads\portfolios",portfolio.ImgFile);
            _portfolioRepository.Add(portfolio);
            _portfolioRepository.Commit();
        }

        public void DeletePortfolio(int id)
        {
            var existPortfolio = _portfolioRepository.Get(x => x.Id == id);
            if (existPortfolio == null)
                throw new EntityNotFoundException("", "portfolio not found!");
            if(existPortfolio.ImgFile != null)
                Helper.DeleteFile(_env.WebRootPath, @"uploads\portfolios",existPortfolio.ImgUrl);
        }

        public List<Portfolio> GetAllPortfolios(Func<Portfolio, bool>? func = null)
        {
            return _portfolioRepository.GetAll(func);

        }

        public Portfolio GetPortfolio(Func<Portfolio, bool>? func = null)
        {
            return _portfolioRepository.Get(func);
        }

        public void UpdatePortfolio(Portfolio portfolio)
        {
            var existPortfolio = _portfolioRepository.Get(x => x.Id ==portfolio.Id);
            if (existPortfolio == null)
                throw new EntityNotFoundException("", "portfolio not found!");
            if (existPortfolio.ImgFile != null) 
            { 
                 if(existPortfolio.ImgFile != null)
                Helper.DeleteFile(_env.WebRootPath, @"uploads\portfolios",existPortfolio.ImgUrl);
                existPortfolio.ImgUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\portfolios", portfolio.ImgFile);
            }
            existPortfolio.Title=existPortfolio.Title;
            existPortfolio.Description=existPortfolio.Description;
            _portfolioRepository.Commit();
        }
    }
}
