using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.EditTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.EditTransaction
{
    public class LoanRepayAdjustRepayController : ControllerBase
    {
        private static ILoanRepayAdjustRepayDao loanRepayAdjustRepayDao = DataAccess.LoanRepayAdjustRepayDao;



        public object GetLoanRepayAdjustRepay(string OfficeCode, string LoanNo, string LoanDno, string FromDate, string ToDate)
        {
            return loanRepayAdjustRepayDao.GetLoanRepayAdjustRepay(OfficeCode, LoanNo, LoanDno, FromDate, ToDate);
        }

    }
}