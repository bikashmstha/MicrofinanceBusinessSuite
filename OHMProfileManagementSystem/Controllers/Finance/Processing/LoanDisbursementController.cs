using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Processing;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Processing
{
    public class LoanDisbursementController : ControllerBase
    {
        private static ILoanDisbursementDao loanDisbursementDao = DataAccess.LoanDisbursementDao;



        public object SaveLoanDisbursement(LoanDisbursement loanDisbursement)
        {
            return loanDisbursementDao.SaveLoanDisbursement(loanDisbursement);
        }
        public object SearchLoanDisbursement(LoanDisbursement loanDisbursement)
        {
            return loanDisbursementDao.SearchLoanDisbursement(loanDisbursement);
        }

        public object GetLoanDisbursement(string OfficeCode, string UserCode)
        {
            return loanDisbursementDao.GetLoanDisbursement(OfficeCode, UserCode);
        }

    }
}