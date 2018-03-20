using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.EditTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;


namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.EditTransaction
{
    public class SavingTransferProcController : ControllerBase
    {
        private static ISavingTransferProcDao savingTransferProcDao = DataAccess.SavingTransferProcDao;



        public object SaveSavingTransferProc(SavingTransferProc savingTransferProc)
        {
            return savingTransferProcDao.SaveSavingTransferProc(savingTransferProc);
        }
        public object SearchSavingTransferProc(SavingTransferProc savingTransferProc)
        {
            return savingTransferProcDao.SearchSavingTransferProc(savingTransferProc);
        }

        public object GetSavTransferProc(string ProductName)
        {
            return savingTransferProcDao.GetSavTransferProc(ProductName);
        }

    }
}