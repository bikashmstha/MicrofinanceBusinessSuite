using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.EditTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.EditTransaction
{
    public class LoanTransferFromLoanController : ControllerBase
    {
        private static ILoanTransferFromLoanDao loanTransferFromLoanDao = DataAccess.LoanTransferFromLoanDao;



        public object SaveLoanTransferFromLoan(LoanTransferFromLoan loanTransferFromLoan)
        {
            return loanTransferFromLoanDao.SaveLoanTransferFromLoan(loanTransferFromLoan);
        }
        public object SearchLoanTransferFromLoan(LoanTransferFromLoan loanTransferFromLoan)
        {
            return loanTransferFromLoanDao.SearchLoanTransferFromLoan(loanTransferFromLoan);
        }

        public object GetLoanTransferFrmLoan(string OfficeCode, string CenterCode, string ClientNo, string ProductCode)
        {
            return loanTransferFromLoanDao.GetLoanTransferFrmLoan(OfficeCode, CenterCode, ClientNo, ProductCode);
        }

    }
}