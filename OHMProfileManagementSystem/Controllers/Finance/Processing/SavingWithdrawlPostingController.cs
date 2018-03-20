using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Processing;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Processing
{
    public class SavingWithdrawlPostingController : ControllerBase
    {
        private static ISavingWithdrawlPostingDao savingWithdrawlPostingDao = DataAccess.SavingWithdrawlPostingDao;



        public object SaveSavingWithdrawlPosting(List<SavingWithdrawlPosting> savingWithdrawlPosting)
        {
            return savingWithdrawlPostingDao.SaveSavingWithdrawlPosting(savingWithdrawlPosting);
        }
        public object SearchSavingWithdrawlPosting(SavingWithdrawlPosting savingWithdrawlPosting)
        {
            return savingWithdrawlPostingDao.SearchSavingWithdrawlPosting(savingWithdrawlPosting);
        }
    }
}