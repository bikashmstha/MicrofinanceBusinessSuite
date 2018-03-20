using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction
{
    public class LoanLasSavingProductController : ControllerBase
    {
        private static ILoanLasSavingProductDao loanLasSavingProductDao = DataAccess.LoanLasSavingProductDao;

        public object Get()
        {
            return loanLasSavingProductDao.Get();
        }

        public object Save(LoanLasSavingProduct loanLasSavingProduct)
        {
            return loanLasSavingProductDao.Save(loanLasSavingProduct);
        }
        public object Search(LoanLasSavingProduct loanLasSavingProduct)
        {
            return loanLasSavingProductDao.Search(loanLasSavingProduct);
        }

        public object GetLoanLasSavingProd(string ProductName)
        {
            return loanLasSavingProductDao.GetLoanLasSavingProd(ProductName);
        }

    }
}