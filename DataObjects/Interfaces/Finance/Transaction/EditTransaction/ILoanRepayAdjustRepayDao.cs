using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.EditTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface ILoanRepayAdjustRepayDao
    {


        object GetLoanRepayAdjustRepay(string OfficeCode, string LoanNo, string LoanDno, string FromDate, string ToDate);
    }
}
