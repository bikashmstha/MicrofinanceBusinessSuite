using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.EditTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.EditTransaction
{
    public class SavingTransferFromClientController : ControllerBase
    {
        private static ISavingTransferFromClientDao savingTransferFromClientDao = DataAccess.SavingTransferFromClientDao;



        public object SaveSavingTransferFromClient(SavingTransferFromClient savingTransferFromClient)
        {
            return savingTransferFromClientDao.SaveSavingTransferFromClient(savingTransferFromClient);
        }
        public object SearchSavingTransferFromClient(SavingTransferFromClient savingTransferFromClient)
        {
            return savingTransferFromClientDao.SearchSavingTransferFromClient(savingTransferFromClient);
        }

        public object GetSavTransferFrmClient(string OfficeCode, string CenterCode, string ClientName)
        {
            return savingTransferFromClientDao.GetSavTransferFrmClient(OfficeCode, CenterCode, ClientName);
        }

    }
}