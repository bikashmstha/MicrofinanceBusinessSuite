using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.LoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface ILoanCollateralDao
    {


        object SaveLoanCollateral(LoanCollateral loanCollateral);

        object Search(LoanCollateral loanCollateral);

        object GetLoanCollateral(string loanNo);

    }
}
