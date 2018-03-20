using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.EditTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.EditTransaction
{
    public class LoanTransferFromClientController : ControllerBase
    {
        private static ILoanTransferFromClientDao loanTransferFromClientDao = DataAccess.LoanTransferFromClientDao;

        

        public object SaveLoanTransferFromClient(LoanTransferFromClient loanTransferFromClient)
        {
            return loanTransferFromClientDao.SaveLoanTransferFromClient(loanTransferFromClient);
        }
        public object SearchLoanTransferFromClient(LoanTransferFromClient loanTransferFromClient)
        {
            return loanTransferFromClientDao.SearchLoanTransferFromClient(loanTransferFromClient);
        }

        public object GetLoanTransferFrmClient(string OfficeCode, string CenterCode, string ClientName)
        {
            return loanTransferFromClientDao.GetLoanTransferFrmClient(OfficeCode, CenterCode, ClientName);
        }

    }
}