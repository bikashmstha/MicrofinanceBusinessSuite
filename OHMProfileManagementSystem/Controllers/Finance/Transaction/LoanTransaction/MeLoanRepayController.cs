using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;


namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction
{
    public class MeLoanRepayController : ControllerBase
    {
        private static IMeLoanRepayDao meLoanRepayDao = DataAccess.MeLoanRepayDao;

        public object Get()
        {
            return meLoanRepayDao.Get();
        }

        public object Save(MeLoanRepay meLoanRepay)
        {
            return meLoanRepayDao.Save(meLoanRepay);
        }
        public object Search(MeLoanRepay meLoanRepay)
        {
            return meLoanRepayDao.Search(meLoanRepay);
        }
        public object GetMeLoanRepay(string offCode, string productCode, string clientName)
        {
            return meLoanRepayDao.GetMeLoanRepay(offCode, productCode, clientName);
        }
        public object GetMeLoanRepaySearch(string offCode,  string clientName)
        {
            return meLoanRepayDao.GetMeLoanRepaySearch(offCode,  clientName);
        }
    }
}