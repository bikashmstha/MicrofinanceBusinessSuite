using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Processing;
using DataObjects;
using DataObjects.Interfaces.Finance;
namespace MicrofinanceBusinessSuite.Controllers.Finance.Processing
{
    public class LiveStockDepositPostingController : ControllerBase
    {
        private static ILiveStockDepositPostingDao liveStockDepositPostingDao = DataAccess.LiveStockDepositPostingDao;



        public object SaveLiveStockDepositPosting(List<LiveStockDepositPosting> liveStockDepositPosting)
        {
            return liveStockDepositPostingDao.SaveLiveStockDepositPosting(liveStockDepositPosting);
        }
        public object SearchLiveStockDepositPosting(LiveStockDepositPosting liveStockDepositPosting)
        {
            return liveStockDepositPostingDao.SearchLiveStockDepositPosting(liveStockDepositPosting);
        }
    }
}