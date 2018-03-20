using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Processing;

namespace DataObjects.Interfaces.Finance
{
    public interface ILoanRepaymentDao
    {


        object SaveLoanRepayment(LoanRepayment loanRepayment);

        object SearchLoanRepayment(LoanRepayment loanRepayment);



        object GetLoanRepayment(string OfficeCode, string UserCode);

    }
}
