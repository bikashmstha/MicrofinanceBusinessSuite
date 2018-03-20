using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.LoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface ILasLoanSearchDao
    {
        object Get();

        object Save(LasLoanSearch lasLoanSearch);

        object Search(LasLoanSearch lasLoanSearch);



        object GetLasLoanSearch(string OfficeCode, string ClientName);

    }
}
