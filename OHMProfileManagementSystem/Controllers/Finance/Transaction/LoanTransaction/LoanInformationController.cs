using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction
{
    public class LoanInformationController : ControllerBase
    {
        private static ILoanInformationDao loanInformationDao = DataAccess.LoanInformationDao;



        public object SaveLoanInformation(LoanInformation loanInformation)
        {
            return loanInformationDao.SaveLoanInformation(loanInformation);
        }
        public object SearchLoanInformation(LoanInformation loanInformation)
        {
            return loanInformationDao.SearchLoanInformation(loanInformation);
        }

        public object GetLoanInformation()
        {
            return loanInformationDao.GetLoanInformation();
        }

    }
}