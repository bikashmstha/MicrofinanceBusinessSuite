using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Processing;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Processing
{
    public class PublicSavingWithdrawlPostingController : ControllerBase
    {
        private static IPublicSavingWithdrawlPostingDao publicSavingWithdrawlPostingDao = DataAccess.PublicSavingWithdrawlPostingDao;



        public object SavePublicSavingWithdrawlPosting(PublicSavingWithdrawlPosting publicSavingWithdrawlPosting)
        {
            return publicSavingWithdrawlPostingDao.SavePublicSavingWithdrawlPosting(publicSavingWithdrawlPosting);
        }
        public object SearchPublicSavingWithdrawlPosting(PublicSavingWithdrawlPosting publicSavingWithdrawlPosting)
        {
            return publicSavingWithdrawlPostingDao.SearchPublicSavingWithdrawlPosting(publicSavingWithdrawlPosting);
        }
    }
}