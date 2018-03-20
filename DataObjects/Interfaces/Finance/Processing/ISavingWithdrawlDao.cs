using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Processing;

namespace DataObjects.Interfaces.Finance
{
    public interface ISavingWithdrawlDao
    {


        object SaveSavingWithdrawl(SavingWithdrawl savingWithdrawl);

        object SearchSavingWithdrawl(SavingWithdrawl savingWithdrawl);



        object GetSavingWithdrawal(string OfficeCode, string UserCode);

    }
}
