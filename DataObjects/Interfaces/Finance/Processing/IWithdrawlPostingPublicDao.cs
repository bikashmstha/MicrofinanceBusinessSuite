using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Processing;

namespace DataObjects.Interfaces.Finance
{
    public interface IWithdrawlPostingPublicDao
    {


        object SaveWithdrawlPostingPublic(WithdrawlPostingPublic withdrawlPostingPublic);

        object SearchWithdrawlPostingPublic(WithdrawlPostingPublic withdrawlPostingPublic);


    }
}
