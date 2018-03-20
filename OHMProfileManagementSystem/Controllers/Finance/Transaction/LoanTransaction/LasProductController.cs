using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;
namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction
{
    public class LasProductController : ControllerBase
    {
        private static ILasProductDao lasProductDao = DataAccess.LasProductDao;

        public object Get()
        {
            return lasProductDao.Get();
        }

        public object Save(LasProduct lasProduct)
        {
            return lasProductDao.Save(lasProduct);
        }
        public object Search(LasProduct lasProduct)
        {
            return lasProductDao.Search(lasProduct);
        }

        public object GetLasProduct(string ProductCodeType, string ProductName)
        {
            return lasProductDao.GetLasProduct(ProductCodeType, ProductName);
        }

    }
}