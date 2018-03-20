using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.PublicSavingTransaction
{
    public class PublicReferenceAccountController : ControllerBase
    {
        private static IPublicReferenceAccountDao publicReferenceAccountDao = DataAccess.PublicReferenceAccountDao;



        public object SavePublicReferenceAccount(PublicReferenceAccount publicReferenceAccount)
        {
            return publicReferenceAccountDao.SavePublicReferenceAccount(publicReferenceAccount);
        }
        public object SearchPublicReferenceAccount(PublicReferenceAccount publicReferenceAccount)
        {
            return publicReferenceAccountDao.SearchPublicReferenceAccount(publicReferenceAccount);
        }

        public object GetPubRefAcc(string OfficeCode, string ClientNo)
        {
            return publicReferenceAccountDao.GetPubRefAcc(OfficeCode, ClientNo);
        }

    }
}