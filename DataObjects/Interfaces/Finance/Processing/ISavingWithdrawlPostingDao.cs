using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Processing;

namespace DataObjects.Interfaces.Finance
{
    public interface ISavingWithdrawlPostingDao
    {


        object SaveSavingWithdrawlPosting(List<SavingWithdrawlPosting> savingWithdrawlPostings);

        object SearchSavingWithdrawlPosting(SavingWithdrawlPosting savingWithdrawlPosting);

    }
}
