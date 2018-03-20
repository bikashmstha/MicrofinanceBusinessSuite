using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Processing;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Processing
{
    public class PublicSavingWithdrawlController : ControllerBase
    {
        private static IPublicSavingWithdrawlDao publicSavingWithdrawlDao = DataAccess.PublicSavingWithdrawlDao;



        public object SavePublicSavingWithdrawl(PublicSavingWithdrawl publicSavingWithdrawl)
        {
            return publicSavingWithdrawlDao.SavePublicSavingWithdrawl(publicSavingWithdrawl);
        }
        public object SearchPublicSavingWithdrawl(PublicSavingWithdrawl publicSavingWithdrawl)
        {
            return publicSavingWithdrawlDao.SearchPublicSavingWithdrawl(publicSavingWithdrawl);
        }

        public object GetPubSavingWithdrawal(string OfficeCode, string UserCode)
        {
            return publicSavingWithdrawlDao.GetPubSavingWithdrawal(OfficeCode, UserCode);
        }

    }
}