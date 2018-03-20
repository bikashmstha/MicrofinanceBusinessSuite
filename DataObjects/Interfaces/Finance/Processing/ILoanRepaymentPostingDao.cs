using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Processing;

namespace DataObjects.Interfaces.Finance
{
    public interface ILoanRepaymentPostingDao
    {


        object SaveLoanRepaymentPosting(List<LoanRepaymentPosting> loanRepaymentPostings);

        object SearchLoanRepaymentPosting(LoanRepaymentPosting loanRepaymentPosting);


    }
}
