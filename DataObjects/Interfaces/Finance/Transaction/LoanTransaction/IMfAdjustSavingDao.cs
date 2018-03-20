using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.LoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IMfAdjustSavingDao
    {
        object Get();

        object Save(MfAdjustSaving mfAdjustSaving);

        object Search(MfAdjustSaving mfAdjustSaving);

        object GetMfAdjustSaving(string offCode, string clientNo, string productName);

    }
}
