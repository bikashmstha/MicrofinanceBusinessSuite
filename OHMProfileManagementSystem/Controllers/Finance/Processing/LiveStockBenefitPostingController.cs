using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Processing;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Processing
{
    public class LiveStockBenefitPostingController : ControllerBase
    {
        private static ILiveStockBenefitPostingDao liveStockBenefitPostingDao = DataAccess.LiveStockBenefitPostingDao;



        public object SaveLiveStockBenefitPosting(List<LiveStockBenefitPosting> liveStockBenefitPosting)
        {
            return liveStockBenefitPostingDao.SaveLiveStockBenefitPosting(liveStockBenefitPosting);
        }
        public object SearchLiveStockBenefitPosting(LiveStockBenefitPosting liveStockBenefitPosting)
        {
            return liveStockBenefitPostingDao.SearchLiveStockBenefitPosting(liveStockBenefitPosting);
        }
    }
}