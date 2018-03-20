using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;


namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction
{
    public class LoanProductController : ControllerBase
    {
        private static ILoanProductDao loanProductDao = DataAccess.LoanProductDao;

        public object Get()
        {
            return loanProductDao.Get();
        }

        public object SaveLoanProduct(LoanProduct loanProduct)
        {
            return loanProductDao.SaveLoanProduct(loanProduct);
        }
        public object Search(LoanProduct loanProduct)
        {
            return loanProductDao.Search(loanProduct);
        }
        public object GetLoanProduct(string productName)
        {
            return loanProductDao.GetLoanProduct(productName);
        }
    }
}