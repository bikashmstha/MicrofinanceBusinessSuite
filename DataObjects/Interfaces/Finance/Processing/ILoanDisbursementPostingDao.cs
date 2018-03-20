using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Processing;

namespace DataObjects.Interfaces.Finance
{
    public interface ILoanDisbursementPostingDao
    {


        object SaveLoanDisbursementPosting(List<LoanDisbursementPosting> loanDisbursementPostings);

        object SearchLoanDisbursementPosting(LoanDisbursementPosting loanDisbursementPosting);


    }
}
