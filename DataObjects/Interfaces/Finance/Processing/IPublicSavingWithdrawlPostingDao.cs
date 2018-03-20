﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Processing;

namespace DataObjects.Interfaces.Finance
{
    public interface IPublicSavingWithdrawlPostingDao
    {


        object SavePublicSavingWithdrawlPosting(PublicSavingWithdrawlPosting publicSavingWithdrawlPosting);

        object SearchPublicSavingWithdrawlPosting(PublicSavingWithdrawlPosting publicSavingWithdrawlPosting);



    }
}
