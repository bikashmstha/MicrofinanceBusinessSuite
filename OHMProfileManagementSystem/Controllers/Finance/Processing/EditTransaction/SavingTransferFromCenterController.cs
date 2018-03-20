using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.EditTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;


namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.EditTransaction
{
    public class SavingTransferFromCenterController : ControllerBase
    {
        private static ISavingTransferFromCenterDao savingTransferFromCenterDao = DataAccess.SavingTransferFromCenterDao;



        public object SaveSavingTransferFromCenter(SavingTransferFromCenter savingTransferFromCenter)
        {
            return savingTransferFromCenterDao.SaveSavingTransferFromCenter(savingTransferFromCenter);
        }
        public object SearchSavingTransferFromCenter(SavingTransferFromCenter savingTransferFromCenter)
        {
            return savingTransferFromCenterDao.SearchSavingTransferFromCenter(savingTransferFromCenter);
        }

        public object GetSavTransferFrmCenter(string OfficeCode, string CenterName)
        {
            return savingTransferFromCenterDao.GetSavTransferFrmCenter(OfficeCode, CenterName);
        }

    }
}