using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;


namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.PublicSavingTransaction
{
    public class PublicAdjustmentdepositaccountController : ControllerBase
    {
        private static IPublicAdjustmentdepositaccountDao publicAdjustmentDepositAccountDao = DataAccess.PublicAdjustmentdepositaccountDao;



        public object SavePublicAdjustmentdepositaccount(PublicAdjustmentdepositaccount publicAdjustmentDepositAccount)
        {
            return publicAdjustmentDepositAccountDao.SavePublicAdjustmentdepositaccount(publicAdjustmentDepositAccount);
        }
        public object SearchPublicAdjustmentdepositaccount(PublicAdjustmentdepositaccount publicAdjustmentDepositAccount)
        {
            return publicAdjustmentDepositAccountDao.SearchPublicAdjustmentdepositaccount(publicAdjustmentDepositAccount);
        }

        public object GetPubAdjDepoAcc(string OfficeCode, string AccountNo)
        {
            return publicAdjustmentDepositAccountDao.GetPubAdjDepoAcc(OfficeCode, AccountNo);
        }

    }
}