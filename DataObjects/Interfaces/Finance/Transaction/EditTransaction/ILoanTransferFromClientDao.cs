using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.EditTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface ILoanTransferFromClientDao
    {
        

        object SaveLoanTransferFromClient(LoanTransferFromClient loanTransferFromClient);

        object SearchLoanTransferFromClient(LoanTransferFromClient loanTransferFromClient);



        object GetLoanTransferFrmClient(string OfficeCode, string CenterCode, string ClientName);

    }
}
