using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;
namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction
{
    public class LoanAgainstSavingDisbursementController : ControllerBase
    {
        private static ILoanAgainstSavingDisbursementDao loanAgainstSavingDisbursementDao = DataAccess.LoanAgainstSavingDisbursementDao;

        public object Get()
        {
            return loanAgainstSavingDisbursementDao.Get();
        }

        public object Save(LoanAgainstSavingDisbursement loanAgainstSavingDisbursement)
        {
            return loanAgainstSavingDisbursementDao.Save(loanAgainstSavingDisbursement);
        }
        public object Search(LoanAgainstSavingDisbursement loanAgainstSavingDisbursement)
        {
            return loanAgainstSavingDisbursementDao.Search(loanAgainstSavingDisbursement);
        }
    }
}