using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.LoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface ILoanTransferToClientDao
    {


        object SaveLoanTransferToClient(LoanTransferToClient loanTransferToClient);

        object SearchLoanTransferToClient(LoanTransferToClient loanTransferToClient);



        object GetLoanTransferToClient(string OfficeCode, string CenterCode, string ProductCode, string ClientName);

    }
}
