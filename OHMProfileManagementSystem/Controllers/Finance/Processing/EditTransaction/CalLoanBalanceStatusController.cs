using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.EditTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;


namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.EditTransaction
{
    public class CalLoanBalanceStatusController : ControllerBase
    {
        private static ICalLoanBalanceStatusDao calLoanBalanceStatusDao = DataAccess.CalLoanBalanceStatusDao;



        public object GetCalLoanBalanceStatus(string OfficeCode, string LoanNo, string RepayDate)
        {
            return calLoanBalanceStatusDao.GetCalLoanBalanceStatus(OfficeCode, LoanNo, RepayDate);
        }

    }
}