using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction
{
    public class MeLoanSearchController : ControllerBase
    {
        private static IMeLoanSearchDao meLoanSearchDao = DataAccess.MeLoanSearchDao;

        public object Get()
        {
            return meLoanSearchDao.Get();
        }

        public object Save(MeLoanSearch meLoanSearch)
        {
            return meLoanSearchDao.Save(meLoanSearch);
        }
        public object Search(MeLoanSearch meLoanSearch)
        {
            return meLoanSearchDao.Search(meLoanSearch);
        }
        public object GetMeLoanSearch(string offCode, string clientName)
        {
            return meLoanSearchDao.GetMeLoanSearch(offCode,clientName);
        }
    }
}