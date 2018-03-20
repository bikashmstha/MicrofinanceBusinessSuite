using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction
{
    public class MeLoanProductController : ControllerBase
    {
        private static IMeLoanProductDao meLoanProductDao = DataAccess.MeLoanProductDao;

        public object Get()
        {
            return meLoanProductDao.Get();
        }

        public object Save(MeLoanProduct meLoanProduct)
        {
            return meLoanProductDao.Save(meLoanProduct);
        }
        public object Search(MeLoanProduct meLoanProduct)
        {
            return meLoanProductDao.Search(meLoanProduct);
        }
       public  object GetMeLoanProduct(string productName)
        {
            return meLoanProductDao.GetMeLoanProduct(productName);
        }
    }
}