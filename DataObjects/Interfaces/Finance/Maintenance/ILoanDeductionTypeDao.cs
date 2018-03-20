using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Maintenance;

namespace DataObjects.Interfaces.Finance
{
    public interface ILoanDeductionTypeDao
    {
        object Get();

        object Save(LoanDeductionType loanDeductionType);

        object Search(LoanDeductionType loanDeductionType);

        object GetLoanDeduction(string LoanDeductionDesc);

    }
}
