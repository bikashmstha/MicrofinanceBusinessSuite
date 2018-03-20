using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Processing;

namespace DataObjects.Interfaces.Finance
{
    public interface ILiveStockBenefitPostingDao
    {


        object SaveLiveStockBenefitPosting(List<LiveStockBenefitPosting> liveStockBenefitPostings);

        object SearchLiveStockBenefitPosting(LiveStockBenefitPosting liveStockBenefitPosting);



    }
}
