using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Processing;

namespace DataObjects.Interfaces.Finance
{
    public interface IAbbsSavingWithdrawlDao
    {


        object SaveAbbsSavingWithdrawl(AbbsSavingWithdrawl abbsSavingWithdrawl);

        object SearchAbbsSavingWithdrawl(AbbsSavingWithdrawl abbsSavingWithdrawl);



        object GetAbbsSavingWithdrawal(string OfficeCode, string UserCode);

    }
}
