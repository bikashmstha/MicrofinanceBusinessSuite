using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.EditTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;


namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.EditTransaction
{
    public class TransferLoanAccountController : ControllerBase
    {
        private static ITransferLoanAccountDao transferLoanAccountDao = DataAccess.TransferLoanAccountDao;



        public object SaveTransferLoanAccount(TransferLoanAccount transferLoanAccount)
        {
            return transferLoanAccountDao.SaveTransferLoanAccount(transferLoanAccount);
        }
        public object SearchTransferLoanAccount(TransferLoanAccount transferLoanAccount)
        {
            return transferLoanAccountDao.SearchTransferLoanAccount(transferLoanAccount);
        }
    }
}