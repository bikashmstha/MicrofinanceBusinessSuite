using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.LoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IMeLoanProductDao
    {
        object Get();

        object Save(MeLoanProduct meLoanProduct);

        object Search(MeLoanProduct meLoanProduct);

        object GetMeLoanProduct(string productName);
    }
}
