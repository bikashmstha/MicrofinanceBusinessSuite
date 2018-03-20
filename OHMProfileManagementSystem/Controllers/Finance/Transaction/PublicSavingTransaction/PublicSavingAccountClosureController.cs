using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.PublicSavingTransaction
{
    public class PublicSavingAccountClosureController : ControllerBase
    {
        private static IPublicSavingAccountClosureDao publicSavingAccountClosureDao = DataAccess.PublicSavingAccountClosureDao;



        public object SavePublicSavingAccountClosure(PublicSavingAccountClosure publicSavingAccountClosure)
        {
            return publicSavingAccountClosureDao.SavePublicSavingAccountClosure(publicSavingAccountClosure);
        }
        public object DeletePublicSavingAccountClosure(string accountNo, string accountClosedDate, string otherIncomeVoucherNo, string username)
        {
            return publicSavingAccountClosureDao.DeletePublicSavingAccountClosure(accountNo, accountClosedDate, otherIncomeVoucherNo, username);
        }
        public object SearchPublicSavingAccountClosure(PublicSavingAccountClosure publicSavingAccountClosure)
        {
            return publicSavingAccountClosureDao.SearchPublicSavingAccountClosure(publicSavingAccountClosure);
        }


    }
}