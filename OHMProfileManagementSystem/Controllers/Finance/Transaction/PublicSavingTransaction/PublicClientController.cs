using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.PublicSavingTransaction
{
    public class PublicClientController : ControllerBase
    {
        private static IPublicClientDao publicClientDao = DataAccess.PublicClientDao;



        public object SavePublicClient(PublicClient publicClient)
        {
            return publicClientDao.SavePublicClient(publicClient);
        }
        public object SearchPublicClient(PublicClient publicClient)
        {
            return publicClientDao.SearchPublicClient(publicClient);
        }

        public object GetPubClient(string OfficeCode, string ClientName)
        {
            return publicClientDao.GetPubClient(OfficeCode, ClientName);
        }

    }
}