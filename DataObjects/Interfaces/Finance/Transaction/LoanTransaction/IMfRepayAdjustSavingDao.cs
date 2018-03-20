using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.LoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IMfRepayAdjustSavingDao
    {
        object Get();

        object Save(MfRepayAdjustSaving mfRepayAdjustSaving);

        object Search(MfRepayAdjustSaving mfRepayAdjustSaving);

        object GetMfRepayAdjustSaving(string offCode, string clientNo, string productName);

    }
}
