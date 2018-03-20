using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.EditTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface ILoanTransferProductDao
    {

        object SaveLoanTransferProduct(LoanTransferProduct loanTransferProduct);

        object SearchLoanTransferProduct(LoanTransferProduct loanTransferProduct);

        object GetLoanTransferProduct(string ProductName);

    }
}
