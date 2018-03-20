using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Processing;
using DataObjects;
using DataObjects.Interfaces.Finance;
namespace MicrofinanceBusinessSuite.Controllers.Finance.Processing
{
    public class WithdrawlPostingPublicController : ControllerBase
    {
        private static IWithdrawlPostingPublicDao withdrawlPostingPublicDao = DataAccess.WithdrawlPostingPublicDao;



        public object SaveWithdrawlPostingPublic(WithdrawlPostingPublic withdrawlPostingPublic)
        {
            return withdrawlPostingPublicDao.SaveWithdrawlPostingPublic(withdrawlPostingPublic);
        }
        public object SearchWithdrawlPostingPublic(WithdrawlPostingPublic withdrawlPostingPublic)
        {
            return withdrawlPostingPublicDao.SearchWithdrawlPostingPublic(withdrawlPostingPublic);
        }
    }
}