using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstracts
{
    public interface IPortfolioService
    {
        void AddPortfolio (Portfolio portfolio);
        void DeletePortfolio(int id);
        void UpdatePortfolio(Portfolio portfolio);
        Portfolio GetPortfolio (Func<Portfolio,bool>?func=null);
        List<Portfolio> GetAllPortfolios(Func<Portfolio, bool>? func = null);

    }
}
