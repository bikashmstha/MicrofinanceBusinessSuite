using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.EditTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface ILoanTransferFromLoanDao
    {


        object SaveLoanTransferFromLoan(LoanTransferFromLoan loanTransferFromLoan);

        object SearchLoanTransferFromLoan(LoanTransferFromLoan loanTransferFromLoan);



        object GetLoanTransferFrmLoan(string OfficeCode, string CenterCode, string ClientNo, string ProductCode);

    }
}
