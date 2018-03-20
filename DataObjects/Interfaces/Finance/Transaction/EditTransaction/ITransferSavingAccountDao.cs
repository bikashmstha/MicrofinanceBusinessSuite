using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.EditTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface ITransferSavingAccountDao
    {


        object SaveTransferSavingAccount(TransferSavingAccount transferSavingAccount);

        object SearchTransferSavingAccount(TransferSavingAccount transferSavingAccount);



    }
}
