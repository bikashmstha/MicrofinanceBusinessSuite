using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.PublicSavingTransaction
{
    public class PublicAccountCloseAccountController : ControllerBase
    {
        private static IPublicAccountCloseAccountDao publicAccountCloseAccountDao = DataAccess.PublicAccountCloseAccountDao;



        public object SavePublicAccountCloseAccount(PublicAccountCloseAccount publicAccountCloseAccount)
        {
            return publicAccountCloseAccountDao.SavePublicAccountCloseAccount(publicAccountCloseAccount);
        }
        public object SearchPublicAccountCloseAccount(PublicAccountCloseAccount publicAccountCloseAccount)
        {
            return publicAccountCloseAccountDao.SearchPublicAccountCloseAccount(publicAccountCloseAccount);
        }

        public object GetPubAccCloseAcc(string OfficeCode, string ProductCode, string SavingAccountNo)
        {
            return publicAccountCloseAccountDao.GetPubAccCloseAcc(OfficeCode, ProductCode, SavingAccountNo);
        }

    }
}