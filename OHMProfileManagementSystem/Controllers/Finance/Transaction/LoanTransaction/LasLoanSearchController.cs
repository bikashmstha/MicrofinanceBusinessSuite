using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;
namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction
{
    public class LasLoanSearchController : ControllerBase
    {
        private static ILasLoanSearchDao lasLoanSearchDao = DataAccess.LasLoanSearchDao;

        public object Get()
        {
            return lasLoanSearchDao.Get();
        }

        public object Save(LasLoanSearch lasLoanSearch)
        {
            return lasLoanSearchDao.Save(lasLoanSearch);
        }

        public object Search(LasLoanSearch lasLoanSearch)
        {
            return lasLoanSearchDao.Search(lasLoanSearch);
        }

        public object GetLasLoanSearch(string OfficeCode, string ClientName)
        {
            return lasLoanSearchDao.GetLasLoanSearch(OfficeCode, ClientName);
        }

    }
}