using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;


namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction
{
    public class LasLoanDetailController : ControllerBase
    {
        private static ILasLoanDetailDao lasLoanDetailDao = DataAccess.LasLoanDetailDao;

        public object Get()
        {
            return lasLoanDetailDao.Get();
        }

        public object Save(LasLoanDetail lasLoanDetail)
        {
            return lasLoanDetailDao.Save(lasLoanDetail);
        }
        public object Search(LasLoanDetail lasLoanDetail)
        {
            return lasLoanDetailDao.Search(lasLoanDetail);
        }

        public object GetLasLoanDetail(string OfficeCode, string ClientName, string LoanNo, string DateFrom, string DateTo)
        {
            return lasLoanDetailDao.GetLasLoanDetail(OfficeCode, ClientName, LoanNo, DateFrom, DateTo);
        }

    }
}