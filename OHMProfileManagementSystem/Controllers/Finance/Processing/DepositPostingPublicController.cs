using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Processing;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Processing
{
    public class DepositPostingPublicController : ControllerBase
    {
        private static IDepositPostingPublicDao depositPostingPublicDao = DataAccess.DepositPostingPublicDao;



        public object SaveDepositPostingPublic(DepositPostingPublic depositPostingPublic)
        {
            return depositPostingPublicDao.SaveDepositPostingPublic(depositPostingPublic);
        }
        public object SearchDepositPostingPublic(DepositPostingPublic depositPostingPublic)
        {
            return depositPostingPublicDao.SearchDepositPostingPublic(depositPostingPublic);
        }
    }
}