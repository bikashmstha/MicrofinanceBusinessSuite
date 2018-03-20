using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.LoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface ILasLoanDetailDao
    {
        object Get();

        object Save(LasLoanDetail lasLoanDetail);

        object Search(LasLoanDetail lasLoanDetail);



        object GetLasLoanDetail(string OfficeCode, string ClientName, string LoanNo, string DateFrom, string DateTo);

    }
}
