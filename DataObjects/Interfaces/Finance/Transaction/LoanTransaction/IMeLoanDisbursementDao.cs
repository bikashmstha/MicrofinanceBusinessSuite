using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.LoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IMeLoanDisbursementDao
    {
        object Get();

        object Save(MeLoanDisbursement meLoanDisbursement);

        object Search(MeLoanDisbursement meLoanDisbursement);

        object GetMeLoanMember(string offCode, string centerCode, string memberName);

    }
}
