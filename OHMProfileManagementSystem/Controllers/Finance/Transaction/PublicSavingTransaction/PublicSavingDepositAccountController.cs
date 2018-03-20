using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;


namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.PublicSavingTransaction
{
    public class PublicSavingDepositAccountController : ControllerBase
    {
        private static IPublicSavingDepositAccountDao publicSavingDepositAccountDao = DataAccess.PublicSavingDepositAccountDao;



        public object SavePublicSavingDepositAccount(PublicSavingDepositAccount publicSavingDepositAccount)
        {
            return publicSavingDepositAccountDao.SavePublicSavingDepositAccount(publicSavingDepositAccount);
        }
        public object SearchPublicSavingDepositAccount(PublicSavingDepositAccount publicSavingDepositAccount)
        {
            return publicSavingDepositAccountDao.SearchPublicSavingDepositAccount(publicSavingDepositAccount);
        }

        public object GetPubSavingDepoAcc(string OfficeCode, string ProductCode, string SavingAccountNo)
        {
            return publicSavingDepositAccountDao.GetPubSavingDepoAcc(OfficeCode, ProductCode, SavingAccountNo);
        }

    }
}