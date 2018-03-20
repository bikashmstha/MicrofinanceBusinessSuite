using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.EditTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface ICalLoanBalanceStatusDao
    {
        object GetCalLoanBalanceStatus(string OfficeCode,string LoanNo,string RepayDate);
    }
}
