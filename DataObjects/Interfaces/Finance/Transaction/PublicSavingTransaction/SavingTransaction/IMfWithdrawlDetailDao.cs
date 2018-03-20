using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.SavingTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IMfWithdrawlDetailDao
    {
        object Get();

        object Save(MfWithdrawlDetail mfWithDrawlDetail);

        object Search(MfWithdrawlDetail mfWithDrawlDetail);

        object GetMfWithdrawDetail(string offCode, long? withdrawlNo, string savingAccountNo, string clientName, string fromDate, string toDate);

    }
}
