using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.LoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IMeLoanSearchDao
    {
        object Get();

        object Save(MeLoanSearch meLoanSearch);

        object Search(MeLoanSearch meLoanSearch);

        object GetMeLoanSearch(string offCode, string clientName);

    }
}
