using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.LoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface ILoanInformationDao
    {


        object SaveLoanInformation(LoanInformation loanInformation);

        object SearchLoanInformation(LoanInformation loanInformation);



        object GetLoanInformation();

    }
}
