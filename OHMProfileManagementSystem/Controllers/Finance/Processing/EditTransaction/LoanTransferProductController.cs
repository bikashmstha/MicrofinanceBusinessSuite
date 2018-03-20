using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.EditTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.EditTransaction
{
    public class LoanTransferProductController : ControllerBase
    {
        private static ILoanTransferProductDao loanTransferProductDao = DataAccess.LoanTransferProductDao;



        public object SaveLoanTransferProduct(LoanTransferProduct loanTransferProduct)
        {
            return loanTransferProductDao.SaveLoanTransferProduct(loanTransferProduct);
        }
        public object SearchLoanTransferProduct(LoanTransferProduct loanTransferProduct)
        {
            return loanTransferProductDao.SearchLoanTransferProduct(loanTransferProduct);
        }

        public object GetLoanTransferProduct(string ProductName)
        {
            return loanTransferProductDao.GetLoanTransferProduct(ProductName);
        }

    }
}