using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.SavingTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.SavingTransaction
{
    public class ProductForAccountCloseController : ControllerBase
    {
        private static IProductForAccountCloseDao productForAccountCloseDao = DataAccess.ProductForAccountCloseDao;

        public object Get()
        {
            return productForAccountCloseDao.Get();
        }

        public object Save(ProductForAccountClose productForAccountClose)
        {
            return productForAccountCloseDao.Save(productForAccountClose);
        }
        public object Search(ProductForAccountClose productForAccountClose)
        {
            return productForAccountCloseDao.Search(productForAccountClose);
        }
        public object GetProductForAccountClose(string productName)
        {
            return productForAccountCloseDao.GetProductForAccountClose(productName);
        }
    }
}