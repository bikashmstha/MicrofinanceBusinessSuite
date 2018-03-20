using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;


namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.PublicSavingTransaction
{
    public class PublicAccountChequeAccountController : ControllerBase
    {
        private static IPublicAccountChequeAccountDao publicAccountChequeAccountDao = DataAccess.PublicAccountChequeAccountDao;



        public object SavePublicAccountChequeAccount(PublicAccountChequeAccount publicAccountChequeAccount)
        {
            return publicAccountChequeAccountDao.SavePublicAccountChequeAccount(publicAccountChequeAccount);
        }
        public object SearchPublicAccountChequeAccount(PublicAccountChequeAccount publicAccountChequeAccount)
        {
            return publicAccountChequeAccountDao.SearchPublicAccountChequeAccount(publicAccountChequeAccount);
        }

        public object GetPubAccCheqAcc(string OfficeCode, string ProductCode, string SavingAccountNo)
        {
            return publicAccountChequeAccountDao.GetPubAccCheqAcc(OfficeCode, ProductCode, SavingAccountNo);
        }

    }
}