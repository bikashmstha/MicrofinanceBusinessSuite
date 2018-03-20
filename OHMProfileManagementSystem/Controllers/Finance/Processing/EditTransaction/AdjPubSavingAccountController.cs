using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.EditTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.EditTransaction
{
    public class AdjPubSavingAccountController : ControllerBase
    {
        private static IAdjPubSavingAccountDao adjPubSavingAccountDao = DataAccess.AdjPubSavingAccountDao;



        public object SaveAdjPubSavingAccount(AdjPubSavingAccount adjPubSavingAccount)
        {
            return adjPubSavingAccountDao.SaveAdjPubSavingAccount(adjPubSavingAccount);
        }
        public object SearchAdjPubSavingAccount(AdjPubSavingAccount adjPubSavingAccount)
        {
            return adjPubSavingAccountDao.SearchAdjPubSavingAccount(adjPubSavingAccount);
        }

        public object GetAdjPubSavingAcc(string OfficeCode, string ProductCode, string SavingAccountNo)
        {
            return adjPubSavingAccountDao.GetAdjPubSavingAcc(OfficeCode, ProductCode, SavingAccountNo);
        }

    }
}