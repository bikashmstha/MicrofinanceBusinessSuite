using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.EditTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.EditTransaction
{
    public class TransferSavingAccountController : ControllerBase
    {
        private static ITransferSavingAccountDao transferSavingAccountDao = DataAccess.TransferSavingAccountDao;



        public object SaveTransferSavingAccount(TransferSavingAccount transferSavingAccount)
        {
            return transferSavingAccountDao.SaveTransferSavingAccount(transferSavingAccount);
        }
        public object SearchTransferSavingAccount(TransferSavingAccount transferSavingAccount)
        {
            return transferSavingAccountDao.SearchTransferSavingAccount(transferSavingAccount);
        }
    }
}