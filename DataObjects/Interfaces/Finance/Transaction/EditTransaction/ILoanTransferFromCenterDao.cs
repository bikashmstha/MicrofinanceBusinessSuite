using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.EditTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface ILoanTransferFromCenterDao
    {
        object GetLoanTransferFromCenter();

        object SaveLoanTransferFromCenter(LoanTransferFromCenter loanTransferFromCenter);

        object SearchLoanTransferFromCenter(LoanTransferFromCenter loanTransferFromCenter);



        object GetLoanTransferFrmCenter(string OfficeCode, string CenterName);

    }
}
