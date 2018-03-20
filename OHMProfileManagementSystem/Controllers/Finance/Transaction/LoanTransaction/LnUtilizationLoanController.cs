using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;
namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction
{
    public class LnUtilizationLoanController : ControllerBase
    {
        private static ILnUtilizationLoanDao lnUtilizationLoanDao = DataAccess.LnUtilizationLoanDao;

        public object Get()
        {
            return lnUtilizationLoanDao.Get();
        }

        public object Save(LnUtilizationLoan lnUtilizationLoan)
        {
            return lnUtilizationLoanDao.Save(lnUtilizationLoan);
        }
        public object Search(LnUtilizationLoan lnUtilizationLoan)
        {
            return lnUtilizationLoanDao.Search(lnUtilizationLoan);
        }

        public object GetLnUtilizationLoan(string CenterCode, string ClientName)
        {
            return lnUtilizationLoanDao.GetLnUtilizationLoan(CenterCode, ClientName);
        }

    }
}