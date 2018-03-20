using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.PublicSavingTransaction
{
    public class PublicWithdrawWithAccountController : ControllerBase
    {
        private static IPublicWithdrawWithAccountDao publicWithdrawWithAccountDao = DataAccess.PublicWithdrawWithAccountDao;



        public object SavePublicWithdrawWithAccount(PublicWithdrawWithAccount publicWithdrawWithAccount)
        {
            return publicWithdrawWithAccountDao.SavePublicWithdrawWithAccount(publicWithdrawWithAccount);
        }
        public object SearchPublicWithdrawWithAccount(PublicWithdrawWithAccount publicWithdrawWithAccount)
        {
            return publicWithdrawWithAccountDao.SearchPublicWithdrawWithAccount(publicWithdrawWithAccount);
        }

        public object GetPubWithAcc(string OfficeCode, string ProductCode, string SavingAccountNo)
        {
            return publicWithdrawWithAccountDao.GetPubWithAcc(OfficeCode, ProductCode, SavingAccountNo);
        }

    }
}