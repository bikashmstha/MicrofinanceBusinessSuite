using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.PublicSavingTransaction
{
    public class PublicChequeUpdateController : ControllerBase
    {
        private static IPublicChequeUpdateDao publicChequeUpdateDao = DataAccess.PublicChequeUpdateDao;



        public object SavePublicChequeUpdate(PublicChequeUpdate publicChequeUpdate)
        {
            return publicChequeUpdateDao.SavePublicChequeUpdate(publicChequeUpdate);
        }
        public object SearchPublicChequeUpdate(PublicChequeUpdate publicChequeUpdate)
        {
            return publicChequeUpdateDao.SearchPublicChequeUpdate(publicChequeUpdate);
        }

        public object GetPubChequeUpdate()
        {
            return publicChequeUpdateDao.GetPubChequeUpdate();
        }

    }
}