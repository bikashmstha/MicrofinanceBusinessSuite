using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Processing;

namespace DataObjects.Interfaces.Finance
{
    public interface ILiveStockDepositPostingDao
    {


        object SaveLiveStockDepositPosting(List<LiveStockDepositPosting> liveStockDepositPostings);

        object SearchLiveStockDepositPosting(LiveStockDepositPosting liveStockDepositPosting);



    }
}
