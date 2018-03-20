using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;


namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.PublicSavingTransaction
{
    public class PublicAccountChequeController : ControllerBase
    {
        private static IPublicAccountChequeDao publicAccountChequeDao = DataAccess.PublicAccountChequeDao;



        public object SavePublicAccountCheque(PublicAccountCheque publicAccountCheque)
        {
            return publicAccountChequeDao.SavePublicAccountCheque(publicAccountCheque);
        }
        public object SearchPublicAccountCheque(PublicAccountCheque publicAccountCheque)
        {
            return publicAccountChequeDao.SearchPublicAccountCheque(publicAccountCheque);
        }

        public object GetPubAccCheque(string AccountNo, string ChequeNo)
        {
            return publicAccountChequeDao.GetPubAccCheque(AccountNo, ChequeNo);
        }

    }
}