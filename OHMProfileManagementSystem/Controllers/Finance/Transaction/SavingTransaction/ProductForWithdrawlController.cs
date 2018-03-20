using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.SavingTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.SavingTransaction
{
    public class ProductForWithdrawlController : ControllerBase
    {
        private static IProductForWithdrawlDao productForWithdrawlDao = DataAccess.ProductForWithdrawlDao;

        public object Get()
        {
            return productForWithdrawlDao.Get();
        }

        public object Save(ProductForWithdrawl productForWithdrawl)
        {
            return productForWithdrawlDao.Save(productForWithdrawl);
        }
        public object Search(ProductForWithdrawl productForWithdrawl)
        {
            return productForWithdrawlDao.Search(productForWithdrawl);
        }
        public object GetProductForWithDrawl(string productName)
        {
            return productForWithdrawlDao.GetProductForWithDrawl(productName);
        }
    }
}