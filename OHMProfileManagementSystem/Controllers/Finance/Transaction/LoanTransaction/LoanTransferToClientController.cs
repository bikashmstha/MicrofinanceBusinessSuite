using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction
{
    public class LoanTransferToClientController : ControllerBase
    {
        private static ILoanTransferToClientDao loanTransferToClientDao = DataAccess.LoanTransferToClientDao;



        public object SaveLoanTransferToClient(LoanTransferToClient loanTransferToClient)
        {
            return loanTransferToClientDao.SaveLoanTransferToClient(loanTransferToClient);
        }
        public object SearchLoanTransferToClient(LoanTransferToClient loanTransferToClient)
        {
            return loanTransferToClientDao.SearchLoanTransferToClient(loanTransferToClient);
        }

        public object GetLoanTransferToClient(string OfficeCode, string CenterCode, string ProductCode, string ClientName)
        {
            return loanTransferToClientDao.GetLoanTransferToClient(OfficeCode, CenterCode, ProductCode, ClientName);
        }

    }
}