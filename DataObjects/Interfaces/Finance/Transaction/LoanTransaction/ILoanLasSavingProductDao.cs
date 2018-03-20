using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.LoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface ILoanLasSavingProductDao
    {
        object Get();

        object Save(LoanLasSavingProduct loanLasSavingProduct);

        object Search(LoanLasSavingProduct loanLasSavingProduct);



        object GetLoanLasSavingProd(string ProductName);

    }
}
