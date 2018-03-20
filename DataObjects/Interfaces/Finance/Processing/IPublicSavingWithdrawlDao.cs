using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Processing;

namespace DataObjects.Interfaces.Finance
{
    public interface IPublicSavingWithdrawlDao
    {


        object SavePublicSavingWithdrawl(PublicSavingWithdrawl publicSavingWithdrawl);

        object SearchPublicSavingWithdrawl(PublicSavingWithdrawl publicSavingWithdrawl);



        object GetPubSavingWithdrawal(string OfficeCode, string UserCode);

    }
}
