using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.EditTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.EditTransaction
{
    public class PubSavingAccountSearchController : ControllerBase
    {
        private static IPubSavingAccountSearchDao pubSavingAccountSearchDao = DataAccess.PubSavingAccountSearchDao;



        public object SavePubSavingAccountSearch(PubSavingAccountSearch pubSavingAccountSearch)
        {
            return pubSavingAccountSearchDao.SavePubSavingAccountSearch(pubSavingAccountSearch);
        }
        public object SearchPubSavingAccountSearch(PubSavingAccountSearch pubSavingAccountSearch)
        {
            return pubSavingAccountSearchDao.SearchPubSavingAccountSearch(pubSavingAccountSearch);
        }

        public object GetPubSavAccSearch(string OfficeCode, string SavingAccountNo)
        {
            return pubSavingAccountSearchDao.GetPubSavAccSearch(OfficeCode, SavingAccountNo);
        }

    }
}