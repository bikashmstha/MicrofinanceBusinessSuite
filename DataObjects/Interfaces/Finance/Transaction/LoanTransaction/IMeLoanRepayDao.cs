using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.LoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IMeLoanRepayDao
    {
        object Get();

        object Save(MeLoanRepay meLoanRepay);

        object Search(MeLoanRepay meLoanRepay);

        object GetMeLoanRepay(string offCode, string productCode, string clientName);

        object GetMeLoanRepaySearch(string offCode, string clientName);

    }
}
