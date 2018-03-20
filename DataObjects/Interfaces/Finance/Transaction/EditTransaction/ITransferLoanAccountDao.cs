using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.EditTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface ITransferLoanAccountDao
    {


        object SaveTransferLoanAccount(TransferLoanAccount transferLoanAccount);

        object SearchTransferLoanAccount(TransferLoanAccount transferLoanAccount);



    }
}
