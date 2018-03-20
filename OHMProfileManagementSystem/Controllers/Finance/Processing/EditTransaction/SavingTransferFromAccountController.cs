using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.EditTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;
namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.EditTransaction
{
    public class SavingTransferFromAccountController : ControllerBase
    {
        private static ISavingTransferFromAccountDao savingTransferFromAccountDao = DataAccess.SavingTransferFromAccountDao;



        public object SaveSavingTransferFromAccount(SavingTransferFromAccount savingTransferFromAccount)
        {
            return savingTransferFromAccountDao.SaveSavingTransferFromAccount(savingTransferFromAccount);
        }
        public object SearchSavingTransferFromAccount(SavingTransferFromAccount savingTransferFromAccount)
        {
            return savingTransferFromAccountDao.SearchSavingTransferFromAccount(savingTransferFromAccount);
        }

        public object GetSavTransferFrmAcc(string OfficeCode, string CenterCode, string ClientNo)
        {
            return savingTransferFromAccountDao.GetSavTransferFrmAcc(OfficeCode, CenterCode, ClientNo);
        }

    }
}