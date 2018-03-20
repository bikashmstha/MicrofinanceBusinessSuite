using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.AccountTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;
namespace MicrofinanceBusinessSuite.Controllers.Finance.AccountTransaction
{
    public class BudgetLimitAmtController : ControllerBase
    {
        private static IBudgetLimitAmtDao budgetLimitAmtDao = DataAccess.BudgetLimitAmtDao;



        public object SaveBudgetLimitAmt(BudgetLimitAmt budgetLimitAmt)
        {
            return budgetLimitAmtDao.SaveBudgetLimitAmt(budgetLimitAmt);
        }
        public object SearchBudgetLimitAmt(BudgetLimitAmt budgetLimitAmt)
        {
            return budgetLimitAmtDao.SearchBudgetLimitAmt(budgetLimitAmt);
        }

        public object GetBudgetLimitAmount(string FiscalYear, string TransactionDate, string TranOfficeCode, string AccountCode)
        {
            return budgetLimitAmtDao.GetBudgetLimitAmount(FiscalYear, TransactionDate, TranOfficeCode, AccountCode);
        }

    }
}