using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.EditTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;
namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.EditTransaction
{
    public class LoanTransferFromCenterController : ControllerBase
    {
        private static ILoanTransferFromCenterDao loanTransferFromCenterDao = DataAccess.LoanTransferFromCenterDao;

        

        public object SaveLoanTransferFromCenter(LoanTransferFromCenter loanTransferFromCenter)
        {
            return loanTransferFromCenterDao.SaveLoanTransferFromCenter(loanTransferFromCenter);
        }
        public object SearchLoanTransferFromCenter(LoanTransferFromCenter loanTransferFromCenter)
        {
            return loanTransferFromCenterDao.SearchLoanTransferFromCenter(loanTransferFromCenter);
        }

        public object GetLoanTransferFrmCenter(string OfficeCode, string CenterName)
        {
            return loanTransferFromCenterDao.GetLoanTransferFrmCenter(OfficeCode, CenterName);
        }

    }
}