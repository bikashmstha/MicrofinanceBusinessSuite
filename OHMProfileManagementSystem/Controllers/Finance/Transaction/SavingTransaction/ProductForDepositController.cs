using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.SavingTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;
namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.SavingTransaction
{
    public class ProductForDepositController : ControllerBase
    {
        private static IProductForDepositDao productForDepositDao = DataAccess.ProductForDepositDao;

        public object Get()
        {
            return productForDepositDao.Get();
        }

        public object Save(ProductForDeposit productForDeposit)
        {
            return productForDepositDao.Save(productForDeposit);
        }
        public object Search(ProductForDeposit productForDeposit)
        {
            return productForDepositDao.Search(productForDeposit);
        }
        public object GetProductForDeposit(string productName)
        {
            return productForDepositDao.GetProductForDeposit(productName);
        }
    }
}