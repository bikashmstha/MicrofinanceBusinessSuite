using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.SavingTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IMfDepositDetailDao
    {
        object Get();

        object Save(MfDepositDetail mFDepositDetail);

        object Search(MfDepositDetail mFDepositDetail);

        object GetMfDepositDetail(string offCode, long? depositNo, string savingAccountNo, string clientName, string fromDate, string toDate);

    }
}
